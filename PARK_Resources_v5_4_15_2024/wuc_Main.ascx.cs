using System;
using Jenzabar.Common;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Framework.Configuration;
using Jenzabar.Portal.Framework.Data;
using Jenzabar.Portal.Framework.Web;
using Jenzabar.Portal.Framework.Web.UI;
using Jenzabar.Portal.Framework.Preferences;
using Jenzabar.Portal.Framework.Security.Authorization;
using Park_MyParkDLL_v2_11_15_2013;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARK_Resources_v5_4_15_2024
{
    public partial class wuc_Main : PortletViewBase
    {
        //public int intCol1RowNum = 0; 
        int intButtonNum = 12;

        public class clButton
        {
            private string _strButtonWording;
            private string _strURL;
            private bool _bolNew = false;
            private bool _bolVisable = false;
            private clButton clButtonTemp1;

            public clButton()
            {
                _strButtonWording = "-- Wording --";
                _strURL = "URL";
                _bolNew = false;
                _bolVisable = false;
                return;
            }

            public clButton(clButton clButtonTemp1)
            {
                _strButtonWording = clButtonTemp1.strButtonWording;
                _strURL = clButtonTemp1.strURL;
                _bolNew = clButtonTemp1.bolNew;
                _bolVisable = clButtonTemp1.bolVisable;
                return;
            }

            public string strButtonWording
            {
                get { return _strButtonWording; }
                set { _strButtonWording = value; return; }
            }

            public string strURL
            {
                get { return _strURL; }
                set { _strURL = value; return; }
            }

            public bool bolNew
            {
                get { return _bolNew; }
                set { _bolNew = value; }
            }


            public bool bolVisable
            {
                get { return _bolVisable; }
                set { _bolVisable = value; }
            }

            public string strDisplayButtonHTML
            {
                get
                {
                    string strButton = "";
                    if (_bolVisable)
                    {
                        strButton = "<a href='" + _strURL + "' ";
                        if (_bolNew)
                        {
                            strButton += " Target='_new' ";
                        }
                        strButton += " class='btn btn-Park'>" + _strButtonWording + "</a><br />";
                    }
                    return strButton;
                }
            }


        }

        public class clRow
        {
            private int _intRowNum;
            private string _strTitle;
            private clButton _clButton1;
            private clButton _clButton2;
            private clButton _clButton3;
            private clButton _clButton4;
            private clButton _clButton5;
            private clButton _clButton6;
            private clButton _clButton7;
            private clButton _clButton8;
            private clButton _clButton9;
            private clButton _clButton10;
            private clButton _clButton11;
            private clButton _clButton12;
            private string _strWording;

            public int intRowNum
            {
                get { return _intRowNum; }
                set { _intRowNum = value; }
            }

            public string strTitle
            {
                get { return _strTitle; }
                set { _strTitle = value; }
            }

            public clButton clButton1
            {
                get { return _clButton1; }
                set { _clButton1 = value; }
            }

            public clButton clButton2
            {
                get { return _clButton2; }
                set { _clButton2 = value; }
            }
            public clButton clButton3
            {
                get { return _clButton3; }
                set { _clButton3 = value; }
            }
            public clButton clButton4
            {
                get { return _clButton4; }
                set { _clButton4 = value; }
            }
            public clButton clButton5
            {
                get { return _clButton5; }
                set { _clButton5 = value; }
            }
            public clButton clButton6
            {
                get { return _clButton6; }
                set { _clButton6 = value; }
            }
            public clButton clButton7
            {
                get { return _clButton7; }
                set { _clButton7 = value; }
            }

            public clButton clButton8
            {
                get { return _clButton8; }
                set { _clButton8 = value; }
            }
            public clButton clButton9
            {
                get { return _clButton9; }
                set { _clButton9 = value; }
            }
            public clButton clButton10
            {
                get { return _clButton10; }
                set { _clButton10 = value; }
            }
            public clButton clButton11
            {
                get { return _clButton11; }
                set { _clButton11 = value; }
            }
            public clButton clButton12
            {
                get { return _clButton12; }
                set { _clButton12 = value; }
            }
            /* increase this to match intButtonNum  */
            public string strWording
            {
                get { return _strWording; }
                set { _strWording = value; }
            }
        }

        List<clRow> lstItemAcad = new List<clRow> { };
        List<clRow> lstItemCampus = new List<clRow> { };
        List<clRow> lstItemStudent = new List<clRow> { };



        protected clButton[] funPopulateButtonList(int intArea)
        {
            clButton clButtonTemp;
            clButton[] arr_clButtons = new clButton[intButtonNum];
            SqlConnection con = new SqlConnection();
            SqlCommand command;
            string strconstring = Settings.GetConfigValue("PARK_Resources", "strConnString");
            con = new SqlConnection(strconstring);
            command = new SqlCommand("Z_P_SP_RESOURCE_Select_AreaButton", con);
            command.Parameters.AddWithValue("@AreaID", intArea);
            command.CommandType = CommandType.StoredProcedure;
            con.Open();
            int intCounter = 0;
            for (intCounter = 0; intCounter < intButtonNum; intCounter++)
            {
                clButtonTemp = new clButton();
                arr_clButtons[intCounter] = new clButton(clButtonTemp);
            }


            SqlDataReader sdrlist = command.ExecuteReader();
            intCounter = -1;
            while (sdrlist.Read())
            {
                intCounter++;
                arr_clButtons[intCounter].bolVisable = true;
                if (Convert.ToInt32(sdrlist["New"]) == 1)
                {
                    arr_clButtons[intCounter].bolNew = true;
                }
                else
                {
                    arr_clButtons[intCounter].bolNew = false;
                }
                arr_clButtons[intCounter].strButtonWording = sdrlist["Word"].ToString();
                arr_clButtons[intCounter].strURL = sdrlist["URL"].ToString();
            }
            con.Close();
            con.Dispose();
            command.Dispose();
            return arr_clButtons;
        }

        protected void funPopulateAreaAcad()
        {
            int intRowCouter = 1;
            clButton clButtonTemp = new clButton();
            SqlConnection con = new SqlConnection();
            SqlCommand command;
            string strconstring = Settings.GetConfigValue("PARK_Resources", "strConnString");
            con = new SqlConnection(strconstring);
            command = new SqlCommand("Z_P_SP_RESOURCE_Select_Area", con);
            command.Parameters.AddWithValue("@Area", "ACAD");
            command.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataReader sdrList = command.ExecuteReader();
            while (sdrList.Read())
            {
                clButton[] arr_clButtons = funPopulateButtonList(Convert.ToInt32(sdrList["ID"].ToString()));

                lstItemAcad.Add(new clRow
                {
                    intRowNum = intRowCouter++,
                    strTitle = sdrList["Title"].ToString(),
                    clButton1 = arr_clButtons[0],
                    clButton2 = arr_clButtons[1],
                    clButton3 = arr_clButtons[2],
                    clButton4 = arr_clButtons[3],
                    clButton5 = arr_clButtons[4],
                    clButton6 = arr_clButtons[5],
                    clButton7 = arr_clButtons[6],
                    clButton8 = arr_clButtons[7],
                    clButton9 = arr_clButtons[8],
                    clButton10 = arr_clButtons[9],
                    clButton11 = arr_clButtons[10],
                    clButton12 = arr_clButtons[11],
                    strWording = sdrList["Wording"].ToString()
                });

            }
            con.Close();
            con.Dispose();
            command.Dispose();
            rptRowAcad.DataSource = lstItemAcad;
            rptRowAcad.DataBind();

            return;
        }

        protected void funPopulateAreaCampus()
        {
            int intRowCouter = 1;
            clButton clButtonTemp = new clButton();
            SqlConnection con = new SqlConnection();
            SqlCommand command;
            string strconstring = Settings.GetConfigValue("PARK_Resources", "strConnString");
            con = new SqlConnection(strconstring);
            command = new SqlCommand("Z_P_SP_RESOURCE_Select_Area", con);
            command.Parameters.AddWithValue("@Area", "CAMP");
            command.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataReader sdrList = command.ExecuteReader();
            while (sdrList.Read())
            {
                clButton[] arr_clButtons = funPopulateButtonList(Convert.ToInt32(sdrList["ID"].ToString()));

                lstItemCampus.Add(new clRow
                {
                    intRowNum = intRowCouter++,
                    strTitle = sdrList["Title"].ToString(),
                    clButton1 = arr_clButtons[0],
                    clButton2 = arr_clButtons[1],
                    clButton3 = arr_clButtons[2],
                    clButton4 = arr_clButtons[3],
                    clButton5 = arr_clButtons[4],
                    clButton6 = arr_clButtons[5],
                    clButton7 = arr_clButtons[6],
                    clButton8 = arr_clButtons[7],
                    clButton9 = arr_clButtons[8],
                    clButton10 = arr_clButtons[9],
                    clButton11 = arr_clButtons[10],
                    clButton12 = arr_clButtons[11],
                    strWording = sdrList["Wording"].ToString()
                });

            }
            con.Close();
            con.Dispose();
            command.Dispose();
            rptRowCamp.DataSource = lstItemCampus;
            rptRowCamp.DataBind();

            return;
        }

        protected void funPopulateAreaStudent()
        {
            int intRowCouter = 1;
            clButton clButtonTemp = new clButton();
            SqlConnection con = new SqlConnection();
            SqlCommand command;
            string strconstring = Settings.GetConfigValue("PARK_Resources", "strConnString");
            con = new SqlConnection(strconstring);
            command = new SqlCommand("Z_P_SP_RESOURCE_Select_Area", con);
            command.Parameters.AddWithValue("@Area", "STUD");
            command.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataReader sdrList = command.ExecuteReader();
            while (sdrList.Read())
            {
                clButton[] arr_clButtons = funPopulateButtonList(Convert.ToInt32(sdrList["ID"].ToString()));

                lstItemStudent.Add(new clRow
                {
                    intRowNum = intRowCouter++,
                    strTitle = sdrList["Title"].ToString(),
                    clButton1 = arr_clButtons[0],
                    clButton2 = arr_clButtons[1],
                    clButton3 = arr_clButtons[2],
                    clButton4 = arr_clButtons[3],
                    clButton5 = arr_clButtons[4],
                    clButton6 = arr_clButtons[5],
                    clButton7 = arr_clButtons[6],
                    clButton8 = arr_clButtons[7],
                    clButton9 = arr_clButtons[8],
                    clButton10 = arr_clButtons[9],
                    clButton11 = arr_clButtons[10],
                    clButton12 = arr_clButtons[11],
                    strWording = sdrList["Wording"].ToString()
                });

            }
            con.Close();
            con.Dispose();
            command.Dispose();
            rptRowStudent.DataSource = lstItemStudent;
            rptRowStudent.DataBind();

            return;
        }

        protected void funPopulateArea()
        {
            funPopulateAreaAcad();
            funPopulateAreaCampus();
            funPopulateAreaStudent();
            return;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsFirstLoad)
            {
                funPopulateArea();
            }
            return;
        }
    }
}