<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmInboundInspection.aspx.cs" Inherits="InventoryManagement_frmInboundInspection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel11" runat="server">
          <ContentTemplate>
                 <div class="col pt-2 border-bottom piDiv position-sticky">
                <div class="row">
                <div class="col-sm-12">
                    <div class="d-flex align-items-center mb-2">
                        <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                        <h4 class="title-hyphen position-relative">Inbound Inspection Summary</h4>
                        <div class="col-sm-6 justify-content-center" id="dvMsg" runat="server" visible="false">
                        <strong class="text-center"><asp:Label runat="server" CssClass="alert alert-success d-block py-1 mb-0"  ID="lblMsg"></asp:Label></strong>
                         </div>      
                    </div>        
                </div>
                </div>
                    <div class="row pb-3">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                <div class="row"> 
               <div class="col-3">
                    <div class="row">
                    <div class="col-sm-12"><label class="mb-0">Product Code</label></div>
                    <div class="col-sm chosenFullWidth">
					 <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductCodeLookUp" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlProductCodeLookUp_SelectedIndexChanged"></asp:DropDownList>	 
                    </div></div></div>
                   <div class="col-6">
                        <div class="row">
                    <div class="col-sm-12"><label class="mb-0">Part# (APN/CPN)/Description</label></div>
                    <div class="col-sm chosenFullWidth">                    
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartNo" runat="server" DataTextField="PartDes" DataValueField="PartID" OnSelectedIndexChanged="ddlPartNo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                             
                </div></div></div>
                                       <div class="col-3">
                        <div class="row">
                    <div class="col-sm-12"><label class="mb-0">&nbsp;</label></div>
                    <div class="col-sm chosenFullWidth">                    
                                                         <asp:Button ID="btnGenerateReport" runat="server" CssClass="btn btn-secondary btn-sm" Text="Report" OnClick="btnGenerateReport_Click" />            
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click"   />          
                </div></div></div>
                </div>
            </div>
                                    <div class="col-sm col-md col-lg col-xl-auto">
                <div class="row">
                    <div class="col-sm-12"><label class="mb-0">&nbsp;</label></div>
                     <div class="col-auto">
        
                     </div>
                </div>
            </div>
            </div>
          </div>
         <div class="col-12">
             <div class="row pt-3">
                 <div class="col-12">
                        <h5 class="text-uppercase">Inbound Summary Details</h5>
                    </div>
                     <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Aerowerks Part No.</label>
                            <asp:TextBox CssClass="form-control form-control-sm" autocomplete="off" Enabled="false" ID="txtAeroPartNo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label> Customer Part No.</label>
                            <asp:TextBox CssClass="form-control form-control-sm" autocomplete="off" Enabled="false" ID="txtCusPartNo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                   <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label> Product Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" autocomplete="off" Enabled="false" ID="txtProductCode" runat="server"  
                                ></asp:TextBox>
                        </div>
                    </div>
                      <div class="col-sm-8 col-md-4 col-lg-3">
                        <div class="form-group">
                            <label>Part Description</label>
                            <asp:TextBox CssClass="form-control form-control-sm" autocomplete="off" Enabled="false" ID="txtPartDes" runat="server"></asp:TextBox>
                        </div>
                    </div>
             </div>
             <div class="row border-top pt-3">
                  <div class="col-sm-12">
                       <h5 class="text-uppercase">Add New Record (* Fields are Mandatory)</h5>
                      <div class="table-responsive"  style="overflow-x:inherit !important;">
                          <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                              <tr>
                                  <th style="width: 7%;">Plant*</th>
                                  <th style="width: 13%;">Container No*</th>                                  
                                  <th style="width: 10%;">Inspection Date</th>
                                  <th style="width: 5%;">Qty Received</th> 
                                  <th style="width: 5%;">Qty Inspected</th>
                                  <th style="width: 5%;">Qty Approved</th>   
                                  <th style="width: 10%;">Status*</th>                               
                                  <th style="width: 15%;">Summary</th>
                                  <th style="width: 20%;">Upload File</th>                                
                                  <th style="width: 10%;"></th>
                              </tr>
                              <tr>
                                  <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPlant" runat="server" OnSelectedIndexChanged="ddlPlant_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Agilent</asp:ListItem>
                                            <asp:ListItem Value="2">Triflex</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td>
                                         <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerNo" runat="server" DataTextField="ContainerNo" DataValueField="ShipInfoid" >  
                                        </asp:DropDownList>                                        
                                    </td>
                                      <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtInspectionDate" autocomplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="caltxtInspectionDate" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtInspectionDate" TargetControlID="txtInspectionDate">
                                        </asp:CalendarExtender>
                                    </td>
                                  <td>
                                       <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtQtyReceived" autocomplete="off" onpaste="return false" MaxLength="5" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);" />
                                  </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtQtyInspected" autocomplete="off" onpaste="return false" MaxLength="5" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);" />
                                    </td>
                                  <td>
                                      <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtAppQty" autocomplete="off" onpaste="return false" MaxLength="5" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);" />
                                  </td>
                                  <td>
                                      <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Approved</asp:ListItem>
                                            <asp:ListItem Value="2">Rejected</asp:ListItem>
                                        </asp:DropDownList>
                                  </td>
                                  <td>
                                      <asp:TextBox CssClass="form-control form-control-sm" ID="txtSummary" MaxLength="500" runat="server" autocomplete="off" />
                                  </td>
                                   <td>
                                      <asp:FileUpload ID="fpuploadfile" Width="75%" CssClass="btn btn-success btn-sm btn-block" runat="server" />
                                  </td>
                               
                                  <td>
                                       <asp:Button CssClass="btn btn-success btn-sm rounded" ID="btnAdd" Enabled="false" runat="server" Text="Add" OnClick="btnAdd_Click"  />
                                  </td>
                              </tr>
                          </table>
                          
                      </div>
                    </div>
            </div>
             <asp:Panel ID="pangvInboundSummDetails" runat="server">
                              <div class="row pt-3">
                                  <div class="col-12">
                                       <div class="table-responsive">
                                           <asp:GridView ID="gvInboundSummDetails" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                                                ForeColor="Black" GridLines="Vertical" Width="100%" Style="font-size: medium" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" CssClass="table mainGridTable table-sm" OnRowEditing="gvInboundSummDetails_RowEditing" OnRowCancelingEdit="gvInboundSummDetails_RowCancelingEdit" OnRowUpdating="gvInboundSummDetails_RowUpdating" DataKeyNames="InspectionDetailID"  OnRowDeleting="gvInboundSummDetails_RowDeleting" OnRowCommand="gvInboundSummDetails_RowCommand" OnRowDataBound="gvInboundSummDetails_RowDataBound">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Plant*">
                                                       <EditItemTemplate>
   <asp:DropDownList ID="gvEditddlPlant" CssClass="form-control form-control-sm" runat="server" Text='<%# Eval("plantid") %>' OnSelectedIndexChanged="gvEditddlPlant_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Agilent</asp:ListItem>
                                                                <asp:ListItem Value="2">Triflex</asp:ListItem>
                                                           </asp:DropDownList>
                                                       </EditItemTemplate>
                                                       <ItemTemplate>
                  <asp:Label ID="lblPlant" runat="server" Text='<%# Eval("plant") %>'></asp:Label>
                                                       </ItemTemplate>
                                                       <HeaderStyle Width="7%" />
                                                       <ItemStyle Width="7%" />
                                                   </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Container No*" HeaderStyle-Width="13%">
                                                       <EditItemTemplate>
                                     <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEditContainerNo" runat="server" DataTextField="ContainerNo" DataValueField="ShipInfoid" >                  
                                        </asp:DropDownList>
                                <asp:Label ID="lblEditContainer" runat="server" Text='<%# Eval("ShipInfoid") %>' Visible="false"></asp:Label> 
                                                       </EditItemTemplate>
                                                       <ItemTemplate>
                                                           <asp:Label ID="lblContainerNo" runat="server" Text='<%# Eval("ContainerNo") %>'></asp:Label>
                                                       </ItemTemplate>
                                                       <HeaderStyle Width="13%" />
                                                       <ItemStyle Width="13%" />
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Inspection Date">
                                <EditItemTemplate>        
                                    <asp:TextBox ID="gvEdittxtInspectionDate"  class="form-control form-control-sm" runat="server" 
                                     Text='<%# Eval("inspectiondate","{0:MM/dd/yyyy}") %>' autocomplete="off"></asp:TextBox>                                                   
                                    <asp:CalendarExtender ID="CalgvEdittxtInspectionDate" runat="server" TargetControlID="gvEdittxtInspectionDate"                                                              Format="MM/dd/yyyy" PopupButtonID="gvEdittxtInspectionDate"></asp:CalendarExtender>                      </EditItemTemplate>
                                                       <ItemTemplate>
                                                           <asp:Label ID="lblInspectionDate" runat="server" Text='<%# Eval("inspectiondate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                       </ItemTemplate>
                                                       <ItemStyle Width="10%" />
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Qty Received">
                                                       <EditItemTemplate>
                                                         <asp:TextBox ID="gvEdittxtQtyReceived" CssClass="form-control form-control-sm text-right" runat="server" Text='<%# Eval("qtyreceived") %>' onkeypress="return onlyDotsAndNumbers(this,event);" autocomplete="off" MaxLength="5" onpaste="return false"></asp:TextBox>  
                                                       </EditItemTemplate>
                                                       <ItemTemplate>
                                    <asp:Label ID="lblqtyrecived" runat="server" Text='<%# Eval("qtyreceived") %>'></asp:Label>
                                                       </ItemTemplate>
                                                       <HeaderStyle Width="5%" />
                                                       <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                   </asp:TemplateField>


                              <asp:TemplateField HeaderText="Qty Inspected">
                                     <EditItemTemplate>
                                    <asp:TextBox ID="gvEdittxtQtyInspected" CssClass="form-control form-control-sm text-right" runat="server" Text='<%# Eval("qtyinspected") %>' onkeypress="return onlyDotsAndNumbers(this,event);" autocomplete="off" MaxLength="5" onpaste="return false"></asp:TextBox>
                                    </EditItemTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblqtyInspected"  runat="server" Text='<%# Eval("qtyinspected") %>'></asp:Label>
                                            </ItemTemplate>
                                                       <HeaderStyle Width="5%" />
                                                       <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Qty Approved">
                                                       <EditItemTemplate>
                                                           <asp:TextBox ID="gvEdittxtQtyApproved" CssClass="form-control form-control-sm text-right" runat="server" Text='<%# Eval("qtyapproved") %>' onkeypress="return onlyDotsAndNumbers(this,event);" autocomplete="off" onpaste="return false" MaxLength="5"></asp:TextBox>
                                                       </EditItemTemplate>
                                                       <ItemTemplate>
                                  <asp:Label ID="lblQtyApproved" runat="server" Text='<%# Eval("qtyapproved") %>'></asp:Label>
                                                       </ItemTemplate>
                                                       <HeaderStyle Width="5%" />
                                                       <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Status*">
                                                       <EditItemTemplate>
                              <asp:Label ID="lblEditStatus" runat="server" Text='<%# Eval("StatusID") %>' Visible="false"></asp:Label>
                              <asp:DropDownList ID="ddlEditStatus" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Approved</asp:ListItem>
                                    <asp:ListItem Value="2">Rejected</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                                                       <ItemTemplate>
                                                           <asp:Label ID="lblgvStatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                                       </ItemTemplate>
                                <ItemStyle Width="10px" />
                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Summary">
                                                       <EditItemTemplate>
                                                           <asp:TextBox ID="gvEdittxtSummary" runat="server" autocomplete="off" CssClass="form-control form-control-sm" MaxLength="500" Text='<%# Eval("remarks") %>'></asp:TextBox>
                                                       </EditItemTemplate>
                                                       <ItemTemplate>
                                                           <asp:Label ID="lblSummary" runat="server" Text='<%# Eval("remarks") %>'></asp:Label>
                                                       </ItemTemplate>
                                                       <HeaderStyle Width="15%" />
                                                       <ItemStyle Width="15%" />
                                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Download">
                                                <EditItemTemplate>
                                                    <asp:FileUpload ID="fpedituploadfile" Width="75%" CssClass="btn btn-success btn-sm btn-block"  runat="server" />
                        <asp:Label ID="lbleditfilename" runat="server" Text='<%# Eval("filename") %>' Visible="false"></asp:Label>
                                                       </EditItemTemplate>
                                                       <ItemTemplate>
                                                           <asp:LinkButton ID="lnkDownload" CommandName="lnkSelect" runat="server" Text='<%# Eval("filename") %>'></asp:LinkButton>
                                                       </ItemTemplate>
                                                       <ItemStyle Width="20%" />
                                                   </asp:TemplateField>
                                                   
                                <asp:TemplateField HeaderText="Modify">
                                <EditItemTemplate>
                                                           <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i>
                                                           </asp:LinkButton>
                                                           &nbsp;<asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                                       </EditItemTemplate>
                                                       <ItemTemplate>
                                                           <asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-info btn-sm" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                                           <asp:LinkButton CssClass="btn btn-info btn-danger" ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure to delete.?');"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                                       </ItemTemplate>
                                                       <HeaderStyle Width="10%" />
                                                       <ItemStyle Width="10%" />
                                                   </asp:TemplateField>
                                               </Columns>                                                                              
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                           </asp:GridView>
                                        </div>
                                  </div>
                                </div>
                          </asp:Panel>
         </div>
              
              <asp:HiddenField ID="hfpartnodrwaing" runat="server" />
              <asp:HiddenField ID="hfgetpartnodrwaing" runat="server" />
          </ContentTemplate>
         <Triggers>
             
             <asp:PostBackTrigger ControlID="btnAdd" />
             <asp:PostBackTrigger ControlID="gvInboundSummDetails" />
            
         </Triggers>
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
            $('#<%=ddlPartNo.ClientID%>').chosen();         
            $('#<%=ddlPlant.ClientID%>').chosen();
            $('#<%=ddlContainerNo.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlProductCodeLookUp.ClientID%>').chosen();
        }
    </script>
</asp:Content>