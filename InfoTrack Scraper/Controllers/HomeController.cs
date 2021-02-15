using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace InfoTrack_Scraper.Controllers
{
    public class HomeController : Controller
    {
        #region Dummy Data Explained
        //If you wish to use Dummy Data, Please uncomment  the Saved Data Variable and replace the File path to where you have saved the file that came with the project.
        //then uncomment "tempdata = SavedData" in the SearchRes method and comment out the webrequest and response block of code inbetween the dashes.
        //If you need help please see the readme file for further details. 
        #endregion
        //string DummyData = System.IO.File.ReadAllText(@"C:\Users\ali\Downloads\tempdata.txt"); //Dummy Data
        string tempData;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchRes()
        {
            //tempData = DummyData; //Only Uncomment if you wish to use dummy data

            //----------------------
            WebRequest webRequest = WebRequest.Create("https://www.google.co.uk/search?num=100&q=land+registry+search");
            WebResponse webResponse = webRequest.GetResponse();

            using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
            {
                string siteSource = responseReader.ReadToEnd();
                tempData = siteSource;
            }
            //----------------------
            if (!string.IsNullOrEmpty(tempData))
            {
                List<int> ele = new List<int>();
                Regex rgx = new Regex("class=\"BNeawe UPmit AP7Wnd\">");
                foreach (Match match in rgx.Matches(tempData))
                {
                    ele.Add(match.Index);
                }

                List<int> ele2 = new List<int>();
                Regex rgx2 = new Regex("class=\"BNeawe UPmit AP7Wnd\">www.infotrack.co.uk");
                foreach (Match match in rgx2.Matches(tempData))
                {
                    ele2.Add(match.Index);
                }
                if (!(ele == null && ele2 == null))
                {
                    var res = (from a in ele
                               join b in ele2
                               on a equals b
                               select new
                               {
                                   C = ele2.Count,
                                   P = ele.IndexOf(a) + 1
                               }).ToList();

                    ViewBag.r = res.Select(x => x.C);
                    ViewBag.rr = res.Select(x => x.P);
                }
                else
                {
                    ViewBag.r = "";
                    ViewBag.rr = "";
                }
            }
            else
            {
                ViewBag.r = "";
                ViewBag.rr = "";
            }
            return View();
        }

        [HttpPost]
        public ActionResult SearchRes(FormCollection form)
        {
            string search = form["Search"];
            var searchO = search.Replace(" ", "+");
            string URLI = form["URL"];
            var URLO = URLI.Replace(" ", "+");

            if (!string.IsNullOrEmpty(search))
            {
                WebRequest webRequest = WebRequest.Create("https://www.google.co.uk/search?num=100&q=" + searchO);
                WebResponse webResponse = webRequest.GetResponse();
                using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string siteSource = responseReader.ReadToEnd();
                    tempData = siteSource;
                }
            }
            else if (!string.IsNullOrEmpty(URLI))
            {
                WebRequest webRequest = WebRequest.Create(URLO);
                WebResponse webResponse = webRequest.GetResponse();
                using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string siteSource = responseReader.ReadToEnd();
                    tempData = siteSource;
                }
            }

            if (!string.IsNullOrEmpty(tempData))
            {
                List<int> ele = new List<int>();
                Regex rgx = new Regex("class=\"BNeawe UPmit AP7Wnd\">");
                foreach (Match match in rgx.Matches(tempData))
                {
                    ele.Add(match.Index);
                }

                List<int> ele2 = new List<int>();
                Regex rgx2 = new Regex("class=\"BNeawe UPmit AP7Wnd\">www.infotrack.co.uk");
                foreach (Match match in rgx2.Matches(tempData))
                {
                    ele2.Add(match.Index);
                }

                if (!(ele == null && ele2 == null))
                {
                    var res = (from a in ele
                               join b in ele2
                               on a equals b
                               select new
                               {
                                   C = ele2.Count,
                                   P = ele.IndexOf(a) + 1
                               }).ToList();

                    ViewBag.r = res.Select(x => x.C);
                    ViewBag.rr = res.Select(x => x.P);
                }
                else
                {
                    ViewBag.r = "";
                    ViewBag.rr = "";
                }
            }
            else
            {
                ViewBag.r = "";
                ViewBag.rr = "";
            }

            return View();
        }
    }
}