<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmDealerSales.aspx.cs" Inherits="Reports_frmDealerSales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="row">
                <div class="col-12">
                    <div class="d-flex align-items-center mb-2">
                        <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                        <h4 class="title-hyphen position-relative">Dealer Sales</h4>
                    </div>
                </div>
            </div>
            <%--<div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
            <div class="col-12">
                <div class="row">
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>End Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group chosenFullWidth">
                            <label>Select Dealer</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRebate" runat="server" DataTextField="CompanyName" DataValueField="DealerID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group mb-0 flex-column">
                            <label>&nbsp;</label>
                            <div>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" runat="server" CausesValidation="false" Text="Export To Excel" OnClick="btnGenerateExcel_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlRebate.ClientID%>').chosen();
        }
    </script>
</asp:Content>
