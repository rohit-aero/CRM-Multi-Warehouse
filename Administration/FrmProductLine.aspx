<%@ Page Language="C#" MasterPageFile="~/Main.master"
    AutoEventWireup="true" CodeFile="FrmProductLine.aspx.cs" Inherits="Administration_FrmProductLine" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <h4 class="title-hyphen position-relative">Product Line Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-7 col-lg-6">
                        <div class="row">
                            <div class="col-sm-auto mb-3">
                                <label class="mb-0">Product Code</label>
                            </div>

                            <div class="col-sm mb-3">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductCode" runat="server" DataTextField="ProductCode" DataValueField="ProductCodeID" AutoPostBack="True" OnSelectedIndexChanged="ddlProductCode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm mb-3">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLine" runat="server" DataTextField="Product" DataValueField="ProductCodeId" AutoPostBack="True" OnSelectedIndexChanged="ddlProductLine_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm col-md col-lg-auto">
                        <div class="row">
                            <div class="col-sm">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
            <div class="row pt-3">           
            <div class="col-12"><h5 class="text-uppercase">Product Line Information</h5></div>
            <div class="col-sm-2 col-md-2">
            <div class="form-group">
            <label class="text-danger">Product Code*</label>
             <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProdCode" runat="server" DataTextField="ProductCode" DataValueField="ProductCodeID" Enabled="false">
              </asp:DropDownList>
            </div>
            </div>
             <div class="col-sm-4 col-md-3">
            <div class="form-group">
            <label class="text-danger">Product Line*</label>
            <asp:TextBox CssClass="form-control form-control-sm" MaxLength="50" AutoComplete="off" ID="txtProductLine" runat="server" Enabled="false"></asp:TextBox>
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
            $('#<%=ddlProdCode.ClientID%>').chosen();
            $('#<%=ddlProductCode.ClientID%>').chosen();
            $('#<%=ddlProductLine.ClientID%>').chosen();           
        }
    </script>
</asp:Content>
