<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmCustomers.aspx.cs" Inherits="ContactManagement_FrmCustomers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <asp:HiddenField ID="hfJobDetails" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Customer Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Customer Name</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3">
                                <div class="col-sm chosenFullWidth pl-0">
                                    <asp:Panel ID="Panel_Customer" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                    </asp:Panel>
                                    <asp:Panel ID="Panel_Customer_1" runat="server" DefaultButton="Customer_AutoCompleteButton">
                                        <asp:TextBox ID="txtCustomer" AutoComplete="off" placeholder="Type Customer Name" CssClass="form-control form-control-sm" OnBlur="return ClickEventForCustomer(event)" runat="server">
                                        </asp:TextBox>
                                        <asp:AutoCompleteExtender ID="Customer_AutoCompleteExtender" runat="server" TargetControlID="txtCustomer"
                                            CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="Panel_Customer"
                                            ServicePath="../AutoComplete.asmx" ServiceMethod="SearchCustomer" CompletionListCssClass="autocomplete" />
                                        <asp:Button ID="Customer_AutoCompleteButton" runat="server" Text="Submit" Style="display: none" OnClick="ddlCustomer_SelectedIndexChanged" />
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click" OnClientClick="return confirm('Are you sure.?');" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:Button CssClass="btn btn-secondary btn-sm" ID="btnBack" runat="server" Text="Project Page" Enabled="false" OnClick="btnBack_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Customer Details</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Company*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyName" AutoComplete="off" runat="server" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Main Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtMainPhone" onblur="phoneMask(this)" AutoComplete="off" MaxLength="25" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Business Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlBusinessType" runat="server" DataTextField="Desc" DataValueField="Desc"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Site Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" AutoComplete="off" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <%-- <div class="col-sm-6 col-md-3">
                    <div class="form-group">
                        <label>Main Fax</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtMainFax" AutoComplete="off" MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3">
                    <div class="form-group">
                        <label>References</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtRef" AutoComplete="off" MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                </div>                    
                <div class="col-sm-6 col-md-3">
                    <div class="form-group">
                        <label>Toll Free</label>
                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtTollFree" AutoComplete="off" MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3">
                    <div class="form-group">
                        <label>Toll Fax</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTollFax" AutoComplete="off" MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                </div>--%>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Country" DataValueField="CountryID" ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>State</label>
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" DataValueField="StateID" DataTextField="State" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                </asp:DropDownList>
                                <div class="input-group-prepend pl-1">
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStateAb" DataValueField="StateID" DataTextField="Sabb" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStateAb_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" AutoComplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Zip Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtZipCode" AutoComplete="off" MaxLength="15" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Representative</h5>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label>Sales Rep</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSales" runat="server" DataTextField="Name" DataValueField="RepID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label>Service Rep</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlServiceRep" runat="server" DataTextField="Branch" DataValueField="ServiceRepID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox ID="txtSiteAddress" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="250" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label>Memo</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtMemo" runat="server" Height="80px" AutoComplete="off" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Contact Details</h5>
                    </div>
                    <div class="col-12">
                        <strong class="text-center">
                            <asp:Label CssClass="d-block py-1" ID="lblMsg" runat="server"></asp:Label></strong>
                    </div>
                    <div class="col-12">
                        <div class="table-responsive">
                            <asp:GridView ID="gvMember" CssClass="table mainGridTable table-sm" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="ContactID" AllowPaging="True"
                                EmptyDataText="No Member has been added." OnRowDeleting="gvMember_RowDeleting" EnableModelValidation="True"
                                OnPageIndexChanging="gvMember_PageIndexChanging" OnRowEditing="gvMember_RowEditing" OnRowUpdating="gvMember_RowUpdating"
                                OnRowCancelingEdit="gvMember_RowCancelingEdit">
                                <Columns>
                                    <asp:TemplateField HeaderText="Position*">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <%-- <asp:DropDownList ID="ddlTitleIn" runat="server" DataTextField="Title" DataValueField="Title"></asp:DropDownList>--%>
                                            <asp:TextBox ID="txtTitleIn" MaxLength="35" runat="server" autocomplete="off" Text='<%# Eval("Title") %>'></asp:TextBox>
                                            <asp:Label ID="lblTitleIn" runat="server" Text='<%# Eval("Title") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name*">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFName" runat="server" Text='<%# Eval("FName") %>' MaxLength="30" AutoComplete="off"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLName" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtLName" runat="server" MaxLength="30" Text='<%# Eval("LName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cell Phone">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPhone" onblur="phoneMask(this)" runat="server" MaxLength="25" Text='<%# Eval("Phone") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Office Phone">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOfficePhone" runat="server" Text='<%# Eval("OfficePhone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOfficePhone" runat="server" onblur="phoneMask(this)" MaxLength="25" Text='<%# Eval("OfficePhone") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEmail" runat="server" oninput="emailMask(this)" MaxLength="50" Text='<%# Eval("email") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Reference">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkRefN" Checked='<%# Eval("ReferenceContact") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkRef" Checked='<%# Eval("ReferenceContact") %>' runat="server" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Main">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkMainN" Checked='<%# Eval("MainContact") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkMain" Checked='<%# Eval("MainContact") %>' runat="server" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modify" ItemStyle-Width="100">
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Member ?');" CommandName="Delete"><i class="far fa-times-circle" title="Delete"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle />
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
                            <table cellpadding="0" cellspacing="0" class="table mainGridTable table-sm" border="1">
                                <tr>
                                    <th>Position*</th>
                                    <th>First Name*</th>
                                    <th>Last Name</th>
                                    <th>Cell Phone</th>
                                    <th>Office Phone</th>
                                    <th>Email</th>
                                    <th>Contact Reference</th>
                                    <th>Main</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtTitle" MaxLength="35" AutoComplete="off" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFName" MaxLength="30" AutoComplete="off" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtLName" MaxLength="30" AutoComplete="off" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" onblur="phoneMask(this)" MaxLength="25" AutoComplete="off" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtOfficePhone" onblur="phoneMask(this)" MaxLength="25" AutoComplete="off" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" oninput="emailMask(this)" MaxLength="50" AutoComplete="off" runat="server" /></td>
                                    <td>
                                        <asp:CheckBox ID="chkRef" runat="server" /></td>
                                    <td>
                                        <asp:CheckBox ID="chkMain" runat="server" /></td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddMember" runat="server" Text="Add Contact" OnClientClick="return confirm('Are you sure.?');" OnClick="btnAddMember_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>            
            <asp:HiddenField ID="HfCustomerID" runat="server" Value="-1" />
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
            $('#<%=ddlBusinessType.ClientID%>').chosen();
            $('#<%=ddlSales.ClientID%>').chosen();
            $('#<%=ddlServiceRep.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlStateAb.ClientID%>').chosen();
        }

        function ClickEventForCustomer(e) {
            __doPostBack('<%=Customer_AutoCompleteButton.UniqueID%>', "");
        }

        <%--function EnterEventForCustomer(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=Customer_AutoCompleteButton.UniqueID%>', "");
            }
        }--%>
    </script>
</asp:Content>
