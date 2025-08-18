<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="rptGaylord.aspx.cs" Inherits="Reports_rptGaylord" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <%-- <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>           --%>
        <fieldset style="width: 90%; margin-top: 1%; margin-left: 2%;">
            <legend>Select Dates</legend>
            <table style="width: 500px;">
                <tr>
                    <td>From Date</td>
                    <td>
                        <asp:TextBox ID="txtFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:ImageButton ID="btnCal1" runat="server" ImageUrl="~/images/calendar.png" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFrom">
                        </asp:CalendarExtender>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td>
                        <asp:TextBox ID="txtTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                        <asp:ImageButton ID="btnCal2" runat="server" ImageUrl="~/images/calendar.png" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal2" TargetControlID="txtTo">
                        </asp:CalendarExtender>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" CausesValidation="False" />
                        <%--<asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>--%>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </fieldset>
        <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False"
            EnableParameterPrompt="False" ToolPanelView="None" />
        <%-- </ContentTemplate>
            <Triggers><asp:PostBackTrigger ControlID="rptSales"/></Triggers>
        </asp:UpdatePanel>--%>
    </div>
</asp:Content>
