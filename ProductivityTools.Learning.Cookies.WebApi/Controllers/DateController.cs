﻿using Microsoft.AspNetCore.Mvc;

namespace ProductivityTools.Learning.Cookies.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public string Index()
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.SameSite = SameSiteMode.None;
            //cookieOptions.Path = "/";
            cookieOptions.Secure = true;
            cookieOptions.HttpOnly = true;
            Response.Cookies.Append("SomeCookie", "SomeValue", cookieOptions);
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("access-control-expose-headers", "Set-Cookie");
            Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:3000");


            return DateTime.Now.ToString();
        }

        private const string MimeType = "image/png";
        private const string FileName = "CM-Logo.png";

        [HttpGet]
        [Route("Image")]
        public IActionResult Get()
        {
            var ookies = Request.Cookies;
            string value = string.Empty;
            ookies.TryGetValue("SomeCookie", out value);
          
            FileStream file = new FileStream("image.png", FileMode.Open);

            return File(file, MimeType, FileName);
        }
    }
}
