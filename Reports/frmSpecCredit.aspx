<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmSpecCredit.aspx.cs" Inherits="Reports_frmSpecCredit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">

                    <div class="col-md-12 mx-auto innerMain">
                        <div class="row pt-3 flex-column">
                            <div class="col-12">
                                <h4 class="title-hyphen position-relative mb-3">Aerowerks Spec Credit Reports</h4>
                            </div>
                            <%--            <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-sm-auto">
                                        <div class="form-group">
                                            <label>Start Date</label>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>

                                        </div>
                                    </div>
                                    <div class="col-sm-auto">
                                        <div class="form-group">
                                            <label>End Date</label>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>

                                        </div>
                                    </div>
                                    <div class="col-sm-auto">
                                        <div class="form-group">
                                            <label>Country</label>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-auto">
                                        <div class="form-group mb-0 flex-column">
                                            <label>&nbsp;</label>
                                            <div>
                                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGenrate_Click" />
                                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Text="Export To Excel" OnClick="btnGenerateExcel_Click" />
                                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>

                    <div class="col-6">
                        <!-- Main content area -->
                        <!-- Your main content here -->
                        <div class="row border-top pt-3">
                            <div class="col-12">
                                <h5 class="text-uppercase">Spec Credit Report</h5>
                            </div>
                            <div class="col-sm-12 col-md">
                                <div class="form-group srRadiosBtns">
                                    <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="showDiv()">
                                        <asp:ListItem Value="0" Selected="True">Spec Credit</asp:ListItem>
                                        <asp:ListItem Value="1">Spec Credit Application Pending</asp:ListItem>
                                        <asp:ListItem Value="2">Spec Credit Applied without J#</asp:ListItem>
                                        <asp:ListItem Value="3">Spec Credit Individual Sale Rep Commission Report</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div style="text-align: left; display: none;" id="ShowDiv" runat="server">
                                    <asp:Label ID="lblSalesRepGroup" runat="server" Text="Sales Rep Group:"></asp:Label>

                                    <asp:DropDownList ID="ddlIndividualSalesRep" runat="server">
                                        <asp:ListItem Value="-1">All</asp:ListItem>
                                        <asp:ListItem Value="0">Burlis-Lawson Group</asp:ListItem>
                                        <asp:ListItem Value="1">PMR</asp:ListItem>
                                        <asp:ListItem Value="2">HRI</asp:ListItem>
                                        <asp:ListItem Value="3">PBAC</asp:ListItem>
                                        <asp:ListItem Value="4">Woolsey Associates</asp:ListItem>
                                        <asp:ListItem Value="5">EPI</asp:ListItem>
                                        <asp:ListItem Value="6">KLH</asp:ListItem>
                                        <asp:ListItem Value="7">PMG</asp:ListItem>
                                        <asp:ListItem Value="8">Squier</asp:ListItem>
                                        <asp:ListItem Value="9">Hobart (All Regions)</asp:ListItem>
                                    </asp:DropDownList>
                                    <CR:CrystalReportViewer ID="rptSpecCreditReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-6">
                        <!-- Help section on the right -->
                        <div class="row pt-3">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divSpecCreditReport_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Spec Credit Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li>Projects which has <strong>Spec Credit approved</strong> are shown in the report.</li>
                                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divSpecCreditAppPendingReport_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Spec Credit Application Pending Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li>Projects which has <strong>Spec Credit pending</strong> are shown in the report.</li>
                                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divSpecCreditAppliedWithoutJ_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Spec Credit Applied Without J#</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Proposal Date</strong>.</li>
                                        <li>Prjects which has <strong>Spec Credit Approved/Not Approved/Pending </strong>are shown in the report </li>
                                        <li><strong>Open Proposal Based On</strong> P-Number.</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divSpecCreditIndividualSalsRep_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Spec Credit Individual Sale Rep Commission Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                                        <li>Projects which has <strong>Spec Credit</strong> approved are shown in the report.</li>
                                        <li>Sales Rep Based On <strong>Hobart Branch Company Name</strong>.</li>
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
            <asp:PostBackTrigger ControlID="btnGenerateExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        function showDiv() {
            console.log('Test');
            var getSelectValue = $("input[name='ctl00$ContentPlaceHolder1$rdbList']:checked").val();

            if (getSelectValue == "0") {
                document.getElementById('<%=ShowDiv.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divSpecCreditAppPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditAppliedWithoutJ_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditIndividualSalsRep_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "1") {
                document.getElementById('<%=ShowDiv.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditAppPendingReport_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divSpecCreditAppliedWithoutJ_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditIndividualSalsRep_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "2") {
                document.getElementById('<%=ShowDiv.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditAppPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditAppliedWithoutJ_HelpSection.ClientID%>').style.display = "block";
                document.getElementById('<%=divSpecCreditIndividualSalsRep_HelpSection.ClientID%>').style.display = "none";
            }
            else if (getSelectValue == "3") {
                document.getElementById('<%=ShowDiv.ClientID%>').style.display = "block";
                document.getElementById('<%=divSpecCreditReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditAppPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditAppliedWithoutJ_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditIndividualSalsRep_HelpSection.ClientID%>').style.display = "block";
            }
            else {
                document.getElementById('<%=ShowDiv.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditAppPendingReport_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditAppliedWithoutJ_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divSpecCreditIndividualSalsRep_HelpSection.ClientID%>').style.display = "none";
            }
}

    </script>
</asp:Content>
