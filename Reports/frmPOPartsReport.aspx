<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPOPartsReport.aspx.cs" Inherits="Reports_frmPOPartsReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Parts Detail</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Order Date From*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrderDateFrom" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtOrderDateFrom"
                                TargetControlID="txtOrderDateFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Order Date To*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrderDateTo" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtOrderDateTo"
                                TargetControlID="txtOrderDateTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md justify-content-center">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-sm" Text="Preview PO" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />

                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
    <CR:CrystalReportViewer ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
