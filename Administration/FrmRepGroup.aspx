<%@ Page Language="C#" MasterPageFile="~/Main.master"
    AutoEventWireup="true" CodeFile="FrmRepGroup.aspx.cs" Inherits="Administration_FrmRepGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <h4 class="title-hyphen position-relative">Rep Group Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-7 col-lg-6">
                        <div class="row">
                            <div class="col-sm-auto mb-3">
                                <label class="mb-0">Business Division</label>
                            </div>

                            <div class="col-sm mb-3">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLineHeaderList" runat="server" DataTextField="Name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlProductLineList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm mb-3">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRepGroupHeaderList" runat="server" DataTextField="Name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlRepGroup_SelectedIndexChanged">
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
            <div class="col-md-auto mx-auto innerMain">
                <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">RepGroup Information</h5>
                    </div>
                    <div class="row">
                        <div class="col-sm-auto ">
                            <div class="form-group d-flex flex-row flex-wrap">
                                <div class="col-sm-auto">
                                    <div>
                                        <label class="text-danger">Business Division*</label>
                                    </div>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLine" runat="server" DataTextField="Name" DataValueField="ID">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-auto">
                                    <label class="text-danger">Rep Group Name*</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" MaxLength="50" AutoComplete="off" ID="txtName" runat="server"></asp:TextBox>
                                </div>
                                <%-- <div class="col-sm-auto">
                                    <label>Sort Order</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtSortOrder" AutoComplete="off" MaxLength="3" runat="server"></asp:TextBox>
                                </div>--%>

                                <div class="col-sm-auto">
                                    <div class="form-group srRadiosBtns">
                                        <label>Is Active</label>
                                        <asp:RadioButtonList ID="IsActive" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Yes &nbsp;</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="col-sm-auto">
                                    <div>
                                        <label>Project Manager</label>
                                    </div>
                                    <asp:DropDownList CssClass="form-control form-control-sm"
                                        ID="ddlPM" runat="server" DataTextField="Name" DataValueField="ID" Enabled="false">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-sm-auto">
                                    <div class="col-12">
                                        <label class="text-danger">Group*</label>
                                    </div>
                                    <div class="col-sm-auto d-flex align-items-center">
                                        <div class="d-flex">
                                            <div class="form-check pr-4">
                                                <asp:CheckBox CssClass="form-check-input" ID="chkHobart" runat="server" />
                                                <label class="form-check-label" for="chkHobart">
                                                    Hobart Group
                                                </label>
                                            </div>
                                            <div class="form-check">
                                                <asp:CheckBox CssClass="form-check-input" ID="chkStero" runat="server" />
                                                <label class="form-check-label" for="chkStero">
                                                    Stero Group
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
            $('#<%=ddlRepGroupHeaderList.ClientID%>').chosen();
            $('#<%=ddlProductLine.ClientID%>').chosen();
            $('#<%=ddlProductLineHeaderList.ClientID%>').chosen();
            $('#<%=ddlPM.ClientID%>').chosen();
        }
    </script>
</asp:Content>
