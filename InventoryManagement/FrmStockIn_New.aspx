<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmStockIn_New.aspx.cs" Inherits="InventoryManagement_FrmStockIn_New" %>

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
                            <h4 class="title-hyphen position-relative">Stock In Details</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-2">
                    <div class="col-2">
                        <label>Look Up Vendor</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendorLookup" runat="server" DataTextField="Source" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlVendorLookup_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label>Invoice No./Container No.</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerLookup" runat="server" DataTextField="ContainerDetail" DataValueField="ContainerID" AutoPostBack="True" OnSelectedIndexChanged="ddlContainerLookup_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-8">
                        <label>&nbsp;</label>
                        <div class="">
                            <asp:Button ID="btnSendEmail" Visible="false" runat="server" CssClass="btn btn-success btn-sm" Text="Send Email" OnClick="btnSendEmail_Click" />
                            <asp:Button ID="btnPackingDetails" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-secondary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Packing List" OnClick="btnPackingDetails_Click" />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Stock In" OnClick="btnSave_Click" OnClientClick="return confirm('Are you sure.?');" Enabled="false" />
                            <asp:Button ID="btnExportNegativeStock" runat="server" CssClass="btn btn-primary btn-sm" Text="Export Negative Stock In Hand Items" OnClick="btnExportNegativeStock_Click" Enabled="false" CausesValidation="false" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" TabIndex="0" />
                            <asp:Button ID="btnRedirectToStockAdj" runat="server" CssClass="btn btn-primary btn-sm" Text="Stock Adjustment" Visible="false" OnClick="btnRedirectToStockAdj_Click" TabIndex="0" />

                        </div>
                    </div>
                </div>
            </div>

            <%-- Info Section --%>
            <div class="col-12">
            <div class="row pt-3">
                    <!-- Existing form content here -->
                    <div class="col-8">
                        <div class="row pt-3">
                            <div class="col-12">
                                <h5 class="text">Manage ETAs and Arrivals</h5>
                            </div>
                            <div class="col-sm-12 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label class="text-danger">Arrival Date*</label>
                                    <asp:TextBox ID="txtReceiveDate" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Enabled="false"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtReceiveDate_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtReceiveDate" TargetControlID="txtReceiveDate">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-sm-5 col-md-4" id="divpackinglistlink" runat="server" visible="false">
                                <div class="form-group" id="divfpupload" runat="server" visible="false">
                                    <label>Upload Packing List (PDF, Excel Max 5000 KB Size)</label>
                                    <asp:FileUpload ID="fpUpload" CssClass="btn btn-success btn-sm btn-block" runat="server" onchange="CheckFileValidations()" />
                                </div>
                                <div class="form-group">
                                    <label class="mb-3">Packing List</label><br />
                                    <asp:LinkButton ID="lnkDowloadPackingList" runat="server" OnClick="lnkDowloadPackingList_Click" Visible="false">
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Help section aligned right -->
                    <div class="col-4">
                        <div class="col-12 ms-auto">
                            <div class="row pt-3">
                                <div class="d-flex align-items-center mb-2">
                                    <h4><strong>Help Section: </strong></h4>
                                </div>
                                <div class="col-12 pt-2" runat="server" id="div1">
                                    <div class="d-flex align-items-center mb-2">
                                        <h5><strong>Stock In</strong></h5>
                                    </div>
                                    <div class="col-12">
                                        <ul>
                                            <li>Containers, having Standard Parts are listed here</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Grid Container History --%>
            <div class="col-12 pt-3">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="GvShipmentTracker" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                        EnableModelValidation="True" Style="margin-top: 0px">
                        <Columns>
                            <asp:TemplateField HeaderText="Revised ETA" HeaderStyle-Width="12%">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtUpdateRevisedETA" runat="server" class="form-control form-control-sm" autocomplete="off" Text='<%# Eval("RevisedETA", "{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtUpdateRevisedETA" TargetControlID="txtUpdateRevisedETA">
                                    </asp:CalendarExtender>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFooterRevisedETA" runat="server" class="form-control form-control-sm" autocomplete="off" Text='<%# Eval("RevisedETA", "{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFooterRevisedETA" TargetControlID="txtFooterRevisedETA">
                                    </asp:CalendarExtender>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="txtRevisedETA" runat="server" autocomplete="off" Text='<%# Eval("RevisedETA", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="68%">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtUpdateComments" runat="server" class="form-control form-control-sm" MaxLength="250" TextMode="MultiLine" Text='<%# Eval("Comments") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFooterComments" runat="server" class="form-control form-control-sm" MaxLength="250" TextMode="MultiLine" Text='<%# Eval("Comments") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="txtComments" runat="server" MaxLength="250" Text='<%# Eval("Comments") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-12 pt-3" id="divexporttoexcel" runat="server" visible="false">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvAddParts" runat="server" AutoGenerateColumns="False"
                        EnableModelValidation="True" Style="margin-top: 0px">
                        <Columns>
                            <asp:TemplateField HeaderText="Part No/Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartNo" runat="server" autocomplete="off" Text='<%# Eval("PartNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="25%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor">
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor" runat="server" autocomplete="off" Text='<%# Eval("Vendor") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Min">
                                <ItemTemplate>
                                    <asp:Label ID="lblMin" runat="server" autocomplete="off" Text='<%# Eval("min") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="7%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Max">
                                <ItemTemplate>
                                    <asp:Label ID="lblMax" runat="server" autocomplete="off" Text='<%# Eval("max") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="7%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock In Hand">
                                <ItemTemplate>
                                    <asp:Label ID="txtStockInHand" runat="server" Text='<%# Eval("StockInHand") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="hfPackingListName" runat="server" Value="-1" />
            <asp:HiddenField ID="HfReceivedETA" runat="server" Value="-1" />
            <asp:HiddenField ID="HfComments" runat="server" Value="-1" />
            <asp:HiddenField ID="HfCheckEmployee" runat="server" Value="-1" />
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
                }
                function CheckFileValidations() {
                    var fileInput = document.getElementById('<%= fpUpload.ClientID %>');
                        var file = fileInput.files[0];

                        const MAX_FILE_SIZE = 5120000; // 5120000/1024=5000 KB
                        const ALLOWED_FILE_TYPES = ['application/pdf', 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', 'application/vnd.ms-excel'];

                        // Check if a file is selected
                        if (!file) {
                            toastr.error("No file selected. Please choose a file to upload.", '', { 'timeOut': 5000, 'hideDuration': 100, 'closeButton': true });
                            return;
                        }

                        // Check file size
                        if (file.size > MAX_FILE_SIZE) {
                            var filesize = "File size exceeds 5000 KB. Please upload a smaller file.";
                            toastr.error(filesize, '', { 'timeOut': 5000, 'hideDuration': 100, 'closeButton': true });
                            fileInput.value = '';
                            return;
                        }

                        // Check file type
                        if (!ALLOWED_FILE_TYPES.includes(file.type)) {
                            var filetype = "Only PDF and Excel files are allowed. Please upload a PDF or Excel file.";
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

            </script>
            <CR:CrystalReportViewer Visible="false" ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPackingDetails" />
            <asp:PostBackTrigger ControlID="lnkDowloadPackingList" />
            <asp:PostBackTrigger ControlID="btnExportNegativeStock" />
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
