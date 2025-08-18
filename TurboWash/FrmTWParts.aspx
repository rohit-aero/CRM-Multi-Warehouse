<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmTWParts.aspx.cs" Inherits="TurboWash_FrmTWParts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">TurboWash Parts Report</h4>
                        </div>
                    </div>
                </div>

                <div class="row pb-2">
                    <div class="col-2">
                        <label>Category</label>
                        <asp:DropDownList ID="ddlCategoryLookupList" runat="server" AutoPostBack="true" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="ddlCategoryLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Size (In Inches)</label>
                        <asp:DropDownList ID="ddlSizeLookupList" runat="server" AutoPostBack="true" DataTextField="SizeName" DataValueField="id" OnSelectedIndexChanged="ddlSizeLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Orientation</label>
                        <asp:DropDownList ID="ddlOrientationLookupList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrientationLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem Value="RL">RL</asp:ListItem>
                            <asp:ListItem Value="LR">LR</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Options</label>
                        <asp:DropDownList ID="ddlOptionLookupList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOptionLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">With Drain</asp:ListItem>
                            <asp:ListItem Value="2">With Sump</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-3">
                        <label>&nbsp;</label>
                        <div class="">
                            <asp:Button ID="btnPreview" runat="server" OnClick="btnPreview_Click" Text="Preview" Enabled="true" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" CssClass="btn btn-info btn-sm" />
                            <asp:Button ID="btnExportToExcel" runat="server" OnClick="btnExportToExcel_Click" Text="Export To Excel" CausesValidation="false" CssClass="btn btn-info btn-sm" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-danger btn-sm" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPreview" />
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptTWParts" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlCategoryLookupList.ClientID%>').chosen();
            $('#<%=ddlOptionLookupList.ClientID%>').chosen();
            $('#<%=ddlOrientationLookupList.ClientID%>').chosen();
            $('#<%=ddlSizeLookupList.ClientID%>').chosen();
        }
    </script>
</asp:Content>
