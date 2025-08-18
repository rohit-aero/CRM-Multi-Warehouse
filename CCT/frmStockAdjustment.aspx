<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmStockAdjustment.aspx.cs" Inherits="CCT_frmStockAdjustment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="Panel1" runat="server">
    <div class="col-12 pb-3 pt-2 piDiv position-sticky">
    <div class="row">
    <div class="col-sm-12">
        <div class="d-flex align-items-center mb-2">
        <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
        <h4 class="title-hyphen position-relative">Stock Adjustment Form</h4>
        </div>
    </div> 
</div>   
 <div class="row">
   <div class="col-sm-7 col-md-8 col-lg-8 col-xl-9">
    <div class="row">
    <div class="col-sm-6 col-md-4">
<div class="form-group">
<label class="text-danger">Manufacturer*</label>
<asp:DropDownList ID="ddlManufacturer" runat="server" DataValueField="id" DataTextField="makername" CssClass="w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlManufacturer_SelectedIndexChanged"></asp:DropDownList>
</div>
</div>
<div class="col-sm-6 col-md-4">
<div class="form-group">
<label class="text-danger">Waste Eq*</label>
<asp:DropDownList ID="ddlWasteEq" runat="server" DataTextField="WasteEqName" DataValueField="WasteEqid" CssClass="w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlWasteEq_SelectedIndexChanged"></asp:DropDownList>
</div>
</div>
<div class="col-sm-6 col-md-4">
<div class="form-group">
<label class="text-danger">Accessory*</label>
<asp:DropDownList ID="ddlAcc" runat="server" CssClass="w-100" DataTextField="acc_name" DataValueField="Accid" AutoPostBack="True" OnSelectedIndexChanged="ddlAcc_SelectedIndexChanged"></asp:DropDownList>
</div>
</div>                   
                </div>
            </div>
   <div class="col-sm col-md col-lg col-xl">
                <div class="row d-flex h-100 align-items-end">
                    <div class="col-sm-6"> <asp:Button ID="btnSave" CssClass="btn btn-success btn-sm btn-block mb-3" runat="server" Text="Save" OnClick="btnSave_Click"  /></div>
                    <div class="col-sm-6">   <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm btn-block mb-3" runat="server" Text="Cancel" OnClick="btnCancel_Click"  /></div>                    
                </div>
            </div>
   </div>
  </div>
    <div class="col-12">    
         <div class="row pt-3">
             <div class="col-12"><h5 class="text-uppercase">Details</h5></div>
             <div class="col-sm-3">
                    <div class="form-group">
                        <label>Qty Available</label>
                         <asp:TextBox ID="txtQtyAvailable" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                          
                    </div>
                    
                </div>

                <div class="col-sm-3">
                    <div class="form-group">
                        <label>Stock Option</label>
                         <asp:DropDownList ID="ddlStockOptions" CssClass="form-control form-control-sm" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="1">Stock In</asp:ListItem>
                                    <asp:ListItem Value="2">Stock Out</asp:ListItem>
                                </asp:DropDownList>
                          
                    </div>
                    
                </div>

             <div class="col-sm-3">
                    <div class="form-group">
                        <label>Qty</label>
                        <asp:TextBox ID="txtQty" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>                          
                    </div>                    
                </div>

             <div class="col-sm-3">
                    <div class="form-group">
                        <label>Adjustment Date</label>
                                  <asp:TextBox ID="txtAdjDate" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtAdjDate" TargetControlID="txtAdjDate">
                                </asp:CalendarExtender>
                    </div>                    
                </div>

                          <div class="col-sm-3">
                    <div class="form-group">
                        <label>Summary</label>
                                  <asp:TextBox ID="txtSummary" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine"></asp:TextBox>         
                    </div>                    
                </div>
         </div> 
         </div>
     <asp:HiddenField ID="HfStockAccid" runat="server" Value="-1" />
    </asp:Panel>
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
               $('#<%=ddlManufacturer.ClientID%>').chosen();
               $('#<%=ddlWasteEq.ClientID%>').chosen();
               $('#<%=ddlAcc.ClientID%>').chosen();  
               $('#<%=ddlStockOptions.ClientID%>').chosen();  
           }
        </script>       
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>