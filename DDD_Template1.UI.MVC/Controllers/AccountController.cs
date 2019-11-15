using AutoMapper;
using DDD_Template1.Domain.Entities;
using DDD_Template1.Domain.Interfaces.Notifications;
using DDD_Template1.Domain.Interfaces.Services;
using DDD_Template1.Infra.CrossCutting.Helpers;
using DDD_Template1.UI.MVC.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace DDD_Template1.UI.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        #region Private vars

        private readonly ILoginService _loginService;

        #endregion Private vars

        #region Ctors

        public AccountController(IMapper mapper, IDomainNotificationHandler notification, ILoginService loginService)
           : base(mapper, notification)
        {
            _loginService = loginService;
        }

        #endregion Ctors

        #region Actions

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login, string url)
        {
            var tokenResponse = GetTokenFromAPI(login);

            if (tokenResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (string.IsNullOrEmpty(url))
                {
                    return RedirectToAction("Index", "Home");
                }

                return Redirect(url);
            }

            AddToastWarningMessage("Invalid username or password!");

            return RedirectToAction("Index", "Account");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            RemoveCookies(USERCOOKIE);

            return RedirectToAction("Index");
        }

        private void SetUserCookie(string username)
        {
            var userCookie = CreateCookie(USERCOOKIE, JsonConvert.SerializeObject(username), CookieExpirationInMinutes);
        }

        #endregion Actions
    }
}