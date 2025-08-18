<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmTWForecasting.aspx.cs" Inherits="Reports_frmTWForecasting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 border-bottom piDiv position-sticky py-3">
                <div class="row">
                    <div class="col-sm-12 col-md-12 mx-auto">
                        <div class="row">
                            <div class="col-12">
                                <h4 class="title-hyphen position-relative mb-3">Turbowash Forecasting Report</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <div class="row">
                                    <label class="col-12">&nbsp;</label>
                                    <div class="col-12">
                                        <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" />
                                        <asp:Button CssClass="btn btn-success btn-sm" ID="btnExportToExcel" runat="server" Text="Export To Excel" CausesValidation="false" Enabled="false" OnClick="btnExportToExcel_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 mt-3">
                <div class="table-responsive eoeTable" style="height: 750px">
                    <asp:GridView ID="gvSearch" runat="server" CellPadding="3"
                        EmptyDataText="No Items Found" Width="100%"
                        CssClass="verticalHeading mx-auto text-center"
                        EnableModelValidation="True"
                        OnRowDataBound="gvSearch_RowDataBound"
                        OnDataBound="gvSearch_DataBound">
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
