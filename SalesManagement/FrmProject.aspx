<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmProject.aspx.cs" Inherits="SalesManagement_FrmProject" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Project Information
                            <%--  <span id="spn" visible="false" runat="server" style="background:#ffff; padding: .1rem 1rem; font-size: 1.2rem;border: 1px solid #0b5fa1;">  --%>
                                <asp:Label ID="lblPM" Visible="false" CssClass="btn btn-primary btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblDesRep" Visible="false" CssClass="btn btn-success btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblConsultant" Visible="false" CssClass="btn btn-info btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <%--<asp:Label ID="lblDealer"  Visible="false" CssClass="btn btn-info btn-sm" style="cursor:no-drop;" runat="server" Text=""></asp:Label>--%>
                                <%--</span>--%>
                            </h4>
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
                                            <asp:TextBox ID="txtSearchPName" AutoComplete="off" placeholder="Type Job Number" CssClass="form-control form-control-sm" OnBlur="return ClickEventForPName(event)" runat="server">
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
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-sm mb-3" OnClick="btnAdd_Click" Text="New Project" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm mb-3" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-secondary btn-sm mb-3" Visible="false" OnClick="btnSearch_Click" Text="Search Project" />
                                <asp:Button ID="btnCADReport" runat="server" CssClass="btn btn-secondary btn-sm mb-3" OnClick="btnCADReport_Click" Text="Engineering" />
                                <asp:Button ID="btnSiteVisit" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnSiteVisit_Click" Text="Site Visit" />
                                <asp:Button ID="btnCuspack" runat="server" CssClass="btn btn-info btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Customer Package" Enabled="false" OnClick="btnCuspack_Click" />
                                <asp:Button ID="btnAcknoledgement" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Acknowledgement" Enabled="false" OnClick="btnAcknoledgement_Click" />
                                <asp:Button ID="btnInf" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Inf for ENG" Enabled="false" OnClick="btnInf_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm mb-3" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="RemoveQueryString()" />

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
                                <a class="nav-link" id="ics-tab" data-toggle="tab" href="#icsTab" role="tab" aria-controls="profile" aria-selected="false"><span>Invoice, Commission & Shipping <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="sd-tab" data-toggle="tab" href="#sdTab" role="tab" aria-controls="contact" aria-selected="false"><span>Shop Drawings <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="fab-tab" data-toggle="tab" href="#fabTab" role="tab" aria-controls="fabrication" aria-selected="false"><span>Fabrication <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="nes-tab" data-toggle="tab" href="#nesTab" role="tab" aria-controls="nesting" aria-selected="false"><span>Nesting <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="Model-tab" data-toggle="tab" href="#Model" role="tab" aria-controls="Model" aria-selected="false"><span>Model <i class="fas fa-arrow-right"></i></span></a>
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
                                        <asp:DropDownList ID="ddlPNumber" CssClass="form-control" runat="server" DataTextField="ProposalID" DataValueField="ProposalID" AutoPostBack="True" OnSelectedIndexChanged="ddlPNumber_SelectedIndexChanged"></asp:DropDownList>
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
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtJobOrderDate" AutoComplete="off" Enabled="false" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtJobOrderDate" TargetControlID="txtJobOrderDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Order Ack Sent Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtOrderAckDate" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtOrderAckDate" TargetControlID="txtOrderAckDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>OA Dispatch Date (HO)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtOADispatch" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtOADispatch" TargetControlID="txtOADispatch"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
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
                                        <asp:ListItem Value="N">Not Required</asp:ListItem>
                                        <asp:ListItem Value="Y">Required</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%--<div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Project Type</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Type</label>
                                    <asp:DropDownList ID="ddlProjectType" runat="server" DataTextField="JobType" DataValueField="id" CssClass="form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                           <%-- <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Existing Job#</label>
                                    <asp:DropDownList ID="ddlExistingJobno" runat="server" DataTextField="JobID" DataValueField="JobID" CssClass="form-control form-control-sm"></asp:DropDownList>
                                </div>
                            </div>



                        </div>--%>
                        <div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">General Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Customer*</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCustomer" runat="server" DataTextField="CompanyName" DataValueField="CustomerID" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList>
                                        <%--<a href="../ContactManagement/FrmCustomers.aspx" style="cursor:pointer;" class="input-group-prepend pl-1"><i class="far fa-address-card fa-2x"></i></a>--%>
                                        <div class="input-group-prepend pl-1">
                                            <%--<button  onclick="GetCustomerPage()" class="btn border-0 p-0" type="button" clientidmode="Static" runat="server"><i class="far fa-address-card fa-2x"></i></button>--%>
                                            <%--<asp:LinkButton ID="lnkRedirecttoCustomer" runat="server" class="btn border-0 p-0" OnClick="lnkRedirecttoCustomer_Click"><i class="far fa-address-card fa-2x"></i></asp:LinkButton>--%>
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
                                    <asp:TextBox CssClass="form-control form-control-sm" MaxLength="15" ID="txtPONumber" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>PO Rec. Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtPoRecDate" AutoComplete="off" runat="server"></asp:TextBox>
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
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Dealer</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDealer" runat="server" DataTextField="CompanyName" DataValueField="DealerID" AutoPostBack="True" OnSelectedIndexChanged="ddlDealer_SelectedIndexChanged"></asp:DropDownList>
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
                            <%--<div class="col-sm-3">
