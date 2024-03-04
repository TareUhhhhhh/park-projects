using Jenzabar.Portal.Framework.Configuration;
using Jenzabar.Portal.Framework.Web.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using System.Linq;

namespace PARK_Student_Club_v1_12_22_2023
{
    public partial class wuc_Welcome : PortletViewBase
    {
        //private string funScreenScrape(string strURL)
        //{
        //    string strReader = "";
        //    WebResponse obj;
        //    WebRequest obj1 = System.Net.HttpWebRequest.Create(strURL);
        //    obj = obj1.GetResponse();
        //    using (StreamReader sr = new StreamReader(obj.GetResponseStream()))
        //    {
        //        strReader = sr.ReadToEnd();
        //        sr.Close();
        //    }
        //    return strReader;
        //}

        private static string funScreenScrape(string strURL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);

                // Set the User-Agent header to simulate a mobile device (iPhone)
                request.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 14_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0 Mobile/15E148 Safari/604.1";

                using (WebResponse response = request.GetResponse())
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                // Handle exceptions (e.g., network errors, invalid URLs, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public string funCleanHtml(string strHTML)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(strHTML);

            // Remove script tags
            var nodes = doc.DocumentNode.DescendantsAndSelf()
                .Where(n => n.Name == "script").ToList();

            foreach (var node in nodes)
                node.Remove();

            // Return the cleaned HTML
            return doc.DocumentNode.OuterHtml;
        }

        protected void funLoadResources()
        {
            string strHTML = "";
            try
            {
                strHTML = funScreenScrape("https://my.park.edu/ics/_portletview_/Campus_Life/Admin_Area/Resources/Default_Page.jnz?portlet=Bookmarks");
                strHTML = strHTML.Replace("<div id=\"portlets\" class=\"container\">", "<div id=\"portlets\">");
                strHTML = funCleanHtml(strHTML);
            }
            catch (Exception expError)
            {
                strHTML = "Fail - "+ expError.Message.ToString();
            }
            lblResources.Text = strHTML;
            return;
        }

        protected void funLoadForms()
        {
            string strHTML = "";
            try
            {
                strHTML = funScreenScrape("https://my.park.edu/ics/_portletview_/Campus_Life/Admin_Area/Resources/Default_Page.jnz?portlet=Bookmarks");
                strHTML = strHTML.Replace("<div id=\"portlets\" class=\"container\">", "<div id=\"portlets\">");

                strHTML = funCleanHtml(strHTML);
            }
            catch (Exception expError)
            {
                strHTML = "Fail - " + expError.Message.ToString();
            }
            lblForms.Text = strHTML;
            return;
        }

        protected void funLoadVolunteer()
        {
            string strHTML = "";
            try
            {
                strHTML = funScreenScrape("https://sites.google.com/park.edu/parkvolunteersite/volunteer-sites");
                strHTML = strHTML.Replace("<link rel=\"icon\" href=\"https://ssl.gstatic.com/atari/images/public/favicon.ico\">", "");
                strHTML = funCleanHtml(strHTML);
            }
            catch (Exception expError)
            {

            }
            lblVolunteer.Text = strHTML;
            return;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            funLoadResources();
            funLoadForms();
            funLoadVolunteer();
            return;
        }
    }
}
