<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmCampus.aspx.cs" Inherits="NACUFS_FrmCampus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Campus Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">University</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3">
                                <asp:DropDownList ID="ddlUniv" CssClass="form-control form-control-sm" runat="server" DataTextField="UniName" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlUniv_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Campus</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3">
                                <asp:DropDownList ID="ddlCampus" CssClass="form-control form-control-sm" runat="server" DataTextField="CampusName" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
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
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Campus Details</h5>
                    </div>
                     <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Campus Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCampus" autocomplete="off" MaxLength="150" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Country" DataValueField="CountryID" ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>State</label>
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" DataValueField="StateID" DataTextField="State" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                                <div class="input-group-prepend pl-1">
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStateAb" DataValueField="StateID" DataTextField="Sabb" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStateAb_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Zip Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtZipCode" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
               <%-- <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Person Details</h5>
                    </div>
                    <div class="col-12">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvDetail" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="PersonID" AllowPaging="True"
                                EmptyDataText="No Member has been added." EnableModelValidation="True"
                                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                ForeColor="Black">
                                <Columns>
                                    <asp:TemplateField HeaderText="First Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFName" runat="server" Text='<%# Eval("FName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLName" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtLName" runat="server" Text='<%# Eval("LName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Des.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDes" runat="server" Text='<%# Eval("Des") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlDes" runat="server" DataTextField="DesName" DataValueField="DesId"></asp:DropDownList>
                                            <asp:Label ID="lblDes" runat="server" Text='<%# Eval("Des") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPhone" runat="server" Text='<%# Eval("Phone") %>' Width="140"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("email") %>' Width="140"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modify">
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Member ?');" CommandName="Delete"><i class="far fa-times-circle" title="Delete"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="142px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                        <div class="table-responsive">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>

                                    <th>University Name</th>
                                    <th>Campus</th>
                                    
                                    <th>Actions</th>
                                </tr>
                                <tr>

                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtLName" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" />
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnEdit" runat="server" Text="Edit" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>--%>
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
            $('#<%=ddlCountry.ClientID%>').chosen();  
            $('#<%=ddlCampus.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
             $('#<%=ddlUniv.ClientID%>').chosen();
            $('#<%=ddlStateAb.ClientID%>').chosen();
        }
    </script>
</asp:Content>
