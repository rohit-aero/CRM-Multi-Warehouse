<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPOPartDetails.aspx.cs" Inherits="InventoryManagement_frmPOPartDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
             <div class="col-12 pt-2 piDiv position-sticky">
                 <div class="row">
                    <div class="col-12">
                    <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Purchase Order Parts Detail</h4>
                    </div>
                    </div>
                </div>
                 <div class="row">
                  <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                <div class="row">
                    <div class="col-sm-3 col-md-auto mb-3">
                        <label class="mb-0">Lookup Part#</label></div>
                    <div class="col-sm-9 col-md mb-3 chosenFullWidth">
					<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartNumber" runat="server" DataTextField="PartDes" DataValueField="PartId" ></asp:DropDownList>                    
                    </div>
                </div>
            </div>
             <div class="col-sm col-md col-lg col-xl-auto">
                <div class="row">
                    <div class="col-auto">
					    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"  />
                           <asp:Button CssClass="btn btn-secondary  btn-sm" ID="btnExportToExcel" runat="server" Text="Export To Excel" CausesValidation="false" OnClick="btnExportToExcel_Click"  />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  />
                     
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
                            <asp:GridView ID="gvPOPartsDetail" runat="server" CssClass="table mainGridTable table-sm mb-0"  AutoGenerateColumns="False" EnableModelValidation="True" EmptyDataText="No Data Found">
                                    <Columns>
                                        <asp:BoundField DataField="Part#" HeaderText="Part #">
                                        <HeaderStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Description" HeaderText="Part Description">
                                        <HeaderStyle Width="50%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OrderQty" HeaderText="Total Order Qty">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ShipQty" HeaderText="Total Ship Qty" >
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PendingQty" HeaderText="Total Pending Qty">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
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
                    $('#<%=ddlPartNumber.ClientID%>').chosen();
            
                }
            </script>
        </ContentTemplate>
          <Triggers>
              <asp:PostBackTrigger ControlID="btnExportToExcel" />
          </Triggers>
</asp:UpdatePanel>
</asp:Content>

