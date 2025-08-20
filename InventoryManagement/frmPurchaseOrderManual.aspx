<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" EnableEventValidation="false" CodeFile="frmPurchaseOrderManual.aspx.cs" ValidateRequest="false" EnableViewState="true" Inherits="InventoryManagement_frmPurchaseOrderManual" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
                            <h4 class="title-hyphen position-relative">Purchase Order</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Purchase Order</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPurchaseOrder" runat="server" DataTextField="PONumber" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="ddlPurchaseOrder_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Add New PO" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Enabled="false" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnNotify" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Acknowledgement" Enabled="false" OnClientClick="return confirm('Are you sure you want to Acknowledgement.?');" OnClick="btnNotify_Click" />
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="PO Submission" Enabled="false" OnClientClick="return confirm('Are you sure to Submit this PO.?');" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnGenerate" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm" Enabled="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate PO" OnClick="btnGenerate_Click" />
                                <asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary btn-sm" Text="Report" OnClick="btnReport_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Purchase Order Information (* Fields Are Required)</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label style="color: red">PO#*</label>
                            <asp:TextBox ID="txtPurchaseOrderNo" CssClass="form-control form-control-sm" runat="server" Enabled="false">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label style="color: red">Source Warehouse*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSource" DataTextField="InvSource" DataValueField="InvSourceid" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSource_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Destination Warehouse*</label>
                            <asp:DropDownList ID="ddlWareHouse" CssClass="form-control form-control-sm" runat="server" DataTextField="Name" DataValueField="WareHouseID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Prepared By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPreparedby" runat="server" DataTextField="FirstName" DataValueField="EmployeeID">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label style="color: red">Issue Date*</label>
                            <asp:TextBox ID="txtIssueDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtIssueDate" TargetControlID="txtIssueDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label style="color: red">PO Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="2">Close</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-sm-12 col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:TextBox ID="txtPORemarks" CssClass="form-control form-control-sm" runat="server" MaxLength="500" autocomplete="off">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Purchase Order details with quantities (* FIELDS ARE REQUIRED)</h5>
                        <div class="table-responsive" style="overflow-x: inherit !important; display: none">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <th style="width: 10%;">Part#/Description*</th>
                                    <th style="width: 10%;">Req Number*</th>
                                    <th style="width: 10%;">Requestor</th>
                                    <th style="width: 5%;">Req Qty</th>
                                    <th style="width: 5%;">In Stock</th>
                                    <th style="width: 5%;">In Transit</th>
                                    <th style="width: 5%;">Order Qty*</th>
                                    <th style="width: 5%;">Priority</th>
                                    <th style="width: 20%;">Remarks</th>
                                    <th style="width: 5%;"></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartNo" runat="server" DataTextField="PartNumber" DataValueField="PartId" AutoPostBack="true" OnSelectedIndexChanged="ddlPartNo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblReqDetailID" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblReqNumber" runat="server" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReqNumber" runat="server" DataTextField="ReqNumber" DataValueField="ReqID"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlReqNumber_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRequestor" runat="server">  </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblReqOrderQty" runat="server">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblInStock" runat="server">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkInTransit" runat="server" OnClick="lnkInTransit_Click">
                                        </asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtPOOrder" runat="server" MaxLength="5" onkeypress="return onlyNumbers(event);" autocomplete="off" AutoPostBack="True" OnTextChanged="txtPOOrder_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="text-align: center; vertical-align: middle;">
                                        <asp:CheckBox ID="chkPriority" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-left" ID="txtRemarks" runat="server" Visible="true" MaxLength="250" autocomplete="off"></asp:TextBox>
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

            <div>
                <div class="col-sm-12">
                    <asp:Panel ID="pangvRequititionDetails" runat="server">
                        <div class="row pt-3">
                            <div class="col-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="gvMainPartDetail" CssClass="table mainGridTable table-sm mb-0" DataKeyNames="PartId" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Part#/Description" HeaderStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartid" runat="server" Text='<%# Eval("PartId") %>' Visible="false">
                                                    </asp:Label>
                                                    <asp:Label ID="lblPartNumber" runat="server" Text='<%# Eval("PartNumber") %>'></asp:Label>
                                                    <asp:Label ID="lblReqId" runat="server" Text='<%# Eval("ReqId") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblReqDetailId" runat="server" Text='<%# Eval("ReqDetailid") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="18%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Source" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSource" runat="server" Text='<%# Eval("Source") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="78%" HeaderText="Purchase Order Details">
                                                <ItemTemplate>
                                                    <asp:Panel ID="pnlPartsDetail" runat="server">
                                                        <asp:GridView CssClass="ChildGrid" ID="gvRequisitionInfo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowDataBound="gvRequisitionInfo_RowDataBound" OnRowCommand="gvRequisitionInfo_RowCommand">
                                                            <Columns>


                                                                <asp:TemplateField HeaderText="Req Number" HeaderStyle-Width="8%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblReqId" runat="server" Text='<%# Eval("ReqID") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblReqDetailId" runat="server" Text='<%# Eval("ReqDetailId") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblReqNumber" runat="server" Text='<%# Eval("ReqNumber") %>'></asp:Label>
                                                                        <asp:Label ID="lblItemPartid" runat="server" Visible="false" Text='<%# Eval("Partid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Requestor" HeaderStyle-Width="8%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvRequestor" runat="server"
                                                                            Text='<%# Eval("Requestor") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Req Qty" HeaderStyle-Width="5%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblReqQty" runat="server" Text='<%# Eval("ReqQty") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="In Stock" HeaderStyle-Width="5%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInStock" runat="server" Text='<%# Eval("InStock") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="In Transit" HeaderStyle-Width="5%">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkInTransit" runat="server" CommandName="Select" Text='<%# Eval("InTransit") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="In Shop" HeaderStyle-Width="5%">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkInShop" runat="server" CommandName="Select2" Text='<%# Eval("InShop") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="5%">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPOOrderQty" runat="server" autocomplete="off" CssClass="form-control form-control-sm text-right"
                                                                            Text='<%# Eval("POOrderQty") %>'
                                                                            onkeypress="return onlyNumbers(event);" MaxLength="5" onpaste="return false" AutoPostBack="true" OnTextChanged="txtPOOrderQty_TextChanged"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Priority" HeaderStyle-Width="5%">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkPriorityFooter" Checked='<%# Eval("Priority") != DBNull.Value && Convert.ToBoolean(Eval("Priority")) %>' runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="18%">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtItemRemarks" runat="server" Text='<%# Eval("Remarks") %>' MaxLength="500" autocomplete="off" CssClass="form-control form-control-sm text-left" TextMode="MultiLine"></asp:TextBox>

                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlReqStatus" runat="server" Text='<%# Eval("StatusID") %>' autocomplete="off" CssClass="form-control form-control-sm text-left">
                                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                                            <asp:ListItem Value="1">Open</asp:ListItem>
                                                                            <asp:ListItem Value="2">Close</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:Label ID="lblStatusID" runat="server" Text='<%# Eval("StatusID") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
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

            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="ReportsModalPopup" Style="display: none; max-width: 100%;" Width="80%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-y: hidden;">
                        <div class="row justify-content-center">
                            <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                <div class="row">
                                    <div class="col-sm-3 col-md-auto mb-3 modal-title text-center">
                                        <h4>
                                            <label class="mb-0 title-hyphen position-relative">Part Number:</label></h4>
                                    </div>
                                    <div class="col-sm-9 col-md mb-3 chosenFullWidth ">
                                        <h4>
                                            <asp:Label ID="lblPartNumber" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <table>
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInTransit" runat="server" AutoGenerateColumns="False"
                                EnableModelValidation="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Source" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSource" runat="server" Text='<%# Eval("Source") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Destination" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("Destination") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Container No" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContainerNo" runat="server" Text='<%# Eval("ContainerNo") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Invoice No" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNo") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tentative Ship Date" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTentativeShipdate" runat="server" Text='<%# Eval("TentativeShipDate","{0:MM/dd/yyyy}") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Arrival In Aerowerks" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblArrivalInAerowerksDate" runat="server" Text='<%# Eval("ArriveDate","{0:MM/dd/yyyy}") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO No" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="In Transit" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInTransit" runat="server" Text='<%# Eval("Intransit") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </table>

                    </div>
                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="LinkButton2"
                PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="ReportsModalPopup" Style="display: none;" Width="85%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton1" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-y: hidden;">
                        <div class="row justify-content-center">
                            <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                <div class="row">
                                    <div class="col-sm-3 col-md-auto mb-3 modal-title text-center">
                                        <h4>
                                            <label class="mb-0 title-hyphen position-relative">Part Number:</label></h4>
                                    </div>
                                    <div class="col-sm-9 col-md mb-3 chosenFullWidth ">
                                        <h4>
                                            <asp:Label ID="lblInShopPartNumber" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <table class="table mainGridTable table-sm">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInShop" runat="server" AutoGenerateColumns="False"
                                EnableModelValidation="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="PO No" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONumber") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prepared By" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPreparedBy" runat="server" Text='<%# Eval("PreparedBy") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Source" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSource" runat="server" Text='<%# Eval("Source") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Destination" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWareHouseDest" runat="server" Text='<%# Eval("DestWarehouse") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issue Date" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("IssueDate","{0:MM/dd/yyyy}") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("OrderQty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ship Qty" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShip" runat="server" Text='<%# Eval("ShipQty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="In Shop" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInShop" runat="server" Text='<%# Eval("InShop") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </table>
                    </div>
                </div>

            </asp:Panel>


            <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
            </div>
            <script type="text/javascript">
                $(document).ready(function () {
                    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
                    //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                });

                function PageLoaded(sender, args) {
                    BindDrp();
                }

                $.when.apply($, PageLoaded).then(function () {
                    BindDrp();
                });

                function BindDrp() {
                    $('#<%=ddlPurchaseOrder.ClientID%>').chosen();
                    $('#<%=ddlSource.ClientID%>').chosen();
                    $('#<%=ddlPreparedby.ClientID%>').chosen();
                    $('#<%=ddlStatus.ClientID%>').chosen();
                    $('#<%=ddlPartNo.ClientID%>').chosen();
                    $('#<%=ddlReqNumber.ClientID%>').chosen();
                    $('#<%=ddlWareHouse.ClientID%>').chosen();

                }

            </script>
            <asp:HiddenField ID="hfpartid" runat="server" />
            <CR:CrystalReportViewer ID="rptRequisition" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerate" />
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
