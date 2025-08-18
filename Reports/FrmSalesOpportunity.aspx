<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmSalesOpportunity.aspx.cs" Inherits="Reports_FrmSalesOpportunity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Sales Opportunity Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="col-2">
                        <div class="form-group">
                            <label>Expected Sales Date From</label>
                            <asp:TextBox ID="txtFromDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtFromDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Expected Sales Date To</label>
                            <asp:TextBox ID="txtToDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtToDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtToDate" TargetControlID="txtToDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlStatus">
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="1">Done</asp:ListItem>
                                <asp:ListItem Value="2">In Progress</asp:ListItem>
                                <asp:ListItem Value="3">Cancelled</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Sales Opportunity</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlSalesOpportunity" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <label>&nbsp;</label>
                        <div class="row">
                            <div class="col-md-auto">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenerate" runat="server" Text="Preview Report" OnClick="btnGenerate_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerate" />
        </Triggers>
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
            $('#<%=ddlSalesOpportunity.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>
