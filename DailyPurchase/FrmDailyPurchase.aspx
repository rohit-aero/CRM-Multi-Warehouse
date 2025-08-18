<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmDailyPurchase.aspx.cs" Inherits="DailyPurchase_FrmDailyPurchase" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_SalesActivity" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SalesActivity" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Daily Purchase</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>PO No</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPOHeaderList" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPOHeaderList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 mt-2">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnPartRedirect" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Part Maintenance" OnClick="btnPartRedirect_Click" />
                            <asp:Button ID="btnVendorMaintenance" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" Text="Vendor Maintenance" OnClick="btnVendorMaintenance_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                            <asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';"
                                Text="Filter Report" OnClick="btnReport_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="row">
                    <div class="col-12">
                        <h5 class="text-uppercase">PO INFORMATION</h5>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">PO No*</label>
                            <asp:TextBox ID="txtPONo" CssClass="form-control form-control-sm" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Vendor*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendor" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>                    

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Order Date*</label>
                            <asp:TextBox ID="txtOrderDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtOrderDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtOrderDate" TargetControlID="txtOrderDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>                                                                                       
                    <%-- <div class="col-sm-2">
                        <div class="form-group">
                            <br />
                            
                        </div>
                    </div>--%>
                </div>

                <div class="row border-top">
                    <div class="col-12">
                        <h5 class="text-uppercase mt-1">DAILY PURCHASE INFORMATION
                        <asp:Button ID="btnSaveDetail" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Add Part" OnClick="btnSaveDetail_Click" />
                        </h5>
                    </div>

                    <div class="col-4">
                        <div class="form-group">
                            <label class="text-danger">Part*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPart" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Order Qty*</label>
                            <asp:TextBox ID="txtOrderQty" CssClass="form-control form-control-sm text-right" autocomplete="off" MaxLength="5" runat="server" onkeypress="return onlyNumbers(this, event);"
                                AutoPostBack="true" OnTextChanged="txtOrderQty_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Received Qty</label>
                            <asp:TextBox ID="txtReceivedQty" CssClass="form-control form-control-sm text-right" autocomplete="off" MaxLength="5" runat="server" onkeypress="return onlyNumbers(this, event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Received Date</label>
                            <asp:TextBox ID="txtReceivedDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtReceivedDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReceivedDate" TargetControlID="txtReceivedDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Requester*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRequester" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>ETA</label>
                            <asp:TextBox ID="txtETA" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtETA_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtETA" TargetControlID="txtETA">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Department*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDepartment" runat="server">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="C">Consumable</asp:ListItem>
                                <asp:ListItem Value="O">Customer Order</asp:ListItem>
                                <asp:ListItem Value="E">Electrical</asp:ListItem>
                                <asp:ListItem Value="F">Filters</asp:ListItem>
                                <asp:ListItem Value="H">Hardware</asp:ListItem>
                                <asp:ListItem Value="J">Job</asp:ListItem>
                                <asp:ListItem Value="T">Others</asp:ListItem>
                                <asp:ListItem Value="P">Polishing</asp:ListItem>
                                <asp:ListItem Value="L">Plumbing</asp:ListItem>
                                <asp:ListItem Value="S">Shipping</asp:ListItem>
                                <asp:ListItem Value="M">Sheet Metal</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOrderStatus" runat="server">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="L">Cancelled</asp:ListItem>
                                <asp:ListItem Value="C">Confirmed</asp:ListItem>
                                <asp:ListItem Value="X">Closed</asp:ListItem>
                                <asp:ListItem Value="D">Delayed</asp:ListItem>
                                <asp:ListItem Value="B">Banket Order</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>     

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Unit Price*</label>
                            <asp:TextBox ID="txtUnitPrice" CssClass="form-control form-control-sm text-right" autocomplete="off" MaxLength="10" runat="server" onkeypress="return onlyDotsAndNumbers(this, event);"
                                AutoPostBack="true" OnTextChanged="txtUnitPrice_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Total Cost</label>
                            <asp:TextBox ID="txtTotalCost" CssClass="form-control form-control-sm text-right" autocomplete="off" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-6">
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:TextBox ID="txtRemarks" CssClass="form-control form-control-sm" TextMode="MultiLine" autocomplete="off" oninput="return limitMultiLineInputLength(this, 500)" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row border-top">
                    <div class="col-12 mt-2">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvDailyPurchaseDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" ForeColor="White"
                                EnableModelValidation="True" OnRowEditing="gvDailyPurchaseDetail_RowEditing" OnRowDeleting="gvDailyPurchaseDetail_RowDeleting" OnSorting="gvDailyPurchaseDetail_Sorting" AllowSorting="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Part #" SortExpression="Part">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPart" runat="server" Text='<%# Eval("Part") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="UM" SortExpression="UM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUM" runat="server" Text='<%# Eval("UM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Requester" SortExpression="Requester">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequester" runat="server" Text='<%# Eval("Requester") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ETA" SortExpression="ETA">
                                        <ItemTemplate>
                                            <asp:Label ID="lblETA" runat="server" Text='<%# Eval("ETA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Department" SortExpression="Department">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Order Status" SortExpression="OrderStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("OrderStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Order Qty" SortExpression="OrderQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Received Qty" SortExpression="ReceivedQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceivedQty" runat="server" Text='<%# Eval("ReceivedQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Received Date" SortExpression="ReceivedDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceivedDate" runat="server" Text='<%# Eval("ReceivedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit Price" SortExpression="UnitPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Cost" SortExpression="TotalCost">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalCost" runat="server" Text='<%# Eval("TotalCost") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                <i class="far fa-times-circle"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>                   
                                        <ItemStyle Width="100px"/>                     
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfDetailID" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
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
            $('#<%=ddlDepartment.ClientID%>').chosen();
            $('#<%=ddlOrderStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>
