<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmContainerReport.aspx.cs" Inherits="Reports_frmContainerReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Container</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By Vendor</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendor" runat="server" DataTextField="Source" DataValueField="SourceId"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By Container</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerCheckStatus" runat="server">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Submitted</asp:ListItem>
                                <asp:ListItem Value="2">Not Submitted</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>



                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Open</asp:ListItem>
                                <asp:ListItem Value="2">Close</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md justify-content-center">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-sm" Text="Search" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnGeneratePendingQty" runat="server" CssClass="btn btn-secondary btn-sm" Text="Generate Pending Qty Report" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGeneratePendingQty_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />

                    </div>
                </div>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnGeneratePendingQty" />
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
            $('#<%=ddlVendor.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlContainerCheckStatus.ClientID%>').chosen();
        }
    </script>
    <CR:CrystalReportViewer ID="rptPO" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>

