<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmJobModels.aspx.cs" Inherits="Forecasting_FrmJobModels" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="_Content_Forecasting_Models" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Forecasting_Models" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky pb-3">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Job Models</h4>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-10">
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
                    <div class="col-sm-2">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" CssClass="ml-3 btn btn-success btn-sm" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClick="btnPreview_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 mt-2">
                <div class="row col-12">
                    <div class="col-2">
                        <label class="pl-0 col-12 text-danger">Conveyor Model*</label>
                        <asp:DropDownList ID="ddlConveyorModel" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorModel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label class="pl-0 col-12 text-danger">Type*</label>
                        <asp:DropDownList ID="ddlConveyorType" CssClass="form-control form-control-sm" DataValueField="id" DataTextField="text" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorType_SelectedIndexChanged">
                            <asp:ListItem Value="">Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label class="pl-0 col-12">Size</label>
                        <asp:DropDownList ID="ddlConveyorSize" CssClass="form-control form-control-sm" DataValueField="id" DataTextField="text" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorSize_SelectedIndexChanged">
                            <asp:ListItem Value="">Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label class="pl-0 col-12 text-danger">Parent Part*</label>
                        <asp:DropDownList ID="ddlConveyorParentParts" CssClass="form-control form-control-sm" DataValueField="id" DataTextField="text" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorParentParts_SelectedIndexChanged">
                            <asp:ListItem Value="">Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-1 mb-2">
                        <label class="pl-0 col-12 text-danger">Qty*</label>
                        <asp:TextBox ID="txtPartQty" CssClass="form-control form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);" MaxLength="4" runat="server">
                        </asp:TextBox>
                    </div>

                    <div class="col-3">
                        <label class="pl-0 col-12">Search All Parent Parts</label>
                        <asp:DropDownList ID="ddlAllParentParts" CssClass="form-control form-control-sm" DataValueField="id" DataTextField="text" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAllParentParts_SelectedIndexChanged">
                            <asp:ListItem Value="">Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-12">
                        <label class="pl-0 col-12">&nbsp;</label>

                        <%--<asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" />--%>
                    </div>
                </div>

                <div class="col-12">
                    <asp:GridView ID="gvList" CssClass="table mainGridTable table-sm" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnRowDeleting="gvList_RowDeleting"
                        OnRowEditing="gvList_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Model">
                                <ItemTemplate>
                                    <asp:Label ID="lblModel" runat="server" Text='<%# Eval("Model") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Size">
                                <ItemTemplate>
                                    <asp:Label ID="lblSize" runat="server" Text='<%# Eval("Size") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Parent Part No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartNo" runat="server" Text='<%# Eval("part") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Right">
                                <HeaderTemplate>
                                    <div style="text-align: right;">Qty</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("qty") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <div style="text-align: center;">Modify</div>
                                </HeaderTemplate>
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
            <asp:HiddenField ID="HfRelease" runat="server" Value="-1" />
            <asp:HiddenField ID="HfID" runat="server" Value="-1" />
            <asp:HiddenField ID="HfJobID" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPreview" />
        </Triggers>
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
            $('#<%=ddlConveyorModel.ClientID%>').chosen();
            $('#<%=ddlConveyorType.ClientID%>').chosen();
            $('#<%=ddlConveyorSize.ClientID%>').chosen();
            $('#<%=ddlConveyorParentParts.ClientID%>').chosen();
            $('#<%=ddlAllParentParts.ClientID%>').chosen();
        }

        function ClickEventForPName(e) {
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchJNumberButton.UniqueID%>', "");
        }
    </script>
</asp:Content>
