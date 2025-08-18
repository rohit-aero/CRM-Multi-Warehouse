<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmModelPartMapping.aspx.cs" Inherits="Forecasting_ModelTypePartMapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="_Content_Forecasting_ModelPartMapping" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Forecasting_Models" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky pb-3">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Job Model Part Mapping</h4>
                        </div>
                    </div>

                    <div class="col-2 mb-2">
                        <label class="pl-0 col-12">Conveyor Model</label>
                        <asp:DropDownList ID="ddlConveyorModelLookup" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorModelLookup_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-2 mb-2">
                        <label class="pl-0 col-12">Conveyor Type</label>
                        <asp:DropDownList ID="ddlConveyorTypeLookup" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorTypeLookup_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-3 mb-2">
                        <label class="pl-0 col-12">Conveyor Size</label>
                        <asp:DropDownList ID="ddlConveyorSizeLookup" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorSizeLookup_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-3 mb-2">
                        <label class="pl-0 col-12">Conveyor Parent Part</label>
                        <asp:DropDownList ID="ddlConveyorParentLookup" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlConveyorParentLookup_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-12 mt-2 border-bottom">
                <h5 class="text-uppercase">Add info</h5>
                <div class="row">
                    <div class="col-2 mb-2">
                        <label class="pl-0 col-12 text-danger">Conveyor Model*</label>
                        <asp:DropDownList ID="ddlConveyorModel" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorModel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-2 mb-2">
                        <label class="pl-0 col-12 text-danger">Conveyor Type*</label>
                        <asp:DropDownList ID="ddlConveyorType" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-2 mb-2">
                        <label class="pl-0 col-12">Conveyor Size</label>
                        <asp:DropDownList ID="ddlConveyorSize" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorSize_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-3 mb-2">
                        <label class="pl-0 col-12 text-danger">Conveyor Parent Part*</label>
                        <asp:DropDownList ID="ddlConveyorParentParts" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlConveyorParentParts_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label class="col-12">&nbsp;</label>
                        <asp:Button ID="btnSaveSize" CssClass="btn btn-success btn-sm" runat="server" Text="Save" OnClick="btnSaveSize_Click" />
                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <h5 class="text-uppercase">Backend Parts</h5>
                <div class="row">
                    <div class="col-3 mb-2">
                        <label class="pl-0 col-12">Conveyor Child Part</label>
                        <asp:DropDownList ID="ddlConveyorChildParts" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlConveyorChildParts_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-1 mb-2">
                        <label class="pl-0 col-12">Qty</label>
                        <asp:TextBox ID="txtPartQty" CssClass="form-control form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);" MaxLength="4" runat="server">
                        </asp:TextBox>
                    </div>

                    <div class="col-1 mb-2">
                        <label class="pl-0 col-12">Active</label>
                        <asp:DropDownList ID="ddlActive" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Value="1" Selected>Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <asp:GridView ID="gvList" CssClass="table mainGridTable table-sm" runat="server" AutoGenerateColumns="false" DataKeyNames="id" OnRowDeleting="gvList_RowDeleting"
                                OnRowEditing="gvList_RowEditing">
                                <Columns>
                                    <asp:TemplateField HeaderText="id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Size">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSize" runat="server" Text='<%# Eval("Size") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Parent Part">
                                        <ItemTemplate>
                                            <asp:Label ID="lblParent" runat="server" Text='<%# Eval("Parent") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Child Part">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChild" runat="server" Text='<%# Eval("Child") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Backend Entry">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBackendEntry" runat="server" Text='<%# Eval("BackendEntry") %>' />
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

                                    <asp:TemplateField HeaderText="Active">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active") %>' />
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
                </div>
            </div>
            <asp:HiddenField ID="hfID" Value="-1" runat="server" />
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
            $('#<%=ddlConveyorModelLookup.ClientID%>').chosen();
            $('#<%=ddlConveyorTypeLookup.ClientID%>').chosen();
            $('#<%=ddlConveyorModel.ClientID%>').chosen();
            $('#<%=ddlConveyorType.ClientID%>').chosen();
            $('#<%=ddlConveyorSizeLookup.ClientID%>').chosen();
            $('#<%=ddlConveyorSize.ClientID%>').chosen();
            $('#<%=ddlConveyorParentParts.ClientID%>').chosen();
            $('#<%=ddlConveyorParentLookup.ClientID%>').chosen();
            $('#<%=ddlConveyorChildParts.ClientID%>').chosen();
            $('#<%=ddlActive.ClientID%>').chosen();
        }
    </script>
</asp:Content>
