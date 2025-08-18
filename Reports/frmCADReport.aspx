<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="frmCADReport.aspx.cs" Inherits="Reports_frmCADReport" %>

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
                            <h4 class="title-hyphen position-relative">CAD Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-3" style="display: none;">
                        <div class="form-group">
                            <label>Date Req. Forward To CAD Team From</label>
                            <asp:TextBox ID="txtReportDateFrom" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReportDateFromExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReportDateFrom" TargetControlID="txtReportDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-3" style="display: none;">
                        <div class="form-group">
                            <label>Date Req. Fwd To CAD Team To</label>
                            <asp:TextBox ID="txtReportDateTo" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReportDateToExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReportDateTo" TargetControlID="txtReportDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Project Manager</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlProjectManagerList" DataTextField="EmployeeName" DataValueField="EmployeeID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Project Engineer</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlProjectEngineer" DataTextField="FirstName" DataValueField="EmployeeID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Project Name</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlProjectList" DataTextField="PName" DataValueField="PNumber">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Nature of Task</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlNatureOfTaskList" DataTextField="Task" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlStatusList" DataTextField="Status" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-md-auto">
                            <asp:Button CssClass="btn btn-secondary btn-sm" ID="btnGenrate" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                            <asp:Button ID="btnExportToExcel" runat="server" Enabled="false" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Export To Excel" OnClick="btnGenerateExcel" />
                            <asp:Button ID="btnExportToPDF" runat="server" Enabled="false" CssClass="btn btn-info btn-sm" CausesValidation="false" Text="Export To PDF" OnClick="btnExportToPDF_Click" />
                        </div>
                        <div class="col-md justify-content-center">
                            <strong class="text-center">
                                <asp:Label CssClass="alert alert-success d-block py-1" ID="lblRecordsCount" runat="server" Text="Label" Visible="false"></asp:Label></strong>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="col">
                    <asp:GridView ID="gvDailyProjectReport" runat="server" CssClass="table mainGridTable table-sm mb-0"
                        AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound" OnRowCreated="gvDailyProjectReport_RowCreated">
                        <Columns>
                            <%-- <asp:TemplateField  HeaderText="Sr No">
                                    <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StatusID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project #" SortExpression="Project #">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjectNo" runat="server" Text='<%# Eval("ProjectNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Name" SortExpression="Project Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblprojectDescription" runat="server" Text='<%# Eval("ProjectDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nature of Task" SortExpression="Nature of Task">
                                <ItemTemplate>
                                    <asp:Label ID="lblprojectManager" runat="server" Text='<%# Eval("NatureOfTask") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Req. By Customer" SortExpression="Date Req. By Customer">
                                <ItemTemplate>
                                    <asp:Label ID="lblReqByRCD" runat="server" Text='<%# Eval("ReqByRCD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Req. Forward To CAD Team" SortExpression="Date Req. Forward To CAD Team">
                                <ItemTemplate>
                                    <asp:Label ID="lblSentToCAD" runat="server" Text='<%# Eval("SentToCAD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Manager" SortExpression="Project Manager">
                                <ItemTemplate>
                                    <asp:Label ID="lblprojectManager" runat="server" Text='<%# Eval("ProjectManager") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Engineer" SortExpression="Project Engineer">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjectEngineer" runat="server" Text='<%# Eval("ProjectEngineer") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Project Sent To Customer" SortExpression="Date Project Sent To Customer">
                                <ItemTemplate>
                                    <asp:Label ID="lblSentToRCD" runat="server" Text='<%# Eval("SentToRCD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <%-- </div>--%>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
            <asp:PostBackTrigger ControlID="btnExportToPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptCADReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlProjectManagerList.ClientID%>').chosen();
            $('#<%=ddlProjectEngineer.ClientID%>').chosen();
            $('#<%=ddlNatureOfTaskList.ClientID%>').chosen();
            $('#<%=ddlProjectList.ClientID%>').chosen();
            $('#<%=ddlStatusList.ClientID%>').chosen();
        }
    </script>
</asp:Content>
