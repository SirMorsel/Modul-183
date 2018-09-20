using System.Web;
using System.Web.Mvc;

namespace two_factor_ath_totp_google
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
