<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmAddMenu.aspx.cs" Inherits="Administration_frmAddMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Add Menu</h4>
                </div>
            </div>
        </div>
           <div class="row">
          <div class="col-sm-7 col-md-8 col-lg-6">
                <div class="row">
                    <div class="col-sm-auto mb-3"><label class="mb-0">Look Up Menu</label></div>
                    <div class="col-sm mb-3 chosenFullWidth">
					     <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlMenuLookUp" runat="server" DataTextField="Menu" DataValueField="MenuID" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuLookUp_SelectedIndexChanged" ></asp:DropDownList>              
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg-auto">
                <div class="row">
                    <div class="col-sm">
					    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>                   
                </div>
            </div>
        </div>  
    </div>
    <div class="col-12">
        <div class="row pt-3">
            <div class="col-12"><h5 class="text-uppercase">Add New Menu</h5></div>
            <div class="col-sm-2 col-md-2">
            <div class="form-group">
                    <label class="text-danger">Name*</label>
                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtName" autocomplete="off" runat="server" MaxLength="50"></asp:TextBox>
            </div>
            </div>
            <div class="col-sm-2 col-md-2">
            <div class="form-group">
                    <label class="text-danger">Description*</label>
                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDesc" runat="server" autocomplete="off" MaxLength="50"></asp:TextBox>
            </div>
            </div>
            <div class="col-sm-5 col-md-5">
            <div class="form-group">
                    <label>Url</label>
                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtUrl" runat="server" autocomplete="off" MaxLength="200"></asp:TextBox>
            </div>
            </div>
            <div class="col-sm-3 col-md-3">
            <div class="form-group">
                    <label>Parent ID</label>
                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlParentID" runat="server"  DataTextField="Menu" DataValueField="MenuID"></asp:DropDownList>
            </div>
            </div>
            <div class="col-sm-2 col-md-2">
            <div class="form-group">
                    <label class="text-danger">Status*</label>
                    <asp:RadioButtonList ID="rdbStatus" runat="server"  RepeatDirection="Horizontal">
                       
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">In-Active</asp:ListItem>
                    </asp:RadioButtonList>
            </div>
            </div>
             <div class="col-sm-2 col-md-2">
            <div class="form-group">
                    <label>Sort Order</label>
                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtMenuSortOrder" autocomplete="off" MaxLength="2" onkeypress="return onlyNumbers(this,event);" runat="server"></asp:TextBox>
            </div>
            </div>
        </div>
    </div>
</ContentTemplate>
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
            $('#<%=ddlMenuLookUp.ClientID%>').chosen();          
            $('#<%=ddlParentID.ClientID%>').chosen();
       }
    </script>
</asp:Content>

