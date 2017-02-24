using RestSharp;
using simplelist.Component;
using simplelist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace simplelist.Controllers
{
    public class HomeController : Controller
    {
        private string getIP(HttpRequestBase request)
        {
            if (request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
            {
                return "not-found";
            }
            else
            {
                return request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(':')[0];
            }
        }
        private string getGeoIPData(string ip)
        {
            if (ip == "::1")
            {
                ip = "46.228.25.202";
            }
            var client = new RestClient(Properties.Settings.Default.GEOIPURL);
            var request = new RestRequest("/" + ip, Method.GET);
            var queryResult = client.Execute<GeoIPHelper.RootObject>(request).Data;
            if (queryResult == null)
            {
                return string.Format(" Your IP [{0}] - VNET not connected", ip);
            }
            else if (queryResult.Data == null)
            {
                return string.Format(" Your IP [{0}] - invalid search argument", ip);
            }
            else
            {
                return string.Format(" Your IP [{0}] - {1}, {2}, {3}/{4}",
                    ip,
                    queryResult.Data.Country.Names.en,
                    (queryResult.Data.City.Names == null ? "Unknown-City" : queryResult.Data.City.Names.en),
                    queryResult.Data.Location.Latitude,
                    queryResult.Data.Location.Longitude);
            }
        }

        public ActionResult Index()
        {
            ViewBag.LinuxData = "VNET not connected!";
            try
            {
                ViewBag.LinuxData = getGeoIPData(getIP(Request));
            }
            catch(Exception e)
            {
                ViewBag.LinuxData = e.ToString();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}