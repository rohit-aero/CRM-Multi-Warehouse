<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmRequisitionNew.aspx.cs" Inherits="INVManagement_frmRequisitionNew " %>

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
                            <h4 class="title-hyphen position-relative">Requisition Maintenance</h4>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-5 col-xl-5">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Requisition</label>
                            </div>
                            <div class="col-sm-6 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPreparedByList" runat="server" DataTextField="FirstName" DataValueField="EmployeeID" AutoPostBack="True" OnSelectedIndexChanged="ddlPreparedByList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReq" runat="server" DataTextField="ReqNo" DataValueField="Requisitionid" AutoPostBack="True" OnSelectedIndexChanged="ddlReq_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Add New Requisition" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClientClick="return AlertCheckStatus()" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Requisition Submittion" OnClientClick="return confirm('Are you sure to Submit this requisition.?');" OnClick="btnSubmit_Click" Visible="false" />
                                <asp:Button ID="btnGenerate" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Requisition" OnClick="btnGenerate_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:Button ID="hiddenBtnYes" runat="server" OnClick="hiddenBtnYes_Click" Style="display: none"></asp:Button>
                                <asp:Button ID="hiddenBtnNo" runat="server" OnClick="hiddenBtnNo_Click" Style="display: none"></asp:Button>
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
                            <label class="text-danger">Requisition #*</label>
                            <asp:TextBox ID="txtReqNo" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Prepared By*</label>
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
                            <asp:TextBox ID="txtTentativeshipdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" Enabled="false" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtTentativeshipdate" TargetControlID="txtTentativeshipdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2" style="display: none;">
                        <div class="form-group">
                            <label>Actual Ship Date</label>
                            <asp:TextBox ID="txtActualShipdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" Enabled="false" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtActualShipdate" TargetControlID="txtActualShipdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList ID="ddlReqStatus" CssClass="form-control form-control-sm" autocomplete="off" runat="server" DataTextField="Status" DataValueField="ReqStatusID"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Requisition details with quantities &emsp;<asp:Button CssClass="btn btn-success btn-sm rounded" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button CssClass="btn btn-success btn-sm rounded" ID="btnShowParts" runat="server" Text="Show Parts" OnClick="btnShowParts_Click" />

                        </h5>
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-4">
                        <div class="form-group">
                            <label class="text-danger">Part#/Description*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartno" runat="server" DataTextField="PartNumber" DataValueField="Partid" AutoPostBack="True" OnSelectedIndexChanged="ddlfooterpartno_SelectedIndexChanged">
                                <%--<asp:ListItem Selected="True"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-8 col-md-4 col-lg-4" style="display: none">
                        <div class="form-group">
                            <label class="text-danger">Description*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartinfo" runat="server" DataTextField="PartDescription" DataValueField="Partid" AutoPostBack="true" OnSelectedIndexChanged="ddlfooterpartinfo_SelectedIndexChanged"></asp:DropDownList>

                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Source</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtSource" runat="server" Enabled="false"></asp:TextBox>
                            <asp:Label CssClass="form-control form-control-sm" ID="lblSourceID" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Product Code</label>
                            <asp:TextBox ID="lblProductCode" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Department</label>
                            <asp:TextBox ID="lblDepartment" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>UM</label>
                            <asp:TextBox ID="lblUm" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-2" id="DivInStock" runat="server" visible="false">
                        <div class="form-group">
                            <label>In Stock</label>
                            <asp:LinkButton ID="lnkInStock" CssClass="form-control form-control-sm text-right" runat="server" OnClick="lnkInStock_Click"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-2" id="InTransit" runat="server" visible="false">
                        <div class="form-group">
                            <label>In Transit</label>
                            <asp:LinkButton ID="lblInTransit" runat="server" OnClick="lblInTransit_Click" CssClass="form-control form-control-sm text-right"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-2" id="DivInShop" runat="server" visible="false">
                        <div class="form-group">
                            <label>In Shop</label>
                            <asp:LinkButton ID="lnkInShop" CssClass="form-control form-control-sm text-right" runat="server" OnClick="lnkInShop_Click"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Order Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOrderType" runat="server" DataTextField="OrderType" DataValueField="OrderTypeId"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Requested By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRequestor" runat="server" DataTextField="FirstName" DataValueField="EmployeeID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Ship By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipBy" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">By Sea</asp:ListItem>
                                <asp:ListItem Value="2">By Air</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Order Qty*</label>
                            <asp:Label CssClass="form-control form-control-sm text-right" ID="lblReOrder" runat="server" Visible="false"></asp:Label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtfooterqty" MaxLength="5"
                                onkeypress="return onlyNumbers(event);" runat="server" autocomplete="off" onchange="Message()"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Priority&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</label>
                            <asp:CheckBox ID="chkfooterPriority" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-5 col-lg-5">
                        <div class="form-group">
                            <label>Comments</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-left" ID="txtcomments" runat="server" autocomplete="off" MaxLength="500">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div id="pangvRequititionDetails" runat="server" class="row border-top pt-3">

                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                                    ForeColor="Black" GridLines="Vertical" Width="100%"
                                    ID="gvRequition" runat="server" AutoGenerateColumns="False" DataKeyNames="ReqDetailid" CssClass="table mainGridTable table-sm"
                                    EnableModelValidation="True" OnRowDeleting="gvRequition_RowDeleting" OnRowCommand="gvRequition_RowCommand" OnRowDataBound="gvRequition_RowDataBound" OnRowEditing="gvRequition_RowEditing">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Part#/Description" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartnumber" runat="server" Text='<%# Eval("Partnumber") %>'></asp:Label>

                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="20%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%" Visible="false">

                                            <ItemStyle />

                                            <ItemTemplate>
                                                <asp:Label ID="lblPartinfo" runat="server" Text='<%# Eval("PartDesc") %>'></asp:Label>
                                                <asp:Label ID="lblpartid" runat="server" Text='<%# Eval("Partid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Source" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSource" runat="server" Text='<%# Eval("Source") %>'></asp:Label>
                                                <asp:Label ID="lblGvSourceID" Visible="false" runat="server" Text='<%# Eval("SourceID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product Code" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvProductCode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UM" HeaderStyle-Width="4%" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvUM" runat="server" Text='<%# Eval("UM") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="4%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order Type" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrderById" runat="server" Text='<%# Eval("OrderType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requested By" HeaderStyle-Width="11%">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRequestorId" runat="server" Text='<%# Eval("Requestor") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="11%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ship By" HeaderStyle-Width="8%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipById" runat="server" Text='<%# Eval("ShipBy") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="8%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="In Stock" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkgvInStock" runat="server" Text='<%# Eval("InStock") %>' CommandName="InStock" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="In Shop" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkgvInShop" runat="server" Text='<%# Eval("InShop") %>' CausesValidation="false" CommandName="Select2"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="InTransit" HeaderStyle-Width="6%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkInTransit" runat="server" Text='<%# Eval("InTransit") %>' CausesValidation="false" CommandName="Select"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="6%" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="txtQty" runat="server" Text='<%# Eval("PartQty") %>' autocomplete="off"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Right" />

                                        </asp:TemplateField>
                                        <asp:TemplateField FooterStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="Priority" ItemStyle-CssClass="ws-nowrap">
                                            <ItemTemplate>
                                                <asp:Label ID="chkpriority" Text='<%# Eval("Priority") %>' runat="server" />
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle CssClass="ws-nowrap" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="35%" HeaderText="Comments" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="txtcomments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>

                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="35%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="ws-nowrap" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="btn btn-primary btn-sm" Text="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-info btn-danger" ID="Delete" runat="server" CommandName="Delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle />

                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>


            </div>

            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="85%" Height="60%">
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
                        <table class="table mainGridTable table-sm">
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
                                            <asp:Label ID="lblWarehouseDestination" runat="server" Text='<%# Eval("Destination") %>'>
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
                PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="btnClose2">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="85%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose2" runat="server" ImageUrl="../images/closebtnCircle.png"
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
                        <%--<table class="table mainGridTable table-sm">
    <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInShop" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True">
        <Columns>
         <asp:TemplateField HeaderText="PO No" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONumber") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="5%" />
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
                          <asp:TemplateField HeaderText="Issue Date" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("IssueDate","{0:MM/dd/yyyy}") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle Width="10%" />
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
                            </table>--%>
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
                                            <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("DestWarehouse") %>'>
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

            <asp:ModalPopupExtender ID="ModalPopupExtenderShowParts" runat="server" TargetControlID="LinkButton3"
                PopupControlID="PanelShowParts" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PanelShowParts" runat="server" CssClass="ReportsModalPopup" Style="display: none;" Width="85%" Height="95%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton1" runat="server" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" OnClick="ImageButton1_Click" />
                    <div class="overflow-auto h-100">
                        <div class="col-12" style="position: sticky; top: 0; z-index: 107; background: white; padding: 10px;">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <asp:Button ID="btnAddParts" CssClass="btn btn-success btn-sm" CausesValidation="false" runat="server" Text="Add Parts" OnClick="btnAddParts_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive" style="position: sticky; width: 100%; height: 100%; overflow-y: auto;">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvShowParts" runat="server" AutoGenerateColumns="False" DataKeyNames="Partid"
                                EnableModelValidation="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Part No" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPartNo" runat="server" Text='<%# Eval("Partnumber") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Part Description" HeaderStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPartDesc" runat="server" Text='<%# Eval("PartDesc") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="25%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Code" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductCode" runat="server" Text='<%# Eval("ProductCode") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Source" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSource" runat="server" Text='<%# Eval("Source") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Department") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UM" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUM" runat="server" Text='<%# Eval("UM") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Min" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMin" runat="server" Text='<%# Eval("MinQty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Max" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMax" runat="server" Text='<%# Eval("MaxQty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stock In Hand" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStockInHand" runat="server" Text='<%# Eval("StockInHand") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("PartQty") %>' CssClass="form-control form-control-sm text-right" onkeypress="return onlyNumbers(event);" autocomplete="off" MaxLength="5">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>


            <asp:ModalPopupExtender ID="ModalPopupStockIn" runat="server" TargetControlID="LinkButton4"
                PopupControlID="PanelStockIn" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PanelStockIn" runat="server" CssClass="ReportsModalPopup" Style="display: none;" Width="80%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton2" runat="server" ImageUrl="../images/closebtnCircle.png"
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
                                            <asp:Label ID="lblInStockPartNumber" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <table class="table mainGridTable table-sm">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvInsTock" runat="server" AutoGenerateColumns="false"
                                EnableModelValidation="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="WareHouse Name" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWareHouseName" runat="server" Text='<%# Eval("WarehouseName") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stock In Hand" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStockInHand" runat="server" Text='<%# Eval("StockInHand") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </table>
                    </div>
                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>

            <script type="text/javascript">

                function ShowPoup() {
                    jQuery.noConflict();
                    $('#RequisitionShowParts').modal('show');
                    HideBlackOverlay();
                }

                function HideBlackOverlay() {
                    $('#RequisitionShowParts').on('hidden.bs.modal', function () {
                        $('.modal-backdrop').remove(); // Removes the overlay
                    });
                }



                function Message() {
                    var ReOrderqty = null;
                    var InTransitqty = document.getElementById('<%=lblInTransit.ClientID%>').text;
                        var Orderqty = document.getElementById('<%=txtfooterqty.ClientID%>').value;
                        if (document.getElementById('<%=HfReOrder.ClientID%>').value != "-1") {
                            ReOrderqty = document.getElementById('<%=HfReOrder.ClientID%>').value;
                        }

                        if (Orderqty < InTransitqty && InTransitqty > 0) {
                            var message = "You may not enter Order Quantity less than In Transit Quantity.If enter Click Yes to Proceed !!";
                            Alert(message);
                        }
                        else if (Orderqty > ReOrderqty && ReOrderqty > 0) {
                            var message = "You may not enter Order Quanity more than Re-Order Quantity.If enter Click Yes to Proceed !!";
                            Alert(message);
                        }

                    }


                    function Alert(message) {
                        var confirmBox = document.createElement("div");
                        confirmBox.classList.add('confirm-box');

                        var messageBox = document.createElement("div");
                        messageBox.classList.add("message-box");
                        messageBox.textContent = message;
                        confirmBox.appendChild(messageBox);

                        var buttonBox = document.createElement("div");
                        buttonBox.classList.add("button-box");
                        messageBox.appendChild(buttonBox);

                        var yesButton = document.createElement("button");
                        yesButton.classList.add("yes-button");
                        yesButton.textContent = "Yes";
                        buttonBox.appendChild(yesButton);
                        yesButton.addEventListener('click', YesButtonClick);

                        var noButton = document.createElement("button");
                        noButton.classList.add("no-button");
                        noButton.textContent = "No";
                        buttonBox.appendChild(noButton);
                        noButton.addEventListener('click', NoButtonClick);

                        function removeConfirmBox() {
                            document.body.removeChild(confirmBox);
                        }

                        function YesButtonClick() {
                            removeConfirmBox();
                        }

                        function NoButtonClick() {
                            removeConfirmBox();
                        }

                        document.body.appendChild(confirmBox);
                    }

                    function AlertCheckStatus(event) {
                        var indexstatus = document.getElementById('<%=ddlReqStatus.ClientID%>');
                        var status = indexstatus.options[indexstatus.selectedIndex].text;
                        var indexReqNo = document.getElementById('<%=ddlReq.ClientID%>');
                        if (indexReqNo.value != "" && indexReqNo.value != "0") {
                            var ReqNo = indexReqNo.options[indexReqNo.selectedIndex].text;
                        }
                        else {
                            var ReqNo = document.getElementById('<%=txtReqNo.ClientID%>').value;
                        }
                        var indexAppBy = document.getElementById('<%=ddlApprovedby.ClientID%>');
                        var AppBy = indexAppBy.options[indexAppBy.selectedIndex].text;
                        if ((status == "Submitted for review" || status == "Approved") && AppBy == "Select") {
                            Alert("Please Select Approved By First !!");
                            return;
                        }
                        if (status == "Submitted for review" || status == "Cancelled" || status == "Rejected" || status == "On hold" || status == "Approved") {
                            if (status == "Submitted for review") {
                                var message = "You are going to submit " + ReqNo + " for Review.This will sent an email with requisition as attachment to " + AppBy + ". Are you sure to send it?";
                            }
                            if (status == "Approved") {
                                var message = "You are going to Approve " + ReqNo + " for final Submission. Are you sure to approve it?";
                            }
                            if (status == "Cancelled" || status == "Rejected" || status == "On hold") {
                                var message = "You are going to submit " + ReqNo + " for Review.        This will send an email with the requisition as an attachment to        the Purchasing Department. Are you sure to send it?";
                            }

                            var confirmBox = document.createElement("div");
                            confirmBox.classList.add('confirm-box');

                            var messageBox = document.createElement("div");
                            messageBox.classList.add("message-box");
                            messageBox.textContent = message;
                            confirmBox.appendChild(messageBox);

                            var buttonBox = document.createElement("div");
                            buttonBox.classList.add("button-box");
                            messageBox.appendChild(buttonBox);

                            var yesButton = document.createElement("button");
                            yesButton.classList.add("yes-button");
                            yesButton.textContent = "Yes";
                            buttonBox.appendChild(yesButton);
                            yesButton.addEventListener('click', YesButtonClick);

                            var noButton = document.createElement("button");
                            noButton.classList.add("no-button");
                            noButton.textContent = "No";
                            buttonBox.appendChild(noButton);
                            noButton.addEventListener('click', NoButtonClick);

                            function removeConfirmBox() {
                                document.body.removeChild(confirmBox);
                            }

                            function YesButtonClick() {
                                removeConfirmBox();
                                document.getElementById('<%=hiddenBtnYes.ClientID%>').click();
                                }

                                function NoButtonClick() {
                                    removeConfirmBox();
                                    document.getElementById('<%=hiddenBtnNo.ClientID%>').click();
                                }

                                document.body.appendChild(confirmBox);
                            }
                        }




                        function isIntegerKey(event) {
                            const char = String.fromCharCode(event.which); // Get the character from the event
                            // Allow backspace (key code 8), delete (key code 46), and digits (0-9)
                            if (!/^[0-9]$/.test(char) && event.which !== 8) {
                                event.preventDefault(); // Prevent the input if it's not a digit or allowed key
                            }
                        }



                        jQuery(document).ready(function () {
                            (function ($) {
                                Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);

                                function PageLoaded(sender, args) {
                                    BindDrp();
                                }

                                $.when.apply($, PageLoaded).then(function () {
                                    BindDrp();
                                });

                                function BindDrp() {
                                    $('#<%=ddlReq.ClientID%>').chosen();
                                $('#<%=ddlPreparedby.ClientID%>').chosen();
                                $('#<%=ddlApprovedby.ClientID%>').chosen();
                                $('#<%=ddlfooterpartinfo.ClientID%>').chosen();
                                $('#<%=ddlfooterpartno.ClientID%>').chosen();
                                $('#<%=ddlPreparedByList.ClientID%>').chosen();
                                $('#<%=ddlOrderType.ClientID%>').chosen();
                                $('#<%=ddlShipBy.ClientID%>').chosen();
                                $('#<%=ddlRequestor.ClientID%>').chosen();
                                $('#<%=ddlReqStatus.ClientID%>').chosen();
                            }
                        })(jQuery);
                  });

                    window.addEventListener('resize', function () {
                        var panel = document.getElementById('<%= PanelShowParts.ClientID %>'); // Access the ASP.NET Panel
                        var scrollableContent = panel.querySelector('.overflow-auto');
                        var stickyHeight = panel.querySelector('.position-sticky').offsetHeight;

                        // Adjust height dynamically
                        scrollableContent.style.height = (panel.offsetHeight - stickyHeight) + 'px';
                        var tableContainer = panel.querySelector('.table-responsive');

                        // Calculate the height based on panel dimensions
                        var panelHeight = panel.offsetHeight;
                        var availableHeight = panelHeight - 20; // Adjust for padding/margin as needed

                        // Apply the height dynamically
                        tableContainer.style.height = availableHeight + 'px';
                        tableContainer.style.overflowY = 'auto'; // Ensure only one vertical scrollbar appears
                    });
            </script>
            <asp:HiddenField ID="hfpartid" runat="server" />
            <asp:HiddenField ID="HfReqID" runat="server" Value="-1" />
            <asp:HiddenField ID="HfReqDetailID" runat="server" Value="-1" />
            <asp:HiddenField ID="HfChekStatus" runat="server" Value="-1" />
            <asp:HiddenField ID="HfReOrder" runat="server" Value="-1" />
            <asp:HiddenField ID="HfEmployeeID" runat="server" Value="-1" />
            <asp:HiddenField ID="HfReqStatus" runat="server" Value="-1" />
            <asp:HiddenField ID="HfEngDepID" runat="server" Value="-1" />
            <asp:HiddenField ID="HfCheckDuplicateParts" runat="server" Value="-1" />
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
