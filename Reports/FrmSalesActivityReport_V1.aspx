<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmSalesActivityReport_V1.aspx.cs" Inherits="Reports_FrmSalesActivityReport_V1" %>

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
                    <div class="col-2">
                        <div class="form-group">
                            <label id="lblFrom">Activity Date From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDateFrom_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateFrom" TargetControlID="txtDateFrom"></asp:CalendarExtender>

                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label id="lblTo">Activity Date To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDateTo_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateTo" TargetControlID="txtDateTo"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Stakeholder</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStakeholder" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlStakeholder_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Company</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompany" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Employee</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEmployees" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-4 mb-2">
                        <div class="row">
                            <%--<label class="col-12">&nbsp;</label>--%>
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
    <CR:CrystalReportViewer ID="rprtSalesActivity" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlStakeholder.ClientID%>').chosen();
            $('#<%=ddlCompany.ClientID%>').chosen();
            $('#<%=ddlEmployees.ClientID%>').chosen();
        }
    </script>
</asp:Content>
