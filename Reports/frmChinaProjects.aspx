<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmChinaProjects.aspx.cs" Inherits="Reports_frmChinaProjects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
    <div class="row">
        <div class="col-8"> <!-- Main content area -->
            <!-- Your main content here -->
  <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Aerowerks China Projects Report</h4>
            </div>
            <div class="col-12">
                <div class="row">
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>

                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>End Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></asp:CalendarExtender>

                        </div>
                    </div>
                    <div class="col-2">
                        <div class="row chosenFullWidth">
                            <label class="col-12">Mfg Facility</label>
                            <div class="col">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReportType" runat="server" DataTextField="text" DataValueField="id" onchange="showDiv();">
                                    <%--<asp:ListItem Value="0" Selected>All</asp:ListItem>
                                    <asp:ListItem Value="3">India</asp:ListItem>
                                    <asp:ListItem Value="2">China</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group mb-0 flex-column">
                            <label>&nbsp;</label>
                            <div>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnGenrate_Click" />
                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnExportToExcel" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Export To Excel" OnClick="btnExportToExcel_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
      
        <div class="col-4"> <!-- Help section on the right -->
            <div class="row pt-3">
                <div class="d-flex align-items-center mb-2">
                    <h4>
                        <strong>Help Section: </strong>
                    </h4>
                </div>
                <div class="col-12 pt-2" runat="server" id="divmfgfacilityall_HelpSection" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Mfg Facility-All</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Mfg Facility <strong>Canada/China/India/Caddy</strong>.</li> 
                            <li>Date is based on <strong> Ship Date</strong>.</li>                                              
                        </ul>
                    </div>
                </div>  
                 <div class="col-12 pt-2" runat="server" id="divmfgfacilitycanada_HelpSection" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Mfg Facility-Canada</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Mfg Facility<strong> Canada</strong>.</li> 
                            <li>Date is based on <strong> Ship Date</strong>.</li>                                              
                        </ul>
                    </div>
                </div> 
                 <div class="col-12 pt-2" runat="server" id="divmfgfacilitychina_HelpSection" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Mfg Facility-China</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Mfg Facility<strong> China</strong>.</li> 
                            <li>Date is based on <strong> Ship Date</strong>.</li>                                              
                        </ul>
                    </div>
                </div> 
                <div class="col-12 pt-2" runat="server" id="divmfgfacilityindia_HelpSection" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Mfg Facility-India</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Mfg Facility<strong> India</strong>.</li> 
                            <li>Date is based on <strong> Ship Date</strong>.</li>                                              
                        </ul>
                    </div>
                </div> 
                <div class="col-12 pt-2" runat="server" id="divmfgfacilityCaddy_HelpSection" style="display:none">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Mfg Facility-Caddy</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Mfg Facility<strong> Caddy</strong>.</li> 
                            <li>Date is based on <strong> Ship Date</strong>.</li>                                              
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
             <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
 </asp:UpdatePanel>

    <CR:CrystalReportViewer ID="rptSalesUsaCan" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
             console.log('Test');
             var getSelectValue = document.getElementById('<%=ddlReportType.ClientID%>').value;             
             if (getSelectValue == "1")
             {                 
                 document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "none";     
                 document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "block";  
                 document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "none";
                 document.getElementById('<%=divmfgfacilityindia_HelpSection.ClientID%>').style.display = "none"; 
                 document.getElementById('<%=divmfgfacilityCaddy_HelpSection.ClientID%>').style.display = "none";
             }
             else if (getSelectValue == "2") {
                  document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "none";     
                 document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "block";
                 document.getElementById('<%=divmfgfacilityindia_HelpSection.ClientID%>').style.display = "none"; 
                 document.getElementById('<%=divmfgfacilityCaddy_HelpSection.ClientID%>').style.display = "none";
             }
             else if (getSelectValue == "3") {
                  document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "none";     
                 document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "none";
                 document.getElementById('<%=divmfgfacilityindia_HelpSection.ClientID%>').style.display = "block"; 
                 document.getElementById('<%=divmfgfacilityCaddy_HelpSection.ClientID%>').style.display = "none";
             }
             else if (getSelectValue == "4") {
                 document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "none";     
                 document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "none";
                 document.getElementById('<%=divmfgfacilityindia_HelpSection.ClientID%>').style.display = "none"; 
                 document.getElementById('<%=divmfgfacilityCaddy_HelpSection.ClientID%>').style.display = "block";
             }
             else
             {
                 document.getElementById('<%=divmfgfacilityall_HelpSection.ClientID%>').style.display = "block";     
                 document.getElementById('<%=divmfgfacilitycanada_HelpSection.ClientID%>').style.display = "none";  
                 document.getElementById('<%=divmfgfacilitychina_HelpSection.ClientID%>').style.display = "none";
                 document.getElementById('<%=divmfgfacilityindia_HelpSection.ClientID%>').style.display = "none"; 
                 document.getElementById('<%=divmfgfacilityCaddy_HelpSection.ClientID%>').style.display = "none";          
             }
         }
    </script>
</asp:Content>
