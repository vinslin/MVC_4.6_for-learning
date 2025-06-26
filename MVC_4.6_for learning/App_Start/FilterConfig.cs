using System.Web;
using System.Web.Mvc;

namespace MVC_4._6_for_learning
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
