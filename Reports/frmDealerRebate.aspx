<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmDealerRebate.aspx.cs" Inherits="Reports_frmDealerRebate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="col-8">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Dealer Rebate</h4>
                <%-- <h5 class="text-uppercase">Select Filters</h5>--%>
            </div>
            <%--            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>--%>
            <div class="col-12">
                <div class="row">
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group">
                            <label>End Date</label>
                           <label>End Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group chosenFullWidth">
                            <label>Select Dealer</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRebate" runat="server" DataTextField="CompanyName" DataValueField="DealerID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group chosenFullWidth">
                            <label>Report Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReportType" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                 <asp:ListItem Value="1">By Quarter</asp:ListItem>
                                 <asp:ListItem Value="2">By Division</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-auto mb-1">
                        <div class="form-group mb-0 flex-column">
                            <label>&nbsp;</label>
                            <div>
                               <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" runat="server" CausesValidation="false" Text="Export To Excel" OnClick="btnGenerateExcel_Click" />
                                                    <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row border-top pt-3"></div>
        <div class="row border-top pt-3" id="ShowDiv" style="display: none" runat="server">
                <div class="col-12">
                <h5 class="text-uppercase">Select Report</h5>
                </div>
                <div class="col-sm-12 col-md">
                <div class="form-group srRadiosBtns" style="display: none" id="ShowDivAramark" runat="server">
                    <asp:RadioButton ID="rdbAramark" runat="server" Text="Aramark Rebate Report" />
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" CellPadding="2" CellSpacing="2" Font-Size="Large">
                        <asp:ListItem Value="0" Selected="True">Aramark Rebate Report </asp:ListItem>
                        <asp:ListItem Value="1">Boelter Rebate Report</asp:ListItem>
                        <asp:ListItem Value="2">Edward Don Rebate Report</asp:ListItem>
                        <asp:ListItem Value="3">Government Sales Inc.</asp:ListItem>
                        <asp:ListItem Value="4">Trimark</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group srRadiosBtns" style="display: none" id="ShowDivBoelter" runat="server">
                    <asp:RadioButton ID="rdbBoelter" runat="server" Text="Boelter Rebate Report" />

                </div>
                <div class="form-group srRadiosBtns" style="display: none" id="ShowDivEdwardDon" runat="server">
                    <asp:RadioButton ID="rdbEdwardDon" runat="server" Text="Edward Don Rebate Report" />

                </div>
                <div class="form-group srRadiosBtns" style="display: none" id="ShowDivGovernmentSales" runat="server">
                    <asp:RadioButton ID="rdbGovernmentSales" runat="server" Text="Government Sales Inc." />

                </div>
                <div class="col-sm-6 col-md" style="display: none" id="DIVGovernment" runat="server">
                    <div class="form-group">
                        <label>Country</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group srRadiosBtns" style="display: none" id="ShowDivTrimark" runat="server">
                    <asp:RadioButton ID="rdbTrimark" runat="server" Text="Trimark" />

                </div>
                </div>

         </div>
                      
    </div>
   
  <div class="col-4">       
        <div class="row pt-3">
            <div class="d-flex align-items-center mb-2">
                <h4>
                    <strong>Help Section: </strong>
                </h4>
            </div>
            <div class="col-12 pt-2" runat="server" id="divDealerRebateReport_HelpSection">
                <div class="d-flex align-items-center mb-2">
                    <h5>
                        <strong>Dealer Rebate Report</strong>
                    </h5>
                </div>
                <div class="col-12">
                    <ul>
                        <li>Date is based on <strong>Invoice Date</strong>.</li>
                        <li>Projects with Order for <strong>Aerowerks</strong> are shown in the report.</li>
                        <li>Projects which has <strong>Invoice Number</strong> are shown in the reports.</li>
                        <li>Projects which are <strong>Active/Confirmed</strong> are shown in the report. </li>
                        <li>Selected <strong>Dealers & its offices</strong> are shown in the report. </li>
                        <li>Report Type <strong>By Division Or By Quartely</strong> are filters in the report. </li>
                    </ul>
                </div>
            </div>
        </div>    
   </div>
            <div class="col-sm-12">
                <asp:Panel ID="pangvReports" runat="server" Visible="false">
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gvMainSalesRebateReport" CssClass="table mainGridTable table-sm mb-0" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" EmptyDataText="No Records Found">
                                    <Columns>                         
                                        <asp:TemplateField HeaderText="Company Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label> 
                                            </ItemTemplate>
                                        </asp:TemplateField>   

                                        <asp:TemplateField HeaderText="Sales Rebate Details">
                                            <ItemTemplate>
                                                <asp:GridView CssClass="ChildGrid" ID="gvChildSalesRebateDetails" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="PO #">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPONumber" runat="server" Text='<%# Eval("PONumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Invoice Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("InvoiceDateExcel","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Invoice No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Job #">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblJobNo" runat="server" Text='<%# Eval("JobID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Project Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ship Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblShipDate" runat="server" Text='<%# Eval("ShipToArriveDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Invoiced Sales">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalInvoicedSales" runat="server" Text='<%# Eval("InvoicedSales") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rebatable Sales">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRebatableSales" runat="server" Text='<%# Eval("NetEqPrice") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Non-Rebatable Sales">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNonRebatableSales" runat="server" Text='<%# Eval("NonReb") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Rebate %">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRebatePer" runat="server" Text='<%# Eval("PER") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Rebate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRebateCalculate" runat="server" Text='<%# Eval("REBATE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
      <div class="col-sm-12">
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gvQuarterly" CssClass="table mainGridTable table-sm mb-0" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" EmptyDataText="No Records Found">
                                    <Columns>                         
                                        <asp:TemplateField HeaderText="Quarter Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuarterName" runat="server" Text='<%# Eval("DateInvoiceSent") %>'></asp:Label> 
                                            </ItemTemplate>
                                        </asp:TemplateField>   

                                        <asp:TemplateField HeaderText="Company Details">
                                            <ItemTemplate>
                                                <asp:GridView CssClass="ChildGrid" ID="gvChildCompanyDetails" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Company Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Company Details">
                                            <ItemTemplate>
                                                <asp:GridView CssClass="ChildGrid" ID="gvChildGridDetails" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                                                    <Columns>
                                <asp:TemplateField HeaderText="PO #">
                                <ItemTemplate>
                                <asp:Label ID="lblPONumber" runat="server" Text='<%# Eval("PONumber") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice Date">
                                        <ItemTemplate>
                                        <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("InvoiceDateExcel","{0:MM/dd/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No">
                                        <ItemTemplate>
                                        <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Job #">
                                        <ItemTemplate>
                                        <asp:Label ID="lblJobNo" runat="server" Text='<%# Eval("JobID") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Project Name">
                                        <ItemTemplate>
                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ship Date">
                                        <ItemTemplate>
                                        <asp:Label ID="lblShipDate" runat="server" Text='<%# Eval("ShipToArriveDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Invoiced Sales">
                                        <ItemTemplate>
                                        <asp:Label ID="lblTotalInvoicedSales" runat="server" Text='<%# Eval("InvoicedSales") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rebatable Sales">
                                        <ItemTemplate>
                                        <asp:Label ID="lblRebatableSales" runat="server" Text='<%# Eval("NetEqPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Non-Rebatable Sales">
                                        <ItemTemplate>
                                        <asp:Label ID="lblNonRebatableSales" runat="server" Text='<%# Eval("NonReb") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rebate %">
                                        <ItemTemplate>
                                        <asp:Label ID="lblRebatePer" runat="server" Text='<%# Eval("PER") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rebate">
                                        <ItemTemplate>
                                        <asp:Label ID="lblRebateCalculate" runat="server" Text='<%# Eval("REBATE") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
    
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlRebate.ClientID%>').chosen();
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlReportType.ClientID%>').chosen();
        }
    </script>
</asp:Content>

