<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmCustomerCareTickets.aspx.cs" Inherits="CCT_frmCustomerCareTickets" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col pt-2 pb-3 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Aerowerks Ticket Details</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-3">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                        <div class="row">
                            <div class="col-8">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Job #</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList ID="ddlJobNo" runat="server" DataTextField="ProjectName" DataValueField="JobID" CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Ticket #</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList ID="ddlTicketNo" runat="server" DataTextField="TicketNo" DataValueField="Ticketid" CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlTicketNo_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-sm-12">
                                <label class="mb-0">&nbsp;</label>
                            </div>
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm" Text="Create New Ticket" OnClick="btnNew_Click" Enabled="false" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnReports" runat="server" CssClass="btn btn-info btn-sm" Text="Report" OnClick="btnReports_Click" />
                                <asp:Button ID="btnPDF" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview" OnClick="btnPDF_Click" />
                                <asp:Button ID="btnPreview" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm" Text="Export to Doc" OnClick="btnPreview_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <asp:Panel ID="PanPersonelInformation" runat="server">
                    <div class="row pt-3">
                        <div class="col-12">
                            <h5 class="text-uppercase">Ticket Details
                            <asp:Button ID="btnGenerateRepairSchedule" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Repair Schedule" OnClick="btnGenerateRepairSchedule_Click" />
                            </h5>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="text-danger">Ticket#*</label>
                                <asp:TextBox ID="txtTicketno" CssClass="form-control form-control-sm" autocomplete="off" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="text-danger">Open Date*</label>
                                <asp:TextBox ID="txtOpenDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtOpenDate" TargetControlID="txtOpenDate">
                                </asp:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <label class="text-danger">Follow Up Date*</label>
                                <asp:TextBox ID="txtFollowUpDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtFollowUpDate" TargetControlID="txtFollowUpDate">
                                </asp:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <label>Issue Closed Date</label>
                                <asp:TextBox ID="txtIssueClosedDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtIssueClosedDate" TargetControlID="txtIssueClosedDate">
                                </asp:CalendarExtender>
                            </div>
                           <div class="form-group" style="display:none">
                                <label>Model</label>
                                <asp:TextBox ID="txtModel" CssClass="form-control form-control-sm" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="text-danger">Task*</label>
                                <asp:TextBox ID="txtTask" CssClass="form-control form-control-sm" TextMode="MultiLine" autocomplete="off" oninput="return limitMultiLineInputLength(this, 500)" runat="server"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                <label class="text-danger">Status*</label>
                                <asp:DropDownList ID="ddlStatus" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                            </div>
                             <div class="form-group">
                                <label class="text-danger">Assigned To*</label>
                                <asp:DropDownList ID="ddlAssignedto" CssClass="form-control form-control-sm" runat="server" DataTextField="FirstName" DataValueField="EmployeeID">
                                </asp:DropDownList>
                            </div>
                             <div class="form-group">
                                <label>Solution</label>
                                <asp:TextBox ID="txtSolution" CssClass="form-control form-control-sm" TextMode="MultiLine" AutoComplete="off" oninput="return limitMultiLineInputLength(this, 250)" runat="server"></asp:TextBox>
                            </div>
                           <div class="form-group" style="display:none">
                                <label>Attach File</label>
                                <asp:FileUpload ID="fpUploadFile" CssClass="btn btn-success btn-sm btn-block" runat="server" />
                                <asp:LinkButton ID="lnkDowload" runat="server" Text="Download File" Visible="false" OnClick="lnkDowload_Click"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="text-danger">Category*</label>
                                <asp:DropDownList ID="ddlCategory" CssClass="form-control form-control-sm" DataTextField="CategoryName" DataValueField="Categoryid" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <asp:Panel ID="PanelCategoryOther" runat="server" Style="display: none;">
                                <div class="form-group">
                                    <label>Other</label>
                                    <asp:TextBox ID="txtCategoryOther" autocomplete="off" CssClass="form-control form-control-sm" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)" runat="server"></asp:TextBox>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <label class="text-danger">Issue Category*</label>
                                <asp:DropDownList ID="ddlIssueCategory" CssClass="form-control form-control-sm" DataTextField="IssueCategoryName" AutoPostBack="true" DataValueField="IssueCategoryid" runat="server" OnSelectedIndexChanged="ddlIssueCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <asp:Panel ID="PanelIssueCategory" runat="server" Style="display: none;">
                                <div class="form-group">
                                    <label>Other</label>
                                    <asp:TextBox ID="txtIssueCategoryOther" autocomplete="off" CssClass="form-control form-control-sm" TextMode="MultiLine" runat="server" oninput="return limitMultiLineInputLength(this, 150)"></asp:TextBox>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <label>Sub Assembly</label>
                                <asp:DropDownList ID="ddlSubAssembly" CssClass="form-control form-control-sm" DataTextField="SubAssemblyname" AutoPostBack="true" DataValueField="SubAssemblyid" runat="server" OnSelectedIndexChanged="ddlSubAssembly_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <asp:Panel ID="PanelSubAssemblyOther" runat="server" Style="display: none;">
                                <div class="form-group">
                                    <label>Other</label>
                                    <asp:TextBox ID="txtSubAssemblyOther" autocomplete="off" CssClass="form-control form-control-sm" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 150)" runat="server"></asp:TextBox>
                                </div>
                            </asp:Panel>
                                <div class="form-group">
                                <label>Issue Reported By</label>
                                <asp:DropDownList ID="ddlIssueReportedBy" CssClass="form-control form-control-sm" runat="server" DataTextField="IssueReportedby" DataValueField="IssueId">
                                    <%--  <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Abner</asp:ListItem>
                                <asp:ListItem Value="2">Hector</asp:ListItem>
                                <asp:ListItem Value="3">Suseen</asp:ListItem>
                                <asp:ListItem Value="4">Boris</asp:ListItem>
                                <asp:ListItem Value="5">Nirmal</asp:ListItem>
                                <asp:ListItem Value="6">Eder</asp:ListItem>
                                <asp:ListItem Value="7">Customer</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>                      
                                   

                       
                    </div>
            </asp:Panel>
               </div>    
                    <div class="col-12 row border-top pt-3"></div>
            <div class="col-12">
                  <div class="row pt-3">
                  <!-- Column 1 -->
                  <div class="col-sm-3">
                    <h5 class="text-uppercase">Repair Details</h5>
                    <div class="form-group">
                          <label>Point of Contact on Site(Name, No. & Email)</label>
                         <asp:TextBox ID="txtPCS" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="250" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                         <label>Technician 1</label>
                          <asp:DropDownList ID="ddlTechnician_1" CssClass="form-control form-control-sm" DataTextField="FullName" DataValueField="EmployeeID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTechnician_1_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                            <label>Technician 2</label>
                        <asp:DropDownList ID="ddlTechnician_2" CssClass="form-control form-control-sm" DataTextField="FullName" DataValueField="EmployeeID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTechnician_2_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                            <label>Start Date & Time</label>
                            <asp:TextBox ID="txtSDT" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="250" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                            <label>Working Window</label>
                            <asp:TextBox ID="txtWorkingWindow" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="100" runat="server"></asp:TextBox>
                    </div>
                   <div class="form-group">
                             <label>Other Contacts</label>
                             <asp:TextBox ID="txtOtherContact" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="250" runat="server"></asp:TextBox>
                    </div>
                  </div>
  
  <!-- Column 2 -->
                      <div class="col-sm-3">
                        <h5 class="text-uppercase">Payment Details</h5>
                        <div class="form-group">
                          <label>Quote No</label>
                         <asp:TextBox ID="txtQuoteNo" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="30" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <label>Quote Amount</label>
                           <asp:TextBox ID="txtQuoteAmount" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="10" onkeypress="return onlyDotsAndNumbers(this,event);" runat="server"></asp:TextBox>
                        </div>
                         <div class="form-group">
                           <label>Service PO#</label>
                           <asp:TextBox ID="txtServicePONo" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="30" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>PO Received Date</label>
                            <asp:TextBox ID="txtPOReceivedDate" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="30" runat="server" OnBlur="validateDate(this)"></asp:TextBox>  
                             <asp:CalendarExtender ID="calPOReceivedDate" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtPOReceivedDate" TargetControlID="txtPOReceivedDate">
                                </asp:CalendarExtender>
                        </div>
                        <div class="form-group">
                          <label>Invoice #</label>
                          <asp:TextBox ID="txtInvoiceNo" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="30" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                                <label>Invoice Date</label>
                                <asp:TextBox ID="txtInvoiceDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtInvoiceDate" TargetControlID="txtInvoiceDate">
                                </asp:CalendarExtender>
                        </div>
                        <div class="form-group">
                          <label>Invoice Amount</label>
                          <asp:TextBox ID="txtTotalCost" CssClass="form-control form-control-sm" AutoComplete="off" MaxLength="10" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                      </div>
                    </div>
            </div>

                    <div class=" col-12 row border-top pt-3">    
                    </div>
               <div class="col-12">
                 
                   <h5 class="text-uppercase">Summary Details</h5>
                <asp:Panel ID="pangvSummary" runat="server">
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvSummary" runat="server" AutoGenerateColumns="False" DataKeyNames="TicketID"
                                    EnableModelValidation="True" ShowFooter="True" OnRowCancelingEdit="gvSummary_RowCancelingEdit" OnRowEditing="gvSummary_RowEditing" OnRowUpdating="gvSummary_RowUpdating" OnRowDeleting="gvSummary_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HfTicketid" runat="server" Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="13%">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvSummDate" runat="server" CssClass="form-control form-control-sm" Text='<%# Eval("summarydate") %>' OnBlur="validateDate(this)" Width="100%"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvSummDate" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtgvSummDate" TargetControlID="txtgvSummDate">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtfooterSummDate" CssClass="form-control form-control-sm" runat="server" autocomplete="off" OnBlur="validateDate(this)" Width="100%"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalFtxtQuoteSent" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtfooterSummDate" TargetControlID="txtfooterSummDate">
                                                </asp:CalendarExtender>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("summarydate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Summary" HeaderStyle-Width="85%">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvSumm" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Text='<%# Eval("summary") %>' oninput="return limitMultiLineInputLength(this, 500)" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFootSumm" CssClass="form-control form-control-sm" runat="server" Width="100%" oninput="return limitMultiLineInputLength(this, 500)" TextMode="MultiLine"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSumm" runat="server" Text='<%# Eval("summary") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-CssClass="ws-nowrap" FooterStyle-HorizontalAlign="Center">
                                            <EditItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                                &nbsp;
                                             <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                                &nbsp;
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" CommandName="Insert" OnClick="btnAdd_Click" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="lnkEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                                &nbsp;<asp:LinkButton CssClass="btn btn-info btn-danger" ID="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure to delete. ?');"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                
               </div>       
            <asp:HiddenField ID="hfFileAddress" runat="server" />
            <asp:HiddenField ID="HfCustomerDetailid" runat="server" />
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
                    $('#<%=ddlJobNo.ClientID%>').chosen();
                    $('#<%=ddlTicketNo.ClientID%>').chosen();
                    $('#<%=ddlCategory.ClientID%>').chosen();
                    $('#<%=ddlIssueCategory.ClientID%>').chosen();
                    $('#<%=ddlSubAssembly.ClientID%>').chosen();
                    $('#<%=ddlIssueReportedBy.ClientID%>').chosen();
                    $('#<%=ddlStatus.ClientID%>').chosen();
                    $('#<%=ddlAssignedto.ClientID%>').chosen();
                    $('#<%=ddlTechnician_1.ClientID%>').chosen();
                    $('#<%=ddlTechnician_2.ClientID%>').chosen();
                }
            </script>
            <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPreview" />
            <asp:PostBackTrigger ControlID="btnPDF" />
         <%--   <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="lnkDowload" />--%>
            <asp:PostBackTrigger ControlID="btnGenerateRepairSchedule" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
