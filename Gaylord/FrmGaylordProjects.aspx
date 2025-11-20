<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmGaylordProjects.aspx.cs" Inherits="Gaylord_FrmGaylordProjects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="cntForm" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="udpForm" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()">
                                <i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Gaylord Project Information
                            </h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="row">
                                    <div class="col-sm-auto">
                                        <label class="mb-0">Project Name</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                        </asp:Panel>
                                        <asp:Panel ID="PanelPName" runat="server" DefaultButton="SearchPNameButton">
                                            <asp:TextBox ID="txtSearchPName" AutoComplete="off" placeholder="Type Job Name" CssClass="form-control form-control-sm" OnBlur="return ClickEventForPName(event)" runat="server">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="PName_Extender" runat="server" TargetControlID="txtSearchPName"
                                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchGaylordProject" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="SearchPNameButton_Click" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="row">
                                    <div class="col-sm-auto">
                                        <label class="mb-0">PO#</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Panel ID="PanelJNum_Hidden" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                        </asp:Panel>
                                        <asp:Panel ID="PanelJNum" runat="server" DefaultButton="SearchJNumberButton">
                                            <asp:TextBox ID="txtSearchPNum" AutoComplete="off" placeholder="Type Job Number" CssClass="form-control form-control-sm" OnBlur="return ClickEvent(event)" runat="server">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchPNum"
                                                CompletionInterval="3" CompletionSetCount="10" MinimumPrefixLength="2" CompletionListElementID="PanelJNum_Hidden"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchGaylordJobID" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchJNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="SearchJNumberButton_Click" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="row">
                                    <div class="col-auto">
                                        <%--<asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm mb-3" OnClick="btnNew_Click" Text="New Order" />--%>
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm mb-3" Text="Save" OnClick="btnSave_Click" />
                                        <%--<asp:Button ID="btnPreviewReport" runat="server" CssClass="btn btn-secondary btn-sm mb-3" CausesValidation="false" OnClick="btnPreviewReport_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" />--%>
                                        <%--<asp:Button ID="btnFilter" runat="server" CssClass="btn btn-secondary btn-sm mb-3" Enabled="true" OnClick="btnFilter_Click" Text="Filter Data" />--%>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm mb-3" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="RemoveQueryString()" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Project Information</h5>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>PO#</label>
                            <asp:TextBox ID="txtPONumber" runat="server" MaxLength="50" AutoComplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Project Name</label>
                            <asp:TextBox ID="txtProjectName" runat="server" MaxLength="250" AutoComplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Drawing Received Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDrawingReceivedDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDrawingReceivedDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDrawingReceivedDate" TargetControlID="txtDrawingReceivedDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">PO Received Date*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPOReceivedDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtPOReceivedDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtPOReceivedDate" TargetControlID="txtPOReceivedDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Req. Ship Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtReqShipDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReqShipDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReqShipDate" TargetControlID="txtReqShipDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label id="lblConfirmedShipDate" runat="server">Confirmed Ship Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtShipDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipDate" TargetControlID="txtShipDate"></asp:CalendarExtender>
                        </div>
                    </div>                   

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Target Completion Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTargetCompletionDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtTargetCompletionDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtTargetCompletionDate" TargetControlID="txtTargetCompletionDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <label class="text-danger">PO Type*</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPOType" runat="server" DataTextField="text" DataValueField="id"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlPOType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Shipping Location</label>
                            <asp:TextBox ID="txtShippingLocation" runat="server" MaxLength="100" AutoComplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>                    
                </div>
            </div>

            <div class="col-12 pt-2 border-top">
                <div class="row">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Project Parts                                     
                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnAdd" runat="server" Text="Add Part" OnClick="btnAdd_Click" />
                            <asp:Button CssClass="btn btn-danger btn-sm" ID="btnClear" runat="server" Text="Cancel" OnClick="btnClear_Click" />
                        </h5>
                    </div>

                    <div class="col-2">
                        <label id="lblWorkOrder" runat="server">Work Order</label>
                        <div class="d-flex">
                            <asp:DropDownList CssClass="form-control form-control-sm me-2" ID="ddlWorkOrder" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                            <asp:Button ID="btnOpenWO" runat="server" CssClass="btn btn-sm btn-primary" Text="Add WO" OnClick="btnOpenWO_Click" />
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Item Type*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlItemType" runat="server" DataTextField="text" DataValueField="id"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div runat="server" id="dvItemType_Stock" class="row col-8">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Product Code</label>
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductCodeLookup" runat="server" DataTextField="text" DataValueField="id"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlProductCodeLookup_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label class="text-danger">Part #*</label>
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartNo" DataTextField="PartNumber" DataValueField="ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPartNo_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="text-danger">Part Description*</label>
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartsDetail" DataTextField="PartDes" DataValueField="ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPartsDetail_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-2">
                            <div class="form-group">
                                <label>UM</label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtUM" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div runat="server" id="dvItemType_NonStock" class="row col-7" visible="false">
                        <div class="col-5">
                            <div class="form-group">
                                <label class="text-danger">Part #*</label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtPartNo" runat="server" MaxLength="50" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-7">
                            <div class="form-group">
                                <label>Part Description</label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtPartDescription" runat="server" MaxLength="200" AutoComplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-1">
                        <div class="form-group">
                            <label class="text-danger">Quantity*</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtQty" AutoComplete="off" MaxLength="6" runat="server" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="form-group">
                            <label>Comments</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtComments" runat="server" MaxLength="500" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)" AutoComplete="off"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <label>Mode of Shipment</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlModeOfShipment_Part" runat="server" DataTextField="text" DataValueField="id">
                        </asp:DropDownList>
                    </div>

                     <div class="col-sm-2">
                        <div class="form-group">
                            <label>Release To Fab</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtReleaseToFab" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReleaseToFab_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReleaseToFab" TargetControlID="txtReleaseToFab"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <label>Layout By</label>
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLayoutBy" runat="server" DataTextField="text" DataValueField="id">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-12 pt-3">
                <div class="table-responsive">
                    <asp:GridView CssClass="table mainGridTable table-sm" ID="gvPartDetail" runat="server" AutoGenerateColumns="False" EmptyDataText="No Parts has been Added"
                        EnableModelValidation="True" DataKeyNames="ProjectPartID" OnRowDeleting="gvPartDetail_RowDeleting" OnRowEditing="gvPartDetail_RowEditing" OnRowCommand="gvPartDetail_RowCommand"
                        OnRowDataBound="gvPartDetail_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No." HeaderStyle-CssClass="align-center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text='<%#Eval("RowNum") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Work Order">
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkOrder" runat="server" Text='<%#Eval("WorkOrder") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartNo" runat="server" Text='<%#Eval("PartNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartDes" runat="server" Text='<%#Eval("PartDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Qty Ordered" HeaderStyle-CssClass="align-right">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UM">
                                <ItemTemplate>
                                    <asp:Label ID="lblUM" runat="server" Text='<%#Eval("UM") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Ship Qty" HeaderStyle-CssClass="align-right">
                                <ItemTemplate>
                                    <asp:Label ID="lblShipQty" runat="server" Text='<%#Eval("ShipQty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Pending Qty" HeaderStyle-CssClass="align-right">
                                <ItemTemplate>
                                    <asp:Label ID="lblPendingQty" runat="server" Text='<%#Eval("PendingQty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MOQ">
                                <ItemTemplate>
                                    <asp:Label ID="lblMOQ" runat="server" Text='<%#Eval("MOQ") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="EAU">
                                <ItemTemplate>
                                    <asp:Label ID="lblEAU" runat="server" Text='<%#Eval("EAU") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Batch">
                                <ItemTemplate>
                                    <asp:Label ID="lblBatch" runat="server" Text='<%#Eval("Batch") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Modify" HeaderStyle-CssClass="align-center">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandName="ShipmentGrid">
                                                        <i class="fa fa-plus-square" title="Shipment"></i>                                                
                                    </asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-info btn-sm" CommandName="edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                    &nbsp;
				                    <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure to delete. ?');" runat="server" CommandName="Delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <asp:ModalPopupExtender ID="ModalWorkOrderDetails" runat="server" TargetControlID="btnWorkOrderDetails"
                PopupControlID="PanelWorkOrderDetails" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PanelWorkOrderDetails" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="50%" Height="70%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-auto h-100">
                        <div class="col-12">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <h5 class="text-uppercase text-center">Work Orders:-
                                      <asp:Label ID="lblPOHeadingForWorkOrder" runat="server">P001</asp:Label>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-4">
                                    <div class="form-group">
                                        <label class="text-danger">Work Order*</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtWorkOrder" runat="server" MaxLength="100" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-8">
                                    <label>&nbsp;</label>
                                    <div class="form-group">
                                        <asp:Button ID="btnSaveWorkOrder" runat="server" CssClass="btn btn-primary btn-sm" Text="Add" OnClick="btnSaveWorkOrder_Click" />
                                        <%--<asp:Button ID="btnReleasePart" runat="server" CssClass="btn btn-success btn-sm" Text="Release Parts" OnClick="btnReleasePart_Click" OnClientClick="return confirm('Are you sure you want to release shipment(s)?');" />--%>
                                        <asp:Button ID="btnCancelWorkOrder" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancelWorkOrder_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <asp:GridView ID="gvWorkOrder" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" EmptyDataText="No Records Found"
                                        BorderWidth="1px" CellPadding="3" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="100%" AllowSorting="true"
                                        CssClass="table mainGridTable table-sm" OnRowDeleting="gvWorkOrder_RowDeleting" DataKeyNames="Id"
                                        OnRowEditing="gvWorkOrder_RowEditing" Style="font-size: small" BackColor="White" BorderColor="#999999">
                                        <Columns>

                                            <asp:BoundField DataField="text" HeaderText="Work Orders">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Modify" ItemStyle-Width="15%">
                                                <ItemTemplate>
                                                    <div style="text-align: center;">
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-info btn-sm" CommandName="edit">
                                                            <i class="far fa-edit" title="Edit"></i>
                                                        </asp:LinkButton>

                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                            <i class="far fa-times-circle"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <%--<ItemStyle HorizontalAlign="Center" Width="140px" />--%>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="btnWorkOrderDetails" runat="server"></asp:LinkButton>

            <%-- Shipment grid --%>
            <asp:ModalPopupExtender ID="ModalShipmentDetails" runat="server" TargetControlID="btnShipmentDetails"
                PopupControlID="PanelShipmentDetails" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PanelShipmentDetails" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="70%" Height="70%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="overflow-auto h-100">
                        <div class="col-12">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <h5 class="text-uppercase text-center">Shipment Details:-
                                      <asp:Label ID="lblOrderAndPartNo" runat="server">Order 1/P001</asp:Label>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-2" style="display: none;">
                                    <div class="form-group">
                                        <label class="text-danger">Order Detail ID</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipmentId" autocomplete="off" Text="-1" MaxLength="5" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-2">
                                    <div class="form-group">
                                        <label class="text-danger">Order Qty*</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrderQty" Style="text-align: right" autocomplete="off" Text="100" MaxLength="5" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-2">
                                    <div class="form-group">
                                        <label class="text-danger">Ship Qty*</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipQty" Style="text-align: right" autocomplete="off" MaxLength="5" runat="server" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-2">
                                    <div class="form-group">
                                        <label>Req. Receive Date</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtRequestedReceiveDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtRequestedReceiveDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtRequestedReceiveDate" TargetControlID="txtRequestedReceiveDate"></asp:CalendarExtender>
                                    </div>
                                </div>

                                <div class="col-2">
                                    <div class="form-group">
                                        <label class="text-danger">Ship Date*</label>
                                        <asp:TextBox ID="txtShipmentShipDate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtShipmentShipDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipmentShipDate" TargetControlID="txtShipmentShipDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>

                                <div class="col-2 chosenFullWidth">
                                    <label>Mode of Shipment</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlModeOfShipment_Shipment" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-2">
                                    <div class="form-group">
                                        <label>UPS Tracking #</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtUPSTrackingNo" runat="server" MaxLength="50" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-4">
                                    <div class="form-group">
                                        <label class="text-danger">Comments*</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipmentComments" runat="server" oninput="return limitMultiLineInputLength(this, 500)"
                                            TextMode="MultiLine" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-8">
                                    <%--<label>&nbsp;</label>--%>
                                    <div class="form-group">
                                        <asp:Button ID="btnAddShipmentDetail" runat="server" CssClass="btn btn-primary btn-sm" Text="Add Ship Qty" OnClick="btnAddShipmentDetail_Click" />
                                        <%--<asp:Button ID="btnReleasePart" runat="server" CssClass="btn btn-success btn-sm" Text="Release Parts" OnClick="btnReleasePart_Click" OnClientClick="return confirm('Are you sure you want to release shipment(s)?');" />--%>
                                        <asp:Button ID="btnCancelShipmentDetail" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancelShipmentDetail_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <asp:GridView ID="gvShipmentHistory" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" EmptyDataText="No Records Found"
                                        BorderWidth="1px" CellPadding="3" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="100%" AllowSorting="true"
                                        CssClass="table mainGridTable table-sm" OnRowDeleting="gvShipmentHistory_RowDeleting" DataKeyNames="id"
                                        OnRowEditing="gvShipmentHistory_RowEditing" Style="font-size: small" BackColor="White" BorderColor="#999999">
                                        <%--DataKeyNames="id"--%>
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="Release">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRelease" runat="server" Checked='<%# Eval("Release") != null && Eval("Release").ToString().Equals("Yes", StringComparison.OrdinalIgnoreCase) %>'
                                                        Enabled='<%# !(Eval("Release") != null && Eval("Release").ToString().Equals("Yes", StringComparison.OrdinalIgnoreCase)) %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>--%>

                                            <asp:BoundField DataField="ShipQty" HeaderText="Ship Qty">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <HeaderStyle CssClass="header-right" Width="8%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="RequestedReceiveDate" HeaderText="Requested Receive Date">
                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ShipDate" HeaderText="Ship Date">
                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Comments" HeaderText="Comments">
                                                <ItemStyle HorizontalAlign="Left" Width="35%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ModeOfShipment" HeaderText="Mode of Shipment">
                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Release" HeaderText="Released" Visible="false">
                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Modify" ItemStyle-Width="15%">
                                                <ItemTemplate>
                                                    <div style="text-align: center;">
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-info btn-sm" CommandName="edit">
                                                            <i class="far fa-edit" title="Edit"></i>
                                                        </asp:LinkButton>

                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                            <i class="far fa-times-circle"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <%--<ItemStyle HorizontalAlign="Center" Width="140px" />--%>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="btnShipmentDetails" runat="server"></asp:LinkButton>
            <asp:HiddenField ID="HfPOId" runat="server" Value="-1" />
            <asp:HiddenField ID="HfWorkOrderId" runat="server" Value="-1" />
            <asp:HiddenField ID="HfProjectPartId" runat="server" Value="-1" />
            <asp:HiddenField ID="HfShipmentId" runat="server" Value="-1" />
        </ContentTemplate>
    </asp:UpdatePanel>
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
            $('#<%=ddlWorkOrder.ClientID%>').chosen();
            $('#<%=ddlPOType.ClientID%>').chosen();
            $('#<%=ddlPartNo.ClientID%>').chosen();
            $('#<%=ddlPartsDetail.ClientID%>').chosen();
            $('#<%=ddlProductCodeLookup.ClientID%>').chosen();
            $('#<%=ddlLayoutBy.ClientID%>').chosen();
            $('#<%=ddlModeOfShipment_Part.ClientID%>').chosen();
            $('#<%=ddlModeOfShipment_Shipment.ClientID%>').chosen();
            $('#<%=ddlItemType.ClientID%>').chosen();
        }

        function ClickEventForPName(e) {
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchJNumberButton.UniqueID%>', "");
        }

        function RemoveQueryString() {
            var uri = window.location.toString();
            if (uri.indexOf("?") > 0) {
                var clean_uri = uri.substring(0, uri.indexOf("?"));
                window.history.replaceState({}, document.title, clean_uri);
            }
        }
    </script>
</asp:Content>
