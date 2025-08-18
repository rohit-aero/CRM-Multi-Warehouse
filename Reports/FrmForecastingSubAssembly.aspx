<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmForecastingSubAssembly.aspx.cs" Inherits="Reports_FrmForecastingSubAssembly" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 border-bottom piDiv position-sticky py-3">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Forecasting Sub-Assembly</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:TextBox ID="txtStartDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtStartDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtStartDate" TargetControlID="txtStartDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>End Date</label>
                            <asp:TextBox ID="txtEndDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtEndDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtEndDate" TargetControlID="txtEndDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Product</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlProduct" DataTextField="Product" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Report Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReportType" runat="server">
                                <asp:ListItem Value="A" Selected>Assembly</asp:ListItem>
                                <asp:ListItem Value="S">Sub-Assembly</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <label>&nbsp;</label>
                        <div class="row">
                            <div class="col-md-auto">
                                <asp:Button ID="btnShow" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" Text="Search" OnClick="btnShow_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnExportToPdf" CausesValidation="false" runat="server" Enabled="false" Text="Export to PDF" OnClick="btnExportToPdf_Click" />
                                <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Enabled="false" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 mt-3">
                <div class="table-responsive eoeTable" style="max-height: 500px">
                    <asp:GridView ID="gvSearchProject" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="verticalHeading mx-auto text-center"
                        EnableModelValidation="True" OnDataBound="gvSearchProject_DataBound" OnRowDataBound="gvSearchProject_RowDataBound">
                    </asp:GridView>
                </div>
            </div>

           <div class="col-12 mt-3">
                <div class="table-responsive eoeTable" style="max-height: 750px">
                    <asp:GridView ID="gvSearch" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="mx-auto text-center"
                        EnableModelValidation="True" OnDataBound="gvSearch_DataBound" OnRowDataBound="gvSearch_RowDataBound">
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
            <asp:PostBackTrigger ControlID="btnExportToPdf" />
        </Triggers>
    </asp:UpdatePanel>
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
            $('#<%=ddlProduct.ClientID%>').chosen();
            $('#<%=ddlReportType.ClientID%>').chosen();
        }
    </script>
</asp:Content>
