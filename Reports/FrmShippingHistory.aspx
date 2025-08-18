<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" EnableEventValidation="false"  CodeFile="FrmShippingHistory.aspx.cs" Inherits="Reports_FrmShippingHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12 mb-3">
                        <h5 class="title-hyphen text-uppercase">Shipping History Report</h5>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Invoice Date From</label>
                            <asp:TextBox ID="txtFromDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtFromtDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Invoice Date To</label>
                            <asp:TextBox ID="txtToDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtToDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtToDate" TargetControlID="txtToDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox runat="server" ID="txtCity" CssClass="form-control form-control-sm" MaxLength="50" AutoComplete="off"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Industry</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlIndustry" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <%--<label class="col-md-12">&nbsp;</label>--%>
                            <div class="col-md-6">
                                <asp:Button ID="btnShow" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" Text="Search" OnClick="btnShow_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClear_Click" />
                                <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Enabled="false" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
                            </div>
                            <div class="col-md-6 justify-content-center">
                                <strong class="text-center">
                                    <asp:Label CssClass="alert alert-success d-block py-1" ID="lblRecordsCount" runat="server" Text="Label" Visible="false"></asp:Label>
                                </strong>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col">
                <asp:GridView ID="gvShippingHistory" runat="server" ForeColor="White" CssClass="table mainGridTable table-sm mb-0" EnableModelValidation="True"
                    AutoGenerateColumns="false" DataKeyNames="JobID" AllowSorting="true" OnSorting="gvShippingHistory_Sorting" OnRowDataBound="gvShippingHistory_RowDataBound"
                    OnRowCommand="gvShippingHistory_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Job #" Visible="true" SortExpression="JobID">
                            <ItemTemplate>
                                <asp:Label ID="lblJobID" runat="server" Text='<%# Eval("JobID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Name" SortExpression="ProjectName" ItemStyle-Width="25%">
                            <ItemTemplate>
                                <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                       

                         <asp:TemplateField HeaderText="Model" SortExpression="Model">
                            <ItemTemplate>
                                <asp:Label ID="lblModels" runat="server" Text='<%# Eval("Models") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Order For" SortExpression="OrderBelongsTo">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderBelongsTo" runat="server" Text='<%# Eval("OrderBelongsTo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="City" SortExpression="City">
                            <ItemTemplate>
                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="State" SortExpression="State">
                            <ItemTemplate>
                                <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Country" SortExpression="Country">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Invoice Date" SortExpression="InvoiceDate">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%#  String.Format("{0:MM/dd/yyyy}", Eval("InvoiceDate")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Net Eq. Price" SortExpression="NetEqPrice" HeaderStyle-CssClass="align-right">
                            <ItemTemplate>
                                <asp:Label ID="lblNetEqPrice" runat="server" Text='<%# "$" + String.Format("{0:N2}", Eval("NetEqPrice")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Freight" SortExpression="Freight" HeaderStyle-CssClass="align-right">
                            <ItemTemplate>
                                <asp:Label ID="lblFreight" runat="server" Text='<%# "$" + String.Format("{0:N2}", Eval("Freight")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Installation" SortExpression="Installation" HeaderStyle-CssClass="align-right">
                            <ItemTemplate>
                                <asp:Label ID="lblInstallation" runat="server" Text='<%# "$" + String.Format("{0:N2}", Eval("Installation")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Actual Shipping Cost" SortExpression="ActualShippingCost" HeaderStyle-CssClass="align-right">
                            <ItemTemplate>
                                <asp:Label ID="lblActualShipping" runat="server" Text='<%# "$" + String.Format("{0:N2}", Eval("ActualShippingCost")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
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
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlIndustry.ClientID%>').chosen();
        }

    </script>
</asp:Content>
