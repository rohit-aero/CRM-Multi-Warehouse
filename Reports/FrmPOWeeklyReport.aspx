<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmPOWeeklyReport.aspx.cs" Inherits="Reports_FrmPOWeeklyReport" %>

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
                                    <h4 class="title-hyphen position-relative mb-3">Aerowerks Upcoming POs Report</h4>
                                </div>
                                <div class="col-12">
                                    <div class="row">
                                        <div class="col-4">
                                            <div class="form-group">
                                                <label>Start Date</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>

                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div class="form-group">
                                                <label>End Date</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></asp:CalendarExtender>

                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div class="form-group chosenFullWidth">
                                                <label>Project Manager</label>
                                                <asp:DropDownList CssClass="form-control form-control-sm pt-3" runat="server" ID="ddlProjectManager" DataTextField="text" DataValueField="id">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-12 pt-2">
                                            <div class="form-group mb-0 flex-column">
                                                <div>
                                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnGenrate_Click" />
                                                    <%--<asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Text="Export to Excel" OnClick="btnGenerateExcel_Click" />--%>
                                                    <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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
                            <div class="col-12 pt-2" runat="server" id="divUpcomingPOs_HelpSection">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Aerowerks Upcoming POs Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>PO Rec. Date</strong>.</li>
                                        <li>Purchase Order Received <strong>When PO Rec. Date is not null</strong>.</li>
                                        <li>Purchase Order Expecting When Bid Project Not In <strong>(Won/Lost/Dead)</strong> and 
                                <strong>PO.Rec Date</strong> is not null.</li>
                                        <li>Hot Projects When Bid Project Not In <strong>(Won/Lost/Dead)</strong> and <strong>(Net Eq. Price + Freight + Installation) >= 75000</strong> and <strong>Expected PO Rec. Date</strong> is null.</li>
                                        <li>Dead Projects When Bid Project is <strong>(Lost/Dead)</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>




        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenrate" />
        </Triggers>
    </asp:UpdatePanel>

    <CR:CrystalReportViewer ID="rptSalesUsaCan" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
        }
    </script>
</asp:Content>
