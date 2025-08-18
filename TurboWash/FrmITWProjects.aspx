<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmITWProjects.aspx.cs" Inherits="TurboWash_FrmITWProjects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()">
                                <i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">ITW Project Information
                            </h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-4">
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
                                            <asp:AutoCompleteExtender ID="PName_Extender" runat="server" TargetControlID="txtSearchPName"
                                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchITWProject" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPName_TextChanged" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="row">
                                    <div class="col-sm-auto">
                                        <label class="mb-0">Job ID</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Panel ID="PanelJNum_Hidden" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                        </asp:Panel>
                                        <asp:Panel ID="PanelJNum" runat="server" DefaultButton="SearchJNumberButton">
                                            <asp:TextBox ID="txtSearchPNum" AutoComplete="off" placeholder="Type Job Number" CssClass="form-control form-control-sm" OnBlur="return ClickEvent(event)" runat="server">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchPNum"
                                                CompletionInterval="3" CompletionSetCount="10" MinimumPrefixLength="2" CompletionListElementID="PanelJNum_Hidden"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchITWJobID" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchJNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPNum_TextChanged" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                               <div class="col-sm-4">
                                    <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm mb-3" OnClick="btnNew_Click" Text="New Project" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm mb-3" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm mb-3" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="RemoveQueryString()" />
                            </div>
                        </div>
                                   </div>
                        </div>
                    </div>                   
                </div>
            </div>

            <%-- Info Section --%>
            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Project Information</h5>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Job ID*</label>
                            <asp:TextBox ID="txtJobId" runat="server" Enabled="false" MaxLength="50" AutoComplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Hobart Drawing#*</label>
                            <asp:TextBox ID="txtHobartDrawingNumber" runat="server" MaxLength="50" AutoComplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label class="text-danger">Project Name*</label>
                            <asp:TextBox ID="txtProjectName" runat="server" MaxLength="200" AutoComplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <label>Orientation</label>
                        <asp:DropDownList ID="ddlOrientationList" runat="server" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem Value="RL">RL</asp:ListItem>
                            <asp:ListItem Value="LR">LR</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-sm-2">
                        <label>Option</label>
                        <asp:DropDownList ID="ddlOption" runat="server" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">With Drain</asp:ListItem>
                            <asp:ListItem Value="2">With Sump</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">PO Received Date*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPOReceivedDate" AutoComplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtPOReceivedDate" TargetControlID="txtPOReceivedDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Req. Ship Date*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtReqShipDate" AutoComplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReqShipDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReqShipDate" TargetControlID="txtReqShipDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Ship Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipDate" AutoComplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtShipDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipDate" TargetControlID="txtShipDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Eq Price</label>
                            <asp:TextBox ID="txtEqPrice" runat="server" MaxLength="10" AutoComplete="off" onkeypress="return onlyDotsAndNumbers(this,event);" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Release Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtReleaseDate" AutoComplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReleaseDate" TargetControlID="txtReleaseDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <div class="row">
                                <label class="col-12">&nbsp;</label>
                            </div>
                            <asp:Button ID="btnRelease" runat="server" CssClass="btn btn-primary btn-sm mb-3" OnClientClick="return confirm('Are you sure to Release.?');" Text="Release" OnClick="btnRelease_Click" />
                            <asp:Button ID="btnRollback" runat="server" CssClass="btn btn-danger btn-sm mb-3" OnClientClick="return confirm('Are you sure to Rollback.?');" Text="Rollback" OnClick="btnRollback_Click" />
                        </div>
                    </div>

                </div>
            </div>

            <asp:Panel ID="Panel2" runat="server">
                <div class="col-12 pt-2 border-top">
                    <div class="row d-flex justify-content-center">
                        <div class="col-md-12 mx-auto">
                            <div class="row">
                                <div class="col-12">
                                    <h5 class="text-uppercase">Project Parts
                                     
                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnAdd" runat="server" Text="Save" OnClick="btnAdd_Click" />
                                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnClear" runat="server" Text="Cancel" OnClick="btnClear_Click" />
                               
                                    </h5>
                                   
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        <label class="col-auto">Category</label>
                                        <div class="col chosenFullWidth">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCategory" runat="server" DataTextField="Category" DataValueField="CategoryID" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="row">
                                        <label class="col-sm-auto">Part #</label>
                                        <div class="col chosenFullWidth">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartNo" DataTextField="PartNo" DataValueField="ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPartNo_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <label class="col-sm-auto">Part Description</label>
                                        <div class="col chosenFullWidth">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartsDetail" DataTextField="PartDesc" DataValueField="ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPartsDetail_SelectedIndexChanged"></asp:DropDownList>
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
            <asp:HiddenField runat="server" ID="HfProjectPartID" Value="-1" />
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
            $('#<%=ddlOrientationList.ClientID%>').chosen();
            $('#<%=ddlOption.ClientID%>').chosen();
            $('#<%=ddlCategory.ClientID%>').chosen();
            $('#<%=ddlPartNo.ClientID%>').chosen();
            $('#<%=ddlPartsDetail.ClientID%>').chosen();
        }

        function ClickEventForPName(e) {
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchJNumberButton.UniqueID%>', "");
        }

        function RemoveQueryString() {
            var uri = window.location.toString();
            if (uri.indexOf("?") > 0) {
                var clean_uri = uri.substring(0, uri.indexOf("?"));
                window.history.replaceState({}, document.title, clean_uri);
            }
        }
    </script>
</asp:Content>
