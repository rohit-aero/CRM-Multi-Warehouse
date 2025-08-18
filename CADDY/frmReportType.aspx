<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmReportType.aspx.cs" Inherits="CADDY_frmReportType" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Caddy Reports</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-2">
                    <div class="col-2">
                        <label>Job Type</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobType" runat="server" OnSelectedIndexChanged="ddlJobType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0" Selected="True">All</asp:ListItem>
                            <asp:ListItem Value="1">Conveyor</asp:ListItem>
                            <asp:ListItem Value="2">Hood</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Req. Fwd To India From Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="calFromDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>
                    </div>

                    <div class="col-2">
                        <label>Req. Fwd To India To Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="calToDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></asp:CalendarExtender>
                    </div>
                    <div class="col-2">
                        <label>Report Type</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOpenReport" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOpenReport_SelectedIndexChanged">
                            <asp:ListItem Value="1" Selected="True">Internal</asp:ListItem>
                            <asp:ListItem Value="2">For Caddy</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-2">
                        <label>Project Type</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectType" runat="server" DataTextField="ProjectTypeName" DataValueField="ProjectTypeID">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm">
                        <div class="row">
                            <label class="col-12">&nbsp;</label>
                            <div class="col-12">
                                <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-primary btn-sm" Text="Preview Report" OnClick="btnGenerate_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerate" />
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
            $('#<%=ddlOpenReport.ClientID%>').chosen();
            $('#<%=ddlJobType.ClientID%>').chosen();
            $('#<%=ddlProjectType.ClientID%>').chosen();
        }
    </script>
    <CR:CrystalReportViewer ID="rptEngTaskReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>

