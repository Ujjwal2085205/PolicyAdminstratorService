using Insureity_Portal.Models;
using Insureity_Portal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Insureity_Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));
        private readonly IHomeService _HomeService;

        private IConfiguration configuration;

        public HomeController(IConfiguration _configuration, IHomeService HomeService)
        {
            configuration = _configuration;
            _HomeService = HomeService;
        }

        public IActionResult Index()
        {
            ViewBag.Agent = HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult Logout()
        {
            _log4net.Info(nameof(Logout) + " method invoked.");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult CreatePolicyRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering details to create policy");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePolicyRequest(CreatePolicy createPolicy)
        {


            _log4net.Info($"Sending a request to [Policy] service to add Policy details");

            var httpResponse = await _HomeService.CreatePolicyRequest(createPolicy);

            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[Policy] service return with {httpResponse.StatusCode} status code");

                return View("Error");
            }
            _log4net.Info($"[Policy] service return with {httpResponse.StatusCode} status code");
            _log4net.Info($"Policy created successfully.");

            ViewBag.Result = "Policy created successfully.";
            return View("Result");

        }
        public IActionResult IssuePolicyRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering details to issue policy");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IssuePolicyRequest(IssuePolicy issuePolicy)
        {

            var httpResponse = await _HomeService.IssuePolicyRequest(issuePolicy);
            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[Policy] service return with {httpResponse.StatusCode} status code");
                return View("Error");
            }
            _log4net.Info($"[Policy] service return with {httpResponse.StatusCode} status code");
            _log4net.Info($"Policy issued successfully.");
            ViewBag.Result = "Policy issued successfully.";
            return View("Result");
        }

        /// <summary>
        /// View policy 
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewPolicyRequest()
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering details to View Policy");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewPolicyRequest(ViewPolicy viewPolicy)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info($"Fetching policy details.");

            var httpResponse = await _HomeService.ViewPolicyRequest(viewPolicy);
            var responseStr = await httpResponse.Content.ReadAsStringAsync();
            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[Policy] service returned with {httpResponse.StatusCode} status code");
                return View("Error");
            }
            PolicyDetails policyDetail = JsonConvert.DeserializeObject<PolicyDetails>(responseStr);
            if (policyDetail != null)
            {
                return View("PolicyDetail", policyDetail);
            }

            ViewBag.Message = "Unable to view details at the moment.";
            return View();
        }

        public IActionResult GetQuotesRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Quotes details");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetQuotesRequest(GetQuotes getQuotes)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            var httpResponse = await _HomeService.GetQuotesRequest(getQuotes);

            var responseStr = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                ViewBag.statuscode = httpResponse.StatusCode;
                _log4net.Error($"[Policy] service returned with {httpResponse.StatusCode} status code");
                return View("Error");
            }
            var quotes = JsonConvert.DeserializeObject<string>(responseStr);

            if (quotes != null)
            {
                ViewBag.quote = quotes;
                return View("quotesValue");
            }

            ViewBag.Message = "Unable to get quotes at the moment.";
            return View();
        }
        private string SessionToken { get => HttpContext.Session.GetString("token"); }
    }
}
