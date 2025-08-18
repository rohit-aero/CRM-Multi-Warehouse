<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmProjectAccountLogs.aspx.cs" Inherits="SalesManagement_FrmProjectAccountLogs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Project Account Logs                            
                                <asp:Label ID="lblPM" Visible="false" CssClass="btn btn-primary btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblDesRep" Visible="false" CssClass="btn btn-success btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblConsultant" Visible="false" CssClass="btn btn-info btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-auto">
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
                                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="SearchPNameButton_Click" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-auto">
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
                                            <asp:Button ID="SearchJNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="SearchJNumberButton_Click" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12 mt-3">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm mb-3" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 mt-3">
                <div class="table-responsive eoeTable">
                    <asp:GridView ID="gvLogs" runat="server" CellPadding="3" EmptyDataText="No Logs Found !" Width="100%" CssClass="table mainGridTable table-sm"
                        AutoGenerateColumns="true" ShowFooter="false">
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
        });

        function PageLoaded(sender, args) {
            DDLName();
        }
        $.when.apply($, PageLoaded).then(function () {
            DDLName();
        });

        function DDLName() {

        }

        function ClickEventForPName(e) {
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchJNumberButton.UniqueID%>', "");
        }

        function bindEnterKey() {
            $('#<%= txtSearchPNum.ClientID %>').off('keydown').on('keydown', function (event) {
                if (event.keyCode == 13) { // 13 is the keycode for the Enter key
                    event.preventDefault();
                    return false;
                }
            });

            $('#<%= txtSearchPName.ClientID %>').off('keydown').on('keydown', function (event) {
                if (event.keyCode == 13) { // 13 is the keycode for the Enter key
                    event.preventDefault();
                    return false;
                }
            });
        }
    </script>
</asp:Content>
