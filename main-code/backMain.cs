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
using Jenzabar.Portal.Web.ErrorPages;
using System.Web.UI.WebControls.WebParts;
using Jenzabar.Common;
using Jenzabar.Common.Configuration;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Framework.Facade;
using Settings = Jenzabar.Common.Configuration.ConfigSettings;
using AjaxControlToolkit;

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
            string strHTMLResults = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);


                using (WebResponse response = request.GetResponse())
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    strHTMLResults = sr.ReadToEnd();

                }
            }
            catch (Exception expError)
            {
                strHTMLResults = "Fail - " + expError.Message.ToString();
            }
            return strHTMLResults;
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

        protected string funLoadResources()
        {
            string strHTML = "";
            string strHTMLHandouts = "";
            string strHTMLBookmark = "";

            //  **** No forms currently being used ** //
            //try
            //{
            //    strHTMLHandouts = funScreenScrape(Settings.GetConfigValue("PARK_StudentClub_v1", "strPortletResourcesBookmarks"));
            //    strHTMLHandouts = strHTMLHandouts.Replace("<div id=\"portlets\" class=\"container\">", "<div id=\"portlets\">");
            //    strHTMLHandouts = strHTMLHandouts.Replace(" #mainLayout {  width: 100%; margin-top: auto; padding: 0; }\r\n ", " #mainLayout {  width: 100%; padding: 0; }\r\n ");
            //    strHTMLHandouts = strHTMLHandouts.Replace("<div class=\"row\">\r\n        <div class=\"col-xs-6\">\r\n            \r\n        </div>\r\n        <div id=\"pg0_V_ViewSelectionIconsContainer\" class=\"col-xs-6\">\r\n           <div class=\"view-toggle-container float-right\">\r\n            <a id=\"pg0_V_ListViewLink\" class=\"view-icon\" href=\"/ics/_portletview_/Campus_Life/Admin_Area/Resources/Default_Page.jnz?portlet=Bookmarks&amp;pvt_c3ee596a-fa44-4d55-8378-65d3a527722e=List\"><span id=\"pg0_V_ListViewIconDescription\" class=\"sr-only\">Bookmarks list view</span><span id=\"pg0_V_ListViewIcon\" class=\"glyphicons glyphicons-list-alt body-text\"></span></a>\r\n            <a id=\"pg0_V_CardLayoutLink\" class=\"view-icon\" href=\"/ics/_portletview_/Campus_Life/Admin_Area/Resources/Default_Page.jnz?portlet=Bookmarks&amp;pvt_c3ee596a-fa44-4d55-8378-65d3a527722e=Card\"><span id=\"pg0_V_CardViewIconDescription\" class=\"sr-only\">Bookmarks card view</span><span id=\"pg0_V_CardViewIcon\" class=\"glyphicons glyphicons-show-thumbnails accent\"></span></a>\r\n        </div>\r\n        </div>\r\n    </div>", "<h2 style=\"margin-top: unset;\">Resources</h2>");
            //    strHTMLHandouts = strHTMLHandouts.Replace("class=\"main-layout container\"", "class=\"portlet-import container\"");
            //    strHTMLHandouts = funCleanHtml(strHTMLHandouts);
            //}
            //catch (Exception expError)
            //{
            //    strHTMLHandouts = "Fail - " + expError.Message.ToString();
            //}

            try
            {
                strHTMLBookmark = funScreenScrape(Settings.GetConfigValue("PARK_StudentClub_v1", "strPortletResourcesBookmarks"));
                strHTMLBookmark = strHTMLBookmark.Replace("<div id=\"portlets\" class=\"container\">", "<div id=\"portlets\">");
                strHTMLBookmark = strHTMLBookmark.Replace(" #mainLayout {  width: 100%; margin-top: auto; padding: 0; }\r\n ", " #mainLayout {  width: 100%; padding: 0; }\r\n ");
                strHTMLBookmark = strHTMLBookmark.Replace("<div class=\"row\">\r\n        <div class=\"col-xs-6\">\r\n            \r\n        </div>\r\n        <div id=\"pg0_V_ViewSelectionIconsContainer\" class=\"col-xs-6\">\r\n           <div class=\"view-toggle-container float-right\">\r\n            <a id=\"pg0_V_ListViewLink\" class=\"view-icon\" href=\"/ics/_portletview_/Campus_Life/Admin_Area/Resources/Default_Page.jnz?portlet=Bookmarks&amp;pvt_c3ee596a-fa44-4d55-8378-65d3a527722e=List\"><span id=\"pg0_V_ListViewIconDescription\" class=\"sr-only\">Bookmarks list view</span><span id=\"pg0_V_ListViewIcon\" class=\"glyphicons glyphicons-list-alt body-text\"></span></a>\r\n            <a id=\"pg0_V_CardLayoutLink\" class=\"view-icon\" href=\"/ics/_portletview_/Campus_Life/Admin_Area/Resources/Default_Page.jnz?portlet=Bookmarks&amp;pvt_c3ee596a-fa44-4d55-8378-65d3a527722e=Card\"><span id=\"pg0_V_CardViewIconDescription\" class=\"sr-only\">Bookmarks card view</span><span id=\"pg0_V_CardViewIcon\" class=\"glyphicons glyphicons-show-thumbnails accent\"></span></a>\r\n        </div>\r\n        </div>\r\n    </div>", "<h2 style=\"margin-top: unset;\">Resources</h2>");
                strHTMLBookmark = strHTMLBookmark.Replace("class=\"main-layout container\"", "class=\"portlet-import container\"");
                strHTMLBookmark = funCleanHtml(strHTMLBookmark);
            }
            catch (Exception expError)
            {
                strHTMLBookmark = "Fail - " + expError.Message.ToString();
            }

            strHTML = strHTMLHandouts + strHTMLBookmark;
            return strHTML;
        }


        //  ******* Removed to have pulling forms and 
        //protected void funLoadForms()
        //{
        //    string strHTML = "";
        //    try
        //    {
        //        strHTML = funScreenScrape(Settings.GetConfigValue("PARK_StudentClub_v1", "strPortletFormsHandouts"));
        //        strHTML = strHTML.Replace("<div id=\"portlets\" class=\"container\">", "<div id=\"portlets\">");
        //        strHTML = strHTML.Replace(" #mainLayout {  width: 100%; margin-top: auto; padding: 0; }\r\n ", " #mainLayout {  width: 100%; padding: 0; }\r\n ");
        //        strHTML = strHTML.Replace("<div class=\"row\">\r\n        <div class=\"col-xs-6\">\r\n            \r\n        </div>\r\n        <div id=\"pg0_V_ViewSelectionIconsContainer\" class=\"col-xs-6\">\r\n           <div class=\"view-toggle-container float-right\">\r\n            <a id=\"pg0_V_ListViewLink\" class=\"view-icon\" href=\"/ics/_portletview_/Campus_Life/Admin_Area/Forms/Default_Page.jnz?portlet=Handouts&amp;pvt_4ef89935-96fb-4b3d-9ea9-9eb327b2eb42=List\"><span id=\"pg0_V_ListViewIconDescription\" class=\"sr-only\">Handouts list view</span><span id=\"pg0_V_ListViewIcon\" class=\"glyphicons glyphicons-list-alt body-text\"></span></a>\r\n            <a id=\"pg0_V_CardLayoutLink\" class=\"view-icon\" href=\"/ics/_portletview_/Campus_Life/Admin_Area/Forms/Default_Page.jnz?portlet=Handouts&amp;pvt_4ef89935-96fb-4b3d-9ea9-9eb327b2eb42=Card\"><span id=\"pg0_V_CardViewIconDescription\" class=\"sr-only\">Handouts card view</span><span id=\"pg0_V_CardViewIcon\" class=\"glyphicons glyphicons-show-thumbnails accent\"></span></a>\r\n        </div>\r\n        </div>\r\n    </div>", "<h2 style=\"margin-top: unset;\">Forms</h2>");
        //        strHTML = strHTML.Replace("class=\"main-layout container\"", "class=\"portlet-import container\"");
        //        strHTML = funCleanHtml(strHTML);
        //    }
        //    catch (Exception expError)
        //    {
        //        strHTML = "Fail - " + expError.Message.ToString();
        //    }
        //    lblForms.Text = strHTML;
        //    return;
        //}


        protected string funLoadForms()
        {
            string strHTML = "";
            string strHTMLHandouts = "";
            string strHTMLBookmark = "";


            try
            {
                strHTMLHandouts = funScreenScrape(Settings.GetConfigValue("PARK_StudentClub_v1", "strPortletFormsHandouts"));
                strHTMLHandouts = strHTMLHandouts.Replace("<div id=\"portlets\" class=\"container\">", "<div id=\"portlets\">");
                strHTMLHandouts = strHTMLHandouts.Replace(" #mainLayout {  width: 100%; margin-top: auto; padding: 0; }\r\n ", " #mainLayout {  width: 100%; padding: 0; }\r\n ");
                strHTMLHandouts = strHTMLHandouts.Replace("<div class=\"row\">\r\n        <div class=\"col-xs-6\">\r\n            \r\n        </div>\r\n        <div id=\"pg0_V_ViewSelectionIconsContainer\" class=\"col-xs-6\">\r\n           <div class=\"view-toggle-container float-right\">\r\n            <a id=\"pg0_V_ListViewLink\" class=\"view-icon\" href=\"/ics/_portletview_/Campus_Life/Admin_Area/Forms/Default_Page.jnz?portlet=Handouts&amp;pvt_4ef89935-96fb-4b3d-9ea9-9eb327b2eb42=List\"><span id=\"pg0_V_ListViewIconDescription\" class=\"sr-only\">Handouts list view</span><span id=\"pg0_V_ListViewIcon\" class=\"glyphicons glyphicons-list-alt body-text\"></span></a>\r\n            <a id=\"pg0_V_CardLayoutLink\" class=\"view-icon\" href=\"/ics/_portletview_/Campus_Life/Admin_Area/Forms/Default_Page.jnz?portlet=Handouts&amp;pvt_4ef89935-96fb-4b3d-9ea9-9eb327b2eb42=Card\"><span id=\"pg0_V_CardViewIconDescription\" class=\"sr-only\">Handouts card view</span><span id=\"pg0_V_CardViewIcon\" class=\"glyphicons glyphicons-show-thumbnails accent\"></span></a>\r\n        </div>\r\n        </div>\r\n    </div>", "<h2 style=\"margin-top: unset;\">Forms</h2>");
                strHTMLHandouts = strHTMLHandouts.Replace("class=\"main-layout container\"", "class=\"portlet-import container\"");
                strHTMLHandouts = funCleanHtml(strHTMLHandouts);
            }
            catch (Exception expError)
            {
                strHTMLHandouts = "Fail - " + expError.Message.ToString();
            }

            try
            {
                strHTMLBookmark = funScreenScrape(Settings.GetConfigValue("PARK_StudentClub_v1", "strPortletFormsBookmarks"));
                strHTMLBookmark = strHTMLBookmark.Replace("<div id=\"portlets\" class=\"container\">", "<div id=\"portlets\">");
                strHTMLBookmark = strHTMLBookmark.Replace(" #mainLayout {  width: 100%; margin-top: auto; padding: 0; }\r\n ", " #mainLayout {  width: 100%; padding: 0; }\r\n ");
                strHTMLBookmark = strHTMLBookmark.Replace("<div class=\"row\">\r\n        <div class=\"col-xs-6\">\r\n            \r\n        </div>\r\n        <div id=\"pg0_V_ViewSelectionIconsContainer\" class=\"col-xs-6\">\r\n           <div class=\"view-toggle-container float-right\">\r\n            <a id=\"pg0_V_ListViewLink\" class=\"view-icon\" href=\"/ICS/_portletview_/Campus_Life/Admin_Area/Forms/Default_Page.jnz?portlet=Bookmarks&amp;pvt_91881b07-a55c-4548-bc6f-627d3850d4d0=List\"><span id=\"pg0_V_ListViewIconDescription\" class=\"sr-only\">Bookmarks list view</span><span id=\"pg0_V_ListViewIcon\" class=\"glyphicons glyphicons-list-alt body-text\"></span></a>\r\n            <a id=\"pg0_V_CardLayoutLink\" class=\"view-icon\" href=\"/ICS/_portletview_/Campus_Life/Admin_Area/Forms/Default_Page.jnz?portlet=Bookmarks&amp;pvt_91881b07-a55c-4548-bc6f-627d3850d4d0=Card\"><span id=\"pg0_V_CardViewIconDescription\" class=\"sr-only\">Bookmarks card view</span><span id=\"pg0_V_CardViewIcon\" class=\"glyphicons glyphicons-show-thumbnails accent\"></span></a>\r\n        </div>\r\n        </div>\r\n    </div>", "<h2 id=\"clubLinks\" style=\"margin-top: unset;\">Club Links</h2>");
                strHTMLBookmark = strHTMLBookmark.Replace("class=\"main-layout container\"", "class=\"portlet-import container\"");
                strHTMLBookmark = funCleanHtml(strHTMLBookmark);
            }
            catch (Exception expError)
            {
                strHTMLBookmark = "Fail - " + expError.Message.ToString();
            }

            strHTML = strHTMLHandouts + strHTMLBookmark;
            return strHTML;
        }

        protected string funLoadVolunteer()
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
            return strHTML;
        }

        protected string funPosterCode()
        {
            string strHTML = "";
            
            try
            {
                lblPosterCode.Text = "\n<!-- Right Column: Poster -->";
                lblPosterCode.Text += "\n<div class=\"col-md-4\">";
                lblPosterCode.Text += "\n<div class=\"poster-slides\">";
                lblPosterCode.Text += "\n<div class=\"slideshow-container\">";

                for (int intPosterCounter = 1; intPosterCounter < 11; intPosterCounter++)
                {
                    lblPosterCode.Text += "\n<div class=\"slide\" onclick=\"openModal();currentSlide(" +intPosterCounter+ ")\">";
                    lblPosterCode.Text += "<img src=\"" + Settings.GetConfigValue("PARK_StudentClubPoster_S", +intPosterCounter + "") + "\"></div>";
                }

                lblPosterCode.Text += "<!-- Navigation arrows -->       \n         <a class=\"prev\" onclick=\"changeSlide(-1)\">&#10094;</a>       \n         <a class=\"next\" onclick=\"changeSlide(1)\">&#10095;</a>      \n          </div>";

                lblPosterCode.Text += "\n<!-- Slide indicators(dots) -->  \n <div class=\"dot-container\">";

                for (int intPosterCounter = 1; intPosterCounter < 11; intPosterCounter++)
                {
                    lblPosterCode.Text += "\n<span class=\"dot\" onclick=\"currentSlide("+intPosterCounter+")\"></span>";
                }

                lblPosterCode.Text += "</div>";

                lblPosterCode.Text += "\r\n<!-- The Modal -->\r\n                <div id=\"myModal\" class=\"modal\">\r\n                <span class=\"close-modal cursor\" onclick=\"closeModal()\">&times;</span>\r\n                <div class=\"modal-content\">\r\n";

                for (int intPosterCounter = 1; intPosterCounter < 11; intPosterCounter++)
                {
                    lblPosterCode.Text += "\r\n<div class=\"mySlides\"><img src=\"" + Settings.GetConfigValue("PARK_StudentClubPoster_L", +intPosterCounter + "" ) + "\"></div>\r\n";
                }

                lblPosterCode.Text += "</div>\r\n                </div>\r\n                </div>";
            }

            catch (Exception expError)
            {

            }

            strHTML = lblPosterCode.Text;

            return strHTML;

        }

    protected void Page_Load(object sender, EventArgs e)
        {
            lblResources.Text = funLoadResources();
            lblForms.Text = funLoadForms();
            lblVolunteer.Text = funLoadVolunteer();
            lblPosterCode.Text = funPosterCode();
            return;
        }

    }
}