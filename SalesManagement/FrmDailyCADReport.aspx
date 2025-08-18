<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmDailyCADReport.aspx.cs" Inherits="SalesManagement_DailyCADReport" %>

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
                            <h4 class="title-hyphen position-relative">CAD Daily Tasks</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-8">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3" style="display: none">
                                <label class="mb-0">Lookup Report Date #</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth" style="display: none">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReportDateHeaderList" runat="server" DataTextField="ReportDate" DataValueField="ReportDate" AutoPostBack="True" OnSelectedIndexChanged="ddlReportDateHeaderList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
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
                                <asp:Button ID="btnCADReport" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClick="btnCADReport_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Report" />
                                <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-secondary btn-sm" Enabled="true" OnClick="btnFilterForm_Click" Text="Filter Data" />
                            </div>
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
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
                    <div class="col-sm-2 " style="display: none;">
                        <div class="form-group">
                            <label class="text-danger">PNumber*</label>
                            <%--<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPNumber" runat="server" DataTextField="PNumber" DataValueField="PNumber" AutoPostBack="true" OnSelectedIndexChanged="syncPNumberDropdown_SelectedIndexChanged">
                            </asp:DropDownList>--%>
                        </div>
                    </div>
                    <div class="col-sm-4 " style="display: none;">
                        <div class="form-group">
                            <label class="text-danger">Project Description/Job Number*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectDesc" runat="server" DataTextField="PName" DataValueField="PNumber" AutoPostBack="true" OnSelectedIndexChanged="syncProjectDesc_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm chosenFullWidth">
                        <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;"></asp:Panel>
                        <label>Project Name</label>
                        <asp:Panel ID="PanelPName" runat="server" DefaultButton="SearchPNameButton">
                            <asp:TextBox ID="txtSearchPName" placeholder="Type Proposal Name" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEventForPName(event)" onkeypress="return EnterEventForPName(event)">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchPName"
                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProposal" CompletionListCssClass="autocomplete" />
                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPName_TextChanged" />
                        </asp:Panel>
                    </div>
                    <div class="col-sm-2 chosenFullWidth">
                        <asp:Panel ID="PNumber" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                        </asp:Panel>
                        <label>Proposal Number</label>
                        <asp:Panel ID="PanelN" runat="server" DefaultButton="SearchPNumberButton">
                            <asp:TextBox ID="txtSearchPNum" placeholder="Type Proposal Number" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEvent(event)" onkeypress="return EnterEvent(event)">
                            </asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchPNum"
                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PNumber"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchPNumberOnly" CompletionListCssClass="autocomplete" />
                            <asp:Button ID="SearchPNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPNum_TextChanged" />
                        </asp:Panel>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Project Manager</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtProjectManager" Enabled="false" runat="server">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <%--  <label>Save/Update</label>--%>
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
                    <div class="col-sm-2" style="display: none;">
                        <div class="form-group">
                            <label class="text-danger">Report Date*</label>
                            <asp:TextBox ID="txtReportDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReportDate" TargetControlID="txtReportDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label class="text-danger">Nature Of Task*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNature" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNature_SelectedIndexChanged" DataTextField="Task" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Revision</label>
                            <asp:TextBox CssClass="form-control form-control-sm" MaxLength="15" ID="txtCorrection" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Req. By Customer</label>
                            <asp:TextBox ID="txtReqByRCD" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqByRCD" TargetControlID="txtReqByRCD">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Req. Fwd To CAD Team</label>
                            <asp:TextBox ID="txtReqForwardedToIndia" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqForwardedToIndia" TargetControlID="txtReqForwardedToIndia">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Project Engineer</label>
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
                            <label>Date Project Sent To Customer</label>
                            <asp:TextBox ID="txtProjectSendToRCD" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtProjectSendToRCD" TargetControlID="txtProjectSendToRCD">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" DataTextField="Status" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Progress*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProgress" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlProgress_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="NS">Not Started</asp:ListItem>
                                <asp:ListItem Value="10%">10%</asp:ListItem>
                                <asp:ListItem Value="20%">20%</asp:ListItem>
                                <asp:ListItem Value="30%">30%</asp:ListItem>
                                <asp:ListItem Value="40%">40%</asp:ListItem>
                                <asp:ListItem Value="50%">50%</asp:ListItem>
                                <asp:ListItem Value="60%">60%</asp:ListItem>
                                <asp:ListItem Value="70%">70%</asp:ListItem>
                                <asp:ListItem Value="80%">80%</asp:ListItem>
                                <asp:ListItem Value="90%">90%</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblComments">Remarks By Assignee</asp:Label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="500" ID="txtComments" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-4" style="display: none;">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label1">Remarks By Engineer</asp:Label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="500" ID="txtCommentsByEngineer" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <asp:Label ID="lblRemarks" runat="server">Project Manager Comments</asp:Label>
                            <asp:TextBox CssClass="form-control form-control-sm" MaxLength="500" ID="txtRemarks" runat="server" />
                        </div>
                    </div>
                    <%--<div class="col-sm-2 ">
                        <div class="form-group mt-5">
                            <label>Is Urgent&nbsp;</label>
                            <asp:CheckBox ID="chkIsUrgent" runat="server" />
                        </div>
                    </div>--%>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Task Details</h5>
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ForeColor="White" ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                                EnableModelValidation="True" ShowFooter="false" OnRowEditing="gvDetail_RowEditing" OnRowDeleting="gvDetail_RowDeleting" AllowSorting="true"
                                OnSorting="gvDetail_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Report Date" SortExpression="ReportDate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReportDate" runat="server" Text='<%# Eval("ReportDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="P Number" SortExpression="PNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPNumber" runat="server" Text='<%# Eval("PNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="J Number" SortExpression="JNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJobID" runat="server" Text='<%# Eval("JobID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Nature of Task" SortExpression="Task">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTask" runat="server" Text='<%# Eval("Task") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Req by RCD" SortExpression="ReqRCD">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReqByRCD" runat="server" Text='<%# Eval("ReqRCD") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Req. Fwd to India" SortExpression="SentCAD">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSentCAD" runat="server" Text='<%# Eval("SentCAD") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sent to RCD" SortExpression="SentRCD">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSentRCD" runat="server" Text='<%# Eval("SentRCD") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Project Manager" SortExpression="ProjectManager">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectManager" runat="server" Text='<%# Eval("ProjectManager") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Project Engineer" SortExpression="ProjectEngineer">
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
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                <i class="far fa-times-circle"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <asp:GridView ID="gvDailyProjectReport" runat="server" CssClass="table mainGridTable table-sm mb-0" Visible="false"
                    AutoGenerateColumns="false" OnRowDataBound="gvDailyProjectReport_OnRowDataBound" OnRowCreated="gvDailyProjectReport_RowCreated">
                    <Columns>
                        <%-- <asp:TemplateField  HeaderText="Sr No">
                                    <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="Status" SortExpression="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="StatusID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="P Number">
                            <ItemTemplate>
                                <asp:Label ID="lblPNumber" runat="server" Text='<%# Eval("PNumberCol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="J Number">
                            <ItemTemplate>
                                <asp:Label ID="lblJNumber" runat="server" Text='<%# Eval("JNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Name" SortExpression="Project Name">
                            <ItemTemplate>
                                <asp:Label ID="lblprojectDescription" runat="server" Text='<%# Eval("ProjectDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nature of Task" SortExpression="Nature of Task">
                            <ItemTemplate>
                                <asp:Label ID="lblprojectManager" runat="server" Text='<%# Eval("NatureOfTask") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Req. By Customer" SortExpression="Date Req. By Customer">
                            <ItemTemplate>
                                <asp:Label ID="lblReqByRCD" runat="server" Text='<%# Eval("ReqByRCD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Req. Forward To CAD Team" SortExpression="Date Req. Forward To CAD Team">
                            <ItemTemplate>
                                <asp:Label ID="lblSentToCAD" runat="server" Text='<%# Eval("SentToCAD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Manager" SortExpression="Project Manager">
                            <ItemTemplate>
                                <asp:Label ID="lblprojectManager" runat="server" Text='<%# Eval("ProjectManager") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Engineer" SortExpression="Project Engineer">
                            <ItemTemplate>
                                <asp:Label ID="lblProjectEngineer" runat="server" Text='<%# Eval("ProjectEngineer") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Project Sent To Customer" SortExpression="Date Project Sent To Customer">
                            <ItemTemplate>
                                <asp:Label ID="lblSentToRCD" runat="server" Text='<%# Eval("SentToRCD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Response Time" SortExpression="Response Time" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblResponseTime" runat="server" Text='<%# Eval("ResponseTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                            <ItemTemplate>
                                <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Change Color" SortExpression="Change Color" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblChangeColor" runat="server" Text='<%# Eval("ChangeColor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HiddenField ID="HfPNumber" runat="server" Value="-1" />
            <asp:HiddenField ID="HiddenID" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenDetailID" runat="server" Value="0" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCADReport" />
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

            $('#<%=ddlProjectDesc.ClientID%>').chosen();
            $('#<%=ddlProjectEngineer.ClientID%>').chosen();
            $('#<%=ddlReportDateHeaderList.ClientID%>').chosen();
            $('#<%=ddlPNumberHeaderList.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlNature.ClientID%>').chosen();
            $('#<%=ddlPriority.ClientID%>').chosen();
            $('#<%=ddlProgress.ClientID%>').chosen();
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

    </script>
</asp:Content>
