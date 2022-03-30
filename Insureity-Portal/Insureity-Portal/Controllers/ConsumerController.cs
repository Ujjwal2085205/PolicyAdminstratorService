using Insureity_Portal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Insureity_Portal.Services;

namespace Insureity_Portal.Controllers
{
    public class ConsumerController : Controller
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));
        private IConfiguration configuration;
        private readonly IConsumerService _ConsumerService;
        public ConsumerController(IConfiguration _configuration, IConsumerService consumerService)
        {
            configuration = _configuration;
            _ConsumerService = consumerService;
        }

        public IActionResult ViewConsumerBusinessRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Details to View Consumer Business");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewConsumerBusinessRequest(ViewConsumerBusiness viewConsumerBusiness)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info($"Fetching Consumer Business details.");
            string consumerId = viewConsumerBusiness.ConsumerId;
            string businessId = viewConsumerBusiness.BusinessId;
            ConsumerBusinessDetails consumerBusinessDetail = await GetConsumerBusinessDetails(consumerId, businessId);

            if (consumerBusinessDetail != null)
            {
                return View("ConsumerBusinessDetail", consumerBusinessDetail);
            }

            ViewBag.Message = "Unable to view consumer business at the moment.";
            return View();
        }

        /// <summary>
        /// update consumer business
        /// </summary>
        /// <param name="viewConsumerBusiness"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateConsumerBusiness(string consumerId, string businessId)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            ConsumerBusinessDetails consumerBusiness = await GetConsumerBusinessDetails(consumerId, businessId);
            if (consumerBusiness != null)
            {
                return View(consumerBusiness);
            }
            else
            {
                ViewBag.Message = "Unable to update at the moment. Try later.";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var httpResponse = await _ConsumerService.UpdateConsumerBusiness(consumerBusiness);

            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code.");

                return View("Error");
            }
            _log4net.Info($"Consumer Business details updated successfuly.");

            ViewBag.Result = "Consumer Business details Updated successfully";
            return View("Result");

        }
        public IActionResult CreateConsumerBusinessRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Details to create Consumer Business");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateConsumerBusinessRequest(ConsumerBusiness consumerBusiness)
        {
            var httpResponse = await _ConsumerService.CreateConsumerBusinessRequest(consumerBusiness);

            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[consumer] service return with {httpResponse.StatusCode} status code");

                return View("Error");
            }

            _log4net.Info($"Consumer Business created successfully.");
            ViewBag.Result = "Consumer Business created successfully";
            return View("Result");
        }
        private async Task<ConsumerBusinessDetails> GetConsumerBusinessDetails(string ConsumerId, string BusinessId)
        {

            string bearerToken = $"Bearer {SessionToken}";
            //   client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

            var httpResponse = await _ConsumerService.GetConsumerBusinessDetails(ConsumerId, BusinessId);

            var responseStr = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code");
                return null;
            }
            ConsumerBusinessDetails consumerBusiness = JsonConvert.DeserializeObject<ConsumerBusinessDetails>(responseStr);
            return consumerBusiness;
        }

        public IActionResult ViewBusinessPropertyRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Details to View Business Property");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewBusinessPropertyRequest(ViewBusinessProperty viewBusinessProperty)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info($"Fetching Consumer Business details.");
            string consumerId = viewBusinessProperty.ConsumerId;
            string propertyId = viewBusinessProperty.PropertyId;
            BusinessPropertyDetails businessProperty = await GetBusinessProperty(consumerId, propertyId);

            if (businessProperty != null)
            {
                return View("BusinessPropertyDetail", businessProperty);
            }

            ViewBag.Message = "Unable to view business property details at the moment.";
            return View();
        }


        public async Task<IActionResult> UpdateBusinessProperty(string consumerId, string propertyId)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            BusinessPropertyDetails businessProperty = await GetBusinessProperty(consumerId, propertyId);
            if (businessProperty != null)
            {
                return View(businessProperty);
            }
            else
            {
                ViewBag.Message = "Unable to update at the moment. Try later.";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBusinessProperty(BusinessProperty businessProperty)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            var httpResponse = await _ConsumerService.UpdateBusinessProperty(businessProperty);

            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code.");
                return View("Error");
            }

            _log4net.Info($"Business property details updated successfuly.");
            ViewBag.Result = "Business Property details updated successfuly.";
            return View("Result");

        }

        public IActionResult CreateBusinessPropertyRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Details to create Business Property");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessPropertyRequest(BusinessProperty businessProperty)
        {

            var httpResponse = await _ConsumerService.CreateBusinessPropertyRequest(businessProperty);

            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[consumer] service return with {httpResponse.StatusCode} status code");
                return View("Error");
            }

            _log4net.Info($"Business Property created successfully.");
            ViewBag.Result = "Business Property created successfully.";
            return View("Result");

        }

        private async Task<BusinessPropertyDetails> GetBusinessProperty(string ConsumerId, string PropertyId)
        {
            using var httpResponse = await _ConsumerService.GetBusinessProperty(ConsumerId, PropertyId);
            var responseStr = await httpResponse.Content.ReadAsStringAsync();
            if (!httpResponse.IsSuccessStatusCode)
            {
                _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code");
                return null;
            }
            BusinessPropertyDetails businessProperty = JsonConvert.DeserializeObject<BusinessPropertyDetails>(responseStr);
            return businessProperty;
        }
        private string SessionToken { get => HttpContext.Session.GetString("token"); }
    }
}
