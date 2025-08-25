<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmShipments.aspx.cs" Inherits="InventoryManagement_FrmShipments" %>

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
                            <h4 class="title-hyphen position-relative">Shipment Details</h4>
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
                    <div class="col-4">
                        <label>&nbsp;</label>
                        <div class="">
                              <asp:Button ID="btnSendEmail" Visible="false" runat="server" CssClass="btn btn-success btn-sm" Text="Send Email" OnClick="btnSendEmail_Click" />
                                 <asp:Button ID="btnPackingDetails" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-secondary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Packing List" OnClick="btnPackingDetails_Click" />                               
                                 <asp:Button ID="btnUploadPackingList" runat="server" CssClass="btn btn-success btn-sm" Text="Update" OnClick="btnUploadPackingList_Click" OnClientClick="return confirm('Are you sure.?');" Enabled="false"  />                                                 
                  <%--              <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Stock In" OnClick="btnSave_Click" OnClientClick="return confirm('Are you sure.?');" Enabled="false" />--%>
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" TabIndex="0" />
                        </div>
                    </div>
                </div>
            </div>

            <%-- Info Section --%>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Manage ETAs and Arrivals</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Received Date*</label>
                            <asp:TextBox ID="txtReceiveDate" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Enabled="false" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReceiveDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReceiveDate" TargetControlID="txtReceiveDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                      <div class="col-sm-5 col-md-4">
                          <label>Upload Packing List (PDF, Excel Max 6 MB Size)</label>
                            <div class="form-group" id="dvUpload" runat="server">                                
                               <asp:FileUpload ID="fpUpload" CssClass="btn btn-success btn-sm btn-block" runat="server" onchange="CheckFileValidations()" />
                            </div>
                            <div class="form-group">
                            <asp:LinkButton ID="lnkDowloadPackingList" runat="server" OnClick="lnkDowloadPackingList_Click" Visible="false"></asp:LinkButton>
                            </div>
                        </div>
                </div>
              </div>  
               <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Add/Update ETA &emsp;<asp:Button CssClass="btn btn-success btn-sm rounded" ID="btnAdd" runat="server" Text="Add"  OnClick="btnAdd_Click" /></h5>       
                    </div>
                     <div class="col-sm-3 col-md-2 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Status*</label> 
                              <asp:DropDownList ID="ddlAddStatus" runat="server" class="form-control form-control-sm" onchange="ETALabelTextChanged()">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">On the water</asp:ListItem>
                                <asp:ListItem Value="2">At the port</asp:ListItem>
                                <asp:ListItem Value="3">On the rail</asp:ListItem>   
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger" id="lblAddRevisedETA" runat="server">Revised ETA*</label> 
                              <asp:TextBox ID="txtAddRevisedETA" runat="server" class="form-control form-control-sm" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtAddRevisedETA" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtAddRevisedETA" TargetControlID="txtAddRevisedETA">
                                    </asp:CalendarExtender>
                                             
                        </div>
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-4">
                        <div class="form-group">
                            <label>Comments</label> 
                             <asp:TextBox ID="txtAddComments" runat="server" class="form-control form-control-sm" MaxLength="250" autocomplete="off" TextMode="MultiLine"></asp:TextBox>              
                        </div>
                    </div>
         
                     </div>                       
             </div>  
 
            <%-- Grid Container History --%>           
            <div class="col-12">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm no-scroll" ID="GvShipmentTracker" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                        EnableModelValidation="True"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                       ForeColor="Black" GridLines="Vertical" Width="100%" Style="font-size: medium" OnRowDeleting="GvShipmentTracker_RowDeleting" OnRowEditing="GvShipmentTracker_RowEditing" OnRowDataBound="GvShipmentTracker_RowDataBound">
                        <Columns>
                        <asp:TemplateField HeaderText="Status">                                      
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("ProjectStatus") %>'></asp:Label>
                                    <asp:Label ID="lblEditProjectStatus" runat="server" Text='<%# Eval("StatusID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Revised ETA" HeaderStyle-Width="12%">                              
                                <ItemTemplate>
                                    <asp:Label ID="txtRevisedETA" runat="server" autocomplete="off" Text='<%# Eval("RevisedETA", "{0:MM/dd/yyyy}") %>'></asp:Label>       
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="68%">                              
                                <ItemTemplate>
                                    <asp:Label ID="txtComments" runat="server" MaxLength="250" Text='<%# Eval("Comments") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Modify">  
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

            <asp:HiddenField ID="hfPackingListName" runat="server" Value="-1" />
            <asp:HiddenField ID="HfReceivedETA" runat="server" Value="-1" />
            <asp:HiddenField ID="HfComments" runat="server" Value="-1" />
            <asp:HiddenField ID="HfCheckEmployee" runat="server" Value="-1" />
              <asp:HiddenField ID="HfCheckRecDate" runat="server" Value="-1" />
            <asp:HiddenField ID="HfEditRowID" runat="server" Value="-1" />
            <asp:HiddenField ID="HfDestinationID" runat="server" Value="-1" />
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
                        $('#<%=ddlVendorLookup.ClientID%>').chosen();
                        $('#<%=ddlContainerLookup.ClientID%>').chosen();
                        $('#<%=ddlAddStatus.ClientID%>').chosen();
                    }
                    function CheckFileValidations() {
                    var fileInput = document.getElementById('<%= fpUpload.ClientID %>'); 
                    var file = fileInput.files[0];

                    const MAX_FILE_SIZE = 6291456; // 6*1024*1024
                    const ALLOWED_FILE_TYPES = ['application/pdf', 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', 'application/vnd.ms-excel'];

                    // Check if a file is selected
                    if (!file) {
                        toastr.error("No file selected. Please choose a file to upload.", '', { 'timeOut': 5000, 'hideDuration': 100, 'closeButton': true });
                        return;
                    }

                    // Check file size
                    if (file.size > MAX_FILE_SIZE) {
                        var filesize = "File size exceeds 6 MB. Please upload a smaller file.";                     
                        toastr.error(filesize, '', { 'timeOut': 5000, 'hideDuration': 100, 'closeButton': true });
                        fileInput.value = '';
                        return;
                    }

                    // Check file type
                    if (!ALLOWED_FILE_TYPES.includes(file.type)) {
                        var filetype = "Only PDF or Excel files are allowed. Please upload a PDF or Excel file.";                  
                        toastr.error(filetype, '', { 'timeOut': 5000, 'hideDuration': 100, 'closeButton': true });
                        fileInput.value = '';
                        return;
                    }
                    }

                function showToastrOnFileUpload() {
                    toastr.success('File Uploaded Successfully and Email Sent !', 'Success');
                }

                function showemailnotification() {
                    toastr.success('Email Sent Successfully!', 'Success');
                }

                function showemailnotificationDisabled() {
                    toastr.error('Email Sent Successfully!', 'error');
                }

                function ETALabelTextChanged() {
                    var id = document.getElementById('<%= ddlAddStatus.ClientID%>').value;
                
                    if (id == 1) {                        
                        document.getElementById('<%= lblAddRevisedETA.ClientID%>').innerText = "Revised ETA at Port*";
                    }
                    else if (id == 2) {
                        document.getElementById('<%= lblAddRevisedETA.ClientID%>').innerText = "Revised ETA on the Rail*";
                    }
                    else if (id == 3) {
                        document.getElementById('<%= lblAddRevisedETA.ClientID%>').innerText = "Revised ETA at Plant*";
                    }
                    else {
                        document.getElementById('<%= lblAddRevisedETA.ClientID%>').innerText = "Revised ETA*";
                    }
                }
                
            </script>
            <CR:CrystalReportViewer Visible="false" ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        </ContentTemplate>
        <Triggers>
                <asp:PostBackTrigger ControlID="btnPackingDetails" />             
                 <asp:PostBackTrigger ControlID="lnkDowloadPackingList" />
                <asp:PostBackTrigger ControlID="btnUploadPackingList" />                     
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgressloader" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
        <ProgressTemplate>
            <div class="spinner">
                <div class="center-div">
                    <div class="inner-div">
                        <div class="loader"></div>
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>