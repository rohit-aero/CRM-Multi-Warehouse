<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmProposals.aspx.cs" Inherits="SalesManagement_FrmProposals" EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col pt-2 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Proposal Information
       <%-- <span id="spn" visible="false" runat="server" style="background:#ffff; padding: .1rem 1rem; font-size: 1.2rem;border: 1px solid #0b5fa1;">  --%>
                                <asp:Label ID="lblPM" Visible="false" CssClass="btn btn-primary btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblDesRep" Visible="false" CssClass="btn btn-success btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblConsultant" Visible="false" CssClass="btn btn-info btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <%--<asp:Label ID="lblDealer"  Visible="false" CssClass="btn btn-info btn-sm" style="cursor:no-drop;" runat="server" Text=""></asp:Label>--%>
                                <%--</span>--%>
                            </h4>
                            <%--  <div class="col-sm-6 justify-content-center" id="dvMsg" runat="server" visible="false">
            <strong class="text-center"><asp:Label Visible="false" runat="server" CssClass="alert alert-success d-block py-1 mb-0"  ID="lblMsg"></asp:Label></strong>
            </div> --%>
                        </div>
                    </div>
                </div>
                <div class="row pb-3">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                        <div class="row">
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Proposal Name</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Panel ID="PName" runat="server" Style="height: 200px; overflow: scroll; display: none;"></asp:Panel>
                                        <asp:Panel ID="PanelPName" runat="server" DefaultButton="SearchPNameButton">
                                            <asp:TextBox ID="txtSearchPName" placeholder="Type Proposal Number" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEventForPName(event)" onkeypress="return EnterEventForPName(event)">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchPName"
                                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PName"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProposal" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchPNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPName_TextChanged" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Proposal Number</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:Panel ID="PNumber" runat="server" Style="height: 200px; overflow: scroll; display: none;">
                                        </asp:Panel>
                                        <asp:Panel ID="PanelN" runat="server" DefaultButton="SearchPNumberButton">
                                            <asp:TextBox ID="txtSearchPNum" placeholder="Type Proposal Number" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEvent(event)" onkeypress="return EnterEvent(event)">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchPNum"
                                                CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="PNumber"
                                                ServicePath="../AutoComplete.asmx" ServiceMethod="SearchProposalNumber" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchPNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="txtSearchPNum_TextChanged" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-sm-12">
                                <label class="mb-0">&nbsp;</label>
                            </div>
                            <div class="col-auto">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-sm" Text="Add Proposal" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSiteVisit" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnSiteVisit_Click" Text="Site Visit" />
                                <asp:Button ID="btnCADReport" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnCADReport_Click" Text="Engineering" />
                                <asp:Button ID="btnSearchProposal" runat="server" Visible="false" CssClass="btn btn-secondary btn-sm" OnClick="btnSearchProposal_Click" Text="Search" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" Text="Cancel" />

                            </div>
                        </div>

                    </div>
                </div>
                <div class="row bg-white border-bottom">
                    <div class="col-6 col-sm-4 col-md-3 col-lg mt-2">
                        <div class="form-group chosenFullWidth">
                            <label class="text-danger">Industry*</label>
                            <asp:DropDownList ID="ddlIndustry" runat="server" DataTextField="name" DataValueField="id" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg mt-2">
                        <div class="form-group chosenFullWidth">
                            <label class="text-danger">Source Lead*</label>
                            <asp:DropDownList ID="ddlSourceLead" runat="server" DataTextField="LeadName" DataValueField="LeadID" CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlSourceLead_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg mt-2">
                        <div class="form-group chosenFullWidth">
                            <label class="text-danger">Source Lead Reference*</label>
                            <asp:DropDownList ID="ddlSourceleadref" runat="server" CssClass="form-control form-control-sm">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg mt-2">
                        <div class="form-group chosenFullWidth">
                            <label class="text-danger">Conveyor Prime Spec*</label>
                            <asp:DropDownList ID="ddlConveyorPrimeSpec" runat="server" DataTextField="Conveyorname"
                                DataValueField="Conveyorid" CssClass="form-control form-control-sm"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlConveyorPrimeSpec_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <asp:Panel ID="PnlConveyorPrimeSpec" runat="server" Visible="false">
                            <div class="form-group">
                                <label>Other</label>
                                <asp:TextBox ID="txtConveyorSpec" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg mt-2">
                        <div class="form-group chosenFullWidth">
                            <label>Conveyor Alternate</label>
                            <asp:DropDownList ID="ddlConveyorAlternate" runat="server" DataTextField="ConveyorAlternatename" DataValueField="ConveyorAlternateid"
                                CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlConveyorAlternate_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <asp:Panel ID="pnlConveyorAlternate" runat="server" Visible="false">
                            <div class="form-group">
                                <label>Other</label>
                                <asp:TextBox ID="txtConveyorAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div class="row bg-white shadow-sm border-bottom">
                    <div class="col">
                        <ul class="nav nav-tabs customTabs" id="myTab" role="tablist">
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link active" id="pf-tab" data-toggle="tab" href="#pfTab" role="tab" aria-controls="home" aria-selected="true"><span>Proposal Form <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <%-- <li class="nav-item" role="presentation">
    <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="contact" aria-selected="false"><span>Warewash Info <i class="fas fa-arrow-right"></i></span></a>
  </li>--%>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="Proposal-tab" data-toggle="tab" href="#ProposalTab" role="tab" aria-controls="Proposal" aria-selected="false"><span>Proposal Drawings <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="Quote-tab" data-toggle="tab" href="#quote" role="tab" aria-controls="quote" aria-selected="false"><span>Quotes Info <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="Model-tab" data-toggle="tab" href="#Model" role="tab" aria-controls="Model" aria-selected="false"><span>Model <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="Followup-tab" data-toggle="tab" href="#followup" role="tab" aria-controls="followup" aria-selected="false"><span>Follow Up <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade show active pt-2" id="pfTab" role="tabpanel" aria-labelledby="pf-tab">
                    <div class="col-12">
                        <h5 class="text-uppercase">Proposal Information</h5>
                        <div class="row">
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label class="text-danger">Proposal Number*</label>
                                    <asp:TextBox ID="txtProNO" runat="server" CssClass="form-control form-control-sm" MaxLength="50" Enabled="false" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Proposal Date</label>
                                    <asp:TextBox ID="txtProDate" runat="server" Enabled="false" autocomplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProDate" TargetControlID="txtProDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Type*</label>
                                    <asp:DropDownList ID="ddlProjectType" runat="server" DataTextField="JobType" DataValueField="id" CssClass="form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Existing Job#</label>
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <asp:Label ID="lblExistingJobDetails" runat="server" Visible="false"></asp:Label>
                                        <asp:Button ID="btnExistingJob" runat="server" CssClass="btn btn-primary btn-sm" Text="Add" Enabled="false" OnClick="btnExistingJob_Click" />
                                    </div>
                                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                                        PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
                                    </asp:ModalPopupExtender>
                                    <asp:Panel ID="Panel1" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="40%" Height="50%">
                                        <div class="position-relative h-100">
                                            <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" ImageUrl="../images/closebtnCircle.png"
                                                AlternateText="Close Popup" ToolTip="Close Popup" />
                                            <div class="overflow-auto h-100">
                                                <div class="col-12">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="form-group">

                                                                <h5 class="text-uppercase text-center">P-Number:-
                                      <asp:Label ID="lblProposalNo" runat="server"></asp:Label></h5>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                                            <div class="form-group chosenFullWidth">
                                                                <label>Job ID</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-6">
                                                            <div class="form-group chosenFullWidth">
                                                                <asp:DropDownList ID="ddlExistingJobID" runat="server" CssClass="form-control form-control-sm" DataTextField="JobID" DataValueField="JobID"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-6">
                                                            <div class="form-group">
                                                                <asp:Button ID="btnAddExistingJobID" runat="server" CssClass="btn btn-primary btn-sm" Text="Add" OnClick="btnAddExistingJobID_Click" />
                                                                <asp:Button ID="btnCancelExistingJobID" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancelExistingJobID_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:Label ID="lblErrorExistingJobid" runat="server"></asp:Label>
                                                <hr />
                                                <div class="col-12">
                                                    <h5 class="text-uppercase">Existing Job Information</h5>

                                                    <div class="table-responsive">
                                                        <asp:GridView CssClass="table mainGridTable table-sm" ID="gvExistingJobID" runat="server" AutoGenerateColumns="False" DataKeyNames="ExistingJobID" OnRowDeleting="gvExistingJobID_RowDeleting"
                                                            EnableModelValidation="True" Height="100%" Style="margin-top: 0px">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Job ID" HeaderStyle-Width="40%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblJobID" runat="server" Text='<%# Eval("JobID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="5%">
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
                                        </div>
                                    </asp:Panel>
                                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Prepared By</label>
                                    <asp:DropDownList ID="ddlPreparedBy" runat="server" DataTextField="Name" DataValueField="EmployeeID" CssClass="form-control form-control-sm"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group srRadiosBtns">
                                    <label>Order For</label>
                                    <asp:RadioButtonList ID="rdbOrderFor" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Selected="True">Aerowerks</asp:ListItem>
                                        <asp:ListItem Value="2">TragenFlex</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Job ID</label>
                                    <div class="input-group input-group-sm">
                                        <asp:TextBox ID="txtJobID" runat="server" Enabled="false" CssClass="form-control form-control-sm" autocomplete="off"></asp:TextBox>
                                        <div class="input-group-prepend p-1">
                                            <asp:ImageButton ID="imgJobID" runat="server" Height="20px" ImageUrl="~/images/goto.png" OnClick="imgJobID_Click" Width="20px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group">
                                    <label class="text-danger">Project Name*</label>
                                    <asp:TextBox ID="txtProjectName" runat="server" CssClass="form-control form-control-sm" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Country</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList DataTextField="Country" DataValueField="CountryID" ID="ddlCountry" CssClass="form-control form-control-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <asp:ImageButton ID="ImgCountry" runat="server" Height="20px" ImageUrl="~/images/goto.png" OnClick="ImgCountry_Click" Width="20px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>State</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList ID="ddlState" DataValueField="StateID" DataTextField="State" runat="server" CssClass="form-control form-control-sm" onchange="SetStateAb();"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <asp:DropDownList ID="ddlStateAb" DataValueField="StateID" onchange="SetState();" DataTextField="Sabb" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                        </div>
                                        <div class="input-group-prepend p-1">
                                            <asp:ImageButton ID="ImgState" runat="server" Height="20px" ImageUrl="~/images/goto.png" OnClick="ImgState_Click" Width="20px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>City</label>
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                       <asp:TextBox ID="txtCity" autocomplete="off" runat="server" MaxLength="50" CssClass="form-control form-control-sm"></asp:TextBox>
                                        <div class="input-group-prepend p-1" style="display:none">
                                            <asp:ImageButton ID="ImgCity0" runat="server" Height="20px" ImageUrl="~/images/goto.png" OnClick="ImgCity_Click" Width="20px"  />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div class="input-group-prepend pr-3">Proposal Drawing Required</div>
                                        <asp:CheckBox ID="chkDwgReq" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div class="input-group-prepend pr-3">Sales Lead From Hobart ISS</div>
                                        <asp:CheckBox ID="chkHobartISS" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div class="input-group-prepend pr-3">Quotation Required</div>
                                        <asp:CheckBox ID="chkQuoteReq" CssClass="text" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div class="input-group-prepend pr-3">Is Gill Marketing Project</div>
                                        <asp:CheckBox ID="chkGillProject" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div class="input-group-prepend pr-3">11400</div>
                                        <asp:CheckBox ID="chk11400" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3" id="pfEquipmentPrice" runat="server">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Equipment Price</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Currency</label>
                                    <asp:DropDownList DataTextField="Currency" DataValueField="CurrencyID" ID="ddlCurruncy" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Equipment Price($)</label>
                                    <asp:TextBox ID="txtEqPrice" runat="server" Style="text-align: right" MaxLength="15" autocomplete="off" onkeyup="javascript:this.value=Comma(this.value);" onchange="getCalc();getPer()" CssClass="form-control form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Discount(%)</label>
                                    <asp:TextBox ID="txtDisPer" runat="server" Style="text-align: right" MaxLength="15" autocomplete="off" onkeyup="javascript:this.value=Comma(this.value);" onchange="getCalc()" CssClass="form-control form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Discount Amount($)</label>
                                    <asp:TextBox ID="txtDisAmount" runat="server" Style="text-align: right" MaxLength="15" autocomplete="off" onkeyup="javascript:this.value=Comma(this.value);" onchange="getPer()" CssClass="form-control form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Net Eq Price($)</label>
                                    <asp:TextBox ID="txtNetEqPrice" runat="server" MaxLength="15" onchange="getCheckedRadio();getCalc();getPer()" onkeyup="javascript:this.value=Comma(this.value);" Style="text-align: right"
                                        CssClass="form-control form-control-sm exempt" autocomplete="off" Enabled="false" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Freight($)</label>
                                    <asp:TextBox ID="txtFreight" runat="server" Style="text-align: right" MaxLength="15" autocomplete="off" onkeyup="javascript:this.value=Comma(this.value);" onchange="getCalc();getPer()" CssClass="form-control form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2 d-flex align-items-center">
                                <div class="form-group mb-0">
                                    <div class="input-group input-group-sm d-flex align-items-center">
                                        <div class="input-group-prepend pr-3">Price Protection Required</div>
                                        <asp:CheckBox ID="chkProtection" onchange="ChangeColor();" runat="server" />
                                    </div>
                                </div>                                
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group">
                                    <label>Special Instructions</label>
                                    <asp:TextBox ID="txtSpecialInstr" runat="server" MaxLength="250" autocomplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Installation($)</label>
                                    <asp:TextBox ID="txtInstall" runat="server" Style="text-align: right" MaxLength="15" autocomplete="off" onkeyup="javascript:this.value=Comma(this.value);" onchange="getCalc();getPer()" CssClass="form-control form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Total Amount($)</label>
                                    <asp:TextBox ID="txtTotalAmount" runat="server" Style="text-align: right" MaxLength="15" autocomplete="off" onchange="getCalc();getPer()"
                                        CssClass="form-control form-control-sm exempt" Enabled="false" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">General Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Order Probability</label>
                                    <asp:DropDownList DataTextField="Status" DataValueField="OrderProbabilityID" ID="ddlOrderProbability" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Current Status</label>
                                    <asp:DropDownList DataTextField="Status" DataValueField="CurrentStatusID" ID="ddlStatus" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>CAD Project Designer</label>
                                    <asp:DropDownList DataTextField="Name" DataValueField="EmployeeID" ID="ddlDesigner" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Consultant*</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList DataTextField="CompanyName" DataValueField="ConsultantID" ID="ddlConsultant" onchange="GetConsultant()" CssClass="form-control form-control-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConsultant_SelectedIndexChanged"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <button type="button" data-toggle="modal" data-target="#dialog1" onclick="GetConsultantDetails()" clientidmode="Static" runat="server" class="btn border-0 p-0"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog1" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel1">Consultant</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Company Name:</td>
                                                                <td>
                                                                    <span id="lblConsultantCompName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Street Address</td>
                                                                <td>
                                                                    <span id="lblConsultantStreetAdd"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">City:</td>
                                                                <td>
                                                                    <span id="lblConsultantCity"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Country:</td>
                                                                <td>
                                                                    <span id="lblConsultantCountry"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">State:</td>
                                                                <td>
                                                                    <span id="lblConsultantState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone:</td>
                                                                <td>
                                                                    <span id="lblConsultantPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Toll Free:</td>
                                                                <td>
                                                                    <span id="lblConsultantTollFree"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Fax:</td>
                                                                <td>
                                                                    <span id="lblConsultantFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Toll Fax:</td>
                                                                <td>
                                                                    <span id="lblConsultantTollFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Rep Name:</td>
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
                                    <label>Consultant Member</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList ID="ddlConsultantMember" CssClass="form-control form-control-sm" runat="server" onchange="SetMemberValue();" DataTextField="ConsultantMemberName" DataValueField="ConsultantMemberID"></asp:DropDownList>

                                        <div class="input-group-prepend p-1">
                                            <button runat="server" data-toggle="modal" data-target="#dialog11" onclick="GetConsultantMemberDetails()" clientidmode="Static" type="button" class="btn border-0 p-0"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog11" tabindex="-1" aria-labelledby="exampleModalLabel11" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel11">Consultant Member Info</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Job Title:</td>
                                                                <td>
                                                                    <span id="lblConstMemJobTitle"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Name:</td>
                                                                <td>
                                                                    <span id="lblConstMemFirstName"></span>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Telephone Extention:</td>
                                                                <td>
                                                                    <span id="lblConstMemTelExt"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">E-Mail:</td>
                                                                <td>
                                                                    <a id="lblConstMememail"></a>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Direct Line:</td>
                                                                <td>
                                                                    <span id="lblConstMemDirectLine"></span>
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
                                    <label class="text-danger">Consultant Rep*</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList DataTextField="RepName" DataValueField="RepID" ID="ddlConsultantRep" CssClass="form-control form-control-sm" runat="server" onchange="GetConsultantRep()"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <button type="button" data-toggle="modal" onclick="GetConsultantRepDetails()" data-target="#dialog3" clientidmode="Static" runat="server" class="btn border-0 p-0"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog3" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel">Consultant Rep</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Name:</td>
                                                                <td>
                                                                    <span id="lblFirstName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Abbreviation:</td>
                                                                <td>
                                                                    <span id="lblAbb"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">State:</td>
                                                                <td>
                                                                    <span id="lblRepState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone Mail:</td>
                                                                <td>
                                                                    <span id="lblPhoneMail"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone:</td>
                                                                <td>
                                                                    <span id="lblPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Cell Phone:</td>
                                                                <td>
                                                                    <span id="lblCellPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Fax:</td>
                                                                <td>
                                                                    <span id="lblFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Email:</td>
                                                                <td>
                                                                    <a id="lblEmail"></a>
                                                                    <%-- <span id="lblEmail"></span>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Status:</td>
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
                                    <label>Dealer</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList DataTextField="CompanyName" DataValueField="DealerID" ID="ddlDealer" CssClass="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDealer_SelectedIndexChanged"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <button runat="server" data-toggle="modal" data-target="#dialog2" onclick="GetDealerDetails()" clientidmode="Static" type="button" class="btn border-0 p-0"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog2" tabindex="-1" aria-labelledby="exampleModalLabel2" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel2">Dealer Info</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">FederalID:</td>
                                                                <td>
                                                                    <span id="lblFederalID"></span>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Company Name:</td>
                                                                <td>
                                                                    <span id="lblCompanyName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Group Name:</td>
                                                                <td>
                                                                    <span id="lblGroupName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Street Address:</td>
                                                                <td>
                                                                    <span id="lblStreetAddress"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">City:</td>
                                                                <td>
                                                                    <span id="lblCity"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Country:</td>
                                                                <td>
                                                                    <span id="lblCountry"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">State:</td>
                                                                <td>
                                                                    <span id="lblState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Toll Free:</td>
                                                                <td>
                                                                    <span id="lblTollFree"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Toll Fax:</td>
                                                                <td>
                                                                    <span id="lblTollFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone:</td>
                                                                <td>
                                                                    <span id="lblDealerPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Fax:</td>
                                                                <td>
                                                                    <span id="lblDealerFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Rep Name:</td>
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
                                    <label>Dealer Member</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList DataTextField="DealerMember" DataValueField="ContactID" ID="ddlDealerMember" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <button runat="server" data-toggle="modal" data-target="#dialog10" onclick="GetDealerMemberDetails()" clientidmode="Static" type="button" class="btn border-0 p-0"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog10" tabindex="-1" aria-labelledby="exampleModalLabel10" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel10">Dealer Member Info</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Title:</td>
                                                                <td>
                                                                    <span id="lblddlMemberTitle"></span>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Name:</td>
                                                                <td>
                                                                    <span id="lblddlMemberFirstName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone:</td>
                                                                <td>
                                                                    <span id="lblddlMemberPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Fax:</td>
                                                                <td>
                                                                    <span id="lblddlMemberFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">E-Mail:</td>
                                                                <td>
                                                                    <a id="lblddlMemberEmail"></a>
                                                                    <%-- <span id="lblddlMemberEmail"></span>--%>
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
                                        <asp:DropDownList ID="ddlOriginationRep" CssClass="form-control form-control-sm" runat="server" DataTextField="RepName" DataValueField="RepID"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <button runat="server" data-toggle="modal" data-target="#dialog4" onclick="GetOriginationRepDetails()" clientidmode="Static" type="button" class="btn border-0 p-0"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog4" tabindex="-1" aria-labelledby="exampleModalLabel4" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel4">Origination Rep Info</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Name:</td>
                                                                <td>
                                                                    <span id="lblOrigFirstName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Abbreviation:</td>
                                                                <td>
                                                                    <span id="lblOrigAbb"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">State:</td>
                                                                <td>
                                                                    <span id="lblOrigState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone Mail:</td>
                                                                <td>

                                                                    <span id="lblOrigPhoneMail"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone:</td>
                                                                <td>
                                                                    <span id="lblOrigPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Cell Phone:</td>
                                                                <td>
                                                                    <span id="lblOrigCellPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Fax:</td>
                                                                <td>
                                                                    <span id="lblOrigFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold">Email:</td>
                                                                <td>
                                                                    <a id="lblOrigEmail"></a>
                                                                    <%-- <span id="lblOrigEmail"></span>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Status:</td>
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
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Competitor</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList DataTextField="CompetitorName" DataValueField="CompetitorID" ID="ddlCompetitor" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <asp:ImageButton ID="ImgCompetitor" runat="server" Height="20px" ImageUrl="~/images/goto.png" OnClick="ImgCompetitor_Click" Width="20px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Destination Rep*</label>
                                    <div class="input-group input-group-sm d-flex align-items-center flex-nowrap">
                                        <asp:DropDownList ID="ddlDestRep" CssClass="form-control form-control-sm" runat="server" AutoPostBack="true" DataTextField="RepName" DataValueField="RepID" OnSelectedIndexChanged="ddlDestRep_SelectedIndexChanged"></asp:DropDownList>
                                        <div class="input-group-prepend p-1">
                                            <button runat="server" data-toggle="modal" data-target="#dialog5" onclick="GetDestinationRepDetails()" clientidmode="Static" type="button" class="btn border-0 p-0"><i class="far fa-address-card fa-2x"></i></button>
                                        </div>
                                        <!-- Modal -->
                                        <div class="modal fade" id="dialog5" tabindex="-1" aria-labelledby="exampleModalLabel5" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel5">Destination Rep Info</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <table>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Name:</td>
                                                                <td>
                                                                    <span id="lblDestFirstName"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Abbreviation:</td>
                                                                <td>
                                                                    <span id="lblDestAbb"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">State:</td>
                                                                <td>
                                                                    <span id="lblDestState"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone Mail:</td>
                                                                <td>
                                                                    <span id="lblDestPhoneMail"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Phone:</td>
                                                                <td>
                                                                    <span id="lblDestPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Cell Phone:</td>
                                                                <td>
                                                                    <span id="lblDestCellPhone"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Fax:</td>
                                                                <td>
                                                                    <span id="lblDestFax"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Email:</td>
                                                                <td>
                                                                    <a id="lblDestEmail"></a>
                                                                    <%--<span id="lblDestEmail"></span>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" style="font-weight: bold; width: 200px">Status:</td>
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
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Prime Spec</label>
                                    <asp:DropDownList ID="ddlPrimeSpec" runat="server" DataTextField="CompetitorName" Enabled="false" DataValueField="CompetitorID" CssClass="form-control form-control-sm"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Est Want Date</label>
                                    <asp:TextBox ID="txtEstWantDate" autocomplete="off" runat="server" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtEstWantDate" TargetControlID="txtEstWantDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Reason For Lost</label>
                                    <asp:DropDownList ID="ddlReason" runat="server" CssClass="form-control form-control-sm">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem>Service</asp:ListItem>
                                        <asp:ListItem>Quality</asp:ListItem>
                                        <asp:ListItem>Price</asp:ListItem>
                                        <asp:ListItem>Design</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Alternate</label>
                                    <asp:DropDownList ID="ddlAlternate1" runat="server" DataTextField="CompetitorName" DataValueField="CompetitorID" CssClass="form-control form-control-sm"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Alternate 2</label>
                                    <asp:DropDownList ID="ddlAlternate2" runat="server" DataTextField="CompetitorName" DataValueField="CompetitorID" CssClass="form-control form-control-sm"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group chosenFullWidth">
                                    <label>Alternate 3</label>
                                    <asp:DropDownList ID="ddlAlternate3" runat="server" DataTextField="CompetitorName" DataValueField="CompetitorID" CssClass="form-control form-control-sm"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-6 col-lg-4">
                                <div class="form-group">
                                    <label>Comments</label>
                                    <asp:TextBox ID="txtComments" runat="server" autocomplete="off" MaxLength="150" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top pt-3">

                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Other Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Conveyor Model</label>
                                    <asp:DropDownList DataTextField="Model" DataValueField="ModelID" ID="ddlModel" Enabled="false" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Conveyor Type</label>
                                    <asp:DropDownList DataTextField="ConveyorType" DataValueField="ConveyorTypeID" Enabled="false" ID="ddlConType" CssClass="form-control form-control-sm" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <%--<div class="col-6 col-sm-4 col-md-3 col-lg-2">
