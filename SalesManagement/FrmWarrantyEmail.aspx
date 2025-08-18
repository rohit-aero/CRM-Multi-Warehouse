<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
CodeFile="FrmWarrantyEmail.aspx.cs" Inherits="Transactions_FrmWarrantyEmail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="UpdatePanel11" runat="server">
<ContentTemplate>
    <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
    <fieldset>
        &nbsp;<div style="overflow-y: scroll; min-width: 200px;">
            <table width="100%" border="0" cellspacing="10">
                <tr><td>
                    <div>
                        <fieldset>  <legend>Send Email</legend>
                            <table style="width: 52%;" cellspacing="10">
                            <tr>
                            <td class="text">&nbsp;</td>
                            <td>&nbsp;</td>
                            </tr>
                            <tr>
                            <td class="text">&nbsp;</td>
                            <td>&nbsp;</td>
                            </tr>
                            </table>
                        </fieldset>
                            <br />
                            <br />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>