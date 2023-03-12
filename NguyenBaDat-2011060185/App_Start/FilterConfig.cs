using System.Web;
using System.Web.Mvc;

namespace NguyenBaDat_2011060185
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
