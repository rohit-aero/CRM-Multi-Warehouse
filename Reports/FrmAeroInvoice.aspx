<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FrmAeroInvoice.aspx.cs" Inherits="Reports_FrmAeroInvoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
             <div class="container">
                 <div class="row">
            <div class="col-9">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Aero Invoice Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row mb-2">
                    <div class="col-12 col-sm-6 col-md-3 col-lg-3">                        
                            <label class="mb-0">Report Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlReportType" onchange="showDiv();">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Proposal Drawings</asp:ListItem>
                                <asp:ListItem Value="2">Shop Drawings</asp:ListItem>
                                <asp:ListItem Value="3">Fabrication</asp:ListItem>
                                 <asp:ListItem Value="4">Revit</asp:ListItem>
                            </asp:DropDownList>                        
                    </div>
                    <div class="col-12 col-sm-6 col-md-3 col-lg-4">                      
                            <asp:Label ID="lblFromDate" runat="server">From Date</asp:Label>
                            <asp:TextBox ID="txtFromDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="fromDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                            </asp:CalendarExtender>                      
                    </div>
                    <div class="col-12 col-sm-4 col-md-3 col-lg-4">                       
                            <asp:Label ID="lblToDate" runat="server">From Date</asp:Label>
                            <asp:TextBox ID="txtToDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="toDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtToDate" TargetControlID="txtToDate">
                            </asp:CalendarExtender>                       
                    </div>
                    <div class="col-auto d-flex align-items-end pt-3">
                        <asp:Button ID="btnPreview" runat="server" Enabled="true" CssClass="btn btn-info btn-sm mr-2" CausesValidation="false" Text="Preview" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnPreview_Click" />
                        <asp:Button ID="btnExportToExcel" runat="server" Enabled="true" CssClass="btn btn-success btn-sm mr-2" CausesValidation="false" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>              
                </div>
             <div class="col-3"> <!-- Help section on the right -->
            <div class="row pt-3">
                <div class="d-flex align-items-center mb-2">
                    <h4>
                        <strong>Help Section: </strong>
                    </h4>
                </div>
                <div class="col-12 pt-2" runat="server" id="divProposalDwgs_HelpSection" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Proposal Drawings Report</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Date Req. Fwd To CAD Team Date</strong>.</li> 
                            <li>Job ID <strong> is Null</strong>.</li>                                                                         
                        </ul>
                    </div>
                </div>  
                <div class="col-12 pt-2" runat="server" id="divShpDwgs_HelpSection" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Shop Drawings Report</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Date Req. Fwd To CAD Team Date</strong>.</li>                           
                            <li>Project Name <strong> is not Null</strong> And Nature of Task is <strong>New J.</strong></li>                                            
                        </ul>
                    </div>
                </div>
                <div class="col-12 pt-2" runat="server" id="divFabrication_HelpSection" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Fabrication Report</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Release Date</strong>.</li>                           
                            <li>Project Name <strong> is not Null</strong>.</li>                                       
                        </ul>
                    </div>
                </div> 
               <div class="col-12 pt-2" runat="server" id="dvRevit" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Revit Report</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Date is based on <strong>Date Req. Fwd To CAD Team Date</strong>.</li>                           
                            <li>Project Name <strong> is not Null </strong> And Nature of Task is <strong>Revit.</strong></li>                                       
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
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptAeroInvoice" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlReportType.ClientID%>').chosen();
        }

         function showDiv()
         {             
             var getSelectValue = document.getElementById('<%=ddlReportType.ClientID%>').value;             
             if (getSelectValue == "1")
             {                 
                 document.getElementById('<%=divProposalDwgs_HelpSection.ClientID%>').style.display = "block";     
                 document.getElementById('<%=divShpDwgs_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=divFabrication_HelpSection.ClientID%>').style.display = "none"; 
                 document.getElementById('<%=dvRevit.ClientID%>').style.display = "none"; 
                 document.getElementById('<%=lblFromDate.ClientID%>').innerHTML = "Date&nbsp;Req.&nbsp;Fwd&nbsp;To&nbsp;CAD&nbsp;Team" + " From&nbsp;Date";
                 document.getElementById('<%=lblToDate.ClientID%>').innerHTML = "Date&nbsp;Req.&nbsp;Fwd&nbsp;To&nbsp;CAD&nbsp;Team" + " To&nbsp;Date";
             }
             else if (getSelectValue == "2") {
                 document.getElementById('<%=divProposalDwgs_HelpSection.ClientID%>').style.display = "none";     
                 document.getElementById('<%=divShpDwgs_HelpSection.ClientID%>').style.display = "block";  
                 document.getElementById('<%=divFabrication_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=dvRevit.ClientID%>').style.display = "none"; 
                 document.getElementById('<%=lblFromDate.ClientID%>').innerHTML = "Date&nbsp;Req.&nbsp;Fwd&nbsp;To&nbsp;CAD&nbsp;Team" + " From&nbsp;Date";
                 document.getElementById('<%=lblToDate.ClientID%>').innerHTML = "Date&nbsp;Req.&nbsp;Fwd&nbsp;To&nbsp;CAD&nbsp;Team" + " To&nbsp;Date";
             }
             else if (getSelectValue == "3") {
                 document.getElementById('<%=divProposalDwgs_HelpSection.ClientID%>').style.display = "none";     
                 document.getElementById('<%=divShpDwgs_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=divFabrication_HelpSection.ClientID%>').style.display = "block";  
                 document.getElementById('<%=dvRevit.ClientID%>').style.display = "none"; 
                 document.getElementById('<%=lblFromDate.ClientID%>').innerHTML = "Released&nbsp;Date" + " From&nbsp;Date";
                 document.getElementById('<%=lblToDate.ClientID%>').innerHTML = "Released&nbsp;Date" + " To&nbsp;Date";
             }
            else if (getSelectValue == "4") {
                 document.getElementById('<%=divProposalDwgs_HelpSection.ClientID%>').style.display = "none";     
                 document.getElementById('<%=divShpDwgs_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=divFabrication_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=dvRevit.ClientID%>').style.display = "block"; 
                 document.getElementById('<%=lblFromDate.ClientID%>').innerHTML = "Date&nbsp;Req.&nbsp;Fwd&nbsp;To&nbsp;CAD&nbsp;Team" + " From&nbsp;Date";
                 document.getElementById('<%=lblToDate.ClientID%>').innerHTML = "Date&nbsp;Req.&nbsp;Fwd&nbsp;To&nbsp;CAD&nbsp;Team" + " To&nbsp;Date";
             }      
             else
             {
                 document.getElementById('<%=divProposalDwgs_HelpSection.ClientID%>').style.display = "none";     
                 document.getElementById('<%=divShpDwgs_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=divFabrication_HelpSection.ClientID%>').style.display = "none";           
                 document.getElementById('<%=lblFromDate.ClientID%>').innerHTML = "From&nbsp;Date&nbsp;";
                 document.getElementById('<%=lblToDate.ClientID%>').innerHTML = "To&nbsp;Date&nbsp;";
             }
         }
    </script>
</asp:Content>
