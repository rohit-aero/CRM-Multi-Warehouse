<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="rptDealerRebates.aspx.cs" Inherits="Reports_rptDealerRebates" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-auto mx-auto">
            <div class="row flex-column">
                <div class="col-12 mt-3">
                    <h4 class="title-hyphen position-relative mb-3">Aerowerks Dealer Rebate Reports</h4>
                    <%--<h6>Select Filters</h6>--%>
                </div>
                <%--                <div class="col-12">
                    <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>

                </div>--%>

                <div class="col-12">
                    <div class="row">
                        <div class="col-sm-auto">
                            <div class="form-group">
                                <label>Start Date</label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-auto">
                            <div class="form-group">
                                <label>End Date</label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-auto">
                            <div class="form-group">
                                <label>Country</label>
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-auto">
                            <div class="form-group mb-0 flex-column">
                                <label class="d-block">&nbsp;</label>
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Generate" OnClick="btnGenrate_Click" />
                            </div>
                        </div>

                    </div>

                </div>
                <div class="col-12">
                    <div class="form-group">
                        <label>Select Report</label>
                        <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large">
                            <asp:ListItem Value="0" Selected="True">Aramark Rebate Report </asp:ListItem>
                            <asp:ListItem Value="1">Boelter Rebate Report</asp:ListItem>
                            <asp:ListItem Value="2">Edward Don Rebate Report</asp:ListItem>
                            <asp:ListItem Value="3">Government Sales Inc.</asp:ListItem>
                            <asp:ListItem Value="4">Trimark</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-12">
            <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        </div>
    </div>
</asp:Content>
