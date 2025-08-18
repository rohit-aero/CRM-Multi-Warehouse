<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmPart.aspx.cs" Inherits="TurboWash_FrmPart" %>

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
                            <h4 class="title-hyphen position-relative">TurboWash Part Maintenance</h4>
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

                    <div class="col-2">
                        <label>Part No</label>
                        <asp:DropDownList ID="ddlPartLookupList" runat="server" AutoPostBack="true" DataTextField="PartNo" DataValueField="id" OnSelectedIndexChanged="ddlPartLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>

                    <div class="col-3 mt-1">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-success btn-sm" CausesValidation="false" />
                        <%--<asp:Button ID="btnExportToPDF" runat="server" OnClick="btnExportToPDF_Click" Text="Report" Enabled="true" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" CssClass="btn btn-info btn-sm" />--%>
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-danger btn-sm" />
                    </div>
                </div>
            </div>
            <div class="col-12 border-3">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">TurboWash Part Information</h5>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Category*</label>
                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" DataTextField="name" DataValueField="id" CssClass="form-control form-control-sm" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Size (In Inches)*</label>
                            <asp:DropDownList ID="ddlSize" runat="server" DataTextField="SizeName" DataValueField="id" CssClass="form-control form-control-sm">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Orientation</label>
                            <asp:DropDownList ID="ddlDirection" runat="server" CssClass="form-control form-control-sm">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="LR">LR</asp:ListItem>
                                <asp:ListItem Value="RL">RL</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <label>Option</label>
                        <asp:DropDownList ID="ddlOption" runat="server" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">With Drain</asp:ListItem>
                            <asp:ListItem Value="2">With Sump</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Part No*</label>
                            <asp:TextBox ID="txtPartNo" runat="server" MaxLength="20" CssClass="form-control form-control-sm">
                            </asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Stock In Hand</label>
                            <asp:TextBox ID="txtStockInHand" runat="server" Enabled="false" CssClass="form-control form-control-sm">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="btnExportToPDF" />--%>
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptTWPartReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlPartLookupList.ClientID%>').chosen();
            $('#<%=ddlCategory.ClientID%>').chosen();
            $('#<%=ddlOptionLookupList.ClientID%>').chosen();
            $('#<%=ddlOrientationLookupList.ClientID%>').chosen();
            $('#<%=ddlOption.ClientID%>').chosen();
            $('#<%=ddlSize.ClientID%>').chosen();
            $('#<%=ddlSizeLookupList.ClientID%>').chosen();
            $('#<%=ddlDirection.ClientID%>').chosen();
        }
    </script>
</asp:Content>
