<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmAssignMenuToGroups.aspx.cs" Inherits="Administration_FrmAssignMenuToGroups" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">User Groups</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6">
                <div class="row">
                    <div class="col-sm-auto mb-3"><label class="mb-0">Group Name</label></div>
                    <div class="col-sm mb-3 chosenFullWidth">
					  <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlGroup" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" ></asp:DropDownList>                 
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg-auto">
                <div class="row">
                    <div class="col-sm">
					    <asp:Button CssClass="btn btn-success btn-sm" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        </div>                   
                </div>
            </div>          
		</div>
</div>
<asp:Panel ID="PanelAssignMenuToGroups" runat="server" Visible="false">
<div class="col-12">
<div class="row pt-3">
<div class="col-12"><h5 class="text-uppercase">Details</h5></div>
<div class="col-12">
<div class="table-responsive">
<asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvGroup" runat="server" AutoGenerateColumns="False"  CellPadding="3" EnableModelValidation="True" Width="100%" OnRowDataBound="gvGroup_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                       <Columns>
                           <asp:TemplateField HeaderText="Status ">
                               <HeaderTemplate>
                                   <asp:CheckBox ID="chkAllStatus" runat="server" Text="Status" onclick="checkAllRow(this);" />
                               </HeaderTemplate>
                               <ItemTemplate>
                                   <asp:CheckBox ID="chkStatus" runat="server" Text='<%# Eval("status") %>'   />
                               </ItemTemplate>
                               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="id" Visible="False">
                               
                               <ItemTemplate>
                                   <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>' ></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:BoundField DataField="name" HeaderText="Menu Name" >

                           <HeaderStyle HorizontalAlign="Left" />
                           <ItemStyle HorizontalAlign="Left" />
                           </asp:BoundField>
                           <asp:BoundField DataField="description" HeaderText="Description" >
                           <HeaderStyle HorizontalAlign="Left" />
                           <ItemStyle HorizontalAlign="Left" />
                           </asp:BoundField>
                       </Columns>
                       <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                       <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                       <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                       <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                       <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
                   </asp:GridView>
</div>
</div>
</div>
</div>
</asp:Panel>
</ContentTemplate>
</asp:UpdatePanel>
                <script type="text/javascript">

                    //TODO
                    // REMOVE IF NOT IN USE

                    function CheckRow(objRef) {
                        //Get the Row based on checkbox
                        var row = objRef.parentNode.parentNode; 
                        //Get the reference of GridView
                        var GridView = row.parentNode; 
                        //Get all input elements in Gridview
                        var inputList = GridView.getElementsByTagName("input");
                        for (var i = 0; i < inputList.length; i++) {
                            //The First element is the Header Checkbox
                            var headerCheckBox = inputList[0]; 
                            //Based on all or none checkboxes
                            //are checked check/uncheck Header Checkbox
                            var checked = true;
                            if (inputList[i].type == "checkbox" && inputList[i]
                                                           != headerCheckBox) {
                                if (!inputList[i].checked) {
                                    checked = false;
                                    break;
                                }

                            }

                        }

                        headerCheckBox.checked = checked; 

                    } 

                    function checkAllRow(objRef) {

                        var GridView = objRef.parentNode.parentNode.parentNode;

                        var inputList = GridView.getElementsByTagName("input");

                        for (var i = 0; i < inputList.length; i++) {

                            //Get the Cell To find out ColumnIndex

                            var row = inputList[i].parentNode.parentNode;

                            if (inputList[i].type == "checkbox" && objRef != inputList[i])
                            {

                                if (objRef.checked) {

                                    //If the header checkbox is checked

                                    //check all checkboxes

                                    //and highlight all rows

                                    //row.style.backgroundColor = "#FAEBD7";

                                    inputList[i].checked = true;

                                }

                                else {

                                    //If the header checkbox is checked

                                    //uncheck all checkboxes

                                    //and change rowcolor back to original

                                   

                                    inputList[i].checked = false;

                                }

                            }

                        }

                    }

                     $(document).ready(function () {
           
           Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
       });
       function PageLoaded(sender, args) {
           
           DDL();
           
       }
       $.when.apply($, PageLoaded).then(function () {
           DDL();
          
       });
       function DDL() {
            $('#<%=ddlGroup.ClientID%>').chosen();
          
       }


                </script>
 </asp:Content>

