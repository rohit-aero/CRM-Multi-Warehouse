<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="frmShipmentInfo.aspx.cs" Inherits="ShipmentTracker_frmShipmentInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel11" runat="server">
<ContentTemplate>
 <div class="col pt-2 border-bottom piDiv position-sticky">
 <div class="row">
 <div class="col-sm-12">
        <div class="d-flex align-items-center mb-2">
        <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
        <h4 class="title-hyphen position-relative mr-3">China/India Shipment Information</h4>     
            <div class="col-sm-6 justify-content-center" id="dvMsg" runat="server" visible="false">
            <strong class="text-center"><asp:Label runat="server" CssClass="alert alert-success d-block py-1 mb-0"  ID="lblMsg"></asp:Label></strong>
            </div>      
        </div>        
    </div> 
</div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                <div class="row">
                    <div class="col-sm-3 col-md-auto mb-3"><label class="mb-0">Lookup Container No</label></div>
                    <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                      <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerNo" DataValueField="ShipInfoid" DataTextField="ContainerNo" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlContainerNo_SelectedIndexChanged"></asp:DropDownList>  
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg col-xl-auto">               
                <div class="row">
                    <div class="col-auto">                         
                                <asp:Button ID="btnSave"  runat="server" CssClass="btn btn-success btn-sm"   CausesValidation="false" Text="Save" OnClick="btnSave_Click"   />                             
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click"   />
                    </div>   
                      <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>               
                </div>
            </div>
</div>
  </div>
                  <div class="col-12">
            <h5 class="text-uppercase">
                <h5 class="text-uppercase">Add New Record</h5>             
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">
                            Shipment From*</label>
                            <asp:DropDownList ID="ddlShipmentFrom" runat="server" CssClass="form-control form-control-sm" DataTextField="ShipFrom" DataValueField="ShipFromid">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">
                            Shipment By*</label>
                            <asp:DropDownList ID="ddlShipmentby" runat="server" CssClass="form-control form-control-sm" DataTextField="Shipby" DataValueField="Shipbyid">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">
                            Container No*</label>
                            <asp:TextBox ID="txtContainerNum" runat="server" autocomplete="off" MaxLength="50" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">
                            Shipped Date*</label>
                            <asp:TextBox ID="txtShippedDate" runat="server" autocomplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShippedDate" TargetControlID="txtShippedDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group chosenFullWidth">
                            <label class="text-danger">
                            ETA As Per PL*</label>
                            <asp:TextBox ID="txtETAAsPerPL" runat="server" autocomplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtETAAsPerPL" TargetControlID="txtETAAsPerPL">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group chosenFullWidth">
                            <label>
                            Received Date</label>
                            <asp:TextBox ID="txtReceivedDate" runat="server" autocomplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReceivedDate" TargetControlID="txtReceivedDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group chosenFullWidth">
                            <label>
                            Packing List</label>                    
                                      <asp:FileUpload ID="fpUploadDrawing" CssClass="btn btn-success btn-sm btn-block" runat="server" />
                                 
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-10">
                        <div class="form-group chosenFullWidth">
                              <label>
                            &nbsp;</label>  
                          <asp:LinkButton ID="lnkDowload" runat="server" CssClass="w-100 d-block" Visible="false" OnClientClick="openInNewTab();" OnClick="lnkDowload_Click"></asp:LinkButton>
                            </div>
                    </div>
                </div>                   
            </div>    
      <div class="col-12 pt-3">
     <div class="table-responsive">
      <asp:GridView CssClass="table mainGridTable table-sm" ID="GvShipmentTracker" runat="server" AutoGenerateColumns="False" DataKeyNames="ShipInfoDetailId"
     EnableModelValidation="True"  ShowFooter="True"  style="margin-top: 0px" OnRowCancelingEdit="GvShipmentTracker_RowCancelingEdit" OnRowDeleting="GvShipmentTracker_RowDeleting" OnRowEditing="GvShipmentTracker_RowEditing" OnRowUpdating="GvShipmentTracker_RowUpdating" >
        <Columns>
              <asp:TemplateField HeaderText="Revised ETA" HeaderStyle-Width="12%">
                  <EditItemTemplate>
                      <asp:TextBox ID="txtUpdateRevisedETA" runat="server" class="form-control form-control-sm" autocomplete="off"   Text='<%# Eval("RevisedETA", "{0:MM/dd/yyyy}") %>'></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtUpdateRevisedETA" TargetControlID="txtUpdateRevisedETA">
                            </asp:CalendarExtender>
                  </EditItemTemplate>
                  <FooterTemplate>
                      <asp:TextBox ID="txtFooterRevisedETA" runat="server" class="form-control form-control-sm" autocomplete="off"  Text='<%# Eval("RevisedETA", "{0:MM/dd/yyyy}") %>'></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFooterRevisedETA" TargetControlID="txtFooterRevisedETA">
                            </asp:CalendarExtender>
                  </FooterTemplate>
                  <ItemTemplate>
                      <asp:Label ID="txtRevisedETA" runat="server" autocomplete="off" Text='<%# Eval("RevisedETA", "{0:MM/dd/yyyy}") %>' ></asp:Label>                      
                  </ItemTemplate>                 
                  
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="68%">
                  <EditItemTemplate>
                      <asp:TextBox ID="txtUpdateComments" runat="server" class="form-control form-control-sm" MaxLength="250" TextMode="MultiLine"  Text='<%# Eval("Comments") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <FooterTemplate>
                      <asp:TextBox ID="txtFooterComments" runat="server" class="form-control form-control-sm" MaxLength="250" TextMode="MultiLine"  Text='<%# Eval("Comments") %>'></asp:TextBox>
                  </FooterTemplate>
                  <ItemTemplate>
                      <asp:Label ID="txtComments" runat="server" MaxLength="250" TextMode="MultiLine"  Text='<%# Eval("Comments") %>'></asp:Label>
                  </ItemTemplate>               
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Add" HeaderStyle-Width="6%">
                  <EditItemTemplate>
                      <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton> 
                      &nbsp;<asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                  </EditItemTemplate>
                  <FooterTemplate>
                      <asp:UpdatePanel ID="UpdatePanelAdd" runat="server">
                          <ContentTemplate>
                               <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" CausesValidation="false" runat="server" Text="Add" OnClick="btnAdd_Click" />
                          </ContentTemplate>
                      </asp:UpdatePanel>                     
                  </FooterTemplate>
                  <ItemTemplate>
                      <asp:LinkButton CssClass="btn btn-info btn-sm" ID="lnkEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                      &nbsp;
                      <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure to delete. ?');" CommandName="Delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                  </ItemTemplate>                
              </asp:TemplateField>
          </Columns>                   
</asp:GridView>
  </div>
        </div>
    <asp:HiddenField ID="HfFilename" runat="server" />
       <asp:HiddenField ID="hfgetdrawing" runat="server" />
</ContentTemplate>    
 <Triggers>
     <asp:PostBackTrigger ControlID="btnSave" />    
      <asp:PostBackTrigger ControlID="lnkDowload" />
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
            $('#<%=ddlContainerNo.ClientID%>').chosen();  
           $('#<%=ddlShipmentby.ClientID%>').chosen();  
           $('#<%=ddlShipmentFrom.ClientID%>').chosen();           
       }   
</script>  
</asp:Content>