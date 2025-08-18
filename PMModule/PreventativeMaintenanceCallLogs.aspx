<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" EnableEventValidation="false" CodeFile="PreventativeMaintenanceCallLogs.aspx.cs" Inherits="PMModule_PreventativeMaintenanceCallLogs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Preventative Maintenance Prospects</h5>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Warranty End Date From</label>
                            <asp:TextBox ID="txtWarrantyEndDateFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtWarrantyEndDateFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtWarrantyEndDateFrom" TargetControlID="txtWarrantyEndDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Warranty End Date To</label>
                            <asp:TextBox ID="txtWarrantyEndDateTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtWarrantyEndDateTo_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtWarrantyEndDateTo" TargetControlID="txtWarrantyEndDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <%--<div class="col-sm-2">
                        <div class="form-group">
                            <label>Job#</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobID" runat="server" DataTextField="text" DataValueField="text">
                            </asp:DropDownList>
                        </div>
                    </div>--%>

                    <div class="col-sm-10">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Project</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                        </asp:Panel>
                                        <asp:Panel ID="PanelPName" runat="server" DefaultButton="SearchPNameButton">
                                            <asp:TextBox ID="txtSearchPName" AutoComplete="off" placeholder="Type Job Name" CssClass="form-control form-control-sm" OnBlur="return ClickEventForPName(event)" runat="server">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchPName"
                                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProject" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPName_TextChanged" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Job ID</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Panel ID="Panel1" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                        </asp:Panel>
                                        <asp:Panel ID="PanelJNum" runat="server" DefaultButton="SearchJNumberButton">
                                            <asp:TextBox ID="txtSearchPNum" AutoComplete="off" placeholder="Type Job Number" CssClass="form-control form-control-sm" OnBlur="return ClickEvent(event)" runat="server">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchPNum"
                                                CompletionInterval="3" CompletionSetCount="10" MinimumPrefixLength="3" CompletionListElementID="Panel1"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProjectNumber" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchJNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPNum_TextChanged" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-8">
                        <div class="row">
                            <label class="col-md-12">&nbsp;</label>
                            <div class="col-md-6">
                                <asp:Button ID="btnShow" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" Text="Search" OnClick="btnShow_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                                <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Enabled="false" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
                                <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnReportRedirect" OnClick="btnReportRedirect_Click" runat="server" Text="Report" />
                            </div>
                            <div class="col-md-6 justify-content-center">
                                <strong class="text-center">
                                    <asp:Label CssClass="alert alert-success d-block py-1" ID="lblRecordsCount" runat="server" Text="Label" Visible="false"></asp:Label>
                                </strong>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col">
                <asp:GridView ID="gvWarrantyEndJobs" runat="server" ForeColor="White" CssClass="table mainGridTable table-sm mb-0" OnRowDataBound="gvWarrantyEndJobs_RowDataBound"
                    OnRowCommand="gvWarrantyEndJobs_RowCommand" EnableModelValidation="True" AutoGenerateColumns="false" DataKeyNames="JobID" AllowSorting="true"
                    OnSorting="gvWarrantyEndJobs_Sorting">
                    <Columns>
                        <asp:TemplateField HeaderText="Job ID" Visible="true" SortExpression="JobID">
                            <ItemTemplate>
                                <asp:Label ID="lblJobID" runat="server" Text='<%# Eval("JobID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Name" SortExpression="CompanyName">
                            <ItemTemplate>
                                <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Time Called" SortExpression="LastCallDate">
                            <ItemTemplate>
                                <asp:Label ID="lblLastCallDate" runat="server" Text='<%# Eval("LastCallDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="City" SortExpression="City">
                            <ItemTemplate>
                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="State" SortExpression="State">
                            <ItemTemplate>
                                <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Warranty End Date" SortExpression="WarrantyEndDate">
                            <ItemTemplate>
                                <asp:Label ID="lblWarrantyEndDate" runat="server" Text='<%# Eval("WarrantyEndDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Net Eq. Price" SortExpression="NetEqPrice">
                            <ItemTemplate>
                                <asp:Label ID="lblNetEqPrice" runat="server" Text='<%# Eval("NetEqPrice") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <%-- Modal --%>
            <asp:ModalPopupExtender ID="modalForJob" runat="server" TargetControlID="lnkModalButton"
                PopupControlID="panelForModal" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="panelForModal" runat="server" CssClass="ReportsModalPopup" Style="display: none;" Width="90%" Height="80%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" OnClick="btnClose_Click" />
                    <div class="overflow-auto h-100">
                        <%-- Title --%>
                        <div class="row justify-content-center col-12">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-sm-4 col-md-auto mb-3 modal-title text-center">
                                        <h5>
                                            <label class="mb-0 title-hyphen position-relative">Job ID:</label>
                                            <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddContactRedirect" Visible="false" OnClick="btnAddContactRedirect_Click" runat="server" Text="Add Contact" />
                                        </h5>
                                    </div>
                                    <div class="col-sm-8 col-md mb-3 chosenFullWidth ">
                                        <h5>
                                            <asp:Label ID="lblJobIDTitleInModal" runat="server"></asp:Label>
                                        </h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4 col-md-auto mb-3 modal-title text-center">
                                        <h5>
                                            <label class="mb-0 title-hyphen position-relative">Warranty End Date:</label>
                                        </h5>
                                    </div>
                                    <div class="col-sm-8 col-md mb-3 chosenFullWidth ">
                                        <h5>
                                            <asp:Label ID="lblWarrantyEndDate" runat="server"></asp:Label>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- First Grid (for contacts) --%>
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvJobContacts" runat="server" AutoGenerateColumns="False"
                                    EnableModelValidation="True" EmptyDataText="No Contacts" DataKeyNames="ContactID" ShowFooter="True"
                                    OnRowCommand="gvJobContacts_RowCommand" OnRowDeleting="gvJobContacts_RowDeleting" OnRowEditing="gvJobContacts_RowEditing"
                                    OnRowCancelingEdit="gvJobContacts_RowCancelingEdit" OnRowUpdating="gvJobContacts_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Position*">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'>
                                                </asp:Label>
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtTitle" Text='<%# Eval("Title") %>' MaxLength="35" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </EditItemTemplate>

                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterTitle" MaxLength="35" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="First Name*">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' MaxLength="30" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </EditItemTemplate>

                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterFirstName" MaxLength="30" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Last Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' MaxLength="30" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </EditItemTemplate>

                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterLastName" MaxLength="30" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Contact Name" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("ContactName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Office Phone">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfficePhone" runat="server" Text='<%# Eval("OfficePhone") %>'>
                                                </asp:Label>
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtOfficePhone" onblur="phoneMask(this)" Text='<%# Eval("OfficePhone") %>' MaxLength="25" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </EditItemTemplate>

                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterOfficePhone" onblur="phoneMask(this)" MaxLength="25" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cell Phone">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'>
                                                </asp:Label>
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPhone" onblur="phoneMask(this)" Text='<%# Eval("Phone") %>' MaxLength="25" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </EditItemTemplate>

                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterPhone" onblur="phoneMask(this)" MaxLength="25" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'>
                                                </asp:Label>
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %> ' MaxLength="50" oninput="emailMask(this)" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </EditItemTemplate>

                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterEmail" oninput="emailMask(this)" MaxLength="50" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Contact Reference" Visible="false">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRefN" Checked='<%# Eval("ReferenceContact") %>' runat="server" />
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:CheckBox ID="chkRef" Checked='<%# Eval("ReferenceContact") %>' runat="server" />
                                            </EditItemTemplate>

                                            <FooterTemplate>
                                                <asp:CheckBox ID="chkFooterRef" runat="server"></asp:CheckBox>
                                            </FooterTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Main" Visible="false">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkMainN" Checked='<%# Eval("MainContact") %>' runat="server" />
                                            </ItemTemplate>

                                            <EditItemTemplate>
                                                <asp:CheckBox ID="chkMain" Checked='<%# Eval("MainContact") %>' runat="server" />
                                            </EditItemTemplate>

                                            <FooterTemplate>
                                                <asp:CheckBox ID="chkFooterMain" runat="server"></asp:CheckBox>
                                            </FooterTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Modify" ItemStyle-Width="150">
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit">
                                                <i class="far fa-edit" title="Edit"></i>
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Member ?');" CommandName="Delete">
                                                <i class="far fa-times-circle" title="Delete"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <%-- while edit buttons --%>
                                            <EditItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update">
                                                <i class="far fa-save" title="Update"></i>
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel">
                                                <i class="fas fa-redo" title="Redo"></i>
                                                </asp:LinkButton>
                                            </EditItemTemplate>
                                            <%-- new entry fields --%>
                                            <FooterTemplate>
                                                <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddContact" CommandName="Insert" runat="server" TabIndex="40" Text="Add" />
                                            </FooterTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                        <%-- form to enter call details --%>
                        <div class="col-12">
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label class="text-danger">Date Called*</label>
                                        <asp:TextBox CssClass="form-control form-control-sm " ID="txtDateCalled" runat="server" />
                                        <asp:CalendarExtender ID="txtDateCalled_Extender" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtDateCalled" TargetControlID="txtDateCalled">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>

                                <div class="col-sm-2" style="display: none;">
                                    <div class="form-group">
                                        <label class="text-danger">Contact Name*</label>
                                        <asp:TextBox CssClass="form-control form-control-sm " MaxLength="50" ID="txtContact" runat="server" />
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group chosenFullWidth">
                                        <label class="text-danger">Contact Name*</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContactName" DataTextField="ContactName" DataValueField="ContactID" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <label>Call Details</label>
                                        <asp:TextBox CssClass="form-control form-control-sm " TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 5000)" ID="txtCallDetails" runat="server" />
                                    </div>
                                </div>

                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <label>Notes</label>
                                        <asp:TextBox CssClass="form-control form-control-sm " TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 5000)" ID="txtNotes" runat="server" />
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group srRadiosBtns">
                                        <label>PM Response</label>
                                        <asp:RadioButtonList ID="rdbPMResponse" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <label>&nbsp;</label>
                                    <div class="col-12">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info btn-sm" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- Second Grid (for call history) --%>
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvCallHistory" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                    OnRowDeleting="gvCallHistory_RowDeleting" OnRowEditing="gvCallHistory_RowEditing" EnableModelValidation="true" EmptyDataText="No Call History">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Date Called" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateCalled" runat="server" Text='<%# Eval("DateCalled") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDateCalled" runat="server" Text='<%# Eval("DateCalled") %>' AutoComplete="off" Style="width: 100%;"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Contact Name" ItemStyle-Width="170">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContact" runat="server" Text='<%# Eval("Contact") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtContact" runat="server" Text='<%# Eval("Contact") %>' AutoComplete="off" Style="width: 100%;"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Call Details" ItemStyle-Width="750">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCallDetails" runat="server" Text='<%# Eval("CallDetails") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtCallDetails" runat="server" Text='<%# Eval("CallDetails") %>' AutoComplete="off" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 5000)" Style="width: 100%;"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Notes" ItemStyle-Width="250">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNotes" runat="server" Text='<%# Eval("Notes") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtNotes" runat="server" Text='<%# Eval("Notes") %>' AutoComplete="off" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 5000)" Style="width: 100%;"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PM Response" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPMResponse" runat="server" Text='<%# Eval("PMResponse") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:RadioButtonList ID="rdbPMResponse" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Modify" ItemStyle-Width="150">
                                            <EditItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update">
                                                <i class="far fa-save" title="Update"></i>
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel">
                                                <i class="fas fa-redo" title="Redo"></i>
                                                </asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit">
                                                <i class="far fa-edit" title="Edit"></i>
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Member ?');" CommandName="Delete">
                                                <i class="far fa-times-circle" title="Delete"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="lnkModalButton" runat="server"></asp:LinkButton>
            <asp:HiddenField ID="hfDetailID" runat="server" />
            <asp:HiddenField ID="hfJobIDTitleInModal" runat="server" />
            <asp:HiddenField ID="HfJObID" runat="server" Value="" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptPreventativeMaintenanceCallLogs" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlContactName.ClientID%>').chosen();           
        }

        function ClickEventForPName(e) {
            console.log("function called");
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

        function ClickEvent(e) {
            console.log("function called 1");
            __doPostBack('<%=SearchJNumberButton.UniqueID%>', "");
        }

    </script>
</asp:Content>
