<%@ Page Title="" Language="C#" MasterPageFile="~/Settings.master" AutoEventWireup="true"
    CodeFile="FrmCategoryTypeMaster.aspx.cs" Inherits="ContactManagement_FrmCategoryTypeMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Category Type Master</legend>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="600px" border="0" cellspacing="0" cellpadding="0">
                                         <tr>
                                                <td align="left" valign="top" width="25%">
                                                    Category Type Name
                                                </td>
                                                <td align="left" valign="top" width="5%">
                                                    &nbsp;
                                                </td>
                                                <td align="left" valign="top" class="w-25" style="width: 22%">
                                                    <asp:TextBox ID="txtCategoryTypeName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtCategoryTypeName" ErrorMessage="*" ValidationGroup="chk"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" valign="top" width="35%">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" width="25%">
                                                    &nbsp;</td>
                                                <td align="left" valign="top" width="5%">
                                                    &nbsp;</td>
                                                <td align="left" valign="top" class="w-25" style="width: 22%">
                                                    &nbsp;</td>
                                                <td align="left" valign="top" width="35%">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" width="25%">
                                                    &nbsp;</td>
                                                <td align="left" valign="top" width="5%">
                                                    &nbsp;</td>
                                                <td align="left" valign="top" class="w-25" style="width: 22%">
                                                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
                                                        ValidationGroup="chk" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                        ValidationGroup="chk" onclick="btnCancel_Click" />
                                                </td>
                                                <td align="left" valign="top" width="35%">
                                                <input type="button" class="btn" value="Previous Page" onclick="previousPage()" /></td>  
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv" Width="500px" runat="server" BackColor="#CCCCCC" BorderColor="#999999"
                                            BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"
                                            AutoGenerateColumns="False" DataKeyNames="CategoryTypeID" OnRowDeleting="gv_RowDeleting"
                                            OnRowUpdating="gv_RowUpdating" HeaderStyle-HorizontalAlign="Left" 
                                            RowStyle-HorizontalAlign="Left">
                                            <RowStyle BackColor="White" />
                                            <Columns>                                                
                                                <asp:BoundField DataField="CategoryTypeName" HeaderText="Category Name" />
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="OnEdit" runat="server" Text="Edit" CommandName="Update" CausesValidation="false"
                                                            ToolTip="Edit">
                                            <img src="../Images/edit.png"height="20px" width="20px" alt="" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="OnDelete" runat="server" Text="Delete" CommandName="Delete" CausesValidation="false"
                                                            ToolTip="Update" OnClientClick='return confirm("Are you sure you want to delete this ?")'>
                                            <img src="../Images/delete.png"height="20px" width="20px" alt="" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="SkyBlue" Font-Bold="True" ForeColor="Black" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>       
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>