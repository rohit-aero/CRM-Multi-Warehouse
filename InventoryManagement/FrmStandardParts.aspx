<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmStandardParts.aspx.cs" Inherits="FrmStandardParts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Standard Parts Information</h4>
                </div>
            </div>
        </div>
    <div class="row">
        <div class="col-sm-6 mb-3">
            <div class="row">
                <label class="col-auto mb-0">Job ID</label>
                <div class="col">
                    <asp:DropDownList CssClass="form-control" ID="ddlJobID" runat="server" DataValueField="JobID" DataTextField="ProjectName" OnSelectedIndexChanged="ddlJobID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
               </div>
            </div>
        </div>
      
    </div>
</div>
<div class="col-12">

</div>




<asp:Panel ID="Panel2" runat="server" Visible="false">
<div class="col-12 pt-3">
<div class="row d-flex justify-content-center">
    <div class="col-auto"><div class="row">

<div class="col-12"><h5 class="text-uppercase">Part Description</h5></div>
<div class="col-sm-auto">
<div class="form-group mb-0">
<label>Category</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartDesc" runat="server" DataTextField="partname" DataValueField="Standardpartid" AutoPostBack="True" OnSelectedIndexChanged="ddlPartDesc_SelectedIndexChanged" ></asp:DropDownList>  

</div>
</div>
<div class="col-sm-auto">
<div class="form-group mb-0">
<label>Part Description</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlItem" runat="server" DataTextField="detailname" DataValueField="StandardPartid" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" ></asp:DropDownList> 

                             
</div>
</div>
<div class="col-sm-auto">
<div class="form-group mb-0">
<label>Part Number</label>
 <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtPartNo" runat="server" Width="80px" Enabled="false" ></asp:TextBox> 

                             
</div>
</div>
<div class="col-sm-auto">
<div class="form-group mb-0">
<label>Quantity</label>
<asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtQty" runat="server" Width="80px" >1</asp:TextBox> 

                             
</div>
</div>
<div class="col-sm-auto">
<div class="form-group mb-0 flex-column">
<label class="">&nbsp;</label>
    <div>
<asp:Button CssClass="btn btn-success btn-sm" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
 </div>                   
</div>

</div>
    </div></div>
    </div>
</div>
<div class="col-12 pt-3">
          
            <div class="table-responsive">     
           <asp:GridView CssClass="table mainGridTable table-sm" ID="gvDetail" runat="server"  AutoGenerateColumns="False"  EmptyDataText="No Parts has been Added"
                 EnableModelValidation="True" DataKeyNames="ProjectStandardid" OnRowDeleting="gvDetail_RowDeleting">
               <Columns>
                   <asp:BoundField DataField="partname" HeaderText="Part Description" >
                   <HeaderStyle HorizontalAlign="Left" />
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:BoundField>
                   <asp:BoundField DataField="detailname" HeaderText="Item" >
                   <HeaderStyle HorizontalAlign="Left" />
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:BoundField>
                   <asp:BoundField DataField="partno" HeaderText="Part #" >
                   <HeaderStyle HorizontalAlign="Right" />
                   <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                   </asp:BoundField>
                    <asp:BoundField DataField="Qty" HeaderText="Quantity" >
                   <HeaderStyle HorizontalAlign="Right" />
                   <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                   </asp:BoundField>
                   <asp:TemplateField HeaderText="Remove">
			    <ItemTemplate>
				<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete">Delete
				</asp:LinkButton>
			    </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
                       <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>  
                   
               </Columns>
           </asp:GridView>
               </div>

    </div>
        </asp:Panel>
    <script type="text/javascript">
        $(document).ready(function () {

            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });
        function PageLoaded(sender, args) {           
          DDLName();
           
       }
       $.when.apply($, PageLoaded).then(function () {          
           DDLName();
       });      

        function DDLName()
       {

            $('#<%=ddlJobID.ClientID%>').chosen();
           
           
           

        }
    </script>
</ContentTemplate>
</asp:UpdatePanel>
 
 </asp:Content>