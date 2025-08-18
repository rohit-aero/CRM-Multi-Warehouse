<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" 
    CodeFile="FrmManageOfficeExtensions.aspx.cs" Inherits="Administration_FrmManageOfficeExtensions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
 <div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Manage Office Extensions</h4>
                </div>
            </div>
        </div>
                <div class="row">
                    <div class="col-sm-6 col-md-6 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-2 col-md-2 mb-2">
                                <label>Employee</label>
                            </div>
                            <div class="col-sm-6 col-md mb-2 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookupEmployee" runat="server"  DataTextField="Employee"  DataValueField="EmployeeID" AutoPostBack="True" OnSelectedIndexChanged="ddlLookupEmployee_SelectedIndexChanged">                   
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm col-md col-lg col-xl-auto">
                            <div class="row">
                                <div class="col-auto">                                    
                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave"  runat="server" Text="Save"  OnClick="btnSave_Click"  /> 
                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnAddExt" runat="server" Enabled="false" Text="Add Ext"  OnClick="btnAddExt_Click"  />
                                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</div>
            <div class="col-12">
              <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Add New Employee </h5></div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">First Name*</label>
                           <asp:TextBox CssClass="form-control form-control-sm" ID="txtFName" MaxLength="30" runat="server" autocomplete="off"></asp:TextBox>    
                        </div>
                    </div>
                     <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Last Name</label>
                             <asp:TextBox CssClass="form-control form-control-sm" ID="txtLName" MaxLength="30" runat="server" autocomplete="off"></asp:TextBox>  
                        </div>
                    </div>
                                      <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">     
                                <asp:ListItem Value="-1">Select</asp:ListItem>      
                                <asp:ListItem Value="1" Selected="True">Active</asp:ListItem> 
                                <asp:ListItem Value="0">In-Active</asp:ListItem> 
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="table-responsive">
                    <asp:GridView ID="gvManageOffExt" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True" AutoGenerateColumns="False" DataKeyNames="EmployeeDetailID" OnRowDeleting="gvManageOffExt_RowDeleting" OnRowEditing="gvManageOffExt_RowEditing">
                        <Columns>
                            <asp:BoundField DataField="company" HeaderText="Company" />
                            <asp:BoundField DataField="companyoffice" HeaderText="Office" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                            <asp:BoundField DataField="Fname" HeaderText="First Name" />
                            <asp:BoundField DataField="LName" HeaderText="Last Name" />
                            <asp:BoundField DataField="abbrevation" HeaderText="Abb." />
                            <asp:BoundField DataField="ext" HeaderText="Ext." />
                            <asp:BoundField DataField="Direct" HeaderText="Direct" />
                            <asp:BoundField DataField="cellnumber" HeaderText="Cell Number" />
                            <asp:BoundField DataField="email" HeaderText="E-Mail" />    
                             <asp:BoundField DataField="showext" HeaderText="Show Ext" />                      
                            <asp:TemplateField ItemStyle-CssClass="ws-nowrap" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="btn btn-primary btn-sm" Text="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="Delete" runat="server" OnClientClick="return confirm('Are you sure to delete. ?');" CommandName="Delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                                <HeaderStyle />

                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>
                </div>
            </div>
                          <asp:ModalPopupExtender ID="ModelAddNewEmployee" runat="server" TargetControlID="btnAddExt"
                            PopupControlID="Panel1" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="Panel1" runat="server" CssClass="AddRepModal  bg-white" Width="90%" Height="60%">
                            <div class="position-relative h-500">
                                <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                                    AlternateText="Close Popup" ToolTip="Close Popup" />
                                <div class="modal-body">
                                <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Add New Extension </h5>

                    </div>
                    <div class="col-sm-6 col-md-3 chosenFullWidth">
                        <div class="form-group">
                            <label class="text-danger">Company*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" DataTextField="Company" DataValueField="CompanyID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 chosenFullWidth">
                        <div class="form-group">
                            <label class="text-danger">Office*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOffice" runat="server" AutoPostBack="true" DataTextField="Office" DataValueField="OfficeID" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 chosenFullWidth">
                        <div class="form-group">
                            <label class="text-danger">Department*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDepartment" runat="server" DataTextField="Deparment" DataValueField="DepartmentID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Abbreviation</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAbbriviation" MaxLength="50" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Extension*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtExtension" autocomplete="off" onkeypress="return onlyNumbers(event);" runat="server" MaxLength="3"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Direct</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDirect" onblur="phoneMask(this)" autocomplete="off" onkeypress="return onlyNumbers(event);" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Cell Number</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCellNumber" onblur="phoneMask(this)" autocomplete="off" onkeypress="return onlyNumbers(event);" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>E-Mail</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" oninput="emailMask(this)" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                            <div class="form-group">
                            <label class="input-group-prepend pr-3">Show Ext.</label>
                            <asp:CheckBox ID="chkShowExt" runat="server"></asp:CheckBox>
                        </div>
                    </div>
                </div>
                            </div>
                                </div>
                                <div class="modal-footer d-flex justify-content-start">
                                    <asp:Button CssClass="btn btn-success btn-sm rounded" ID="btnAdd" runat="server" Text="Save" OnClick="btnAdd_Click" />
                                    <asp:Button CssClass="btn btn-danger btn-sm rounded" ID="btnReset" runat="server" Text="Cancel" OnClick="btnReset_Click" />
                                </div>
                            </div>
                        </asp:Panel>
 <asp:HiddenField ID="HfEmployeeID" runat="server" Value="-1" />
<asp:HiddenField ID="HfCheckEmployee" runat="server" Value="-1" />
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
    $('#<%=ddlLookupEmployee.ClientID%>').chosen(); 
    $('#<%=ddlCompany.ClientID%>').chosen(); 
    $('#<%=ddlOffice.ClientID%>').chosen();    
    $('#<%=ddlStatus.ClientID%>').chosen();    
    $('#<%=ddlDepartment.ClientID%>').chosen();  
}
</script>
         <asp:HiddenField ID="HfRowID" runat="server" Value="-1" />
</asp:Content>