<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmManageReps.aspx.cs" Inherits="ContactManagement_FrmManageReps" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Active Sales</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-7 col-lg-7 col-xl">
                        <div class="row">
                            <div class="col-2">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">Business Division</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:DropDownList ID="ddlProductLineHeaderList" CssClass="form-control form-control-sm" runat="server" DataTextField="Name" DataValueField="Id"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlProductLineHeaderList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-3">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">Rep Group</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:DropDownList ID="ddlRepGroupHeaderList" CssClass="form-control form-control-sm" runat="server"
                                            DataTextField="Name" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="ddlRepGroupHeaderList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-3">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">Branch</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlBranchHeaderList" runat="server" DataTextField="Branch" DataValueField="BranchID" AutoPostBack="True" OnSelectedIndexChanged="ddlBranchHeaderList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-2">
                                <div class="row">
                                    <div class="col-12 mb-3">
                                        <label class="mb-0">Rep</label>
                                    </div>
                                    <div class="col-12 mb-3">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRepHeaderList" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlRepHeaderList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-2">
                                <div class="row">
                                    <div class="row">
                                        <div class="col-12 mb-3">
                                            <label class="mb-0">&nbsp;</label>
                                        </div>
                                        <div class="col-12 mb-3">
                                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Visible="false" />
                                            <%--   <button runat="server" id="btnAddEmployee" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#AddEmployee" data-backdrop="static" data-keyboard="false" href="#" type="button">
                                    Add
                                </button>--%>
                                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnModalOpener" Enabled="false" runat="server" Text="Add Rep" OnClick="btnOpenModal" />
                                            <%--<asp:Button ID="btnProposals" runat="server" CssClass="btn btn-info btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Related Proposals" Visible="false" Enabled="false" OnClick="btnProposals_Click" />
                                <asp:Button ID="btnProjects" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Related Projects" Visible="false" Enabled="false" OnClick="btnProjects_Click" />--%>
                                            <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <%--<div class="row pt-3">
                    <div class="col-12"></div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Company Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Branch Location</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtBranchLocation" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Branch Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtBranchName" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Street Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtStrAddress" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>--%>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <%--<div class="table-responsive">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <th>First Name*</th>
                                    <th>Last Name*</th>
                                    <th>Abbreviation*</th>
                                    <th>Phone</th>
                                    <th>Email</th>
                                    <th>Status*</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                       
                                </tr>
                            </table>
                        </div>--%>
                        <%--            <button type="button" id="closeAddEmployee" style="display: none" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>--%>
                        <%--<div class="modal fade" id="AddEmployee" tabindex="-1" aria-labelledby="EmployeeAddLabel" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-scrollable modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <asp:Label runat="server" class="modal-title h5 text-uppercase" ID="Label1"></asp:Label>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="modal-body ul-model-info">
                                                <div class="table-responsive">
                                                    <div class="row w-100">
                                                        <div class="col-6 d-flex flex-column">
                                                            <label>First Name*</label>
                                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFirstName" MaxLength="30" autocomplete="off" runat="server" />
                                                        </div>
                                                        <div class="col-6 d-flex flex-column">
                                                            <label>Last Name*</label>
                                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtLastName" MaxLength="30" autocomplete="off" runat="server" />
                                                        </div>
                                                        <div class="col-6 d-flex flex-column">
                                                            <label>Abbreviation*</label>
                                                            <asp:DropDownList ID="ddlAbbreviationAddList" CssClass="form-control form-control-sm" DataTextField="AbbreviationName" DataValueField="AbbreviationID" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-6 d-flex flex-column">
                                                            <label>Phone</label>
                                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" MaxLength="25" autocomplete="off" runat="server" />
                                                        </div>
                                                        <div class="col-6 d-flex flex-column">
                                                            <label>Email</label>
                                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" runat="server" MaxLength="40" autocomplete="off" />
                                                        </div>
                                                        <div class="col-6 d-flex flex-column">
                                                            <label>Status*</label>
                                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatusAddList" runat="server">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                                <asp:ListItem Value="Active">Active</asp:ListItem>
                                                                <asp:ListItem Value="Quit">Quit</asp:ListItem>
                                                                <asp:ListItem Value="Retired">Retired</asp:ListItem>
                                                                <asp:ListItem Value="Temp. Leave">Temp. Leave</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add Rep" OnClick="btnAdd_Click" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>--%>
                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnModalOpener"
                            PopupControlID="Panel1" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="Panel1" runat="server" CssClass="AddRepModal bg-white" Style="display: none" Width="40%" Height="50%">
                            <div class="position-relative h-100">
                                <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                                    AlternateText="Close Popup" ToolTip="Close Popup" />
                                <div class="modal-body ul-model-info">
                                    <div class="table-responsive">
                                        <div class="row w-100">
                                            <div class="col-6 d-flex flex-column">
                                                <label class="text-danger">First Name*</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtFirstName" MaxLength="30" autocomplete="off" runat="server" />
                                            </div>
                                            <div class="col-6 d-flex flex-column">
                                                <label class="text-danger">Last Name*</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtLastName" MaxLength="30" autocomplete="off" runat="server" />
                                            </div>
                                            <div class="col-6 d-flex flex-column">
                                                <label class="text-danger">Abbreviation*</label>
                                                <asp:DropDownList ID="ddlAbbreviationAddList" CssClass="form-control form-control-sm" DataTextField="AbbreviationName" DataValueField="AbbreviationID" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-6 d-flex flex-column">
                                                <label>Phone</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" onblur="phoneMask(this)" MaxLength="25" autocomplete="off" runat="server" />
                                            </div>
                                            <div class="col-6 d-flex flex-column">
                                                <label>Email</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" oninput="emailMask(this)" runat="server" MaxLength="40" autocomplete="off" />
                                            </div>
                                            <div class="col-6 d-flex flex-column">
                                                <label class="text-danger">Status*</label>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatusAddList" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem Value="Active">Active</asp:ListItem>
                                                    <asp:ListItem Value="Quit">Quit</asp:ListItem>
                                                    <asp:ListItem Value="Retired">Retired</asp:ListItem>
                                                    <asp:ListItem Value="Temp. Leave">Temp. Leave</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="modal-footer">
                                    <asp:Button CssClass="btn btn-success btn-sm rounded" ID="btnAdd" runat="server" Text="Add Rep" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                        </asp:Panel>

                        <div class="table-responsive">
                            <asp:Panel ID="pangvSalesRep" runat="server">
                                <div class="table-responsive">
                                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvSalesRep" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="ID"
                                        OnRowDeleting="gvSalesRep_RowDeleting" EnableModelValidation="True"
                                        OnPageIndexChanging="gvSalesRep_PageIndexChanging" OnRowEditing="gvSalesRep_RowEditing" OnRowUpdating="gvSalesRep_RowUpdating"
                                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                        ForeColor="Black" OnRowCancelingEdit="gvSalesRep_RowCancelingEdit" OnRowCommand="gvSalesRep_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="First Name*">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtFirstName" MaxLength="50" runat="server" autocomplete="off" Text='<%# Eval("FirstName") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle />
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Last Name*">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtLastName" MaxLength="50" runat="server" autocomplete="off" Text='<%# Eval("LastName") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle />
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Abbreviation*">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAbbreviation" runat="server" Text='<%# Eval("Abbreviation") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlAbbreviation" CssClass="form-control form-control-sm" DataTextField="AbbreviationName" DataValueField="AbbreviationID" runat="server"></asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemStyle />
                                                <ItemStyle Width="14%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Phone">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtPhone" MaxLength="25" onblur="phoneMask(this)" runat="server" autocomplete="off" Text='<%# Eval("Phone") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle />
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEmail" MaxLength="50" oninput="emailMask(this)" runat="server" autocomplete="off" Text='<%# Eval("Email") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle />
                                                <ItemStyle Width="14%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status*">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem Value="Active">Active</asp:ListItem>
                                                        <asp:ListItem Value="Quit">Quit</asp:ListItem>
                                                        <asp:ListItem Value="Retired">Retired</asp:ListItem>
                                                        <asp:ListItem Value="Temp. Leave">Temp. Leave</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemStyle />
                                                <ItemStyle Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Modify">
                                                <EditItemTemplate>
                                                    <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit">
                                                <i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Rep ?');" CommandName="Delete"><i class="far fa-times-circle" title="Delete"></i></asp:LinkButton>
                                                    <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnProposals" runat="server" Text="Proposals" title="Proposals" CommandName="Proposal">
                                                <i class="far fa-file-powerpoint"></i>
                                                    </asp:LinkButton>
                                                    <asp:LinkButton CssClass="btn btn-primary btn-sm" ID="btnProjects" runat="server" CausesValidation="false" Text="Projects" title="Projects" CommandName="Project">
                                            <i class="fas fa-file-powerpoint"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="p-1" hidden>
                            <button runat="server" id="proposalAndProjectDialogButton" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#proposalAndProjectDialog" data-backdrop="static" data-keyboard="false" href="#" type="button">
                            </button>
                        </div>
                        <!-- Modal -->
                    </div>
                </div>
            </div>
            <div class="modal fade" id="proposalAndProjectDialog" tabindex="-1" aria-labelledby="ProposalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-scrollable modal-xl">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label runat="server" class="modal-title h5 text-uppercase" ID="ModalLabelHeader"></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body ul-model-info">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm" ID="gvProposalAndProjectPopUpData" runat="server"
                                    EmptyDataText="No Proposals" AutoGenerateColumns="true"
                                    BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                    ForeColor="Black">
                                </asp:GridView>
                            </div>
                            <input type="hidden" id="Hidden1" runat="server" value="" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });
        function PageLoaded(sender, args) {
            DDL();
        }
        $.when.apply($, PageLoaded).then(function () {
            DDL();
        });
        function DDL() {
            $('#<%=ddlRepGroupHeaderList.ClientID%>').chosen();
            $('#<%=ddlProductLineHeaderList.ClientID%>').chosen();
            $('#<%=ddlBranchHeaderList.ClientID%>').chosen();
            $('#<%=ddlRepHeaderList.ClientID%>').chosen();
<%--            $('#<%=ddlAbbreviationAddList.ClientID%>').chosen();
            $('#<%=ddlStatusAddList.ClientID%>').chosen();--%>
        }

        function openModal() {
            var clickButton = document.getElementById("<%= proposalAndProjectDialogButton.ClientID %>");
            clickButton.click();
        }

        function closeModal() {
            var clickButton = document.getElementById("closeAddEmployee");
            clickButton.click();
        }
    </script>
</asp:Content>