<div class="form-group chosenFullWidth">
<label>Model Combination</label>    
  <asp:CheckBoxList ID="chkModels" DataTextField="name" DataValueField="id" ToolTip="abbr"  runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
</div>
</div>--%>
                        </div>
                        <div class="row border-top pt-3">
                            <div class="col-sm-12 d-flex align-items-center">
                                <h5 class="text-uppercase">Spec Credit Info</h5>
                                <div class="ml-auto">
                                    <div class="form-group mb-0">
                                        <button type="button" id="btnClearSpec" class="btn btn-outline-primary btn-sm" onclick="ClearSpecCredit()"><i class="fas fa-redo-alt"></i>Reset</button>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group srRadiosBtns">
                                    <label>Spec Credit</label>
                                    <asp:RadioButtonList ID="rdbSpecCredit" onchange="getCheckedRadio()" runat="server" RepeatDirection="Horizontal" Enabled="false">
                                        <asp:ListItem Value="1">Not Approved</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Pending</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Spec Credit(%)</label>
                                    <asp:DropDownList DataTextField="Percentage" DataValueField="SpecCreditPercentID" Enabled="false" onchange="getCheckedRadio()" ID="ddlSpecCredit" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Spec Credit Amount</label>
                                    <asp:TextBox ID="txtSpecAmount" runat="server" autocomplete="off" MaxLength="15" CssClass="form-control form-control-sm" Enabled="false" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group ">
                                    <label>Consultant Rep</label>
                                    <asp:Label ID="txtSpecConsultantRep" runat="server" autocomplete="off" CssClass="form-control form-control-sm" BackColor="#e9ecef"></asp:Label>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Consultant</label>
                                    <asp:Label ID="txtSpecConsultant" runat="server" autocomplete="off" CssClass="form-control form-control-sm" BackColor="#e9ecef"></asp:Label>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Spec Credit Check#</label>
                                    <asp:TextBox ID="txtSpecCheque" CssClass="form-control form-control-sm" MaxLength="15" Enabled="false" autocomplete="off" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Date Spec Credit Paid</label>
                                    <asp:TextBox ID="txtSpecPaid" autocomplete="off" runat="server" MaxLength="15" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtSpecPaid" TargetControlID="txtSpecPaid"></asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<div class="tab-pane fade pt-2" id="profile" role="tabpanel" aria-labelledby="contact-tab">
          
       <div class="col-12">
          
           <h5 class="text-uppercase">Warewash Info</h5>
                                                <div class="row">
                                                            <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Dishwasher Prime Spec</label>
                                                                    <asp:DropDownList ID="ddlDishPrimeSpec" runat="server" DataTextField="name" DataValueField="id"
                                                                          CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlDishPrimeSpec_SelectedIndexChanged">                                                                       
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <asp:Panel ID="pnlDishPrimeSpec" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtDishPrimeSpec" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                                    </asp:Panel>
                                                            </div>                                                             
                                                            <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Dishwasher Alternate</label>
                                                                    <asp:DropDownList ID="ddlDishAlternate" runat="server"   DataTextField="name" DataValueField="id" 
                                                                        CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlDishAlternate_SelectedIndexChanged" >
                                                                        <asp:ListItem></asp:ListItem>                                                                       
                                                                    </asp:DropDownList>                                                                
                                                                </div>
                                                                 <asp:Panel ID="pnlDishAlternate" runat="server"  Style="display:none;">
                                                                 <div class="form-group">
                                                                     <label>Other</label>
                                                                   <asp:TextBox ID="txtDishAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>                                                                   
                                                                </div>
                                                                     </asp:Panel>
                                                            </div>
                                                             <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Waste Equipment Prime Spec</label>
                                                                    <asp:DropDownList ID="ddlWastePrimeSpec" runat="server"   DataTextField="name" 
                                                                        DataValueField="id"  CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlWastePrimeSpec_SelectedIndexChanged">                                                                     
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <asp:Panel ID="pnlWastePrimeSpec" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtWastePrimeSpec" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                            </asp:Panel>
                                                            </div> 
                                                               
                                                     <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Waste Equipment Alternate</label>
                                                                    <asp:DropDownList ID="ddlWasteAlternate" runat="server"   DataTextField="name" AutoPostBack="True" OnSelectedIndexChanged="ddlWasteAlternate_SelectedIndexChanged"
                                                                        DataValueField="id"  CssClass="form-control form-control-sm">
                                                                   </asp:DropDownList>
                                                                </div>
                                                                <asp:Panel ID="PanelWasteEqAlternate" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtWasteEqAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                            </asp:Panel>
                                                            </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Dish Machine Type</label>
                                                             
                                                                           <asp:DropDownList ID="ddlDishType" runat="server" DataTextField="name" DataValueField="id" 
                                                                          CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlDishType_SelectedIndexChanged">                                                                      
                                                                    </asp:DropDownList>
                                                                
                                                                 
                                                                </div>
                                                                  <asp:Panel ID="pnlDishType" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtDishType" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                                      </asp:Panel>
                                                            </div>
                                <div class="col-sm-3">
                                        <div class="form-group chosenFullWidth">
                                            <label>Dish Machine Type Alternate</label>
                                            <asp:DropDownList ID="ddlDishTypeAlternate" runat="server" DataTextField="name" DataValueField="id" 
                                                CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlDishTypeAlternate_SelectedIndexChanged">                                                                     
                                            </asp:DropDownList>
                                        </div>
                                            <asp:Panel ID="pnlDishTypeAlternate" runat="server" Style="display:none;">
                                        <div class="form-group">
                                            <label>Other</label>
                                            <asp:TextBox ID="txtDishTypeAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        </div>
                                                </asp:Panel>
                                    </div>

                                            <div class="col-sm-3">
                                        <div class="form-group chosenFullWidth">
                                            <label>Waste Equipment Type</label>
                                            <asp:DropDownList ID="ddlWasteEqType" runat="server" DataTextField="name" DataValueField="id"   
                                                CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlWasteEqType_SelectedIndexChanged">
                                              
                                            </asp:DropDownList>
                                        </div>
                                            <asp:Panel ID="pnlWasteEqType" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtWasteEqType" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                                     </asp:Panel>
                                                            </div>

                                                    <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Waste Equipment Type Alternate</label>
                                                                    <asp:DropDownList ID="ddlWasteEqTypeAlternate" runat="server"  DataTextField="name" DataValueField="id"   
                                                                        CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlWasteEqTypeAlternate_SelectedIndexChanged">
                                                                       
                                                                    </asp:DropDownList>
                                                                </div>
                                                                 <asp:Panel ID="PanelWasteEqType" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtWasteEqTypeAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                                     </asp:Panel>
                                                            </div>
                                                                                                               
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Dish Machine Model</label>
                                                                    <asp:DropDownList ID="ddlDishModel" runat="server" DataTextField="name" DataValueField="id" 
                                                                         CssClass="form-control form-control-sm"  AutoPostBack="True" OnSelectedIndexChanged="ddlDishModel_SelectedIndexChanged">                                                                       
                                                                    </asp:DropDownList>
                                                                </div>
                                                                   <asp:Panel ID="pnlDishModel" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtDishModel" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                                       </asp:Panel>
                                                            </div>

                                                       <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Dish Machine Model Alternate</label>
                                                                    <asp:DropDownList ID="ddlDishModelAlternate" runat="server" DataTextField="name" DataValueField="id" 
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlDishModelAlternate_SelectedIndexChanged"
                                                                         CssClass="form-control form-control-sm">                                                                       
                                                                    </asp:DropDownList>
                                                                </div>
                                                                   <asp:Panel ID="pnlDishModelAlternate"  runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtDishModelAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                                       </asp:Panel>
                                                            </div>

                                                         <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Waste Equipment Model</label>
                                                                    <asp:DropDownList ID="ddlWasteEqModel" runat="server" DataTextField="name" DataValueField="id" 
                                                                        CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlWasteEqModel_SelectedIndexChanged">
                                                              
                                                                    </asp:DropDownList>
                                                                </div>
                                                                  <asp:Panel ID="pnlWasteEqModel" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtWasteEqModel" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                            </asp:Panel>
                                                            </div>
                                                      
                                                    <div class="col-sm-3">
                                                                <div class="form-group chosenFullWidth">
                                                                    <label>Waste Equipment Model Alternate</label>
                                                                    <asp:DropDownList ID="ddlWasteEqModelAlternate" runat="server" DataTextField="name" DataValueField="id"  
                                                                        CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlWasteEqModelAlternate_SelectedIndexChanged">
                                                                        
                                                                    </asp:DropDownList>
                                                                </div>
                                                                  <asp:Panel ID="PanelWasteEqModelAlternate" runat="server" Style="display:none;">
                                                                <div class="form-group">
                                                                    <label>Other</label>
                                                                    <asp:TextBox ID="txtWasteEqModelAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                </div>
                                                            </asp:Panel>
                                                            </div>
                                                </div>
                                                <div class="row">
                                               <div class="col-sm-3">
                                                                                                <div class="form-group chosenFullWidth">
                                                                                                    <label>Dish Machine Style</label>
                                                                                                    <asp:DropDownList ID="ddlDishStyle" runat="server"  DataTextField="name" DataValueField="id" 
                                                                                                         CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlDishStyle_SelectedIndexChanged">                                                                     
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                  <asp:Panel ID="pnlDishStyle" runat="server" Style="display:none;">
                                                                                                <div class="form-group">
                                                                                                    <label>Other</label>
                                                                                                    <asp:TextBox ID="txtDishStyle" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                                                </div>
                                                                                                      </asp:Panel>
                                                                                            </div>
                                               <div class="col-sm-3">
                                                                                                <div class="form-group chosenFullWidth">
                                                                                                    <label>Dish Machine Style Alternate</label>
                                                                                                    <asp:DropDownList ID="ddlDishStyleAlternate" runat="server"   OnSelectedIndexChanged="ddlDishStyleAlternate_SelectedIndexChanged"
                                                                                                      AutoPostBack="True"  CssClass="form-control form-control-sm" DataTextField="name" DataValueField="id">
                                                                     
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                  <asp:Panel ID="pnlDishStyleAlternate" runat="server" Style="display:none;">
                                                                                                <div class="form-group">
                                                                                                    <label>Other</label>
                                                                                                    <asp:TextBox ID="txtDishStyleAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                                                </div>
                                                                                                      </asp:Panel>
                                                                                            </div>

                                                                                                 <div class="col-sm-3">
                                                                                                <div class="form-group chosenFullWidth">
                                                                                                    <label>Waste Equipment Style</label>
                                                                                                    <asp:DropDownList ID="ddlWasteEqStyle" runat="server"   AutoPostBack="True" OnSelectedIndexChanged="ddlWasteEqStyle_SelectedIndexChanged"
                                                                                                        CssClass="form-control form-control-sm" DataTextField="name" DataValueField="id">
                                                                     
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                  <asp:Panel ID="PanelWasteEqStyle" runat="server" Style="display:none;">
                                                                                                <div class="form-group">
                                                                                                    <label>Other</label>
                                                                                                    <asp:TextBox ID="txtWasteEqStyle" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                                                </div>
                                                                                                      </asp:Panel>
                                                                                            </div>

                                               <div class="col-sm-3">
                                                                                                <div class="form-group chosenFullWidth">
                                                                                                    <label>Waste Equipment Style Alternate</label>
                                                                                                    <asp:DropDownList ID="ddlWasteEqStyleAlternate" runat="server"  
                                                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlWasteEqStyleAlternate_SelectedIndexChanged"
                                                                                                        CssClass="form-control form-control-sm" DataTextField="name" DataValueField="id">
                                                                     
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                  <asp:Panel ID="PanelWasteEqStyleAlternate" runat="server" Style="display:none;">
                                                                                                <div class="form-group">
                                                                                                    <label>Other</label>
                                                                                                    <asp:TextBox ID="txtWasteEqStyleAlternate" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                                                                                </div>
                                                                                                      </asp:Panel>
                                                                                            </div>
                                           
                                  </div>
