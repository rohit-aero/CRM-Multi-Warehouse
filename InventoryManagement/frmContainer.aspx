<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmContainer.aspx.cs" Inherits="INVManagement_frmContainer" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel11" runat="server">
     <ContentTemplate>
      <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
        <div class="col-12 pt-2 piDiv position-sticky">
        <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Container Details</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                <div class="row">
                    <div class="col-sm-3 col-md-auto mb-3"><label class="mb-0">Lookup Requisition</label></div>
                    <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                      <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRequisitionNo" runat="server" DataTextField="ReqNo"  DataValueField="Requisitionid" AutoPostBack="True" OnSelectedIndexChanged="ddlRequisitionNo_SelectedIndexChanged"></asp:DropDownList>  
                    </div>
                </div>
            </div>
            <div class="col-sm col-md col-lg col-xl-auto">
                <div class="row">
                    <div class="col-auto">                         
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" Enabled="false"  OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click"   />
                          <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-sm" Text="Submit" Enabled="false"  OnClientClick="return confirm('Are you sure to Submit this requisition.?');"    />
                          <asp:Button ID="btnGenerate" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-primary btn-sm"  OnClientClick="window.document.forms[0].target='_blank';"  Text="Preview" OnClick="btnGenerate_Click"     />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click"  />
                    </div>   
                      <div class="col-12"><div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div></div>               
                </div>
            </div></div>
        </div>
        <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12"><h5 class="text-uppercase">Container Information</h5></div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Invoice No</label>
                              <asp:TextBox ID="txtInvoiceNo" CssClass="form-control form-control-sm"  runat="server"></asp:TextBox>                              
                        </div>
                    </div>                        
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Container No</label>
                           <asp:TextBox ID="txtContainerNo" CssClass="form-control form-control-sm"  runat="server"></asp:TextBox>
                        </div>
                    </div> 
                         
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Seal No</label>
                              <asp:TextBox ID="txtSealNo" CssClass="form-control form-control-sm"  runat="server"></asp:TextBox> 
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Sent Date</label>
                            <asp:TextBox ID="txtsentdate" CssClass="form-control form-control-sm" autocomplete="off"  runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" 
                                                PopupButtonID="txtsentdate" TargetControlID="txtsentdate">
                                                </asp:CalendarExtender>
                        </div>
                    </div>
                           
                        
                </div>  
                   <asp:Panel ID="pangvRequititionDetails" runat="server">
                <div class="row pt-3"><div class="col-12"><div class="table-responsive">
                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvContainer"  runat="server" AutoGenerateColumns="False" 
                     EnableModelValidation="True">                  
                    <Columns>                      
                        <asp:TemplateField HeaderText="Part #" HeaderStyle-Width="9%">                          
                            <ItemTemplate>
                                <asp:Label ID="lblItemPartNo" runat="server" Text='<%# Eval("PartNo") %>'></asp:Label>
                                 <asp:Label ID="lblItemPartid" runat="server" Visible="false" Text='<%# Eval("Partid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Revision #" HeaderStyle-Width="4%">                          
                            <ItemTemplate>
                                <asp:Label ID="lblItemRev" runat="server" Text='<%# Eval("revisionno") %>'></asp:Label>                                 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="30%">                            
                            <ItemTemplate>
                                <asp:Label ID="lblItemdes" runat="server" Text='<%# Eval("PartDes") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Priority" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%">                           
                            <ItemTemplate>
                                <asp:Label ID="lblItempriority" runat="server" Text='<%# Eval("ReqPriority") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="4%">                           
                            <ItemTemplate>
                                <asp:Label ID="lblItemOrderqty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shipped Qty" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="4%">                           
                            <ItemTemplate>
                                <asp:TextBox ID="txtItemshipqty" runat="server" Text='<%# Eval("ShippedQty") %>' autocomplete="off" CssClass="form-control form-control-sm text-right" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>  
                         <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="25%">                           
                            <ItemTemplate>
                                <asp:TextBox ID="txtItemRemarks" runat="server" Text='<%# Eval("Remarks") %>' MaxLength="500" autocomplete="off" CssClass="form-control form-control-sm text-left" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                    </Columns>                  
                </asp:GridView>
            </div></div></div>
            </asp:Panel>                
            
           </div>  
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
           $('#<%=ddlRequisitionNo.ClientID%>').chosen();
        }
    </script>            
        <asp:HiddenField ID="hfpartid" runat="server" />
        <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />          
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="btnGenerate" />
        </Triggers>
    </asp:UpdatePanel>    
</asp:Content>