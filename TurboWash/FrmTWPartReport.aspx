<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmTWPartReport.aspx.cs" Inherits="TurboWash_FrmTWPartReport" %>

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
                            <h4 class="title-hyphen position-relative">TurboWash Inventory Transaction Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-2">
                    <div class="col-2">
                        <label>Category</label>
                        <asp:DropDownList ID="ddlCategoryLookupList" runat="server" AutoPostBack="true" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="ddlCategoryLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Size (In Inches)</label>
                        <asp:DropDownList ID="ddlSizeLookupList" runat="server" AutoPostBack="true" DataTextField="SizeName" DataValueField="id" OnSelectedIndexChanged="ddlSizeLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Orientation</label>
                        <asp:DropDownList ID="ddlOrientationLookupList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrientationLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem Value="RL">RL</asp:ListItem>
                            <asp:ListItem Value="LR">LR</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Options</label>
                        <asp:DropDownList ID="ddlOptionLookupList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOptionLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">With Drain</asp:ListItem>
                            <asp:ListItem Value="2">With Sump</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-3">
                        <label>Parts</label>
                        <asp:DropDownList ID="ddlPartLookupList" runat="server" AutoPostBack="true" DataTextField="PartNo" DataValueField="id" OnSelectedIndexChanged="ddlPartLookupList_SelectedIndexChanged" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Transaction Type</label>
                        <asp:DropDownList ID="ddlTransactionType" runat="server" CssClass="form-control form-control-sm">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="1">IN</asp:ListItem>
                            <asp:ListItem Value="2">OUT</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Transaction By</label>
                        <asp:DropDownList ID="ddlTransactionBy" runat="server" DataTextField="FirstName" DataValueField="EmployeeID" CssClass="form-control form-control-sm"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Transaction Date From</label>
                            <asp:TextBox ID="txtTransactionDateFrom" CssClass="form-control form-control-sm" AutoComplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtTransactionDateFromExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtTransactionDateFrom" TargetControlID="txtTransactionDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Transaction Date To</label>
                            <asp:TextBox ID="txtTransactionDateTo" CssClass="form-control form-control-sm" AutoComplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtTransactionDateToExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtTransactionDateTo" TargetControlID="txtTransactionDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-3">
                        <label>&nbsp;</label>
                        <div class="">
                            <asp:Button ID="btnPreview" runat="server" OnClick="btnPreview_Click" Text="Preview" Enabled="true" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" CssClass="btn btn-info btn-sm" />
                            <asp:Button ID="btnExportToPDF" runat="server" OnClick="btnExportToPDF_Click" Text="Export To PDF" Enabled="true" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" CssClass="btn btn-info btn-sm" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-danger btn-sm" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
            </div>
            <div class="col-12 pt-3">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvTransactions" runat="server" AutoGenerateColumns="false"
                        EnableModelValidation="True" EmptyDataText="No Transaction Found">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Transaction ID" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" />
                            <asp:BoundField DataField="JobID" HeaderText="Job No./Remarks" />
                            <asp:BoundField DataField="PartGroup" HeaderText="PartNumber" />
                            <asp:BoundField DataField="OpeningStock" HeaderText="Opening Stock" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="TransactQty" HeaderText="Transaction Qty" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="ClosingStock" HeaderText="Closing Stock" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="TransactionDateTime" HeaderText="Transaction Date Time" />
                            <asp:BoundField DataField="TransactionBy" HeaderText="Transaction By" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptTWPartReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlPartLookupList.ClientID%>').chosen();
            $('#<%=ddlTransactionType.ClientID%>').chosen();
            $('#<%=ddlTransactionBy.ClientID%>').chosen();
            $('#<%=ddlOptionLookupList.ClientID%>').chosen();
            $('#<%=ddlOrientationLookupList.ClientID%>').chosen();
            $('#<%=ddlSizeLookupList.ClientID%>').chosen();
        }
    </script>
</asp:Content>