<div class="form-group">
<label>Project Designer</label>
<asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDesigner" runat="server" DataTextField="Name" DataValueField="EmployeeID"></asp:DropDownList>
</div>
</div>
<div class="col-sm-3">
<div class="form-group">
<label>Date Assigned</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtDateAssigned" runat="server" AutoComplete="off"></asp:TextBox>
<asp:CalendarExtender CssClass="form-control form-control-sm" ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateAssigned" TargetControlID="txtDateAssigned"></asp:CalendarExtender>
</div>
</div>--%>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Sales Source</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesSource" runat="server" Enabled="false" DataTextField="SalesSource" DataValueField="SalesSourceID"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Conveyor Type</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConveyorType" DataValueField="ConveyorTypeID" DataTextField="ConveyorType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConveyorType_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Model</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlModel" DataValueField="ModelID" DataTextField="ModelName" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Service Rep</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlServiceRep" DataValueField="ServiceRepID" DataTextField="Rep" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3" style="display: none;">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Project Data</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Prepared By</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Name" DataValueField="EmployeeID" ID="ddlPreparedBy" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By (AI)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Name" DataValueField="EmployeeID" ID="ddlReviewedByAI" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By (AI) Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtReviewedByAI" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReviewedByAI" TargetControlID="txtReviewedByAI"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By (HO)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Name" DataValueField="EmployeeID" ID="ddlReviewedByHO" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By (HO) Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtReviewedByHO" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReviewedByHO" TargetControlID="txtReviewedByHO"></asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Date (Before Shipped)</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Released</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtReleased" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtReleased_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReleased" TargetControlID="txtReleased"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Built Dwgs Sent</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateBuiltDrgsSent" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateBuiltDrgsSent" TargetControlID="txtDateBuiltDrgsSent"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Estimated Completion</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtEstimatedCom" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender10" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtEstimatedCom" TargetControlID="txtEstimatedCom"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Actual Completion</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtActualCom" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender11" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtActualCom" TargetControlID="txtActualCom"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Test Run</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtTestRun" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender12" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtTestRun" TargetControlID="txtTestRun"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none">
                                <div class="form-group chosenFullWidth">
                                    <label>Manufacturing Facility</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlMfgFacility" runat="server" DataTextField="FacilityName" DataValueField="id"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Date (After Shipped)</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label>Installation By</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallationBy" runat="server" DataTextField="Desc" DataValueField="InstallationByID"></asp:DropDownList>
                                        <div class="input-group-prepend pl-1">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallerA" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label>Installation Start</label>
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtInstallationStart" AutoComplete="off" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender13" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtInstallationStart" TargetControlID="txtInstallationStart"></asp:CalendarExtender>
                                        <div class="input-group-prepend pl-1">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallerB" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label>Installation End</label>
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtInstallationEnd" AutoComplete="off" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender14" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtInstallationEnd" TargetControlID="txtInstallationEnd"></asp:CalendarExtender>
                                        <div class="input-group-prepend pl-1">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlInstallerC" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Test Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDemo" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender15" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDemo" TargetControlID="txtDemo"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Warranty Start</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtWarrantyStart" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtWarrantyStart_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender16" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtWarrantyStart" TargetControlID="txtWarrantyStart"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Warranty End</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtWarrantyEnd" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender17" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtWarrantyEnd" TargetControlID="txtWarrantyEnd"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>Follow Up</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFollowUp" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender29" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFollowUp" TargetControlID="txtFollowUp"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Warranty Letter Dispatched</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCarePack" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender30" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtCarePack" TargetControlID="txtCarePack"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Service Manuals Dispatched</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtManualsDisp" AutoComplete="off" runat="server"></asp:TextBox>
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
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group srRadiosBtns">
                                    <label>PM Package</label>
                                    <asp:RadioButtonList ID="rdbPM" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:RadioButtonList>
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
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtSpecPaid" AutoComplete="off" Enabled="false" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtSpecPaid" TargetControlID="txtSpecPaid"></asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade pt-2" id="icsTab" role="tabpanel" aria-labelledby="profile-tab">
                        <div class="row">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">General Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Currency*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCurrency" runat="server" DataTextField="Currency" DataValueField="CurrencyID"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Equipment Price($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtEqPrice" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getPer()" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Eq Discount%</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtEqDiscount" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Eq Dis Amount($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtEqDisAmount" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getPer()" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
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
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtFreight" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getPer()" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Installation($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtInstall" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getPer()" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Ex Warranty Price($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtExWarranty" MaxLength="15" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" AutoCompleteType="Disabled" onchange="getCalc();getPer()" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
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
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtinvnumber" Enabled="false" MaxLength="15" AutoComplete="off" AutoCompleteType="Disabled" runat="server" AutoPostBack="true" OnTextChanged="txtinvnumber_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Invoice Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtInvodate" AutoComplete="off" Enabled="false" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender18" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtInvodate" TargetControlID="txtInvodate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">FOB*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFOB" runat="server" DataTextField="type" DataValueField="fobId"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Term*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTerm" runat="server" DataTextField="type" DataValueField="termId"></asp:DropDownList></td>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3" style="display: none;">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Individual Rep Commission</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Cheque No</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtChequeNo" AutoComplete="off" MaxLength="15" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Ind Com Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtIndComDate" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender19" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtIndComDate" TargetControlID="txtIndComDate"></asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3">
                            <div class="col-12">
                                <h5 class="text-uppercase">Early Payment Cash Discount</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Received</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateReceived" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender20" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDateReceived" TargetControlID="txtDateReceived"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>Discount (%)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtDiscount" AutoComplete="off" MaxLength="15" runat="server" Text="0" onchange="getDis()" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>Amount($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtAmount" AutoComplete="off" runat="server" onkeyup="javascript:this.value=Comma(this.value);" MaxLength="15" Text="0" Enabled="false" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>Actual Freight Paid($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtActualFreight" onkeyup="javascript:this.value=Comma(this.value);" AutoComplete="off" Text="0" MaxLength="15" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>


                        </div>
                        <div class="row  pt-3">
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Total Amount Invoiced ($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtAmountInvoiced" onkeypress="return onlyDotsAndNumbers(this,event);" AutoComplete="off" MaxLength="15" AutoPostBack="true" runat="server" OnTextChanged="txtAmountInvoiced_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label title="Net Eq Price($) - Discount Percentage (%)">Discount Amount ($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtCashDiscountAmount" onkeypress="return onlyDotsAndNumbers(this,event);" AutoComplete="off" MaxLength="15" AutoPostBack="true" runat="server" OnTextChanged="txtCashDiscountAmount_TextChanged"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Discount Percentage (%)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtCashDiscountPer" onkeypress="return onlyDotsAndNumbers(this,event);" AutoComplete="off" MaxLength="15" runat="server" AutoPostBack="True" OnTextChanged="txtCashDiscountPer_TextChanged"></asp:TextBox>
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
                        <div class="row border-top pt-3">
                            <div class="col-12 mb-3">
                                <h5 class="text-uppercase mb-0">Project Commission Info</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Rate %*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRate" runat="server" onchange="CalculateCommission()" DataTextField="CommissionType" DataValueField="CommissionType"></asp:DropDownList>
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
                                    <label>Cheque #</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCommCheque" MaxLength="15" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Paid</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCommDate" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender21" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtCommDate" TargetControlID="txtCommDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Project Commission Notes</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtProjectCommNotes" AutoComplete="off" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3" style="display: none;">
                            <div class="col-12 mb-3">
                                <h5 class="text-uppercase mb-0">Government Sales Inc</h5>
                                <small>Government Sales Inc Amount is dependent on Net Eq Price</small>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Commission Rate</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCommissionRate" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Commission Amount($)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtCommissionAmount" AutoComplete="off" runat="server" Enabled="false" Text="0" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Commission Cheque #</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCommissionChequeNo" AutoComplete="off" MaxLength="255" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Sent</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCommissionDateSent" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender22" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtCommissionDateSent" TargetControlID="txtCommissionDateSent"></asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3">
                            <div class="col-12 mb-3">
                                <h5 class="text-uppercase mb-0">Shipping Info</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Shipper</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipper" runat="server" DataTextField="CompanyName" DataValueField="ShipperID"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Shipping Commitment*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShippingComit" runat="server">
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
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipDate" AutoPostBack="true" AutoComplete="off" runat="server" OnTextChanged="txtShipDate_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender23" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipDate" TargetControlID="txtShipDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label class="text-danger">Ship To Arrive*</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipToArrive" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender24" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipToArrive" TargetControlID="txtShipToArrive"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Arrival Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtArrivalDate" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender25" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtArrivalDate" TargetControlID="txtArrivalDate"></asp:CalendarExtender>
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
                        </div>
                        <div class="row border-top pt-3" style="display: none;">
                            <div class="col-12 mb-3">
                                <h5 class="text-uppercase mb-0">SpaceMiser Royalty Info (@2%)</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>S.M Cost</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtSMCost" autocomplete="off" MaxLength="15" Text="0" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);" onchange="CalSpaceMiser()"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Royl. Amount $</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtRoyalAmount" autocomplete="off" MaxLength="15" Text="0" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Cheque #</label>
                                    <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtCheq" autocomplete="off" MaxLength="15" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Paid</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDatePaid" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender26" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDatePaid" TargetControlID="txtDatePaid"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtConRoyalAmount" autocomplete="off" MaxLength="15" Text="0" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade pt-2" id="sdTab" role="tabpanel" aria-labelledby="contact-tab">
                        <div class="col-sm-12">
                            <h5 class="text-uppercase">Shop Drawing Information</h5>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="GvShpDrg" runat="server" DataKeyNames="sDrgNum" AutoGenerateColumns="False"
                                EnableModelValidation="True" Height="100%"
                                OnRowEditing="GvShpDrg_RowEditing" OnRowUpdating="GvShpDrg_RowUpdating" OnRowCancelingEdit="GvShpDrg_RowCancelingEdit"
                                ShowFooter="True" AllowPaging="True" OnPageIndexChanging="GvShpDrg_PageIndexChanging" OnRowCommand="GvShpDrg_RowCommand" Style="margin-top: 0px" OnRowDeleting="GvShpDrg_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Dwg Num (Autogen)" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgNum" runat="server" Text='<%# Eval("sDrgNum") %>' Width="140px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgNum" runat="server" Width="140px" Text='<%# Eval("sDrgNum") %>' ReadOnly="True"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgNum" Width="140px" runat="server" ReadOnly="True" Enabled="false"></asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dwg Sent to RCD" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgSentToRCD" runat="server" Text='<%#Eval("sDrgSentToRCD") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgSentToRCD" runat="server" Text='<%#Eval("sDrgSentToRCD") %>' Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgSentToRCD" TargetControlID="txtDrgSentToRCD">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgSentToRCD" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender12" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgSentToRCD" TargetControlID="FtxtDrgSentToRCD">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DwgJobID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgJID" runat="server" Width="100%" Text='<%#Eval("sDrgJID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgJID" runat="server" Width="100%" Text='<%# Eval("sDrgJID") %>' ReadOnly="True"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtJobID" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DwgWantDate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgWantDate" runat="server" Width="100%" Text='<%# Eval("sDrgWantDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgWantDate" runat="server" Width="100%" Text='<%# Eval("sDrgWantDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgWantDate" TargetControlID="txtDrgWantDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgWantDate" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgWantDate" TargetControlID="FtxtDrgWantDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DwgPromisedDate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgPromisedDate" runat="server" Text='<%# Eval("sDrgPromiseDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgPromisedDate" runat="server" Width="100%" Text='<%# Eval("sDrgPromiseDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgPromisedDate" TargetControlID="txtDrgPromisedDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgPromisedDate" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgPromisedDate" TargetControlID="FtxtDrgPromisedDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DwgExpecApprDate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgExpectedApprovalDate" runat="server" Text='<%# Eval("sDrgExpecApprovalDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgExpectedApprovalDate" runat="server" Width="100%" Text='<%#Eval("sDrgExpecApprovalDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgExpectedApprovalDate" TargetControlID="txtDrgExpectedApprovalDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgExpectedApprovalDate" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender11" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgExpectedApprovalDate" TargetControlID="FtxtDrgExpectedApprovalDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dwg App Date" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgAppDate" runat="server" Text='<%#Eval("sDrgAppDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgAppDate" runat="server" Width="100%" Text='<%#Eval("sDrgAppDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgAppDate" TargetControlID="txtDrgAppDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgAppDate" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender13" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgAppDate" TargetControlID="FtxtDrgAppDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dwg Date Followedup" HeaderStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgDateFollowedUp" runat="server" Text='<%#Eval("sDateFollowedUp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgDateFollowedUp" runat="server" Width="100%" Text='<%#Eval("sDateFollowedUp") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgDateFollowedUp" TargetControlID="txtDrgDateFollowedUp">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgDateFollowedUp" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender115" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgDateFollowedUp" TargetControlID="FtxtDrgDateFollowedUp">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dwg Next Followup Date" HeaderStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgNextFollowupDate" runat="server" Text='<%#Eval("sNextFolowupDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgNextFollowupDate" runat="server" Width="100%" Text='<%#Eval("sNextFolowupDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgNextFollowupDate" TargetControlID="txtDrgNextFollowupDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgNextFollowupDate" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender15" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgNextFollowupDate" TargetControlID="FtxtDrgNextFollowupDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Dwg Release Date" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsDateReleasedToFab" runat="server" Text='<%#Eval("sDateReleasedToFab") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDateReleasedToFab" runat="server" Width="100%" Text='<%#Eval("sDateReleasedToFab") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender116" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDateReleasedToFab" TargetControlID="txtDateReleasedToFab">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDateReleasedToFab" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender124" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDateReleasedToFab" TargetControlID="FtxtDateReleasedToFab">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Dwg Comment" HeaderStyle-Width="40%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgComment" runat="server" Text='<%# Eval("sDrgComment") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgComment" runat="server" Width="100%" Text='<%# Eval("sDrgComment") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgComment" runat="server" Width="100%"></asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="5%">
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="LinkButton2" runat="server" CommandName="update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="LinkButton3" runat="server" CommandName="cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddRecord" runat="server" Text="Add" CommandName="Insert" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm" ID="LinkButton1" runat="server" CommandName="edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            &nbsp;&nbsp;
                                 <asp:LinkButton CssClass="btn btn-info btn-danger" ID="LinkButton4" OnClientClick="return confirm('Are you sure to delete. ?');" runat="server" CommandName="delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="tab-pane fade pt-2" id="fabTab" role="tabpanel" aria-labelledby="fabrication-tab">
                        <div class="row">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Fabrication Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>FAB Project Designer</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectDesigner" DataValueField="EmployeeID" DataTextField="Abbrivation" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Fabrication Start Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabStartDate" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender31" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabStartDate" TargetControlID="txtFabStartDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>Date (Due To Canada Office)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDueToCanda" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtDueToCanda" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDueToCanda" TargetControlID="txtDueToCanda"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Fabrication End Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabtrication" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtFabtrication" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabtrication" TargetControlID="txtFabtrication"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Project Designer(Canada)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectDesCanada" DataTextField="Name" DataValueField="Name" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Manufacturing Facility</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlManuFac" DataTextField="FacilityName" DataValueField="ID" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Released</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabReleasedDate" AutoComplete="off" runat="server" AutoPostBack="true" OnTextChanged="txtFabReleasedDate_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender32" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabReleasedDate" TargetControlID="txtFabReleasedDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Status</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFabStatus" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">In Production</asp:ListItem>
                                        <asp:ListItem Value="4">Ready to Ship</asp:ListItem>
                                        <asp:ListItem Value="2">Shipped</asp:ListItem>
                                        <asp:ListItem Value="3">Arrived</asp:ListItem>
                                        <asp:ListItem Value="5">Completed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReviewedBy" runat="server" DataTextField="Name" DataValueField="EmployeeID" onchange="SetReviewByDropDown()"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label>Expected Arrival Date from China</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtExpectedArrivalDatefromChina" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender33" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtExpectedArrivalDatefromChina" TargetControlID="txtExpectedArrivalDatefromChina"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Purchased Items</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPurchasedItems" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="O">Ordered</asp:ListItem>
                                        <asp:ListItem Value="R">Received</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group">
                                    <%--<label>Release</label>--%>
                                    <asp:Button runat="server" ID="btnRelease" CssClass="btn btn-primary btn-sm mb-3" Text="Release" Enabled="false" OnClientClick="return confirm('Are you sure to Release.?');" OnClick="btnRelease_Click" />
                                    <asp:Button runat="server" ID="btnRollback" CssClass="btn btn-danger btn-sm mb-3" Text="Rollback" Enabled="false" OnClientClick="return confirm('Are you sure to Rollback.?');" OnClick="btnRollback_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade pt-2" id="nesTab" role="tabpanel" aria-labelledby="nesting-tab">
                        <div class="row">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Nesting Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Start Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtReleasetoNesting" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtReleasetoNesting" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReleasetoNesting" TargetControlID="txtReleasetoNesting"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Completion Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtProjectReleasedToShop" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtProjectReleasedToShop" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProjectReleasedToShop" TargetControlID="txtProjectReleasedToShop"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Project Status(Nesting)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNestingStatus" runat="server">
                                        <asp:ListItem Value="8">Select</asp:ListItem>
                                        <asp:ListItem Value="0">Not started</asp:ListItem>
                                        <asp:ListItem Value="1">In Progress</asp:ListItem>
                                        <asp:ListItem Value="2">Completed</asp:ListItem>
                                        <asp:ListItem Value="3">Shipment within 4 weeks</asp:ListItem>
                                        <asp:ListItem Value="4">(P.O / Drawings) Not Received</asp:ListItem>
                                        <asp:ListItem Value="5">On Hold</asp:ListItem>
                                        <asp:ListItem Value="6">Used from Stock</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade pt-2" id="Model" role="tabpanel" aria-labelledby="Model">
                        <div class="col-12">
                            <div class="col-12">
                                <div class="form-group">
                                    <label id="lblText_1" class="boldtext">
                                    </label>
                                    <asp:Label ID="lblModel" runat="server">
                                    </asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="input-group-prepend p-1">
                            <button runat="server" data-toggle="modal" data-target="#dialog6" class="btn btn-primary btn-sm" data-backdrop="static" data-keyboard="false" href="#" type="button">
                                Show Model Info
                            </button>
                        </div>
                        <!-- Modal -->
                        <div class="modal fade" id="dialog6" tabindex="-1" aria-labelledby="exampleModalLabel6" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-scrollable modal-xl">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel6">Model Info</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body ul-model-info">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <b>
                                                    <label>Conveyor</label></b>
                                                <asp:Literal ID="chk5_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                            </div>
                                            <div class="col-md-4">
                                                <b>
                                                    <label>SDT</label></b>
                                                <asp:Literal ID="chk1_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                <b>
                                                    <label>CDT</label></b>
                                                <asp:Literal ID="chk2_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                <b>
                                                    <label>Sink</label></b>
                                                <asp:Literal ID="chk3_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                            </div>
                                            <div class="col-md-4">
                                                <b>
                                                    <label>Tray Make Up</label></b>
                                                <asp:Literal ID="chk6_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                            </div>
                                            <div class="col-md-4">
                                                <b>
                                                    <label>Tite Turn Unit</label></b>
                                                <asp:Literal ID="chk7_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                            </div>
                                            <div class="col-md-4">
                                                <b>
                                                    <label>RET</label></b>
                                                <asp:Literal ID="chk4_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                            </div>
                                            <div class="col-md-4">
                                                <b>
                                                    <label>Miselleneous</label></b>
                                                <asp:Literal ID="chk8_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                            </div>
                                            <div class="col-md-4">
                                                <b>
                                                    <label>Show Conveyor</label></b>
                                                <asp:Literal ID="chk9_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                            </div>
                                        </div>
                                        <input type="hidden" id="Hidden1" runat="server" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- <asp:Panel ID="Panel2" runat="server" CssClass="ReportsModalPopup" Width="90%" Height="80%">
                            <div class="position-relative h-100">
                                <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton1" runat="server" ImageUrl="../images/closebtnCircle.png"
                                    AlternateText="Close Popup" ToolTip="Close Popup" OnClick="btnOpen_Click" />
                                <div class="overflow-auto h-100">
                                    <div class="">
                                        <div class=" d-flex flex-row flex-wrap  pt-3">
                                            <div class="flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>Conveyor</label></b>
                                                    <asp:Literal ID="chk5_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>
                                            <div class="flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>SDT</label></b>
                                                    <asp:Literal ID="chk1_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>
                                            <div class=" flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>CDT</label></b>
                                                    <asp:Literal ID="chk2_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>
                                            <div class="flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>Sink</label></b>
                                                    <asp:Literal ID="chk3_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>

                                            <div class="flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>Tray Make Up</label></b>
                                                    <asp:Literal ID="chk6_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>
                                            <div class="flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>Tite Turn Unit</label></b>
                                                    <asp:Literal ID="chk7_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>
                                            <div class="flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>RET</label></b>
                                                    <asp:Literal ID="chk4_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>


                                            <div class="flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>Miselleneous</label></b>
                                                    <asp:Literal ID="chk8_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>
                                            <div class="flex-grow-1 p-2">
                                                <div class="form-group">
                                                    <b>
                                                        <label>Show Conveyor</label></b>
                                                    <asp:Literal ID="chk9_PopUp" runat="server" Mode="Transform" Text=""></asp:Literal>
                                                </div>
                                            </div>
                                            <input type="hidden" id="Hidden1" runat="server" value="" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Show Model Info"></asp:LinkButton>--%>
                        <%--<asp:LinkButton ID="bindModels" runat="server" OnClick="btnOpen_Click" ></asp:LinkButton>--%>

                        <div class="col-12">
                            <div class="col-12">
                                <div class="form-group">
                                    <label id="lblText_1" class="boldtext"></label>
                                    <%-- <label id="lblText_2"></label>--%>
                                </div>
                            </div>
                        </div>
                        <%-- <div class="col-12">
                            <div class="col-12">
                                <div class="form-group">
                                    <label id="lblText_2"></label>
                                </div>
                            </div>
                    </div>--%>
                        <div class="col-12">
                            <div class="row pt-3 custom-checkbox-align">
                                <div class="col-sm-6 col-md-1">
                                    <div class="form-group">
                                        <b>
                                            <label>Conveyor</label></b>
                                        <asp:CheckBoxList ID="chk5" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-1">
                                    <div class="form-group">
                                        <b>
                                            <label>SDT</label></b>
                                        <asp:CheckBoxList ID="chk1" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-1">
                                    <div class="form-group">
                                        <b>
                                            <label>CDT</label></b>
                                        <asp:CheckBoxList ID="chk2" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-1">
                                    <div class="form-group">
                                        <b>
                                            <label>Sink</label></b>
                                        <asp:CheckBoxList ID="chk3" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-2">
                                    <div class="form-group">
                                        <b>
                                            <label>Tray Make Up</label></b>
                                        <asp:CheckBoxList ID="chk6" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-2">
                                    <div class="form-group">
                                        <b>
                                            <label>Tite Turn Unit</label></b>
                                        <asp:CheckBoxList ID="chk7" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-1">
                                    <div class="form-group">
                                        <b>
                                            <label>RET</label></b>
                                        <asp:CheckBoxList ID="chk4" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-1">
                                    <div class="form-group">
                                        <b>
                                            <label>Miselleneous</label></b>
                                        <asp:CheckBoxList ID="chk8" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-2">
                                    <div class="form-group">
                                        <b>
                                            <label>Show Conveyor</label></b>
                                        <asp:CheckBoxList ID="chk9" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <%-- <div class="col-sm-6 col-md-1">
                                <div class="form-group">
                                    <b>
                                        <label>Show Conveyor</label></b>
                                    <asp:CheckBoxList ID="chk10" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>--%>
                                <input type="hidden" id="hdchk" runat="server" value="" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <script language="javascript" type="text/javascript">

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

                $(document).ready(function () {
                    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
                    bindEnterKey();
                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindEnterKey);
                });

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
                    //Display the new URL without any querystrings.
                    //alert(document.URL);
                }
                function GetConsultantRepDetails() {
                    var e = document.getElementById('<%=ddlConsultantRep.ClientID%>');
                            var param = { Repid: e.value };
                            $.ajax({
                                url: "FrmProject.aspx/GetConsultantRepDetails",
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

                        function ShowPopupConsultantRep() {
                            $("#dialog3").dialog({
                                title: "Consultant Rep Information",
                                width: 757,
                                height: 430,
                                buttons: {
                                    Close: function () {
                                        $(this).dialog('close')
                                    }
                                },
                                modal: true
                            });
                        };

                        function GetOriginationRepDetails() {
                            var e = document.getElementById('<%=ddlOrgRep.ClientID%>');
                    var param = { Repid: e.value };
                    $.ajax({
                        url: "../SalesManagement/FrmProject.aspx/GetOriginationRepDetails",
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

                function ShowPopupOriginationRep() {
                    $("#dialog4").dialog({
                        title: "Origination Rep Information",
                        width: 757,
                        height: 430,
                        buttons: {
                            Close: function () {
                                $(this).dialog('close')
                            }
                        },
                        modal: true
                    });
                };

                function GetDestinationRepDetails() {
                    var e = document.getElementById('<%=ddlDesRep.ClientID%>');
                    var param = { Repid: e.value };
                    $.ajax({
                        url: "../SalesManagement/FrmProject.aspx/GetDestinationRepDetails",
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
                function ShowPopupDestinationRep() {
                    $("#dialog5").dialog({
                        title: "Destination Rep Information",
                        width: 757,
                        height: 430,
                        buttons: {
                            Close: function () {
                                $(this).dialog('close')
                            }
                        },
                        modal: true
                    });
                };

                function GetDealerDetails() {
                    var e = document.getElementById('<%=ddlDealer.ClientID%>');
                    var param = { DealerID: e.value };
                    $.ajax({
                        url: "../SalesManagement/FrmProject.aspx/GetDealerDetails",
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

                function ShowPopupDealer() {
                    $("#dialog2").dialog({
                        title: "Dealer Information",
                        width: 757,
                        height: 430,
                        buttons: {
                            Close: function () {
                                $(this).dialog('close')
                            }
                        },
                        modal: true
                    });
                };

                function GetConsultantDetails() {
                    var e = document.getElementById('<%=ddlConsultant.ClientID%>');
                    var param = { ConsultantID: e.value };
                    $.ajax({
                        url: "../SalesManagement/FrmProject.aspx/GetConsultantDetails",
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

                function ShowPopupConsultant() {
                    $("#dialog1").dialog({
                        title: "Consultant Information",
                        width: 757,
                        height: 430,
                        buttons: {
                            Close: function () {
                                $(this).dialog('close')
                            }
                        },
                        modal: true
                    });
                };

                function GetCustomerPage() {
                    window.location.href = "../ContactManagement/FrmCustomers.aspx";
                }

      <%--  function GetCustomerDetails() {
            //var param = { CustomerID: $('#<%=ddlCustomer.ClientID%>').val() };
               var e = document.getElementById('<%=ddlCustomer.ClientID%>');
            var param = { CustomerID: e.value };           
            $.ajax({
                url: "../SalesManagement/FrmProject.aspx/GetCustomerDetails",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                   const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {
                        if (key == "CompanyName") {
                            document.getElementById('lblCustCompanyName').innerHTML = value;
                        }
                        else if (key == "StreetAddress") {
                           document.getElementById('lblCustStreetAddress').innerHTML = value;
                        }
                        else if (key == "City") {
                            document.getElementById('lblCustCity').innerHTML = value;
                        }
                        else if (key == "Country") {
                            document.getElementById('lblCustCountry').innerHTML = value;
                        }
                        else if (key == "State") {
                            document.getElementById('lblCustState').innerHTML = value;
                        }
                        else if (key == "TollFree") {
                           document.getElementById('lblCustTollFree').innerHTML = value;
                        }
                        else if (key == "TollFax") {
                           document.getElementById('lblCustTollFax').innerHTML = value;
                        }
                        else if (key == "MainPhone") {
                           document.getElementById('lblCustMainPhone').innerHTML = value;
                        }
                        else if (key == "MainFax") {
                          document.getElementById('lblCustMainFax').innerHTML = value;
                        }
                        else if (key == "RepName") {
                            document.getElementById('lblCustSales').innerHTML = value;
                        }
                        else if (key == "Branch") {
                            document.getElementById('lblCustServiceRep').innerHTML = value;
                        }                        
                    }
                )
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
            return false;
        };--%>
                function ShowPopupCustomer() {
                    $("#dialog").dialog({
                        title: "Customer Information",
                        width: 757,
                        height: 430,
                        buttons: {
                            Close: function () {
                                $(this).dialog('close')
                            }
                        },
                        modal: true
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



                //});

                //var Rep = $('#<%= ddlConsultantRep.ClientID %>').val();
                // alert(Rep);


                function getCalc() {
                    var EqPrice = document.getElementById('<%=txtEqPrice.ClientID%>').value;
                    let EqpriceWithoutComma = eval(parseFloat(EqPrice.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(EqpriceWithoutComma)) EqpriceWithoutComma = 0.00;
                    var disperc = eval(parseFloat(document.getElementById('<%=txtEqDiscount.ClientID%>').value)).toFixed(2);
                    if (isNaN(disperc)) disperc = 0.00;
                    document.getElementById('<%=txtEqDiscount.ClientID%>').value = disperc;
                    var DisAmount = (EqpriceWithoutComma * disperc / 100).toFixed(2);
                    if (isNaN(DisAmount)) DisAmount = 0.00;
                    document.getElementById('<%=txtEqDisAmount.ClientID%>').value = DisAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var NetEqPrice = (EqpriceWithoutComma - DisAmount).toFixed(2);
                    if (isNaN(NetEqPrice)) NetEqPrice = 0.00;
                    document.getElementById('<%=txtNetEqPrice.ClientID%>').value = NetEqPrice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var Freight = document.getElementById('<%=txtFreight.ClientID%>').value;
                    let FreightWithoutcomma = eval(parseFloat(Freight.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(FreightWithoutcomma)) FreightWithoutcomma = 0.00;
                    document.getElementById('<%=txtFreight.ClientID%>').value = Freight.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var Installation = document.getElementById('<%=txtInstall.ClientID%>').value;
                    let Installationwithoutcomma = eval(parseFloat(Installation.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(Installationwithoutcomma)) Installationwithoutcomma = 0.00;
                    document.getElementById('<%=txtInstall.ClientID%>').value = Installation.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var ExWarranty = document.getElementById('<%=txtExWarranty.ClientID%>').value;
                    let ExWarrantywithoutcomma = eval(parseFloat(ExWarranty.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(ExWarrantywithoutcomma)) ExWarrantywithoutcomma = 0.00;
                    document.getElementById('<%=txtExWarranty.ClientID%>').value = ExWarranty.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var NetAmount = parseFloat((parseFloat(NetEqPrice) + parseFloat(FreightWithoutcomma) + parseFloat(Installationwithoutcomma) + parseFloat(ExWarrantywithoutcomma))).toFixed(2);
                    if (isNaN(NetAmount)) NetAmount = 0.00;
                    document.getElementById('<%=txtNetAmount.ClientID%>').value = NetAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var HST = document.getElementById('<%=txtHST.ClientID%>').value;
                    let HSTWithoutcomma = eval(parseFloat(HST.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(HSTWithoutcomma)) HSTWithoutcomma = 0.00;
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
                    var Disc = document.getElementById('<%=txtDiscount.ClientID%>').value;
                    if (document.getElementById('<%=txtDiscount.ClientID%>').value > 0) {

                        let Discount = parseFloat((NetAmount * Disc) / 100).toFixed(2);
                        document.getElementById('<%=txtAmount.ClientID%>').value = Discount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    }
                    var CommRate = eval(parseFloat(document.getElementById('<%=ddlRate.ClientID%>').value)).toFixed(2);
                    // if(document.getElementById('<%=ddlRate.ClientID%>').value > 0)
                    if (CommRate > 0) {
                        let CommAmt = parseFloat(NetEqPrice * CommRate / 100).toFixed(2);
                        document.getElementById('<%=txtCommAmount.ClientID%>').value = CommAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    }
                    var GovSalesComm = document.getElementById('<%=txtCommissionRate.ClientID%>').value;
                    if (document.getElementById('<%=txtCommissionRate.ClientID%>').value > 0) {
                        let GovtSalesCommAmt = parseFloat(NetEqPrice * GovSalesComm / 100).toFixed(2);
                        document.getElementById('<%=txtCommissionAmount.ClientID%>').value = GovtSalesCommAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    }

                }
                function getPer() {
                    var EqPrice = document.getElementById('<%=txtEqPrice.ClientID%>').value;
                    let EqpriceWithoutComma = eval(parseFloat(EqPrice.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(EqpriceWithoutComma)) EqpriceWithoutComma = 0.00;
                    var DisAmt = eval(parseFloat(document.getElementById('<%=txtEqDisAmount.ClientID%>').value.replace(/,/g, ''))).toFixed(2);
                    var DisPerc = (DisAmt / EqpriceWithoutComma * 100).toFixed(2);
                    if (isNaN(DisPerc)) DisPerc = 0.00;
                    document.getElementById('<%=txtEqDiscount.ClientID%>').value = DisPerc;
                    var NetEqPrice = (EqpriceWithoutComma - DisAmt).toFixed(2);
                    if (isNaN(NetEqPrice)) NetEqPrice = 0.00;
                    document.getElementById('<%=txtNetEqPrice.ClientID%>').value = NetEqPrice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var Freight = document.getElementById('<%=txtFreight.ClientID%>').value;
                    let FreightWithoutcomma = eval(parseFloat(Freight.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(FreightWithoutcomma)) FreightWithoutcomma = 0.00;
                    document.getElementById('<%=txtFreight.ClientID%>').value = Freight.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var Installation = document.getElementById('<%=txtInstall.ClientID%>').value;
                    let Installationwithoutcomma = eval(parseFloat(Installation.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(Installationwithoutcomma)) Installationwithoutcomma = 0.00;
                    document.getElementById('<%=txtInstall.ClientID%>').value = Installation.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var ExWarranty = document.getElementById('<%=txtExWarranty.ClientID%>').value;
                    let ExWarrantywithoutcomma = eval(parseFloat(ExWarranty.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(ExWarrantywithoutcomma)) ExWarrantywithoutcomma = 0.00;
                    document.getElementById('<%=txtExWarranty.ClientID%>').value = ExWarranty.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var NetAmount = parseFloat((parseFloat(NetEqPrice) + parseFloat(FreightWithoutcomma) + parseFloat(Installationwithoutcomma) + parseFloat(ExWarrantywithoutcomma))).toFixed(2);
                    if (isNaN(NetAmount)) NetAmount = 0.00;
                    document.getElementById('<%=txtNetAmount.ClientID%>').value = NetAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    var HST = document.getElementById('<%=txtHST.ClientID%>').value;
                    let HSTWithoutcomma = eval(parseFloat(HST.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(HSTWithoutcomma)) HSTWithoutcomma = 0.00;
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
                    var Disc = document.getElementById('<%=txtDiscount.ClientID%>').value;
                    if (document.getElementById('<%=txtDiscount.ClientID%>').value > 0) {
                        let Discount = parseFloat((NetAmount * Disc) / 100).toFixed(2);
                        document.getElementById('<%=txtAmount.ClientID%>').value = Discount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    }
                    var CommRate = eval(parseFloat(document.getElementById('<%=ddlRate.ClientID%>').value)).toFixed(2);
                    // if(document.getElementById('<%=ddlRate.ClientID%>').value > 0)
                    if (CommRate > 0) {
                        let CommAmt = parseFloat(NetEqPrice * CommRate / 100).toFixed(2);
                        document.getElementById('<%=txtCommAmount.ClientID%>').value = CommAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    }
                    var GovSalesComm = document.getElementById('<%=txtCommissionRate.ClientID%>').value;
                    if (document.getElementById('<%=txtCommissionRate.ClientID%>').value > 0) {
                        let GovtSalesCommAmt = parseFloat(NetEqPrice * GovSalesComm / 100).toFixed(2);
                        document.getElementById('<%=txtCommissionAmount.ClientID%>').value = GovtSalesCommAmt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                    }
                }
                function getDis() {
                    var Discount = document.getElementById('<%=txtDiscount.ClientID%>').value;
                    let DisWithoutcomma = eval(parseFloat(Discount.replace(/,/g, ''))).toFixed(2);
                    if (isNaN(DisWithoutcomma)) DisWithoutcomma = 0.00;
                    let NetAmount = document.getElementById('<%=txtNetAmount.ClientID%>').value;
                    let NetAmountwithoutcomma = eval(parseFloat(NetAmount.replace(/,/g, ''))).toFixed(2);
                    let Amount = parseFloat(parseFloat(NetAmountwithoutcomma) * parseFloat(DisWithoutcomma) / 100).toFixed(2);
                    document.getElementById('<%=txtAmount.ClientID%>').value = Amount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                function CalculateCommission() {
                    var NetEqPrice = document.getElementById('<%=txtNetEqPrice.ClientID%>').value;
                    let NetEqPricewithoutcomma = eval(parseFloat(NetEqPrice.replace(/,/g, ''))).toFixed(2);
                    var ComType = eval(parseFloat(document.getElementById('<%=ddlRate.ClientID%>').value)).toFixed(2);
                    let commamount = (parseFloat(NetEqPricewithoutcomma) * parseFloat(ComType) / 100).toFixed(2);
                    document.getElementById('<%=txtCommAmount.ClientID%>').value = commamount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }

                function CashDiscount() {
                    debugger;
                    var ct = "8";
                    var amount;
                    var NetEqPrice = document.getElementById('<%=txtNetEqPrice.ClientID%>').value;
                    document.getElementById('<%=txtCashDiscountPer.ClientID%>').value = ct;
                    var c = (parseFloat(NetEqPrice) * parseFloat(ct) / 100);
                    //amount = parseFloat(NetEqPrice) * parseFloat(ct) / 100;
                    //alert(c);
                    //alert(ct);
                    //alert(c);
                    document.getElementById('<%=txtCashDiscountAmount.ClientID%>').value = c;
                    //document.getElementById('<%=txtAmountForComision.ClientID%>').value = (parseFloat(NetEqPrice) * parseFloat(document.getElementById('<%=txtCashDiscountAmount.ClientID%>').value).toFixed(2);
                }

           <%--function CalcCommissionRate(id) {
            const ids = [856, 916, 613, 576, 665, 912, 813, 859, 657, 476, 712, 466, 464, 776, 860, 731, 74, 855, 586, 570, 896, 671, 307, 560, 897, 560, 933, 680];
            var newid = parseInt(id);         
            if (ids.includes(newid)) {
                var ct;
                if (document.getElementById('<%=txtCashDiscountPer.ClientID%>').value == "") {
                    ct = 8;
                }
                else {
                    ct = document.getElementById('<%=txtCashDiscountPer.ClientID%>').value;
                }
                
                var amount;
              
                var EqPrice = document.getElementById('<%=txtNetEqPrice.ClientID%>').value;
                let EqpriceWithoutComma = eval(parseFloat(EqPrice.replace(/,/g, ''))).toFixed(2);
                if (isNaN(EqpriceWithoutComma)) EqpriceWithoutComma = 0.00;
                var disperc = eval(parseFloat(document.getElementById('<%=txtEqDiscount.ClientID%>').value)).toFixed(2);
                if (isNaN(disperc)) disperc = 0.00;
                document.getElementById('<%=txtEqDiscount.ClientID%>').value = disperc;
                var DisAmount = (EqpriceWithoutComma * ct / 100).toFixed(2);
                var AmtRec = (EqpriceWithoutComma - DisAmount).toFixed(2);

                document.getElementById('<%=txtCashDiscountAmount.ClientID%>').value = DisAmount;
                document.getElementById('<%=txtCashDiscountPer.ClientID%>').value = "8";
                document.getElementById('<%=txtAmountForComision.ClientID%>').value = AmtRec;

            }
            else {
                document.getElementById('<%=txtCashDiscountAmount.ClientID%>').value = "";
                document.getElementById('<%=txtCashDiscountPer.ClientID%>').value = "";
                document.getElementById('<%=txtAmountForComision.ClientID%>').value = "";
            }
           }--%>

                function GetCommission() {
                    const ids = [856, 916, 613, 576, 665, 912, 813, 859, 657, 476, 712, 466, 464, 776, 860, 731, 74, 855, 586, 570, 896, 671, 307, 560, 897, 560, 933, 680];
                    var newid = parseInt(id);
                    if (ids.includes(newid)) {
                        var ct;
                        if (document.getElementById('<%=txtCashDiscountPer.ClientID%>').value == "") {
                            ct = 8;
                        }
                        else {
                            ct = document.getElementById('<%=txtCashDiscountPer.ClientID%>').value;
                        }

                        var amount;

                        var EqPrice = document.getElementById('<%=txtNetEqPrice.ClientID%>').value;
                        let EqpriceWithoutComma = eval(parseFloat(EqPrice.replace(/,/g, ''))).toFixed(2);
                        if (isNaN(EqpriceWithoutComma)) EqpriceWithoutComma = 0.00;
                        var disperc = eval(parseFloat(document.getElementById('<%=txtEqDiscount.ClientID%>').value)).toFixed(2);
                        if (isNaN(disperc)) disperc = 0.00;
                        document.getElementById('<%=txtEqDiscount.ClientID%>').value = disperc;
                        var DisAmount = (EqpriceWithoutComma * ct / 100).toFixed(2);
                        var AmtRec = (EqpriceWithoutComma - DisAmount).toFixed(2);

                        document.getElementById('<%=txtCashDiscountAmount.ClientID%>').value = DisAmount;
                        document.getElementById('<%=txtCashDiscountPer.ClientID%>').value = "8";
                        document.getElementById('<%=txtAmountForComision.ClientID%>').value = AmtRec;

                    }
                    else {
                        document.getElementById('<%=txtCashDiscountAmount.ClientID%>').value = "";
                        document.getElementById('<%=txtCashDiscountPer.ClientID%>').value = "";
                        document.getElementById('<%=txtAmountForComision.ClientID%>').value = "";
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
                    document.getElementById('<%=ddlMfgFacility.ClientID%>').value = 2;
                }
                else {
                    document.getElementById('<%=ddlMfgFacility.ClientID%>').value = 1;
                }
            }
            function CheckPNumber() {
                var param = { PNumber: $("#<%=ddlPNumber.ClientID %>").val() };

                $.ajax({
                    url: "FrmProject.aspx/HideDuplicatePNumber",
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
                var param = { PNumber: $("#<%=ddlPNumber.ClientID %>").val() };
                //alert(param);
                $.ajax({
                    url: "FrmProject.aspx/AutoFillPNumber",
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
                                document.getElementById('<%=ddlConveyorType.ClientID%>').value = this.ConveyorTypeID;
                                document.getElementById('<%=ddlOrgRep.ClientID%>').value = this.OriginRepID;
                                document.getElementById('<%=ddlConsultantRep.ClientID%>').value = this.ConsultRepID;
                                document.getElementById('<%=ddlDesRep.ClientID%>').value = this.RepID;
                                document.getElementById('<%=ddlConsultant.ClientID%>').value = this.ConsultantID;
                                document.getElementById('<%=ddlModel.ClientID%>').value = this.ModelID;
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

            function CalSpaceMiser() {
                var SMCost = eval(parseFloat(document.getElementById('<%=txtSMCost.ClientID%>').value).toFixed(2));
                document.getElementById('<%=txtRoyalAmount.ClientID%>').value = SMCost * 0.02;
            }

            function SetCSSFirst() {
                document.getElementById("giTab").className = 'tab-pane fade show active pt-2';
            }

            function SetCSS() {
                document.getElementById("sdTab").className = 'tab-pane fade show active pt-2';
                document.getElementById("giTab").className = 'tab-pane fade pt-2';
                document.getElementById("gi-tab").className = 'nav-link';
                document.getElementById("sd-tab").className = 'nav-link active';
            }

            function SetICSCSS() {
                document.getElementById("icsTab").className = 'tab-pane fade show active pt-2';
                document.getElementById("giTab").className = 'tab-pane fade  pt-2';
                document.getElementById("gi-tab").className = 'nav-link';
                document.getElementById("ics-tab").className = 'nav-link active';

            }

            function SetCSSFab() {

                document.getElementById("fabTab").className = 'tab-pane fade show active pt-2';
                document.getElementById("giTab").className = 'tab-pane fade pt-2';
                document.getElementById("gi-tab").className = 'nav-link';
                document.getElementById("fabrication-tab").className = 'nav-link active';
            }
            </script>
            <CR:CrystalReportViewer ID="rptSalesUsaCan" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
            <script type="text/javascript">
                $(document).ready(function () {
                    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
                });

                function PageLoaded(sender, args) {
                    DDLName();
                }
                $.when.apply($, PageLoaded).then(function () {
                    DDLName();
                });

                function DDLName() {
                    $('#<%=ddlPNumber.ClientID%>').chosen();
                    $('#<%=ddlOASentTo.ClientID%>').chosen();
                    $('#<%=ddlProjectManager.ClientID%>').chosen();
                    <%--$('#<%=ddlProjectType.ClientID%>').chosen();--%>
                   <%--$('#<%=ddlExistingJobno.ClientID%>').chosen();--%>
                    $('#<%=ddlCustomer.ClientID%>').chosen();
                    $('#<%=ddlConsultantRep.ClientID%>').chosen();
                    $('#<%=ddlOrgRep.ClientID%>').chosen();
                    $('#<%=ddlDesRep.ClientID%>').chosen();
                    $('#<%=ddlDealer.ClientID%>').chosen();
                    $('#<%=ddlConsultant.ClientID%>').chosen();
                    $('#<%=ddlConveyorType.ClientID%>').chosen();
                    $('#<%=ddlModel.ClientID%>').chosen();
                    $('#<%=ddlPreparedBy.ClientID%>').chosen();
                    $('#<%=ddlReviewedByAI.ClientID%>').chosen();
                    $('#<%=ddlReviewedByHO.ClientID%>').chosen();
                    $('#<%=ddlInstallationBy.ClientID%>').chosen();
                    $('#<%=ddlInstallerA.ClientID%>').chosen();
                    $('#<%=ddlInstallerB.ClientID%>').chosen();
                    $('#<%=ddlInstallerC.ClientID%>').chosen();
                    $('#<%=ddlCurrency.ClientID%>').chosen();
                    $('#<%=ddlFOB.ClientID%>').chosen();
                    $('#<%=ddlTerm.ClientID%>').chosen();
                    $('#<%=ddlRate.ClientID%>').chosen();
                    $('#<%=ddlShipper.ClientID%>').chosen();
                    $('#<%=ddlcountry.ClientID%>').chosen();
                    $('#<%=ddlState.ClientID%>').chosen();
                    $('#<%=ddlProjectDesigner.ClientID%>').chosen();
                    $('#<%=ddlManuFac.ClientID%>').chosen();
                    $('#<%=ddlReviewedBy.ClientID%>').chosen();
                    $('#<%=ddlNestingStatus.ClientID%>').chosen();
                    $('#<%=ddlShippingComit.ClientID%>').chosen();
                    $('#<%=ddlShippingStatus.ClientID%>').chosen();
                    $('#<%=ddlprojectstatus.ClientID%>').chosen();
                    $('#<%=ddlFabStatus.ClientID%>').chosen();
                    $('#<%=ddlPurchasedItems.ClientID%>').chosen();
                    $('#<%=ddlPurchasedItemsCAD.ClientID%>').chosen();
                }

                function Comma(Num) {
                    Num += '';
                    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
                    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
                    x = Num.split('.');
                    x1 = x[0];
                    x2 = x.length > 1 ? '.' + x[1] : '';
                    var rgx = /(\d+)(\d{3})/;
                    while (rgx.test(x1))
                        x1 = x1.replace(rgx, '$1' + ',' + '$2');
                    return x1 + x2;
                }
                function GetValue() {
                    //debugger;
                    document.getElementById('lblText_1').innerHTML = '';
                    var chkBoxCategory = new Array();
                    chkBoxCategory.push(document.getElementById('<%= chk5 .ClientID %>'));
                    chkBoxCategory.push(document.getElementById('<%= chk1 .ClientID %>'));
                    chkBoxCategory.push(document.getElementById('<%= chk2 .ClientID %>'));
                    chkBoxCategory.push(document.getElementById('<%= chk3 .ClientID %>'));
                    chkBoxCategory.push(document.getElementById('<%= chk6 .ClientID %>'));
                    chkBoxCategory.push(document.getElementById('<%= chk7 .ClientID %>'));
                    chkBoxCategory.push(document.getElementById('<%= chk4 .ClientID %>'));
                    chkBoxCategory.push(document.getElementById('<%= chk8 .ClientID %>'));
                    chkBoxCategory.push(document.getElementById('<%= chk9 .ClientID %>'));
                    for (var i_1 = 0; i_1 < chkBoxCategory.length; i_1++) {

                        var options = chkBoxCategory[i_1].getElementsByTagName('input');
                        var listOfSpans = chkBoxCategory[i_1].getElementsByTagName('span');
                        var checkBoxSelectedItems = new Array();
                        var checkBoxSelectedText = new Array();

                        for (var i_2 = 0; i_2 < options.length; i_2++) {
                            if (options[i_2].checked) {
                                checkBoxSelectedItems.push(listOfSpans[i_2].attributes["JSvalue"].value);
                                var ins = '';
                                if (document.getElementById('lblText_1').innerHTML != '') {
                                    ins = ',';
                                }
                                checkBoxSelectedText.push(ins + listOfSpans[i_2].attributes["JSText"].value);
                            }
                        }

                        document.getElementById('lblText_1').innerHTML += checkBoxSelectedText;

                    }

                    var lblText = document.getElementById('lblText_1').innerHTML.replaceAll(",/", "/");
                    lblText = lblText.replaceAll(",", "/");
                    lblText = lblText.replaceAll("//", "/");
                    document.getElementById('lblText_1').innerHTML = lblText;
                    var temp = true;
                    return temp;
                }
            </script>
            <%--<script type="text/javascript">
window.onbeforeunload = function(e) {  
var message = "You have not saved your changes. Do you wish to leave and abandon your changes or stay on this page so you can save?";  
e = e || window.event;  
if (CheckUnSavedChanges(document.forms['aspnetForm']))
{  
if (e) {  
e.returnValue = message;  
}  
return message;}  
}



function CheckUnSavedChanges() {  
    for (var i = 0; i < document.forms['aspnetForm'].elements.length; i++) {
        var element = document.forms['aspnetForm'].elements[i];
        var type = element.type;  
        if (type == "checkbox" || type == "radio") {  
            if (element.checked != element.defaultChecked) {  
                    return true;  
                }  
                    }  
        else if (type == "text" || type == "textarea") {  
            if (element.value != element.defaultValue) {  
                return true;  
            }  
        }  
        else if (type == "select-one" || type == "select-multiple") {  
            for (var j = 0; j < element.options.length; j++) {  
                if (element.options[j].selected != element.options[j].defaultSelected) {  
                    return true;  
                }  
            }  
        }  
    }  
    return false;  
}  
</script>--%>
            <asp:HiddenField ID="hfShipToArriveDate" runat="server" Value="-1" />
            <asp:HiddenField ID="hfShipToArriveDateFillDetail" runat="server" Value="-1" />
            <asp:HiddenField ID="HfJObID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfReleased" runat="server" Value="" />
            <asp:HiddenField ID="hfCurrentUser" runat="server" Value="" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnInf" />
            <asp:PostBackTrigger ControlID="btnCuspack" />
            <asp:PostBackTrigger ControlID="btnAcknoledgement" />
            <asp:PostBackTrigger ControlID="btnWarrntyLetter" />
        </Triggers>
    </asp:UpdatePanel>
    <%--<asp:UpdateProgress ID="UpdateProgressloader" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
<ProgressTemplate>            
<div class="spinner">
    <div class="center-div">
        <div class="inner-div">
            <div class="loader"></div>
        </div>
    </div>
</div>   
</ProgressTemplate>
</asp:UpdateProgress>--%>
</asp:Content>
