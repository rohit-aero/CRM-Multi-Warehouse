<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="frmQuoteReport.aspx.cs" Inherits="Reports_frmQuoteReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Quote Tasks Filters</h5>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Nature of Task</label>
                            <asp:DropDownList ID="ddlNature" runat="server" DataTextField="Task" DataValueField="id" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Assigned To</label>
                            <asp:DropDownList ID="ddlAssignedTo" runat="server" DataTextField="FirstName" DataValueField="EmployeeID" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Priority</label>
                            <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control form-control-sm">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Regular</asp:ListItem>
                                <asp:ListItem Value="2">Urgent</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList ID="ddlStatus" runat="server" DataTextField="Status" DataValueField="id" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Req. By Customer From</label>
                            <asp:TextBox ID="txtReqByCustomerFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtReqByCustomerFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqByCustomerFrom" TargetControlID="txtReqByCustomerFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Req. By Customer To</label>
                            <asp:TextBox ID="txtReqByCustomerTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtReqByCustomerTo_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqByCustomerTo" TargetControlID="txtReqByCustomerTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Quote Sent Out From</label>
                            <asp:TextBox ID="txtQuoteSentOutFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtQuoteSentOutFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtQuoteSentOutFrom" TargetControlID="txtQuoteSentOutFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Quote Sent Out To</label>
                            <asp:TextBox ID="txtQuoteSentOutTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtQuoteSentOutTo_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtQuoteSentOutTo" TargetControlID="txtQuoteSentOutTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-md-auto">
                                <asp:Button ID="btnExportToPDF" runat="server" CssClass="btn btn-info btn-sm" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" Text="Preview Report" OnClick="btnExportToPDF_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            BindDrp();
        }

        $.when.apply($, PageLoaded).then(function () {
            BindDrp();
        });

        function BindDrp() {
            $('#<%=ddlNature.ClientID%>').chosen();
            $('#<%=ddlAssignedTo.ClientID%>').chosen();
            $('#<%=ddlPriority.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
        }
    </script>
    <CR:CrystalReportViewer ID="rptQuoteReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
