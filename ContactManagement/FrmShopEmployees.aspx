<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false"  AutoEventWireup="true"  CodeFile="FrmShopEmployees.aspx.cs" Inherits="ContactManagement_FrmShopEmployees" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
<asp:UpdatePanel ID="UpdatePanel11" runat="server">
     <Triggers>
     <asp:PostBackTrigger ControlID="btnSave"  />   
          
    
 </Triggers>
<ContentTemplate>
<asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
<asp:HiddenField ID="HfFileUpload" runat="server" Value="-1" />
    <asp:HiddenField ID="HfSavePath" runat="server" Value="-1" />

 <div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Shop Employees Information</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                <div class="row">
                    <div class="col-sm-auto col-md-auto mb-3"><label class="mb-0">Employees</label></div>
                    <div class="col-sm col-md mb-3 chosenFullWidth">
                     <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEmployee" runat="server" DataTextField="EmployeeName" DataValueField="Employeeid" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                        </asp:DropDownList> 
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg col-xl-auto">
                <div class="row">
                    <div class="col-auto">
                        <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" CausesValidation="false" OnClick="btnSave_Click"  />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  />
                    </div>                  
                </div>
            </div>
</div>
     </div>
<div class="col-12">
<div class="row pt-3">
<div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
<div class="col-12"><h5 class="text-uppercase">Basic Details</h5></div>
</div>

    <div class="row">
    <div class="col-md-8">
     <div class="row">  
<div class="col-sm-3 col-md-3">
<div class="form-group">
<label>First Name*</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtFirstName" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>                              
</div>
</div>
         <div class="col-sm-3 col-md-3">
<div class="form-group">
<label>Last Name*</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtLastName" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>                               
</div>
</div>
 
<div class="col-sm-3 col-md-3">
<div class="form-group chosenFullWidth">
<label>Country*</label>
<asp:DropDownList CssClass="form-control form-control-sm"  ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">   
</asp:DropDownList>                              
</div>
</div>
<div class="col-sm-3 col-md-3">
<div class="form-group chosenFullWidth">
<label>State*</label>
<asp:DropDownList CssClass="form-control form-control-sm"  ID="ddlState" runat="server" DataTextField="Statename" DataValueField="StateID">   
</asp:DropDownList>                              
</div>
</div>
 <div class="col-sm-3 col-md-3">
<div class="form-group">
<label>City</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-3 col-md-3">
<div class="form-group">
<label>Street Address</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" autocomplete="off" MaxLength="500" runat="server"></asp:TextBox>                             
</div>
</div>
 <div class="col-sm-3 col-md-3">
<div class="form-group">
<label>Postal Code</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPostalCode" autocomplete="off" MaxLength="10" runat="server"></asp:TextBox>                               
</div>
</div>
 <div class="col-sm-3 col-md-3">
<div class="form-group">
<label>Phone</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" autocomplete="off" MaxLength="12" runat="server"></asp:TextBox>                               
</div>
</div>
<div class="col-sm-3 col-md-3">
<div class="form-group">
<label>Date Hired</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtDateHired" autocomplete="off" MaxLength="10" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateHired" TargetControlID="txtDateHired"></asp:CalendarExtender>
</div>
</div>
<div class="col-sm-3 col-md-3">
<div class="form-group chosenFullWidth">
<label>Position*</label>
<asp:DropDownList CssClass="form-control form-control-sm"  ID="ddlPosition" DataTextField="DepartmentName" DataValueField="Departmentid" runat="server">    
</asp:DropDownList>                              
</div>
</div>
<div class="col-sm-3 col-md-3">
<div class="form-group">
<label>Status*</label>
<div class="input-group input-group-sm d-flex align-items-center">  
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">   
     <asp:ListItem Value="0">Select</asp:ListItem>
     <asp:ListItem Value="1">Active</asp:ListItem>
     <asp:ListItem Value="2">Quit</asp:ListItem>
    <asp:ListItem Value="3">Terminated</asp:ListItem>
     <asp:ListItem Value="4">Retired</asp:ListItem>
