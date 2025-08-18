<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmCaddyFilterData.aspx.cs" Inherits="CADDY_FrmCaddyFilterData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 border-bottom piDiv position-sticky py-3">
                                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Filter Data</h4>
                            <div class="col-sm-6 justify-content-center" id="dvMsg" runat="server" visible="false">
                                <strong class="text-center">
                                    <asp:Label runat="server" CssClass="alert alert-success d-block py-1 mb-0" ID="lblMsg"></asp:Label></strong>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                   
<%--                    <div class="col-12">
                        <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                    </div>--%>
                    <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Job No</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobNo" runat="server" DataTextField="JobNo" DataValueField="ProjectID">
                            </asp:DropDownList>
                        </div>
                    </div>
                  <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Job Name</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobName" runat="server" DataTextField="JobName" DataValueField="ProjectID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Job Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobType" runat="server" DataTextField="JobType" DataValueField="JobTypeid">
                            </asp:DropDownList>
                        </div>
                    </div>
                 <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Project Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectType" runat="server" DataTextField="ProjectTypeName" DataValueField="ProjectTypeID">
                            </asp:DropDownList>
                        </div>
                    </div>
                  <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Project Manager Caddy</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPMCaddy" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID">
                            </asp:DropDownList>
                        </div>
                    </div>

                  <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Nature of Task</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNature" runat="server">
                               <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">New</asp:ListItem>
                                <asp:ListItem Value="2">Revision</asp:ListItem>
                                <asp:ListItem Value="3">Correction</asp:ListItem>
                                <asp:ListItem Value="4">Revision A</asp:ListItem>
                                <asp:ListItem Value="5">Revision B</asp:ListItem>
                                <asp:ListItem Value="6">Revision C</asp:ListItem>
                                <asp:ListItem Value="7">Revision D</asp:ListItem>
                                <asp:ListItem Value="8">Revision E</asp:ListItem>
                                <asp:ListItem Value="9">Revision F</asp:ListItem>
                                <asp:ListItem Value="10">Revision G</asp:ListItem>
                                <asp:ListItem Value="11">Revision H</asp:ListItem>
                                <asp:ListItem Value="12">Revision I</asp:ListItem>
                                <asp:ListItem Value="13">Revision J</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                  <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" DataTextField="name" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>
                   <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Req. Forward To India From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtReqForwToIndiaFrom" runat="server" autocomplete="off">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="caltxtReqForwToIndiaFrom" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqForwToIndiaFrom" TargetControlID="txtReqForwToIndiaFrom">
                            </asp:CalendarExtender>  
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Req. Forward To India To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtReqForwToIndiaTo" runat="server" autocomplete="off">
                            </asp:TextBox>
                          <asp:CalendarExtender ID="caltxtReqForwToIndiaTo" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqForwToIndiaTo" TargetControlID="txtReqForwToIndiaTo">
                            </asp:CalendarExtender>  
                        </div>
                    </div>
                <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Sent To Caddy From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSendToCaddyFrom" runat="server" autocomplete="off">
                            </asp:TextBox>
                   <asp:CalendarExtender ID="caltxtSendToCaddyFrom" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtSendToCaddyFrom" TargetControlID="txtSendToCaddyFrom">
                            </asp:CalendarExtender>  
                        </div>
                    </div>
                                    <div class="col-sm-2 col-md-2">
                        <div class="form-group">
                            <label>Sent To Caddy To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSendToCaddyTo" runat="server" autocomplete="off">
                            </asp:TextBox>
                                   <asp:CalendarExtender ID="caltxtSendToCaddyTo" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtSendToCaddyTo" TargetControlID="txtSendToCaddyTo">
                            </asp:CalendarExtender>  
                        </div>
                    </div>
                    <div class="col-sm">
                        <div class="row">
                            <label class="col-12">&nbsp;</label>
                            <div class="col-12">
                                <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-success btn-sm" Text="Generate" OnClick="btnSearchProposal_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';"  />                              
                                <asp:Button ID="btnClearProposal" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click"  />
                            </div>
                        </div>
                    </div>
                </div>
            </div>           
            <div class="col-12 pt-3">
        <div class="table-responsive">
            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvSearch" runat="server" AutoGenerateColumns="False"
                EnableModelValidation="True" EmptyDataText="Part not Found">
           
            </asp:GridView>
        </div>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearchProposal" />
        </Triggers>
    </asp:UpdatePanel>
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
            $('#<%=ddlJobNo.ClientID%>').chosen();
            $('#<%=ddlJobName.ClientID%>').chosen();
             $('#<%=ddlJobType.ClientID%>').chosen();
            $('#<%=ddlProjectType.ClientID%>').chosen();           
            $('#<%=ddlPMCaddy.ClientID%>').chosen();
            $('#<%=ddlNature.ClientID%>').chosen();
             $('#<%=ddlStatus.ClientID%>').chosen();
        }
    </script>
   <CR:CrystalReportViewer ID="rptTrimark" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>