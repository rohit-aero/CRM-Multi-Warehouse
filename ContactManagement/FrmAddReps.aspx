<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmAddReps.aspx.cs" Inherits="ContactManagement_FrmAddReps" %>

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
                        <td class="boldtext">Rep</td>
                        <td>
                            <asp:DropDownList ID="ddlBranch" runat="server" 
                              DataTextField="BName" DataValueField="BranchID" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" 
                             ></asp:DropDownList>
                            </td>                          
                        </tr>
                        <tr>
                            <td style="width: 134px"><asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;">
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
                            </td>
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
                                    <fieldset><legend>Branch Information</legend>
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
                                                <td class="text" style="width: 196px">Region</td>
                                                <td style="width: 365px">
                                                    <asp:DropDownList ID="ddlRegion" runat="server" DataTextField="Region" DataValueField="RegionID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="text">Branch Name</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBranchMain" runat="server" DataTextField="HobartBranchName" DataValueField="HobartBranchName">
                                                    </asp:DropDownList>
                                                </td>                                              
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 196px">Branch Location</td>
                                                <td style="width: 365px">
                                                    <asp:DropDownList ID="ddlBranchLocation" runat="server" DataTextField="BName" DataValueField="BranchID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="text">Company Name</td>
                                                <td>
                                                    <asp:TextBox ID="txtBrachCompany" MaxLength="50" runat="server"></asp:TextBox>
                                                </td>                                              
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <br />
                                    <div class="clear"></div>
                                    <fieldset>  <legend>Contact Information</legend>
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
                                                <td class="text" style="width: 198px">Street Address</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtComStreet" MaxLength="50" runat="server" Width="80%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">City</td>
                                                <td>
                                                    <asp:TextBox ID="txtComCity" MaxLength="50" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">State</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComState" runat="server" DataTextField="State" DataValueField="StateID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Country</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComCountry" runat="server" DataTextField="Country" DataValueField="CountryID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Zip Code</td>
                                                <td>
                                                    <asp:TextBox ID="txtComZip" MaxLength="15" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Telephone</td>
                                                <td>
                                                    <asp:TextBox ID="txtComTel" MaxLength="20" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>Toll Free</td>
                                                <td>
                                                    <asp:TextBox ID="txtComTollFree" MaxLength="20" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">Fax Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtComFax" MaxLength="20" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>Toll Fax</td>
                                                <td>
                                                    <asp:TextBox ID="txtComTollFax" MaxLength="20" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text" style="width: 198px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <br />
                                     <div class="clear"></div>
                                    <fieldset>  
                                        <legend>Inside Sales Support Information</legend>
                                        <table style="width: 92%;" cellspacing="10">                                            
                                            <tr>
                                                <td class="text">Name</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSaleName" runat="server" DataTextField="ISSName" DataValueField="RepID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="text">&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text">Company</td>
                                                <td>
                                                    <asp:TextBox ID="txtSaleCompany" MaxLength="50" runat="server" CssClass="textarea"></asp:TextBox>
                                                </td>
                                                <td class="text">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text">Street Address</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtSaleAddress" MaxLength="50" runat="server" Width="80%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">City</td>
                                                <td>
                                                    <asp:TextBox ID="txtSaleCity" MaxLength="50" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text">State</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSaleState" runat="server" DataTextField="State" DataValueField="StateID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text">Country</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSaleCountry" runat="server" DataTextField="Country" DataValueField="CountryID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="text">Telephone</td>
                                                <td>
                                                    <asp:TextBox ID="txtSaleTel" MaxLength="25" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>Fax Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtSaleFax" MaxLength="25" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">Cell Phone</td>
                                                <td>
                                                    <asp:TextBox ID="txtSaleCell" MaxLength="25" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>Email</td>
                                                <td>
                                                    <asp:TextBox ID="txtSaleEmail" MaxLength="50" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <div class="clear"></div>                                   
                                    <fieldset>  
                                        <legend>Employee Information</legend>
                                        <table style="width: 92%;" cellspacing="10">                                            
                                            <tr>
                                                <td class="text">Fisrt Name</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="ISSName" DataValueField="RepID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="text">&nbsp;</td>
                                                <td>
                                                    Last Name</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">Abbreviation</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textarea"></asp:TextBox>
                                                </td>
                                                <td class="text">&nbsp;</td>
                                                <td>Job Title</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">Email</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>Direct Phone</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">Cell Phone</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="State" DataValueField="StateID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>Direct Fax</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">Phone Mail</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList3" runat="server" DataTextField="Country" DataValueField="CountryID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>Status</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList4" runat="server" DataTextField="Country" DataValueField="CountryID">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">Mail Sent to Home Office</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <div class="clear"></div>
                                    <fieldset>  
                                        <legend>Home Office Information </legend>
                                        <table style="width: 92%;" cellspacing="10">                                            
                                            <tr>
                                                <td class="text">Address</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList5" runat="server" DataTextField="ISSName" DataValueField="RepID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="text">&nbsp;</td>
                                                <td>
                                                    Postal Code</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">City</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="textarea"></asp:TextBox>
                                                </td>
                                                <td class="text">&nbsp;</td>
                                                <td>Phone</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text">State</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
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
       $.when.apply($, PageLoaded).then(function ()
       {
           BindDrp();
       });
       function BindDrp()
       {
            $('#<%=ddlBranch.ClientID%>').chosen();  
            $('#<%=ddlBranchLocation.ClientID%>').chosen();  
            $('#<%=ddlBranchMain.ClientID%>').chosen();  
            $('#<%=ddlComCountry.ClientID%>').chosen();  
            $('#<%=ddlComState.ClientID%>').chosen();
             $('#<%=ddlRegion.ClientID%>').chosen();  
            $('#<%=ddlSaleCountry.ClientID%>').chosen();  
            $('#<%=ddlSaleName.ClientID%>').chosen();
              $('#<%=ddlSaleState.ClientID%>').chosen();            
        }
    </script>
</asp:Content>