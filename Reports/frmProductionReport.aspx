<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmProductionReport.aspx.cs" Inherits="Reports_frmProductionReport" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left: 25%;">
        <h3>Aerowerks Production Reports</h3>
    </div>
    <div style="width: 50%; margin-left: 25%;">
        <fieldset>
            <legend>Select Filters</legend>
            <table cellpadding="5" cellspacing="5">
                <tr>
                    <td>Start Date</td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate">
                        </asp:CalendarExtender>
                    </td>
                    <td></td>
                    <td>End Date</td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate">
                        </asp:CalendarExtender>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Country</td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGenrate" runat="server" Text="Generate" OnClick="btnGenrate_Click" />
                    </td>
                    <td></td>
                </tr>
                <%--                <tr>
                    <td colspan="6">
                        <div class="error" runat="server" id="divError" visible="false">Error message</div>
                    </td>
                </tr>--%>
            </table>
        </fieldset>
    </div>
    <div style="width: 50%; margin-left: 25%;">
        <fieldset>
            <legend>Production Report</legend>
            <table cellpadding="5" cellspacing="5" style="width: 100%;">
                <tr>
                    <td></td>
                    <td align="left" colspan="2">
                        <asp:RadioButtonList ID="rdbList" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large" onchange="showDiv()">
                            <asp:ListItem Value="0">Production Report </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </fieldset>
        <CR:CrystalReportViewer ID="rptProdcutionReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    </div>
</asp:Content>
