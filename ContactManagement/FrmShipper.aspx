<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmShipper.aspx.cs" Inherits="ContactManagement_FrmShipper" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfShipperID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfMemberID" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Shipper Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6">
                        <div class="row">
                            <div class="col-sm-auto mb-3">
                                <label class="mb-0">Company</label>
                            </div>
                            <div class="col-sm mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipper" runat="server" DataTextField="CompanyName" DataValueField="ShipperID"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlShipper_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg-auto">
                        <div class="row">
                            <div class="col-sm">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label><h5 class="text-uppercase">Company Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Comapny Name*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyName" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Street Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtComapnyAddress" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyCity" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlComapnyState" runat="server" DataTextField="State" DataValueField="StateID"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Contact Person Information&emsp;<asp:Button CssClass="btn btn-success btn-sm rounded" ID="btnAdd" runat="server" Text="Add" Enabled="false" OnClick="btnAdd_Click" /></h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">First Name*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFName" Enabled="false" autocomplete="off" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Last Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtLName" Enabled="false" autocomplete="off" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Telephone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" Enabled="false" autocomplete="off" MaxLength="15" onblur="phoneMask(this)" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" Enabled="false" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm no-scroll" ID="gvShipperMember" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="ShipperMemberID"
                        EnableModelValidation="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                        ForeColor="Black" GridLines="Vertical" Width="100%" Style="font-size: medium" OnRowEditing="gvShipperMember_RowEditing" OnRowDeleting="gvShipperMember_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="First Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridFName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridLName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="E-Mail">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modify">
                                <ItemTemplate>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm" ID="lnkEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                    &nbsp;
                                <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure to delete. ?');" CommandName="Delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
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
            $('#<%=ddlComapnyState.ClientID%>').chosen();
            $('#<%=ddlShipper.ClientID%>').chosen();

        }
    </script>

</asp:Content>
