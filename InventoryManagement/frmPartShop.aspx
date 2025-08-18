<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPartShop.aspx.cs" Inherits="InventoryManagement_frmPartShop" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Parts Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <div class="row">
                            <div class="col-sm-2 col-md-auto mb-2">
                                <label class="mb-0">Product Code</label>
                            </div>
                            <div class="col-sm-3 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductCode" runat="server" DataValueField="productcodeid" DataTextField="productcode" OnSelectedIndexChanged="ddlProductCode_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-auto col-md-auto mb-2">
                                <label class="mb-0">Product Line</label>
                            </div>
                            <div class="col-sm col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLine" runat="server" DataValueField="ProductID" DataTextField="Product">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-auto col-md-auto mb-2">
                                <label class="mb-0">Status</label>
                            </div>
                            <div class="col-sm col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartStatus" runat="server">
                                    <asp:ListItem Value="-1" Selected="True">All</asp:ListItem>
                                    <asp:ListItem Value="1">Current</asp:ListItem>
                                    <asp:ListItem Value="0">Obsolete</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-auto col-md-auto mb-2">
                                <label class="mb-0">Dwg Attached</label>
                            </div>
                            <div class="col-sm col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDwgAttached" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="-1">All</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-auto col-md-auto mb-2">
                                <label class="mb-0">Line Stoppers</label>
                            </div>
                            <div class="col-sm col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLineStoppers" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="-1" Selected="True">All</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                   
                </div>
                       <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <div class="row">
       
                            <div class="col-sm-auto col-md-auto mb-2">
                            <label class="mb-0">Search Keyword</label>
                            </div>
                            <div class="col-sm col-md mb-3 chosenFullWidth">
                            <asp:TextBox ID="txtPartNum" runat="server" autocomplete="off"
                            CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                                                 <div class="col-auto mb-3">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnExporttoExcel" CausesValidation="false" runat="server" Enabled="false" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnExporttoPdf" CausesValidation="false" runat="server" Enabled="false" Text="Export to Pdf" 
                                    OnClick="btnExportToPdf_Click"
                                     />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                            <div class="col-md justify-content-center">
                                <strong class="text-center">
                                    <asp:Label CssClass="alert alert-success d-block py-1" ID="lblRecordsCount" runat="server" Text="Label" Visible="false"></asp:Label>
                                </strong>
                            </div>

    
                            </div>
                        </div>
                    </div>

            </div>
            <div class="row border-top pt-3">
            </div>
            <div class="col-12">
                <h5 class="text-uppercase">Parts Details</h5>
            </div>

            <div class="col-12  mt-3" id="divgvsearch">
                <div class="table-responsive">
                    <asp:GridView ID="gvPartsDetails" runat="server" AutoGenerateColumns="False" Visible="true" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="3" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="100%"
                           CssClass="table mainGridTable table-sm"
                            Style="font-size: small"   BackColor="White" BorderColor="#999999" OnRowDataBound="gvPartsDetails_RowDataBound">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                    <asp:BoundField DataField="ProductCode" HeaderText="Product Code">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PartNumber" HeaderText="Part Number#">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PartDes" HeaderText="PartDescription">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                              <asp:BoundField DataField="Product" HeaderText="Product Line">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                     <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                   <asp:BoundField DataField="PartImage" HeaderText="Part Image">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField> 
                              <asp:BoundField DataField="StockItem" HeaderText="Stock Item">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="DwgAttached" HeaderText="Dwg Attached">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>    
                           <asp:BoundField DataField="Status" HeaderText="Status">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>                          
                                <asp:BoundField DataField="stockinhand" HeaderText="Stock In Hand ">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="reorderpoint" HeaderText="Re Order Point">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="reorderqty" HeaderText="Re Order Qty">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                           <asp:BoundField DataField="LeadTime" HeaderText="Lead Time">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LineStopper" HeaderText="Line Stopper">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    <asp:GridView ID="gvSearch" runat="server" CssClass="table mainGridTable table-sm mb-0" 
                        AutoGenerateColumns="false" Visible="false"  AllowSorting="true" OnSorting="gvSearch_Sorting">
                        <%--<HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Product Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductCode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartNumber" runat="server" Text='<%# Eval("PartNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part Des">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartDes" runat="server" Text='<%# Eval("PartDes") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product Line">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductLine" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UM">
                                <ItemTemplate>
                                    <asp:Label ID="lblUM" runat="server" Text='<%# Eval("UM") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part Image">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lblPartImage" runat="server" Text='<%# Eval("PartImage") %>'></asp:Label>--%>
                                    <asp:Image ID ="imgPartImage" runat="server" ImageUrl='<%# Eval("PartImage") %>' Height="100px" Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="Stock Item">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockItem" runat="server" Text='<%# Eval("StockItem") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dwg Attached">
                                <ItemTemplate>
                                    <asp:Label ID="lblDwgAttached" runat="server" Text='<%# Eval("DwgAttached") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock In Hand">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockInHand" runat="server" Text='<%# Eval("StockInHand") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Reorder Point">
                                <ItemTemplate>
                                    <asp:Label ID="lblReorderPoint" runat="server" Text='<%# Eval("ReorderPoint") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ReorderQty">
                                <ItemTemplate>
                                    <asp:Label ID="lblReorderQty" runat="server" Text='<%# Eval("ReorderQty") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Lead Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblLeadTime" runat="server" Text='<%# Eval("LeadTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Line Stopper">
                                <ItemTemplate>
                                    <asp:Label ID="lblLineStopper" runat="server" Text='<%# Eval("LineStopper") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExporttoExcel" />
        <asp:PostBackTrigger ControlID="btnExportToPdf" />
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
            $('#<%=ddlLineStoppers.ClientID%>').chosen();
            $('#<%=ddlProductCode.ClientID%>').chosen();
            $('#<%=ddlPartStatus.ClientID%>').chosen();
            $('#<%=ddlProductLine.ClientID%>').chosen();
            $('#<%=ddlDwgAttached.ClientID%>').chosen();
        }

        
    </script>
</asp:Content>
