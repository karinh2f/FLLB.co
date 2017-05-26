using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLLB.Models;
using FLLB.Repos;

namespace FLLB.Controllers
{
    public class BaseController : Controller
    {
        public static int FromHex(string value)
        {

            if (value == null) return 0;
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            try
            {
                return Int32.Parse(value, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}