<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmModelTypeMapping.aspx.cs" Inherits="Forecasting_FrmModelTypeMapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="_Content_Forecasting_ModelTypeMapping" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Forecasting_Models" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky pb-3">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Job Model Type Mapping</h4>
                        </div>
                    </div>
                </div>

                <div class="col-12 mt-2">
                    <div class="row col-12">
                        <div class="col-2 mb-2">
                            <label class="pl-0 col-12">Conveyor Model</label>
                            <asp:DropDownList ID="ddlConveyorModelLookup" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorModelLookup_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                        <div class="col-2 mb-2">
                            <label class="pl-0 col-12">Conveyor Type</label>
                            <asp:DropDownList ID="ddlConveyorType" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-2 mb-2">
                            <label class="col-12">&nbsp;</label>
                            <asp:Button ID="btnSaveType" CssClass="btn btn-success btn-sm" runat="server" Text="Save" OnClick="btnSaveType_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 mt-2 ml-2">
                <h5 class="col-12 text-uppercase">Map conveyor Type</h5>
                <div class="row col-12">
                    <div class="col-2 mb-2">
                        <label class="pl-0 col-12 text-danger">Conveyor Model*</label>
                        <asp:DropDownList ID="ddlConveyorModel" CssClass="form-control form-control-sm" DataTextField="text" DataValueField="id" runat="server">
                        </asp:DropDownList>
                    </div>

                    <div class="col-2 mb-2">
                        <label class="pl-0 col-12 text-danger">Conveyor Type*</label>
                        <asp:TextBox ID="txtConveyorType" CssClass="form-control form-control-sm" MaxLength="50" runat="server">
                        </asp:TextBox>
                    </div>

                    <div class="col-2 mb-2">
                        <label class="pl-0 col-12">Conveyor Type Description</label>
                        <asp:TextBox ID="txtConveyorTypeDescription" CssClass="form-control form-control-sm" MaxLength="250" runat="server">
                        </asp:TextBox>
                    </div>

                    <div class="col-1 mb-2">
                        <label class="pl-0 col-12">Is Active</label>
                        <asp:DropDownList ID="ddlActive" CssClass="form-control form-control-sm" runat="server">
                            <asp:ListItem Value="1" Selected>Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
        });

        function PageLoaded(sender, args) {
            DDLName();
        }
        $.when.apply($, PageLoaded).then(function () {
            DDLName();
        });

        function DDLName() {
            $('#<%=ddlConveyorModel.ClientID%>').chosen();
            $('#<%=ddlConveyorType.ClientID%>').chosen();
            $('#<%=ddlConveyorModelLookup.ClientID%>').chosen();
            $('#<%=ddlActive.ClientID%>').chosen();
        }
    </script>
</asp:Content>
