<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmModelSizeMapping.aspx.cs" Inherits="Forecasting_FrmModelSizeMapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="_Content_Forecasting_ModelPartMapping" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Forecasting_ModelSize" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky pb-3">
                <div class="row ml-1">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Job Model Size Mapping</h4>
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

                    <div class="col-3">
                        <label class="col-12">&nbsp;</label>
                        <asp:Button ID="btnSaveSize" CssClass="btn btn-success btn-sm" runat="server" Text="Save" OnClick="btnSaveSize_Click" />
                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>

            <div class="col-12 mt-2 border-bottom">
                <h5 class="col-12 text-uppercase">Map conveyor Size</h5>
                <div class="row col-12">
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

                    <div class="col-4 mb-2">
                        <label class="pl-0 col-12 text-danger">Conveyor Size*</label>
                        <asp:TextBox ID="txtConveyorSize" CssClass="form-control form-control-sm" MaxLength="250" runat="server">
                        </asp:TextBox>
                    </div>

                    <div class="col-1 mb-2">
                        <label class="pl-0 col-12 text-danger">Is Active*</label>
                        <asp:DropDownList ID="ddlActive" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Value="1" Selected>Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-8">
                <asp:GridView ID="gvList" CssClass="table mainGridTable table-sm" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                    OnRowEditing="gvList_RowEditing" OnRowDeleting="gvList_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Model" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="lblModel" runat="server" Text='<%# Eval("Model") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Type" ItemStyle-Width="30%">
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Size" ItemStyle-Width="30%">
                            <ItemTemplate>
                                <asp:Label ID="lblSize" runat="server" Text='<%# Eval("Size") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                            <HeaderTemplate>
                                <div style="text-align: center;">Modify</div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                <%--</asp:LinkButton>--%>
                                <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                <i class="far fa-times-circle"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HiddenField ID="hfID" runat="server" Value="-1" />
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
            $('#<%=ddlActive.ClientID%>').chosen();
        }
    </script>
</asp:Content>
