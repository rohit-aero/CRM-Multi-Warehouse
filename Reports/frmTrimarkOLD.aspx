<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmTrimarkOLD.aspx.cs" Inherits="Reports_frmTrimark" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Trimark Report</h4>
                <%-- <h5 class="text-uppercase">Select Filters</h5>--%>
            </div>
            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>
            <div class="col-12">
                <div class="row">
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>Year</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtYear" autocomplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group chosenFullWidth">
                            <label>Select Quarter</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlQuarter" Enabled="false" runat="server">
                                <%--<asp:ListItem Value="-1">Select</asp:ListItem>--%>
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
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnPreview" runat="server" Text="Preview Report" OnClick="btnPreview_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenExcel" runat="server" CausesValidation="false" Text="Export To Excel" OnClick="btnGenExcel_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Visible="false" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row border-top pt-3">
            <div class="col-12">
                <h5 class="text-uppercase">Select Option</h5>
            </div>
            <div class="col-sm-12 col-md">
                <div class="form-group srRadiosBtns">
                    <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" AutoPostBack="True" OnSelectedIndexChanged="rdbList_SelectedIndexChanged">
                        <asp:ListItem Value="1" Selected="True">Gross Purchase</asp:ListItem>
                        <asp:ListItem Value="2">Rebatable Purchase</asp:ListItem>
                        <asp:ListItem Value="3">Detailed Rebate Report</asp:ListItem>
                        <asp:ListItem Value="4">Quarterly Report</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptTrimark" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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

            $('#<%=ddlQuarter.ClientID%>').chosen();
        }

    </script>
</asp:Content>
