<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="frmSearchPart.aspx.cs" Inherits="InventoryManagement_frmSearchPart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col pt-2 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Part</h4>
                            <div class="col-sm-6 justify-content-center" id="dvMsg" runat="server" visible="false">
                                <strong class="text-center">
                                    <asp:Label runat="server" CssClass="alert alert-success d-block py-1 mb-0" ID="lblMsg"></asp:Label></strong>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row pb-3">
                    <div class="col-sm col-md-8 col-lg-8">
                        <div class="row">
                <div class="col-3">
                    <div class="row">
                    <div class="col-sm-12"><label class="mb-0">Product Code</label></div>
                    <div class="col-sm chosenFullWidth">
					 <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductCodeLookUp" runat="server" DataTextField="productcode" DataValueField="productcodeid" AutoPostBack="True" OnSelectedIndexChanged="ddlProductCodeLookUp_SelectedIndexChanged"></asp:DropDownList>	 
                    </div></div></div>
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Part# (APN/CPN) Description</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartDescHeaderList" runat="server" DataTextField="PartDes" DataValueField="PartId" AutoPostBack="True" OnSelectedIndexChanged="ddlPartDescHeaderList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                                               <div class="col-3">
                        <div class="row">
                    <div class="col-sm-12"><label class="mb-0">&nbsp;</label></div>
                    <div class="col-sm chosenFullWidth">      
                                                      <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-sm" Text="Search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
            </div></div></div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg ">
                        <div class="row">
                            <div class="col-sm-12">
                                <label class="mb-0">&nbsp;</label>
                            </div>
                            <div class="col-auto">
        
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Product Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtProductCode" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Aerowerks Part No.</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPartNo" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Customer Part No.</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCustomerPartNo" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                     <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Product Line</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtProductLine" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Measuring Unit</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtUM" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-1">
                        <div class="form-group">
                            <label>Revision No</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtRevision" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-3">
                        <div class="form-group">
                            <label>Description</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDes" runat="server" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Department</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDepartment" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Source</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSource" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Stock In Hand</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtStockInHand" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Min</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtMin" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Max</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtMax" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Re-Order Point</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtReOrderPoint" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Re-Order Qty</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtReOrderQty" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Lead Time Weeks</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtLeadTime" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtStatus" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Part Image</label>
                        </div>
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-2">                        
                        <asp:Image ID="Image1" CssClass="img-thumbnail img-fluid" runat="server" />
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-2">
                    </div>
                </div>
            </div>

            <div class="row border-top pt-3"></div>
            <div class="col-sm-12">
                <asp:Panel ID="pangvShopdwg" runat="server" Visible="false">
                    <h5 class="text-uppercase">
                        <asp:Label ID="lblMessage" runat="server" Text="Shop Drawings"></asp:Label></h5>
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvShopDwg" runat="server" AutoGenerateColumns="False" DataKeyNames="Drawingid"
                                    OnRowCommand="gvShopDwg_RowCommand" EnableModelValidation="True">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Revision No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrevisionNo" runat="server" Text='<%# Eval("revisionno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Stock In Hand">
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStockInHand" runat="server" Text='<%# Eval("stockinhand") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Drawing Name (Preview & Download)">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDrawing" runat="server" CausesValidation="false" Text='<%# Eval("drawingname") %>' OnClientClick="openInNewTab();" CommandName="select"></asp:LinkButton>
                                                <asp:Label ID="lblDrwaingnameNo" runat="server" Text='<%# Eval("drawingname") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
             <asp:HiddenField ID="hfgetshopdrawing" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="gvShopDwg" />
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
            $('#<%=ddlPartDescHeaderList.ClientID%>').chosen();   
            $('#<%=ddlProductCodeLookUp.ClientID%>').chosen();  
        }
    </script>
</asp:Content>
