<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmSiteVisitInformation.aspx.cs" Inherits="SalesManagement_FrmSiteVisitInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_SiteVisit" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SiteVisit" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Site Visit Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <div class="col-sm chosenFullWidth">
                            <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;"></asp:Panel>
                            <label>Proposal Number</label>
                            <asp:Panel ID="PanelPName" runat="server" DefaultButton="SearchPNameButton">
                                <asp:TextBox ID="txtSearchPName" placeholder="Type Proposal Name" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEventForPName(event)" onkeypress="return EnterEventForPName(event)">
                                </asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchPName"
                                    CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                    ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProjectNameAndPNumber" CompletionListCssClass="autocomplete" />
                                <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPName_TextChanged" />
                            </asp:Panel>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="col-sm chosenFullWidth">
                            <asp:Panel ID="JName" runat="server" Style="height: 200px; overflow: scroll; display: none;"></asp:Panel>
                            <label>Job ID</label>
                            <asp:Panel ID="PanelJName" runat="server" DefaultButton="SearchJNameButton">
                                <asp:TextBox ID="txtSearchJName" placeholder="Type Job" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEventForJName(event)" onkeypress="return EnterEventForJName(event)">
                                </asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchJName"
                                    CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="JName"
                                    ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProjectNameAndJNumber" CompletionListCssClass="autocomplete" />
                                <asp:Button ID="SearchJNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchJName_TextChanged" />
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row ">
                            <div class="col-12 mb-2">
                                <label class="mb-0">&nbsp;</label>
                            </div>
                            <div class="col-auto mb-2">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Add Visit" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-secondary btn-sm" Enabled="true" OnClick="btnFilterForm_Click" Text="Filter Data" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Project Information&nbsp;                            
                        </h5>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Requestor*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm " ID="ddlRequestor" DataTextField="EmployeeName" DataValueField="EmployeeID" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Employees</label>
                            <%--<asp:DropDownList CssClass="form-control form-control-sm " ID="ddlEmployee" DataTextField="EmployeeName" DataValueField="EmployeeID" runat="server" />--%>
                            <asp:ListBox CssClass="form-control form-control-sm" AutoPostBack="false" ID="ddlEmployee" DataTextField="EmployeeName" DataValueField="EmployeeID" runat="server" SelectionMode="Multiple" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Purpose*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm " ID="ddlPurpose" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="2">Exisiting projects site visits</asp:ListItem>
                                <asp:ListItem Value="3">Post-install site visits</asp:ListItem>
                                <asp:ListItem Value="1">Presale meeting</asp:ListItem>
                                <asp:ListItem Value="4">Site Measurements</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2" style="display: none;">
                        <div class="form-group">
                            <label class="text-danger">Region*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm " ID="ddlRegion" DataTextField="Region" DataValueField="RegionID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Project Location&nbsp;                            
                        </h5>
                    </div>

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="250" ID="txtAddress_ProjectLocation" runat="server" autocomplete="off" Enabled="false" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="250" ID="txtCountry_ProjectLocation" runat="server" autocomplete="off" Enabled="false" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>State</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="250" ID="txtState_ProjectLocation" runat="server" autocomplete="off" Enabled="false" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="250" ID="txtCity_ProjectLocation" runat="server" autocomplete="off" Enabled="false" />
                        </div>
                    </div>

                </div>
            </div>


            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Site Location</h5>
                    </div>

                    <div class="col-12">
                        <div class="form-group">
                            <asp:CheckBox ID="chkSameAsProjectLocation" runat="server" OnCheckedChanged="chkSameAsProjectLocation_CheckedChanged" Text="&emsp;Same as Project Location" AutoPostBack="true" />
                            <%--  <label>&emsp;Same as Project Location</label>--%>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label class="form-group">Site Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="250" ID="txtSiteAddress" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="form-group">Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm " ID="ddlCountry" DataTextField="Country" DataValueField="CountryID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="form-group">State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm " ID="ddlState" DataTextField="State" DataValueField="StateID" runat="server" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="form-group">City</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="100" ID="txtCity" runat="server" autocomplete="off" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Visit Information</h5>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label class="text-danger">Site Visit Date*</label>
                            <asp:TextBox ID="txtSiteVisitDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtSiteVisitDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtSiteVisitDate" TargetControlID="txtSiteVisitDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Site Contact Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="100" ID="txtSiteContactName" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Site Contact Number</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="25" ID="txtSiteContactNumber" onblur="phoneMask(this)" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:TextBox CssClass="form-control form-control-sm " TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)" ID="txtRemarks" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Next Visit Date</label>
                            <asp:TextBox ID="txtNextVisitDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtNextVisitDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtNextVisitDate" TargetControlID="txtNextVisitDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                </div>
                <div id="siteVisits" runat="server" class="row border-top pt-3">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Site Visits</h5>
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ForeColor="White" ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                                EnableModelValidation="True" ShowFooter="false" OnRowEditing="gvDetail_RowEditing" OnRowDeleting="gvDetail_RowDeleting">
                                <Columns>
                                    <%--<asp:BoundField DataField="Region" HeaderText="Region" />--%>
                                    <asp:BoundField DataField="SiteVisitDate" HeaderText="Site Visit Date" />
                                    <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                                    <asp:BoundField DataField="Requestor" HeaderText="Requestor" />
                                    <asp:BoundField DataField="EmployeeNames" HeaderText="Employee Name" ItemStyle-Width="10%" />
                                    <asp:BoundField DataField="SiteName" HeaderText="Site Name" ItemStyle-Width="15%" />
                                    <asp:BoundField DataField="SiteContactName" HeaderText="Site Contact Name" />
                                    <asp:BoundField DataField="SiteContactNumber" HeaderText="Site Contact Number" />
                                    <asp:BoundField DataField="NextVisitDate" HeaderText="Next Visit Date" />
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
            <asp:HiddenField ID="HfPNumber" runat="server" Value="-1" />
            <asp:HiddenField ID="hfID" runat="server" />
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
            $('#<%=ddlPurpose.ClientID%>').chosen();
            $('#<%=ddlRegion.ClientID%>').chosen();
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlEmployee.ClientID%>').chosen();
            $('#<%=ddlRequestor.ClientID%>').chosen();
        }

         function EnterEventForJName(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=SearchJNameButton.UniqueID%>', "");
            }
        }

        function ClickEventForJName(e) {
            __doPostBack('<%=SearchJNameButton.UniqueID%>', "");
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
