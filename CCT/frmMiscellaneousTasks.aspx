<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="frmMiscellaneousTasks.aspx.cs" Inherits="CCT_frmMiscellaneousTasks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Miscellaneous Tasks</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-8">
                        <div class="row">
                            <div class="col-sm-2 mb-3">
                                <label class="mb-0">Lookup Task</label>
                            </div>
                            <div class="col-sm-10 mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTaskHeaderList" runat="server" DataTextField="CompanyName" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlTaskHeaderList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-secondary btn-sm" Enabled="true" OnClick="btnFilterForm_Click" Text="Filter Data" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Info Section --%>
            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Task Information</h5>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label class="text-danger">Company Name*</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="250" ID="txtCompanyName" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Location</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="500" ID="txtLocation" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Reference Number*</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="80" ID="txtRefNo" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Point of Contact</label>
                            <asp:TextBox CssClass="form-control form-control-sm " MaxLength="50" ID="txtContact" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Issue</label>
                            <asp:TextBox CssClass="form-control form-control-sm" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 5000)" ID="txtIssue" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Issue Date</label>
                            <asp:TextBox ID="txtIssueDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtIssueDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtIssueDate" TargetControlID="txtIssueDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Issue Highlighted By</label>
                            <asp:TextBox CssClass="form-control form-control-sm" MaxLength="80" ID="txtIssueBy" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Solution</label>
                            <asp:TextBox CssClass="form-control form-control-sm" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 5000)" ID="txtSolution" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Solution Date</label>
                            <asp:TextBox ID="txtSolutionDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"  OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtSolutionDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtSolutionDate" TargetControlID="txtSolutionDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Description</label>
                            <asp:TextBox CssClass="form-control form-control-sm" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 5000)" ID="txtDescription" runat="server" autocomplete="off" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>File(jpg/doc/pdf)</label>
                            <asp:FileUpload ID="fpUploadDoc" CssClass="btn btn-success btn-sm btn-block" runat="server" />
                            <asp:LinkButton ID="lnkDowload" runat="server" Text="Download File" Visible="false" OnClick="lnkDowload_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfFileAddress" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="lnkDowload" />
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
            $('#<%=ddlTaskHeaderList.ClientID%>').chosen();
        }
    </script>
</asp:Content>
