<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmStockIn.aspx.cs" Inherits="INVManagement_frmStockIn" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Stock In Details</h4>
                        </div>
                    </div>
                </div>
                    <div class="row pb-3">
            <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                <div class="row">
                    <div class="col-6">
                    <div class="row">
                    <div class="col-sm-12"><label class="mb-0 text-danger">Look Up Vendor*<label></div>
                    <div class="col-sm chosenFullWidth">
					 <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendor" DataTextField="Source" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged"></asp:DropDownList>
                    </div></div></div>
                    <div class="col-6">
                        <div class="row">
                    <div class="col-sm-12"><label class="mb-0 text-danger">Container No.*</label></div>
                    <div class="col-sm chosenFullWidth">                    
                          <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRequisitionNo" runat="server" DataTextField="ContainerDetail" DataValueField="Containerid" AutoPostBack="True" OnSelectedIndexChanged="ddlRequisitionNo_SelectedIndexChanged"></asp:DropDownList>                         
            </div></div></div>
                </div>
            </div>
            <div class="col-sm col-md col-lg col-xl-auto">
                <div class="row">
                    <div class="col-sm-12"><label class="mb-0">&nbsp;</label></div>
                     <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Stock In" CausesValidation="false" OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click"  />
                              
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                            </div>
                        </div>
                </div>
            </div>
        </div>

            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Add Stock In Details</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Receive Date*</label>
                            <asp:TextBox ID="txtReciveDate" CssClass="form-control form-control-sm" runat="server" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReciveDate" TargetControlID="txtReciveDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>   

                </div>
            </div>
            <div class="col-12">
               <%-- <div class="row border-top pt-3">--%>
                    <div class="col-sm-12">
                        <asp:Panel ID="pangvRequititionDetails" runat="server">
                            <div class="row pt-3">
                                <div class="col-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvMainRequisitionDetail" CssClass="table mainGridTable table-sm mb-0" DataKeyNames="PartId" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
    <Columns>
        <asp:TemplateField HeaderText="Part# (APN/CPN)/Description" HeaderStyle-Width="22%">
            <ItemTemplate>            
                <asp:Label ID="lblPartid" runat="server" Text='<%# Eval("PartId") %>' Visible="false">
                </asp:Label>
                <asp:Label ID="lblPartNumber" runat="server" Text='<%# Eval("PartNumber") %>'></asp:Label>
                  <asp:Label ID="lblPOId" runat="server" Text='<%# Eval("POid") %>' Visible="false"></asp:Label>
                <asp:Label ID="lblPODetailId" runat="server" Text='<%# Eval("PODetailid") %>' Visible="false"></asp:Label> 
            </ItemTemplate>
            <ItemStyle Width="22%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="80%" HeaderText="Purchase Order Details">
            <ItemTemplate>
                <asp:Panel ID="pnlPartsDetail" runat="server">
                    <asp:GridView CssClass="ChildGrid" ID="gvContainer" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                        <Columns>
                            <asp:TemplateField HeaderText="PO Number" HeaderStyle-Width="11%">
                                <ItemTemplate> 
                  <asp:Label ID="lblContainerPOId" runat="server" Text='<%# Eval("POid") %>' Visible="false"></asp:Label> 
                          <asp:Label ID="lblContainerPODetailId" runat="server" Text='<%# Eval("PODetailid") %>' Visible="false"></asp:Label>                                                           
                                    <asp:Label ID="lblPONumber" runat="server" Text='<%# Eval("PONumber") %>'></asp:Label>
                                    <asp:Label ID="lblItemPartid" runat="server" Visible="false" Text='<%# Eval("Partid") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                         <asp:TemplateField HeaderText="Requestor" HeaderStyle-Width="6%">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestor" runat="server" Text='<%# Eval("Attn") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="6%">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pending Qty" HeaderStyle-Width="6%">
                                <ItemTemplate>
                                    <asp:Label ID="lblPendingQty" runat="server" 
                                        Text='<%# Eval("Pendingqty") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ship Qty" HeaderStyle-Width="6%">
                                <ItemTemplate>
                                <asp:Label ID="txtShippingQty" runat="server" 
                                Text='<%# Eval("ShipQty") %>' ></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>          
                      <asp:TemplateField HeaderText="Skid No" HeaderStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="txtSkidNo" runat="server" Text='<%# Eval("SkidNo") %>' MaxLength="50" autocomplete="off"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="30%">
                                <ItemTemplate>
                                    <asp:Label ID="txtItemRemarks" runat="server" Text='<%# Eval("Remarks") %>' MaxLength="500" autocomplete="off"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%">
                                <ItemTemplate>
                                   <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' />  </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ItemTemplate>
            <ItemStyle Width="80%" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
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
                     $('#<%=ddlVendor.ClientID%>').chosen();
                    $('#<%=ddlRequisitionNo.ClientID%>').chosen();
            
                }
            </script>
            <asp:HiddenField ID="hfContainerid" runat="server" />
            </label>
            </label>
        </ContentTemplate>
    
    </asp:UpdatePanel>
</asp:Content>
