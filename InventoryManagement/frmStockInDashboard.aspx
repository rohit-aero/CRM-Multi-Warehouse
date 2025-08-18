<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmStockInDashboard.aspx.cs" Inherits="INVManagement_frmStockInDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="col-12 pt-2 piDiv position-sticky">
    <div class="row">
            <div class="col-12">
                <div class="d-flex align-items-center mb-2">
                    <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i> Back</button>
                    <h4 class="title-hyphen position-relative">Stock In Dashboard</h4>
                </div>
            </div>
        </div>
</div>
<div class="col-12">
    <h5 class="text-uppercase">In-Transit</h5>
</div>

<div class="col-12 pt-0">          
     <div class="table-responsive">     
      <asp:GridView CssClass="table mainGridTable table-sm" ID="gvInTransit" 
          runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                 ForeColor="Black" GridLines="Vertical" Width="100%" OnRowDataBound="gvInTransit_RowDataBound" 
          EmptyDataText="No Data Found" AutoGenerateColumns="False" EnableModelValidation="True">

          <Columns>
             <asp:BoundField DataField="ContainerID" HeaderText="Container No">
              <HeaderStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No">
              <HeaderStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="ContainerNo" HeaderText="Container No">
              <ItemStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="Vendor" HeaderText="Vendor">
              <HeaderStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="ETA" HeaderText="ETA">
              <HeaderStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="Comments" HeaderText="Comments">
              <ItemStyle Width="100px" />
              </asp:BoundField>
          </Columns>

      </asp:GridView>
     </div>

</div>


<%--<div class="">
</div>--%>
<div class="col-12  row border-top pt-1">   
</div>    
<div class="col-12">          
     <h5 class="text-uppercase">Arrived</h5>
      <div class="table-responsive">    
      <asp:GridView CssClass="table mainGridTable table-sm" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                 ForeColor="Black" GridLines="Vertical" Width="100%" ID="gvContainerArrived" runat="server" OnRowDataBound="gvContainerArrived_RowDataBound" EmptyDataText="No Data Found" AutoGenerateColumns="False" EnableModelValidation="True" >
          <Columns>
              <asp:BoundField DataField="ContainerID" HeaderText="Container ID">
              <HeaderStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No">
              <HeaderStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="ContainerNo" HeaderText="Container No">
              <ItemStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="Source" HeaderText="Vendor">
              <HeaderStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="ReceivedDate" HeaderText="Arrived Date">
              <HeaderStyle Width="50px" />
              </asp:BoundField>
              <asp:BoundField DataField="StockIn" HeaderText="Stock In">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle Width="100px" HorizontalAlign="Left" />
              </asp:BoundField>
          </Columns>
      </asp:GridView>
     </div>
</div>


<%--<div class="row border-top pt-2">
</div>--%>
<div class="col-12 row border-top pt-1">    
</div>
<div class="col-12 pt-1">          
    <h5 class="text-uppercase">Stock In Hand</h5>
     <div class="scrollable-container" style="position: relative; height: 170px; overflow-y: auto; overflow-x: hidden; border: 1px solid #999;">     
      <asp:GridView CssClass="table mainGridTable table-sm" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                 ForeColor="Black" GridLines="Vertical" Width="100%" ID="gvStockInhand" runat="server" OnRowDataBound="gvStockInhand_RowDataBound" 
          EmptyDataText="No Data Found" AutoGenerateColumns="False" EnableModelValidation="True" AllowSorting="true" OnSorting="gvStockInhand_Sorting">
           <Columns>
              <asp:BoundField DataField="PartID" HeaderText="Part ID" SortExpression="PartID">           
              </asp:BoundField>
              <asp:BoundField DataField="PartNo" HeaderText="Part No" SortExpression="PartNo">              
              </asp:BoundField>
              <asp:BoundField DataField="Description" HeaderText="Part Description" SortExpression="Description">              
              </asp:BoundField>
              <asp:BoundField DataField="StockIn" HeaderText="Stock In Hand" SortExpression="StockIn"> 
                 <ItemStyle HorizontalAlign="Right" />  
              </asp:BoundField>                   
          </Columns>
      </asp:GridView>
     </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>