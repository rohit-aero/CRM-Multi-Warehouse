<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmProjects.aspx.cs" Inherits="SalesManagement_FrmProjects" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_Projects" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Projects" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Project Information
                            <%--  <span id="spn" visible="false" runat="server" style="background:#ffff; padding: .1rem 1rem; font-size: 1.2rem;border: 1px solid #0b5fa1;">  --%>
                                <asp:Label ID="lblPM" Visible="false" CssClass="btn btn-primary btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblConsultantRep" Visible="false" CssClass="btn btn-info btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblOrgRep" Visible="false" CssClass="btn btn-secondary btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblDesRep" Visible="false" CssClass="btn btn-success btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblConsultant" Visible="false" CssClass="btn btn-info btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <%--<asp:Label ID="lblDealer"  Visible="false" CssClass="btn btn-info btn-sm" style="cursor:no-drop;" runat="server" Text=""></asp:Label>--%>
                                <%--</span>--%>
                            </h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm mb-3" Text="Look Up Another Project" Visible="false" OnClick="btnCancel_Click" OnClientClick="RemoveQueryString()" />
                            <asp:Label CssClass="alert alert-danger d-block mx-1 py-1" ID="lblMessage" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-auto">
                                        <label class="mb-0">Project</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>--%>
                                        <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                        </asp:Panel>
                                        <asp:Panel ID="PanelPName" runat="server" DefaultButton="SearchPNameButton">
                                            <asp:TextBox ID="txtSearchPName" AutoComplete="off" placeholder="Type Job Name" CssClass="form-control form-control-sm" OnBlur="return ClickEventForPName(event)" runat="server">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchPName"
                                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProject" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPName_TextChanged" />
                                        </asp:Panel>
                                        <%--</ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-auto">
                                        <label class="mb-0">Job ID</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Panel ID="Panel1" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                        </asp:Panel>
                                        <asp:Panel ID="PanelJNum" runat="server" DefaultButton="SearchJNumberButton">
                                            <asp:TextBox ID="txtSearchPNum" AutoComplete="off" placeholder="Type Job Number" CssClass="form-control form-control-sm" OnBlur="return ClickEvent(event)" runat="server">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchPNum"
                                                CompletionInterval="3" CompletionSetCount="10" MinimumPrefixLength="3" CompletionListElementID="PNumber"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProjectNumber" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchJNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPNum_TextChanged" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12 mt-3">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm mb-3" OnClick="btnNew_Click" Text="New Project" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm mb-3" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-secondary btn-sm mb-3" Visible="false" OnClick="btnSearch_Click" Text="Search Project" />
                                <asp:Button ID="btnProjectsEng" runat="server" CssClass="btn btn-secondary btn-sm mb-3" OnClick="btnProjectsEng_Click" Text="Project Eng" />
                                <asp:Button ID="btnShipping" runat="server" CssClass="btn btn-secondary btn-sm mb-3" Enabled="false" OnClick="btnShipping_Click" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" Text="Generate Shipping Form" />

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row bg-white shadow-sm border-bottom">
                    <div class="col">
                        <ul class="nav nav-tabs customTabs" id="myTab" role="tablist">
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link active" id="gi-tab" data-toggle="tab" href="#giTab" role="tab" aria-controls="home" aria-selected="true"><span>General Information <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="ot-tab" data-toggle="tab" href="#otTab" role="tab" aria-controls="other" aria-selected="false"><span>Project Coordination<i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="si-tab" data-toggle="tab" href="#siTab" role="tab" aria-controls="shipping" aria-selected="false"><span>Shipping & Installation<i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="ics-tab" data-toggle="tab" href="#icsTab" role="tab" aria-controls="profile" aria-selected="false"><span>Invoice & Commission <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active pt-2" id="giTab" role="tabpanel" aria-labelledby="home-tab">
                        <div class="row">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Basic Info</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label class="text-danger">Job ID*</label>
                                    <asp:TextBox ID="txtJobId" runat="server" Enabled="false" MaxLength="50" AutoComplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Proposal #*</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:Panel ID="PNumber" runat="server" CssClass="form-control form-control-sm" Style="height: 200px; overflow: scroll; display: none;"></asp:Panel>
                                        <%--<asp:DropDownList ID="ddlPNumber" CssClass="form-control" runat="server" DataTextField="ProposalID" DataValueField="ProposalID" AutoPostBack="True" OnSelectedIndexChanged="ddlPNumber_SelectedIndexChanged"></asp:DropDownList>--%>
                                        <div class="col-sm chosenFullWidth pl-0">
                                            <asp:Panel ID="Panel_PNumber" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                            </asp:Panel>
                                            <asp:Panel ID="Panel_PNumberAutoComplete" runat="server" DefaultButton="Customer_AutoCompleteButton">
                                                <asp:TextBox ID="txtPNumber" AutoComplete="off" placeholder="Type Proposal #" CssClass="form-control form-control-sm" OnBlur="return ClickEventForPNumber(event)" runat="server">
                                                </asp:TextBox>
                                                <asp:AutoCompleteExtender ID="PNumber_AutoComplete" runat="server" TargetControlID="txtPNumber"
                                                    CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="Panel_PNumber"
                                                    ServicePath="../AutoComplete.asmx" ServiceMethod="SearchPNumberOnly" CompletionListCssClass="autocomplete" />
                                                <asp:Button ID="btnPNumber_AutoComplete" runat="server" Text="Submit" Style="display: none" OnClick="ddlPNumber_SelectedIndexChanged" />
                                            </asp:Panel>
                                        </div>

                                        <div class="input-group-prepend p-1">
                                            <asp:ImageButton ID="ImgPNumber" runat="server" Height="20px" ImageUrl="~/images/goto.png" OnClick="ImgPNumber_Click" Width="20px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>OA Sent To</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOASentTo" runat="server" DataTextField="Company" DataValueField="Company"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Job Order Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtJobOrderDate" AutoComplete="off" Enabled="false" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtJobOrderDate" TargetControlID="txtJobOrderDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Order Ack Sent Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrderAckDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)" AutoPostBack="true" OnTextChanged="txtOrderAckDate_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtOrderAckDate" TargetControlID="txtOrderAckDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>OA Dispatch Date (HO)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtOADispatch" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtOADispatch" TargetControlID="txtOADispatch"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Project Status*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlprojectstatus" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem Value="0">Active</asp:ListItem>
                                        <asp:ListItem Value="1">Confirmed</asp:ListItem>
                                        <asp:ListItem Value="2">Cancelled</asp:ListItem>
                                        <asp:ListItem Value="3">On Hold</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label id="lblProjectManager" runat="server" class="text-danger">Project Manager*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectManager" DataTextField="EmployeeName" DataValueField="EmployeeID" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Purchased Items CAD</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPurchasedItemsCAD" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="N">Not Req.</asp:ListItem>
                                        <asp:ListItem Value="Y">Req</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center" id="divInr" runat="server">
                                        <div class="input-group-prepend pr-3">Invoice Not Required</div>
                                        <asp:CheckBox ID="chkInvoiceNotRequired" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">General Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Customer*</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <%--<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCustomer" runat="server" DataTextField="CompanyName" DataValueField="CustomerID" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList>--%>
                                        <div class="col-sm chosenFullWidth pl-0">
                                            <asp:Panel ID="Panel_Customer" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                            </asp:Panel>
                                            <asp:Panel ID="Panel_Customer_1" runat="server" DefaultButton="Customer_AutoCompleteButton">
                                                <asp:TextBox ID="txtCustomer" AutoComplete="off" placeholder="Type Customer Name" CssClass="form-control form-control-sm" OnBlur="return ClickEventForCustomer(event)" runat="server">
                                                </asp:TextBox>
                                                <asp:AutoCompleteExtender ID="Customer_AutoCompleteExtender" runat="server" TargetControlID="txtCustomer"
                                                    CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="Panel_Customer"
                                                    ServicePath="../AutoComplete.asmx" ServiceMethod="SearchCustomer" CompletionListCssClass="autocomplete" />
                                                <asp:Button ID="Customer_AutoCompleteButton" runat="server" Text="Submit" Style="display: none" OnClick="ddlCustomer_SelectedIndexChanged" />
                                            </asp:Panel>
                                        </div>

                                        <div class="input-group-prepend pl-1">
                                            <asp:ImageButton ID="lnkRedirecttoCustomer" runat="server" Height="20px" ImageUrl="~/images/goto.png" OnClick="lnkRedirecttoCustomer_Click" Width="20px" />
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel">Customer Information</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <th>Company Name:</th>
                                                                <td>
                                                                    <span id="lblCustCompanyName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Street Address:</th>
                                                                <td>
                                                                    <span id="lblCustStreetAddress"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>City:</th>
                                                                <td>
                                                                    <span id="lblCustCity"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Country:</th>
                                                                <td>
                                                                    <span id="lblCustCountry"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>State:</th>
                                                                <td>
                                                                    <span id="lblCustState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Toll Free:</th>
                                                                <td>
                                                                    <span id="lblCustTollFree"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Toll Fax:</th>
                                                                <td>
                                                                    <span id="lblCustTollFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Main Phone:</th>
                                                                <td>
                                                                    <span id="lblCustMainPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Main Fax:</th>
                                                                <td>
                                                                    <span id="lblCustMainFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Service Rep Name:</th>
                                                                <td>
                                                                    <span id="lblCustServiceRep"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Sales:</th>
                                                                <td>
                                                                    <span id="lblCustSales"></span>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>PO Number</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" MaxLength="100" ID="txtPONumber" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>PO Rec. Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtPoRecDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender27" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtPoRecDate" TargetControlID="txtPoRecDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Quote</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtQuote" MaxLength="15" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group srRadiosBtns">
                                    <label>Order For</label>
                                    <asp:RadioButtonList ID="rdbOrderFor" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">Aerowerks</asp:ListItem>
                                        <asp:ListItem Value="2">TragenFlex</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Consultant Rep</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConsultantRep" runat="server" DataTextField="TSM" DataValueField="RepID" onchange="GetConsultantRep();"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <button runat="server" data-toggle="modal" data-target="#dialog3" onclick="GetConsultantRepDetails()" class="btn border-0 p-0" clientidmode="Static" type="button"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog3" tabindex="-1" aria-labelledby="exampleModalLabel3" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel3">Consultant Rep Information</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <th>Name:</th>
                                                                <td>
                                                                    <span id="lblFirstName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Abbreviation:</th>
                                                                <td>
                                                                    <span id="lblAbb"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>State:</th>
                                                                <td>
                                                                    <span id="lblRepState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Phone Mail:</th>
                                                                <td>
                                                                    <span id="lblPhoneMail"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Phone:</th>
                                                                <td>
                                                                    <span id="lblPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Cell Phone:</th>
                                                                <td>
                                                                    <span id="lblCellPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Fax:</th>
                                                                <td>
                                                                    <span id="lblFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Email:</th>
                                                                <td>
                                                                    <a id="lblEmail"></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Status:</th>
                                                                <td>
                                                                    <span id="lblStatus"></span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Origination Rep</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlOrgRep" DataValueField="RepID" DataTextField="TSM" runat="server"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <button runat="server" data-toggle="modal" data-target="#dialog4" onclick="GetOriginationRepDetails()" class="btn borde-0 p-0" clientidmode="Static" type="button"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog4" tabindex="-1" aria-labelledby="exampleModalLabel4" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel4">Origination Rep Information</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <th>Name:</th>
                                                                <td>
                                                                    <span id="lblOrigFirstName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Abbreviation:</th>
                                                                <td>
                                                                    <span id="lblOrigAbb"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>State:</th>
                                                                <td>
                                                                    <span id="lblOrigState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Phone Mail:</th>
                                                                <td>
                                                                    <span id="lblOrigPhoneMail"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Phone:</th>
                                                                <td>
                                                                    <span id="lblOrigPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Cell Phone:</th>
                                                                <td>
                                                                    <span id="lblOrigCellPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Fax:</th>
                                                                <td>
                                                                    <span id="lblOrigFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Email:</th>
                                                                <td>
                                                                    <a id="lblOrigEmail"></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Status:</th>
                                                                <td>
                                                                    <span id="lblOrigStatus"></span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Destination Rep</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="TSM" DataValueField="RepID" ID="ddlDesRep" runat="server"></asp:DropDownList>
                                        <div class="input-group-prepend pl-1">
                                            <button type="button" data-toggle="modal" data-target="#dialog5" onclick="GetDestinationRepDetails()" class="btn borer-0 p-0" clientidmode="Static" runat="server"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog5" tabindex="-1" aria-labelledby="exampleModalLabel5" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel5">Destination Rep Information</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <th>Name:</th>
                                                                <td>
                                                                    <span id="lblDestFirstName"></span>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <th>Abbreviation:</td>
                                                    <td>
                                                        <span id="lblDestAbb"></span>
                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <th>State:</th>
                                                                <td>
                                                                    <span id="lblDestState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Phone Mail:</th>
                                                                <td>
                                                                    <span id="lblDestPhoneMail"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Phone:</th>
                                                                <td>
                                                                    <span id="lblDestPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Cell Phone:</th>
                                                                <td>
                                                                    <span id="lblDestCellPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Fax:</th>
                                                                <td>
                                                                    <span id="lblDestFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Email:</th>
                                                                <td>
                                                                    <a id="lblDestEmail"></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Status:</th>
                                                                <td>
                                                                    <span id="lblDestStatus"></span>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" id="giGeneralInformation" runat="server">
                                <div class="form-group chosenFullWidth">
                                    <label>Dealer</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm paymentSection" ID="ddlDealer" runat="server" DataTextField="CompanyName" DataValueField="DealerID" AutoPostBack="True" OnSelectedIndexChanged="ddlDealer_SelectedIndexChanged"></asp:DropDownList>
                                        <div class="input-group-prepend pl-1">
                                            <button type="button" data-toggle="modal" data-target="#dialog2" onclick="GetDealerDetails()" class="btn border-0 p-0" clientidmode="Static" runat="server"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog2" tabindex="-1" aria-labelledby="exampleModalLabel2" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel2">Dealer Information</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <th>FederalID:</th>
                                                                <td>
                                                                    <span id="lblFederalID"></span>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <th>Company Name:</th>
                                                                <td>
                                                                    <span id="lblCompanyName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Group Name:</th>
                                                                <td>
                                                                    <span id="lblGroupName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Street Address:</th>
                                                                <td>
                                                                    <span id="lblStreetAddress"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>City:</th>
                                                                <td>
                                                                    <span id="lblCity"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Country:</th>
                                                                <td>
                                                                    <span id="lblCountry"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>State:</th>
                                                                <td>
                                                                    <span id="lblState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Toll Free:</th>
                                                                <td>
                                                                    <span id="lblTollFree"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Toll Fax:</th>
                                                                <td>
                                                                    <span id="lblTollFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Phone:</th>
                                                                <td>
                                                                    <span id="lblDealerPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Fax:</th>
                                                                <td>
                                                                    <span id="lblDealerFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Rep Name:</th>
                                                                <td>
                                                                    <span id="lblDealerRepName"></span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Consultant</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConsultant" runat="server" DataTextField="CompanyName" DataValueField="ConsultantID" onchange="GetConsultant()"></asp:DropDownList>
                                        <div class="input-group-prepend pl-1">
                                            <button type="button" data-toggle="modal" data-target="#dialog1" onclick="GetConsultantDetails()" class="btn border-0 p-0" clientidmode="Static" runat="server"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog1" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel1">Consultant Information</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <th>Company Name:</th>
                                                                <td>
                                                                    <span id="lblConsultantCompName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Street Address</th>
                                                                <td>
                                                                    <span id="lblConsultantStreetAdd"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>City:</th>
                                                                <td>
                                                                    <span id="lblConsultantCity"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Country:</th>
                                                                <td>
                                                                    <span id="lblConsultantCountry"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text">State:</td>
                                                                <td>
                                                                    <span id="lblConsultantState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Phone:</th>
                                                                <td>
                                                                    <span id="lblConsultantPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Toll Free:</th>
                                                                <td>
                                                                    <span id="lblConsultantTollFree"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Fax:</th>
                                                                <td>
                                                                    <span id="lblConsultantFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Toll Fax:</th>
                                                                <td>
                                                                    <span id="lblConsultantTollFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Rep Name:</th>
                                                                <td>
                                                                    <span id="lblConsultantRepName"></span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Sales Source</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesSource" runat="server" Enabled="false" DataTextField="SalesSource" DataValueField="SalesSourceID"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row border-top pt-3">
                            <div class="col-sm-12 d-flex align-center">
                                <h5 class="text-uppercase">Spec Credit Info</h5>
                                <div class="ml-auto">
                                    <button type="button" id="btnClearSpec" class="btn btn-outline-primary btn-sm" onclick="ClearSpecCredit()"><i class="fas fa-redo-alt"></i>Reset</button>
                                </div>

                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group srRadiosBtns">
                                    <label>Spec Credit</label>
                                    <asp:RadioButtonList ID="rdbSpecCredit" runat="server" RepeatDirection="Horizontal" onchange="getCheckedRadio()" Enabled="false">
                                        <asp:ListItem Value="1">Not Approved</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Pending</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Spec Credit(%)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Percentage" DataValueField="SpecCreditPercentID" onchange="getCheckedRadio()" ID="ddlSpecCredit" Enabled="false" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Spec Credit Amount($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtSpecAmount" Text="0" runat="server" AutoComplete="off" Enabled="false" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Consultant Rep</label>&nbsp;&nbsp;&nbsp;
                                    <br />
                                    <asp:Label ID="txtSpecConsultantRep" runat="server" CssClass="form-control form-control-sm" BackColor="#e9ecef"></asp:Label>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Consultant</label>
                                    <br />
                                    <asp:Label ID="txtSpecConsultant" runat="server" CssClass="form-control form-control-sm" BackColor="#e9ecef"></asp:Label>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Spec Credit Check#</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtSpecCheque" Enabled="false" AutoComplete="off" MaxLength="255" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Spec Credit Paid</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtSpecPaid" AutoComplete="off" Enabled="false" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtSpecPaid" TargetControlID="txtSpecPaid"></asp:CalendarExtender>
                                </div>
                            </div>
                        </div>

                        <div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Sales Opportunity Information</h5>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Sales Opportunity</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesOpportunity" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Expected Sales Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtExpectedSalesDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtExpectedSalesDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtExpectedSalesDate" TargetControlID="txtExpectedSalesDate"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Status</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesOpportunityStatus" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Done</asp:ListItem>
                                        <asp:ListItem Value="2">In Progress</asp:ListItem>
                                        <asp:ListItem Value="3">Cancelled</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-4">
                                <label>&nbsp;</label>
                                <div class="form-group">
                                    <asp:Button ID="btnSalesOpportunityRedirect" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false"
                                        Text="Report" OnClick="btnSalesOpportunityRedirect_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade pt-2" id="icsTab" role="tabpanel" aria-labelledby="profile-tab">
                        <div class="row" id="icsGeneralInformation" runat="server">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">General Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Currency*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm paymentSection" ID="ddlCurrency" runat="server" DataTextField="Currency" DataValueField="CurrencyID"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Equipment Price($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right paymentSection" ID="txtEqPrice" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getPer()"
                                        onkeypress="return onlyDotsAndNumbers(this,event);" AutoPostBack="true" OnTextChanged="txtEqPrice_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Eq Discount%</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right paymentSection" ID="txtEqDiscount" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();" onkeypress="return onlyDotsAndNumbers(this,event);" AutoPostBack="true" OnTextChanged="txtEqPrice_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Eq Dis Amount($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right paymentSection" ID="txtEqDisAmount" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getPer()" onkeypress="return onlyDotsAndNumbers(this,event);" AutoPostBack="true" OnTextChanged="txtEqPrice_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Net Eq Price($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtNetEqPrice" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getCheckedRadio();" Enabled="false" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Freight($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right paymentSection" ID="txtFreight" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getPer()" onkeypress="return onlyDotsAndNumbers(this,event);" AutoPostBack="true" OnTextChanged="txtFreightAndInstallation_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Installation($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right paymentSection" ID="txtInstall" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getPer()" onkeypress="return onlyDotsAndNumbers(this,event);" AutoPostBack="true" OnTextChanged="txtFreightAndInstallation_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Ex Warranty Price($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right paymentSection" ID="txtExWarranty" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getPer()" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-1">
                                <div class="form-group">
                                    <label>NetAmount($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtNetAmount" MaxLength="15" AutoComplete="off" Text="0" runat="server" onkeyup="javascript:this.value=Comma(this.value);" Enabled="false" onchange="getCalc();getPer()" AutoCompleteType="Disabled" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-1">
                                <div class="form-group">
                                    <label>HST($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtHST" MaxLength="15" AutoComplete="off" Text="0" runat="server" Enabled="false" onkeyup="javascript:this.value=Comma(this.value);" onchange="getCalc();getPer()" AutoCompleteType="Disabled" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Total Amount($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtTotalAmount" MaxLength="15" AutoComplete="off" Text="0" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" Enabled="false" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Invoice Number</label>
                                    <asp:TextBox CssClass="form-control form-control-sm paymentSection" ID="txtinvnumber" Enabled="false" MaxLength="15" AutoComplete="off" AutoCompleteType="Disabled" runat="server" AutoPostBack="true" OnTextChanged="txtinvnumber_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Invoice Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm paymentSection" ID="txtInvodate" AutoComplete="off" Enabled="false" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender18" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtInvodate" TargetControlID="txtInvodate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">FOB*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm paymentSection" ID="ddlFOB" runat="server" DataTextField="type" DataValueField="fobId"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Term*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm paymentSection" ID="ddlTerm" runat="server" DataTextField="type" DataValueField="termId"></asp:DropDownList></td>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm paymentSection" ID="ddlProjectReviewedBy" runat="server" DataTextField="Employee" DataValueField="EmployeeID"></asp:DropDownList></td>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm paymentSection" ID="txtProjectReviewedDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtReviewedDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProjectReviewedDate" TargetControlID="txtProjectReviewedDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div class=" text-danger input-group-prepend pr-3">Updated on Visual*</div>
                                        <asp:CheckBox ID="chkUpdatedOnVisual" runat="server" CssClass="paymentSection" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div class=" text-danger input-group-prepend pr-3">Confirmed From Gover*</div>
                                        <asp:CheckBox ID="chkConfirmedFromGover" runat="server" CssClass="paymentSection" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-6">
                                <div class="form-group">
                                    <label>Reason For Price Update</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtReasonForPriceUpdate" AutoComplete="off" runat="server" TextMode="MultiLine" Enabled="false"
                                        oninput="return limitMultiLineInputLength(this, 500)"></asp:TextBox>
                                </div>
                            </div>


                        </div>

                        <div class="row border-top pt-3" id="icsEarlyPaymentCashDiscount_1" runat="server">
                            <div class="col-12">
                                <h5 class="text-uppercase">Early Payment Cash Discount</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Received</label>
                                    <asp:TextBox CssClass="form-control form-control-sm paymentSection" ID="txtDateReceived" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender20" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateReceived" TargetControlID="txtDateReceived"></asp:CalendarExtender>
                                </div>
                            </div>
                        </div>

                        <div class="row pt-3" id="icsEarlyPaymentCashDiscount_2" runat="server">
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Total Amount Invoiced ($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtAmountInvoiced" onkeypress="return onlyDotsAndNumbers(this,event);" AutoComplete="off" MaxLength="15" Enabled="false" AutoPostBack="true" runat="server" OnTextChanged="txtAmountInvoiced_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label title="Net Eq Price($) - Discount Percentage (%)">Discount Amount ($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right paymentSection" ID="txtCashDiscountAmount" onkeypress="return onlyDotsAndNumbers(this,event);" AutoComplete="off" MaxLength="15" AutoPostBack="true" runat="server" OnTextChanged="txtCashDiscountAmount_TextChanged"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Discount Percentage (%)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right paymentSection" ID="txtCashDiscountPer" onkeypress="return onlyDotsAndNumbers(this,event);" AutoComplete="off" MaxLength="15" runat="server" AutoPostBack="True" OnTextChanged="txtCashDiscountPer_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Total Amount Received ($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtTAmountRec" AutoComplete="off" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label class="text-truncate d-block" title="Rebatable Amount for Hobart Commission">Rebatable Amount for Hobart Commission</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtAmountForComision" AutoComplete="off" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row border-top pt-3" id="icsProjectCommissionInfo" runat="server">
                            <div class="col-12 mb-3">
                                <h5 class="text-uppercase mb-0">Project Commission Info</h5>
                            </div>
                            <%--onchange="CalculateCommission()"--%>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Rate %*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm paymentSection" ID="ddlRate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRate_SelectedIndexChanged" DataTextField="CommissionType" DataValueField="CommissionType"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Amount($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtCommAmount" AutoComplete="off" runat="server" MaxLength="15" Enabled="false" Text="0" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Net Commission</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtNetRateCommission" AutoComplete="off" runat="server" MaxLength="15" Enabled="false" Text="0" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Cheque #</label>
                                    <asp:TextBox CssClass="form-control form-control-sm paymentSection" ID="txtCommCheque" MaxLength="15" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Paid</label>
                                    <asp:TextBox CssClass="form-control form-control-sm paymentSection" ID="txtCommDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender21" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtCommDate" TargetControlID="txtCommDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Project Commission Notes</label>
                                    <asp:TextBox CssClass="form-control form-control-sm paymentSection" ID="txtProjectCommNotes" AutoComplete="off" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade pt-2" id="siTab" role="tabpanel" aria-labelledby="shipping-tab">
                        <div class="row">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Date (Before Shipped)</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Released</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtReleased" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReleased" TargetControlID="txtReleased"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Built Dwgs Sent</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateBuiltDrgsSent" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateBuiltDrgsSent" TargetControlID="txtDateBuiltDrgsSent"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Estimated Completion</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtEstimatedCom" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender10" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtEstimatedCom" TargetControlID="txtEstimatedCom"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Actual Completion</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtActualCom" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender11" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtActualCom" TargetControlID="txtActualCom"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Test Run</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtTestRun" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender12" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtTestRun" TargetControlID="txtTestRun"></asp:CalendarExtender>
                                </div>
                            </div>
                        </div>

                        <div class="row border-top pt-2">
                            <div class="col-12 mb-3">
                                <h5 class="text-uppercase mb-0">Shipping Info</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Shipping Commitment*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShippingComit" runat="server" OnSelectedIndexChanged="ddlShippingComit_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="F">Firm</asp:ListItem>
                                        <asp:ListItem Value="T">Tentative</asp:ListItem>
                                        <asp:ListItem Value="W">Window</asp:ListItem>
                                        <asp:ListItem Value="H">Warehouse</asp:ListItem>
                                        <asp:ListItem Value="S">Ship when ready</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Shipment Status*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShippingStatus" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="S">Shipped</asp:ListItem>
                                        <asp:ListItem Value="N">Not Shipped</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label class="text-danger">Ship Date*</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipDate" AutoPostBack="true" AutoComplete="off" runat="server" Enabled="false"
                                        OnTextChanged="txtShipDate_TextChanged" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender23" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipDate" TargetControlID="txtShipDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label class="text-danger">Ship To Arrive*</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipToArrive" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender24" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipToArrive" TargetControlID="txtShipToArrive"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Delivery Preference</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDeliveryPref" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="1">LTL</asp:ListItem>
                                        <asp:ListItem Value="2">FTL</asp:ListItem>
                                        <asp:ListItem Value="3">Customer Pickup</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Site Contact</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCustomerSiteContact" runat="server" DataTextField="SiteContact" DataValueField="ContactID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Dealer Project Manager</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDealerProjManager" runat="server" DataTextField="DealerProjectManager" DataValueField="ContactID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Arrival Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtArrivalDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender25" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtArrivalDate" TargetControlID="txtArrivalDate"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-12 mb-2">
                                <div class="table-responsive">
                                    <asp:GridView CssClass="table mainGridTable table-sm mb-0" ForeColor="White" ID="gvShipDate" Height="100%" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                                        EnableModelValidation="True" ShowFooter="true" OnRowDeleting="gvShipDate_RowDeleting" OnRowCommand="gvShipDate_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Row#">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNo" runat="server" Text='<%# Eval("RowNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ship Date*">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipDate" runat="server" Text='<%# Eval("ShipDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtShipDate_Footer" class="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"
                                                        AutoComplete="off" Width="100%"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtShipDate_Footer_Extender" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtShipDate_Footer" TargetControlID="txtShipDate_Footer">
                                                    </asp:CalendarExtender>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reason of Delay">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDepartment_Footer" runat="server" DataTextField="text" DataValueField="id">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Comments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtComments_Footer" class="form-control form-control-sm" runat="server"
                                                        AutoComplete="off" Width="100%" MaxLength="500"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Updated By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUpdatedBy" runat="server" Text='<%# Eval("UpdatedBy") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="5%">
                                                <FooterTemplate>
                                                    <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddShipDate" TabIndex="0" runat="server" Text="Add" CommandName="Insert" />
                                                </FooterTemplate>

                                                <ItemTemplate>
                                                    <asp:LinkButton CssClass="btn btn-info btn-danger" ID="LinkButton4" OnClientClick="return confirm('Are you sure to delete. ?');" runat="server" CommandName="delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Shipper Info</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Shipper</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipper" runat="server" DataTextField="CompanyName" DataValueField="ShipperID" AutoPostBack="true" OnSelectedIndexChanged="ddlShipper_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Contact Name</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipperContactName" AutoComplete="off" MaxLength="30" runat="server" AutoPostBack="true" DataValueField="ContactID" Enabled="false"
                                    DataTextField="ContactName" OnSelectedIndexChanged="ddlShipperContactName_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Contact Person Phone</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipperPhone" Enabled="false" onblur="phoneMask(this)" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipperEmail" Enabled="false" onblur="emailMask(this)" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Tracking No</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipperTrackingNo" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Pickup Time from Shop</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipperPickupFromShop" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group srRadiosBtns">
                                    <label>Shipped via</label>
                                    <asp:RadioButtonList ID="rdbShippedVia" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="L">LTL</asp:ListItem>
                                        <asp:ListItem Value="F">FTL</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Actual Shipping Cost</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtActualShippingCost" MaxLength="15" AutoComplete="off"
                                        runat="server" onkeyup="javascript:this.value=Comma(this.value);" onblur="limitToTwoDecimalPlaces(this)" onkeypress="return onlyDotsAndNumbers(this,event);" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Additional Charges</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtAdditionalCharges" MaxLength="15" AutoComplete="off"
                                        runat="server" onkeyup="javascript:this.value=Comma(this.value);" onblur="limitToTwoDecimalPlaces(this)" onkeypress="return onlyDotsAndNumbers(this,event);" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-6 col-lg-4">
                                <div class="form-group">
                                    <label>Notes</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipperNotes" autocomplete="off" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row border-top pt-3">
                            <div class="col-12 mb-3">
                                <h5 class="text-uppercase mb-0">Receiver Info</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Company</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompany" AutoComplete="off" MaxLength="50" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Country</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlcountry" runat="server" DataTextField="Country" DataValueField="CountryID" AutoPostBack="true" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>State</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="State" DataValueField="State"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>City</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" autocomplete="off" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Zip Code</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtZip" autocomplete="off" MaxLength="10" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Contact Person Name</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtContactPerson" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Contact Person Phone</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" onblur="phoneMask(this)" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" onblur="emailMask(this)" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Date (After Shipped)</h5>
                            </div>
                            <div class="col-3 col-sm-2 col-md-2 col-lg-2">
                                <div class="form-group">
                                    <label>Installation By</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallationBy" runat="server" DataTextField="Desc" DataValueField="InstallationByID" OnSelectedIndexChanged="ddlInstallationBy_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <div class="input-group-prepend pl-1" id="divddlInstallerA" runat="server" visible="false">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallerA" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Installation Priority</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallationPriority" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="H">High</asp:ListItem>
                                        <asp:ListItem Value="M">Medium</asp:ListItem>
                                        <asp:ListItem Value="L">Low</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-2" runat="server" visible="true" id="divInstallationCommitment">
                                <div class="form-group chosenFullWidth">
                                    <label>Installation Commitment</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallationCommitment" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="C">Confirm</asp:ListItem>
                                        <asp:ListItem Value="N">Not Confirm</asp:ListItem>
                                        <asp:ListItem Value="T">Tentative</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label class="mx-2">Technician</label>
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div id="divTechnician" runat="server" visible="true" class="row mx-2">
                                            <div class="form-group">
                                                <asp:Button ID="btnTechnician" runat="server" CssClass="btn btn-primary btn-sm" Text="Add/View" Enabled="false" OnClick="btnTechnician_Click" />
                                                <asp:Label ID="lblSelectedTechnician" runat="server"></asp:Label></h5>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:ModalPopupExtender ID="mdlTechnician" runat="server" TargetControlID="btnTechnicianModal"
                                        PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
                                    </asp:ModalPopupExtender>
                                    <asp:Panel ID="Panel2" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="50%" Height="60%">
                                        <div class="position-relative h-100">
                                            <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                                                AlternateText="Close Popup" ToolTip="Close Popup" />
                                            <div class="overflow-auto h-100">
                                                <div class="col-12">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="form-group">
                                                                <h5 class="text-uppercase text-center">Job #:-
                                                                <asp:Label ID="lblJob" runat="server"></asp:Label></h5>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:CheckBoxList ID="chkTechnician" CssClass="chkNewline" runat="server" JSvalue="id" DataTextField="text" DataValueField="id" RepeatDirection="Vertical" CellPadding="5">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:LinkButton ID="btnTechnicianModal" runat="server"></asp:LinkButton>
                                </div>
                            </div>

                            <div class="col-3 col-sm-2 col-md-2 col-lg-2">
                                <div class="form-group">
                                    <label>Installation Start</label>
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtInstallationStart" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender13" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtInstallationStart" TargetControlID="txtInstallationStart"></asp:CalendarExtender>
                                        <div class="input-group-prepend pl-1" id="divddlInstallerB" runat="server" visible="false">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallerB" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-3 col-sm-2 col-md-2 col-lg-2">
                                <div class="form-group">
                                    <label>Installation End</label>
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtInstallationEnd" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender14" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtInstallationEnd" TargetControlID="txtInstallationEnd"></asp:CalendarExtender>
                                        <div class="input-group-prepend pl-1" id="divddlInstallerC" runat="server" visible="false">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallerC" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Working Hours (Date-Time)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlWorkingHours" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Day Time</asp:ListItem>
                                        <asp:ListItem Value="2">Night Time</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Mon-Fri</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtMontoFriTime" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Sat-Sun Access</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtSatSunTime" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Test Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDemo" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender15" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDemo" TargetControlID="txtDemo"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Warranty Start</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtWarrantyStart" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtWarrantyStart_TextChanged" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender16" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtWarrantyStart" TargetControlID="txtWarrantyStart"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Warranty End</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtWarrantyEnd" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender17" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtWarrantyEnd" TargetControlID="txtWarrantyEnd"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>Follow Up</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFollowUp" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender29" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFollowUp" TargetControlID="txtFollowUp"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Warranty Letter Dispatched</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCarePack" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender30" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtCarePack" TargetControlID="txtCarePack"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Service Manuals Dispatched</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtManualsDisp" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender28" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtManualsDisp" TargetControlID="txtManualsDisp"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Generate Warranty Letter</label>
                                    <asp:Button ID="btnWarrntyLetter" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate" OnClick="btnWarrntyLetter_Click" />
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Test Remarks</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtTestRemarks" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-2">
                                <div class="form-group">
                                    <label>Startup Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtStartupDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtStartupDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtStartupDate" TargetControlID="txtStartupDate"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-lg-3 col-xl-2">
                                <div class="form-group">
                                    <label>Commissioning Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCommissioningDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtCommissioningDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtCommissioningDate" TargetControlID="txtCommissioningDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group srRadiosBtns">
                                    <label>PM Package</label>
                                    <asp:RadioButtonList ID="rdbPM" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes/Prospecting</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label></label>
                                    <asp:Button ID="btnProspecting" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Prospecting" OnClick="btnProspecting_Click" />
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label></label>
                                    <asp:Button ID="btnServiceAgree" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Service Agreement" OnClick="btnServiceAgree_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade p-2" id="otTab" role="tabpanel" aria-labelledby="other-tab">
                        <div class="row pt-2">
                            <div class="col-12 mb-3">
                                <h5 class="text-uppercase mb-0">Project Coordination</h5>
                            </div>

                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group chosenFullWidth">
                                    <label>Shipping Requirements</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShippingRequirements" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="L">Liftgate is required</asp:ListItem>
                                        <asp:ListItem Value="R">Requirements of Crates</asp:ListItem>
                                        <asp:ListItem Value="A">Availability of an unloading dock</asp:ListItem>
                                        <asp:ListItem Value="S">Specific site delivery window</asp:ListItem>
                                        <asp:ListItem Value="C">Customer pickup (who is handling custom paperwork)</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <label>Shipping Requirement Detail</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShippingRequirementDetails" AutoComplete="off"
                                        runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">Manned Fire Watch</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkMannedFireWatch" runat="server" onchange="enableDisable_MFW()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtMannedFireWatch" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">Hot Work Permit</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkHotWorkPermit" runat="server" onchange="enableDisable_HWP()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtHotWorkPermit" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">Canadian Technician Access</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkCanTechAccess" runat="server" onchange="enableDisable_CTA()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtCanTechAccess" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">OSHA</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkOsha" runat="server" onchange="enableDisable_Osha()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtOsha" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">State Certificate</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkStateCertificate" runat="server" onchange="enableDisable_StateCertificate()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtStateCertificate" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">Drug testing certificate</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkDrugTestingCertificate" runat="server" onchange="enableDisable_DrugTestingCertificate()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtDrugTestingCertificate" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">WHMIS</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkWHMIS" runat="server" onchange="enableDisable_WHMIS()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtWHMIS" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">Fall Protection</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkFallProtection" runat="server" onchange="enableDisable_FallProtection()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtFallProtection" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">Medical Certificates</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkMedicalCertificate" runat="server" onchange="enableDisable_MedicalCertificate()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtMedicalCertificate" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-12">Insurance Certificates</label>
                                        <div class="col-auto pr-0">
                                            <div class="form-group size-chkbox">
                                                <asp:CheckBox ID="chkInsuranceCertificate" runat="server" onchange="enableDisable_InsuranceCertificate()" />
                                            </div>
                                        </div>

                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtInsuranceCertificate" AutoComplete="off" Enabled="false"
                                                    runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>



                            <div class="col-12 row" style="display: none;">
                                <div class="col-9">
                                    <div class="form-group chosenFullWidth">
                                        <label>Certificate Requirements</label>
                                        <asp:CheckBoxList ID="chkCertReq" CssClass="chkNewline" runat="server" JSvalue="id" DataTextField="text" DataValueField="id" RepeatDirection="Horizontal" CellPadding="5">
                                            <asp:ListItem Value="O">&nbsp;OSHA</asp:ListItem>
                                            <asp:ListItem Value="S">&nbsp;State Certificate</asp:ListItem>
                                            <asp:ListItem Value="D">&nbsp;Drug testing certificate</asp:ListItem>
                                            <asp:ListItem Value="W">&nbsp;WHMIS</asp:ListItem>
                                            <asp:ListItem Value="F">&nbsp;Fall Protection</asp:ListItem>
                                            <asp:ListItem Value="M">&nbsp;Medical Certificates</asp:ListItem>
                                            <asp:ListItem Value="I">&nbsp;Insurance Certificates</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </div>

                                <div class="col-3">
                                    <div class="form-group">
                                        <label>Certificate Requirement Details</label>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCertReq" AutoComplete="off"
                                            runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group table-radio-btns">
                                    <label>Orientation Training</label>
                                    <asp:RadioButtonList ID="rdbOrientTraining" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="2" Selected>&nbsp;No</asp:ListItem>
                                        <asp:ListItem Value="1">&nbsp;Online</asp:ListItem>
                                        <asp:ListItem Value="0">&nbsp;Offline(On Site)</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <label>Orientation Training Details</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrientationTraining" AutoComplete="off"
                                        runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <label>Plumbing & Electrical Supply</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtPlumbingElectricalSupply" AutoComplete="off"
                                        runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-3">
                                <div class="form-group">
                                    <label>Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtScopeDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtScopeDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtScopeDate" TargetControlID="txtScopeDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-lg-3 col-xl-6">
                                <div class="form-group">
                                    <label>Scope Of Work</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtScopeOfWork" AutoComplete="off"
                                        runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-1 col-sm-1 col-lg-1 col-xl-1">
                                <div class="form-group align-items-center">
                                    <label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;<br />
                                    </label>
                                    <asp:Button ID="btnGenerateCommReport" Enabled="false" runat="server" OnClientClick="window.document.forms[0].target='_blank';" CausesValidation="false" CssClass="btn btn-primary btn-sm mb-3" Text="Generate Communication Report" OnClick="btnGenerateCommReport_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfShipToArriveDate" runat="server" Value="-1" />
            <asp:HiddenField ID="hfShipToArriveDateFillDetail" runat="server" Value="-1" />
            <asp:HiddenField ID="HfJObID" runat="server" Value="-1" />
            <asp:HiddenField ID="HfCustomerID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfReleased" runat="server" Value="" />
            <asp:HiddenField ID="hfCurrentUser" runat="server" Value="" />
            <asp:HiddenField ID="hfCheckShipDateChange" runat="server" Value="" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnWarrntyLetter" />
            <asp:PostBackTrigger ControlID="btnShipping" />
            <asp:PostBackTrigger ControlID="btnGenerateCommReport" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
            //bindEnterKey();
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindEnterKey);
        });

        function PageLoaded(sender, args) {
            DDLName();
        }
        $.when.apply($, PageLoaded).then(function () {
            DDLName();
        });

        function DDLName() {
            $('#<%=ddlprojectstatus.ClientID%>').chosen();
            $('#<%=ddlOASentTo.ClientID%>').chosen();
            $('#<%=ddlProjectManager.ClientID%>').chosen();
            $('#<%=ddlConsultantRep.ClientID%>').chosen();
            $('#<%=ddlOrgRep.ClientID%>').chosen();
            $('#<%=ddlDesRep.ClientID%>').chosen();
            $('#<%=ddlDealer.ClientID%>').chosen();
            $('#<%=ddlConsultant.ClientID%>').chosen();
            $('#<%=ddlSalesSource.ClientID%>').chosen();
            $('#<%=ddlInstallationBy.ClientID%>').chosen();
            $('#<%=ddlInstallerA.ClientID%>').chosen();
            $('#<%=ddlInstallerB.ClientID%>').chosen();
            $('#<%=ddlInstallerC.ClientID%>').chosen();
            $('#<%=ddlSpecCredit.ClientID%>').chosen();
            $('#<%=ddlPurchasedItemsCAD.ClientID%>').chosen();
            $('#<%=ddlCurrency.ClientID%>').chosen();
            $('#<%=ddlFOB.ClientID%>').chosen();
            $('#<%=ddlTerm.ClientID%>').chosen();
            $('#<%=ddlRate.ClientID%>').chosen();
            $('#<%=ddlShipper.ClientID%>').chosen();           
            $('#<%=ddlShipperContactName.ClientID%>').chosen();
            $('#<%=ddlShippingComit.ClientID%>').chosen();
            $('#<%=ddlShippingStatus.ClientID%>').chosen();
            $('#<%=ddlcountry.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlCustomerSiteContact.ClientID%>').chosen();
            $('#<%=ddlDealerProjManager.ClientID%>').chosen();
            $('#<%=ddlWorkingHours.ClientID%>').chosen();
            $('#<%=ddlDeliveryPref.ClientID%>').chosen();
            $('#<%=ddlProjectReviewedBy.ClientID%>').chosen();
            $('#<%=ddlInstallationCommitment.ClientID%>').chosen();
            $('#<%=ddlInstallationPriority.ClientID%>').chosen();
            $('#<%=ddlShippingRequirements.ClientID%>').chosen();
            $('#<%=ddlSalesOpportunity.ClientID%>').chosen();
            $('#<%=ddlSalesOpportunityStatus.ClientID%>').chosen();
        }

        function ClickEventForPNumber(e) {
            __doPostBack('<%=btnPNumber_AutoComplete.UniqueID%>', "");
        }

        function ClickEventForCustomer(e) {
            __doPostBack('<%=Customer_AutoCompleteButton.UniqueID%>', "");
        }

        function ClickEventForPName(e) {
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchJNumberButton.UniqueID%>', "");
        }

        function bindEnterKey() {
            $('#<%= txtSearchPNum.ClientID %>').off('keydown').on('keydown', function (event) {
                if (event.keyCode == 13) { // 13 is the keycode for the Enter key
                    event.preventDefault();
                    return false;
                }
            });

            $('#<%= txtSearchPName.ClientID %>').off('keydown').on('keydown', function (event) {
                if (event.keyCode == 13) { // 13 is the keycode for the Enter key
                    event.preventDefault();
                    return false;
                }
            });
        }

        function RemoveQueryString() {
            var uri = window.location.toString();
            if (uri.indexOf("?") > 0) {
                var clean_uri = uri.substring(0, uri.indexOf("?"));
                window.history.replaceState({}, document.title, clean_uri);
            }
            //Display the new URL without any querystrings.
            //alert(document.URL);
        }

        function GetConsultantRepDetails() {
            var e = document.getElementById('<%=ddlConsultantRep.ClientID%>');
            var param = { Repid: e.value };
            $.ajax({
                url: "FrmProjects.aspx/GetConsultantRepDetails",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                    const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {
                        if (key == "FirstName") {
                            document.getElementById('lblFirstName').innerHTML = value;
                        }
                        else if (key == "AbbreviationName") {
                            document.getElementById('lblAbb').innerHTML = value;
                        }
                        else if (key == "RepState") {
                            document.getElementById('lblRepState').innerHTML = value;
                        }
                        else if (key == "PhoneMail") {
                            document.getElementById('lblPhoneMail').innerHTML = value;
                        }
                        else if (key == "Phone") {
                            document.getElementById('lblPhone').innerHTML = value;
                        }
                        else if (key == "CellPhone") {
                            document.getElementById('lblCellPhone').innerHTML = value;
                        }
                        else if (key == "Fax") {
                            document.getElementById('lblFax').innerHTML = value;
                        }
                        else if (key == "Email") {
                            document.getElementById('lblEmail').innerHTML = value;
                            var sendto = 'mailto:' + value;
                            $("#lblEmail").attr("href", sendto);
                        }
                        else if (key == "Status") {
                            document.getElementById('lblStatus').innerHTML = value;
                        }
                    })
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
            return false;
        };

        function GetOriginationRepDetails() {
            var e = document.getElementById('<%=ddlOrgRep.ClientID%>');
            var param = { Repid: e.value };
            $.ajax({
                url: "../SalesManagement/FrmProjects.aspx/GetOriginationRepDetails",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                    const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {
                        if (key == "FirstName") {
                            document.getElementById('lblOrigFirstName').innerHTML = value;
                        }
                        else if (key == "AbbreviationName") {
                            document.getElementById('lblOrigAbb').innerHTML = value;
                        }
                        else if (key == "RepState") {
                            document.getElementById('lblOrigState').innerHTML = value;
                        }
                        else if (key == "PhoneMail") {
                            document.getElementById('lblOrigPhoneMail').innerHTML = value;
                        }
                        else if (key == "Phone") {
                            document.getElementById('lblOrigPhone').innerHTML = value;
                        }
                        else if (key == "CellPhone") {
                            document.getElementById('lblOrigCellPhone').innerHTML = value;
                        }
                        else if (key == "Fax") {
                            document.getElementById('lblOrigFax').innerHTML = value;
                        }
                        else if (key == "Email") {
                            document.getElementById('lblOrigEmail').innerHTML = value;

                            var sendto = 'mailto:' + value;
                            $("#lblOrigEmail").attr("href", sendto);
                        }
                        else if (key == "Status") {
                            document.getElementById('lblOrigStatus').innerHTML = value;
                        }
                    }
            )
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
        };

        function GetDestinationRepDetails() {
            var e = document.getElementById('<%=ddlDesRep.ClientID%>');
            var param = { Repid: e.value };
            $.ajax({
                url: "../SalesManagement/FrmProjects.aspx/GetDestinationRepDetails",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                    const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {
                        if (key == "FirstName") {
                            document.getElementById('lblDestFirstName').innerHTML = value;
                        }
                        else if (key == "AbbreviationName") {
                            document.getElementById('lblDestAbb').innerHTML = value;
                        }
                        else if (key == "RepState") {
                            document.getElementById('lblDestState').innerHTML = value;
                        }
                        else if (key == "PhoneMail") {
                            document.getElementById('lblDestPhoneMail').innerHTML = value;
                        }
                        else if (key == "Phone") {
                            document.getElementById('lblDestPhone').innerHTML = value;
                        }
                        else if (key == "CellPhone") {
                            document.getElementById('lblDestCellPhone').innerHTML = value;
                        }
                        else if (key == "Fax") {
                            document.getElementById('lblDestFax').innerHTML = value;
                        }
                        else if (key == "Email") {
                            document.getElementById('lblDestEmail').innerHTML = value;
                            var sendto = 'mailto:' + value;
                            $("#lblDestEmail").attr("href", sendto);
                        }
                        else if (key == "Status") {
                            document.getElementById('lblDestStatus').innerHTML = value;
                        }
                    }
            )
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
        };

        function GetDealerDetails() {
            var e = document.getElementById('<%=ddlDealer.ClientID%>');
            var param = { DealerID: e.value };
            $.ajax({
                url: "../SalesManagement/FrmProjects.aspx/GetDealerDetails",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                    const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {
                        if (key == "FederalID") {
                            document.getElementById('lblFederalID').innerHTML = value;
                        }
                        else if (key == "CompanyName") {
                            document.getElementById('lblCompanyName').innerHTML = value;
                        }
                        else if (key == "GroupName") {
                            document.getElementById('lblGroupName').innerHTML = value;
                        }
                        else if (key == "StreetAddress") {
                            document.getElementById('lblStreetAddress').innerHTML = value;
                        }
                        else if (key == "City") {
                            document.getElementById('lblCity').innerHTML = value;
                        }
                        else if (key == "Country") {
                            document.getElementById('lblCountry').innerHTML = value;
                        }
                        else if (key == "DealerState") {
                            document.getElementById('lblState').innerHTML = value;
                        }
                        else if (key == "TollFree") {
                            document.getElementById('lblTollFree').innerHTML = value;
                        }
                        else if (key == "TollFax") {
                            document.getElementById('lblTollFax').innerHTML = value;
                        }
                        else if (key == "DealerPhone") {
                            document.getElementById('lblDealerPhone').innerHTML = value;
                        }
                        else if (key == "DealerFax") {
                            document.getElementById('lblDealerFax').innerHTML = value;
                        }
                        else if (key == "RepName") {
                            document.getElementById('lblDealerRepName').innerHTML = value;
                        }
                    })
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
        };

        function GetConsultantDetails() {
            var e = document.getElementById('<%=ddlConsultant.ClientID%>');
            var param = { ConsultantID: e.value };
            $.ajax({
                url: "../SalesManagement/FrmProjects.aspx/GetConsultantDetails",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                    const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {
                        if (key == "CompanyName") {
                            document.getElementById('lblConsultantCompName').innerHTML = value;
                        }
                        else if (key == "StreetAdd") {
                            document.getElementById('lblConsultantStreetAdd').innerHTML = value;
                        }
                        else if (key == "City") {
                            document.getElementById('lblConsultantCity').innerHTML = value;
                        }
                        else if (key == "Country") {
                            document.getElementById('lblConsultantCountry').innerHTML = value;
                        }
                        else if (key == "ConsultantState") {
                            document.getElementById('lblConsultantState').innerHTML = value;
                        }
                        else if (key == "Phone") {
                            document.getElementById('lblConsultantPhone').innerHTML = value;
                        }
                        else if (key == "TollFree") {
                            document.getElementById('lblConsultantTollFree').innerHTML = value;
                        }
                        else if (key == "Fax") {
                            document.getElementById('lblConsultantFax').innerHTML = value;
                        }
                        else if (key == "TollFax") {
                            document.getElementById('lblConsultantTollFax').innerHTML = value;
                        }
                        else if (key == "RepName") {
                            document.getElementById('lblConsultantRepName').innerHTML = value;
                        }
                    }
                )
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
        };

        function sumCalc() {
            var EqPrice = document.getElementById('<%= txtEqPrice.ClientID %>').value;
            var DisPer = document.getElementById('<%= txtEqDiscount.ClientID %>').value;
            var DisAmt = document.getElementById('<%= txtEqDisAmount.ClientID %>').value;
            var NetEqPrice = document.getElementById('<%= txtNetEqPrice.ClientID %>').value;
            var Freight = document.getElementById('<%= txtFreight.ClientID %>').value;
            var Install = document.getElementById('<%= txtInstall.ClientID %>').value;
            var Warranty = document.getElementById('<%= txtExWarranty.ClientID %>').value;
            var NetAmt = document.getElementById('<%= txtNetAmount.ClientID %>').value;
            var HST = document.getElementById('<%= txtHST.ClientID %>').value;
            var TotalAmt = document.getElementById('<%= txtTotalAmount.ClientID %>').value;

            if (EqPrice == '') { EqPrice = '0'; };
            if (DisPer == '') { DisPer = '0'; };
            if (DisAmt == '') { DisAmt = '0'; };
            if (NetEqPrice == '') { NetEqPrice = '0'; };
            if (Freight == '') { Freight = '0'; };
            if (Install == '') { Install = '0'; };
            if (Warranty == '') { Warranty = '0'; };
            if (NetAmt == '') { NetAmt = '0'; };
            if (HST == '') { HST = '0'; };
            if (TotalAmt == '') { TotalAmt = '0'; };

            //alert(DisPer);

            document.getElementById('<%= txtEqDiscount.ClientID %>').value = (parseFloat(DisAmt).toFixed(2) / parseFloat(EqPrice).toFixed(2) * 100);
            document.getElementById('<%= txtEqDisAmount.ClientID %>').value = (parseFloat(EqPrice).toFixed(2) * parseFloat(DisPer).toFixed(2) / 100);
            document.getElementById('<%= txtNetEqPrice.ClientID %>').value = (parseFloat(EqPrice).toFixed(2) - parseFloat(DisAmt).toFixed(2));
        
            <%-- alert(document.getElementById('<%= txtEqDisAmount.ClientID %>').value);--%>

        }

        function getCalc() {
            var EqPrice = document.getElementById('<%=txtEqPrice.ClientID%>').value;
            let EqpriceWithoutComma = eval(parseFloat(EqPrice.replace(/,/g, ''))).toFixed(2);

            if (isNaN(EqpriceWithoutComma)) {
                EqpriceWithoutComma = 0.00;
            }

            var disperc = eval(parseFloat(document.getElementById('<%=txtEqDiscount.ClientID%>').value)).toFixed(2);
            if (isNaN(disperc)) {
                disperc = 0.00;
            }
            document.getElementById('<%=txtEqDiscount.ClientID%>').value = disperc;

            var DisAmount = (EqpriceWithoutComma * disperc / 100).toFixed(2);
            if (isNaN(DisAmount)) {
                DisAmount = 0.00;
            }
            document.getElementById('<%=txtEqDisAmount.ClientID%>').value = DisAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var NetEqPrice = (EqpriceWithoutComma - DisAmount).toFixed(2);
            if (isNaN(NetEqPrice)) {
                NetEqPrice = 0.00;
            }
            document.getElementById('<%=txtNetEqPrice.ClientID%>').value = NetEqPrice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var Freight = document.getElementById('<%=txtFreight.ClientID%>').value;
            let FreightWithoutcomma = eval(parseFloat(Freight.replace(/,/g, ''))).toFixed(2);
            if (isNaN(FreightWithoutcomma)) {
                FreightWithoutcomma = 0.00;
            }
            document.getElementById('<%=txtFreight.ClientID%>').value = FreightWithoutcomma.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var Installation = document.getElementById('<%=txtInstall.ClientID%>').value;
            let Installationwithoutcomma = eval(parseFloat(Installation.replace(/,/g, ''))).toFixed(2);
            if (isNaN(Installationwithoutcomma)) {
                Installationwithoutcomma = 0.00;
            }
            document.getElementById('<%=txtInstall.ClientID%>').value = Installationwithoutcomma.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var ExWarranty = document.getElementById('<%=txtExWarranty.ClientID%>').value;
            let ExWarrantywithoutcomma = eval(parseFloat(ExWarranty.replace(/,/g, ''))).toFixed(2);
            if (isNaN(ExWarrantywithoutcomma)) {
                ExWarrantywithoutcomma = 0.00;
            }
            document.getElementById('<%=txtExWarranty.ClientID%>').value = ExWarranty.replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var NetAmount = parseFloat((parseFloat(NetEqPrice) + parseFloat(FreightWithoutcomma) + parseFloat(Installationwithoutcomma) + parseFloat(ExWarrantywithoutcomma))).toFixed(2);
            if (isNaN(NetAmount)) {
                NetAmount = 0.00;
            }
            document.getElementById('<%=txtNetAmount.ClientID%>').value = NetAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var HST = document.getElementById('<%=txtHST.ClientID%>').value;
            let HSTWithoutcomma = eval(parseFloat(HST.replace(/,/g, ''))).toFixed(2);
            if (isNaN(HSTWithoutcomma)) {
                HSTWithoutcomma = 0.00;
            }
            document.getElementById('<%=txtHST.ClientID%>').value = HST.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            var TotalAmount = parseFloat(parseFloat(NetAmount) + parseFloat(HSTWithoutcomma)).toFixed(2);
            document.getElementById('<%=txtTotalAmount.ClientID%>').value = TotalAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var percentage = $("#ctl00_ContentPlaceHolder1_TabContainer1_TabPanel1_ddlSpecCredit option:selected").text();
            if (document.getElementById('<%=ddlSpecCredit.ClientID%>').value > 0) {

                var e = document.getElementById('<%=ddlSpecCredit.ClientID%>');
                let specpercentage = e.options[e.selectedIndex].text;
                let specamount = parseFloat(NetEqPrice * specpercentage / 100).toFixed(2);
                document.getElementById('<%=txtSpecAmount.ClientID%>').value = specamount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            }
             <%--var Disc = document.getElementById('<%=txtDiscount.ClientID%>').value;
            if (document.getElementById('<%=txtDiscount.ClientID%>').value > 0) {

                let Discount = parseFloat((NetAmount * Disc) / 100).toFixed(2);
                document.getElementById('<%=txtAmount.ClientID%>').value = Discount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            }--%>
            var CommRate = eval(parseFloat(document.getElementById('<%=ddlRate.ClientID%>').value)).toFixed(2);
            // if(document.getElementById('<%=ddlRate.ClientID%>').value > 0)
            if (CommRate > 0) {
                if (NetEqPrice <= 0) {
                    document.getElementById('<%=txtCommAmount.ClientID%>').value = "0";
                } else {
                    let CommAmt = parseFloat(NetEqPrice * CommRate / 100).toFixed(2);
                    document.getElementById('<%=txtCommAmount.ClientID%>').value = CommAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
            }
           <%-- var GovSalesComm = document.getElementById('<%=txtCommissionRate.ClientID%>').value;
            if (document.getElementById('<%=txtCommissionRate.ClientID%>').value > 0) {
                let GovtSalesCommAmt = parseFloat(NetEqPrice * GovSalesComm / 100).toFixed(2);
                document.getElementById('<%=txtCommissionAmount.ClientID%>').value = GovtSalesCommAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            }--%>
        }

        function getPer() {
            var EqPrice = document.getElementById('<%=txtEqPrice.ClientID%>').value;
            let EqpriceWithoutComma = eval(parseFloat(EqPrice.replace(/,/g, ''))).toFixed(2);
            if (isNaN(EqpriceWithoutComma)) {
                EqpriceWithoutComma = 0.00;
            }

            var DisAmt = eval(parseFloat(document.getElementById('<%=txtEqDisAmount.ClientID%>').value.replace(/,/g, ''))).toFixed(2);
            if (isNaN(DisAmt)) {
                DisAmt = 0.00;
            }
            document.getElementById('<%=txtEqDisAmount.ClientID%>').value = DisAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var DisPerc = (DisAmt / EqpriceWithoutComma * 100).toFixed(2);
            if (isNaN(DisPerc)) {
                DisPerc = 0.00;
            }
            document.getElementById('<%=txtEqDiscount.ClientID%>').value = DisPerc;

            var NetEqPrice = (EqpriceWithoutComma - DisAmt).toFixed(2);
            if (isNaN(NetEqPrice)) {
                NetEqPrice = 0.00;
            }
            document.getElementById('<%=txtNetEqPrice.ClientID%>').value = NetEqPrice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var Freight = document.getElementById('<%=txtFreight.ClientID%>').value;
            let FreightWithoutcomma = eval(parseFloat(Freight.replace(/,/g, ''))).toFixed(2);
            if (isNaN(FreightWithoutcomma)) {
                FreightWithoutcomma = 0.00;
            }
            document.getElementById('<%=txtFreight.ClientID%>').value = Freight.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var Installation = document.getElementById('<%=txtInstall.ClientID%>').value;
            let Installationwithoutcomma = eval(parseFloat(Installation.replace(/,/g, ''))).toFixed(2);
            if (isNaN(Installationwithoutcomma)) {
                Installationwithoutcomma = 0.00;
            }
            document.getElementById('<%=txtInstall.ClientID%>').value = Installation.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var ExWarranty = document.getElementById('<%=txtExWarranty.ClientID%>').value;
            let ExWarrantywithoutcomma = eval(parseFloat(ExWarranty.replace(/,/g, ''))).toFixed(2);
            if (isNaN(ExWarrantywithoutcomma)) {
                ExWarrantywithoutcomma = 0.00;
            }
            document.getElementById('<%=txtExWarranty.ClientID%>').value = ExWarranty.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            var NetAmount = parseFloat((parseFloat(NetEqPrice) + parseFloat(FreightWithoutcomma) + parseFloat(Installationwithoutcomma) + parseFloat(ExWarrantywithoutcomma))).toFixed(2);

            if (isNaN(NetAmount)) {
                NetAmount = 0.00;
            }
            document.getElementById('<%=txtNetAmount.ClientID%>').value = NetAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var HST = document.getElementById('<%=txtHST.ClientID%>').value;
            let HSTWithoutcomma = eval(parseFloat(HST.replace(/,/g, ''))).toFixed(2);
            if (isNaN(HSTWithoutcomma)) {
                HSTWithoutcomma = 0.00;
            }
            document.getElementById('<%=txtHST.ClientID%>').value = HST.replace(/\B(?=(\d{3})+(?!\d))/g, ',');

            var TotalAmount = parseFloat(parseFloat(NetAmount) + parseFloat(HSTWithoutcomma)).toFixed(2);
            document.getElementById('<%=txtTotalAmount.ClientID%>').value = TotalAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            var percentage = $("#ctl00_ContentPlaceHolder1_TabContainer1_TabPanel1_ddlSpecCredit option:selected").text();

            if (document.getElementById('<%=ddlSpecCredit.ClientID%>').value > 0) {
                var e = document.getElementById('<%=ddlSpecCredit.ClientID%>');
                let specpercentage = e.options[e.selectedIndex].text;
                let specamount = parseFloat(NetEqPrice * specpercentage / 100).toFixed(2);
                document.getElementById('<%=txtSpecAmount.ClientID%>').value = specamount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            }
            <%--        var Disc = document.getElementById('<%=txtDiscount.ClientID%>').value;
            if (document.getElementById('<%=txtDiscount.ClientID%>').value > 0) {
                let Discount = parseFloat((NetAmount * Disc) / 100).toFixed(2);
                document.getElementById('<%=txtAmount.ClientID%>').value = Discount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            }--%>
            var CommRate = eval(parseFloat(document.getElementById('<%=ddlRate.ClientID%>').value)).toFixed(2);
            // if(document.getElementById('<%=ddlRate.ClientID%>').value > 0)
            if (CommRate > 0) {
                if (NetEqPrice <= 0) {
                    document.getElementById('<%=txtCommAmount.ClientID%>').value = "0";
                } else {
                    let CommAmt = parseFloat(NetEqPrice * CommRate / 100).toFixed(2);
                    document.getElementById('<%=txtCommAmount.ClientID%>').value = CommAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
            }
           <%-- var GovSalesComm = document.getElementById('<%=txtCommissionRate.ClientID%>').value;
            if (document.getElementById('<%=txtCommissionRate.ClientID%>').value > 0) {
                let GovtSalesCommAmt = parseFloat(NetEqPrice * GovSalesComm / 100).toFixed(2);
                document.getElementById('<%=txtCommissionAmount.ClientID%>').value = GovtSalesCommAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            }--%>
        }

        function CalculateCommission() {
            var NetEqPrice = document.getElementById('<%=txtNetEqPrice.ClientID%>').value;
            let NetEqPricewithoutcomma = eval(parseFloat(NetEqPrice.replace(/,/g, ''))).toFixed(2);
            var ComType = eval(parseFloat(document.getElementById('<%=ddlRate.ClientID%>').value)).toFixed(2);
            let commamount = (parseFloat(NetEqPricewithoutcomma) * parseFloat(ComType) / 100).toFixed(2);

            NetEqPrice = document.getElementById('<%=txtAmountForComision.ClientID%>').value;
            NetEqPricewithoutcomma = eval(parseFloat(NetEqPrice.replace(/,/g, ''))).toFixed(2);
            ComType = eval(parseFloat(document.getElementById('<%=ddlRate.ClientID%>').value)).toFixed(2);
            if (NetEqPricewithoutcomma <= 0) {
                document.getElementById('<%=txtCommAmount.ClientID%>').value = "0";
                document.getElementById('<%=txtNetRateCommission.ClientID%>').value = "0";
            }
            else {
                commamount = (parseFloat(NetEqPricewithoutcomma) * parseFloat(ComType) / 100).toFixed(2);
                var integerPart = Math.floor(commamount);
                var decimalPart = commamount - integerPart;
                if (decimalPart >= 0.5) {
                    integerPart += 1;
                }
                commamount = integerPart;
                document.getElementById('<%=txtCommAmount.ClientID%>').value = commamount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                document.getElementById('<%=txtNetRateCommission.ClientID%>').value = commamount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            }
        }

        function EnableDisableSpecCredit() {
            var CrUser = document.getElementById('<%=hfCurrentUser.ClientID%>').value;
            if (CrUser == 28) {
                document.getElementById('<%=ddlSpecCredit.ClientID%>').disabled = false;
                document.getElementById('<%=txtSpecCheque.ClientID%>').disabled = false;
                document.getElementById('<%=txtSpecPaid.ClientID%>').disabled = false;
                document.getElementById("btnClearSpec").disabled = false;
            }
            else {
                document.getElementById('<%=rdbSpecCredit.ClientID%>').disabled = true;
                document.getElementById('<%=ddlSpecCredit.ClientID%>').disabled = true;
                document.getElementById('<%=txtSpecCheque.ClientID%>').disabled = true;
                document.getElementById('<%=txtSpecPaid.ClientID%>').disabled = true;
                document.getElementById("btnClearSpec").disabled = true;
            }
        }

        function getCheckedRadio() {
            var radioValue = $('#<%=rdbSpecCredit.ClientID %> input:checked').val();
            if (radioValue != undefined) {
                var ddlCreditValue = document.getElementById('<%=ddlSpecCredit.ClientID%>').value;
                //alert(radioValue);
                //alert(ddlCreditValue);
                if (radioValue == 2) {
                    document.getElementById('<%=ddlSpecCredit.ClientID%>').disabled = false;
                    document.getElementById('<%=txtSpecCheque.ClientID%>').disabled = false;
                    document.getElementById('<%=txtSpecPaid.ClientID%>').disabled = false;
                    // Hard Code ID For spec credit by deafult Value
                    if (ddlCreditValue == 0) {
                        document.getElementById('<%=ddlSpecCredit.ClientID%>').value = 3;
                    }
                    else {
                        document.getElementById('<%=ddlSpecCredit.ClientID%>').value = ddlCreditValue;
                    }
                    var e = document.getElementById('<%=ddlSpecCredit.ClientID%>');
                    var percentage = e.options[e.selectedIndex].text;
                    let NetEqPrice = document.getElementById('<%=txtNetEqPrice.ClientID%>').value;
                    let NetEqPricewithoutcomma = parseFloat(NetEqPrice.replace(/,/g, '')).toFixed(2);
                    var SpecAmount = (parseFloat(NetEqPricewithoutcomma) * parseFloat(percentage) / 100).toFixed(2);
                    if (isNaN(SpecAmount)) SpecAmount = 0.00;
                    document.getElementById('<%=txtSpecAmount.ClientID%>').value = SpecAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                else if (radioValue == 3) {
                    document.getElementById('<%=ddlSpecCredit.ClientID%>').disabled = true;
                    document.getElementById('<%=txtSpecCheque.ClientID%>').disabled = true;
                    document.getElementById('<%=txtSpecPaid.ClientID%>').disabled = true;
                    document.getElementById('<%=txtSpecCheque.ClientID%>').value = "";
                    document.getElementById('<%=ddlSpecCredit.ClientID%>').value = "0";
                    document.getElementById('<%=txtSpecPaid.ClientID%>').value = "";
                    document.getElementById('<%= txtSpecAmount.ClientID %>').value = "";
                }
                else {
                    document.getElementById('<%= ddlSpecCredit.ClientID %>').value = "0";
                    document.getElementById('<%= txtSpecAmount.ClientID %>').value = "";
                    document.getElementById('<%= txtSpecCheque.ClientID %>').value = "";
                    document.getElementById('<%= txtSpecPaid.ClientID %>').value = "";
                    document.getElementById('<%=ddlSpecCredit.ClientID%>').disabled = true;
                    document.getElementById('<%=txtSpecCheque.ClientID%>').disabled = true;
                    document.getElementById('<%=txtSpecPaid.ClientID%>').disabled = true;
                }
        }

    }

    function ClearSpecCredit() {
        ClearRadioButtonList('<%= rdbSpecCredit.ClientID %>');
        document.getElementById('<%= ddlSpecCredit.ClientID %>').value = "0";
        document.getElementById('<%= txtSpecAmount.ClientID %>').value = "";
        document.getElementById('<%= txtSpecCheque.ClientID %>').value = "";
        document.getElementById('<%= txtSpecPaid.ClientID %>').value = "";

    }

    function GetConsultant() {
        var e = document.getElementById('<%=ddlConsultant.ClientID%>');
        var Consultantinfo = e.options[e.selectedIndex].text;
        document.getElementById('<%=txtSpecConsultant.ClientID%>').innerText = Consultantinfo;
    }

    function GetConsultantRep() {
        var e = document.getElementById('<%=ddlConsultantRep.ClientID%>');
        var ConsultantRepinfo = e.options[e.selectedIndex].text;

        document.getElementById('<%=txtSpecConsultantRep.ClientID%>').innerText = ConsultantRepinfo;
    }

    function SetReviewByDropDown() {
        var ddl = document.getElementById("ctl00_ContentPlaceHolder1_TabContainer1_TabPanel1_ddlReviewedBy");
        var ReviewedBy = ddl.options[ddl.selectedIndex].value;
        if (ReviewedBy == 242) {
            <%--document.getElementById('<%=ddlMfgFacility.ClientID%>').value = 2;--%>
        }
        else {
             <%--document.getElementById('<%=ddlMfgFacility.ClientID%>').value = 1;--%>
        }
    }
        function CheckPNumber() {
            var param = { PNumber: $("#<%=txtPNumber.ClientID %>").val() };

            $.ajax({
                url: "FrmProjects.aspx/HideDuplicatePNumber",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    $('[id$=btnSave]').attr('disabled', false);
                    if (param != "") {
                        var me = data.d;
                        if (me != "") {
                            // alert(me);
                            $('[id$=btnSave]').attr('disabled', true);
                        }
                        else {
                            AutoFillPNumber();
                        }
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
        };


        function AutoFillPNumber() {
            var param = { PNumber: $("#<%=txtPNumber.ClientID %>").val() };
            //alert(param);
            $.ajax({
                url: "FrmProjects.aspx/AutoFillPNumber",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    {
                        var myData = data.d;
                        $(myData).each(function () {
                            document.getElementById('<%=ddlDealer.ClientID%>').value = this.DealerID;
                            document.getElementById('<%=ddlOrgRep.ClientID%>').value = this.OriginRepID;
                            document.getElementById('<%=ddlConsultantRep.ClientID%>').value = this.ConsultRepID;
                            document.getElementById('<%=ddlDesRep.ClientID%>').value = this.RepID;
                            document.getElementById('<%=ddlConsultant.ClientID%>').value = this.ConsultantID;
                                <%--document.getElementById('<%=ddlConveyorType.ClientID%>').value = this.ConveyorTypeID;
                                document.getElementById('<%=ddlModel.ClientID%>').value = this.ModelID;--%>
                            document.getElementById('<%=txtEqPrice.ClientID%>').value = this.Price;
                            document.getElementById('<%=txtFreight.ClientID%>').value = this.Freight;
                            document.getElementById('<%=txtInstall.ClientID%>').value = this.Installation;
                            document.getElementById('<%=ddlCurrency.ClientID%>').value = this.CurrencyID;
                            document.getElementById('<%=txtEqDiscount.ClientID%>').value = this.EqDiscount;
                            document.getElementById('<%=txtEqDisAmount.ClientID%>').value = this.EqDisAmount;
                            document.getElementById('<%=txtNetEqPrice.ClientID%>').value = this.NetEqPrice;
                            <%--document.getElementById('<%=ddlProjectType.ClientID%>').value = this.JobType;--%>
                                <%-- document.getElementById('<%=ddlExistingJobno.ClientID%>').value = this.ExistingJobID;--%>
                            document.getElementById('<%=ddlSpecCredit.ClientID%>').value = this.SpecCreditPercentID;
                            document.getElementById('<%=txtSpecAmount.ClientID%>').value = this.SpecCreditAmount;
                            document.getElementById('<%=txtSpecCheque.ClientID%>').value = this.SpecCreditCheckNo;
                            var sel = document.getElementById('<%=ddlConsultant.ClientID%>');
                            var Consultantinfo = sel.options[sel.selectedIndex].text;
                            //$("ctl00_ContentPlaceHolder1_ddlConsultantRep option:selected").text();                                                  
                            document.getElementById('<%=txtSpecConsultant.ClientID%>').innerText = Consultantinfo;
                            var sel = document.getElementById('<%=ddlConsultantRep.ClientID%>');
                            var ConsultantRepinfo = sel.options[sel.selectedIndex].text;
                            document.getElementById('<%=txtSpecConsultantRep.ClientID%>').innerText = ConsultantRepinfo;
                            var SpecVal = this.SpecCredits;

                            if (SpecVal == "1") {
                                //("input[id=rdbSpecCredit][value=" + SpecVal + "]").attr('checked', 'checked');
                                $("[id$=rdbSpecCredit]").find("input[value='" + SpecVal + "']").prop("checked", true);
                                getCheckedRadio();
                            }
                            else if (SpecVal == "2") {
                                $("[id$=rdbSpecCredit]").find("input[value='" + SpecVal + "']").prop("checked", true);
                                document.getElementById('<%=ddlSpecCredit.ClientID%>').disabled = false;
                                document.getElementById('<%=txtSpecCheque.ClientID%>').disabled = false;
                                document.getElementById('<%=txtSpecPaid.ClientID%>').disabled = false;
                            }
                            else if (SpecVal == "3") {
                                $("[id$=rdbSpecCredit]").find("input[value='" + SpecVal + "']").prop("checked", true);
                                getCheckedRadio();
                            }
                            else {
                                ClearRadioButtonList('<%= rdbSpecCredit.ClientID %>');
                            }

                            var OrderBelongsTo = this.OrderBelongsTo;
                            if (OrderBelongsTo == 1) {
                                $("[id$=rdbOrderFor]").find("input[value='" + OrderBelongsTo + "']").prop("checked", true);
                            }
                            else if (OrderBelongsTo == 2) {
                                $("[id$=rdbOrderFor]").find("input[value='" + OrderBelongsTo + "']").prop("checked", true);
                            }

                            // var radioValue =$("input[name='ctl00$ContentPlaceHolder1$TabContainer1$TabPanel1$rdbSpecCredit']:checked").val(this.SpecCredits);
                            var pattern = /Date\(([^)]+)\)/;
                            var results = pattern.exec(this.SpecCreditPaidDate);
                            var dt = new Date(parseFloat(results[1]));
                            document.getElementById('<%=txtSpecPaid.ClientID%>').value = dt.getMonth() + 1 + "/" + dt.getDate() + "/" + dt.getFullYear();

                            var pattern = /Date\(([^)]+)\)/;
                            var results = pattern.exec(this.shipdate);
                            var dt = new Date(parseFloat(results[1]));
                            document.getElementById('<%=txtShipToArrive.ClientID%>').value = dt.getMonth() + 1 + "/" + dt.getDate() + "/" + dt.getFullYear();

                        });
                        //$("#ddlDealer").text(myData[0]);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
        }

        function SetCSSFirst() {
            document.getElementById("giTab").className = 'tab-pane fade show active pt-2';
        }

        function SetCSS() {
            document.getElementById("sdTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("giTab").className = 'tab-pane fade pt-2';
            document.getElementById("siTab").className = 'tab-pane fade pt-2';
            document.getElementById("otTab").className = 'tab-pane fade pt-2';
            document.getElementById("gi-tab").className = 'nav-link';
            document.getElementById("si-tab").className = 'nav-link';
            document.getElementById("ot-tab").className = 'nav-link';
            document.getElementById("sd-tab").className = 'nav-link active';
        }

        function SetICSCSS() {
            document.getElementById("icsTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("giTab").className = 'tab-pane fade pt-2';
            document.getElementById("siTab").className = 'tab-pane fade pt-2';
            document.getElementById("otTab").className = 'tab-pane fade pt-2';
            document.getElementById("gi-tab").className = 'nav-link';
            document.getElementById("si-tab").className = 'nav-link';
            document.getElementById("ot-tab").className = 'nav-link';
            document.getElementById("ics-tab").className = 'nav-link active';
        }

        function SetSICSS() {
            document.getElementById("siTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("giTab").className = 'tab-pane fade pt-2';
            document.getElementById("icsTab").className = 'tab-pane fade pt-2';
            document.getElementById("otTab").className = 'tab-pane fade pt-2';
            document.getElementById("gi-tab").className = 'nav-link';
            document.getElementById("ics-tab").className = 'nav-link';
            document.getElementById("ot-tab").className = 'nav-link';
            document.getElementById("si-tab").className = 'nav-link active';
        }

        function SetOTCSS() {
            document.getElementById("otTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("siTab").className = 'tab-pane fade pt-2';
            document.getElementById("giTab").className = 'tab-pane fade pt-2';
            document.getElementById("icsTab").className = 'tab-pane fade pt-2';
            document.getElementById("gi-tab").className = 'nav-link';
            document.getElementById("ics-tab").className = 'nav-link';
            document.getElementById("si-tab").className = 'nav-link';
            document.getElementById("ot-tab").className = 'nav-link active';
        }

        function refocusAndTriggerAutocomplete(inputId, inputValue) {
            var input = document.getElementById(inputId);
            if (input) {
                // Set the value
                input.value = inputValue;

                // Set the cursor at the end of the text
                if (input.setSelectionRange) {
                    input.setSelectionRange(input.value.length, input.value.length); // Set cursor at the end
                } else if (input.createTextRange) {
                    var range = input.createTextRange();
                    range.moveStart('character', input.value.length);
                    range.select(); // For older browsers
                }

                setTimeout(function () {
                    var event = new KeyboardEvent('input', {
                        bubbles: true,
                        cancelable: true,
                        key: 'Enter',  // You can also use other keys or leave it blank to just trigger the event
                    });
                    input.dispatchEvent(event);
                    //console.log('Input event dispatched with value:', input.value);
                    input.focus();
                }, 100);
            }
        }

        function enableDisable_MFW() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkMannedFireWatch');
            var txt = document.getElementById('<%= txtMannedFireWatch.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_HWP() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkHotWorkPermit');
            var txt = document.getElementById('<%= txtHotWorkPermit.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_CTA() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkCanTechAccess');
            var txt = document.getElementById('<%= txtCanTechAccess.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_Osha() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkOsha');
            var txt = document.getElementById('<%= txtOsha.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_StateCertificate() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkStateCertificate');
            var txt = document.getElementById('<%= txtStateCertificate.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_DrugTestingCertificate() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkDrugTestingCertificate');
            var txt = document.getElementById('<%= txtDrugTestingCertificate.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_WHMIS() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkWHMIS');
            var txt = document.getElementById('<%= txtWHMIS.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_FallProtection() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkFallProtection');
            var txt = document.getElementById('<%= txtFallProtection.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_MedicalCertificate() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkMedicalCertificate');
            var txt = document.getElementById('<%= txtMedicalCertificate.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }

        function enableDisable_InsuranceCertificate() {
            var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_chkInsuranceCertificate');
            var txt = document.getElementById('<%= txtInsuranceCertificate.ClientID %>');
            if (!checkbox || !txt) {
                return;
            }
            txt.disabled = !checkbox.checked;
        }
    </script>
</asp:Content>
