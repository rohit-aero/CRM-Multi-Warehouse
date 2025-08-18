<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPreventiveMaintenance.aspx.cs" Inherits="CCT_frmPreventiveMaintenance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Aerowerks Preventive Maintenance</h4>
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
                                        <asp:DropDownList ID="ddlJobHeaderList" CssClass="form-control form-control-sm" runat="server" DataTextField="ProjectName" DataValueField="JobID"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlJobHeaderList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="row">
                                    <div class="col-sm-10">
                                        <label class="mb-0">Quote #</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList ID="ddlOrderNoHeaderList" CssClass="form-control form-control-sm" runat="server" DataTextField="OrderNo" DataValueField="OrderNo"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlOrderNoHeaderList_SelectedIndexChanged">
                                        </asp:DropDownList>
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
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddNew" runat="server" Text="Create New Contract" OnClick="btnAddNew_Click" Enabled="false" />
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnReports" runat="server" CssClass="btn btn-info btn-sm" Text="Report" OnClick="btnReports_Click" />
                                <asp:Button ID="btnPDF" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview" OnClick="btnPDF_Click" Enabled="false" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12"></div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Contact Information</h5>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Position</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTitle" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtName" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <div class="row align-items-center">
                            <div class="col-auto">
                                <h5 class="text-uppercase mb-0">Quote Information</h5>
                            </div>
                            <div class="col-auto">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenQuote" CausesValidation="false" Visible="false" runat="server" Text="Generate Quote doc" OnClick="btnGenQuote_Click" Enabled="false" OnClientClick="window.document.forms[0].target='_blank';" />
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGenQuotePdf" CausesValidation="false" runat="server" Text="Generate Quote Pdf" OnClick="btnGenQuotePdf_Click" Enabled="false" OnClientClick="window.document.forms[0].target='_blank';" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Quote #*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrderNo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control form-control-sm" DataTextField="Name" DataValueField="ID" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="">Attention</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAttention" AutoComplete="off" runat="server" MaxLength="200"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Quote Sent Date</label>
                            <asp:TextBox ID="txtQuoteSentDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtQuoteSentDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtQuoteSentDate" TargetControlID="txtQuoteSentDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Quote Amount</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtQuoteAmount" runat="server" autocomplete="off" MaxLength="11" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Quote Details</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtQuoteDetails" runat="server" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row border-top pt-3">
                    <div class="col-12"></div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Information</h5>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>PO#</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPONumber" MaxLength="50" autocomplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>PO Rec. Date</label>
                            <asp:TextBox ID="txtPORecDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtPORecDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtPORecDate" TargetControlID="txtPORecDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Contract Start Date</label>
                            <asp:TextBox ID="txtContractStartDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtContractStartDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtContractStartDate" TargetControlID="txtContractStartDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Contract End Date</label>
                            <asp:TextBox ID="txtContractEndDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtContractEndDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtContractEndDate" TargetControlID="txtContractEndDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Last Tuneup - Visit</label>
                            <asp:TextBox ID="txtLastTuneUpDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtLastTuneUpDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtLastTuneUpDate" TargetControlID="txtLastTuneUpDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Next Tuneup Date</label>
                            <asp:TextBox ID="txtNextTuneUpDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtNextTuneUpDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtNextTuneUpDate" TargetControlID="txtNextTuneUpDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Invoice Date</label>
                            <asp:TextBox ID="txtInvoiceDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtInvoiceDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtInvoiceDate" TargetControlID="txtInvoiceDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Invoice#</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtInvoiceNo" MaxLength="50" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2" style="display: none">
                        <div class="form-group">
                            <label>Followup Date</label>
                            <asp:TextBox ID="txtFollowUpDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtFollowUpDateExtender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtFollowUpDate" TargetControlID="txtFollowUpDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-4" style="display: none">
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtRemarks" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row border-top pt-3" runat="server" id="GridDiv" visible="false">
                    <div class="col-12">
                        <h5 class="text-uppercase">Details</h5>
                    </div>
                    <div class="col-12">
                        <%-- <asp:Panel ID="pangvPreventiveMaintenance" runat="server">--%>
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvPreventiveMaintenance" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="ID"
                                OnRowDeleting="gvPreventiveMaintenance_RowDeleting" OnRowEditing="gvPreventiveMaintenance_RowEditing" OnRowCancelingEdit="gvPreventiveMaintenance_RowCancelingEdit"
                                OnRowUpdating="gvPreventiveMaintenance_RowUpdating" EnableModelValidation="True"
                                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                ForeColor="Black" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Date*">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgvPreventiveMaintenanceDate" runat="server" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" Text='<%# Eval("Date") %>' Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CE_txtgvPreventiveMaintenanceDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtgvPreventiveMaintenanceDate" TargetControlID="txtgvPreventiveMaintenanceDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtfooterPreventiveMaintenanceDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" autocomplete="off" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CE_txtfooterPreventiveMaintenanceDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtfooterPreventiveMaintenanceDate" TargetControlID="txtfooterPreventiveMaintenanceDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="20%" />
                                        <FooterStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgvPreventiveMaintenanceRemarks" runat="server" CssClass="form-control form-control-sm" Text='<%# Eval("Remarks") %>' Width="100%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtfooterPreventiveMaintenanceRemarks" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)" autocomplete="off" Width="100%"></asp:TextBox>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="70%" />
                                        <FooterStyle Width="70%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit">
                                        <i class="far fa-edit" title="Edit"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete ?');" CommandName="Delete">
                                        <i class="far fa-times-circle" title="Delete"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                            &nbsp;
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" CommandName="Insert" OnClick="btnAdd_Click" />
                                        </FooterTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <%-- </asp:Panel>--%>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HiddenID" runat="server" Value="0" />
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="btnPreview" />--%>
            <asp:PostBackTrigger ControlID="btnPDF" />
            <asp:PostBackTrigger ControlID="btnGenQuote" />
            <asp:PostBackTrigger ControlID="btnGenQuotePdf" />
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
            $('#<%=ddlJobHeaderList.ClientID%>').chosen();
            $('#<%=ddlOrderNoHeaderList.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>
