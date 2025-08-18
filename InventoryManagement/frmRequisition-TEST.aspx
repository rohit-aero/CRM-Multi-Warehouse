<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmRequisition-TEST.aspx.cs" Inherits="INVManagement_frmRequisition " %>

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
                            <h4 class="title-hyphen position-relative">Requisition Maintenance</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Requisition</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPreparedByList" runat="server" DataTextField="FirstName" DataValueField="EmployeeID" AutoPostBack="True" OnSelectedIndexChanged="ddlPreparedByList_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartInfo" runat="server" DataTextField="ReqNo" DataValueField="Requisitionid" AutoPostBack="True" OnSelectedIndexChanged="ddlPartInfo_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Add New Requisition" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Approve & Submit" Enabled="false" OnClientClick="return confirm('Are you sure to Submit this requisition.?');" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnGenerate" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Requisition" OnClick="btnGenerate_Click" />
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
                        <h5 class="text-uppercase">Requisition Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Requisition #</label>
                            <asp:TextBox ID="txtReqNo" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>

                        </div>
                    </div>
                  <%--  <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Requisition For</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReqNo" DataTextField="InvSource" DataValueField="InvSourceid" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>--%>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Prepared By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPreparedby" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Approved By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlApprovedby" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Requested Arrival Date</label>
                            <asp:TextBox ID="txtTentativeshipdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtTentativeshipdate" TargetControlID="txtTentativeshipdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2" style="display: none;">
                        <div class="form-group">
                            <label>Actual Ship Date</label>
                            <asp:TextBox ID="txtActualShipdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtActualShipdate" TargetControlID="txtActualShipdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <%--<div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Requisition Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReqStatus" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="2">Close</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Requisition details with quantities</h5>
                        <div class="table-responsive">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <th style="width: 10%;">Division</th>
                                    <th style="width: 10%;">Product Line</th>
                                    <th style="width: 10%;">Part#</th>
                                    <th style="width: 5%;">Revision#</th>
                                    <th style="width: 20%;">Description</th>
                                    <th>Min</th>
                                    <th>Max</th>
                                    <th>In Hand</th>
                                    <th>In Transit</th>
                                    <th>Qty Backordered</th>
                                    <th style="width: 5%;">Order</th>
                                    <th>Priority</th>
                                    <th>Comments</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDivision" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLine" runat="server" DataTextField="Product" DataValueField="Prodctid" AutoPostBack="True" OnSelectedIndexChanged="ddlProductLine_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartno" runat="server" DataTextField="PartNumber" DataValueField="Partid" AutoPostBack="True" OnSelectedIndexChanged="ddlfooterpartno_SelectedIndexChanged">
                                            <%--<asp:ListItem Selected="True"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblfooterpartrevisionno" runat="server" DataValueField="Productid" DataTextField="revisionno"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartinfo" runat="server" DataTextField="PartDescription" DataValueField="Partid" AutoPostBack="true" OnSelectedIndexChanged="ddlfooterpartinfo_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFooterMin" runat="server" DataValueField="Productid" DataTextField="Min"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFooterMax" runat="server" DataValueField="Productid"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFooterStockinhand" runat="server" DataValueField="Productid"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkFooterTransit" runat="server"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkFooterShop" runat="server"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtfooterqty" MaxLength="5" onkeypress="return onlyDotsAndNumbers(this,event);" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkfooterPriority" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-left" ID="txtcomments" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" CommandName="Insert" OnClick="btnAdd_Click" />
                                </tr>
                            </table>
                            <asp:Panel ID="pangvRequititionDetails" runat="server">
                                <div class="row pt-3">
                                    <div class="col-12">
                                        <div class="table-responsive">
                                            <asp:GridView BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                                                ForeColor="Black" GridLines="Vertical" Width="100%" Style="font-size: small"
                                                ID="gvRequition" runat="server" AutoGenerateColumns="False" DataKeyNames="ReqDetailid" CssClass="table mainGridTable table-sm"
                                                EnableModelValidation="True" OnRowDeleting="gvRequition_RowDeleting" OnRowCommand="gvRequition_RowCommand" AllowSorting="True" OnSorting="gvRequition_Sorting">
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Part#" HeaderStyle-Width="7%" SortExpression="Partnumber">
                                                        <ItemTemplate>
                                                            <%-- asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartno" runat="server" DataTextField="PartNumber" DataValueField="Partid" AutoPostBack="True" OnSelectedIndexChanged="ddlfooterpartno_SelectedIndexChanged"></asp:DropDownList>--%>

                                                            <asp:Label ID="lblpartnumber" runat="server" Text='<%# Eval("Partnumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                        <HeaderStyle Width="7%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Revision#" HeaderStyle-Width="5%" SortExpression="revisionno">
                                                        <%--<FooterTemplate>
                                                        <asp:Label ID="lblfooterpartrevisionno" runat="server" Text='<%# Eval("revisionno") %>'></asp:Label>
                                                    </FooterTemplate>--%>
                                                        <ItemStyle />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpartrevno" runat="server" Text='<%# Eval("revisionno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="48%" SortExpression="PartDesc">
                                                        <%--<FooterTemplate>
                                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartinfo" runat="server" DataTextField="PartDescription" DataValueField="Partid" AutoPostBack="true" OnSelectedIndexChanged="ddlfooterpartinfo_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:Label ID="lblfooterPartinfo" runat="server" Text='<%# Eval("Partid") %>'></asp:Label>
                                                    </FooterTemplate>--%>
                                                        <ItemStyle />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPartinfo" runat="server" Text='<%# Eval("PartDesc") %>'></asp:Label>
                                                            <asp:Label ID="lblpartid" runat="server" Text='<%# Eval("Partid") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="48%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Min" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Right" SortExpression="minqty">
                                                        <%--<FooterTemplate>
                                                        <asp:Label ID="lblFooterMin" runat="server" Text='<%# Eval("minqty") %>'></asp:Label>
                                                    </FooterTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMin" runat="server" Text='<%# Eval("minqty") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="5%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Max" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Right" SortExpression="maxqty">
                                                        <%-- <FooterTemplate>
                                                        <asp:Label ID="lblFooterMax" runat="server" Text='<%# Eval("maxqty") %>'></asp:Label>
                                                    </FooterTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMax" runat="server" Text='<%# Eval("maxqty") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="5%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="In Hand" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right" SortExpression="stockinhand">
                                                        <%--     <FooterTemplate>
                                                        <asp:Label ID="lblFooterStockinhand" runat="server" Text='<%# Eval("stockinhand") %>'></asp:Label>
                                                    </FooterTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStockinHand" runat="server" Text='<%# Eval("stockinhand") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="8%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="In Transit" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                                        <%--<FooterTemplate>
                                                        <asp:LinkButton ID="lnkFooterTransit" runat="server" Text='<%# Eval("Intransit") %>'></asp:LinkButton>
                                                    </FooterTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkItemTranstit" runat="server" Text='<%# Eval("Intransit") %>' CausesValidation="false" CommandName="Select"></asp:LinkButton>
                                                            <asp:Label ID="lblparttransitid" runat="server" Text='<%# Eval("Partid") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="8%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qty Backordered" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                                        <%--   <FooterTemplate>--%>
                                                        <%--                                                        <asp:LinkButton ID="lnkFooterShop" runat="server" Text='<%# Eval("InShop") %>'></asp:LinkButton>--%>
                                                        <%-- <asp:Label ID="lblFooterInShop" runat="server"  Text='<%# Eval("InShop") %>'></asp:Label>--%>
                                                        <%--</FooterTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkItemShop" runat="server" Text='<%# Eval("InShop") %>' CausesValidation="false" CommandName="Select2"></asp:LinkButton>
                                                            <%-- <asp:Label ID="lblInShop" runat="server"  Text='<%# Eval("InShop") %>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="8%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="Right">
                                                        <%--<FooterTemplate>
                                                        <asp:TextBox ID="txtfooterqty" runat="server" Text='<%# Eval("PartQty") %>' autocomplete="off" CssClass="form-control form-control-sm text-right" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                                    </FooterTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtqty" runat="server" Text='<%# Eval("PartQty") %>' autocomplete="off" MaxLength="5" CssClass="form-control form-control-sm text-right" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="7%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Center" HeaderStyle-Width="8%" HeaderText="Priority" ItemStyle-CssClass="ws-nowrap">
                                                        <%--<FooterTemplate>
                                                        <asp:CheckBox ID="chkfooterPriority" runat="server" />
                                                    </FooterTemplate>--%>
                                                        <%-- <FooterStyle HorizontalAlign="Center" />--%>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkpriority" Checked='<%# Eval("Priority") %>' runat="server" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <HeaderStyle Width="8%" />
                                                        <ItemStyle CssClass="ws-nowrap" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="7%" HeaderText="Comments" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtcomments" runat="server" Text='<%# Eval("Comments") %>' CssClass="form-control form-control-sm text-left"></asp:TextBox>
                                                            <%--                                                            <asp:Label ID="lblcomments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <HeaderStyle Width="7%" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="8%" FooterStyle-HorizontalAlign="Center">
                                                        <%-- <FooterTemplate>
                                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" CommandName="Insert" OnClick="btnAdd_Click" />
                                                    </FooterTemplate>--%>
                                                        <EditItemTemplate>
                                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                                            &nbsp;
                                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                                            &nbsp;
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
                        $('#<%=ddlDivision.ClientID%>').chosen();
                        $('#<%=ddlPartInfo.ClientID%>').chosen();
                       <%-- $('#<%=ddlReqNo.ClientID%>').chosen();
                        $('#<%=ddlReqStatus.ClientID%>').chosen();--%>
                        $('#<%=ddlPreparedby.ClientID%>').chosen();
                        $('#<%=ddlApprovedby.ClientID%>').chosen();
                        $('#<%=ddlfooterpartinfo.ClientID%>').chosen();
                        $('#<%=ddlfooterpartno.ClientID%>').chosen();
                        $('#<%=ddlProductLine.ClientID%>').chosen();
                        $('#<%=ddlPreparedByList.ClientID%>').chosen();
                        
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
