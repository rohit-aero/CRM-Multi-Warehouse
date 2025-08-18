<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/main.master" CodeFile="FrmPostInstallFollowupsReport.aspx.cs" Inherits="Reports_FrmPostInstallFollowupsReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-8">
                        <!-- Main content area -->
                        <!-- Your main content here -->
                        <div class="col-7 mx-auto ">
                            <div class="row">
                                <div class="col-12 pt-2">
                                    <div class="d-flex align-items-center mb-2">
                                        <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                                        <h4 class="title-hyphen position-relative">Post Install Followup Report</h4>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
                                        <label>From Date</label>
                                        <asp:TextBox ID="txtFromDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtFromDateExtender" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>

                                <div class="col-6">
                                    <div class="form-group">
                                        <label>To Date</label>
                                        <asp:TextBox ID="txtToDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtToDateExtender" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtToDate" TargetControlID="txtToDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>

                                <div class="col-6">
                                    <div class="form-group">
                                        <label>State</label>
                                        <asp:DropDownList runat="server" ID="ddlState" DataTextField="State" DataValueField="StateID" CssClass="form-control form-control-sm"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                        <label>Filter Report On</label>
                                        <asp:DropDownList runat="server" ID="ddlFilterReportOn" CssClass="form-control form-control-sm" onchange="showDiv()">
                                            <asp:ListItem Value="F">Followup Date</asp:ListItem>
                                            <asp:ListItem Value="I">Installation Start Date</asp:ListItem>
                                            <asp:ListItem Value="S">Scheduled Followup Date</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-5">
                                    <div class="form-group">
                                        <label></label>
                                        <asp:Button runat="server" ID="btnPreview" Text="Preview Report" OnClick="btnPreview_Click" OnClientClick="window.document.forms[0].target='_blank';" CssClass="btn btn-success btn-sm" CausesValidation="false" />
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
                            <div class="col-12 pt-2" runat="server" id="divfollowupDate_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Post Install Followup Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Followup Date</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divInstallDate_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Post Install Followup Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Install Date</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divSchedulledFollowup_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Post Install Followup Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Scheduled Followup Date</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPreview" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptPostinstallFollowups" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlFilterReportOn.ClientID%>').chosen();
        }
        function showDiv() {
            var getSelectValue = document.getElementById('<%=ddlFilterReportOn.ClientID%>').value;
            if (getSelectValue == "F") {
                document.getElementById('<%=divfollowupDate_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divInstallDate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSchedulledFollowup_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "I") {
                document.getElementById('<%=divfollowupDate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divInstallDate_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divSchedulledFollowup_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "S") {
                document.getElementById('<%=divfollowupDate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divInstallDate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSchedulledFollowup_HelpSection.ClientID%>').style.display = "block";
            }
}
    </script>
</asp:Content>
