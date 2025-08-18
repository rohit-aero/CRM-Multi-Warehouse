<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="FrmShipmentReport.aspx.cs" Inherits="ShipmentTracker_FrmShipmentReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
<div class="row">
            <div class="col-12 pt-2">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Search Shipment Info</h4>
                </div>
            </div>
</div>
<div class="row">
<div class="col-sm-6 col-md-4 col-lg-2">
<div class="form-group">
<label>Shipment From</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipmentfrom" runat="server" DataTextField="ShipFrom" DataValueField="ShipFromid"></asp:DropDownList>
</div>
</div>
<div class="col-sm-6 col-md-4 col-lg-2">
<div class="form-group">
<label>Shipment By</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipmentBy" runat="server" DataTextField="Shipby" DataValueField="Shipbyid"></asp:DropDownList>
</div>
</div>
<div class="col-sm-6 col-md-4 col-lg-2">
<div class="form-group">
<label>Container No</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtContainerNo" AutoComplete="off" runat="server"></asp:TextBox>
</div>
</div>
<div class="col-sm-6 col-md-4 col-lg-2">
<div class="form-group">
<label>Shipment From Date</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtShippmentFromDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
<asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShippmentFromDate" TargetControlID="txtShippmentFromDate"></asp:CalendarExtender>
</div>
</div>
<div class="col-sm-6 col-md-4 col-lg-2">
<div class="form-group">
<label>Shipment To Date</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtShipmentToDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipmentToDate" TargetControlID="txtShipmentToDate"></asp:CalendarExtender>
</div>
</div>
<div class="col-sm-12">

     <div class="row">
        <div class="col-md-auto">
            <asp:Button CssClass="btn btn-secondary btn-sm" ID="btnSearch" runat="server"  Text="Search" OnClick="btnSearch_Click" />
<asp:Button CssClass="btn btn-danger btn-sm" ID="btnClear" runat="server"  Text="Clear Search" OnClick="btnClear_Click" />
<asp:Button CssClass="btn btn-primary btn-sm" ID="btnExportToExcel" CausesValidation="false" runat="server" Enabled="false"  Text="Export To Excel" OnClick="btnExportToExcel_Click"   />

            </div>
<%--         <div class="col-md justify-content-center">
<strong class="text-center"><asp:Label CssClass="alert alert-success d-block py-1" ID="lblRecordsCount" runat="server" Text="Label" Visible="false"></asp:Label></strong>
</div>--%>
         </div>
</div>

</div>

</div>
            <br />
  <div class="row border-top pt-3"></div>

       <div class="col-12">
            <div class="col-4" id="divhelp" runat="server">
        <div class="row pt-3">
            <div class="d-flex align-items-center mb-2">
                <h4>
                    <strong>Help Section: </strong>
                </h4>
            </div>
            <div class="col-12 pt-2" runat="server" id="divHobartCommissionReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Shipment Info Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Top 1 Revised ETA Descending</strong>.</li>
                        <li><strong>Container No</strong> is not null.</li>                       
                    </ul>
                </div>
            </div>
        </div>
    </div>
<div class="table-responsive">
<asp:GridView CssClass="table mainGridTable table-sm" ID="gvShipmentTracker" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                             BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                             EnableModelValidation="True" ForeColor="Black" 
                             Width="100%" OnRowCommand="gvShipmentTracker_RowCommand" OnRowDataBound="gvShipmentTracker_RowDataBound">
                             <AlternatingRowStyle BackColor="#CCCCCC" />
                             <Columns>
                                     <asp:BoundField DataField="Shipment From" HeaderText="Shipment From">
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="Shipment By" HeaderText="Shipment By">
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="Container No" HeaderText="Container No">
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="Ship Date" HeaderText="Ship Date">
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="ETA AS Per PL" HeaderText="ETA AS Per PL">
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                   <asp:BoundField DataField="Received Date" HeaderText="Received Date">
                                    <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>                             
                                  <asp:BoundField DataField="Revised ETA" HeaderText="Revised ETA">
                                <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="Comments" HeaderText="Comments">
                                <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>                                
                                <asp:TemplateField HeaderText="Packing List">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPackingList" runat="server" Text='<%# Eval("PackingList") %>' CommandName="Select"></asp:LinkButton>
                                    <asp:Label ID="lblPackingList" runat="server" Text='<%# Eval("PackingList") %>' Visible="false" ></asp:Label>
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



</ContentTemplate>
         <Triggers>
     <asp:PostBackTrigger ControlID="btnExportToExcel" />
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
              $('#<%=ddlShipmentfrom.ClientID%>').chosen();
            $('#<%=ddlShipmentBy.ClientID%>').chosen();
       }

      
</script>
</asp:Content>