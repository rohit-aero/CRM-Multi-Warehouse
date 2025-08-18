<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmShopDwgIssueLog_Impact.aspx.cs" Inherits="SalesManagement_FrmShopDwgIssueLog_Impact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Impact Maintenance</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label class="mb-0">Impact&nbsp;</label>
                                    <div class="chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlImpactLookup" runat="server" DataTextField="text" DataValueField="Id" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlImpactLookup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-4">
                        <label class="mb-0">&nbsp;</label>
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <h5 class="text-uppercase">Impact Info</h5>
                <div class="row">
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Impact*</label>
                            <asp:TextBox ID="txtImpact" CssClass="form-control form-control-sm" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group srRadiosBtns">
                            <label class="text-danger">Active*</label>
                            <asp:RadioButtonList ID="rdbActive" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">No</asp:ListItem>
                                <asp:ListItem Value="2" Selected>Yes</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
            </div>
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
            $('#<%=ddlImpactLookup.ClientID%>').chosen();
        }

    </script>
</asp:Content>