</div>
      </div>--%>

                <div class="tab-pane fade pt-2" id="quote" role="tabpanel" aria-labelledby="quote-tab">
                    <div class="col-12">
                        <h5 class="text-uppercase">Quotes Info</h5>
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvQuoteInfo" runat="server" AutoGenerateColumns="False"
                                EnableModelValidation="True" Height="100%" DataKeyNames="QuoteNum" OnRowCommand="gvQuoteInfo_RowCommand" OnRowDeleting="gvQuoteInfo_RowDeleting"
                                OnRowEditing="gvQuoteInfo_RowEditing" OnRowCancelingEdit="gvQuoteInfo_RowCancelingEdit" OnRowUpdating="gvQuoteInfo_RowUpdating"
                                ShowFooter="True" Style="margin-top: 0px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Quote No" HeaderStyle-Width="10%">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditItemRevisionNo" Text='<%# Eval("QuoteNum") %>' AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuoteNo" runat="server" Text='<%# Eval("QuoteNum") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFRevisionNo" AutoComplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlEditRevisionNo" CssClass="form-control form-control-sm" Text='<%# Eval("QRevType") %>' runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="N">N</asp:ListItem>
                                                <asp:ListItem Value="R">R</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRevNo" runat="server" Text='<%# Eval("QRevType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="FRevisionNo" CssClass="form-control form-control-sm" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="N">N</asp:ListItem>
                                                <asp:ListItem Value="R">R</asp:ListItem>
                                            </asp:DropDownList>

                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quote Req Date">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditQuoteReqDate" runat="server" CssClass="form-control form-control-sm" Text='<%# Eval("QuoteReqDate") %>'
                                                AutoComplete="off" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtQuoteReqDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtEditQuoteReqDate" TargetControlID="txtEditQuoteReqDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuoteReq" runat="server" Width="100%" Text='<%# Eval("QuoteReqDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtQuoteReqDate" runat="server" CssClass="form-control form-control-sm" AutoComplete="off" Width="100%"
                                                OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtQuoteReqDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtQuoteReqDate" TargetControlID="FtxtQuoteReqDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quote Req. Ack." Visible="false">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txEditQuoteReqAck" runat="server" CssClass="form-control form-control-sm" Text='<%# Eval("QuoteAckDate") %>'
                                                Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtQuoteReqAck" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txEditQuoteReqAck" TargetControlID="txEditQuoteReqAck">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuoteReqAck" runat="server" Width="100%" Text='<%# Eval("QuoteAckDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtQuoteReqAck" runat="server" CssClass="form-control form-control-sm"
                                                Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtQuoteReqAck" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtQuoteReqAck" TargetControlID="FtxtQuoteReqAck">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quote Sent">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditQuoteSent" AutoComplete="off" CssClass="form-control form-control-sm" Text='<%# Eval("QuoteSentDate") %>'
                                                runat="server" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtQuoteSent" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtEditQuoteSent" TargetControlID="txtEditQuoteSent">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuoteSent" runat="server" Width="100%" Text='<%# Eval("QuoteSentDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtQuoteSent" AutoComplete="off" CssClass="form-control form-control-sm"
                                                runat="server" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtQuoteSent" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtQuoteSent" TargetControlID="FtxtQuoteSent">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount $" FooterStyle-HorizontalAlign="Right">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditAmount" AutoComplete="off" runat="server" Text='<%# Eval("QEqPrice","{0:0,0.00}") %>' Style="text-align: right" CssClass="form-control  form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("QEqPrice","{0:0,0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtAmount" AutoComplete="off" runat="server" Style="text-align: right" onkeyup="javascript:this.value=Comma(this.value);" CssClass="form-control  form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="8%" FooterStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddRecord" OnClientClick="return QuoteAdditionWarning();" runat="server" Text="Add" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm" ID="lnkEdit" runat="server" CommandName="edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            &nbsp;&nbsp;
                                <asp:LinkButton CssClass="btn btn-info btn-danger" ID="LinkButton4" OnClientClick="return confirm('Are you sure to delete. ?');" CommandName="Delete" runat="server"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <asp:Button ID="HiddenButton" runat="server" OnClick="HiddenButton_Click" Style="display: none" />
                <div class="tab-pane fade pt-2" id="ProposalTab" role="tabpanel" aria-labelledby="Proposal-tab">
                    <div class="col-12">
                        <h5 class="text-uppercase">Proposal Drawing Information</h5>

                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="GvProDwg" runat="server" AutoGenerateColumns="False" DataKeyNames="ProDwgid"
                                EnableModelValidation="True" Height="100%" ShowFooter="True" AllowPaging="True" Style="margin-top: 0px" OnRowCommand="GvProDwg_RowCommand"
                                OnRowEditing="GvProDwg_RowEditing" OnRowUpdating="GvProDwg_RowUpdating" OnRowCancelingEdit="GvProDwg_RowCancelingEdit" OnRowDeleting="GvProDwg_RowDeleting">
                                <Columns>

                                    <asp:TemplateField HeaderText="Dwg Num (Autogen)" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgNum" runat="server" Width="140px" Text='<%#Eval("DwgNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgNum" runat="server" Width="140px" Text='<%#Eval("DwgNo") %>' ReadOnly="True"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgNum" Width="140px" runat="server" ReadOnly="True" Enabled="false"></asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eng Name" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEngName" runat="server" Width="140px" Text='<%#Eval("EmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEngName" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID"></asp:DropDownList>
                                            <asp:Label ID="lblddlEngName" runat="server" Width="140px" Text='<%#Eval("EmployeeID") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="FddlEngName" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID"></asp:DropDownList>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Req.By RCD" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgReqByRCD" runat="server" Text='<%#Eval("DateReqByRCD") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDwgReqbyRCD" runat="server" Width="100%" autocomplete="off" Text='<%#Eval("DateReqByRCD") %>' OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalDrgReqbyRCD" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDwgReqbyRCD" TargetControlID="txtDwgReqbyRCD">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDwgReqbyRCD" runat="server" autocomplete="off" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="FCalDrgReqbyRCD" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDwgReqbyRCD" TargetControlID="FtxtDwgReqbyRCD">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Req. Fwd to CAD">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDwgReqFwdtoCAD" runat="server" Width="100%" Text='<%#Eval("DateFwdToCAD") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDwgReqFwdtoCAD" runat="server" autocomplete="off" Width="100%" Text='<%#Eval("DateFwdToCAD") %>' OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalDwgReqFwdtoCAD" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDwgReqFwdtoCAD" TargetControlID="txtDwgReqFwdtoCAD">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDwgReqFwdtoCAD" runat="server" autocomplete="off" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="FCalDwgFwdtoCAD" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDwgReqFwdtoCAD" TargetControlID="FtxtDwgReqFwdtoCAD">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dwg Sent to Manager">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgSenttoManager" runat="server" Width="100%" Text='<%#Eval("DwgSentToManger") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgSenttoManager" runat="server" autocomplete="off" Width="100%" Text='<%#Eval("DwgSentToManger") %>' OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalDrgSenttoManager" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgSenttoManager" TargetControlID="txtDrgSenttoManager">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgSenttoManager" runat="server" autocomplete="off" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFDrgSenttoManager" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgSenttoManager" TargetControlID="FtxtDrgSenttoManager">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dwg Sent to RCD">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgFwdtoRCD" runat="server" Text='<%#Eval("DwgFwdToRCD") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgFwdtoRCD" runat="server" Width="100%" autocomplete="off" Text='<%#Eval("DwgFwdToRCD") %>' OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgFwdtoRCD" TargetControlID="txtDrgFwdtoRCD">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgFwdtoRCD" runat="server" autocomplete="off" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgFwdtoRCD" TargetControlID="FtxtDrgFwdtoRCD">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="40%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgComment" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgComment" runat="server" MaxLength="500" autocomplete="off" Width="100%" Text='<%#Eval("Remarks") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgComment" runat="server" MaxLength="500" autocomplete="off" Width="100%"></asp:TextBox>
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
                </div>
                <div class="tab-pane fade pt-2" id="followup" role="tabpanel" aria-labelledby="followup-tab">
                    <div class="col-12">
                        <h5 class="text-uppercase">Followup Info</h5>
                        <div class="row">
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Project Stage*</label>
                                    <asp:DropDownList ID="ddlProjectBid" runat="server" DataTextField="bidname" DataValueField="bidid"
                                        OnSelectedIndexChanged="ddlProjectBid_SelectedIndexChanged" CssClass="form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Project Manager*</label>
                                    <asp:DropDownList ID="ddlProjectManager" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID"
                                        CssClass="form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3" id="divBiddate" runat="server">
                                <asp:Panel ID="PanelBidDate" runat="server">
                                    <div class="form-group">
                                        <label>Bid Date</label>
                                        <asp:TextBox ID="txtBidDate" runat="server" autocomplete="off" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtBidDate" TargetControlID="txtBidDate"></asp:CalendarExtender>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label>App. Ship Date</label>
                                    <asp:TextBox ID="txtShipDate" runat="server" autocomplete="off" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipDate" TargetControlID="txtShipDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3 col-lg-4" id="divProjectLost" runat="server" visible="false">
                                <asp:Panel ID="pnlProjectLost" runat="server">
                                    <div class="form-group">
                                        <label>Lost Reason</label>
                                        <asp:TextBox ID="txtLostReason" autocomplete="off" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 pt-3">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="GvFollowup" runat="server" AutoGenerateColumns="False"
                                EnableModelValidation="True" Height="100%"
                                OnRowEditing="GvFollowup_RowEditing" OnRowUpdating="GvFollowup_RowUpdating" DataKeyNames="Followupid" OnRowCancelingEdit="GvFollowup_RowCancelingEdit"
                                ShowFooter="True" OnPageIndexChanging="GvFollowup_PageIndexChanging" OnRowCommand="GvFollowup_RowCommand" Style="margin-top: 0px" OnRowDeleting="GvFollowup_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Shown in Reports" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShowninreports" runat="server" Text='<%# Eval("showninreports") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShowninreports" runat="server">
                                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblddlshowninreports" runat="server" Text='<%# Eval("showninreports") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="Fddlshowninreports" runat="server">
                                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>

                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Proposal No" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProposalNo" runat="server" Text='<%# Eval("ProposalNo") %>' Visible="false" Width="140px"></asp:Label>

                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtProposalNo" runat="server" class="form-control form-control-sm" Width="140px" Text='<%# Eval("ProposalNo") %>' Visible="false" ReadOnly="True" Enabled="false"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FProposalNo" Width="140px" runat="server" ReadOnly="True" Visible="false" Enabled="false"></asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Followup With" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFollowupwith" runat="server" Text='<%#Eval("followupwith") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFollowupwith" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="S">Sales Rep</asp:ListItem>
                                                <asp:ListItem Value="D">Dealer</asp:ListItem>
                                                <asp:ListItem Value="C">Consultant</asp:ListItem>
                                                <asp:ListItem Value="I">In House</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblFollowupwithdropdown" runat="server" Text='<%# Eval("followupwith") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="FddlFollowupwith" CssClass="form-control form-control-sm" runat="server" Width="100%" AutoPostBack="false" OnSelectedIndexChanged="FddlFollowupwith_SelectedIndexChanged">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="S">Sales Rep</asp:ListItem>
                                                <asp:ListItem Value="D">Dealer</asp:ListItem>
                                                <asp:ListItem Value="C">Consultant</asp:ListItem>
                                                <asp:ListItem Value="I">In House</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="FlblFollowupwith" runat="server" Width="100%" Text='<%# Eval("followupwith") %>' Visible="false"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Followup Date" HeaderStyle-Width="9%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFollowUpDate" runat="server" Width="100%" Text='<%#Eval("followupdate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFollowupDate" class="form-control form-control-sm" AutoComplete="off" runat="server"
                                                Width="100%" Text='<%# Eval("followupdate") %>' OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CaltxtFollowupDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtFollowupDate" TargetControlID="txtFollowupDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtFollowupDate" class="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"
                                                AutoComplete="off" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtFollowupDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtFollowupDate" TargetControlID="FtxtFollowupDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Scheduled Followup Date" HeaderStyle-Width="9%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNextFollowUpDate" runat="server" Width="100%" Text='<%# Eval("nextfollowupdate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNextFollowUpDate" class="form-control form-control-sm" onchange="nextFollowUpDate(this.id);" OnBlur="validateDate(this)"
                                                AutoComplete="off" runat="server" Width="100%" Text='<%# Eval("nextfollowupdate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CaltxtNextFollowedupDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtNextFollowUpDate" TargetControlID="txtNextFollowUpDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtNextFollowedUpDate" class="form-control form-control-sm" AutoComplete="off" runat="server" OnBlur="validateDate(this)"
                                                Width="100%" onchange="nextFollowUpDate(this.id);"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtNextFollowedupDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtNextFollowedUpDate" TargetControlID="FtxtNextFollowedUpDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Followed Up Date" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFollowedUpDate" runat="server" Width="100%" Text='<%# Eval("followedupdate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFollowedupDate" class="form-control form-control-sm" AutoComplete="off" OnBlur="validateDate(this)"
                                                runat="server" Width="100%" Text='<%# Eval("followedupdate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CaltxtFollowedupDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtFollowedupDate" TargetControlID="txtFollowedupDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtFollowedupDate" class="form-control form-control-sm" runat="server" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalFtxtFollowedupDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtFollowedupDate" TargetControlID="FtxtFollowedupDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notes" ItemStyle-Width="45%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNotes" runat="server" Width="100%" Text='<%# Eval("notes") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNotes" class="form-control form-control-sm" runat="server" AutoComplete="off" Width="100%" Text='<%# Eval("notes") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtNotes" class="form-control form-control-sm" AutoComplete="off" runat="server" Width="100%"></asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Followup Type" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFollowupNature" runat="server" Text='<%#Eval("followupNature") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFollowupNature" runat="server">
                                                <asp:ListItem></asp:ListItem>

                                                <asp:ListItem Value="E">Email</asp:ListItem>
                                                <asp:ListItem Value="P">Phone</asp:ListItem>
                                                <asp:ListItem Value="T">Teams Meeting</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblFollowupNaturedropdown" runat="server" Text='<%# Eval("followupNature") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="FddlFollowupNature" CssClass="form-control form-control-sm" runat="server" Width="100%">
                                                <asp:ListItem Value=""></asp:ListItem>
                                                <asp:ListItem Value="E">Email</asp:ListItem>
                                                <asp:ListItem Value="P">Phone</asp:ListItem>
                                                <asp:ListItem Value="T">Teams Meeting</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="FlblFollowupNature" runat="server" Width="100%" Text='<%# Eval("followupNature") %>' Visible="false"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Expected PO Received Date" Visible="true" HeaderStyle-Width="9%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpectedPOReceivedDate" runat="server" Width="100%" Text='<%# Eval("expectedPOReceivedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtExpectedPOReceivedDate" class="form-control form-control-sm" AutoComplete="off" OnBlur="validateDate(this)"
                                                runat="server" Width="100%" Text='<%# Eval("expectedPOReceivedDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="Extender_ExpectedPOReceivedDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtExpectedPOReceivedDate" TargetControlID="txtExpectedPOReceivedDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtExpectedPOReceivedDate" class="form-control form-control-sm" runat="server" Width="100%" OnBlur="validateDate(this)"></asp:TextBox>
                                            <asp:CalendarExtender ID="Extender_FtxtExpectedPOReceivedDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtExpectedPOReceivedDate" TargetControlID="FtxtExpectedPOReceivedDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="5%">
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="LinkButton2" runat="server" CommandName="update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="LinkButton3" runat="server" CommandName="cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddRecord" TabIndex="0" runat="server" Text="Add" CommandName="Insert" />
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
            <%--</div></div>--%>
            <div class="row mx-0 pt-2">
                <div class="col-12">
                </div>
            </div>
            <asp:HiddenField ID="hdfPM" runat="server" Value="0" />
            <asp:HiddenField ID="hfCurrentUser" runat="server" Value="0" />
            <asp:HiddenField ID="HfPNumber" runat="server" Value="" />
            <asp:HiddenField ID="HfCountryid" runat="server" Value="-1" />
            <asp:HiddenField ID="hfMemberID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfConsultantMember" runat="server" Value="-1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--  <asp:UpdateProgress ID="UpdateProgressloader" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
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
    <script type="text/javascript">

        function QuoteAdditionWarning(event) {
            var job = document.getElementById('<%= txtJobID.ClientID %>').value;
            var message = "";
            if (job != "") {
                message = "This Proposal has Job. Please check Pricing/PO before adding.";
            } else {
                message = "Are you sure !";
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
            yesButton.textContent = "Add";
            buttonBox.appendChild(yesButton);
            yesButton.addEventListener('click', YesButtonClick);

            var noButton = document.createElement("button");
            noButton.classList.add("no-button");
            noButton.textContent = "Cancel";
            buttonBox.appendChild(noButton);
            noButton.addEventListener('click', NoButtonClick);

            function removeConfirmBox() {
                document.body.removeChild(confirmBox);
            }

            function YesButtonClick() {
                removeConfirmBox();
                document.getElementById('<%= HiddenButton.ClientID %>').click();
            }

            function NoButtonClick() {
                removeConfirmBox();
            }

            document.body.appendChild(confirmBox);
        }

        function EnterEventForPName(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
            }
        }
        function ClickEventForPName(e) {
            __doPostBack('<%=SearchPNameButton.UniqueID%>', "");
        }

        function EnterEvent(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=SearchPNumberButton.UniqueID%>', "");
            }
        }

        function ClickEvent(e) {
            __doPostBack('<%=SearchPNumberButton.UniqueID%>', "");
        }
        function GetConsultantDetails() {
            var e = document.getElementById('<%=ddlConsultant.ClientID%>');
            var param = { ConsultantID: e.value };
            $.ajax({
                url: "../SalesManagement/FrmProposals.aspx/GetConsultantDetails",
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

        function GetConsultantRepDetails() {
            var e = document.getElementById('<%=ddlConsultantRep.ClientID%>');
            var param = { Repid: e.value };

            $.ajax({
                url: "../SalesManagement/FrmProposals.aspx/GetConsultantRepDetails",
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
                            // document.getElementById('lblEmail').attr("href", value)
                            var sendto = 'mailto:' + value;
                            $("#lblEmail").attr("href", sendto);
                        }
                        else if (key == "Status") {
                            document.getElementById('lblStatus').innerHTML = value;
                        }
                    }

                   )
                },

            });
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

        function GetDealerDetails() {
            var e = document.getElementById('<%=ddlDealer.ClientID%>');
            var param = { DealerID: e.value };

            $.ajax({
                url: "../SalesManagement/FrmProposals.aspx/GetDealerDetails",
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
                            //lblState
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
                    }

            )
                },

            });
        };

        function GetDealerMemberDetails() {
            var e = document.getElementById('<%=ddlDealerMember.ClientID%>');
            var param = { DealerMemberID: e.value };

            $.ajax({
                url: "../SalesManagement/FrmProposals.aspx/GetDealerMemberDetails",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                    const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {

                        if (key == "Title") {
                            document.getElementById('lblddlMemberTitle').innerHTML = value;
                        }
                        else if (key == "FName") {
                            document.getElementById('lblddlMemberFirstName').innerHTML = value;
                        }
                        else if (key == "Phone") {
                            document.getElementById('lblddlMemberPhone').innerHTML = value;
                        }
                        else if (key == "Fax") {
                            document.getElementById('lblddlMemberFax').innerHTML = value;
                        }
                        else if (key == "email") {
                            document.getElementById('lblddlMemberEmail').innerHTML = value;
                            var sendto = 'mailto:' + value;
                            $("#lblddlMemberEmail").attr("href", sendto);

                        }

                    }

                  )
                },

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
        //GetDealerMemberDetails
        function ShowPopupDealerMember() {
            $("#dialog10").dialog({
                title: "Dealer Member Information",
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
            var e = document.getElementById('<%=ddlOriginationRep.ClientID%>');
            var param = { Repid: e.value };

            $.ajax({
                url: "../SalesManagement/FrmProposals.aspx/GetOriginationRepDetails",
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
                    })
                },
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
            var e = document.getElementById('<%=ddlDestRep.ClientID%>');
            var param = { Repid: e.value };
            $.ajax({
                url: "../SalesManagement/FrmProposals.aspx/GetDestinationRepDetails",
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
                            //lblDestState
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
                    })
                },
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

        function getCalc() {
            let EqPrice = document.getElementById('<%=txtEqPrice.ClientID%>').value;
            let EqpriceWithoutComma = eval(parseFloat(EqPrice.replace(/,/g, ''))).toFixed(2);
            if (isNaN(EqpriceWithoutComma)) EqpriceWithoutComma = 0.00;
            var disperc = eval(parseFloat(document.getElementById('<%=txtDisPer.ClientID%>').value)).toFixed(2);
            if (isNaN(disperc)) disperc = 0.00;
            var DisAmount = (EqpriceWithoutComma * disperc / 100).toFixed(2);
            document.getElementById('<%=txtDisAmount.ClientID%>').value = DisAmount;
            var NetEqPrice = (EqpriceWithoutComma - DisAmount).toFixed(2);
            document.getElementById('<%=txtNetEqPrice.ClientID%>').value = NetEqPrice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            var Freight = document.getElementById('<%=txtFreight.ClientID%>').value;
            let FreightWithoutComma = eval(parseFloat(Freight.replace(/,/g, ''))).toFixed(2);
            if (isNaN(FreightWithoutComma)) FreightWithoutComma = 0.00;
            document.getElementById('<%=txtFreight.ClientID%>').value = Freight;
            var Installation = document.getElementById('<%=txtInstall.ClientID%>').value;
            let InstallationWithoutComma = parseFloat(Installation.replace(/,/g, '')).toFixed(2);
            if (isNaN(InstallationWithoutComma)) InstallationWithoutComma = 0.00;
            document.getElementById('<%=txtInstall.ClientID%>').value = Installation;
            var TotalAmount = parseFloat(parseFloat(NetEqPrice) + parseFloat(FreightWithoutComma) + parseFloat(InstallationWithoutComma)).toFixed(2);
            document.getElementById('<%=txtTotalAmount.ClientID%>').value = TotalAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            var percentage = $("#ctl00_ContentPlaceHolder1_TabContainer1_TabPanel1_ddlSpecCredit option:selected").text();
            if (document.getElementById('<%=ddlSpecCredit.ClientID%>').value > 0) {
                var e = document.getElementById('<%=ddlSpecCredit.ClientID%>');
                let specpercentage = e.options[e.selectedIndex].text;
                let specamount = parseFloat(NetEqPrice * specpercentage / 100).toFixed(2);
                document.getElementById('<%=txtSpecAmount.ClientID%>').value = specamount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            }
        }
        function getPer() {
            let EqPrice = document.getElementById('<%=txtEqPrice.ClientID%>').value;
                let EqpriceWithoutComma = eval(parseFloat(EqPrice.replace(/,/g, ''))).toFixed(2);
                if (isNaN(EqpriceWithoutComma)) EqpriceWithoutComma = 0.00;
                var DisAmt = eval(parseFloat(document.getElementById('<%=txtDisAmount.ClientID%>').value)).toFixed(2);
                if (isNaN(DisAmt)) DisAmt = 0.00;
                var DisPerc = (DisAmt / EqpriceWithoutComma * 100).toFixed(2);
                if (isNaN(DisPerc)) DisPerc = 0.00;
                document.getElementById('<%=txtDisPer.ClientID%>').value = DisPerc;
            var NetEqPrice = (EqpriceWithoutComma - DisAmt).toFixed(2);
            document.getElementById('<%=txtNetEqPrice.ClientID%>').value = NetEqPrice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            var Freight = document.getElementById('<%=txtFreight.ClientID%>').value;
                let FreightWithoutComma = eval(parseFloat(Freight.replace(/,/g, ''))).toFixed(2);
                if (isNaN(FreightWithoutComma)) FreightWithoutComma = 0.00;
                document.getElementById('<%=txtFreight.ClientID%>').value = Freight;
                var Installation = document.getElementById('<%=txtInstall.ClientID%>').value;
                let InstallationWithoutComma = parseFloat(Installation.replace(/,/g, '')).toFixed(2);
                if (isNaN(InstallationWithoutComma)) InstallationWithoutComma = 0.00;
                document.getElementById('<%=txtInstall.ClientID%>').value = Installation;
                var TotalAmount = parseFloat(parseFloat(NetEqPrice) + parseFloat(FreightWithoutComma) + parseFloat(InstallationWithoutComma)).toFixed(2);
                document.getElementById('<%=txtTotalAmount.ClientID%>').value = TotalAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
            var percentage = $("#ctl00_ContentPlaceHolder1_TabContainer1_TabPanel1_ddlSpecCredit option:selected").text();
            if (document.getElementById('<%=ddlSpecCredit.ClientID%>').value > 0) {
                var e = document.getElementById('<%=ddlSpecCredit.ClientID%>');
                let specpercentage = e.options[e.selectedIndex].text;
                let specamount = parseFloat(NetEqPrice * specpercentage / 100).toFixed(2);
                document.getElementById('<%=txtSpecAmount.ClientID%>').value = specamount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
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
            var radioValue = $('#<%= rdbSpecCredit.ClientID %> input:checked').val();
            var ddlCreditValue = document.getElementById('<%=ddlSpecCredit.ClientID%>').value;
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
                document.getElementById('<%=ddlSpecCredit.ClientID%>').value = "";
                document.getElementById('<%=txtSpecPaid.ClientID%>').value = "";
                document.getElementById('<%= txtSpecAmount.ClientID %>').value = "";
            }
            else {
                document.getElementById('<%= ddlSpecCredit.ClientID %>').value = "";
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
        document.getElementById('<%= ddlSpecCredit.ClientID %>').value = "";
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
    function SetStateAb() {
        var e = document.getElementById('<%=ddlState.ClientID%>');
        var strUser = e.options[e.selectedIndex].value;
        document.getElementById('<%=ddlStateAb.ClientID%>').value = strUser;
        //alert(strUser);
           }
           function SetState() {
               var e = document.getElementById('<%=ddlStateAb.ClientID%>');
                    var strUser = e.options[e.selectedIndex].value;
                    document.getElementById('<%=ddlState.ClientID%>').value = strUser;
                    }
                    function SetMemberValue() {
                        document.getElementById('<%=hfMemberID.ClientID%>').value = document.getElementById('<%=ddlConsultantMember.ClientID%>').value;
                        //document.getElementById('<%=ddlConsultantMember.ClientID%>').value = document.getElementById('<%=hfConsultantMember.ClientID%>').value;
                    }

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });
        function PageLoaded(sender, args) {
            Drp();
        }
        $.when.apply($, PageLoaded).then(function () {
            Drp();
        });

        function Drp() {
         <%--  $('#<%=cboPName.ClientID%>').chosen();
           $('#<%=cboPNumber.ClientID%>').chosen(); --%>
            $('#<%=ddlExistingJobID.ClientID%>').chosen();
            $('#<%=ddlPreparedBy.ClientID%>').chosen();
           <%-- $('#<%=ddlAlternate1.ClientID%>').chosen();
           $('#<%=ddlAlternate2.ClientID%>').chosen();  
           $('#<%=ddlAlternate3.ClientID%>').chosen();--%>
            $('#<%=ddlCompetitor.ClientID%>').chosen();
            $('#<%=ddlConsultant.ClientID%>').chosen();
            $('#<%=ddlConsultantMember.ClientID%>').chosen();
            $('#<%=ddlConsultantRep.ClientID%>').chosen();
            $('#<%=ddlConType.ClientID%>').chosen();
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlConsultantRep.ClientID%>').chosen();
            $('#<%=ddlOriginationRep.ClientID%>').chosen();
            $('#<%=ddlDestRep.ClientID%>').chosen();
            $('#<%=ddlDealer.ClientID%>').chosen();
            $('#<%=ddlModel.ClientID%>').chosen();
            $('#<%=ddlSourceleadref.ClientID%>').chosen();
            $('#<%=ddlCurruncy.ClientID%>').chosen();
            $('#<%=ddlProjectType.ClientID%>').chosen();
          <%-- $('#<%=ddlState.ClientID%>').chosen();
           $('#<%=ddlStateAb.ClientID%>').chosen();--%>
            $('#<%=ddlDesigner.ClientID%>').chosen();
            $('#<%=ddlDealerMember.ClientID%>').chosen();
            $('#<%=ddlReason.ClientID%>').chosen();
            $('#<%=ddlAlternate1.ClientID%>').chosen();
            $('#<%=ddlAlternate2.ClientID%>').chosen();
            $('#<%=ddlAlternate3.ClientID%>').chosen();
            $('#<%=ddlSourceLead.ClientID%>').chosen();
            $('#<%=ddlConveyorPrimeSpec.ClientID%>').chosen();
            $('#<%=ddlConveyorAlternate.ClientID%>').chosen();
            $('#<%=ddlIndustry.ClientID%>').chosen();
            $('#<%=ddlProjectBid.ClientID%>').chosen();
            $('#<%=ddlProjectManager.ClientID%>').chosen();
        }

       <%-- function ShowPrimeSpec(id) {
           var e = document.getElementById('<%=ddlDishPrimeSpec.ClientID%>');
           var PrimeSpec = e.options[e.selectedIndex].text;        
           if (PrimeSpec == 'Other') {           
               document.getElementById('<%=pnlDishPrimeSpec.ClientID%>').style.display = "block";
               var dishprimespecvalue = document.getElementById('<%=ddlDishPrimeSpec.ClientID%>').value;               
           }
           else {
               document.getElementById('<%=pnlDishPrimeSpec.ClientID%>').style.display = "none";
               document.getElementById('<%=txtDishPrimeSpec.ClientID%>').value = "";
               var dishprimespecvalue = document.getElementById('<%=ddlDishPrimeSpec.ClientID%>').value;
           }         
       }

       function ShowAlternate() {
           var e = document.getElementById('<%=ddlDishAlternate.ClientID%>');
           var DishAlternate = e.options[e.selectedIndex].text;    
           //Second
           if (DishAlternate == 'Other') {
               document.getElementById('<%=pnlDishAlternate.ClientID%>').style.display = "block";
               var dishalternate = document.getElementById('<%=ddlDishAlternate.ClientID%>').value;               
           }
           else {
               document.getElementById('<%=pnlDishAlternate.ClientID%>').style.display = "none";
               document.getElementById('<%=txtDishAlternate.ClientID%>').value = "";
               var dishalternate = document.getElementById('<%=ddlDishAlternate.ClientID%>').value;               
           }           
       }

       function ShowMachineType() {         
           var e = document.getElementById('<%=ddlDishType.ClientID%>');
           var DishType = e.options[e.selectedIndex].text;    
           //Third
           if (DishType == 'Other') {
               document.getElementById('<%=pnlDishType.ClientID%>').style.display = "block";
               var dishtype = document.getElementById('<%=ddlDishType.ClientID%>').value;
           }
           else {
               document.getElementById('<%=pnlDishType.ClientID%>').style.display = "none";
               document.getElementById('<%=txtDishType.ClientID%>').value = "";
               var dishtype = document.getElementById('<%=ddlDishType.ClientID%>').value;
           }
       }

        function ShowMachineTypeAlternate() {
           var e = document.getElementById('<%=ddlDishTypeAlternate.ClientID%>');
           var DishTypeAlternate = e.options[e.selectedIndex].text;  
           //Third
           if (DishTypeAlternate == 'Other') {
               document.getElementById('<%=pnlDishTypeAlternate.ClientID%>').style.display = "block";
               var dishtypealternate = document.getElementById('<%=ddlDishTypeAlternate.ClientID%>').value;
           }
           else {
               document.getElementById('<%=pnlDishTypeAlternate.ClientID%>').style.display = "none";
               document.getElementById('<%=txtDishTypeAlternate.ClientID%>').value = "";
               var dishtypealternate = document.getElementById('<%=ddlDishTypeAlternate.ClientID%>').value;
           }           
       }      

       function ShowModel() {          
           //Fifth
           var e = document.getElementById('<%=ddlDishModel.ClientID%>');
           var DishModel = e.options[e.selectedIndex].text;  
           if (DishModel == 'Other') {
               document.getElementById('<%=pnlDishModel.ClientID%>').style.display = "block";
               var SelectedVal = document.getElementById('<%=ddlDishModel.ClientID%>').value;               
           }
           else {
               document.getElementById('<%=pnlDishModel.ClientID%>').style.display = "none";
                document.getElementById('<%=txtDishModel.ClientID%>').value = "";
               var SelectedVal = document.getElementById('<%=ddlDishModel.ClientID%>').value;
           }
       }

    	  function ShowModelAlternate() {
            var e = document.getElementById('<%=ddlDishModelAlternate.ClientID%>');
           var DishModelAlternate = e.options[e.selectedIndex].text;  
           //Fifth
           if (DishModelAlternate == 'Other')
           {
               document.getElementById('<%=pnlDishModelAlternate.ClientID%>').style.display = "block";
               var SelectedValalternate = document.getElementById('<%=ddlDishModelAlternate.ClientID%>').value;
           }
           else
           {
               document.getElementById('<%=pnlDishModelAlternate.ClientID%>').style.display = "none";
               document.getElementById('<%=txtDishModelAlternate.ClientID%>').value = "";
               var SelectedValalternate = document.getElementById('<%=ddlDishModelAlternate.ClientID%>').value;
           }
       }

       function ShowStyle() {
           var e = document.getElementById('<%=ddlDishStyle.ClientID%>');
           var DishStyle = e.options[e.selectedIndex].text;  
           //Sixth
           if (DishStyle == 'Other') {
               document.getElementById('<%=pnlDishStyle.ClientID%>').style.display = "block";
                var dishstyle = document.getElementById('<%=ddlDishStyle.ClientID%>').value;
           }
           else {
               document.getElementById('<%=pnlDishStyle.ClientID%>').style.display = "none";
                document.getElementById('<%=txtDishStyle.ClientID%>').value = "";
               var dishstyle = document.getElementById('<%=ddlDishStyle.ClientID%>').value;
           }
       }

       function ShowStyleAlternate()
       {
           var e = document.getElementById('<%=ddlDishStyle.ClientID%>');
           var DishStyleAlternate = e.options[e.selectedIndex].text;  
           //Sixth
           if (DishStyleAlternate == 'Other') {
               document.getElementById('<%=pnlDishStyleAlternate.ClientID%>').style.display = "block";
                var dishstylealternate = document.getElementById('<%=ddlDishStyleAlternate.ClientID%>').value;
           }
           else {
               document.getElementById('<%=pnlDishStyleAlternate.ClientID%>').style.display = "none";
                document.getElementById('<%=txtDishStyleAlternate.ClientID%>').value = "";
                var dishstylealternate = document.getElementById('<%=ddlDishStyleAlternate.ClientID%>').value;
           }
       }
          function ShowHideHobartInfo() {
            var e = document.getElementById('<%=ddlWastePrimeSpec.ClientID%>');
           var HobartInfo = e.options[e.selectedIndex].text;  
           //Seventh
           if (HobartInfo == 'Other')
           {
               document.getElementById('<%=pnlWastePrimeSpec.ClientID%>').style.display = "block";
               //HfWasteEqPrimeSpec
               var WastePrimeSpec = document.getElementById('<%=ddlWastePrimeSpec.ClientID%>').value;
           }
           else
           {
               document.getElementById('<%=pnlWastePrimeSpec.ClientID%>').style.display = "none";
               document.getElementById('<%=txtWastePrimeSpec.ClientID%>').value = "";
               var WastePrimeSpec = document.getElementById('<%=ddlWastePrimeSpec.ClientID%>').value;
           }              
       }
       function ShowHideWasteEqType(id) {          
            var e = document.getElementById('<%=ddlWasteEqType.ClientID%>');
           var WateEquType = e.options[e.selectedIndex].text;  
           //Eigth
           if (WateEquType == 'Other')
           {
               document.getElementById('<%=pnlWasteEqType.ClientID%>').style.display = "block";
               var WasteEqType = document.getElementById('<%=ddlWasteEqType.ClientID%>').value;
           }
           else {
               document.getElementById('<%=pnlWasteEqType.ClientID%>').style.display = "none";
               document.getElementById('<%=txtWasteEqType.ClientID%>').value = "";
               var WasteEqType = document.getElementById('<%=ddlWasteEqType.ClientID%>').value;
           }           
       }

       function ShowHideHobartInfoModel() {
             var e = document.getElementById('<%=ddlWasteEqModel.ClientID%>');
           var WateEquModel = e.options[e.selectedIndex].text;  
           //Nine
           if (WateEquModel == 'Other')
           {
               document.getElementById('<%=pnlWasteEqModel.ClientID%>').style.display = "block";
               var WasteEqModel = document.getElementById('<%=ddlWasteEqModel.ClientID%>').value;
           }
           else {
               document.getElementById('<%=pnlWasteEqModel.ClientID%>').style.display = "none";
               document.getElementById('<%=txtWasteEqModel.ClientID%>').value = "";
               var WasteEqModel = document.getElementById('<%=ddlWasteEqModel.ClientID%>').value;
           }          
       }

       function WasteEqStyle() {
            var e = document.getElementById('<%=ddlWasteEqStyle.ClientID%>');
           var WateEquStyle = e.options[e.selectedIndex].text; 
           //Ten
           if (WateEquStyle == 'Other')
           {
               document.getElementById('<%=PanelWasteEqStyle.ClientID%>').style.display = "block";
              var WasteEqStyle = document.getElementById('<%=ddlWasteEqStyle.ClientID%>').value;   
               
           }
           else {
               document.getElementById('<%=PanelWasteEqStyle.ClientID%>').style.display = "none";
               document.getElementById('<%=txtWasteEqStyle.ClientID%>').value = "";
               var WasteEqStyle = document.getElementById('<%=ddlWasteEqStyle.ClientID%>').value;
           }
       }

       function ShowHideHobartInfoAlternate() {
           var e = document.getElementById('<%=ddlWasteAlternate.ClientID%>');
           var WateEquPrimeAlternate = e.options[e.selectedIndex].text; 
           //Seventh
           if (WateEquPrimeAlternate == 'Other')
           {
               document.getElementById('<%=PanelWasteEqAlternate.ClientID%>').style.display = "block";
               var WasteEqPrimeAlternate = document.getElementById('<%=ddlWasteAlternate.ClientID%>').value;
           }
           else {
               document.getElementById('<%=PanelWasteEqAlternate.ClientID%>').style.display = "none";
               document.getElementById('<%=txtWasteEqAlternate.ClientID%>').value = "";
               var WasteEqPrimeAlternate = document.getElementById('<%=ddlWasteAlternate.ClientID%>').value;
           }
       }

       function ShowHideWasteEqTypeAlternate(id) {
            var e = document.getElementById('<%=ddlWasteEqTypeAlternate.ClientID%>');
           var WateEquTypeAlternate = e.options[e.selectedIndex].text; 
           //Eigth
           if (WateEquTypeAlternate == 'Other') {
               document.getElementById('<%=PanelWasteEqType.ClientID%>').style.display = "block";
               var WasteEqTypeAlternate = document.getElementById('<%=ddlWasteEqTypeAlternate.ClientID%>').value;
           }
           else {
               document.getElementById('<%=PanelWasteEqType.ClientID%>').style.display = "none";
               document.getElementById('<%=txtWasteEqTypeAlternate.ClientID%>').value = "";
               var WasteEqTypeAlternate = document.getElementById('<%=ddlWasteEqTypeAlternate.ClientID%>').value;
           }           
       }

       function WasteEqModelAlternate() {
            var e = document.getElementById('<%=ddlWasteEqModelAlternate.ClientID%>');
           var WateEquModelAlternate = e.options[e.selectedIndex].text;
           //Nine
           if (WateEquModelAlternate == 'Other') {
               document.getElementById('<%=PanelWasteEqModelAlternate.ClientID%>').style.display = "block";
               var WasteEqModelAlternate = document.getElementById('<%=ddlWasteEqModelAlternate.ClientID%>').value;
           }
           else {
               document.getElementById('<%=PanelWasteEqModelAlternate.ClientID%>').style.display = "none";
               document.getElementById('<%=txtWasteEqModelAlternate.ClientID%>').value = "";
               var WasteEqModelAlternate = document.getElementById('<%=ddlWasteEqModelAlternate.ClientID%>').value;
           }          
       }

       function WasteEqStyleAlternate(id)
       {
           var e = document.getElementById('<%=ddlWasteEqStyleAlternate.ClientID%>');
           var WateEquStyleAlternate = e.options[e.selectedIndex].text;
           //Ten
           if (WateEquStyleAlternate == 'Other')
           {
               document.getElementById('<%=PanelWasteEqStyleAlternate.ClientID%>').style.display = "block";
               var WasteEqStyleAlternate = document.getElementById('<%=ddlWasteEqStyleAlternate.ClientID%>').value;
           }
           else
           {
               document.getElementById('<%=PanelWasteEqStyleAlternate.ClientID%>').style.display = "none";
               document.getElementById('<%=txtWasteEqStyleAlternate.ClientID%>').value = "";
               var WasteEqStyleAlternate = document.getElementById('<%=ddlWasteEqStyleAlternate.ClientID%>').value;
           }
       }--%>

        function SetCSS() {
            document.getElementById("pfTab").className = 'tab-pane fade pt-2';
            document.getElementById("profile").className = 'tab-pane fade show active pt-2';
            document.getElementById("pf-tab").className = 'nav-link';
            document.getElementById("profile-tab").className = 'nav-link active';
        }
        //followup
        function SetCSSFollowUps() {
            document.getElementById("pfTab").className = 'tab-pane fade pt-2';
            document.getElementById("followup").className = 'tab-pane fade show active pt-2';
            document.getElementById("pf-tab").className = 'nav-link';
            document.getElementById("Followup-tab").className = 'nav-link active';
        }
        function SetCSSQuote() {
            document.getElementById("pfTab").className = 'tab-pane fade pt-2';
            document.getElementById("quote").className = 'tab-pane fade show active pt-2';
            document.getElementById("pf-tab").className = 'nav-link';
            document.getElementById("Quote-tab").className = 'nav-link active';
        }
        function SetCSSProDrw() {
            document.getElementById("pfTab").className = 'tab-pane fade pt-2';
            document.getElementById("ProposalTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("pf-tab").className = 'nav-link';
            document.getElementById("Proposal-tab").className = 'nav-link active';
        }
        function SetCSSModels() {
            document.getElementById("Model-tab").className = 'nav-link active';
            document.getElementById("pfTab").className = 'tab-pane fade pt-2';
            document.getElementById("Model").className = 'tab-pane fade show active pt-2';
            document.getElementById("pf-tab").className = 'nav-link';
        }
        function ShowMessage(msg) {
        }
        function GetConsultantMemberDetails() {
            var e = document.getElementById('<%=ddlConsultantMember.ClientID%>');
            var param = { ConsultantID: e.value };
            $.ajax({
                url: "../SalesManagement/FrmProposals.aspx/GetConsultantMember",
                data: JSON.stringify(param),
                datatype: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //dataFilter: function (data) { return data; },
                success: function (data) {
                    const info = JSON.stringify(data.d);
                    var obj = JSON.parse(info, function (key, value) {
                        if (key == "JobTitle") {
                            document.getElementById('lblConstMemJobTitle').innerHTML = value;
                        }
                        else if (key == "FirstName") {
                            document.getElementById('lblConstMemFirstName').innerHTML = value;
                        }
                        else if (key == "TelephoneExtension") {
                            document.getElementById('lblConstMemTelExt').innerHTML = value;
                        }
                        else if (key == "Email") {
                            document.getElementById('lblConstMememail').innerHTML = value;
                            var sendto = 'mailto:' + value;
                            $("#lblConstMememail").attr("href", sendto);
                        }
                        else if (key == "DirectLine") {
                            document.getElementById('lblConstMemDirectLine').innerHTML = value;
                        }
                    }
                )
                },
            });
        };

        function ShowPopupConsultantMember() {
            $("#dialog11").dialog({
                title: "Consultant Member Information",
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

        function ChangeColor() {
            if (document.getElementById('<%=chkProtection.ClientID%>').checked == true) {
                document.getElementById('<%=txtSpecialInstr.ClientID%>').style.borderColor = "#FF0000";
            }
            else {
                document.getElementById('<%=txtSpecialInstr.ClientID%>').style.borderColor = "#ced4da";
            }
        }

        function RemoveChar(signs, id) {
            var desired = signs.replace(/[`~^&*()_|+\-=;:'",.<>\{\}\[\]\\\/]/gi, '');
            document.getElementById(id).value = desired;
        }

        function GetValue() {
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
                            ins = '/';
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
        function nextFollowUpDate(id) {
            var e = document.getElementById(id);
            var projectManager = document.getElementById('<%=ddlProjectManager.ClientID%>');
            if (e.value.length > 1) {
                var param = { nextFollowUpDate: e.value, projectManagerID: projectManager.value };
                $.ajax({
                    url: "../SalesManagement/FrmProposals.aspx/NextFollowUpDateEvent",
                    data: JSON.stringify(param),
                    datatype: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        const info = JSON.stringify(data.d);
                        var obj = JSON.parse(info, function (key, value) {
                            e.style.background = value;
                        });
                    }
                });
            } else {
                e.style.borderColor = "lightgrey";
            }
        }
    </script>
</asp:Content>
