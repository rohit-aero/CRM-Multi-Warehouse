<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="FrmShipmentReport_New.aspx.cs" Inherits="InventoryManagement_FrmShipmentReport_New" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
      <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Shipment Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-2">
                    <div class="col-2">
                        <label>Look Up Source</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendorLookup" runat="server" DataTextField="Source" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlVendorLookup_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                             <label>Invoice No./Container No.</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerLookup" runat="server" DataTextField="ContainerDetail" DataValueField="ContainerID" AutoPostBack="True" OnSelectedIndexChanged="ddlContainerLookup_SelectedIndexChanged"></asp:DropDownList>
                    </div> 
                    <div class="col-8">
                        <label>&nbsp;</label>
                        <div class="">
                        <asp:Button ID="btnPackingDetails" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-secondary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Packing List" OnClick="btnPackingDetails_Click" Visible="false" /> 
                        <asp:Button CssClass="btn btn-secondary btn-sm" ID="btnSearch" runat="server"  Text="Search" OnClick="btnSearch_Click" />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnClear" runat="server"  Text="Clear Search" OnClick="btnClear_Click" />
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnExportToExcel" CausesValidation="false" runat="server" Enabled="false"  Text="Export To Excel" OnClick="btnExportToExcel_Click" Visible="false"  />
                        </div>
                    </div>
                </div>
            </div>     
     <div class="col-12  row border-top pt-3">
            </div>
       <div class="col-12">        
        
<div class="table-responsive">
<asp:GridView CssClass="table mainGridTable table-sm" ID="gvShipmentTracker" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
        EnableModelValidation="True" ForeColor="Black" 
        Width="100%" OnRowCommand="gvShipmentTracker_RowCommand" OnRowDataBound="gvShipmentTracker_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
  <asp:TemplateField HeaderText="Invoice No.">
        <ItemTemplate>            
            <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNo") %>'></asp:Label></ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField> 
                <asp:TemplateField HeaderText="Container No.">
        <ItemTemplate>       
            <asp:Label ID="lblContainerNo" runat="server" Text='<%# Eval("ContainerNo") %>'></asp:Label></ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>       
          <asp:BoundField DataField="ReceivedDate" HeaderText="Received Date">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
  
        <asp:TemplateField HeaderText="ETA" Visible="false">
        <ItemTemplate>
       <asp:Label ID="lblRevisedETA" runat="server" Text='<%# Eval("RevisedETA") %>'></asp:Label>                  
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Comments" Visible="false">
        <ItemTemplate>
         <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>                       
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Generate Packing List">
        <ItemTemplate>
            <asp:LinkButton ID="lnkGeneratePackingList" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" runat="server" Text='<%# Eval("ContainerNoLink") %>' CommandName="SelectPackingList"></asp:LinkButton>       
            <asp:Label ID="lblGeneratePackingList" runat="server" Text='<%# Eval("ContainerID") %>' Visible="false"></asp:Label></ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField> 
            <asp:TemplateField HeaderText="Download Doc">
        <ItemTemplate>
            <asp:LinkButton ID="lnkPackingList" runat="server" Text='<%# Eval("PackingList") %>' CommandName="Select"></asp:LinkButton>     <asp:Label ID="lblPackingList" runat="server" Text='<%# Eval("PackingList") %>' Visible="false"></asp:Label>              
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>        
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
</div>
</div>

            <asp:HiddenField ID="hfContainerID" runat="server" Value="-1" />
</ContentTemplate>
        <Triggers>           
                <asp:PostBackTrigger ControlID="btnPackingDetails" />    
              <asp:PostBackTrigger ControlID="gvShipmentTracker" />                 
        </Triggers> 
</asp:UpdatePanel>
<script type="text/javascript">
    var opennewwindow = function (jid) {
        window.location = "FrmProjects.aspx?jid=" + jid;
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
              $('#<%=ddlVendorLookup.ClientID%>').chosen();
            $('#<%=ddlContainerLookup.ClientID%>').chosen();
       }

      
</script>
     <CR:CrystalReportViewer Visible="false" ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>