<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmSearchRequisitionHistory.aspx.cs" Inherits="InventoryManagement_frmSearchRequisitionHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 border-bottom piDiv position-sticky py-3">
                <div class="row">
                    <div class="col-sm-12 col-md-12 mx-auto">
                        <div class="row">
                            <div class="col-12">
                                <h4 class="title-hyphen position-relative mb-3">Aerowerks Requistion History</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2">
                                <div class="row">
                                    <label class="col-12">Start Date</label>
                                    <div class="col">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <div class="row">
                                    <label class="col-12">End Date</label>
                                    <div class="col">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtToDate"
                                            TargetControlID="txtToDate">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                     
                            <div class="col-sm">
                                <div class="row">
                                    <label class="col-12">&nbsp;</label>
                                    <div class="col-12">
                                        <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" />                                     
                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" CausesValidation="false" runat="server" Enabled="false" Text="Export to Excel" OnClick="btnGenerateExcel_Click"  />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 mt-3">
                <div class="table-responsive eoeTable" style="height: 750px">
                    <asp:GridView ID="gvSearch" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="table mainGridTable table-sm mb-0"
                        EnableModelValidation="True" AutoGenerateColumns="False" OnRowCommand="gvSearch_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Catergory" HeaderText="Category" />
                            <asp:BoundField DataField="Partnumber" HeaderText="Part #" />
                            <asp:BoundField DataField="PartDesc" HeaderText="Part Desc" />
                            <asp:BoundField DataField="stockinhand" HeaderText="Stock In Hand"  />
                            <asp:TemplateField HeaderText="In Transit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTransit" runat="server" Text='<%# Eval("Intransit") %>' CausesValidation="false" CommandName="Select"></asp:LinkButton>
                                   <%--  <asp:Label ID="lblparttransitid" runat="server" Text='<%# Eval("Intransit") %>'  Visible="false"></asp:Label>--%>
                                     <asp:Label ID="lblPartintransitid" runat="server" Text='<%# Eval("Partid") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="In Shop">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkInShop" runat="server" Text='<%# Eval("InShop") %>' CausesValidation="false" CommandName="Select2"></asp:LinkButton>
                                      <%--<asp:Label ID="lblpartshopid" runat="server" Text='<%# Eval("InShop") %>' Visible="false"></asp:Label>--%>
                                        <asp:Label ID="lblPartshpid" runat="server" Text='<%# Eval("Partid") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                                                <asp:Label ID="lblPartnumber" runat="server" Text='<%# Eval("Partnumber") %>'></asp:Label>
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
                                                <asp:Label ID="lblReqNo" runat="server" Text='<%# Eval("ReqNo") %>'></asp:Label>
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
             <asp:HiddenField ID="hfpartid" runat="server" />
        </ContentTemplate>
      <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerateExcel" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>