<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="frmPOManual.aspx.cs" Inherits="InventoryManagement_frmPOManual" %>

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
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Purchase Order Manual</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Purchase Order</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPurchaseOrder" runat="server" DataTextField="PONumber" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="ddlPurchaseOrder_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Add New Purchase Order" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click" />
                                <%--<asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Approve & Submit" Enabled="false" OnClientClick="return confirm('Are you sure to Submit this requisition.?');" OnClick="btnSubmit_Click" />--%>
                                <asp:Button ID="btnGenerate" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Purchase Order" OnClick="btnGenerate_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Purchase Order Info Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>PO#</label>
                            <asp:TextBox ID="txtPurchaseOrderNo" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Vendor</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSource" DataTextField="Source" DataValueField="Id" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Prepared By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPreparedby" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                        </div>
                    </div>


                    <%-- <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Approved By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlApprovedby" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                        </div>
                    </div>--%>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Issue Date</label>
                            <asp:TextBox ID="txtIssueDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtIssueDate" TargetControlID="txtIssueDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Purchase Order details with quantities</h5>
                        <div class="table-responsive">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <th style="width: 5%;">Division</th>
                                    <th style="width: 5%;">Product Line</th>
                                    <th style="width: 10%;">Part#</th>
                                    <th style="width: 5%;">Revision#</th>
                                    <th style="width: 8%;">Description</th>
                                    <th style="width: 5%;">Req Qty</th>
                                    <th style="width: 5%;">Order Qty</th>
                                    <%--<th>Remarks</th>--%>
                                    <th style="width: 15%;"></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDivision" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLine" runat="server" DataTextField="Product" DataValueField="ProductId" AutoPostBack="True" OnSelectedIndexChanged="ddlpartno_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartno" runat="server" DataTextField="PartNumber" DataValueField="PartId" AutoPostBack="True" OnSelectedIndexChanged="ddlfooterpartno_SelectedIndexChanged">
                                            <%--<asp:ListItem Selected="True"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblfooterpartrevisionno" runat="server" DataValueField="ProductId" DataTextField="RevisionNo"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartinfo" runat="server" DataTextField="PartDescription" DataValueField="PartId" AutoPostBack="true" OnSelectedIndexChanged="ddlfooterpartinfo_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtReqQty" MaxLength="5" onkeypress="return onlyDotsAndNumbers(this,event);" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtOrderQty" MaxLength="5" onkeypress="return onlyDotsAndNumbers(this,event);" runat="server" />
                                    </td>
                                    <%--<td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-left" ID="txtRemarks" runat="server" Visible="false"></asp:TextBox>
                                    </td>--%>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" CommandName="Insert" OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pangvRequititionDetails" runat="server">
                                <div class="row pt-3">
                                    <div class="col-12">
                                        <div class="table-responsive">
                                            <asp:GridView BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                                                ForeColor="Black" GridLines="Vertical" Width="100%" Style="font-size: small"
                                                ID="gvRequition" runat="server" AutoGenerateColumns="False" DataKeyNames="PartId" CssClass="table mainGridTable table-sm"
                                                EnableModelValidation="True" OnRowDeleting="gvRequition_RowDeleting" OnRowCommand="gvRequition_RowCommand" AllowSorting="True" OnSorting="gvRequition_Sorting">
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Part#" HeaderStyle-Width="7%" SortExpression="PartNumber">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpartnumber" runat="server" Text='<%# Eval("PartNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                        <HeaderStyle Width="7%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Revision#" HeaderStyle-Width="5%" SortExpression="RevisionNo">

                                                        <ItemStyle />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpartrevno" runat="server" Text='<%# Eval("RevisionNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="48%" SortExpression="PartDesc">

                                                        <ItemStyle />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPartinfo" runat="server" Text='<%# Eval("PartDesc") %>'></asp:Label>
                                                            <asp:Label ID="lblDetailId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblpartid" runat="server" Text='<%# Eval("PartId") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="48%" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Req Qty" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtReqQtyFooter" runat="server" Text='<%# Eval("ReqQty") %>' autocomplete="off" MaxLength="5" CssClass="form-control form-control-sm text-right" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                                            <%--<asp:Label ID="lblReqQty" runat="server" Text='<%# Eval("ReqQty") %>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="7%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtOrderQtyFooter" runat="server" Text='<%# Eval("OrderQty") %>' autocomplete="off" MaxLength="5" CssClass="form-control form-control-sm text-right" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                                            <%--<asp:Label ID="lblReqQty1" runat="server" Text='<%# Eval("ReqQty") %>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="7%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>

                                                   <%-- <asp:TemplateField HeaderStyle-Width="7%" HeaderText="Remarks" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>                                                           
                                                            <asp:TextBox ID="txtRemarksFooter" runat="server" Text='<%# Eval("Remarks") %>' CssClass="form-control form-control-sm text-left"></asp:TextBox>
                                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <HeaderStyle Width="7%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="8%" FooterStyle-HorizontalAlign="Center">
                                                        <EditItemTemplate>
                                                            <%--<asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                                            &nbsp;--%>
                                                            <%-- <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                                            &nbsp;--%>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton CssClass="btn btn-info btn-danger" ID="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure to delete.?');"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <HeaderStyle />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" Wrap="True" />
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
                <asp:Panel ID="Panel1" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="65%" Height="50%">
                    <div class="position-relative h-100">
                        <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                            AlternateText="Close Popup" ToolTip="Close Popup" />
                        <div class="overflow-auto h-100">
                            <table class="table mainGridTable table-sm">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInTransit" runat="server" AutoGenerateColumns="False"
                                    EnableModelValidation="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Req No" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReqNo" runat="server" Text='<%# Eval("ReqNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tentative Ship Date" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTentativeShipdate" runat="server" Text='<%# Eval("TentativeShipDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Container No" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContainerNo" runat="server" Text='<%# Eval("ContainerNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part Number" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Partnumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <%--              <asp:TemplateField HeaderText="Part Desc" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Left">                            
                           
                            <ItemTemplate>
                                <asp:Label ID="lblPartDesc" runat="server" Text='<%# Eval("PartDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>     --%>
                                        <asp:TemplateField HeaderText="In Transit" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">

                                            <ItemTemplate>
                                                <asp:Label ID="lblInTransit" runat="server" Text='<%# Eval("Intransit") %>'></asp:Label>
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
                <asp:Panel ID="Panel2" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="65%" Height="50%">
                    <div class="position-relative h-100">
                        <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton1" runat="server" ImageUrl="../images/closebtnCircle.png"
                            AlternateText="Close Popup" ToolTip="Close Popup" />
                        <div class="overflow-auto h-100">
                            <table class="table mainGridTable table-sm">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInShop" runat="server" AutoGenerateColumns="False"
                                    EnableModelValidation="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Req No" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ReqNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tentative Ship Date" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInShopTentativeShipDate" runat="server" Text='<%# Eval("TentativeShipDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Part Number" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">                       
                                        <ItemTemplate>
                                        <asp:Label ID="lblPartnumber" runat="server"  Text='<%# Eval("Partnumber") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>                     
                                        <asp:TemplateField HeaderText="Part Desc" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <asp:Label ID="lblPartDesc" runat="server" Text='<%# Eval("PartDesc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="In Shop" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInShop" runat="server" Text='<%# Eval("InShop") %>'></asp:Label>
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
                        $('#<%=ddlPurchaseOrder.ClientID%>').chosen();
                        $('#<%=ddlSource.ClientID%>').chosen();
                        $('#<%=ddlPreparedby.ClientID%>').chosen();
                        $('#<%=ddlDivision.ClientID%>').chosen();
                        $('#<%=ddlfooterpartinfo.ClientID%>').chosen();
                        $('#<%=ddlfooterpartno.ClientID%>').chosen();
                        $('#<%=ddlProductLine.ClientID%>').chosen();
                       <%-- var dropdown = document.getElementById('<%=((DropDownList)gvRequition.FooterRow.FindControl("ddlfooterpartinfo")).ClientID %>');
                        $(dropdown).chosen();
                        var dropdown2 = document.getElementById('<%=((DropDownList)gvRequition.FooterRow.FindControl("ddlfooterpartno")).ClientID %>');
                        $(dropdown2).chosen();--%>
                    }
                </script>
                <asp:HiddenField ID="hfpartid" runat="server" />
                <CR:CrystalReportViewer ID="rptRequisition" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerate" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>