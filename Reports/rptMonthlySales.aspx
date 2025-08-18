<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="rptMonthlySales.aspx.cs" Inherits="Reports_rptMonthlySales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
              <fieldset style="width:90%; margin-top:1%; margin-left:2%;">
              <legend>Select Dates</legend>
        <table style="width:85%;">
            <tr>
                <td>From Date</td>
                <td>
                    <asp:TextBox ID="txtFrom" runat="server" AutoComplete="off" Width="100px" OnBlur="validateDate(this)"></asp:TextBox>
                    <asp:ImageButton ID="btnCal1" runat="server" ImageUrl="~/images/calendar.png" />
                     <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFrom">
                     </asp:CalendarExtender>
                </td>
                <td>To Date</td>
                <td>
                    <asp:TextBox ID="txtTo" runat="server" AutoComplete="off" Width="100px" OnBlur="validateDate(this)"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal2"  TargetControlID="txtTo">
                     </asp:CalendarExtender>
                      <asp:ImageButton ID="btnCal2" runat="server" ImageUrl="~/images/calendar.png" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
              
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
              
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Country</td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
              
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
              
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
              
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" CausesValidation="False" />
                    </td>
                <td>
              
                    &nbsp;</td>
            </tr>
<%--            <tr>
                <td colspan="6">
                    <div class="error" runat="server" id="divError" visible="false">Error message</div>
                </td>
            </tr>--%>
            </table>
        </fieldset>
        <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    </div>
</asp:Content>