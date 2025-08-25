<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPOReport.aspx.cs" Inherits="Reports_frmPOReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By Source</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendor" runat="server" DataTextField="Source" DataValueField="SourceId" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By Destination</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDest" runat="server" DataTextField="Name" DataValueField="WareHouseID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By PO</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPOCheckStatus" runat="server" OnSelectedIndexChanged="ddlPOCheckStatus_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Submit</asp:ListItem>
                                <asp:ListItem Value="2">Not Submit</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>By Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Open</asp:ListItem>
                                <asp:ListItem Value="2">Close</asp:ListItem>
                                <asp:ListItem Value="3">Cancelled</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-9 col-sm-8 col-md-6 col-lg-4">
                        <div class="form-group">
                            <label>Part No./Description </label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookupPart" runat="server" DataValueField="PartID" DataTextField="PartDes">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md justify-content-center">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-sm" Text="Preview" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnPreviewParts" runat="server" CausesValidation="false" CssClass="btn btn-secondary btn-sm" Text="Search" OnClick="btnPreviewParts_Click" />
                        <asp:Button ID="btnExporttoExcel" runat="server" CausesValidation="false" CssClass="btn btn-secondary btn-sm" Text="Export to Excel" OnClick="btnExporttoExcel_Click" Enabled="false" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnReport" runat="server" CausesValidation="false" CssClass="btn btn-info btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Summary Report" OnClick="btnReport_Click" />
                        <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="PO Report" OnClick="btnPreview_Click" />
                    </div>
                </div>

            </div>
            <div class="col-sm-12">
                <asp:Panel ID="pangvReports" runat="server">
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gvMainPOReport" CssClass="table mainGridTable table-sm mb-0" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" EmptyDataText="No Records Found">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Source">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSource" runat="server" Text='<%# Eval("Source") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PO Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPONumber" runat="server" Text='<%# Eval("PONumber") %>'></asp:Label>
                                                <asp:Label ID="lblPOId" runat="server" Text='<%# Eval("POId") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartID" runat="server" Text='<%# Eval("PartID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblPartNo" runat="server" Text='<%# Eval("PartNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requestor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRequestor" runat="server" Text='<%# Eval("Requestor") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ship by">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipby" runat="server" Text='<%# Eval("Shipby") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUM" runat="server" Text='<%# Eval("UM") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ship Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipQty" runat="server" Text='<%# Eval("ShipQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pending Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPendingQty" runat="server" Text='<%# Eval("PendingQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Container Details">
                                            <ItemTemplate>
                                                <asp:GridView CssClass="ChildGrid" ID="gvContainerInfo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Destination">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("Destination") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Invoice No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Container No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblContainerNo" runat="server" Text='<%# Eval("ContainerNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sent Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSentDate" runat="server" Text='<%# Eval("SentDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Received Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReceivedDate" runat="server" Text='<%# Eval("ReceivedDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Qty">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblShipQty" runat="server" Text='<%# Eval("ShipQty") %>'></asp:Label>
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
            <asp:HiddenField ID="hidVendorID" runat="server" Value="-1" />
            <asp:HiddenField ID="hidIsSubmittedID" runat="server" Value="-1" />
            <asp:HiddenField ID="hidStatusID" runat="server" Value="-1" />
            <asp:HiddenField ID="hidPartID" runat="server" Value="-1" />
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
                    $('#<%=ddlVendor.ClientID%>').chosen();
                    $('#<%=ddlStatus.ClientID%>').chosen();
                    $('#<%=ddlPOCheckStatus.ClientID%>').chosen();
                    $('#<%=ddlLookupPart.ClientID%>').chosen();
                    $('#<%=ddlDest.ClientID%>').chosen();
                }
            </script>
            <CR:CrystalReportViewer ID="rptPO" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnExporttoExcel" />
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

