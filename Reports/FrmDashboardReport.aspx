<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmDashboardReport.aspx.cs" Inherits="Reports_FrmDashboardReport" %>

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
                            <h4 class="title-hyphen position-relative">Report (Dashboard)</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-2">
                    <div class="col-2">
                        <label class="text-danger">Report Type*</label>
                        <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control form-control-sm chosenFullWidth" AutoPostBack="True" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                            <asp:ListItem Value="1" Selected="True">In-Transit</asp:ListItem>
                            <asp:ListItem Value="2">Arrived Container</asp:ListItem>
                            <asp:ListItem Value="3">Inventory Report</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>From Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="calFromDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>
                    </div>
                    <div class="col-2">
                        <label>To Date</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="calToDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></asp:CalendarExtender>
                    </div>

                    <div class="col-1">
                        <label>Vendor</label>
                        <asp:DropDownList ID="ddlVendor" runat="server" DataValueField="SourceID" DataTextField="Source" CssClass="form-control form-control-sm chosenFullWidth">
                        </asp:DropDownList>
                    </div>
                    <div class="col-10 row" id="divPartNo" runat="server" visible="false">
                        <div class="col-2">
                            <label>Product Code</label>
                            <asp:DropDownList ID="ddlProductCode" runat="server" DataValueField="id" DataTextField="text" OnSelectedIndexChanged="ddlProductCode_SelectedIndexChanged" AutoPostBack="true"
                                CssClass="form-control form-control-sm chosenFullWidth">
                            </asp:DropDownList>
                        </div>

                        <div class="col-2">
                            <label>Product Line</label>
                            <asp:DropDownList ID="ddlProductLine" runat="server" DataValueField="id" DataTextField="text" OnSelectedIndexChanged="ddlProductLine_SelectedIndexChanged" AutoPostBack="true"
                                CssClass="form-control form-control-sm chosenFullWidth">
                            </asp:DropDownList>
                        </div>

                        <div class="col-2">
                            <div class="form-group">
                                <label>Status</label>
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartStatus" runat="server">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="1">Current</asp:ListItem>
                                    <asp:ListItem Value="2">Obsolete</asp:ListItem>
                                    <asp:ListItem Value="3">Not In Use</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-6">
                            <label>Part No</label>
                            <asp:DropDownList ID="ddlPartNo" runat="server" DataValueField="id" DataTextField="text"
                                CssClass="form-control form-control-sm chosenFullWidth">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-5">
                        <label>&nbsp;</label>
                        <div class="">
                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnShow" runat="server" CausesValidation="false" Text="Show" OnClick="btnShow_Click" Enabled="false" />
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Text="Export to Excel" OnClick="btnGenerateExcel_Click" Enabled="false" />
                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnGeneratePDF" CausesValidation="false" runat="server" Text="Export to PDF" OnClick="btnGeneratePDF_Click" Enabled="false" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12  row border-top pt-3">
            </div>
            <div class="col-12">
                <h5 class="text-uppercase">
                    <asp:Label ID="lblgvDashboard" runat="server"></asp:Label></h5>
            </div>

            <div class="col-12 pt-0">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvShowStockData"
                        runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                        ForeColor="Black" GridLines="Vertical" Width="100%" AllowSorting="true"
                        AutoGenerateColumns="true" EnableModelValidation="True" OnRowDataBound="gvShowStockData_RowDataBound" OnSorting="gvShowStockData_Sorting">
                    </asp:GridView>
                </div>
            </div>

            <div class="col-10 pt-0">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvInventoryReport"
                        runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                        ForeColor="Black" GridLines="Vertical" Width="100%" AllowSorting="true" DataKeyNames="id"
                        AutoGenerateColumns="false" EnableModelValidation="true" OnRowDataBound="gvInventoryReport_RowDataBound" OnSorting="gvInventoryReport_Sorting"
                        OnRowCommand="gvInventoryReport_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No" HeaderStyle-Width="2%" SortExpression="SrNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text='<%# Eval("SrNo") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part #" HeaderStyle-Width="30%" SortExpression="PartNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartNo" runat="server" Text='<%# Eval("PartNo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Current Stock" HeaderStyle-Width="1%" SortExpression="StockInHand">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkStockInHand" runat="server" Text='<%# Eval("StockInHand") %>' CommandName="InStockCommand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                    <asp:Label ID="lblInStock" runat="server" Text='<%# Eval("StockInHand") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="In Transit" HeaderStyle-Width="1%" SortExpression="InTransit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkInTransit" runat="server" CommandName="TransitCommand" Text='<%# Eval("InTransit") %>' CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                    <asp:Label ID="lblInTransit" runat="server" Text='<%# Eval("InTransit") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="In Production" HeaderStyle-Width="1%" SortExpression="InProduction">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkInProduction" runat="server" CommandName="ProductionCommand" Text='<%# Eval("InProduction") %>' CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                    <asp:Label ID="lblInProduction" runat="server" Text='<%# Eval("InProduction") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="In Forcast" HeaderStyle-Width="1%" SortExpression="InForcast">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkInForcast" runat="server" CommandName="ForcastCommand" Text='<%# Eval("InForcast") %>' CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                    <asp:Label ID="lblInForcast" runat="server" Text='<%# Eval("InForcast") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="85%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="h-100">
                        <div class="row justify-content-center">
                            <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                <div class="row">
                                    <div class="col-sm-3 col-md-auto mb-3 modal-title text-center">
                                        <h4>
                                            <label class="mb-0 title-hyphen position-relative">Part Number:</label></h4>
                                    </div>
                                    <div class="col-sm-9 col-md mb-3 chosenFullWidth ">
                                        <h4>
                                            <asp:Label ID="lblPartNumber" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <table class="table mainGridTable table-sm">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInTransit" runat="server" AutoGenerateColumns="False"
                                EnableModelValidation="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Source" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSource" runat="server" Text='<%# Eval("Source") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Destination" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("Destination") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Container No" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContainerNo" runat="server" Text='<%# Eval("ContainerNo") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Invoice No" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNo") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tentative Ship Date" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTentativeShipdate" runat="server" Text='<%# Eval("TentativeShipDate","{0:MM/dd/yyyy}") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Arrival In Aerowerks" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblArrivalInAerowerksDate" runat="server" Text='<%# Eval("ArriveDate","{0:MM/dd/yyyy}") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO No" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="In Transit" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInTransit" runat="server" Text='<%# Eval("Intransit") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </table>
                    </div>
                </div>
            </asp:Panel>

            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="LinkButton2"
                PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="85%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton1" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="h-100">
                        <div class="row justify-content-center">
                            <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                <div class="row">
                                    <div class="col-sm-3 col-md-auto mb-3 modal-title text-center">
                                        <h4>
                                            <label class="mb-0 title-hyphen position-relative">Part Number:</label></h4>
                                    </div>
                                    <div class="col-sm-9 col-md mb-3 chosenFullWidth ">
                                        <h4>
                                            <asp:Label ID="lblInShopPartNumber" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <table class="table mainGridTable table-sm">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInShop" runat="server" AutoGenerateColumns="False"
                                EnableModelValidation="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="PO No" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONumber") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prepared By" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPreparedBy" runat="server" Text='<%# Eval("PreparedBy") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Source" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSource" runat="server" Text='<%# Eval("Source") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Destination" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWareHouseDest" runat="server" Text='<%# Eval("DestWarehouse") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issue Date" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("IssueDate","{0:MM/dd/yyyy}") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("OrderQty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ship Qty" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShip" runat="server" Text='<%# Eval("ShipQty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="In Shop" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInShop" runat="server" Text='<%# Eval("InShop") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>

            <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="LinkButton3"
                PopupControlID="Panel3" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="85%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton2" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="h-100">
                        <div class="row">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-sm-3 col-md-auto mb-3 modal-title text-center">
                                        <h4>
                                            <label class="mb-0 title-hyphen position-relative">Part Number:</label></h4>
                                    </div>
                                    <div class="col-sm-9 col-md mb-3 chosenFullWidth ">
                                        <h4>
                                            <asp:Label ID="lblTitle" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <table class="table mainGridTable table-sm">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInForcast" runat="server" AutoGenerateColumns="true"
                                EnableModelValidation="True">
                            </asp:GridView>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>

            <asp:ModalPopupExtender ID="ModalPopupStockIn" runat="server" TargetControlID="LinkButton4"
                PopupControlID="PanelStockIn" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PanelStockIn" runat="server" CssClass="ReportsModalPopup" Style="display: none;" Width="80%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton3" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-y: hidden;">
                        <div class="row justify-content-center">
                            <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                <div class="row">
                                    <div class="col-sm-3 col-md-auto mb-3 modal-title text-center">
                                        <h4>
                                            <label class="mb-0 title-hyphen position-relative">Part Number:</label></h4>
                                    </div>
                                    <div class="col-sm-9 col-md mb-3 chosenFullWidth ">
                                        <h4>
                                            <asp:Label ID="lblInStockPartNumber" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <table class="table mainGridTable table-sm">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInsTock" runat="server" AutoGenerateColumns="false"
                                EnableModelValidation="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="WareHouse Name" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWareHouseName" runat="server" Text='<%# Eval("WarehouseName") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stock In Hand" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStockInHand" runat="server" Text='<%# Eval("StockInHand") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </table>
                    </div>
                </div>

            </asp:Panel>


            <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>

            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvInventoryReportExcel" runat="server" Visible="false" AutoGenerateColumns="false"></asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGeneratePDF" />
            <asp:PostBackTrigger ControlID="btnGenerateExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            DDLName();

        }
        $.when.apply($, PageLoaded).then(function () {
            DDLName();
        });
        function DDLName() {
            $('#<%=ddlReportType.ClientID%>').chosen();
            $('#<%=ddlVendor.ClientID%>').chosen();
            $('#<%=ddlProductLine.ClientID%>').chosen();
            $('#<%=ddlPartNo.ClientID%>').chosen();
            $('#<%=ddlProductCode.ClientID%>').chosen();
            $('#<%=ddlPartStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>
