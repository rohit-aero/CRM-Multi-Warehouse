<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmSalesForecast.aspx.cs" Inherits="Reports_frmSalesForecast" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-md-4 mx-auto">
                <div class="row pt-3">
                    <div class="col-12">
                        <h4 class="title-hyphen position-relative mb-3">Sales Forecast Report</h4>
                    </div>
                    <%--<div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>--%>
                    <div class="col-sm-4 col-md-4">
                        <div class="form-group">
                            <label>Year</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtYear" runat="server" MaxLength="4" onkeypress="return onlyNumbers(event);" AutoComplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Preview Report" OnClick="btnSearchProposal_Click" />
                            <asp:Button ID="btnExportExcel" runat="server" CssClass="btn btn-info btn-sm" Text="Export to Excel" CausesValidation="false" OnClick="btnExportExcel_Click" />
                            <asp:Button ID="btnClearProposal" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click" />
                        </div>
                    </div>
                    <asp:GridView ID="gvReport" CssClass="table mainGridTable table-sm" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                        OnRowDataBound="gvReport_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Month" HeaderText="Month">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Monthly Forecast" DataFormatString="{0:C2}" HeaderText="Monthly Forecast">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Actual" DataFormatString="{0:C2}" HeaderText="Actual">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Variance" DataFormatString="${0:n}" HeaderText="Variance $">
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
</asp:Content>
