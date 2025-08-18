<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmPendingInstallations.aspx.cs" Inherits="Reports_FrmPendingInstallations" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Pending Installation Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-8">
                        <div class="row">
                            <div class="row mx-2">
                                <div class="form-group">
                                     <label>&nbsp;</label></b>
                                    <asp:RadioButtonList ID="rdbDateSettings" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbDateSettings_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="1">&nbsp;All&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">&nbsp;Specify Dates</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label>Installation Start Date From</label>
                                    <asp:TextBox ID="txtDateFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                    </asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtDateFrom" TargetControlID="txtDateFrom">
                                    </asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label>Installation Start Date To</label>
                                    <asp:TextBox ID="txtDateTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                    </asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateTo_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtDateTo" TargetControlID="txtDateTo">
                                    </asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-3">
                                <div class="form-group chosenFullWidth">
                                    <label>Installation Priority</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallationPriority" runat="server">
                                        <asp:ListItem Value="A">All</asp:ListItem>
                                        <asp:ListItem Value="H">High</asp:ListItem>
                                        <asp:ListItem Value="M">Medium</asp:ListItem>
                                        <asp:ListItem Value="L">Low</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-8">
                                <div class="form-group">
                                    <label>By Technician</label>
                                    <asp:ListBox CssClass="form-control form-control-sm" ID="ddlTechinician" runat="server" DataTextField="text" DataValueField="id" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>

                            <div class="col-2" style="display: none;">
                                <div class="form-group">
                                    <label>Installation Commitment</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallationCommitment" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="C">Confirm</asp:ListItem>
                                        <asp:ListItem Value="N">Not Confirm</asp:ListItem>
                                        <asp:ListItem Value="T">Tentative</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-4">
                                <label>&nbsp;</label>
                                <div class="form-group">
                                    <asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';"
                                        Text="Generate Report" OnClick="btnReport_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-4">
                        <div class="row">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Pending Installations</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Project with <strong>Installation By Aerowerks & Supervision Only</strong> are shown in the report.</li>
                                        <li>Date is based on <strong>Installation Start Date</strong>.</li>
                                        <li>Projects with <strong>selected Technician </strong>are shown in the report.</li>
                                        <li>Projects which does not have <strong>Installation Completion Date</strong> are shown in the report.</li>
                                    </ul>
                                </div>
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
            BindDrp();
        }

        $.when.apply($, PageLoaded).then(function () {
            BindDrp();
        });

        function BindDrp() {
            $('#<%=ddlInstallationCommitment.ClientID%>').chosen();
            $('#<%=ddlTechinician.ClientID%>').chosen();
            $('#<%=ddlInstallationPriority.ClientID%>').chosen();
        }
    </script>
</asp:Content>
