﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuotesMicroservice.Filters
{
    public class TokenValidation : Attribute, IAuthorizationFilter

    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            StringValues token;
            filterContext.HttpContext.Request.Headers.TryGetValue("Authorization", out token);

            if (ValidateToken(token.FirstOrDefault()))
            {
                return;
            }
            else
                filterContext.Result = new UnauthorizedResult();

        }
        public bool ValidateToken(string token)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44369/api/Auth/");
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = client.GetAsync("Validate").Result;
                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
