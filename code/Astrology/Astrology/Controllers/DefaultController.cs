using Astrology.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astrology.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index() => View();
        [HttpPost]
        public string index(ContactUsViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return "invalid input";
            }
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(string.Empty);
                sb.AppendFormat("Name: {0}<br/>", cvm.Name);
                sb.AppendFormat("Mobile: {0}<br/>", cvm.Mobile);
                sb.AppendFormat("Email: {0}<br/>", cvm.Email);
                sb.AppendFormat("City: {0}<br/>", cvm.City);
                sb.AppendFormat("Message: {0}<br/>", cvm.Message);

                EmailModule.SendEmail("Contact ( Bangalore Super Strikers ): ", sb.ToString(), null, cvm.Email);

                return "success";
            }
            catch (Exception)
            {
                return "error";
            }
        }

    }
}