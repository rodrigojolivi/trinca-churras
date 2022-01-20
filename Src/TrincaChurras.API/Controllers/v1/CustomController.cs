using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TrincaChurras.Core.Validators;

namespace TrincaChurras.API.Controllers.v1
{
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomController()
        {
        }

        public CustomController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected Guid GetIdUser()
        {
            return new Guid(GetClaims().First(x => x.Type == "id").Value);
        }

        protected bool HasNotifications(List<Notification> notifications)
        {
            return notifications.Count > 0;
        }

        protected IEnumerable<string> FormatNotifications(List<Notification> notifications)
        {
            return notifications.Select(x => x.Message);
        }

        protected IEnumerable<string> FormatNotifications(ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage));
        }

        private IEnumerable<Claim> GetClaims()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }
    }
}
