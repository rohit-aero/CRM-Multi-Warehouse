<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmITWProjectParts.aspx.cs" Inherits="TurboWash_FrmITWProjectParts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Parts Information ITW</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <label class="col-auto">Job ID</label>
                    <div class="col-sm-6 mb-3">
                        <div class="col-sm chosenFullWidth">
                            <asp:Panel ID="PanelJNum_Hidden" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                            </asp:Panel>
                            <asp:Panel ID="PanelJNum" runat="server" DefaultButton="SearchJNumberButton">
                                <asp:TextBox ID="txtSearchPNum" AutoComplete="off" placeholder="Type Job Number" CssClass="form-control form-control-sm" OnBlur="return ClickEvent(event)" runat="server">
                                </asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchPNum"
                                    CompletionInterval="3" CompletionSetCount="10" MinimumPrefixLength="2" CompletionListElementID="PanelJNum_Hidden"
                                    ServicePath="../AutoComplete.asmx" ServiceMethod="SearchITWJob" CompletionListCssClass="autocomplete" />
                                <asp:Button ID="SearchJNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchJName_TextChanged" />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="Panel2" runat="server">
                <div class="col-12 pt-2">
                    <div class="row d-flex justify-content-center">
                        <div class="col-md-11 mx-auto">
                            <div class="row">
                                <div class="col-12">
                                    <h5 class="text-uppercase">Part Description</h5>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <label class="col-auto">Category</label>
                                        <div class="col chosenFullWidth">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCategory" runat="server" DataTextField="Category" DataValueField="CategoryID" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md">
                                    <div class="row">
                                        <label class="col-sm-auto">Part Description</label>
                                        <div class="col chosenFullWidth">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartsDetail" DataTextField="PartNo" DataValueField="ID" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="row">
                                        <label class="col-sm-auto">Quantity</label>
                                        <div class="col">
                                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtQty" AutoComplete="off" MaxLength="6" runat="server" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-auto">
                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnClear" runat="server" Text="Cancel" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-12 pt-3">
                    <div class="table-responsive">
                        <asp:GridView CssClass="table mainGridTable table-sm" ID="gvDetail" runat="server" AutoGenerateColumns="False" EmptyDataText="No Parts has been Added"
                            EnableModelValidation="True" DataKeyNames="ProjectPartID" OnRowDeleting="gvDetail_RowDeleting" OnRowEditing="gvDetail_RowEditing">
                            <Columns>
                                <asp:TemplateField HeaderText="Part Description" HeaderStyle-Width="70%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPartDes" runat="server" Text='<%#Eval("PartNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Modify" HeaderStyle-Width="15%">
                                    <ItemTemplate>
                                        &nbsp;<asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-info btn-sm" CommandName="edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                        &nbsp;
				                    <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure to delete. ?');" runat="server" CommandName="Delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
            <asp:HiddenField runat="server" ID="HfProjectPartID" Value="-1"/>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });
        function PageLoaded(sender, args) {
            DDLName();
        }
        $.when.apply($, PageLoaded).then(function () {
            DDLName();
        });
        function DDLName() {
            $('#<%=ddlCategory.ClientID%>').chosen();
            $('#<%=ddlPartsDetail.ClientID%>').chosen();
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchJNumberButton.UniqueID%>', "");
        }
    </script>
</asp:Content>
