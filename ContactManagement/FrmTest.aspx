<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmTest.aspx.cs" Inherits="Masters_FrmTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <fieldset>
                <legend>City Information</legend>
                <fieldset style="width: 90%; margin-top: 1%; margin-left: 2%;">
                    <table style="margin-left: 2%; margin-top: 1%; width: 45%;">
                        <tr>
                        <td class="boldtext">City</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" 
                                 PopupButtonID="TextBox1" TargetControlID="TextBox1">
                             </asp:CalendarExtender>
                        </td>
                        </tr>
                        <tr>
                            <td style="width: 134px"></td>
                            <td style="width: 389px"></td>
                        </tr>
                    </table>                    
                    <table style="margin-left: 35%; margin-top: -2%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" OnClick="btnSave_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" OnClick="btnCancel_Click" />
                            </td>
                            <%-- <td>
                                <asp:Button ID="Button2" runat="server" CssClass="btn" Text="Edit" />
                            </td>--%>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                </fieldset>               
                </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>