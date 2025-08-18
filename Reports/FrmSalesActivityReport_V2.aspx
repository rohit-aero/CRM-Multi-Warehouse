<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmSalesActivityReport_V2.aspx.cs" Inherits="Reports_FrmSalesActivityReport_V2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content_SalesActivity" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SalesActivity" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Sales Activity Report</h4>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Project Manager</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectManager" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Other filter</label>
                            <asp:ListBox CssClass="form-control form-control-sm" ID="ddlOtherFilter" SelectionMode="multiple" runat="server" >
                                <%--<asp:ListItem Value="0">All</asp:ListItem>--%>
                                <asp:ListItem Value="1">Alternate Specification Projects</asp:ListItem>
                                <asp:ListItem Value="2">Prime Spec Projects with Alternate</asp:ListItem>
                                <asp:ListItem Value="3">Prime Spec Projects without Alternate</asp:ListItem>
                            </asp:ListBox>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Filter data on</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDateType" runat="server" OnSelectedIndexChanged="ddlDateType_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">Activity Date</asp:ListItem>
                                <asp:ListItem Value="1">Proposal Date</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label id="lblFrom" runat="server">Activity Date From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDateFrom_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateFrom" TargetControlID="txtDateFrom"></asp:CalendarExtender>

                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label id="lblTo" runat="server">Activity Date To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDateTo_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateTo" TargetControlID="txtDateTo"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-3 pl-0">
                        <div class="form-group">
                            <%--<label>&nbsp;</label>--%>
                            <div class="col-auto">
                                <asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClick="btnReport_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Report" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
            DDL();
        }

        $.when.apply($, PageLoaded).then(function () {
            DDL();
        });

        function DDL() {
            $('#<%=ddlProjectManager.ClientID%>').chosen();
            $('#<%=ddlDateType.ClientID%>').chosen();
            $('#<%=ddlOtherFilter.ClientID%>').chosen();
        }
    </script>
</asp:Content>
