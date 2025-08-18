<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmTrimarkQuarterly.aspx.cs" Inherits="Reports_frmTrimarkQuarterly" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Trimark Quarterly Report</h4>
            </div>
<%--            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>--%>
            <div class="col-12">
                <div class="row">
                    <div class="col-sm-auto">
                        <div class="col-sm-auto">
                            <div class="form-group chosenFullWidth">
                                <label>Year</label>
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlYear" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-auto">
                            <div class="form-group chosenFullWidth">
                                <label>Quarter</label>
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlQuarter" runat="server">
                                    <%--  <asp:ListItem Value="-1">Select</asp:ListItem>--%>
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="1">First</asp:ListItem>
                                    <asp:ListItem Value="2">Second</asp:ListItem>
                                    <asp:ListItem Value="3">Third</asp:ListItem>
                                    <asp:ListItem Value="4">Fourth</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-auto">
                            <div class="form-group mb-0 flex-column">
                                <label>&nbsp;</label>
                                <div>
                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnGenrate_Click" />
                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />
                                    <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSalesUsaCan" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script language="javascript" type="text/javascript">
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
            $('#<%=ddlYear.ClientID%>').chosen();
        $('#<%=ddlQuarter.ClientID%>').chosen();
    }
    </script>
</asp:Content>