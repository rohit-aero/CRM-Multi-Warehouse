<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmPostInstallFollowups.aspx.cs" Inherits="CCT_FrmPostInstallFollowups" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Post Install Followups</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-6 mb-3">
                                <div class="col-sm-12 ">
                                    <label class="mb-0">From Date:</label>
                                </div>
                                <div class="col-sm-12">
                                    <asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control form-control-sm" MaxLength="10" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFromDate_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                                    </asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-sm-6 mb-3">
                                <div class="col-sm-12 ">
                                    <label class="mb-0">To Date:</label>
                                </div>
                                <div class="col-sm-12">
                                    <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control form-control-sm" MaxLength="10" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtToDate_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtToDate" TargetControlID="txtToDate">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <label class="mb-0">&nbsp;</label>
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <div class="col-sm-12 px-0 mb-3">
                            <div class="col-12">
                                <label class="mb-0">JobID/Name</label>
                            </div>
                            <div class="col-sm-12">
                                <asp:DropDownList runat="server" ID="ddlJobSearch" DataTextField="JobName" DataValueField="JobID" AutoPostBack="true" OnSelectedIndexChanged="ddlJobSearch_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Job info</h5>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Job</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtJob" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtCity" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>State</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtState" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtCountry" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Installation By</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtInstallationBy" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Installation End Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtInstallationEndDate" runat="server" autocomplete="off" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 mt-3">
                <div class="table-responsive eoeTable">
                    <asp:GridView ID="gvCustomerMember" runat="server" CellPadding="3" EmptyDataText="No Members Found !" Width="100%" CssClass="table mainGridTable table-sm"
                        AutoGenerateColumns="true" ShowFooter="false">
                    </asp:GridView>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Price and followups</h5>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Net Eq. Price</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" Enabled="false" ID="txtNetEqPrice" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Freight</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" Enabled="false" ID="txtFreight" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Installation</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" Enabled="false" ID="txtInstallation" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Ex Warranty Price</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" Enabled="false" ID="txtExWarrantyPrice" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Net Amount</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" Enabled="false" ID="txtNetAmount" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>HST</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" Enabled="false" ID="txtHST" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Total Amount</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" Enabled="false" ID="txtTotalAmount" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Models</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtModels" runat="server" autocomplete="off" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 pt-3">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvFollowup" runat="server" AutoGenerateColumns="False"
                        EnableModelValidation="True" Height="100%"
                        OnRowEditing="gvFollowup_RowEditing" OnRowUpdating="gvFollowup_RowUpdating" DataKeyNames="ID" OnRowCancelingEdit="gvFollowup_RowCancelingEdit"
                        ShowFooter="True" OnPageIndexChanging="gvFollowup_PageIndexChanging" OnRowCommand="gvFollowup_RowCommand" Style="margin-top: 0px" OnRowDeleting="gvFollowup_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Followup With" HeaderStyle-Width="8%">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowupwith" runat="server" Text='<%#Eval("FollowupWith") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFollowupwith" runat="server">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="S">Sales Rep</asp:ListItem>
                                        <asp:ListItem Value="D">Dealer</asp:ListItem>
                                        <asp:ListItem Value="C">Customer</asp:ListItem>
                                        <asp:ListItem Value="I">In House</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblFollowupwithdropdown" runat="server" Text='<%# Eval("FollowupWith") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="FddlFollowupwith" CssClass="form-control form-control-sm" runat="server" Width="100%" AutoPostBack="false" OnSelectedIndexChanged="FddlFollowupwith_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="S">Sales Rep</asp:ListItem>
                                        <asp:ListItem Value="D">Dealer</asp:ListItem>
                                       <asp:ListItem Value="C">Customer</asp:ListItem>
                                        <asp:ListItem Value="I">In House</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="FlblFollowupwith" runat="server" Width="100%" Text='<%# Eval("FollowupWith") %>' Visible="false"></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Followup Date" HeaderStyle-Width="14%">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowUpDate" runat="server" Width="100%" Text='<%#Eval("FollowupDate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFollowupDate" class="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"
                                         Width="100%" Text='<%# Eval("FollowupDate") %>'></asp:TextBox>
                                    <asp:CalendarExtender ID="CaltxtFollowupDate" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtFollowupDate" TargetControlID="txtFollowupDate">
                                    </asp:CalendarExtender>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="FtxtFollowupDate" class="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"
                                         AutoComplete="off" Width="100%"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalFtxtFollowupDate" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="FtxtFollowupDate" TargetControlID="FtxtFollowupDate">
                                    </asp:CalendarExtender>
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Scheduled Followup Date" HeaderStyle-Width="14%">
                                <ItemTemplate>
                                    <asp:Label ID="lblNextFollowUpDate" runat="server" Width="100%" Text='<%# Eval("ScheduledFollowupDate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNextFollowUpDate" class="form-control form-control-sm" onchange="nextFollowUpDate(this.id);" OnBlur="validateDate(this)" 
                                        AutoComplete="off" runat="server" Width="100%" Text='<%# Eval("ScheduledFollowupDate") %>'></asp:TextBox>
                                    <asp:CalendarExtender ID="CaltxtNextFollowedupDate" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtNextFollowUpDate" TargetControlID="txtNextFollowUpDate">
                                    </asp:CalendarExtender>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="FtxtNextFollowedUpDate" class="form-control form-control-sm" AutoComplete="off" OnBlur="validateDate(this)" 
                                        runat="server" Width="100%" onchange="nextFollowUpDate(this.id);"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalFtxtNextFollowedupDate" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="FtxtNextFollowedUpDate" TargetControlID="FtxtNextFollowedUpDate">
                                    </asp:CalendarExtender>
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Notes" ItemStyle-Width="45%">
                                <ItemTemplate>
                                    <asp:Label ID="lblNotes" runat="server" Width="100%" Text='<%# Eval("Notes") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNotes" class="form-control form-control-sm" runat="server" AutoComplete="off" Width="100%" Text='<%# Eval("Notes") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="FtxtNotes" class="form-control form-control-sm" AutoComplete="off" runat="server" Width="100%"></asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Followup Type" HeaderStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowupNature" runat="server" Text='<%#Eval("FollowupType") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFollowupNature" runat="server">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Email</asp:ListItem>
                                        <asp:ListItem Value="P">Phone</asp:ListItem>
                                        <asp:ListItem Value="T">Teams Meeting</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblFollowupNaturedropdown" runat="server" Text='<%# Eval("FollowupType") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="FddlFollowupNature" CssClass="form-control form-control-sm" runat="server" Width="100%">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="E">Email</asp:ListItem>
                                        <asp:ListItem Value="P">Phone</asp:ListItem>
                                        <asp:ListItem Value="T">Teams Meeting</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="FlblFollowupNature" runat="server" Width="100%" Text='<%# Eval("FollowupType") %>' Visible="false"></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="5%">
                                <EditItemTemplate>
                                    <asp:LinkButton CssClass="btn btn-success btn-sm" ID="LinkButton2" runat="server" CommandName="update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="LinkButton3" runat="server" CommandName="cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button CssClass="btn btn-success btn-sm rounded" ID="btnAddRecord" TabIndex="0" runat="server" Text="Add" CommandName="Insert" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm" ID="LinkButton1" runat="server" CommandName="edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                    &nbsp;&nbsp;
                                <asp:LinkButton CssClass="btn btn-info btn-danger" ID="LinkButton4" OnClientClick="return confirm('Are you sure to delete. ?');" runat="server" CommandName="delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
            $('#<%=ddlJobSearch.ClientID%>').chosen();
        }
    </script>
</asp:Content>
