<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmProductionWeekly.aspx.cs" Inherits="Reports_frmProductionWeekly" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-8">
                        <!-- Main content area -->
                        <!-- Your main content here -->
                        <div class="col-12">
                            <div class="row">
                                <div class="col-12 pt-2">
                                    <div class="d-flex align-items-center mb-2">
                                        <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                                        <h4 class="title-hyphen position-relative">Aerowerks Production Weekly Report</h4>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                    <div class="form-group">
                                        <label>Start Date</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                    <div class="form-group">
                                        <label>End Date</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-sm-auto">
                                    <div class="row chosenFullWidth">
                                        <label>Warehouse</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShop" runat="server" DataTextField="text" DataValueField="id" onchange="showDiv();">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-12" runat="server" id="rdbForChina" style="display: none">
                                    <div class="form-group srRadiosBtns">
                                        <asp:RadioButtonList ID="rdbIssuedFor" runat="server">
                                            <asp:ListItem Value="D">&emsp;Fabrication Drawings Only</asp:ListItem>
                                            <asp:ListItem Value="P">&emsp;Production Only</asp:ListItem>
                                            <asp:ListItem Value="B">&emsp;Both</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-md-auto">
                                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnGenrate_Click" />
                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />
                                            <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="col-4">
                        <!-- Help section on the right -->
                        <div class="row pt-3">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divmfgfacilityall_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Manufacturing Facility-All</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Manufacturing Facility <strong>Canada/China/India/Caddy</strong>.</li>
                                        <li>Date is based on <strong>Ship Date</strong>.</li>
                                        <li><strong>USD & CAD</strong> currency projects are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divmfgfacilitycaddy_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Manufacturing Facility-Caddy</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Projects with Manufacturing Facility <strong>Caddy</strong> are shown in the report.</li>
                                        <li>Date is based on <strong>Ship Date</strong>.</li>
                                        <li><strong>USD & CAD</strong> currency projects are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divmfgfacilitycanada_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Manufacturing Facility-Canada</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Projects with Manufacturing Facility <strong>Canada</strong> are shown in the report.</li>
                                        <li>Date is based on <strong>Ship Date</strong>.</li>
                                        <li><strong>USD & CAD</strong> currency projects are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divmfgfacilitychina_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Manufacturing Facility-China</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Release Date China</strong>.</li>
                                        <li>In case of <i>China(Mfg Facility)</i>, <strong>either Mfg Facility should be China or designer should be Eric Liu & J. L. Chen</strong>.</li>
                                        <li><strong>USD & CAD</strong> currency projects are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divmfgfacilityIndia_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Manufacturing Facility-India</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Projects with Manufacturing Facility <strong>India</strong> are shown in the report.</li>
                                        <li>Date is based on <strong>Ship Date</strong>.</li>
                                        <li><strong>USD & CAD</strong> currency projects are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenrate" />
            <asp:PostBackTrigger ControlID="btnGenerateExcel" />
        </Triggers>
    </asp:UpdatePanel>

    <CR:CrystalReportViewer ID="rptSalesUsaCan" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });
        function PageLoaded(sender, args) {
            DDL();
        }
        $.when.apply($, PageLoaded).then(function () {
            DDL();
        });
        function DDL() {
            $('#<%=ddlShop.ClientID%>').chosen();
        }

        function showDiv() {
            console.log('test');
            var getSelectValue = document.getElementById('<%=ddlShop.ClientID%>').value;
            if (getSelectValue == "1") {
                document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitycaddy_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilityIndia_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=rdbForChina.ClientID%>').style.display = "none";
                document.getElementById('<%=rdbIssuedFor.ClientID%>').disabled = true;
            }
            else if (getSelectValue == "2") {
                document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitycaddy_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divmfgfacilityIndia_HelpSection.ClientID%>').style.display = "none";
                var radioButtons = document.getElementsByName('ctl00$ContentPlaceHolder1$rdbIssuedFor');
                for (var i = 0; i < radioButtons.length; i++) {
                    if (radioButtons[i].value === 'B') {
                        radioButtons[i].checked = true; // Select the radio button
                        break; // Exit the loop once found
                    }
                }
                document.getElementById('<%=rdbForChina.ClientID%>').style.display = "block";
                document.getElementById('<%=rdbIssuedFor.ClientID%>').disabled = false;
            }
            else if (getSelectValue == "3") {
                document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitycaddy_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilityIndia_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=rdbForChina.ClientID%>').style.display = "none";
                document.getElementById('<%=rdbIssuedFor.ClientID%>').disabled = true;
            }
            else if (getSelectValue == "4") {
                document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitycaddy_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilityIndia_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=rdbForChina.ClientID%>').style.display = "none";
                document.getElementById('<%=rdbIssuedFor.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divmfgfacilitycaddy_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divmfgfacilityIndia_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=rdbForChina.ClientID%>').style.display = "none";
                document.getElementById('<%=rdbIssuedFor.ClientID%>').disabled = true;
            }
}
    </script>
</asp:Content>
