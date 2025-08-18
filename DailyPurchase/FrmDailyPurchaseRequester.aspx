<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmDailyPurchaseRequester.aspx.cs" Inherits="DailyPurchase_FrmDailyPurchaseRequester" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_SalesActivity" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SalesActivity" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Daily Purchase Requester</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Requester</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRequesterHeaderList" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlRequesterHeaderList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4 mt-2">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="row">
                    <div class="col-12">
                        <h5 class="text-uppercase">REQUESTER INFORMATION</h5>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">First Name*</label>
                            <asp:TextBox ID="txtFirstName" CssClass="form-control form-control-sm" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Last Name</label>
                            <asp:TextBox ID="txtLastName" CssClass="form-control form-control-sm" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Active*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlActive" runat="server">
                                <asp:ListItem Value="1" Selected>Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
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
            BindDrp();
        }

        $.when.apply($, PageLoaded).then(function () {
            BindDrp();
        });

        function BindDrp() {
            $('#<%=ddlRequesterHeaderList.ClientID%>').chosen();
            $('#<%=ddlActive.ClientID%>').chosen();
        }
    </script>
</asp:Content>
