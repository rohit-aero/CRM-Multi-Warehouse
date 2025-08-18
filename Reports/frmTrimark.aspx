<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmTrimark.aspx.cs" Inherits="Reports_frmTrimark" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-8">
                        <div class="col-md-auto mx-auto innerMain">
                            <div class="row pt-3 flex-column">
                                <div class="col-12">
                                    <h4 class="title-hyphen position-relative mb-3">Trimark Report</h4>
                                    <%-- <h5 class="text-uppercase">Select Filters</h5>--%>
                                </div>
                                <%--    <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
                                <div class="col-12">
                                    <div class="row">
                                        <div class="col-sm-auto">
                                            <div class="form-group">
                                                <label>Year</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtYear" autocomplete="off" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-auto">
                                            <div class="form-group chosenFullWidth">
                                                <label>Select Quarter</label>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlQuarter" Enabled="false" runat="server">
                                                    <%-- <asp:ListItem Value="-1">Select</asp:ListItem>--%>
                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                    <asp:ListItem Value="1">First Quarter</asp:ListItem>
                                                    <asp:ListItem Value="2">Second Quarter</asp:ListItem>
                                                    <asp:ListItem Value="3">Third Quarter</asp:ListItem>
                                                    <asp:ListItem Value="4">Fourth Quarter</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-auto">
                                            <div class="form-group mb-0 flex-column">
                                                <label>&nbsp;</label>
                                                <div>
                                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnPreview" runat="server" Text="Preview Report" OnClick="btnPreview_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenExcel" runat="server" CausesValidation="false" Text="Export To Excel" OnClick="btnGenExcel_Click" />
                                                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Visible="false" Text="Cancel" OnClick="btnCancel_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row border-top pt-3">
                                <div class="col-12">
                                    <h5 class="text-uppercase">Select Option</h5>
                                </div>
                                <div class="col-sm-12 col-md">
                                    <div class="form-group srRadiosBtns">
                                        <%--  <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
                                        <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="listenabled();showDiv();">
                                            <asp:ListItem Value="1" Selected="True">Gross Purchase</asp:ListItem>
                                            <asp:ListItem Value="2">Rebatable Purchase</asp:ListItem>
                                            <asp:ListItem Value="3">Detailed Rebate Report</asp:ListItem>
                                            <asp:ListItem Value="4">Quarterly Report</asp:ListItem>
                                            <%-- <asp:ListItem Value="5">Summary Report</asp:ListItem>--%>
                                        </asp:RadioButtonList>
                                        <%-- </ContentTemplate>
        <Triggers>
    <asp:PostBackTrigger ControlID="rdbList" />
</Triggers>
        </asp:UpdatePanel>--%>
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
                            <div class="col-12 pt-2" runat="server" id="divGrossPurchase_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Gross Purchase Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>PO Rec. Date</strong>.</li>
                                        <li>Amount Based On <strong>Cash Amount Received</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divRebatablePurchase_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Rebatable Purchase Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li>Amount Based On <strong>Cash Amount Received</strong>.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divDetailedRebate_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Detailed Rebate Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li>Order Belongs To <strong>Aerowerks</strong>. </li>
                                        <li>Projects which are <strong>Active/Confirmed</strong> are shown in the reports.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divQuarterly_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Quarterly Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li>Order Belongs To <strong>Aerowerks</strong>. </li>
                                        <li>Projects which are <strong>Active/Confirmed</strong> are shown in the reports.</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPreview" />
            <asp:PostBackTrigger ControlID="btnGenExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptTrimark" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script language="javascript" type="text/javascript">
        function listenabled() {
            var checked_radio = $("[id*=rdbList] input:checked");
            var ddlQuarter = document.getElementById('<%=ddlQuarter.ClientID%>');
            var value = checked_radio.val();
            if (value == "1" || value == "2" || value == "3" || value == "5") {
                ddlQuarter.disabled = true;
            }
            else {
                ddlQuarter.disabled = false;
            }
        }
        function showDiv() {
            console.log('Test');
            var getSelectValue = $("input[name='ctl00$ContentPlaceHolder1$rdbList']:checked").val();

            if (getSelectValue == "1") {
                document.getElementById('<%=divGrossPurchase_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divRebatablePurchase_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divDetailedRebate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divQuarterly_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "2") {
                document.getElementById('<%=divGrossPurchase_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divRebatablePurchase_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divDetailedRebate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divQuarterly_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "3") {
                document.getElementById('<%=divGrossPurchase_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divRebatablePurchase_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divDetailedRebate_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divQuarterly_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "4") {
                document.getElementById('<%=divGrossPurchase_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divRebatablePurchase_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divDetailedRebate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divQuarterly_HelpSection.ClientID%>').style.display = "block";
            }
            else {
                document.getElementById('<%=divGrossPurchase_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divRebatablePurchase_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divDetailedRebate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divQuarterly_HelpSection.ClientID%>').style.display = "none";
            }
}
    </script>
</asp:Content>
