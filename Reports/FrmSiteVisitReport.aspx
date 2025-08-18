<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/Main.master" CodeFile="FrmSiteVisitReport.aspx.cs" Inherits="Reports_FrmSiteVisitReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content_SiteVisitReport" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SiteVisitReport" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Site Visit Report Filters</h5>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>By Employee</label>
                            <asp:DropDownList ID="ddlEmployee" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Site Visit From Date</label>
                            <asp:TextBox ID="txtFromDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtFromDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Site Visit To Date</label>
                            <asp:TextBox ID="txtToDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtToDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtToDate" TargetControlID="txtToDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-3" style="display: none;">
                        <div class="form-group">
                            <label>By Region</label>
                            <asp:DropDownList CssClass="form-control form-control-sm " ID="ddlRegion" DataTextField="Region" DataValueField="RegionID" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm " ID="ddlState" DataTextField="State" DataValueField="StateID" runat="server" />
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>By PNumber/JobID</label>
                            <%--<asp:DropDownList ID="ddlJobNo" runat="server" DataTextField="PNameForReport" DataValueField="PNumber" CssClass="form-control form-control-sm"></asp:DropDownList>--%>
                            <asp:TextBox ID="txtSearch" CssClass="form-control form-control-sm" autocomplete="off" runat="server">
                            </asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-md-auto">
                                <asp:Button CssClass="btn btn-secondary btn-sm" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnExportToExcel" runat="server" Enabled="false" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Export To Excel" OnClick="btnGenerateExcel" />
                                <asp:Button ID="btnExportToPDF" runat="server" Enabled="false" CssClass="btn btn-info btn-sm" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" Text="Preview Report" OnClick="btnExportToPDF_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                            </div>
                            <div class="col-md justify-content-center">
                                <strong class="text-center">
                                    <asp:Label CssClass="alert alert-success d-block py-1" ID="lblRecordsCount" runat="server" Text="Label" Visible="false"></asp:Label></strong>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 mt-3">
                <div class="table-responsive" style="max-height: 750px">
                    <asp:GridView ID="gvSearch" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="table mainGridTable table-sm mb-0"
                        EnableModelValidation="True" AutoGenerateColumns="false" AllowSorting="true" OnSorting="gvSearch_Sorting">
                        <Columns>
                            <asp:BoundField DataField="Site Visit Date" HeaderText="Site Visit Date" SortExpression="Site Visit Date" />
                            <asp:BoundField DataField="PNumber" HeaderText="P#" SortExpression="PNumber" />
                            <asp:BoundField DataField="Project Name" HeaderText="Project Name" SortExpression="Project Name" ItemStyle-Width="15%" />
                            <asp:BoundField DataField="Requestor" HeaderText="Requestor" SortExpression="Requestor" />
                            <asp:BoundField DataField="Employee Names" HeaderText="Employees" SortExpression="Employee Names" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Next Visit Date" HeaderText="Next Visit Date" SortExpression="Next Visit Date" />
                            <asp:BoundField DataField="Site Contact Name" HeaderText="Site Contact Name" SortExpression="Site Contact Name" />
                            <asp:BoundField DataField="Site Contact Number" HeaderText="Site Contact Number" SortExpression="Site Contact Number" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="20%" />
                        </Columns>
                        <HeaderStyle ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
            <asp:PostBackTrigger ControlID="btnExportToPdf" />
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
            $('#<%=ddlEmployee.ClientID%>').chosen();
            $('#<%=ddlRegion.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
        }
    </script>
    <CR:CrystalReportViewer ID="rptSiteVisitReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
