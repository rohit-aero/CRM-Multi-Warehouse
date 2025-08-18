<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmOpenProposals.aspx.cs" Inherits="Reports_frmOpenProposals" %>

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
                                    <h4 class="title-hyphen position-relative mb-3">Scheduled Followups Report</h4>
                                </div>
                                <%--     <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Project Manager</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectManagers" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID" onchange="showDiv();"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6" style="display: none">
                                    <div class="form-group">
                                        <label>Project Stage</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectStage" runat="server" DataTextField="bidname" DataValueField="bidid" onchange="showDiv();"></asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Destination Rep</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDestRep" runat="server" DataTextField="SalesRep" DataValueField="RepID" onchange="showDiv();"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Schedule Date From</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtProposalShipDateFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProposalShipDateFrom" TargetControlID="txtProposalShipDateFrom"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Schedule Date To</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtProposalShipDateTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProposalShipDateTo" TargetControlID="txtProposalShipDateTo"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>State</label>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="State" DataValueField="StateID" onchange="showDiv();"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group srRadiosBtns">
                                        <label>Please check applicabale filters</label>
                                        <asp:CheckBox ID="chkAll" runat="server" Text="&nbsp;&nbsp;All" Checked="true" Width="100%" ClientIDMode="Static" />
                                        <asp:CheckBoxList ID="chkProjectStage" class="w-100 sfurTable" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnSearchProposal_Click" />
                                    <asp:Button ID="btnExportExcel" runat="server" CssClass="btn btn-info btn-sm" Text="Export to Excel" CausesValidation="false" OnClick="btnExportExcel_Click" />
                                    <asp:Button ID="btnClearProposal" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click" />
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
                            <div class="col-12 pt-2" runat="server" id="divfollowupdate_HelpSection">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Scheduled Followups Report</strong>
                                    </h5>
                                </div>
                                <div class="col-12" id="followup" runat="server">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearchProposal" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <%--</div>--%>
    <CR:CrystalReportViewer ID="rptSalesRepGroup" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("[id*=chkAll]").bind("click", function () {
                if ($(this).is(":checked")) {
                    $("[id*=chkProjectStage] input").attr("checked", "checked");
                } else {
                    $("[id*=chkProjectStage] input").removeAttr("checked");
                }
            });
            $("[id*=chkProjectStage] input").bind("click", function () {
                if ($("[id*=chkProjectStage] input:checked").length == $("[id*=chkProjectStage] input").length) {
                    $("[id*=chkAll]").attr("checked", "checked");
                } else {
                    $("[id*=chkAll]").removeAttr("checked");
                }
            });
        });

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
            DDL(); // Call DDL here to ensure it runs on page load
        });

        function PageLoaded(sender, args) {
            DDL();
        }

        function DDL() {
            $('#<%=ddlProjectManagers.ClientID%>').chosen();
            $('#<%=ddlProjectStage.ClientID%>').chosen();
            $('#<%=ddlDestRep.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
        }

        function showDiv() {
            var projmanager = document.getElementById('<%=ddlProjectManagers.ClientID%>');
            var selectedTextprojmanager = projmanager.options[projmanager.selectedIndex].text;
            var desrep = document.getElementById('<%=ddlDestRep.ClientID%>');
            var selectedTextdesrep = desrep.options[desrep.selectedIndex].text;
            var ddlstate = document.getElementById('<%=ddlState.ClientID%>');
            var selectedTextddlstate = ddlstate.options[ddlstate.selectedIndex].text;
            var bindhtml = "";
            bindhtml += " <ul><li>Date is based on <strong>Schedule Date</strong>.</li>";
            bindhtml += "<li>Project Manager <strong>" + selectedTextprojmanager + "</strong>.</li>";
            bindhtml += "<li>Destination Rep <strong>" + selectedTextdesrep + "</strong>.</li>";
            bindhtml += "<li>State <strong>" + selectedTextddlstate + "</strong>.</li>";
            var followupDiv = document.getElementById('<%= followup.ClientID %>');
            followupDiv.innerHTML = bindhtml;
        }
    </script>
</asp:Content>
