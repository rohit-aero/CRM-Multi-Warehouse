<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmAeroOpenProposals.aspx.cs" Inherits="Reports_frmAeroOpenProposals" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-8">
                        <!-- Main content area -->
                        <!-- Your main content here -->
                        <div class="col-md-auto mx-auto innerMain">
                            <div class="row pt-3 flex-column">
                                <div class="col-12">
                                    <h4 class="title-hyphen position-relative mb-3">Aerowerks Open Proposals Report</h4>
                                </div>
                                <div class="col-12">
                                    <div class="row">
                                        <div class="col-sm-auto" id="proFrmDate" runat="server">
                                            <div class="form-group">
                                                <label id="lblFrom">Proposal Date From</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtProposalDateFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProposalDateFrom" TargetControlID="txtProposalDateFrom"></asp:CalendarExtender>

                                            </div>
                                        </div>
                                        <div class="col-sm-auto" id="proToDate" runat="server">
                                            <div class="form-group">
                                                <label id="lblTo">Proposal Date To</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtProposalDateTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProposalDateTo" TargetControlID="txtProposalDateTo"></asp:CalendarExtender>

                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-4 col-md-3 col-lg-6">
                                            <div class="form-group">
                                                <label id="lblRepGroup">Rep Group</label>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRepGroup" runat="server" AutoComplete="off" DataTextField="RepGroup" DataValueField="RepGroupID"></asp:DropDownList>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12 col-sm-4 col-md-3 col-lg-6">
                                            <div class="form-group srRadiosBtns">
                                                <label></label>
                                                <asp:RadioButtonList ID="rdbOptions" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="1" Selected="True">Open Proposals</asp:ListItem>
                                                    <asp:ListItem Value="2">Proposals With Job #</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>

                                        <div class="col-12 pt-2">
                                            <div class="form-group mb-0 flex-column">
                                                <div>
                                                    <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnSearchProposal_Click" />
                                                    <asp:Button ID="btnClearProposal" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-4">
                        <!-- Help section on the right -->
                        <div class="row pt-3">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divProposal_HelpSection">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Aerowerks Open Proposals Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Proposal Date</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>




        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearchProposal" />
        </Triggers>
    </asp:UpdatePanel>

    <CR:CrystalReportViewer ID="rptSalesRepGroup" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False"
        EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlRepGroup.ClientID%>').chosen();
        }
    </script>
</asp:Content>
