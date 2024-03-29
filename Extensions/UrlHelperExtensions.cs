using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DrugVerizone.Controllers;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountsController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountsController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
