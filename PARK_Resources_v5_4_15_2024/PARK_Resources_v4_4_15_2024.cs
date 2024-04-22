using System;
using Jenzabar;
using Jenzabar.Common;
using Jenzabar.Common.Globalization;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Framework.Configuration;
using Jenzabar.Portal.Framework.Data;
using Jenzabar.Portal.Framework.Web;
using Jenzabar.Portal.Framework.Web.UI;
using Jenzabar.Portal.Framework.Web.UI.Controls;
using Jenzabar.Portal.Framework.Web.UI.Controls.MetaControls;
using Jenzabar.Portal.Framework.Web.UI.Controls.MetaControls.Attributes;
using Jenzabar.Portal.Framework.Preferences;
using Jenzabar.Portal.Framework.Security.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Web;

namespace PARK_Resources_v5_4_15_2024
{
    public class PARK_Resources_v5_4_15_2024 : PortletBase
    {
        protected override PortletViewBase GetCurrentScreen()
        {
            PortletViewBase screen = null;

            screen = LoadPortletView("ICS/PARK_Resources_v5_4_15_2024/wuc_Default.ascx");

            return screen;
        }
    }
}