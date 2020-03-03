using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace OnlineTourismManagement.AuthData
{
    public class Authentication : ActionFilterAttribute, IAuthenticationFilter
    {
        private bool isAuth;
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            isAuth = (filterContext.ActionDescriptor.GetCustomAttributes
               (typeof(OverrideAuthenticationAttribute), true).Length == 0);
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if(user==null||!user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}