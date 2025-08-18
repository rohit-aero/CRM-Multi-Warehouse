<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ConveyorType.aspx.cs" Inherits="Administration_ConveyorType" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HfConveyorTypeId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Conveyor Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-7 col-lg-6 col-sm-7">
                        <div class="row">
                            <div class="col-sm-auto">
                                <label class="mb-0">Conveyor</label>
                            </div>
                            <div class="col-sm mb-3">
                                <asp:DropDownList ID="ddlConveyor" CssClass="form-control form-control-sm" DataTextField="ConveyorType" DataValueField="ConveyorTypeID" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlConveyor_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg-auto">
                        <div class="row">
                            <div class="col-sm">
                                <asp:Button CssClass="btn btn-success" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button CssClass="btn btn-danger" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Conveyor Details</h5>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label>Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtName" runat="server" MaxLength="50" OnTextChanged="btnSave_Click"></asp:TextBox>
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
            $('#<%=ddlConveyor.ClientID%>').chosen();
        }
    </script>
</asp:Content>

