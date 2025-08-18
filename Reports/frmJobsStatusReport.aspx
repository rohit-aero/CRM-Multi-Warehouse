<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmJobsStatusReport.aspx.cs" Inherits="Reports_frmJobsStatusReport" %>

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
                            <h4 class="title-hyphen position-relative">Project Status Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2 col-sm-2 col-md-2 col-lg-1">
                        <div class="form-group">
                            <label>By Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectStatus" runat="server">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="Behind">Behind</asp:ListItem>
                                <asp:ListItem Value="On Track">On Track</asp:ListItem>
                                <asp:ListItem Value="Ahead">AHead</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <label>By Project Number</label>
                             <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectNumber" runat="server" DataTextField="Project Number" DataValueField="Project Number">                    
                            </asp:DropDownList>
                        </div>
                    </div> 
                   <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="form-group">
                            <label>By Project Manager</label>
                             <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectManager" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID">                    
                            </asp:DropDownList>
                        </div>
                    </div>
                    
 
                    <div class="col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Ship From Date</label>
                              <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)" autocomplete="off" ></asp:TextBox>
                            <asp:CalendarExtender ID="caltxtFrmDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div> 
                     <div class="col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Ship To Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" autocomplete="off"  OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="caltxtToDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-5 col-md-3 col-lg-5">
                        <div class="form-group">
                            <label>By Project Name</label>
                             <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectName" runat="server" DataTextField="Project Name" DataValueField="Project Name">                    
                            </asp:DropDownList>
                        </div>
                    </div> 
                </div>
                <div class="row">
                    <div class="col-md justify-content-center">
                        <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-primary btn-sm" Text="Generate" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnGenerate_Click"    />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />

                    </div>
                </div>
            </div>
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
                    $('#<%=ddlProjectStatus.ClientID%>').chosen();
                    //ddlContainerNo
                    $('#<%=ddlProjectNumber.ClientID%>').chosen();      
                    $('#<%=ddlProjectName.ClientID%>').chosen();   
                    $('#<%=ddlProjectManager.ClientID%>').chosen();         
                }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerate" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
