<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmStockInHandAdj.aspx.cs" Inherits="InventoryManagement_FrmStockInHandAdj" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>


                        <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Stock Adjustment For Container</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-2">
                    <div class="col-2">
                        <label>Look Up Vendor</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendorLookup" runat="server" DataTextField="Source" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlVendorLookup_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                             <label>Invoice No./Container No.</label>
                        <asp:DropDownList ID="ddlContainerNo" CssClass="form-control form-control-sm" runat="server" DataTextField="ContainerNo" DataValueField="ContainerID" AutoPostBack="True" OnSelectedIndexChanged="ddlContainerNo_SelectedIndexChanged"></asp:DropDownList>
                    </div> 
                    <div class="col-4">
                        <label>&nbsp;</label>
                        <div class="">
                             <asp:Button CssClass="btn btn-success btn-sm" ID="btnSubmit" runat="server" OnClientClick="return confirm('Are you Sure ?');" CausesValidation="false" Text="Make Adjustment" OnClick="btnSubmit_Click" Enabled="false" />
                             <asp:Button CssClass="btn btn-success btn-sm" ID="btnExportToExcel" runat="server" OnClientClick="return confirm('Are you Sure ?');" CausesValidation="false" Text="Export To Excel" OnClick="btnExportToExcel_Click" Enabled="false" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" CausesValidation="false"  Text="Cancel" OnClick="btnCancel_Click"  />
                        </div>
                    </div>
                </div>
            </div>

            <%-- Grid Container History --%>
            <div class="col-12 pt-3">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvAddParts" runat="server" AutoGenerateColumns="False" DataKeyNames="PartID"
                        EnableModelValidation="True" Style="margin-top: 0px" OnRowDataBound="gvAddParts_RowDataBound">   
                        <Columns>             
                            <asp:TemplateField HeaderText="PartID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartID" runat="server" autocomplete="off" Text='<%# Eval("PartID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>          
                                <ItemStyle Width="25%" />                         
                            </asp:TemplateField>                  
                            <asp:TemplateField HeaderText="Part No/Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartNo" runat="server" autocomplete="off" Text='<%# Eval("PartNo") %>'></asp:Label>
                                </ItemTemplate>          
                                <ItemStyle Width="25%" />                         
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="Vendor">
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor" runat="server" autocomplete="off" Text='<%# Eval("Vendor") %>'></asp:Label>
                                </ItemTemplate>    
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Min">
                                <ItemTemplate>
                                    <asp:Label ID="lblMin" runat="server" autocomplete="off" Text='<%# Eval("min") %>'></asp:Label>
                                </ItemTemplate>    
                                <ItemStyle Width="7%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Max">
                                <ItemTemplate>
                                    <asp:Label ID="lblMax" runat="server" autocomplete="off" Text='<%# Eval("max") %>'></asp:Label>
                                </ItemTemplate>    
                                <ItemStyle Width="7%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock In Hand">                                
                                <ItemTemplate>
                                    <asp:label ID="txtStockInHand" runat="server" Text='<%# Eval("StockInHand") %>'></asp:label>
                                </ItemTemplate>    
                                 <ItemStyle Width="5%" HorizontalAlign="Right" />   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ship Qty">                                
                                <ItemTemplate>
                                    <asp:label ID="lblShipQty" runat="server" Text='<%# Eval("ShipQty") %>'></asp:label>
                                </ItemTemplate>    
                                 <ItemStyle Width="5%" HorizontalAlign="Right" />   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Closing Stock">                                
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTransactQty" runat="server" Text='<%# Eval("transactqty") %>' CssClass="form-control form-control-sm text-right" onkeypress="validateIntegerInput(event)" autocomplete="off" MaxLength="10"></asp:TextBox>
                                </ItemTemplate>    
                                 <ItemStyle Width="5%" HorizontalAlign="Right" />   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Adjustment Summary">                               
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSummary" runat="server" Text='<%# Eval("summary") %>' CssClass="form-control form-control-sm" MaxLength="250" autocomplete="off"></asp:TextBox>
                                </ItemTemplate>  
                                <ItemStyle Width="40%" />   
                            </asp:TemplateField>       

                        </Columns>                                      
                    </asp:GridView>
                </div>
            </div>           
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
                        $('#<%=ddlVendorLookup.ClientID%>').chosen();   
                        $('#<%=ddlContainerNo.ClientID%>').chosen();
                    }
                function validateIntegerInput(event) {
                    // Get the key code of the pressed key
                    var keyCode = event.keyCode || event.which;
                    console.log(keyCode);
                    // Allow: backspace, tab, enter, escape, and delete
                    if (keyCode === 8 || keyCode === 9 || keyCode === 13 || keyCode === 27) {
                        return; // Allow these keys
                    }

                    // Allow: Ctrl+A, Ctrl+C, Ctrl+V
                    if (event.ctrlKey && (keyCode === 65 || keyCode === 67 || keyCode === 86)) {
                        return; // Allow Ctrl+A, Ctrl+C, Ctrl+V
                    }

                    // Prevent decimal point (key code 190)
                    if (keyCode === 46) {
                        event.preventDefault(); // Prevent decimal point
                        return; // Exit the function
                    }

                    // Ensure that it is a number (0-9) and stop the keypress
                    if (keyCode < 48 || keyCode > 57) {
                        event.preventDefault(); // Prevent any non-numeric input
                    }
                }
            </script>
    </ContentTemplate> 
                <Triggers>          
            <asp:PostBackTrigger ControlID="btnExportToExcel" />                                                            
        </Triggers>     
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgressloader" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
        <ProgressTemplate>
            <div class="spinner">
                <div class="center-div">
                    <div class="inner-div">
                        <div class="loader"></div>
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>