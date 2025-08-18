<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmTest.aspx.cs" Inherits="Test_FrmTest" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content_Projects_Test" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Projects_Test" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <div class="row col-2 p-1">
                        <div class="col-12">
                            <label class="pl-0 col-12">Conveyor Model</label>
                            <asp:DropDownList ID="ddlConveyorModel" CssClass="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorModel_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="SBC">SBC</asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <div class="row col-12" id="type" runat="server" visible="false">
                            <div class="col-10">
                                <label class="pl-0 col-10">Conveyor Type</label>
                                <asp:DropDownList ID="ddlConveyorType" CssClass="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorType_SelectedIndexChanged">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="Single7">Single 7"</asp:ListItem>
                                    <asp:ListItem Value="Single10">Single 10"</asp:ListItem>
                                    <asp:ListItem Value="Single12">Single 12"</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-2">
                                <label>&nbsp;</label>
                                <div class="col-2">
                                    <asp:CheckBox ID="chkModelPersistent" runat="server" />
                                    <label>Persist</label>
                                </div>
                            </div>
                        </div>

                        <div class="row col-12" id="driveunit" runat="server" visible="false">
                            <div class="col-10">
                                <label class="pl-0 col-10">Drive Unit</label>
                                <asp:DropDownList ID="ddlDriveUnit" CssClass="form-control form-control-sm" runat="server">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="010001 L-R">010001 L-R</asp:ListItem>
                                    <asp:ListItem Value="010002 L-R">010002 R-L</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-2">
                                <label class="pl-0 col-2">Qty</label>
                                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-12">
                            <label class="pl-0 col-12">&nbsp;</label>
                            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>

                    <div class="col-12">
                        <asp:GridView ID="gvTest" CssClass="table mainGridTable table-sm" runat="server" AutoGenerateColumns="true">
                        </asp:GridView>
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
            $('#<%=ddlDriveUnit.ClientID%>').chosen();
        }
    </script>
</asp:Content>
