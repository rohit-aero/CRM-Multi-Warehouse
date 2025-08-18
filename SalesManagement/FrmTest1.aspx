<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmTest1.aspx.cs" Inherits="Test1_FrmTest" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_Projects_Test" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Projects_Test" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <div class="row col-12 p-1">
                        <div class="col-2">
                            <label class="pl-0 col-12">Conveyor Model</label>
                            <asp:DropDownList ID="ddlConveyorModel" CssClass="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorModel_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                 <asp:ListItem Value="SBC">SBC</asp:ListItem>
                                <asp:ListItem Value="TAC">TAC</asp:ListItem>                               
                            </asp:DropDownList>
                        </div>

                        <%-- <div class="col-2">
                            <label>&nbsp;</label>
                            <div class="col-2">
                                <asp:CheckBox ID="chkModelPersistent" runat="server" />
                                <label>Persist</label>
                            </div>
                        </div>--%>

                        <div class="col-2">
                            <label class="pl-0 col-12">Size</label>
                            <asp:DropDownList ID="ddlConveyorType" CssClass="form-control form-control-sm" DataValueField="id" DataTextField="text" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConveyorType_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-3">
                            <label class="pl-0 col-12">Type</label>
                            <asp:DropDownList ID="ddlSize" CssClass="form-control form-control-sm" DataValueField="id" DataTextField="text" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSize_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <%--  <div class="col-12" id="driveunit" runat="server" visible="false">
                            <label class="pl-0 col-12">Drive Unit</label>
                            <asp:DropDownList ID="ddlDriveUnit" CssClass="form-control form-control-sm" runat="server">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="010001 L-R">010001 L-R</asp:ListItem>
                                <asp:ListItem Value="010002 L-R">010002 R-L</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>

                        <div class="col-12">
                            <label class="pl-0 col-12">&nbsp;</label>

                            <%--<asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" />--%>
                        </div>
                    </div>

                    <div class="col-4">
                        <asp:GridView ID="gvTemp" CssClass="table mainGridTable table-sm" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Drive Unit">
                                    <ItemTemplate>
                                        <%--                                        <asp:CheckBox ID="chkDriveUnit" runat="server">                                            
                                        </asp:CheckBox>--%>
                                        <asp:Label ID="partno" runat="server" Text='<%# Eval("part") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty" runat="server" MaxLength="3" Style="width: 50px;"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <asp:Button ID="btnSave" CssClass="ml-3 btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
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
            $('#<%=ddlSize.ClientID%>').chosen();
        }
    </script>
</asp:Content>
