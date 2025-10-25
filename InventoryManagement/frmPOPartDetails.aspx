<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPOPartDetails.aspx.cs" Inherits="InventoryManagement_frmPOPartDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Purchase Order Parts Detail</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Part#</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartNumber" runat="server" DataTextField="PartDes" DataValueField="PartId"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                <asp:Button CssClass="btn btn-secondary  btn-sm" ID="btnExportToExcel" runat="server" Text="Export To Excel" CausesValidation="false" OnClick="btnExportToExcel_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="col-sm-12">
                    <asp:Panel ID="pangvPOPartDetails" runat="server">
                        <div class="row pt-3">
                            <div class="col-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="gvPOPartsDetail" runat="server" CssClass="table mainGridTable table-sm mb-0" AutoGenerateColumns="False" EnableModelValidation="True" EmptyDataText="No Data Found" OnRowCommand="gvPOPartsDetail_RowCommand" OnRowDataBound="gvPOPartsDetail_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Part ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpartid" runat="server" Text='<%# Eval("PartID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="10%" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PartNo" HeaderText="Part #">
                                                <HeaderStyle Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PartDesc" HeaderText="Part Description">
                                                <HeaderStyle Width="40%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Total Order Qty" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>' CommandName="Order"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="10%" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Ship Qty" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkShipQty" runat="server" Text='<%# Eval("ShipQty") %>' CommandName="Ship"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="10%" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Stock in Hand" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkStockInQty" runat="server" Text='<%# Eval("StockIn") %>' CommandName="StockIn"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="10%" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Pending Qty" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPendingQty" runat="server" Text='<%# Eval("PendingQty") %>' CommandName="Pending"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="10%" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

                        </div>
                    </asp:Panel>
                </div>
            </div>

            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="ReportsModalPopup modal-xl" Style="display: none" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-auto h-100">
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
                                            <asp:Label ID="lblWarehouseDestination" runat="server" Text='<%# Eval("Destination") %>'>
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
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>


            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="LinkButton2"
                PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="btnClose2">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="ReportsModalPopup modal-xl" Style="display: none" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose2" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-auto h-100">
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
                                            <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("DestWarehouse") %>'>
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

                                </Columns>
                            </asp:GridView>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>

            <asp:ModalPopupExtender ID="ModalPopupOrder" runat="server" TargetControlID="LinkButton4"
                PopupControlID="PanelOrderQty" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PanelOrderQty" runat="server" CssClass="ReportsModalPopup modal-xl" Style="display: none;" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton2" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-auto h-100">
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
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvOrderQty" runat="server" AutoGenerateColumns="false"
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
                                            <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("DestWarehouse") %>'>
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

                                </Columns>
                            </asp:GridView>
                        </table>
                    </div>
                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>



            <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="LinkButton5"
                PopupControlID="Panel3" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" CssClass="ReportsModalPopup" Style="display: none;" Width="80%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton1" runat="server" ImageUrl="../images/closebtnCircle.png"
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
                                            <asp:Label ID="lblStockInHand" runat="server"></asp:Label></h4>
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
            <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>


            <asp:ModalPopupExtender ID="ModalPopupExtender4" runat="server" TargetControlID="LinkButton3"
                PopupControlID="PanelPendingQty" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PanelPendingQty" runat="server" CssClass="ReportsModalPopup modal-xl" Style="display: none" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton3" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-auto h-100">
                        <div class="row justify-content-center">
                            <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                <div class="row">
                                    <div class="col-sm-3 col-md-auto mb-3 modal-title text-center">
                                        <h4>
                                            <label class="mb-0 title-hyphen position-relative">Part Number:</label></h4>
                                    </div>
                                    <div class="col-sm-9 col-md mb-3 chosenFullWidth ">
                                        <h4>
                                            <asp:Label ID="lblPendingQtyPartNumber" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <table class="table mainGridTable table-sm">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvPendingQty" runat="server" AutoGenerateColumns="false"
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
                                            <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("DestWarehouse") %>'>
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
                                    <asp:TemplateField HeaderText="Pending Qty" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("PendingQty") %>'>
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
            <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>



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
                    $('#<%=ddlPartNumber.ClientID%>').chosen();

                }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

