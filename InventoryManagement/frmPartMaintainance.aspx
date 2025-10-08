<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="frmPartMaintainance.aspx.cs" Inherits="INVManagement_frmPartMaintainance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col pt-2 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Part Maintenance</h4>
                            <div class="col-sm-6 justify-content-center" id="dvMsg" runat="server" visible="false">
                                <strong class="text-center">
                                    <asp:Label runat="server" CssClass="alert alert-success d-block py-1 mb-0" ID="lblMsg"></asp:Label></strong>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row pb-3">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                        <div class="row">
                            <div class="col-3">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Product Code</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm control-access-enabled" ID="ddlProductCodeLookUp" runat="server" DataTextField="productcode" DataValueField="productcodeid" AutoPostBack="True" OnSelectedIndexChanged="ddlProductCodeLookUp_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-5">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Part#/Description</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm control-access-enabled" ID="ddlPartInfo" runat="server" DataTextField="PartDes" DataValueField="Partid" AutoPostBack="True" OnSelectedIndexChanged="ddlPartInfo_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">&nbsp;</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm control-access-enabled" Text="Save" OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnReport" runat="server" CssClass="btn btn-primary btn-sm control-access-enabled" Text="Preview Report" OnClick="btnReport_Click" />
                                        <asp:Button ID="btnITWReport" runat="server" CssClass="btn btn-secondary btn-sm control-access-enabled" Text="ITW Report" OnClick="btnITWReport_Click" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm control-access-enabled" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12" id="dvAccessControls" runat="server">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Add New Record</h5>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label style="color: red">Product Code*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm control-access" ID="ddlProductCode" DataTextField="productcode" DataValueField="productcodeid" runat="server" OnSelectedIndexChanged="ddlProductCode_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>

                    <div runat="server" id="ITWDiv" class="row col-8">
                        <div class="col-2">
                            <label>Company</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompany" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>

                        <div class="col-2">
                            <div class="form-group">
                                <label>Category</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" DataTextField="name" DataValueField="id" CssClass="form-control form-control-sm control-access" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="form-group">
                                <label>Size (In Inches)</label>
                                <asp:DropDownList ID="ddlSize" runat="server" DataTextField="SizeName" DataValueField="id" CssClass="form-control form-control-sm control-access">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="form-group">
                                <label>Orientation</label>
                                <asp:DropDownList ID="ddlDirection" runat="server" CssClass="form-control form-control-sm control-access">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="LR">LR</asp:ListItem>
                                    <asp:ListItem Value="RL">RL</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-2">
                            <label>Option</label>
                            <asp:DropDownList ID="ddlOption" runat="server" CssClass="form-control form-control-sm control-access">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">With Drain</asp:ListItem>
                                <asp:ListItem Value="2">With Sump</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label style="color: red">Part No.*</label>
                            <asp:TextBox CssClass="form-control form-control-sm control-access" autocomplete="off" ID="txtPartNo" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Customer Part No.</label>
                            <asp:TextBox CssClass="form-control form-control-sm control-access" autocomplete="off" ID="txtCustPartNo" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Product Line</label>
                            <asp:DropDownList CssClass="form-control form-control-sm control-access" autocomplete="off" ID="ddlProductLineID" DataValueField="ProductID" DataTextField="Product" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Measuring Unit</label>
                            <asp:DropDownList CssClass="form-control form-control-sm control-access" ID="ddlUM" runat="server" DataTextField="UM" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-1">
                        <div class="form-group">
                            <label>Revision No</label>
                            <asp:DropDownList CssClass="form-control form-control-sm control-access" ID="ddlRevisionNo" runat="server">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="A">A</asp:ListItem>
                                <asp:ListItem Value="B">B</asp:ListItem>
                                <asp:ListItem Value="C">C</asp:ListItem>
                                <asp:ListItem Value="D">D</asp:ListItem>
                                <asp:ListItem Value="E">E</asp:ListItem>
                                <asp:ListItem Value="F">F</asp:ListItem>
                                <asp:ListItem Value="G">G</asp:ListItem>
                                <asp:ListItem Value="H">H</asp:ListItem>
                                <asp:ListItem Value="I">I</asp:ListItem>
                                <asp:ListItem Value="J">J</asp:ListItem>
                                <asp:ListItem Value="K">K</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-3">
                        <div class="form-group">
                            <label>Description</label>
                            <asp:TextBox CssClass="form-control form-control-sm control-access" autocomplete="off" ID="txtDes" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group srRadiosBtns">
                            <label>Stock Item</label>
                            <asp:RadioButtonList ID="rdbStockItem" runat="server" RepeatDirection="Horizontal" CssClass="control-access">
                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Department</label>
                            <asp:DropDownList CssClass="form-control form-control-sm control-access" ID="ddlDepartment" DataTextField="Department" DataValueField="id" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Source</label>
                            <asp:DropDownList CssClass="form-control form-control-sm control-access" ID="ddlSource" runat="server" DataTextField="Source" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Stock In Hand</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtStockInHand" runat="server" Enabled="false" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Min</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right control-access-enabled" ID="txtMin" MaxLength="6" runat="server" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Max</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right control-access-enabled" ID="txtMax" MaxLength="6" runat="server" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Re-Order Point</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right control-access-enabled" ID="txtReOrderPoint" MaxLength="6" runat="server" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Re-Order Qty</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right control-access-enabled" ID="txtReOrderQty" MaxLength="6" runat="server" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>MOQ</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right control-access-enabled" ID="txtMOQ" MaxLength="5" runat="server" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>EAU</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right control-access-enabled" ID="txtEAU" MaxLength="5" runat="server" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Batch</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right control-access-enabled" ID="txtBatch" MaxLength="5" runat="server" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Lead Time Weeks</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right control-access-enabled" ID="txtLeadTime" MaxLength="2" runat="server" autocomplete="off" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm control-access" ID="ddlPartStatus" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Current</asp:ListItem>
                                <asp:ListItem Value="2">Obsolete</asp:ListItem>
                                <asp:ListItem Value="3">Not In Use</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Part Image (JPG only)</label>
                            <asp:FileUpload ID="fpUploadpartimage" CssClass="btn btn-success btn-sm btn-block control-access" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <asp:Image ID="Image1" CssClass="img-thumbnail img-fluid control-access" runat="server" />
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Drawings (PDF Only)</label>
                            <asp:FileUpload ID="fpUploadShopDrawing" CssClass="btn btn-success btn-sm btn-block control-access" runat="server" />
                            <asp:LinkButton ID="lnkDowload" runat="server" Text="Download Pdf" Visible="false" OnClick="lnkDowload_Click"></asp:LinkButton>
                            <%--  <input type="file" id="myFile" name="myFile" />--%>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group srRadiosBtns">
                            <label>Display in Forecast Report</label>
                            <asp:RadioButtonList ID="rdbForecast" runat="server" RepeatDirection="Horizontal" CssClass="control-access">
                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group srRadiosBtns">
                            <label>Line Stopper</label>
                            <asp:RadioButtonList ID="rdbLineStopper" runat="server" RepeatDirection="Horizontal" CssClass="control-access" OnSelectedIndexChanged="rdbLineStopper_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Line Stopper Priority</label>
                            <asp:DropDownList CssClass="form-control form-control-sm control-access" ID="ddlLineStopperPriority" runat="server">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="H">High</asp:ListItem>
                                <asp:ListItem Value="M">Medium</asp:ListItem>
                                <asp:ListItem Value="L">Low</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--<div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Stock Item</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStockItem" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="2">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
                    <div class="col-sm-8 col-md-4 col-lg-2">
                    </div>
                </div>
            </div>
            <div class="col-12 border-top pt-3"></div>
            <div class="col-sm-12">
                <asp:Panel ID="pangvShopdwg" runat="server" Visible="false">
                    <h5 class="text-uppercase">
                        <asp:Label ID="lblMessage" runat="server" Text="Shop Drawings"></asp:Label></h5>
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive" id="gvShowDwg" runat="server">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvShopDwg" runat="server" AutoGenerateColumns="False" DataKeyNames="Drawingid"
                                    EnableModelValidation="True" OnRowCommand="gvShopDwg_RowCommand" OnRowDeleting="gvShopDwg_RowDeleting" OnRowDataBound="gvShopDwg_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Revision No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrevisionNo" runat="server" Text='<%# Eval("revisionno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Stock In Hand">
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
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this Revision ?');" CommandName="Delete"><i class="far fa-times-circle" title="Delete"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>

            <div class="col-12 border-top mt-3"></div>
            <div class="col-3">
                <div class="row pt-3">
                    <div class="col-sm-12">
                        <%--<h5 class="text-uppercase">Warehouse Stock</h5>--%>
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ForeColor="White" ID="gvWarehouseStock" runat="server" AutoGenerateColumns="false"
                                EnableModelValidation="True" ShowFooter="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Warehouse Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWarehouseName" runat="server" Text='<%# Eval("Warehouse Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Stock In Hand" HeaderStyle-CssClass="align-right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStockInHand" runat="server" Text='<%# Eval("Stock In Hand") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfpartid" runat="server" />
            <asp:HiddenField ID="hfpartimage" runat="server" />
            <asp:HiddenField ID="hfshopdrawing" runat="server" />
            <asp:HiddenField ID="hfGetpartimage" runat="server" />
            <asp:HiddenField ID="hfgetshopdrawing" runat="server" />
            <asp:HiddenField ID="hfcontrolaccess" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <%--  <asp:AsyncPostBackTrigger ControlID="btnSave" EventName = "Click" />--%>
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
            <%--$('#<%=ddlProductLine.ClientID%>').chosen();--%>
            $('#<%=ddlPartInfo.ClientID%>').chosen();            
            <%-- $('#<%=ddlProductCat.ClientID%>').chosen();  --%>
            $('#<%=ddlUM.ClientID%>').chosen();
            $('#<%=ddlRevisionNo.ClientID%>').chosen();
            $('#<%=ddlDepartment.ClientID%>').chosen();
            $('#<%=ddlSource.ClientID%>').chosen();
            $('#<%=ddlPartStatus.ClientID%>').chosen();
            $('#<%=ddlProductCode.ClientID%>').chosen();
            $('#<%=ddlProductCodeLookUp.ClientID%>').chosen();
            $('#<%=ddlProductLineID.ClientID%>').chosen();
            $('#<%=ddlOption.ClientID%>').chosen();
            $('#<%=ddlCategory.ClientID%>').chosen();
            $('#<%=ddlSize.ClientID%>').chosen();
            $('#<%=ddlDirection.ClientID%>').chosen();
            $('#<%=ddlLineStopperPriority.ClientID%>').chosen();
            $('#<%=ddlCompany.ClientID%>').chosen();
        }

    </script>
</asp:Content>
