<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="YTDSalesReport.aspx.cs" Inherits="Reports_rptYTDSalesReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="margin-left:25%;">
         <h3>TragenFlex Reports</h3>
     </div>
    <div style="width:50%; margin-left:25%;">
        <fieldset>
            <legend>Select Dates</legend>
        <table cellpadding="5" cellspacing="5">
            <tr>
                <td>Start Date</td><td>
                <asp:TextBox ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate">
                     </asp:CalendarExtender>
                </td>
                <td></td><td>End Date</td>
                <td>
                <asp:TextBox ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate">
                     </asp:CalendarExtender>
                </td><td></td>
            </tr>
<%--            <tr>
                <td colspan="6"><div class="error" runat="server" id="divError" visible="false">Error message</div></td> 
            </tr>  --%>       
        </table>          
        </fieldset>
          </div>
        <div style="width:50%; margin-left:25%;">
        <fieldset>
        <legend>Report</legend>
            <table cellpadding="5" cellspacing="5">
                <tr>
                    <td>
                         <asp:RadioButtonList ID="rdbTragenFlex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">YTD Sales Activity Report</asp:ListItem>
                        <asp:ListItem Value="2">Proposals</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnGenerate" CssClass="btn" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
                    </td>
                </tr>
                                 
                </table>
            </fieldset>
         <CR:CrystalReportViewer ID="rptTragenFlexPandJ" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    </div>
</asp:Content>
