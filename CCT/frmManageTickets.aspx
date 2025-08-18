<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmManageTickets.aspx.cs" Inherits="CCT_frmManageTickets" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col pt-2 pb-3 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Aerowerks Ticket Details</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl-9">
                        <div class="row">
                            <div class="col-sm-3 col-md-2">
                                <label class="mb-0">Ticket #</label></div>
                            <div class="col-sm-9 col-md-10">
                                <asp:DropDownList ID="ddlTicketNo" runat="server" DataValueField="RepairID" CssClass="w-100" DataTextField="TicketNo" AutoPostBack="True" OnSelectedIndexChanged="ddlTicketNo_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl">
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm btn-block" Text="Save" OnClick="btnSave_Click" /></div>
                            <div class="col-sm-6">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm btn-block" Text="Cancel" OnClick="btnCancel_Click" /></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <asp:Panel ID="PanPersonelInformation" runat="server" Enabled="false">
                    <div class="row pt-3">
                        <div class="col-12">
                            <h5 class="text-uppercase">Personal Information</h5>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Ticket#</label>
                                <asp:TextBox ID="txtTicketno" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Task</label>
                                <asp:TextBox ID="txtTask" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Issue</label>
                                <asp:TextBox ID="txtissue" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Issue Open</label>
                                <asp:TextBox ID="txtIssueOpen" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Issue Close</label>
                                <asp:TextBox ID="txtIssueClose" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Promised</label>
                                <asp:TextBox ID="txtPromised" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Follow Up</label>
                                <asp:TextBox ID="txtFollowupdate" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Status</label>
                                <asp:TextBox ID="txtStatus" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Assigned To</label>
                                <asp:TextBox ID="txtAssgnedTo" CssClass="form-control form-control-sm" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelgvInsert" runat="server" Enabled="false">
                    <div class="row border-top pt-3">
                        <div class="col-12">
                            <h5 class="text-uppercase">Add Record</h5>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>Date</label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtSummDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtSummDate" TargetControlID="txtSummDate">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>Summary</label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtSumm" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pangvSummary" runat="server">
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvSummary" runat="server" AutoGenerateColumns="False" DataKeyNames="id" EnableModelValidation="True" OnRowCancelingEdit="gvSummary_RowCancelingEdit" OnRowEditing="gvSummary_RowEditing" OnRowUpdating="gvSummary_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvSummDate" runat="server" Text='<%# Eval("SummDate") %>' OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvSummDate" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtgvSummDate" TargetControlID="txtgvSummDate">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("SummDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="200px" HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Summary">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvSumm" runat="server" Text='<%# Eval("Summary") %>' TextMode="MultiLine" Width="600px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSumm" runat="server" Text='<%# Eval("Summary") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="600px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update">Update</asp:LinkButton>
                                                &nbsp;
                                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" Wrap="True" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <asp:HiddenField ID="HfCustomerDetailid" runat="server" />
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
                    $('#<%=ddlTicketNo.ClientID%>').chosen();
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>