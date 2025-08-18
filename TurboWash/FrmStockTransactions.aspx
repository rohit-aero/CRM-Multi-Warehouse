<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmStockTransactions.aspx.cs" Inherits="TurboWash_FrmStockTransactions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">TurboWash Stock Transaction</h4>
                        </div>
                    </div>
                </div>
                  <div class="row pb-5">
                    <div class="col-3">
                        <label>Category</label>
                        <asp:DropDownList ID="ddlCategoryLookupList" runat="server" AutoPostBack="true" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="ddlCategoryLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>
                    <div class="col-3">
                        <label>Size (In Inches)</label>
                        <asp:DropDownList ID="ddlSizeLookupList" runat="server" AutoPostBack="true" DataTextField="SizeName" DataValueField="id" OnSelectedIndexChanged="ddlSizeLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>
                    <div class="col-3">
                        <label>Orientation</label>
                        <asp:DropDownList ID="ddlOrientationLookupList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrientationLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem Value="RL">RL</asp:ListItem>
                            <asp:ListItem Value="LR">LR</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-3">
                        <label>Options</label>
                        <asp:DropDownList ID="ddlOptionLookupList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOptionLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">With Drain</asp:ListItem>
                            <asp:ListItem Value="2">With Sump</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-4 mt-4">
                        <label>Part No</label>
                        <asp:DropDownList ID="ddlPartLookupList" runat="server" AutoPostBack="true" DataTextField="PartNo" DataValueField="id" OnSelectedIndexChanged="ddlPartLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>
                    <div class="col-3 mt-5">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-success btn-sm" CausesValidation="false" />
                        <asp:Button ID="btnITWReport" runat="server" CssClass="btn btn-secondary btn-sm" Text="ITW Report" OnClick="btnITWReport_Click" />                      
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-danger btn-sm" />
                    </div>
                </div>
            </div>
            <div class="col-12 border-3">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">TurboWash Stock Transaction</h5>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Stock In Hand</label>
                            <asp:TextBox ID="txtStockInHand" runat="server" Enabled="false"  AutoComplete="off" CssClass="form-control form-control-sm">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Transaction Type*</label>
                            <asp:DropDownList ID="ddlTransactionType" runat="server" DataTextField="TransactType" DataValueField="id" CssClass="form-control form-control-sm">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Transaction Qty*</label>
                            <asp:TextBox ID="txtTransactQty" runat="server" onkeypress="return onlyNumbers(event);"  AutoComplete="off" MaxLength="10" CssClass="form-control form-control-sm">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-group">
                            <label>Job No. / Remarks*</label>
                            <asp:TextBox ID="txtRemarks" runat="server" MaxLength="250"  AutoComplete="off" CssClass="form-control form-control-sm">
                            </asp:TextBox>
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
            $('#<%=ddlCategoryLookupList.ClientID%>').chosen();
            $('#<%=ddlSizeLookupList.ClientID%>').chosen();
            $('#<%=ddlPartLookupList.ClientID%>').chosen();
            $('#<%=ddlOptionLookupList.ClientID%>').chosen();
            $('#<%=ddlOrientationLookupList.ClientID%>').chosen();
            $('#<%=ddlTransactionType.ClientID%>').chosen();
        }
    </script>
</asp:Content>