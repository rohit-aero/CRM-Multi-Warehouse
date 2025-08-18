<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmRollback.aspx.cs" Inherits="INVManagement_FrmRollback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Rollback</h4>
                </div>
            </div>
        </div>
    <div class="row">
        <div class="col-sm-6 mb-3">
            <div class="row">
                <label class="col-auto mb-0">Job ID</label>
                <div class="col chosenFullWidth">
                    <asp:DropDownList CssClass="form-control" ID="ddlJobID" runat="server" DataValueField="JobID" DataTextField="ProjectName" AutoPostBack="True" OnSelectedIndexChanged="ddlJobID_SelectedIndexChanged"></asp:DropDownList>
              
               </div>
            </div>
            
        </div>   
         <div class="col-sm col-md col-lg col-xl-auto">
                <div class="row">
                    <div class="col-auto">
                        <asp:Button ID="btnRelease" runat="server" CssClass="btn btn-success btn-sm" Text="Rollback" Enabled="false" OnClientClick="return confirm('Are you sure.?');" OnClick="btnRelease_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click"   />
                    </div>                  
                </div>
            </div>   
    </div>
</div>
<div class="col-12">
</div>
<div class="col-12 pt-3">
          
            <div class="table-responsive">     
           <asp:GridView CssClass="table mainGridTable table-sm" ID="gvDetail" runat="server"  AutoGenerateColumns="False"  EmptyDataText="No Parts has been Added"
                 EnableModelValidation="True">
               <Columns>               
                   <asp:BoundField DataField="PartNumber" HeaderText="Part Description" >
                   <HeaderStyle HorizontalAlign="Left" />
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:BoundField>
                   <asp:BoundField DataField="qty" HeaderText="Qty" HeaderStyle-HorizontalAlign="Right">
                   <HeaderStyle HorizontalAlign="Right" />
                   <ItemStyle HorizontalAlign="Right" />
                   </asp:BoundField>             
                   <asp:TemplateField HeaderText="Remove">
			    <ItemTemplate>
				<asp:LinkButton ID="btnDelete" OnClientClick="return confirm('Are you sure to delete. ?');" runat="server" CommandName="Delete">Delete</asp:LinkButton>
			    </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
                       <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>  
                   
               </Columns>
           </asp:GridView>
               </div>

    </div>

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

