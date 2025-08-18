<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="frmEngHoursFilters.aspx.cs" Inherits="ContactManagement_frmSearchCostingProjects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           
                
                <div class="col-12 pt-2 piDiv position-sticky">
                <div class="col-12">
                        
               <%-- Project Info Start --%>
              
<fieldset>
<legend>Engineering Time Sheet Filters</legend>
<div class="row mb-1 customSelects">
<label class="col-xl-2 mb-0">Project Name</label>
<div class="col-xl-10 mb-2">  <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectNo" DataTextField="ProjectName" DataValueField="PNumber" runat="server"></asp:DropDownList></div>
<label class="col-xl-2 mb-0">By Department</label>
<div class="col-xl-10 mb-2"> <asp:DropDownList ID="ddlDepartment" CssClass="form-control form-control-sm" DataValueField="Departmentid" DataTextField="DepartmentName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList></div>
<label class="col-xl-2 mb-0">By Employee</label>
<div class="col-xl-10 mb-2"><asp:DropDownList ID="ddlEmployee" CssClass="form-control form-control-sm" DataValueField="EmployeeID" DataTextField="EmployeeName" runat="server"></asp:DropDownList></div>
<label class="col-xl-2 mb-0">By Nature of Task</label>
<div class="col-xl-10 mb-2"><asp:DropDownList ID="ddlNatureOfTask" CssClass="form-control form-control-sm" runat="server">
                                        <asp:ListItem Value="0">All</asp:ListItem>
                                        <asp:ListItem Value="1">Proposal</asp:ListItem>
                                        <asp:ListItem Value="2">Drawing</asp:ListItem>
                                        <asp:ListItem Value="3">Revit</asp:ListItem>
                                    </asp:DropDownList></div>
<label class="col-xl-2 mb-0">By Cateogy</label>
<div class="col-xl-10 mb-2">
                    <asp:DropDownList ID="ddlCategory" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="1">New</asp:ListItem>
                            <asp:ListItem Value="2">Revision</asp:ListItem>
                            <asp:ListItem Value="3">Correction</asp:ListItem>
                    </asp:DropDownList>
</div>
<div class="offset-xl-2 col-xl-10">
<asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearch" CausesValidation="false" runat="server" Text="Search" OnClick="btnSearch_Click" />        
<asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
<asp:Button CssClass="btn btn-secondary btn-sm" ID="btnExporttoExcel" CausesValidation="false" runat="server" Text="Export to Excel" Enabled="false" OnClick="btnExporttoExcel_Click"  /> 
</div>
</div></fieldset>
        </div>
                    </div>
            <br />
            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvProjectSearch" runat="server"    AutoGenerateColumns="true">                
              </asp:GridView>
        </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnExporttoExcel" />
    </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() != undefined) {
                args.set_errorHandled(true);
            }
        }
     $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
       });
       function PageLoaded(sender, args) {          
           ddl();  
       }
       $.when.apply($, PageLoaded).then(function () {         
           ddl();
       });
        function ddl()
        {
            $('#<%=ddlProjectNo.ClientID%>').chosen();
            $('#<%=ddlDepartment.ClientID%>').chosen();
            $('#<%=ddlEmployee.ClientID%>').chosen();
            $('#<%=ddlNatureOfTask.ClientID%>').chosen();
            $('#<%=ddlCategory.ClientID%>').chosen();
        }
        </script>
</asp:Content>