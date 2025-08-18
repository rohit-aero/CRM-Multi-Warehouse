<%@ Page Language="C#" MasterPageFile="~/Main.master"
    AutoEventWireup="true" CodeFile="FrmCompanyOfficeDepartment.aspx.cs" Inherits="Administration_FrmCompanyOfficeDepartment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <h4 class="title-hyphen position-relative">Company Office Department</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-5 col-lg-6">
                        <div class="row">
                            <div class="col-sm-auto mb-3">
                                <label class="mb-0">Look Up Office</label>
                            </div>

                            <div class="col-sm mb-2">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookUpOffice" runat="server" DataTextField="Office" DataValueField="OffiecID" AutoPostBack="True" OnSelectedIndexChanged="ddlLookUpOffice_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm mb-2 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookUpDepartment" runat="server" DataTextField="Department" DataValueField="DepartmentID" AutoPostBack="True" OnSelectedIndexChanged="ddlLookUpDepartment_SelectedIndexChanged">
                                </asp:DropDownList>
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
                    <div class="col-12">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Company Office Department Information </h5></div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Office*</label>
                             <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOffice" runat="server" DataTextField="Office" DataValueField="OffiecID">
                                    </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Department*</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" MaxLength="50" autocomplete="off" ID="txtDepartment" runat="server"></asp:TextBox>
                        </div>
                    </div>
                     <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                           <label class="input-group-prepend pr-3">Status</label>
                           <asp:CheckBox ID="chkIsACtive" runat="server"></asp:CheckBox>
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
            $('#<%=ddlLookUpDepartment.ClientID%>').chosen();
            $('#<%=ddlLookUpOffice.ClientID%>').chosen();
            $('#<%=ddlOffice.ClientID%>').chosen();           
        }
    </script>
</asp:Content>
