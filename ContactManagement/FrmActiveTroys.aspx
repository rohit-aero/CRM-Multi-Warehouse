<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmActiveTroys.aspx.cs" Inherits="ContactManagement_FrmActiveTroys" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <fieldset>
                <legend>Search</legend>
                <fieldset style="width: 70%; margin-top: 1%; margin-left: 2%;">
                    <table style="margin-left: 2%; margin-top: 1%; width: 70%;">
                        <tr>
                        <td class="boldtext">Troy Employee</td>
                        <td>
                            <asp:DropDownList ID="ddlTroyEmployee" runat="server" 
                              DataTextField="BName" DataValueField="BranchID" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" 
                             ></asp:DropDownList>
                            </td>                          
                        </tr>
                        <tr>
                            <td style="width: 134px">
                            <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                            </asp:Panel>
                            </td>
                            <td style="width: 131px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 134px"></td>
                            <td style="width: 389px"></td>
                        </tr>
                        <tr>
                            <td style="width: 134px"></td>
                            <td style="width: 389px"></td>
                        </tr>
                    </table>
                    <table style="margin-left: 70%; margin-top: -5%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" OnClick="btnSave_Click" OnClientClick="return confirm('Are you sure.?');" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" OnClick="btnCancel_Click" />
                            </td>
                            <%-- <td>
                                <asp:Button ID="Button2" runat="server" CssClass="btn" Text="Edit" />
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <input type="button" class="btn" value="Previous Page" onclick="previousPage()" /></td>
                           <%-- </td>--%>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                </fieldset>
                <div style="overflow-y: scroll; min-width: 200px; height: 500px;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <table width="90%" border="0" cellspacing="10">                       
                        <tr>
                            <td>
                                <div>
                                    <fieldset>  <legend>Company Information</legend>
                                        <table style="width: 100%;" cellspacing="10">
                                            <%--<tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>--%>
                                            <tr>
                                                <td class="text" style="width: 196px">Company</td>
                                                <td style="width: 365px">
                                                    <asp:TextBox ID="txtBrachCompany" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="text">Branch</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBranchMain" runat="server" DataTextField="BranchName" DataValueField="BranchID">
                                                    </asp:DropDownList>
                                                </td>                                              
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 196px">Branch Name</td>
                                                <td style="width: 365px">
                                                    <asp:TextBox ID="txtBrachName" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="text">&nbsp;</td>
                                                <td>
                                                &nbsp;</td>                                              
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <br />
                                    <div class="clear"></div>
                                    <fieldset>  <legend>Employee Information</legend>
                                        <table style="width: 90%;" cellspacing="10">
                                            <%--<tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>--%>
                                            <tr>
                                                <td class="text" style="width: 198px">First Name</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Last Name</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Abbreviation</td>
                                                <td colspan="4">
                                                    <asp:DropDownList ID="ddlAbbrevation" runat="server" DataTextField="Abb" DataValueField="AbbreviationID">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Direct Phone</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtDirectPhone" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Phone Mail</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtPhoneMail" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Direct Fax</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtDirectFax" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Cell Phone</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Email</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td class="text" style="width: 198px">Status</td>
                                            <td>
                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>Active</asp:ListItem>
                                                <asp:ListItem>Quit</asp:ListItem>
                                                <asp:ListItem>Retired</asp:ListItem>
                                                <asp:ListItem>Temp Leave</asp:ListItem>
                                            </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            </tr>                                       
                                        </table>
                                    </fieldset>
                                    <br />
                                    <div class="clear"></div>
                                    &nbsp;<div class="clear"></div>                                   
                                    &nbsp;<div class="clear"></div>
                                    <fieldset>  
                                        <legend>Home Office Information </legend>
                                        <table style="width: 92%;" cellspacing="10">                                            
                                            <tr>
                                                <td class="text" style="width: 158px">Address</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtHomeAddress" runat="server" Width="70%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="height: 32px; width: 158px">Postal Code</td>
                                                <td style="height: 32px">
                                                    <asp:TextBox ID="txtHomePostalCode" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="text" style="height: 32px"></td>
                                                <td style="height: 32px"></td>
                                                <td style="height: 32px"></td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 158px">City</td>
                                                <td>
                                                    <asp:TextBox ID="txtHomeCity" runat="server" CssClass="textarea"></asp:TextBox>
                                                </td>
                                                <td class="text">&nbsp;</td>
                                                <td>Phone</td>
                                                <td>
                                                    <asp:TextBox ID="txtHomePhone" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 158px">State</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlHomeState" runat="server" DataTextField="State" DataValueField="StateID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>Fax</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    &nbsp;</div>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
           $(document).ready(function () {           
           Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
       });
       function PageLoaded(sender, args) {
           BindDrp();
       }
       $.when.apply($, PageLoaded).then(function () {
           BindDrp();
       });
        function BindDrp() {
            $('#<%=ddlAbbrevation.ClientID%>').chosen();  
            $('#<%=ddlBranchMain.ClientID%>').chosen();  
            $('#<%=ddlHomeState.ClientID%>').chosen();  
            $('#<%=ddlStatus.ClientID%>').chosen();  
            $('#<%=ddlTroyEmployee.ClientID%>').chosen();
        }
    </script>
</asp:Content>