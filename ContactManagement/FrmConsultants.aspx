<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true"
    CodeFile="FrmConsultants.aspx.cs" Inherits="ContactManagement_FrmConsultants" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Consultant Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Consultant</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConsultant" runat="server"
                                    DataTextField="CompanyName" DataValueField="ConsultantID" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlConsultant_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnProposals" runat="server" CssClass="btn btn-info btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Related Proposals" Enabled="false" OnClick="btnProposals_Click" />
                                <asp:Button ID="btnProjects" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Related Projects" Enabled="false" OnClick="btnProjects_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
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
                        <h5 class="text-uppercase">Consultant Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Company Name*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyName" autocomplete="off" MaxLength="100" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" autocomplete="off" MaxLength="250" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Country*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Country" DataValueField="CountryID" ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">State*</label>
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
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtZipCode" autocomplete="off" MaxLength="10" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" onblur="phoneMask(this)" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Toll Free</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTollFree" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Fax</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFax" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Food Preference</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFoodPref" runat="server"
                                DataTextField="FoodType" DataValueField="FoodId">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Nature of Consultant</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlnatureConsul" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="R">Rigid</asp:ListItem>
                                <asp:ListItem Value="F">Flexible</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Sales Rep</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesRep" runat="server"
                                DataTextField="Name" DataValueField="RepID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Preferred Vendor 1</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPrefVendor1" runat="server"
                                DataTextField="CompetitorName" DataValueField="CompetitorID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Preferred Vendor 2</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPrefVendor2" runat="server"
                                DataTextField="CompetitorName" DataValueField="CompetitorID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Preferred Vendor 3</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPrefVendor3" runat="server"
                                DataTextField="CompetitorName" DataValueField="CompetitorID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Preferences</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtConsPref" autocomplete="off"
                                MaxLength="250" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="2">In-Active</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Email Attachment</label>
                            <asp:FileUpload ID="fpUpload" CssClass="btn btn-success btn-sm btn-block" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label class="col-12">&nbsp;</label>
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" Text="Delete" CausesValidation="false" Enabled="false" OnClick="btnDelete_Click" />
                            <asp:LinkButton ID="lnkAttachment" runat="server" CssClass="btn btn-primary btn-sm" Visible="false" OnClick="lnkAttachment_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Contact Details</h5>
                    </div>
                    <div class="col-12">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvMember" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="ConsultantMemberID" AllowPaging="True"
                                EmptyDataText="No Member has been added." OnRowDeleting="gvMember_RowDeleting" EnableModelValidation="True"
                                OnPageIndexChanging="gvMember_PageIndexChanging" OnRowEditing="gvMember_RowEditing" OnRowUpdating="gvMember_RowUpdating"
                                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" CellSpacing="0"
                                ForeColor="Black" OnRowCancelingEdit="gvMember_RowCancelingEdit">
                                <Columns>
                                    <asp:TemplateField HeaderText="First Name*">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFName" runat="server" Text='<%# Eval("FirstName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtLName" runat="server" Text='<%# Eval("LastName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Job Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("JobTitle") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("JobTitle") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Extension">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExtension" runat="server" Text='<%# Eval("TelephoneExtension") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtExtension" runat="server" Text='<%# Eval("TelephoneExtension") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Direct Line">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDirect" runat="server" MaxLength="50" onblur="phoneMask(this)" Text='<%# Eval("DirectLine") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDirect" runat="server" MaxLength="50" Text='<%# Eval("DirectLine") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server"  Text='<%# Eval("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEmail" runat="server" oninput="emailMask(this)" Text='<%# Eval("Email") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
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
                            <table border="1" cellpadding="0" cellspacing="0" class="table mainGridTable table-sm">
                                <tr>
                                    <th>First Name*</th>
                                    <th>Last Name</th>
                                    <th>Job Title</th>
                                    <th>Extension</th>
                                    <th>Direct Line</th>
                                    <th>Email</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFName" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtLName" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtJobTitle" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtExten" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtDirectLine" onblur="phoneMask(this)" MaxLength="50" runat="server" /></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" oninput="emailMask(this)" runat="server" /></td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddMember" runat="server" Text="Add Contact" OnClick="btnAddMember_Click" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="Hfemailpath" runat="server" />
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkAttachment" />
            <asp:PostBackTrigger ControlID="btnDelete"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnSave"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnProjects"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnProposals"></asp:PostBackTrigger>
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
            $('#<%=ddlConsultant.ClientID%>').chosen();
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlFoodPref.ClientID%>').chosen();
            $('#<%=ddlnatureConsul.ClientID%>').chosen();
            $('#<%=ddlnatureConsul.ClientID%>').chosen();
            $('#<%=ddlPrefVendor1.ClientID%>').chosen();
            $('#<%=ddlPrefVendor2.ClientID%>').chosen();
            $('#<%=ddlPrefVendor3.ClientID%>').chosen();
            $('#<%=ddlSalesRep.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlStateAb.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>
