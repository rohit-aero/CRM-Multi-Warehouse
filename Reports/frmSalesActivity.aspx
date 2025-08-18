<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmSalesActivity.aspx.cs" Inherits="Reports_frmSalesActivity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-9">
                        <!-- Main content area -->
                        <!-- Your main content here -->
                        <div class="col-md-7 mx-auto">
                            <div class="row pt-3">
                                <div class="col-12">
                                    <h4 class="title-hyphen position-relative mb-3">Sales Followups Report</h4>
                                </div>
                                <%--<div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label id="lblFrom">Followup Date From</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateFrom" TargetControlID="txtDateFrom"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label id="lblTo">Followup Date To</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateTo" TargetControlID="txtDateTo"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group chosenFullWidth">
                                        <label>Project Manager</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectManagers" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID" onchange="showDiv();"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group chosenFullWidth">
                                        <label>Destination Rep</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDestRep" runat="server" DataTextField="SalesRep" DataValueField="RepID" onchange="showDiv();"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group chosenFullWidth">
                                        <label>State</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="State" DataValueField="StateID" onchange="showDiv();"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Filter data on</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDateType" runat="server" onchange="ChangeText();showDiv();">
                                            <asp:ListItem Value="0">Followup Date</asp:ListItem>
                                            <asp:ListItem Value="1">Proposal Date</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-12" style="display: none;">
                                    <div class="form-group srRadiosBtns">
                                        <label>Report Type</label>
                                        <asp:RadioButtonList ID="rdbType" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Selected="True">Done</asp:ListItem>
                                            <asp:ListItem Value="2">Upcoming</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group mb-0 srRadiosBtns">
                                        <div class="input-group input-group-sm d-flex align-items-center">
                                            <div class="input-group-prepend pr-3">Please check applicabale filters</div>
                                            <asp:CheckBox ID="chkAll" runat="server" Text="&nbsp;&nbsp;All" Checked="true" Width="100%" ClientIDMode="Static" />
                                            <asp:CheckBoxList ID="chkProjectStage" CssClass="w-100 sfurTable" Width="100%" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Shown In Reports</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShownInReports" runat="server" onchange="showDiv()">
                                            <asp:ListItem Value="0">All</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnSearchProposal_Click" />
                                    <asp:Button ID="btnSearchProposalExcel" runat="server" CausesValidation="false" CssClass="btn btn-info btn-sm" Text="Export to Excel" OnClick="btnSearchProposalExcel_Click" />
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-3">
                        <!-- Help section on the right -->
                        <div class="row pt-3">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divfollowupdate_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Sales Followups Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12" id="followup" runat="server">
                                </div>
                            </div>
                            <div class="col-12 pt-2" runat="server" id="divProposal_HelpSection" style="display: none">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Sales Followups Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12" id="proposaldate" runat="server">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearchProposal" />
            <asp:PostBackTrigger ControlID="btnSearchProposalExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptSalesRepGroup" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />

    <script type="text/javascript">
        $(function () {
            $('[id*=chkAll]').bind("click", function () {
                console.log('1');
                if ($(this).is(":checked")) {
                    console.log('1');
                    $('[id*=chkProjectStage] input').attr("checked", "checked");
                } else {
                    console.log('2');
                    $('[id*=chkProjectStage] input').removeAttr("checked");
                }
            });
            $("[id*=chkProjectStage] input").bind("click", function () {
                if ($("[id*=chkProjectStage] input:checked").length == $("[id*=chkProjectStage] input").length) {
                    console.log('1');
                    $("[id*=chkAll]").attr("checked", "checked");
                } else {
                    console.log('2');
                    $("[id*=chkAll]").removeAttr("checked");
                }
            });
        });

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
            $('#<%=ddlProjectManagers.ClientID%>').chosen();
            $('#<%=ddlDestRep.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
        }

        function ChangeText() {
            var typename = document.getElementById('<%=ddlDateType.ClientID%>').value;
            if (typename == "0") {
                document.getElementById('lblFrom').innerHTML = "Followup Date From";
                document.getElementById('lblTo').innerHTML = "Followup Date To";
            }
            else {
                document.getElementById('lblFrom').innerHTML = "Proposal Date From";
                document.getElementById('lblTo').innerHTML = "Proposal Date To";
            }
        }

        function showDiv() {
            var getSelectValue = document.getElementById('<%=ddlDateType.ClientID%>').value;
            var projmanager = document.getElementById('<%=ddlProjectManagers.ClientID%>');
            var selectedTextprojmanager = projmanager.options[projmanager.selectedIndex].text;
            var desrep = document.getElementById('<%=ddlDestRep.ClientID%>');
            var selectedTextdesrep = desrep.options[desrep.selectedIndex].text;
            var ddlstate = document.getElementById('<%=ddlState.ClientID%>');
            var selectedTextddlstate = ddlstate.options[ddlstate.selectedIndex].text;
            var ddlshowninreports = document.getElementById('<%=ddlShownInReports.ClientID%>');
                var selectedTextddlshowninreports = ddlshowninreports.options[ddlshowninreports.selectedIndex].text;
                var bindhtml = "";
                if (getSelectValue == "0") {
                    bindhtml += " <ul><li>Date is based on <strong>Followup Date</strong>.</li>";
                }
                else if (getSelectValue == "1") {
                    bindhtml += " <ul><li>Date is based on <strong>Proposal Date</strong>.</li>";
                }
                bindhtml += "<li>Project Manager <strong>" + selectedTextprojmanager + "</strong>.</li>";
                bindhtml += "<li>Destination Rep <strong>" + selectedTextdesrep + "</strong>.</li>";
                bindhtml += "<li>State <strong>" + selectedTextddlstate + "</strong>.</li>";
                bindhtml += "<li>Shown in Reports <strong>" + selectedTextddlshowninreports + "</strong>.</li></ul>";
                if (getSelectValue == "0") {
                    document.getElementById('<%=divfollowupdate_HelpSection.ClientID%>').style.display = "block";
                    document.getElementById('<%=divProposal_HelpSection.ClientID%>').style.display = "none";
                    var followupDiv = document.getElementById('<%= followup.ClientID %>');
                    followupDiv.innerHTML = bindhtml;
                }
                else if (getSelectValue == "1") {
                    document.getElementById('<%=divfollowupdate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divProposal_HelpSection.ClientID%>').style.display = "block";
                var proposaldate = document.getElementById('<%= proposaldate.ClientID %>');
                proposaldate.innerHTML = bindhtml;
            }
            else {
                document.getElementById('<%=divfollowupdate_HelpSection.ClientID%>').style.display = "none";
                document.getElementById('<%=divProposal_HelpSection.ClientID%>').style.display = "none";
            }
    }

    </script>
</asp:Content>
