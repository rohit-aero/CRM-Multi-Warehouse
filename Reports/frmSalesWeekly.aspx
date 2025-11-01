<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmSalesWeekly.aspx.cs" Inherits="Reports_frmSalesWeekly" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Aerowerks Monthly Sales Report</h4>
            </div>
            <%--            <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
            <div class="col-12 row">
                <div class="row col-7">
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>End Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="row chosenFullWidth">
                            <label>Warehouse</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShop" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-2 col-lg-2">
                        <label>Report Type</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlReportType">
                            <asp:ListItem Value="1" Selected>Sales Report</asp:ListItem>
                            <asp:ListItem Value="2">Summary Report</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group mb-0 flex-column">
                            <label>&nbsp;</label>
                            <div>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnGenrate_Click" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />
                                <asp:Button ID="btnDownloadCombinedPlanView" CssClass="btn btn-secondary btn-sm" runat="server" Text="Download Plan View" OnClick="btnDownloadCombinedPlanView_Click" OnClientClick="showLoading(this);  return false;" CausesValidation="false" Enabled="false" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-5 pl-0">
                    <div class="row">
                        <div class="col-12 pt-2">
                            <div class="d-flex align-items-center mb-2">
                                <h5>
                                    <strong>Help Section: Sales & Summary Report</strong>
                                </h5>
                            </div>
                        </div>

                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Ship Date</strong>.</li>
                                <li><strong>USD</strong> & <strong>CAD</strong> currency projects are shown in the report.</li>
                                <li><i>Selected</i> Manufacturing Facility projects are shown in the report.</li>
                                <li>In case of <i>China(Mfg Facility)</i>, <strong>either Mfg Facility should be China or designer should be Eric Liu & J. L. Chen</strong>.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
            $('#<%=ddlReportType.ClientID%>').chosen();
        }
        function showLoading(button) {
            // Change the button value to "Please wait..."
            button.value = "Please wait...";
            button.disabled = true; // Optionally disable the button to prevent multiple clicks
            __doPostBack(button.name, '');
            // Set a timer to re-enable the button after a certain time (e.g., 5 seconds)
            setTimeout(function () {
                button.value = "Download Plan View"; // Reset button text
                button.disabled = false; // Re-enable the button
            }, 10000); // Adjust the timeout as needed
        }

    </script>
</asp:Content>
