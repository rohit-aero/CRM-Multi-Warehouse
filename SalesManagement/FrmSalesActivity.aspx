<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmSalesActivity.aspx.cs" Inherits="SalesManagement_FrmSalesActivity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content_SalesActivity" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SalesActivity" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Sales Activity</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-8">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group">
                                    <label>Stakeholder</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStakeHolderHeaderList" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlStakeHolderHeaderList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group">
                                    <label>Company</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompanyHeaderList" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlCompanyHeaderList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-12 border-top border-bottom">
                <div class="row">
                    <div class="col-12">
                        <h5 class="text-uppercase">Stakeholder Details</h5>
                    </div>

                    <div class="col-3">
                        <div class="form-group">
                            <label class="text-danger">Stakeholder*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStakeholder" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlStakeholder_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="form-group">
                            <label class="text-danger">Company*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompany" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-6"></div>

                    <div class="col-3">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCountry" runat="server" autocomplete="off" disabled />
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="form-group">
                            <label>State</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtState" runat="server" autocomplete="off" disabled />
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" runat="server" autocomplete="off" disabled />
                        </div>
                    </div>

                    <div class="col-6">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" runat="server" autocomplete="off" disabled />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row">
                    <div class="col-12">
                        <h5 class="text-uppercase">Activity Details</h5>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Sales Manager*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlUsers" runat="server" DataTextField="text" DataValueField="id" Enabled="false">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Date*</label>
                            <asp:TextBox ID="txtActivityDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtActivityDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtActivityDate" TargetControlID="txtActivityDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="row">
                            <label class="col-12">&nbsp;</label>
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                                <%--<asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClick="btnReport_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Report" />--%>
                                <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-secondary btn-sm" Enabled="true" OnClick="btnFilter_Click" Text="Filter Data" />
                                <asp:Button ID="btnReport" runat="server" CssClass="btn btn-primary btn-sm" Enabled="true" OnClick="btnReport_Click" Text="Report" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-9"></div>

                    <div class="col-12">
                        <div class="form-group">
                            <label class="text-danger">Objective*</label>
                            <asp:TextBox ID="txtActivityObjective" CssClass="form-control form-control-sm" TextMode="MultiLine" autocomplete="off" oninput="return limitMultiLineInputLength(this, 500)" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-12">
                        <div class="form-group">
                            <label>Outcome</label>
                            <asp:TextBox ID="txtActivityOutcome" CssClass="form-control form-control-sm" TextMode="MultiLine" autocomplete="off" oninput="return limitMultiLineInputLength(this, 500)" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm mb-2" ID="gvActivityHistory" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                        EnableModelValidation="True" OnRowCommand="gvActivityHistory_RowCommand" OnRowDataBound="gvActivityHistory_RowDataBound" OnRowDeleting="gvActivityHistory_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Sales Manager" SortExpression="SalesManager">
                                <ItemTemplate>
                                    <asp:Label ID="lblSalesManager" runat="server" Text='<%# Eval("SalesManager") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Objective" SortExpression="Objective">
                                <ItemTemplate>
                                    <asp:Label ID="lblObjective" runat="server" Text='<%# Eval("Objective") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Outcome" SortExpression="Outcome">
                                <ItemTemplate>
                                    <asp:Label ID="lbloutcome" runat="server" Text='<%# Eval("Outcome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Modify" ItemStyle-Width="45%">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Edit Activity" CommandName="EditActivity" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'></asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="View/Add Followups" CommandName="Followup" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'></asp:LinkButton>
                                    <asp:LinkButton ID="btnTravelLogs" runat="server" CssClass="btn btn-outline-success btn-sm" Text="View/Add Travel Logs" CommandName="TravelLogs" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'></asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                Delete Activity
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <asp:LinkButton ID="btnFollowup" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="Modal_Followup" runat="server" TargetControlID="btnFollowup"
                PopupControlID="Panel_Followup" BackgroundCssClass="modalBackground" CancelControlID="btnCloseFollowup">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel_Followup" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="80%" Height="80%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnCloseFollowup" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-auto h-100">
                        <div class="col-12">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <h5 class="text-uppercase ">Activity:-
                                        <asp:Label ID="lblActivity" runat="server"></asp:Label>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-3">
                                    <div class="form-group">
                                        <label class="text-danger">Date*</label>
                                        <asp:TextBox ID="txtFollowupDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                        </asp:TextBox>
                                        <asp:CalendarExtender ID="txtFollowupDate_Extender" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtFollowupDate" TargetControlID="txtFollowupDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                        <label class="text-danger">Task(Reason of Contact)*</label>
                                        <asp:TextBox ID="txtTask" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" autocomplete="off" oninput="return limitMultiLineInputLength(this, 500)">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-group chosenFullWidth">
                                        <label class="text-danger">Type of Contact*</label>
                                        <asp:DropDownList ID="ddlTypeOfContact" runat="server" CssClass="form-control form-control-sm">
                                            <asp:ListItem Value="">Select</asp:ListItem>
                                            <asp:ListItem Value="T">Teams Meeting</asp:ListItem>
                                            <asp:ListItem Value="P">Phone Call</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-group chosenFullWidth">
                                        <label>PNumber #</label>
                                        <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                            <asp:Panel ID="PNumber" runat="server" CssClass="form-control form-control-sm" Style="height: 200px; overflow: scroll; display: none;"></asp:Panel>
                                            <div class="col-sm chosenFullWidth pl-0">
                                                <asp:Panel ID="Panel_PNumber" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                                </asp:Panel>
                                                <asp:Panel ID="Panel_PNumberAutoComplete" runat="server">
                                                    <asp:TextBox ID="txtPNumber" AutoComplete="off" placeholder="Type PNumber #" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEvent(event)" onkeypress="return EnterEvent(event)">
                                                    </asp:TextBox>
                                                    <asp:AutoCompleteExtender ID="PNumber_AutoComplete" runat="server" TargetControlID="txtPNumber"
                                                        CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="Panel_PNumber"
                                                        ServicePath="../AutoComplete.asmx" ServiceMethod="SearchPNumberOnly" CompletionListCssClass="autocomplete" />
                                                    <asp:Button ID="SearchPNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="SearchPNumberButton_Click" />
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                        <label>Project Name</label>
                                        <asp:TextBox ID="txtProjectName" CssClass="form-control form-control-sm" autocomplete="off" runat="server" MaxLength="250">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-group chosenFullWidth">
                                        <label class="text-danger">Contact Person*</label>
                                        <asp:DropDownList ID="ddlResponsiblePerson" runat="server" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                        <label>Action Required</label>
                                        <asp:TextBox ID="txtDeadline" CssClass="form-control form-control-sm" autocomplete="off" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                        <label>Regional Industry Updates</label>
                                        <asp:TextBox ID="txtRegionalIndustryUpdates" CssClass="form-control form-control-sm" autocomplete="off" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-group chosenFullWidth">
                                        <label class="text-danger">Status*</label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-3">
                                    <div class="form-group">
                                        <label>Next Followup Date</label>
                                        <asp:TextBox ID="txtNextFollowupDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                        </asp:TextBox>
                                        <asp:CalendarExtender ID="txtNextFollowupDate_Extender" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtNextFollowupDate" TargetControlID="txtNextFollowupDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
                                        <asp:Button ID="btnAddFollowup" runat="server" CssClass="btn btn-primary btn-sm" Text="Add" OnClick="btnAddFollowup_Click" />
                                        <asp:Button ID="btnCancelFollowup" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancelFollowup_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 border-top" id="divFollowupSection" runat="server">
                                <div class="row">
                                    <%--<div class="col-12">--%>
                                    <h5 class="text-uppercase">Followup Details</h5>
                                    <%--</div>--%>

                                    <%--<div class="col-12">--%>
                                    <div class="table-responsive">
                                        <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvFollowups" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                            EnableModelValidation="True" OnRowCommand="gvFollowups_RowCommand" OnRowDeleting="gvFollowups_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFollowupDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Task(Reason of Contact)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTask" runat="server" Text='<%# Eval("Task") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Contact Person">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblResponsiblePerson" runat="server" Text='<%# Eval("ResponsiblePerson") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Action Required">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDeadline" runat="server" Text='<%# Eval("Deadline") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Modify">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Edit" CommandName="EditFollowup" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'>Edit</asp:LinkButton>
                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <%--</div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:LinkButton ID="btnTravelLog" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="Modal_TravelLogs" runat="server" TargetControlID="btnTravelLog"
                PopupControlID="Panel_TravelLogs" BackgroundCssClass="modalBackground" CancelControlID="btnCloseTravelLogs">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel_TravelLogs" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="80%" Height="80%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnCloseTravelLogs" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-auto h-100">
                        <div class="col-12">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <h5 class="text-uppercase ">Activity:- 
                                      <asp:Label ID="lblTask" runat="server"></asp:Label></h5>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-3">
                                    <div class="form-group">
                                        <label class="text-danger">Date*</label>
                                        <asp:TextBox ID="txtTravelDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                        </asp:TextBox>
                                        <asp:CalendarExtender ID="txtTravelDate_Extender" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtTravelDate" TargetControlID="txtTravelDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                        <label class="text-danger">Destination*</label>
                                        <asp:TextBox ID="txtDestination" CssClass="form-control form-control-sm" runat="server" autocomplete="off" MaxLength="50">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-5">
                                    <div class="form-group chosenFullWidth">
                                        <label class="text-danger">Purpose*</label>
                                        <asp:TextBox ID="txtPurpose" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" autocomplete="off" oninput="return limitMultiLineInputLength(this, 500)">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-5">
                                    <div class="form-group chosenFullWidth">
                                        <label>Outcome</label>
                                        <asp:TextBox ID="txtOutcome" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" autocomplete="off" oninput="return limitMultiLineInputLength(this, 500)">
                                        </asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
                                        <asp:Button ID="btnAddTravelLog" runat="server" CssClass="btn btn-primary btn-sm" Text="Add" OnClick="btnAddTravelLog_Click" />
                                        <asp:Button ID="btnCancelTravellog" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancelTravelLog_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-12 border-top" id="divTravelLogSection" runat="server">
                                <div class="row">
                                    <%--<div class="col-12">--%>
                                    <h5 class="text-uppercase">Travel Logs Details</h5>
                                    <%--</div>--%>

                                    <%--<div class="col-12 mx-auto">--%>
                                    <div class="table-responsive">
                                        <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvTravelLogs" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                            EnableModelValidation="True" OnRowCommand="gvTravelLogs_RowCommand" OnRowDeleting="gvTravelLogs_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTravelDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Destination">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("Destination") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Purpose">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPurpose" runat="server" Text='<%# Eval("Purpose") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Outcome">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTravelOutcome" runat="server" Text='<%# Eval("Outcome") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Modify">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Edit" CommandName="EditTravel" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'></asp:LinkButton>
                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <%--</div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hfPermission" runat="server" Value="-1" />
            <asp:HiddenField ID="hfActivityDetailId" runat="server" Value="-1" />
            <asp:HiddenField ID="hfFollowupId" runat="server" Value="-1" />
            <asp:HiddenField ID="hfTravelLogId" runat="server" Value="-1" />
        </ContentTemplate>
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
        </Triggers>--%>
    </asp:UpdatePanel>
    <%--<CR:CrystalReportViewer ID="rprtSalesActivity" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />--%>
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
            $('#<%=ddlStakeHolderHeaderList.ClientID%>').chosen();
            $('#<%=ddlResponsiblePerson.ClientID%>').chosen();
            $('#<%=ddlCompanyHeaderList.ClientID%>').chosen();
            $('#<%=ddlTypeOfContact.ClientID%>').chosen();
            $('#<%=ddlStakeholder.ClientID%>').chosen();
            $('#<%=ddlCompany.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlUsers.ClientID%>').chosen();
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchPNumberButton.UniqueID%>', "");
        }

        function EnterEvent(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=SearchPNumberButton.UniqueID%>', "");
            }
        }
    </script>
</asp:Content>
