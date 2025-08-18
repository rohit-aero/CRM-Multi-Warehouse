<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="FrmRequisitionReport.aspx.cs" Inherits="Reports_FrmRequisitionReport" %>
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
                            <h4 class="title-hyphen position-relative">Requisition Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-2">
                    <div class="col-2">
                        <label>Look Up Prepared By</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPreparedBy" runat="server" DataTextField="FirstName" DataValueField="EmployeeID" AutoPostBack="True" OnSelectedIndexChanged="ddlPrepareBy_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                             <label>Requisition No.</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRequisition" runat="server" DataTextField="ReqNo" DataValueField="RequisitionID" AutoPostBack="True" OnSelectedIndexChanged="ddlRequisition_SelectedIndexChanged"></asp:DropDownList>
                    </div> 
                    
                    <div class="col-2">
                             <label>Requisition No.</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="DropDownList1" runat="server" DataTextField="ReqNo" DataValueField="RequisitionID" AutoPostBack="True" OnSelectedIndexChanged="ddlRequisition_SelectedIndexChanged"></asp:DropDownList>
                    </div> 

                    <div class="col-8">
                        <label>&nbsp;</label>
                        <div class="">
                        <asp:Button ID="btnPreview" runat="server" CausesValidation="false" CssClass="btn btn-secondary btn-sm"  Text="Search" OnClick="btnPreview_Click"  />           
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnClear" runat="server"  Text="Clear Search" OnClick="btnClear_Click" />                      
                        </div>
                    </div>
                </div>
            </div>     
     <div class="col-12  row border-top pt-3">
            </div>
       <div class="col-12">        
        
<div class="table-responsive">
<asp:GridView CssClass="table mainGridTable table-sm" ID="gvRequitions" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
        EnableModelValidation="True" ForeColor="Black" 
        Width="100%" OnRowCommand="gvRequitions_RowCommand" OnRowDataBound="gvRequitions_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
  <asp:TemplateField HeaderText="Req No.">
        <ItemTemplate>            
            <asp:Label ID="lblReqNo" runat="server" Text='<%# Eval("ReqNo") %>'></asp:Label></ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Prepared By">
        <ItemTemplate>
       <asp:Label ID="lblAppBy" runat="server" Text='<%# Eval("Preparedby") %>'></asp:Label>                  
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Approved By">
        <ItemTemplate>
         <asp:Label ID="lblApprovedBy" runat="server" Text='<%# Eval("AppBy") %>'></asp:Label>                       
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>  
                      <asp:BoundField DataField="ReqDate" HeaderText="Requested Arrival Date">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
          <asp:BoundField DataField="ReqStatus" HeaderText="Req Status">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        <asp:TemplateField HeaderText="Preview Requisition">
        <ItemTemplate>
            <asp:LinkButton ID="lnkGenerateRequisition" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" runat="server" Text='<%# Eval("ReqNo") %>' CommandName="Select"></asp:LinkButton>       
            <asp:Label ID="lblGenerateRequisition" runat="server" Text='<%# Eval("ReqNo") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblReqID" runat="server" Text='<%# Eval("ReqID") %>' Visible="false"></asp:Label></ItemTemplate>
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

            <asp:HiddenField ID="hfReqID" runat="server" Value="-1" />
</ContentTemplate>
        <Triggers>           
                <asp:PostBackTrigger ControlID="gvRequitions" />                             
        </Triggers> 
</asp:UpdatePanel>
<script type="text/javascript"> 
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
              $('#<%=ddlPreparedBy.ClientID%>').chosen();
            $('#<%=ddlRequisition.ClientID%>').chosen();
       }      
</script>
     <CR:CrystalReportViewer Visible="false" ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>