</asp:DropDownList>

</div>
</div>
</div>
<div class="col-4 col-sm-3 col-md-3">
<div class="form-group srRadiosBtns">
<label>Employment Type</label>
<asp:RadioButtonList ID="rdbEmployeeCurrentStatus" runat="server" RepeatDirection="Horizontal">
<asp:ListItem Value="1" Selected="True">Permanent</asp:ListItem>
<asp:ListItem Value="2">Agency</asp:ListItem>
</asp:RadioButtonList>
</div>
                                                                
                                                                
</div>

        <div class="col-sm-12">
<div class="form-group">
<label>Notes</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtNotes" autocomplete="off" MaxLength="500" runat="server" Height="43px" TextMode="MultiLine"></asp:TextBox>                               
</div>
</div>

</div> 
    </div>
    <div class="col-md-4">      
    <asp:Image ID="Image1" CssClass="img-thumbnail img-fluid"  runat="server" />
        
<div class="form-group">
<label>Choose Image</label>
<div class="input-group input-group-sm d-flex align-items-center">  
    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-success btn-sm btn-block" onchange="ShowImagePreview(this);"  />
</div>
</div>

    </div>
</div>
<div class="col-12 ">
    <div class="row pt-3">        
        <div class="col-12"><h5 class="text-uppercase">Qualification Details</h5></div>
<div class="row border-top mb-3">
            <div class="col-6 col-sm-4 col-md-3 mt-3">
                <div class="input-group chosenFullWidth">
  <div class="input-group-prepend">
    <span class="input-group-text px-1 py-0"><asp:CheckBox ID="chkLaser" runat="server" onchange="Laser()" /><label class="mb-0 pl-1">Laser</label></span>
  </div>
  <asp:DropDownList ID="ddlLaser" CssClass="form-control form-control-sm" runat="server" Enabled="false">
    <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Helper</asp:ListItem>
    <asp:ListItem Value="2">Experienced</asp:ListItem>
</asp:DropDownList>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 mt-3">
<div class="input-group chosenFullWidth">
  <div class="input-group-prepend">
    <span class="input-group-text px-1 py-0"><asp:CheckBox ID="chkbrake" runat="server" onchange="Brakepress()" /><label class="mb-0 pl-1">Brake Press</label></span>
  </div>
<asp:DropDownList ID="ddlbrakepress" CssClass="form-control form-control-sm" runat="server" Enabled="false">
    <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Helper</asp:ListItem>
    <asp:ListItem Value="2">Experienced</asp:ListItem>
</asp:DropDownList>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 mt-3">
<div class="input-group chosenFullWidth">
  <div class="input-group-prepend">
    <span class="input-group-text px-1 py-0"><asp:CheckBox ID="chkwelding" runat="server" onchange="Welding()" /><label class="mb-0 pl-1">Welding</label></span>
  </div>
<asp:DropDownList ID="ddlwelding" CssClass="form-control form-control-sm" runat="server" Enabled="false">
    <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Helper</asp:ListItem>
    <asp:ListItem Value="2">Experienced</asp:ListItem>
</asp:DropDownList>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 mt-3">
<div class="input-group chosenFullWidth">
  <div class="input-group-prepend">
    <span class="input-group-text px-1 py-0"><asp:CheckBox ID="chkpolishing" runat="server" onchange="Polishing()" /><label class="mb-0 pl-1">Polishing</label></span>
  </div>
<asp:DropDownList ID="ddlpolishing" CssClass="form-control form-control-sm" runat="server" Enabled="false">
    <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Helper</asp:ListItem>
    <asp:ListItem Value="2">Experienced</asp:ListItem>
</asp:DropDownList>
</div>
</div>
<div class="col-6 col-sm-4 col-md-3 mt-3">
<div class="input-group chosenFullWidth">
  <div class="input-group-prepend">
    <span class="input-group-text px-1 py-0"><asp:CheckBox ID="chkmachineshop" runat="server" onchange="MachineShop()" /><label class="mb-0 pl-1">Machine Shop</label></span>
  </div>
