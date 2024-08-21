using System.Collections.Generic;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private static readonly object _lock = new object();
        private const string QueryKey = "QueryKey";
        private const string EntityKey = "ListEntitiesKey";

        [WebMethod]
        public string GetQuery()
        {
            lock (_lock)
            {
                return Application[QueryKey] as string;
            }
        }

        [WebMethod]
        public string SetQuery(string query)
        {
            lock (_lock)
            {
                Application[QueryKey] = query;
                return query;
            }
        }

        [WebMethod]
        public void ClearQuery()
        {
            lock (_lock)
            {
                Application[QueryKey] = null;
            }
        }

        [WebMethod]
        public List<string> SetListEntities(List<string> listEntities)
        {
            lock (_lock)
            {
                Application[EntityKey] = listEntities;
                return listEntities;
            }
        }

        [WebMethod]
        public List<string> GetListEntities()
        {
            lock (_lock)
            {
                return Application[EntityKey] as List<string>;
            }
        }
    }
}
