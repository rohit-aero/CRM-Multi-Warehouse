<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmDailyQuoteReport.aspx.cs" Inherits="SalesManagement_FrmDailyQuoteReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Quote Daily Tasks</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-8">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Project#</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPNumberHeaderList" runat="server" DataTextField="PName" DataValueField="PNumber" AutoPostBack="True" OnSelectedIndexChanged="ddlPNumberHeaderList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnQuoteReport" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClick="btnQuoteReport_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Report" />
                                <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-secondary btn-sm" Enabled="true" OnClick="btnFilterForm_Click" Text="Filter Data" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-3">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Project Information</h5>
                    </div>

                    <div class="col-sm-2 chosenFullWidth">
                        <asp:Panel ID="PNumber" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                        </asp:Panel>
                        <label class="text-danger">Proposal Number*</label>
                        <asp:Panel ID="PanelN" runat="server" DefaultButton="SearchPNumberButton">
                            <asp:TextBox ID="txtSearchPNum" placeholder="Type Proposal Number" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"
                                OnBlur="return ClickEvent(event)" onkeypress="return EnterEvent(event)">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchPNum"
                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PNumber"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchPNumberOnly" CompletionListCssClass="autocomplete" />
                            <asp:Button ID="SearchPNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPNum_TextChanged" />
                        </asp:Panel>
                    </div>

                    <div class="col-sm-1 chosenFullWidth">
                        <asp:Panel ID="JobID" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                        </asp:Panel>
                        <label>JobID</label>
                        <asp:Panel ID="Panel2" runat="server" DefaultButton="SearchJobIDButton">
                            <asp:TextBox ID="txtSearchJobID" placeholder="Type JobID" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"
                                OnBlur="return ClickEventForJobID(event)" onkeypress="return EnterEventForJobID(event)">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtSearchJobID"
                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="JobID"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchJobNumberOnly" CompletionListCssClass="autocomplete" />
                            <asp:Button ID="SearchJobIDButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchJobID_TextChanged" />
                        </asp:Panel>
                    </div>

                    <div class="col-sm-5 chosenFullWidth">
                        <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;"></asp:Panel>
                        <label class="text-danger">Project Name*</label>
                        <asp:Panel ID="PanelPName" runat="server" DefaultButton="SearchPNameButton">
                            <asp:TextBox ID="txtSearchPName" placeholder="Type Proposal Name" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEventForPName(event)" onkeypress="return EnterEventForPName(event)">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchPName"
                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProposal" CompletionListCssClass="autocomplete" />
                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPName_TextChanged" />
                        </asp:Panel>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Project Manager</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtProjectManager" Enabled="false" runat="server">
                            </asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <%--<label>&nbsp;</label>--%>
                            <br />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm mt-2" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Task Information</h5>
                    </div>

                     <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Options</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOptions" runat="server" DataTextField="Option" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label class="text-danger">Nature Of Task*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNature" runat="server" DataTextField="Task" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Req. By Customer</label>
                            <asp:TextBox ID="txtReqByCustomer" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtReqByCustomer_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqByCustomer" TargetControlID="txtReqByCustomer">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Req. Fwd To Quote Team</label>
                            <asp:TextBox ID="txtReqForwardedToQuoteTeam" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtReqForwardedToQuoteTeam_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqForwardedToQuoteTeam" TargetControlID="txtReqForwardedToQuoteTeam">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Assigned To</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectEngineer" runat="server" DataTextField="FirstName" DataValueField="EmployeeID">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label class="text-danger">Priority*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPriority" runat="server">
                                <asp:ListItem Value="1">Regular</asp:ListItem>
                                <asp:ListItem Value="2">Urgent</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Quote Sent Out</label>
                            <asp:TextBox ID="txtQuoteSent" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtQuoteSent_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtQuoteSent" TargetControlID="txtQuoteSent">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" DataTextField="Status" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="500" ID="txtRemarks" runat="server" />
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblRemarksByTL">Remarks By TL</asp:Label>
                            <asp:TextBox CssClass="form-control form-control-sm mt-2" MaxLength="500" ID="txtRemarksByTL" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Task Details</h5>
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ForeColor="White" ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                                EnableModelValidation="True" ShowFooter="false" OnRowEditing="gvDetail_RowEditing" OnRowDeleting="gvDetail_RowDeleting" AllowSorting="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Option">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOption" runat="server" Text='<%# Eval("Option") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nature of Task">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTask" runat="server" Text='<%# Eval("Task") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Req by Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReqByRCD" runat="server" Text='<%# Eval("ReqByCustomer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Req. Fwd to Quote Team">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSentCAD" runat="server" Text='<%# Eval("SentQuoteRequest") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Quote Sent Out">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSentRCD" runat="server" Text='<%# Eval("SentToCustomer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Project Manager">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectManager" runat="server" Text='<%# Eval("ProjectManager") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Assigned To">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectEngineer" runat="server" Text='<%# Eval("ProjectEngineer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Remarks By TL">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarksByTL" runat="server" Text='<%# Eval("RemarksByTL") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
            <asp:HiddenField ID="HiddenID" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenDetailID" runat="server" Value="0" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnQuoteReport" />
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
            $('#<%=ddlProjectEngineer.ClientID%>').chosen();
            $('#<%=ddlPNumberHeaderList.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlOptions.ClientID%>').chosen();
            $('#<%=ddlNature.ClientID%>').chosen();
            $('#<%=ddlPriority.ClientID%>').chosen();
        }

        function EnterEvent(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=SearchPNumberButton.UniqueID%>', "");
            }
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchPNumberButton.UniqueID%>', "");
        }

        function EnterEventForPName(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
            }
        }

        function ClickEventForPName(e) {
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

        function EnterEventForJobID(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=SearchJobIDButton.UniqueID%>', "");
            }
        }

        function ClickEventForJobID(e) {
            __doPostBack('<%=SearchJobIDButton.UniqueID%>', "");
        }

    </script>
</asp:Content>
