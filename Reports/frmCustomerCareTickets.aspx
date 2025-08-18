<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="frmcustomercaretickets.aspx.cs" Inherits="Reports_frmcustomercaretickets" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Ticket Summary</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                        <div class="form-group">
                            <label>Project Name</label>
                            <%--<asp:TextBox CssClass="form-control form-control-sm" ID="txtProjectName" AutoComplete="off" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlProjectNameList" DataTextField="ProjectName" DataValueField="ProjectName">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Ticket #</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTicketNo" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Category</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCategory" runat="server" DataTextField="CategoryName" DataValueField="Categoryid"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Issue Category</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlIssueCategory" runat="server" DataTextField="IssueCategoryName" DataValueField="IssueCategoryid"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Assigned To</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAssignedto" runat="server" DataTextField="FirstName" DataValueField="EmployeeID">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Sushant</asp:ListItem>
                                <asp:ListItem Value="2">Sunny</asp:ListItem>
                                <asp:ListItem Value="3">Himanshu</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Sub Assembly</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSubAssembly" runat="server" DataTextField="SubAssemblyname" DataValueField="SubAssemblyid"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Conveyor Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConveyorType" runat="server" DataTextField="ConveyorType" DataValueField="ConveyorID"></asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" DataTextField="StatusName" DataValueField="Statusid"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Service PO#</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPO" AutoComplete="off" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Open From Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtfromdate" runat="server" AutoComplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtfromdate" TargetControlID="txtfromdate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Open To Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txttodate" AutoComplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="txttodate" TargetControlID="txttodate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Project Manager</label>
                            <asp:DropDownList ID="ddlProjectManager" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID"
                                CssClass="form-control form-control-sm">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-md-auto">
                                <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-secondary btn-sm" Text="Search" OnClick="btnSearchProposal_Click" />
                                <asp:Button ID="btnClearProposal" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click" />
                                <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Enabled="false" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                        <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvSummary" BackColor="White" BorderColor="#999999" BorderWidth="1px"
                            CellPadding="3" BorderStyle="Solid"
                            GridLines="Vertical" Width="100%" ForeColor="Black" Style="font-size: small"
                            runat="server" AutoGenerateColumns="true" EnableModelValidation="True" EmptyDataText="No Matching Records Found !!!">
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <CR:CrystalReportViewer ID="rptTickets" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
                    $('#<%=ddlCategory.ClientID%>').chosen();
                    $('#<%=ddlIssueCategory.ClientID%>').chosen();
                    $('#<%=ddlProjectNameList.ClientID%>').chosen();
                    $('#<%=ddlProjectManager.ClientID%>').chosen();
                    $('#<%=ddlAssignedto.ClientID%>').chosen();
                    $('#<%=ddlSubAssembly.ClientID%>').chosen();
                    $('#<%=ddlConveyorType.ClientID%>').chosen();
                    $('#<%=ddlStatus.ClientID%>').chosen();

                }
            </script>
            <asp:HiddenField ID="hfjobname" runat="server"></asp:HiddenField>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
            <asp:PostBackTrigger ControlID="btnGenrate" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
