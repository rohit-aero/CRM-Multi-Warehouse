<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmDailyPurchaseReport.aspx.cs" Inherits="DailyPurchase_FrmDailyPurchaseReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_SalesActivity" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SalesActivity" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Daily Purchase Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="row">
                            <div class="col-2">
                                <div class="form-group">
                                    <label>PO No</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPOHeaderList" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-2">
                                <div class="form-group">
                                    <label>Vendor</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendor" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-4">
                                <div class="form-group">
                                    <label>Part</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPart" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-2">
                                <div class="form-group">
                                    <label>Requester</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRequester" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-2" style="display: none;">
                                <div class="form-group">
                                    <label>Project</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProject" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-2">
                                <div class="form-group">
                                    <label>Order Status</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOrderStatus" runat="server">
                                        <asp:ListItem Value="">All</asp:ListItem>
                                        <asp:ListItem Value="C">Confirmed</asp:ListItem>
                                        <asp:ListItem Value="X">Closed</asp:ListItem>
                                        <asp:ListItem Value="B">Banket Order</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label>Order Date From</label>
                                    <asp:TextBox ID="txtOrderDateFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                    </asp:TextBox>
                                    <asp:CalendarExtender ID="txtOrderDateFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtOrderDateFrom" TargetControlID="txtOrderDateFrom">
                                    </asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label>Order Date From</label>
                                    <asp:TextBox ID="txtOrderDateTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                    </asp:TextBox>
                                    <asp:CalendarExtender ID="txtOrderDateTo_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtOrderDateTo" TargetControlID="txtOrderDateTo">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-5 mt-2">
                        <div class="form-group">
                            <asp:Button ID="btnReport" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';"
                                Text="Generate Report" OnClick="btnReport_Click" />
                            <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false"
                                Text="Export To Excel" OnClick="btnExportToExcel_Click" />
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false"
                                Text="Search PO" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>

                <div class="row border-top">
                    <div class="col-12 mt-2">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvDailyPurchaseDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" ForeColor="White"
                                EnableModelValidation="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Part #">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPart" runat="server" Text='<%# Eval("Part") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="UM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUM" runat="server" Text='<%# Eval("UM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Requester" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequester" runat="server" Text='<%# Eval("Requester") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Department">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Order Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Received Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceivedQty" runat="server" Text='<%# Eval("ReceivedQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Pending Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPendingQty" runat="server" Text='<%# Eval("PendingQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Received Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceivedDate" runat="server" Text='<%# Eval("ReceivedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Cost">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalCost" runat="server" Text='<%# Eval("TotalCost") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <asp:GridView ID="gvExportToExcel" runat="server" CssClass="table mainGridTable table-sm mb-0" Visible="false"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="PO#">
                        <ItemTemplate>
                            <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("PONumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Vendor">
                        <ItemTemplate>
                            <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("Vendor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Part #">
                        <ItemTemplate>
                            <asp:Label ID="lblPart" runat="server" Text='<%# Eval("Part") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Requester">
                        <ItemTemplate>
                            <asp:Label ID="lblRequester" runat="server" Text='<%# Eval("Requester") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order Qty">
                        <ItemTemplate>
                            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Received Qty">
                        <ItemTemplate>
                            <asp:Label ID="lblReceivedQty" runat="server" Text='<%# Eval("ReceivedQty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="UM">
                        <ItemTemplate>
                            <asp:Label ID="lblUM" runat="server" Text='<%# Eval("UM") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order Date">
                        <ItemTemplate>
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order Status">
                        <ItemTemplate>
                            <asp:Label ID="lblOrderStatus" runat="server" Text='<%# Eval("OrderStatus") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ETA">
                        <ItemTemplate>
                            <asp:Label ID="lblETA" runat="server" Text='<%# Eval("ETA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Received Date">
                        <ItemTemplate>
                            <asp:Label ID="lblReceivedDate" runat="server" Text='<%# Eval("ReceivedDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
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
            $('#<%=ddlPOHeaderList.ClientID%>').chosen();
            $('#<%=ddlVendor.ClientID%>').chosen();
            $('#<%=ddlPart.ClientID%>').chosen();
            $('#<%=ddlRequester.ClientID%>').chosen();
            $('#<%=ddlProject.ClientID%>').chosen();
            $('#<%=ddlOrderStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>
