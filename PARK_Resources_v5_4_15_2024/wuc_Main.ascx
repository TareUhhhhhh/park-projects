<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wuc_Main.ascx.cs" Inherits="PARK_Resources_v5_4_15_2024.wuc_Main" %>

<script src="ToggleIcon.js"></script>
<link href="TabStyle.css" rel="stylesheet" />
<style>
    .btn-Park {
        color: black;
        background-color: rgb(253,210,36);
        border-color: black;
        font-weight: 700;
        margin-bottom: 10px;
    }

    .top-btn-Park {
        display: inline-block;
        padding: 10px 25px;
        border: 2px solid #9d2235;
        background-color: #E5E5E5;
        color: #000000;
        font-family: "bebas-neue", sans-serif;
        font-weight: 400;
        text-decoration: none;
        font-size: 22px;
    }

        .top-btn-Park a:hover {
            display: inline-block;
            padding: 10px 25px;
            border: 2px solid #000000;
            background-color: #9d2235;
            color: #000000;
            font-family: "bebas-neue", sans-serif;
            font-weight: 400;
            text-decoration: none;
            font-size: 22px;
        }

        .top-btn-Park a:focus {
            display: inline-block;
            padding: 10px 25px;
            border: 2px solid #000000;
            background-color: rgb(253,218,36);
            color: #000000;
            font-family: "bebas-neue", sans-serif;
            font-weight: 400;
            text-decoration: none;
            font-size: 22px;
        }

        .resource-tabs {
            border: 2px solid green;
            max-width: 100%;
        }

        .resource-tab-content {
            border: 2px solid pink;
        }
</style>
<div class="container-fluid">
    <div class="container resource-tabs">
        <article class="tabs">
            <ul class="nav nav-tabs nav-tabs-redBorders">
                <li class="active">
                    <a data-toggle="tab" href="#Academic" class="top-btn-Park">Academic Support
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#Campus" class="top-btn-Park">Campus Operations 
                    </a>
                </li>
                 <li>
                    <a data-toggle="tab" href="#Student" class="top-btn-Park">Student Services
                    </a>
                </li>
            </ul>
            <div class="tab-content resource-tab-content">
                <!--tab1 - home-->
                <div id="Academic" class="tab-pane fade in active">
                    <!-- 
==============================
bootstrap accordion
==============================
-->
                    <div class="panel-group" id="accordion1" role="tablist" aria-multiselectable="true">
                        <!--panel-default-->
                        <%--                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h3 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion1" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        <i class="fa fa-minus more-less" aria-hidden="true"></i>
                                        Academics
                                    </a>
                                </h3>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                <div class="panel-body">
                                    <p>
                                        These are areas and resources that are for the academic areas of Park University.
                                    </p>
                                </div>
                            </div>
                        </div>--%>
                        <!--panel-2-->
                        <asp:Repeater ID="rptRowAcad" runat="server">
                            <ItemTemplate>
                                <div class="panel panel-default">
                                    <div class="panel-heading" role="tab" id="heading<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>">
                                        <h3 class="panel-title">
                                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion1" href='#collapse<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>' aria-expanded="false" aria-controls='collapse<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>'>
                                                <i class="fa fa-plus more-less" aria-hidden="true"></i>
                                                <asp:Label ID="lblRowTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"strTitle") %>' />
                                            </a>
                                        </h3>
                                    </div>
                                    <div id="collapse<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>">
                                        <div class="panel-body">
                                            <table class="table table-bordered">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRowButton1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton1.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton2.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton3.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton4.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton5.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton6.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton7.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton8.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton9.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton10.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton11.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton12.strDisplayButtonHTML") %>' />

                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRowWording" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"strWording") %>' /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- end
==============================
bootstrap accordion
==============================
-->
                </div>
                <!--tab2-->
                <div id="Campus" class="tab-pane fade">
                    <!-- 
==============================
bootstrap accordion
==============================
-->
                    <div class="panel-group" id="accordion2" role="tablist" aria-multiselectable="true">
                        <!--panel-default-->
                        <%--                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingTwo">
                                <h3 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion2" href="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
                                        <i class="fa fa-minus more-less" aria-hidden="true"></i>
                                        Administrative
                                    </a>
                                </h3>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">
                                <div class="panel-body">
                                    <p>
                                       Administrative.
                                    </p>
                                </div>
                            </div>
                        </div>--%>
                        <!--panel-2-->
                        <asp:Repeater ID="rptRowCamp" runat="server">
                            <ItemTemplate>
                                <div class="panel panel-default">
                                    <div class="panel-heading" role="tab" id="heading<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>">
                                        <h3 class="panel-title">
                                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion2" href='#collapseAdmin<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>' aria-expanded="false" aria-controls='collapseAdmin<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>'>
                                                <i class="fa fa-plus more-less" aria-hidden="true"></i>
                                                <asp:Label ID="lblRowTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"strTitle") %>' />
                                            </a>
                                        </h3>
                                    </div>
                                    <div id="collapseAdmin<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>">
                                        <div class="panel-body">
                                            <table class="table table-bordered">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRowButton1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton1.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton2.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton3.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton4.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton5.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton6.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton7.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton8.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton9.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton10.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton11.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton12.strDisplayButtonHTML") %>' />


                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRowWording" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"strWording") %>' /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- end
          ==============================
          bootstrap accordion
          ==============================
          -->
                </div>

     <div id="Student" class="tab-pane fade">
                    <!-- 
==============================
bootstrap accordion
==============================
-->
                    <div class="panel-group" id="accordion3" role="tablist" aria-multiselectable="true">
                        <!--panel-default-->
                        <%--                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingTwo">
                                <h3 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion2" href="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
                                        <i class="fa fa-minus more-less" aria-hidden="true"></i>
                                        Student
                                    </a>
                                </h3>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">
                                <div class="panel-body">
                                    <p>
                                       Student 
                                    </p>
                                </div>
                            </div>
                        </div>--%>
                        <!--panel-2-->
                        <asp:Repeater ID="rptRowStudent" runat="server">
                            <ItemTemplate>
                                <div class="panel panel-default">
                                    <div class="panel-heading" role="tab" id="heading<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>">
                                        <h3 class="panel-title">
                                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion2" href='#collapseStudent<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>' aria-expanded="false" aria-controls='collapseStudent<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>'>
                                                <i class="fa fa-plus more-less" aria-hidden="true"></i>
                                                <asp:Label ID="lblRowTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"strTitle") %>' />
                                            </a>
                                        </h3>
                                    </div>
                                    <div id="collapseStudent<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading<%# DataBinder.Eval(Container.DataItem,"intRowNum") %>">
                                        <div class="panel-body">
                                            <table class="table table-bordered">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRowButton1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton1.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton2.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton3.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton4.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton5.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton6.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton7.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton8.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton9.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton10.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton11.strDisplayButtonHTML") %>' />
                                                        <asp:Label ID="lblRowButton12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"clButton12.strDisplayButtonHTML") %>' />


                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRowWording" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"strWording") %>' /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- end
          ==============================
          bootstrap accordion
          ==============================
          -->
                </div>

            </div>
        </article>
    </div>


    <asp:Label ID="lblNote" runat="server" />

</div>

