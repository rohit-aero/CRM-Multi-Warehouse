<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmForecastingNew_V1.aspx.cs" Inherits="Reports_frmForecastingNew_V1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 border-bottom piDiv position-sticky py-3">
                <div class="row">
                    <div class="col-sm-12 col-md-12 mx-auto">
                        <div class="row">
                            <div class="col-12">
                                <h4 class="title-hyphen position-relative mb-3">Aerowerks Forecasting Report</h4>
                            </div>
                        </div>
<%--                        <div class="row">
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col-sm-2">
                                <div class="row">
                                    <label class="col-12">Start Date</label>
                                    <div class="col">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <div class="row">
                                    <label class="col-12">End Date</label>
                                    <div class="col">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate"
                                            TargetControlID="txtToDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <div class="row chosenFullWidth">
                                    <label class="col-12">Manufacturing Facility</label>
                                    <div class="col">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShop" runat="server" DataTextField="FacilityName" DataValueField="id"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <div class="row chosenFullWidth">
                                    <label class="col-12">Product</label>
                                    <div class="col">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProduct" runat="server" DataTextField="Product" DataValueField="id"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm">
                                <div class="row">
                                    <label class="col-12">&nbsp;</label>
                                    <div class="col-12">
                                        <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" />
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnExporttoPdf" CausesValidation="false" runat="server" Visible="false" Enabled="false" Text="Export to PDF" OnClick="btnExporttoPdf_Click" />
                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Enabled="false" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
               <div class="col-12" id="divAerowerksForecastingReport" runat="server" style="display:none">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5><strong>Help Section: </strong></h5>
                    </div>
                    <div class="col-12 pt-2" runat="server" id="divGrossPurchase_HelpSection">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Aerowerks Forecasting Report</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong> Ship Date</strong>.</li> 
                            <li>Project Parts Qty<strong> Greater Than Zero</strong>.</li>  
                            <li>Project Status<strong> Not Cancelled/On-Hold</strong>.</li>                                                             
                        </ul>
                    </div>
                </div>
                </div>
            </div>
            <div class="col-12 mt-3">
                <div class="table-responsive eoeTable" style="height: 750px">
                    <asp:GridView  ID="gvSearch" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="table mainGridTable table-sm verticalHeading mx-auto text-center"
                        EnableModelValidation="True" ShowFooter="false" OnDataBound="gvSearch_DataBound" OnRowDataBound="gvSearch_RowDataBound">
                    </asp:GridView>
                </div>
                  <div class="table-responsive eoeTable" style="height: 750px" id="dvSummary" runat="server" visible="false">
                    <asp:GridView  ID="gvSummary" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" 
                        CssClass="table mainGridTable table-sm verticalHeading mx-auto text-center"
                        EnableModelValidation="True" ShowFooter="false" OnDataBound="gvSummary_DataBound" OnRowDataBound="gvSummary_RowDataBound">
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerateExcel" />
            <asp:PostBackTrigger ControlID="btnExporttoPdf" />
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
            $('#<%=ddlShop.ClientID%>').chosen();
        }
    </script>
</asp:Content>