<asp:DropDownList ID="ddlMachineShop" CssClass="form-control form-control-sm" runat="server" Enabled="false">
    <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Helper</asp:ListItem>
    <asp:ListItem Value="2">Experienced</asp:ListItem>
</asp:DropDownList>
</div>
</div>

<div class="col-6 col-sm-4 col-md-3 mt-3">
<div class="input-group chosenFullWidth">
  <div class="input-group-prepend">
    <span class="input-group-text px-1 py-0"><asp:CheckBox ID="chkElectrical" runat="server" onchange="Electrical()" /><label class="mb-0 pl-1">Electrical</label></span>
  </div>
<asp:DropDownList ID="ddlElectrical" CssClass="form-control form-control-sm" runat="server" Enabled="false">
    <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Helper</asp:ListItem>
    <asp:ListItem Value="2">Experienced</asp:ListItem>
</asp:DropDownList>
</div>
</div>

<div class="col-6 col-sm-4 col-md-3 mt-3">
<div class="input-group chosenFullWidth">
  <div class="input-group-prepend">
    <span class="input-group-text px-1 py-0"><asp:CheckBox ID="chkShippingReceiver" runat="server" onchange="Shipping()" /><label class="mb-0 pl-1">Shipping & Receiving</label></span>
  </div>
<asp:DropDownList ID="ddlShippingandReceiver" CssClass="form-control form-control-sm" runat="server" Enabled="false">
       <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Helper</asp:ListItem>
    <asp:ListItem Value="2">Experienced</asp:ListItem>
</asp:DropDownList>
</div>
</div>
</div>
</div>
</div>

