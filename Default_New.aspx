<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Default_New.aspx.cs" Inherits="_Default_New" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
 <asp:UpdatePanel ID="UpdatePanel11" runat="server">
  <ContentTemplate>
    <div class="col-sm col-md-12">       
                 <div class="row">
                    <div class="col-12">
                        <h5 class="title-hyphen position-relative mb-3">Search Ext.</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Look Up Company</label>
                           <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookupCompany" runat="server" DataTextField="Company" DataValueField="CompanyID" AutoPostBack="true" OnSelectedIndexChanged="ddlLookupCompany_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>       
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Office</label>
                            <asp:DropDownList CssClass="form-control form-control-sm wide-dropdown" ID="ddlLookUpOffice" runat="server" DataTextField="Office" DataValueField="OfficeID" AutoPostBack="true" OnSelectedIndexChanged="ddlLookUpOffice_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Department</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookupDepartment" runat="server" DataTextField="Department" DataValueField="DepartmentID" AutoPostBack="true" OnSelectedIndexChanged="ddlLookupDepartment_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Employee</label>
                             <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookupEmployee" runat="server" DataTextField="Employee" DataValueField="EmployeeID" AutoPostBack="true" OnSelectedIndexChanged="ddlLookupEmployee_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Extension</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlExtension" runat="server" DataTextField="Extension" DataValueField="EmployeeDetailID"  AutoPostBack="true" OnSelectedIndexChanged="ddlExtension_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>

                 </div> 
                 <div class="row">
                    <div class="col-md-6 justify-left">             
                         <asp:Button CssClass="btn btn-primary btn-sm" ID="btnExportDirToExcel" runat="server" CausesValidation="false" Text="Export Directory to Excel" OnClick="btnExportDirToExcel_Click" />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                    <div class="col-md-4 justify-left">
                    <strong class="text-center">
                            <asp:Label CssClass="alert alert-success d-block py-1" ID="lblShowRecords" runat="server" Text="Label" Visible="false"></asp:Label>
                    </strong>
                </div>
                </div><br />
               <div class="table-responsive">
                   <asp:GridView ID="gvManageOffExt" runat="server" AutoGenerateColumns="False"  BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="3" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="100%"
                            CssClass="table mainGridTable table-sm" Style="font-size: small" AllowSorting="True"  
                            OnSorting="gvManageOffExt_Sorting" BackColor="White" BorderColor="#999999">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>                               
                                 <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OfficeExt" HeaderText="Office" SortExpression="OfficeExt">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>                                 
                                <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Direct" HeaderText="Direct" SortExpression="Direct">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CellNumber" HeaderText="Cell Number" SortExpression="CellNumber">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                               <asp:BoundField DataField="Email" HeaderText="E-Mail" SortExpression="Email">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>                    
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
               </div>
               </div>       
 </ContentTemplate>              
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
                $('#<%=ddlLookupCompany.ClientID%>').chosen();
                $('#<%=ddlLookUpOffice.ClientID%>').chosen();
                $('#<%=ddlLookupDepartment.ClientID%>').chosen();
                $('#<%=ddlExtension.ClientID%>').chosen();
                $('#<%=ddlLookupEmployee.ClientID%>').chosen();  
            }
    </script>    
</asp:Content>