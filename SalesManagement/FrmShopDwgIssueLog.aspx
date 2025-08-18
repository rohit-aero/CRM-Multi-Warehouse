<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmShopDwgIssueLog.aspx.cs" Inherits="SalesManagement_FrmShopDwgIssueLog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Shop Drawing Issue Log</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-8">
                        <div class="row">
                            <div class="col-3">
                                <div class="form-group">
                                    <label class="mb-0">Issue #&nbsp;</label>
                                    <div class="chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlIssueLookup" runat="server" DataTextField="text" DataValueField="text" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlIssueLookup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-9">
                                <div class="form-group">
                                    <label class="mb-0">Job #&nbsp;</label>
                                    <div class="chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobLookup" runat="server" DataTextField="text" DataValueField="Id" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlJobLookup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label class="mb-0">&nbsp;</label>
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm" Text="Generate Issue" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSaveMain" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSaveMain_Click" />
                                <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-secondary btn-sm" Enabled="true" OnClick="btnFilterForm_Click" Text="Filter Data" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 pt-2">
                <h5 class="text-uppercase">Issue Identification</h5>
                <div class="row">
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Issue #*</label>
                            <asp:TextBox ID="txtIssueNo" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Date Identified*</label>
                            <asp:TextBox ID="txtDateIdentified" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtDateIdentified_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtDateIdentified" TargetControlID="txtDateIdentified">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 chosenFullWidth">
                        <asp:Panel ID="JobID" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                        </asp:Panel>
                        <label class="text-danger">Job #*</label>
                        <asp:Panel ID="Panel2" runat="server" DefaultButton="SearchJobIDButton">
                            <asp:TextBox ID="txtSearchJobID" placeholder="Type JobID" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"
                                OnBlur="return ClickEventForJobID(event)" onkeypress="return EnterEventForJobID(event)">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="txtSearchJobID_Extender" runat="server" TargetControlID="txtSearchJobID"
                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="JobID"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchJobNumberOnly" CompletionListCssClass="autocomplete" />
                            <asp:Button ID="SearchJobIDButton" runat="server" Text="Submit" Style="display: none" OnClick="SearchJobIDButton_Click" />
                        </asp:Panel>
                    </div>

                    <div class="col-sm-5 chosenFullWidth">
                        <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                        </asp:Panel>
                        <label class="text-danger">Project Name*</label>
                        <asp:Panel ID="PanelPName" runat="server" DefaultButton="SearchPNameButton">
                            <asp:TextBox ID="txtSearchPName" AutoComplete="off" placeholder="Type Job Name" CssClass="form-control form-control-sm" OnBlur="return ClickEventForPName(event)" runat="server">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchPName"
                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProject" CompletionListCssClass="autocomplete" />
                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="SearchPNameButton_Click" />
                        </asp:Panel>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top pt-2">
                <h5 class="text-uppercase">Issue Details</h5>
                <div class="row">
                    <div class="col-4">
                        <div class="form-group">
                            <label class="text-danger">Issue Description*</label>
                            <asp:TextBox ID="txtIssueDescription" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-4">
                        <div class="form-group">
                            <label>Root Cause</label>
                            <asp:TextBox ID="txtRootCause" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Impact</label>
                            <asp:DropDownList ID="ddlImpact" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Category</label>
                            <asp:DropDownList ID="ddlCategory" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top pt-2">
                <h5 class="text-uppercase">Corrective Actions</h5>

                <div class="row">
                    <div class="col-4">
                        <div class="form-group">
                            <label>Intial Action Taken</label>
                            <asp:TextBox ID="txtInitialActionTaken" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-4">
                        <div class="form-group">
                            <label>Corrective Action</label>
                            <asp:TextBox ID="txtCorrectiveAction" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-4">
                        <div class="form-group">
                            <label>Preventive Action</label>
                            <asp:TextBox ID="txtPreventiveAction" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top pt-2">
                <h5 class="text-uppercase">Accountability</h5>
                <div class="row">
                    <div class="col-2">
                        <div class="form-group">
                            <label>Responsible Person</label>
                            <asp:DropDownList ID="ddlResponsiblePerson" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Verification Date</label>
                            <asp:TextBox ID="txtVerificationDate" CssClass="form-control form-control-sm" runat="server" onBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtVerificationDate_Extender" PopupButtonID="txtVerificationDate" TargetControlID="txtVerificationDate"
                                runat="server" Format="MM/dd/yyyy">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Verification Outcome</label>
                            <asp:DropDownList ID="ddlVerificationOutcome" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group srRadiosBtns">
                            <label>Followup Required</label>
                            <asp:RadioButtonList ID="rdbFollowupRequired" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdbFollowupRequired_SelectedIndexChanged">
                                <asp:ListItem Value="1" Selected>No</asp:ListItem>
                                <asp:ListItem Value="2">Yes</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Followup Date</label>
                            <asp:TextBox ID="txtFollowupDate" CssClass="form-control form-control-sm" runat="server" onBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtFollowupDate_Extender" PopupButtonID="txtFollowupDate" TargetControlID="txtFollowupDate"
                                runat="server" Format="MM/dd/yyyy">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-4">
                        <div class="form-group">
                            <label>Comments</label>
                            <asp:TextBox ID="txtComments" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-4">
                        <label>&nbsp;</label>
                        <div class="form-group">
                            <asp:Button ID="btnSaveDetail" runat="server" CssClass="btn btn-success btn-sm" Text="Save Detail" OnClick="btnSaveDetail_Click" />
                        </div>
                    </div>
                </div>

                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ForeColor="White" ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                                EnableModelValidation="True" ShowFooter="false" OnRowEditing="gvDetail_RowEditing" OnRowDeleting="gvDetail_RowDeleting" AllowSorting="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Issue Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssueDescription" runat="server" Text='<%# Eval("IssueDescription") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Impact">
                                        <ItemTemplate>
                                            <asp:Label ID="lblImpact" runat="server" Text='<%# Eval("Impact") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Verification Outcome">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVerificationOutcome" runat="server" Text='<%# Eval("VerificationOutcome") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Followup Required">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFollowupRequired" runat="server" Text='<%# Eval("FollowupRequired") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                <i class="far fa-times-circle"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfDetailId" runat="server" Value="-1" />
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
            $('#<%=ddlIssueLookup.ClientID%>').chosen();
            $('#<%=ddlJobLookup.ClientID%>').chosen();
            $('#<%=ddlImpact.ClientID%>').chosen();
            $('#<%=ddlCategory.ClientID%>').chosen();
            $('#<%=ddlResponsiblePerson.ClientID%>').chosen();
            $('#<%=ddlVerificationOutcome.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
        }

        function EnterEventForJobID(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=SearchJobIDButton.UniqueID%>', "");
            }
        }

        function ClickEventForJobID(e) {
            __doPostBack('<%=SearchJobIDButton.UniqueID%>', "");
        }

        function ClickEventForPName(e) {
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

    </script>
</asp:Content>
