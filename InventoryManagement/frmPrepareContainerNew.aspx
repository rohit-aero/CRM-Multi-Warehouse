<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmPrepareContainerNew.aspx.cs" Inherits="InventoryManagement_frmPrepareContainerNew" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()">
                                <i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Prepare Shipment</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5 col-md-6 col-lg-5 col-xl-5">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Shipment</label>
                            </div>
                            <div class="col-sm-3 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlVendorLookup" runat="server" DataTextField="Source" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlVendorLookup_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4 col-md mb-2 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerNo" runat="server" DataTextField="ContainerDetail" DataValueField="Containerid" AutoPostBack="True" OnSelectedIndexChanged="ddlContainerNo_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto mb-2">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" CausesValidation="false" OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click" />
                                <asp:Button ID="btnPackingDetails" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-secondary btn-sm" OnClientClick="window.document.forms[0].target='_blank';"
                                    Text="Generate Packing List" OnClick="btnPackingDetails_Click" />
                                <asp:Button ID="btnNotify" runat="server" CssClass="btn btn-danger btn-sm" Text="Acknowledgement" Enabled="false" CausesValidation="false" OnClick="btnNotify_Click" OnClientClick="return confirm('Are you sure you want to Acknowledgement.?');" />
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-sm" Text="Submission" Enabled="false" CausesValidation="false" OnClick="btnSubmit_Click" OnClientClick="return confirm('Are you sure to Submit this Container?');" />
                                <asp:Button ID="btnGenerate" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview" Visible="false" OnClick="btnGenerate_Click" />
                                <asp:Button ID="btnAddProjects" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-secondary btn-sm" OnClientClick="window.document.forms[0].target='_blank';"
                                    Text="Add Parts/Projects" OnClick="btnAddProjects_Click" />
                                <asp:Button ID="btnPackingDetailsExcel" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-secondary btn-sm" OnClientClick="window.document.forms[0].target='_blank';"
                                    Text="Export To Excel" OnClick="btnPackingDetailsExcel_Click" />
                                <asp:Button ID="btnContainerReport" runat="server" CssClass="btn btn-secondary btn-sm" Text="Report" OnClick="btnContainerReport_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError"
                                    visible="false">
                                    Error message
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Shipment Information (* Fields Are Required)</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger"> Source WareHouse*</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlVendor" runat="server" DataTextField="Source" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Destination WareHouse*</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlDestWareHouse" runat="server" DataTextField="Name" DataValueField="WareHouseID" AutoPostBack="True" OnSelectedIndexChanged="ddlDestWareHouse_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Invoice No*</label>
                            <asp:TextBox ID="txtInvoiceNo" CssClass="form-control form-control-sm" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Container No</label>
                            <asp:TextBox ID="txtContainerNo" CssClass="form-control form-control-sm" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Seal No*</label>
                            <asp:TextBox ID="txtSealNo" CssClass="form-control form-control-sm" runat="server" autocomplete="off" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Tentative Sent Date*</label>
                            <asp:TextBox ID="txtTentativeSentDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtTentativeSentDate" TargetControlID="txtTentativeSentDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Sent Date (Load Date)</label>
                            <asp:TextBox ID="txtsentdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtsentdate" TargetControlID="txtsentdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Tentative Arrival in Aerowerks</label>
                            <asp:TextBox ID="txtArrivalinAerowerks" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtArrivalinAerowerks" TargetControlID="txtArrivalinAerowerks">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2" style="display: none">
                        <div class="form-group">
                            <label>Container</label>
                            <asp:TextBox ID="txtContainer" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Attn</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlAttn" DataValueField="EmployeeID" DataTextField="EmployeeName" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Approved By*</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlApprovedBy" DataValueField="EmployeeID" DataTextField="ApprovedBy" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Issued By</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlIssuedBy" DataValueField="EmployeeID" DataTextField="EmployeeName" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Shippment By*</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlShipment" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">By Sea</asp:ListItem>
                                <asp:ListItem Value="2">By Air</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-7 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Upload Document</label>
                            <asp:FileUpload ID="fpuploadfile" CssClass="btn btn-success btn-sm btn-block" runat="server" />
                            <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="row border-top pt-3" id="dvContainerInfo" runat="server" visible="false">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Container details with quantities</h5>
                        <div class="table-responsive" style="overflow-x: inherit !important; display: none">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <th style="width: 20%;">Part# (APN/CPN)/Description*</th>
                                    <th style="width: 10%;">PO Number*</th>
                                    <th style="width: 5%;">Order Qty</th>
                                    <th style="width: 5%;">Pending Qty</th>
                                    <th style="width: 5%;">Ship Qty*</th>
                                    <th style="width: 15%;">Skid No</th>
                                    <th style="width: 20%;">Remarks</th>
                                    <th style="width: 10%;">Status*</th>
                                    <th style="width: 5%;"></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartNo" runat="server" DataTextField="PartNumber" DataValueField="PartId" AutoPostBack="true" OnSelectedIndexChanged="ddlPartNo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblPODetail" runat="server" Text='<%# Eval("PODetailid") %>' Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPONumber" runat="server" DataTextField="PONumber" DataValueField="POid"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlPONumber_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblOrder" runat="server">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPending" runat="server">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipped" runat="server" MaxLength="5" onkeypress="return onlyNumbers(this,event);">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtSkid" runat="server" TextMode="MultiLine">                                       
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-left" ID="txtRemarks" runat="server" Visible="true" MaxLength="250"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1" Selected="True">Open</asp:ListItem>
                                            <asp:ListItem Value="2">Close</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div id="pogrid" runat="server" class="row border-top pt-3" visible="false">
                    <div class="col-sm-12">
                        <asp:Panel ID="pangvRequititionDetails" runat="server">
                            <div class="row pt-3">
                                <div class="col-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvMainRequisitionDetail" CssClass="table mainGridTable table-sm mb-0" DataKeyNames="PartId" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Part# (APN/CPN)/Description" HeaderStyle-Width="22%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPartid" runat="server" Text='<%# Eval("PartId") %>' Visible="false">
                                                        </asp:Label>
                                                        <asp:Label ID="lblWareHouseID" runat="server" Text='<%# Eval("DestWareHouseID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblPartNumber" runat="server" Text='<%# Eval("PartNumber") %>'></asp:Label>
                                                        <asp:Label ID="lblPOId" runat="server" Text='<%# Eval("POid") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblPODetailId" runat="server" Text='<%# Eval("PODetailid") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="22%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="80%" HeaderText="Purchase Order Details">
                                                    <ItemTemplate>
                                                        <asp:Panel ID="pnlPartsDetail" runat="server">
                                                            <asp:GridView CssClass="ChildGrid" ID="gvContainer" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvContainer_RowDataBound" EnableModelValidation="True">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="PO Number" HeaderStyle-Width="11%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblContainerPOId" runat="server" Text='<%# Eval("POid") %>' Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblContainerPODetailId" runat="server" Text='<%# Eval("PODetailid") %>' Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblPONumber" runat="server" Text='<%# Eval("PONumber") %>'></asp:Label>
                                                                            <asp:Label ID="lblItemPartid" runat="server" Visible="false" Text='<%# Eval("Partid") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="6%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Pending Qty" HeaderStyle-Width="6%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPendingQty" runat="server"
                                                                                Text='<%# Eval("Pendingqty") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Ship Qty" HeaderStyle-Width="6%">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtShippingQty" runat="server" autocomplete="off" CssClass="form-control form-control-sm text-right"
                                                                                Text='<%# Eval("ShipQty") %>'
                                                                                onkeypress="return onlyNumbers(event);" MaxLength="5" onpaste="return false" OnTextChanged="txtShippingQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField HeaderText="Packing No" HeaderStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPackingNo" runat="server" Text='<%# Eval("PackingNo") %>' MaxLength="500" autocomplete="off" CssClass="form-control form-control-sm text-left" TextMode="MultiLine"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Skid No" HeaderStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtSkidNo" runat="server" Text='<%# Eval("SkidNo") %>' MaxLength="50" autocomplete="off" TextMode="MultiLine" CssClass="form-control form-control-sm text-left"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="30%">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtItemRemarks" runat="server" Text='<%# Eval("Remarks") %>' MaxLength="500" autocomplete="off" CssClass="form-control form-control-sm text-left" TextMode="MultiLine"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' Visible="false" />
                                                                            <asp:DropDownList ID="ddlstatus" CssClass="form-control form-control-sm" runat="server">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Open</asp:ListItem>
                                                                                <asp:ListItem Value="2">Close</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10%" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="85%" Height="70%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="col-sm-12">
                        <h5 class="title-hyphen position-relative text-uppercase"><b>Add Job Information (* Mark Fields are Required)</b></h5>
                        <h5 class="text-center"><b></b></h5>

                        <div class="table-responsive">
                            <table class="table table-sm" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th style="width: 30%">Container #</th>
                                    <td style="width: 70%">
                                        <asp:Label ID="lblJobProjects" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 30%; color: red">Job #/Part #*</th>
                                    <td class="form-group chosenFullWidth">
                                        <asp:TextBox ID="txtJobNo" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 30%">Description</th>
                                    <td style="width: 70%">
                                        <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control form-control-sm" MaxLength="500"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <th style="width: 30%">Requestor</th>
                                    <td style="width: 70%">
                                        <asp:TextBox ID="txtRequestor" runat="server" CssClass="form-control form-control-sm" MaxLength="50"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <th style="width: 30%; color: red">Quantity*</th>
                                    <td style="width: 70%">
                                        <asp:TextBox ID="txtJobQty" runat="server" CssClass="form-control form-control-sm" onkeypress="return onlyNumbers(this,event);" onpaste="return false" MaxLength="5"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <th style="width: 30%">Remarks</th>
                                    <td>
                                        <asp:TextBox ID="txtJobRemarks" runat="server" MaxLength="500" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnJobSave" CausesValidation="false" runat="server" Text="Save" OnClick="btnJobSave_Click" />
                                        <asp:Button CssClass="btn btn-danger btn-sm rounded" ID="btnJobCancel" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnJobCancel_Click" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblShowMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <div class="col-12">
                <div id="containerProjects" runat="server" class="row border-top pt-3" visible="false">
                    <div class="col-sm-12">
                        <div class="col-sm-12">
                            <asp:Panel ID="Panel2" runat="server">
                                <div class="row pt-3">
                                    <div class="col-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvContainerProjects" CssClass="table mainGridTable table-sm mb-0" runat="server"
                                                AutoGenerateColumns="False" EnableModelValidation="True" DataKeyNames="ContainerProjectid"
                                                OnRowDeleting="gvContainerProjects_RowDeleting" OnRowDataBound="gvContainerProjects_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="jobid" HeaderText="Job No/Part No">
                                                        <ItemStyle Width="10%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                                        <ItemStyle Width="25%" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Requester" HeaderText="Requestor">
                                                        <ItemStyle Width="10%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="qty" HeaderText="Quantity">
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="remarks" HeaderText="Remarks" ItemStyle-Wrap="true">
                                                        <ItemStyle Width="45%" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Modify">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" CssClass="btn btn-danger btn-sm" CommandName="Delete" runat="server" OnClientClick="return confirm('Are you sure to delete.?');"><i class="far fa-times-circle" title="Delete"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:GridView ID="gvPackingListExcelExport" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="table mainGridTable table-sm verticalHeading mx-auto text-center"
                EnableModelValidation="True" ShowFooter="false" OnRowDataBound="gvPackingListExcelExport_RowDataBound" Style="display: none;">
            </asp:GridView>
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
                    $('#<%=ddlContainerNo.ClientID%>').chosen();
                    $('#<%=ddlAttn.ClientID%>').chosen();
                    $('#<%=ddlIssuedBy.ClientID%>').chosen();
                    $('#<%=ddlVendorLookup.ClientID%>').chosen();
                    $('#<%=ddlVendor.ClientID%>').chosen();
                    $('#<%=ddlShipment.ClientID%>').chosen();
                    $('#<%=ddlApprovedBy.ClientID%>').chosen();
                    $('#<%=ddlPartNo.ClientID%>').chosen();
                    $('#<%=ddlPONumber.ClientID%>').chosen();
                    $('#<%=ddlStatus.ClientID%>').chosen();
                    $('#<%=ddlDestWareHouse.ClientID%>').chosen();
                   <%-- $('#<%=ddlContainerJobNo.ClientID%>').chosen({ width: 
                "inherit" }); --%>
                }

            </script>
            <asp:HiddenField ID="hfInvoiceNodrwaing" runat="server" Value="-1" />
            <asp:HiddenField ID="hfContainerid" runat="server" />
            <asp:HiddenField ID="hfContaineridgetfromdb" runat="server" />
            <asp:HiddenField ID="hfPODetailid" runat="server" Value="-1" />
            <div id="dvcrystalerror" runat="server">
                <CR:CrystalReportViewer ID="rptGenerateReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" OnError="btnCrystalError_Click" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPackingDetails" />
            <asp:PostBackTrigger ControlID="btnPackingDetailsExcel" />
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="lnkDownload" />
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

