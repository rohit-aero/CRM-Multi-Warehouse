<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmStockAdjustment.aspx.cs" Inherits="INVManagement_FrmStockAdjustment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="col-lg-9">
                    <fieldset>
                        <legend>Inventory Transaction Adjustments</legend>
                        <div class="row customSelects">
                            <label class="col-xl-2 mb-0">By Product Code</label>
                            <div class="col-xl-10 mb-2">
                                <asp:DropDownList ID="ddlProductCode" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="True" 
                                    OnSelectedIndexChanged="ddlProductCode_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <label class="col-xl-2 mb-0">By Part Number</label>
                            <div class="col-xl-10 mb-2">
                                <asp:DropDownList ID="ddlPartNumber" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="True" 
                                    OnSelectedIndexChanged="ddlPartNumber_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <label class="col-xl-2 mb-0">Warehouse</label>
                            <div class="col-xl-10 mb-2">
                                <asp:DropDownList ID="ddlWarehouse" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                            </div>

                            <label class="col-xl-2 mb-0">Adjustment Type</label>
                            <div class="col-xl-10 mb-2">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlType" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="1">Stock In</asp:ListItem>
                                    <asp:ListItem Value="2">Stock Out</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <label class="col-xl-2 mb-0">Adjustment Reason</label>
                            <div class="col-xl-10 mb-2">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReason" DataTextField="reason" DataValueField="id" runat="server">
                                </asp:DropDownList>
                            </div>
                            <label class="col-xl-2 mb-0">Quantity</label>
                            <div class="col-xl-10 mb-2">
                                <asp:TextBox ID="txtQty" CssClass="form-control form-control-sm" runat="server" autocomplete="off" onkeypress="return onlyNumbers(event);" MaxLength="7"></asp:TextBox>
                            </div>
                            <label class="col-xl-2 mb-0">Summary</label>
                            <div class="col-xl-10 mb-2">
                                <asp:TextBox ID="txtSummary" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server" MaxLength="500"></asp:TextBox>
                            </div>
                            <div class="offset-xl-2 col-xl-10">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" OnClientClick="return confirm('Are you Sure ?');" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="col-12">
            </div>
            <div class="col-12 pt-3">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvSearch" runat="server" AutoGenerateColumns="False"
                        EnableModelValidation="True" EmptyDataText="No Transaction Found">
                        <Columns>
                            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" SortExpression="TransactionID">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction Type" DataField="TransactionType" SortExpression="TransactionType">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Part Number" DataField="partnumber" SortExpression="partnumber">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Part Description" DataField="PartDes" SortExpression="PartDes">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Warehouse" DataField="WarehouseName" SortExpression="WarehouseName">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Opening Stock" DataField="openingstock" SortExpression="openingstock">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction Qty" DataField="transactqty" SortExpression="transactqty">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Closing Stock" DataField="closingstock" SortExpression="closingstock">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction Date Time" DataField="transactdatetime" SortExpression="transactdatetime">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Reason" DataField="reason" SortExpression="reason">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction Summary" DataField="transactsummary" SortExpression="transactsummary">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Transaction By" DataField="EmpName" SortExpression="EmpName">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="HfProjectNo" runat="server" />
                </div>
            </div>
            <script type="text/javascript">
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
                    $('#<%=ddlPartNumber.ClientID%>').chosen();
                    $('#<%=ddlReason.ClientID%>').chosen();
                    $('#<%=ddlType.ClientID%>').chosen();
                    $('#<%=ddlWarehouse.ClientID%>').chosen();
                    $('#<%=ddlProductCode.ClientID%>').chosen();
                }
    </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

