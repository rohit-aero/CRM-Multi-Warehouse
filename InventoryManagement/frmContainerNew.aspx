<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmContainerNew.aspx.cs" Inherits="INVManagement_frmContainerNew" %>

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
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Container Details</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Container</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlContainerNo" runat="server" DataTextField="ContainerDetail" DataValueField="Containerid" AutoPostBack="True" OnSelectedIndexChanged="ddlContainerNo_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" CausesValidation="false" OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-sm" Text="Submit" Enabled="false" OnClientClick="return confirm('Are you sure to Submit this requisition.?');" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnGenerate" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview" OnClick="btnGenerate_Click" />
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
                        <h5 class="text-uppercase">Container Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Invoice No</label>
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
                            <label>Seal No</label>
                            <asp:TextBox ID="txtSealNo" CssClass="form-control form-control-sm" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Sent Date</label>
                            <asp:TextBox ID="txtsentdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtsentdate" TargetControlID="txtsentdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Arrival in Aerowerks On</label>
                            <asp:TextBox ID="txtArrivalinAerowerks" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtArrivalinAerowerks" TargetControlID="txtArrivalinAerowerks">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Container</label>
                            <asp:TextBox ID="txtContainer" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Attn</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlAttn" DataValueField="EmployeeID" DataTextField="EmployeeName" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Issued By</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlIssuedBy" DataValueField="EmployeeID" DataTextField="EmployeeName" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <asp:Panel ID="pangvRequititionDetails" runat="server">
                            <div class="row pt-3">
                                <div class="col-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvMainRequisitionDetail" CssClass="table mainGridTable table-sm mb-0" DataKeyNames="POid" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="PO Number" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPOForId" runat="server" Text='<%# Eval("PurchaseOrderFor") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblPOId" runat="server" Text='<%# Eval("PONumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" />
                                                </asp:TemplateField>
                  
                                                <asp:TemplateField HeaderStyle-Width="80%" HeaderText="Purchase Order Details">
                                                    <ItemTemplate>
                                                        <asp:Panel ID="pnlPartsDetail" runat="server">
                                                            <asp:GridView CssClass="ChildGrid" ID="gvContainer" runat="server" AutoGenerateColumns="False" 
                                                                OnRowDataBound="gvContainer_RowDataBound" EnableModelValidation ="True" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Part #" HeaderStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblReqDetailid" runat="server" Text='<%# Eval("PODetailid") %>' Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblPartnumber" runat="server" Text='<%# Eval("PartNo") %>'></asp:Label>
                                                                            <asp:Label ID="lblItemPartid" runat="server" Visible="false" Text='<%# Eval("Partid") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
<%--                                                                    <asp:TemplateField HeaderText="Rev. No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="6%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRevisionNo" runat="server" Text='<%# Eval("revisionno") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>--%>
 <%--                                                                   <asp:TemplateField HeaderText="Attn" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="6%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAttn" runat="server" Text='<%# Eval("Attn") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Part Des" HeaderStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPartDes" runat="server" Text='<%# Eval("PartDes") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
<%--                                                                    <asp:TemplateField HeaderText="Priority" HeaderStyle-Width="8%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblReqprority" runat="server" Text='<%# Eval("ReqPriority") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="7%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Pending Qty" HeaderStyle-Width="6%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPendingQty" runat="server" Text='<%# Eval("Pendingqty") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Ship Qty" HeaderStyle-Width="6%">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtShippingQty" runat="server" autocomplete="off" CssClass="form-control form-control-sm text-right" Text='<%# Eval("ShippedQty") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
 <%--                                                                   <asp:TemplateField HeaderText="Packing No" HeaderStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtPackingNo" runat="server" Text='<%# Eval("PackingNo") %>' MaxLength="500" autocomplete="off" CssClass="form-control form-control-sm text-left" TextMode="MultiLine"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtItemRemarks" runat="server" Text='<%# Eval("Remarks") %>' MaxLength="500" autocomplete="off" CssClass="form-control form-control-sm text-left" TextMode="MultiLine"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' Visible="false" />
                                                        <asp:DropDownList ID="ddlstatus" CssClass="form-control form-control-sm" DataValueField="Status"  DataTextField="Status" runat="server">
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
                }
            </script>
            <asp:HiddenField ID="hfContainerid" runat="server" />
            <asp:HiddenField ID="hfContaineridgetfromdb" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerate" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
