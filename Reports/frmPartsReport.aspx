<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPartsReport.aspx.cs" Inherits="Reports_frmPartsReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 border-bottom piDiv position-sticky py-3">
                <div class="row">
                    <div class="col-12 mx-auto">
                        <h4 class="title-hyphen position-relative mb-3">Aerowerks Parts Report</h4>
                    </div>
<%--                    <div class="col-12">
                        <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                    </div>--%>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label>Product Line</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProduct" runat="server" DataTextField="Product" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm">
                        <div class="row">
                            <label class="col-12">&nbsp;</label>
                            <div class="col-12">
                                <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-success btn-sm" Text="Generate" OnClick="btnSearchProposal_Click" />
                                <asp:Button ID="btnExportExcel" runat="server" CssClass="btn btn-info btn-sm" Text="Export to Excel" CausesValidation="false" OnClick="btnExportExcel_Click" />
                                <asp:Button ID="btnClearProposal" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>     
                 <div class="col-12" id="divPartStatusReport" runat="server" style="display:none">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5><strong>Help Section: </strong></h5>
                    </div>
                    <div class="col-12 pt-2">
                    <div class="d-flex align-items-center mb-2">
                        <h5>
                            <strong>Aerowerks Parts Report</strong>
                        </h5>
                    </div>
                    <div class="col-12">
                        <ul>
                            <li>Part Status <strong> Current Or (Obsolete and Stock in hand Greater than Zero)</strong>.</li>                       
                        </ul>
                    </div>
                </div>
                </div>
            </div>      
            <div class="col-12 pt-3">
        <div class="table-responsive">
            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvSearch" runat="server" AutoGenerateColumns="False"
                EnableModelValidation="True" EmptyDataText="Part not Found">
                <Columns>
                    <asp:BoundField HeaderText="Product Line" DataField="Product" SortExpression="Product" HeaderStyle-Width="10%">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Part Number" DataField="Partnumber" SortExpression="Partnumber" HeaderStyle-Width="10%">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Part Description" DataField="PartDes" SortExpression="PartDes" HeaderStyle-Width="30%">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Stock in Hand" DataField="stockinhand" SortExpression="stockinhand" HeaderStyle-Width="8%">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Min" DataField="min" SortExpression="min" HeaderStyle-Width="8%">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Max" DataField="max" SortExpression="max" HeaderStyle-Width="8%">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Reorder Point" DataField="reorderpoint" SortExpression="reorderpoint" HeaderStyle-Width="8%">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Reorder Qty" DataField="reorderqty" SortExpression="reorderqty" HeaderStyle-Width="8%">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportExcel" />
        </Triggers>
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
            $('#<%=ddlProduct.ClientID%>').chosen();
        }
    </script>
</asp:Content>