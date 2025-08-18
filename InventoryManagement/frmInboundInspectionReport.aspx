<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="frmInboundInspectionReport.aspx.cs" Inherits="InventoryManagement_frmInboundInspectionReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col pt-2 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Inbound Inspection Summary Report</h4>
                            <div class="col-sm-6 justify-content-center" id="dvMsg" runat="server" visible="false">
                                <strong class="text-center">
                                    <asp:Label runat="server" CssClass="alert alert-success d-block py-1 mb-0" ID="lblMsg"></asp:Label></strong>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row pb-3">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                        <div class="row">
                            <div class="col-3">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Product Code</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductCodeLookUp" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlProductCodeLookUp_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Part No/Description</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartNo" runat="server" DataTextField="PartDes" DataValueField="PartID" AutoPostBack="true" OnSelectedIndexChanged="ddlPartNo_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-3">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Status</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                            <asp:ListItem Value="0">All</asp:ListItem>
                                            <asp:ListItem Value="1">Approved</asp:ListItem>
                                            <asp:ListItem Value="2">Rejected</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <label class="mb-0">&nbsp;</label>
                            </div>
                            <div class="col-auto">
                                <asp:Button ID="btnGenerateReport" runat="server" CausesValidation="false" CssClass="btn btn-success btn-sm" Text="Generate Report" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGenerateReport_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>

                </div>





            </div>
            <CR:CrystalReportViewer ID="rptRequisition" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerateReport" />
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
            $('#<%=ddlPartNo.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlProductCodeLookUp.ClientID%>').chosen();
        }
    </script>

</asp:Content>