<div class="row border-top pt-3">
<div class="col-12"><h5 class="text-uppercase">Training History</h5></div>
<div class="col-12">
<div class="table-responsive">
<asp:GridView CssClass="table mainGridTable table-sm" ID="gvShopEmployee" runat="server" AutoGenerateColumns="False"   DataKeyNames="Shopemployeetrainingid"    
        EmptyDataText="No Member has been added."  EnableModelValidation="True"            
            BackColor="#CCCCCC" ShowFooter="true" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
            ForeColor="Black" OnRowEditing="gvShopEmployee_RowEditing" OnRowDataBound="gvShopEmployee_RowDataBound" OnRowCancelingEdit="gvShopEmployee_RowCancelingEdit" OnRowUpdating="gvShopEmployee_RowUpdating">
        <Columns>
       
            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="30%">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDesc" CssClass="form-control form-control-sm" autocomplete="off" runat="server" MaxLength="500" Text='<%# Eval("EmployeeDesc") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtFooterDesc" CssClass="form-control form-control-sm" autocomplete="off" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("EmployeeDesc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category" HeaderStyle-Width="10%">
                <EditItemTemplate>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCategory" DataTextField="DepartmentName" DataValueField="Departmentid" runat="server">
                    </asp:DropDownList>
                           <asp:Label ID="lblCategoryEdit" runat="server" Width="100%" Text='<%# Eval("CategoryID") %>' Visible="false"></asp:Label>    
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFooterCategory" DataTextField="DepartmentName" DataValueField="Departmentid" runat="server">
                 
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trainer" HeaderStyle-Width="30%">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTrainer" CssClass="form-control form-control-sm" autocomplete="off" MaxLength="40" runat="server" Text='<%# Eval("Trainer") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtFooterTrainer" CssClass="form-control form-control-sm" autocomplete="off" MaxLength="40" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTrainer" runat="server" Text='<%# Eval("Trainer") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="12%">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDate" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Text='<%# Eval("TrainingDate","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDate" TargetControlID="txtDate"></asp:CalendarExtender>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtFooterDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFooterDate" TargetControlID="txtFooterDate"></asp:CalendarExtender>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("TrainingDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
                <EditItemTemplate>
                    <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-info btn-sm rounded" Text="Add" OnClick="btnAdd_Click" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                    &nbsp;
                </ItemTemplate>
            </asp:TemplateField>
       
        </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
</asp:GridView>                           
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
             $('#<%=ddlEmployee.ClientID%>').chosen();   
             $('#<%=ddlPosition.ClientID%>').chosen();   
            $('#<%=ddlStatus.ClientID%>').chosen();  
            $('#<%=ddlCountry.ClientID%>').chosen(); 
             $('#<%=ddlState.ClientID%>').chosen(); 
        }

    function Laser()
    {
        
         var laser = document.getElementById('<%= chkLaser.ClientID%>').checked;
       
        if(laser == true)
        {
            document.getElementById('<%=ddlLaser.ClientID%>').disabled = false;
          
        }
        else
        {
            document.getElementById('<%=ddlLaser.ClientID%>').disabled = true;
            document.getElementById('<%=ddlLaser.ClientID%>').value="0";
             
        }
    }

     function Brakepress()
    {
        
         var brakepress = document.getElementById('<%= chkbrake.ClientID%>').checked;
        
         if (brakepress == true)
         {             
            document.getElementById('<%=ddlbrakepress.ClientID%>').disabled = false;
        }
         else if (brakepress==false)
         {             
             document.getElementById('<%=ddlbrakepress.ClientID%>').disabled = true;
             document.getElementById('<%=ddlbrakepress.ClientID%>').value = "0";
        }
     }

      function Welding()
    {
        
         var welding = document.getElementById('<%= chkwelding.ClientID%>').checked;
       
          if (welding == true)
        {
            document.getElementById('<%=ddlwelding.ClientID%>').disabled = false;
        }
        else
        {
              document.getElementById('<%=ddlwelding.ClientID%>').disabled = true;
              document.getElementById('<%=ddlwelding.ClientID%>').value = "0";
        }
      }

      function Polishing()
    {
        
         var polishing = document.getElementById('<%= chkpolishing.ClientID%>').checked;
       
          if (polishing == true)
        {
            document.getElementById('<%=ddlpolishing.ClientID%>').disabled = false;
        }
        else
        {
              document.getElementById('<%=ddlpolishing.ClientID%>').disabled = true;
              document.getElementById('<%=ddlpolishing.ClientID%>').value = "0";
        }
      }

    function MachineShop()
    {
        
        var MachineShop = document.getElementById('<%= chkmachineshop.ClientID%>').checked;
       
        if (MachineShop == true)
        {
            document.getElementById('<%=ddlMachineShop.ClientID%>').disabled = false;
        }
        else
        {
            document.getElementById('<%=ddlMachineShop.ClientID%>').disabled = true;
            document.getElementById('<%=ddlMachineShop.ClientID%>').value = "0";
        }
    }

      function Electrical()
    {
        
        var Electrical = document.getElementById('<%= chkElectrical.ClientID%>').checked;
       
          if (Electrical == true)
        {
            document.getElementById('<%=ddlElectrical.ClientID%>').disabled = false;
        }
        else
        {
              document.getElementById('<%=ddlElectrical.ClientID%>').disabled = true;
               document.getElementById('<%=ddlElectrical.ClientID%>').value = "0";
        }
      }


      function Shipping()
        {
        
          var Shipping = document.getElementById('<%= chkShippingReceiver.ClientID%>').checked;
       
          if (Shipping == true)
        {
            document.getElementById('<%=ddlShippingandReceiver.ClientID%>').disabled = false;
        }
        else
        {
              document.getElementById('<%=ddlShippingandReceiver.ClientID%>').disabled = true;
               document.getElementById('<%=ddlShippingandReceiver.ClientID%>').value = "0";
        }
    }
    function ShowImagePreview(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();            
            reader.onload = function (e) {
              $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                                       
            };
            reader.readAsDataURL(input.files[0]);
           
        }
    }
    
  
    </script>
</asp:Content>