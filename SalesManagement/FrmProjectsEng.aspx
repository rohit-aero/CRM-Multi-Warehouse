<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmProjectsEng.aspx.cs" Inherits="SalesManagement_FrmProjectsEng" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_Projects_Eng" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Projects_Eng" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative mr-3">Project Information                            
                               
                                <asp:Label ID="lblPM" Visible="false" CssClass="btn btn-primary btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblDesRep" Visible="false" CssClass="btn btn-success btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblConsultant" Visible="false" CssClass="btn btn-info btn-sm" Style="cursor: no-drop;" runat="server" Text=""></asp:Label>
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
                                                CompletionInterval="3" CompletionSetCount="10" MinimumPrefixLength="3" CompletionListElementID="Panel1"
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
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm mb-3" Text="Update" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-secondary btn-sm mb-3" Visible="false" OnClick="btnSearch_Click" Text="Search Project" />
                                <asp:Button ID="btnCADReport" runat="server" CssClass="btn btn-secondary btn-sm mb-3" OnClick="btnCADReport_Click" Text="Engineering" />
                                <asp:Button ID="btnSiteVisit" runat="server" CssClass="btn btn-secondary btn-sm mb-3" OnClick="btnSiteVisit_Click" Text="Site Visit" />
                                <asp:Button ID="btnCuspack" runat="server" CssClass="btn btn-info btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Customer Package" Enabled="false" OnClick="btnCuspack_Click" />
                                <asp:Button ID="btnAcknoledgement" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Acknowledgement" Enabled="false" OnClick="btnAcknoledgement_Click" />
                                <asp:Button ID="btnInf" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Inf for ENG" Enabled="false" OnClick="btnInf_Click" />
                                <asp:Button ID="btnProjectsEng" runat="server" CssClass="btn btn-secondary btn-sm mb-3" OnClick="btnProjects_Click" Text="Project" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm mb-3" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="RemoveQueryString()" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row bg-white shadow-sm border-bottom">
                    <div class="col">
                        <ul class="nav nav-tabs customTabs" id="myTab" role="tablist">
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link active" id="sd-tab" data-toggle="tab" href="#sdTab" role="tab" aria-controls="contact" aria-selected="true"><span>Shop Drawings <i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="fab-tab" data-toggle="tab" href="#fabTab" role="tab" aria-controls="fabrication" aria-selected="false"><span>Fabrication Canada<i class="fas fa-arrow-right"></i></span></a>
                            </li>
                            <li class="nav-item border-right" role="presentation">
                                <a class="nav-link" id="fabChina-tab" data-toggle="tab" href="#fabChinaTab" role="tab" aria-controls="fabricationChina" aria-selected="false"><span>Fabrication China<i class="fas fa-arrow-right"></i></span></a>
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
                    <div class="tab-pane fade show active pt-2" id="sdTab" role="tabpanel" aria-labelledby="contact-tab">
                        <div class="col-sm-12">
                            <h5 class="text-uppercase">Shop Drawing Information</h5>
                        </div>
                        <div class="col-12 col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label>Upload Plan View (PDF Max 800 kb Size)</label>
                                <asp:FileUpload ID="fileInput" CssClass="btn btn-success btn-sm btn-block" runat="server" onchange="CheckFileValidations()" Style="width: 350px" />
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="lnkDowload" runat="server" Text="Download Pdf"
                                    OnClick="lnkDowload_Click" Visible="false"></asp:LinkButton>
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm mb-3" Text="Delete File" OnClientClick="return confirm('Are you sure to delete. ?');" OnClick="btnDelete_Click" Visible="false" />
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="GvShpDrg" runat="server" DataKeyNames="sDrgNum" AutoGenerateColumns="False"
                                EnableModelValidation="True" Height="100%"
                                OnRowEditing="GvShpDrg_RowEditing" OnRowUpdating="GvShpDrg_RowUpdating" OnRowCancelingEdit="GvShpDrg_RowCancelingEdit"
                                ShowFooter="True" AllowPaging="True" OnPageIndexChanging="GvShpDrg_PageIndexChanging" OnRowCommand="GvShpDrg_RowCommand" Style="margin-top: 0px" OnRowDeleting="GvShpDrg_RowDeleting" OnRowDataBound="GvShpDrg_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Dwg Num (Autogen)" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgNum" runat="server" Text='<%# Eval("sDrgNum") %>' Width="140px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgNum" CssClass="form-control form-control-sm" runat="server" Width="140px" Text='<%# Eval("sDrgNum") %>' ReadOnly="True"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgNum" CssClass="form-control form-control-sm" Width="140px" runat="server" ReadOnly="True" Enabled="false"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDrgSentToRCD" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"
                                                Text='<%#Eval("sDrgSentToRCD") %>' Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgSentToRCD" TargetControlID="txtDrgSentToRCD">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgSentToRCD" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"
                                                runat="server" Width="100%"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDrgJID" CssClass="form-control form-control-sm" runat="server" Width="100%" Text='<%# Eval("sDrgJID") %>' ReadOnly="True"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtJobID" CssClass="form-control form-control-sm" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="DwgWantDate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrgWantDate" runat="server" Width="100%" Text='<%# Eval("sDrgWantDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDrgWantDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"
                                                Width="100%" Text='<%# Eval("sDrgWantDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgWantDate" TargetControlID="txtDrgWantDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgWantDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"
                                                runat="server" Width="100%"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDrgPromisedDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"
                                                runat="server" Width="100%" Text='<%# Eval("sDrgPromiseDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgPromisedDate" TargetControlID="txtDrgPromisedDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgPromisedDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"
                                                runat="server" Width="100%"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDrgExpectedApprovalDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"
                                                runat="server" Width="100%" Text='<%#Eval("sDrgExpecApprovalDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgExpectedApprovalDate" TargetControlID="txtDrgExpectedApprovalDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgExpectedApprovalDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDrgAppDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%" Text='<%#Eval("sDrgAppDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgAppDate" TargetControlID="txtDrgAppDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgAppDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDrgDateFollowedUp" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%" Text='<%#Eval("sDateFollowedUp") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgDateFollowedUp" TargetControlID="txtDrgDateFollowedUp">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgDateFollowedUp" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDrgNextFollowupDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"
                                                runat="server" Width="100%" Text='<%#Eval("sNextFolowupDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDrgNextFollowupDate" TargetControlID="txtDrgNextFollowupDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtDrgNextFollowupDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender15" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtDrgNextFollowupDate" TargetControlID="FtxtDrgNextFollowupDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Released To" HeaderStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReleasedTo" runat="server" Text='<%#Eval("sReleasedToText") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEditReleasedTo" runat="server">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                <asp:ListItem Value="F">Release To Fab</asp:ListItem>
                                                <asp:ListItem Value="S">Release To Shop</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblEditReleasedTo" runat="server" Text='<%#Eval("sReleasedTo") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFooterReleasedTo" runat="server">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                <asp:ListItem Value="F">Release To Fab</asp:ListItem>
                                                <asp:ListItem Value="S">Release To Shop</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblFooterReleasedTo" runat="server" Text='<%#Eval("sReleasedTo") %>' Visible="false"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Released To Fab Date" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReleasedToFabDate" runat="server" Text='<%#Eval("sReleasedToFabDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditReleaseToFabDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"
                                                runat="server" Text='<%#Eval("sReleasedToFabDate") %>' Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="caltxtEditReleaseToFabDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtEditReleaseToFabDate" TargetControlID="txtEditReleaseToFabDate">
                                            </asp:CalendarExtender>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtReleaseToFabDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="calFtxtReleaseToFabDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtReleaseToFabDate" TargetControlID="FtxtReleaseToFabDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Released To Shop Date" HeaderStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReleasedToShopDate" runat="server" Text='<%#Eval("sReleasedToShopDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditReleaseToShopDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%" Text='<%#Eval("sReleasedToShopDate") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="caltxtEditReleaseToShopDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtEditReleaseToShopDate" TargetControlID="txtEditReleaseToShopDate">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="FtxtReleaseToShopDate" CssClass="form-control form-control-sm" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
                                            <asp:CalendarExtender ID="calFtxtReleaseToShopDate" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="FtxtReleaseToShopDate" TargetControlID="FtxtReleaseToShopDate">
                                            </asp:CalendarExtender>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Dwg Release Date" HeaderStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsDateReleasedToFab" runat="server" Text='<%#Eval("sDateReleasedToFab") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDateReleasedToFab" OnBlur="validateDate(this)" runat="server"
                                                Width="100%" Text='<%#Eval("sDateReleasedToFab") %>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender116" runat="server" Format="MM/dd/yyyy"
                                                PopupButtonID="txtDateReleasedToFab" TargetControlID="txtDateReleasedToFab">
                                            </asp:CalendarExtender>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="FtxtDateReleasedToFab" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
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
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDrgComment" runat="server" Width="100%" Text='<%# Eval("sDrgComment") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="FtxtDrgComment" runat="server" Width="100%"></asp:TextBox>
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
                                <h5 class="text-uppercase">Fabrication Canada Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>FAB Project Designer</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectDesigner" DataValueField="EmployeeID" DataTextField="Abbrivation" runat="server" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Fabrication Start Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabStartDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)" Enabled="false"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender31" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabStartDate" TargetControlID="txtFabStartDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2" style="display: none;">
                                <div class="form-group">
                                    <label>Date (Due To Canada Office)</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDueToCanda" AutoComplete="off" runat="server" OnBlur="validateDate(this)" Enabled="false"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtDueToCanda" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDueToCanda" TargetControlID="txtDueToCanda"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Fabrication End Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabtrication" AutoComplete="off" runat="server" OnBlur="validateDate(this)" Enabled="false"></asp:TextBox>
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
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlManuFac" DataTextField="FacilityName" DataValueField="ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlManuFac_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Warehouse</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlWarehouse" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Released</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabReleasedDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender32" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabReleasedDate" TargetControlID="txtFabReleasedDate"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReviewedBy" runat="server" DataTextField="Name" DataValueField="EmployeeID" AutoPostBack="true" Enabled="false"
                                        OnSelectedIndexChanged="ddlReviewedBy_SelectedIndexChanged">
                                    </asp:DropDownList>
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

                        <div class="row border-top">
                            <div class="col-sm-12 mt-2">
                                <h5 class="text-uppercase">Fabrication Canada Tasks</h5>
                            </div>

                            <div class="col-sm-2 ">
                                <div class="form-group">
                                    <label>Task #</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtTaskNumber_Grid" runat="server" Enabled="false">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Nature of Task*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNatureOfTask_Grid" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="NR">New Release</asp:ListItem>
                                        <asp:ListItem Value="SP">Service Parts</asp:ListItem>
                                        <asp:ListItem Value="RW">Rework</asp:ListItem>
                                        <asp:ListItem Value="U">Urgent</asp:ListItem>
                                        <asp:ListItem Value="E">Expedited</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Release Type</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReleaseType_Grid" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="R">Regular</asp:ListItem>
                                        <asp:ListItem Value="S">Special</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>FAB Project Designer</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectDesigner_Grid" DataValueField="EmployeeID" DataTextField="Abbrivation" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Fabrication Start Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabStartDate_Grid" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFabStartDate_Grid_extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabStartDate_Grid" TargetControlID="txtFabStartDate_Grid"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Fabrication End Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabEndDate_Grid" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFabEndDate_Grid_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabEndDate_Grid" TargetControlID="txtFabEndDate_Grid"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReviewedBy_Grid" runat="server" DataTextField="Name" DataValueField="EmployeeID" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlReviewedBy_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <label>&nbsp;</label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnAddFabricationTask" CssClass="btn btn-primary btn-sm" Text="Add" OnClick="btnAddFabricationTask_Click" />
                                </div>
                            </div>

                        </div>

                        <div class="row pt-3">
                            <div class="col-sm-12">
                                <%--<h5 class="text-uppercase">Task Details</h5>--%>
                                <div class="table-responsive">
                                    <asp:GridView CssClass="table mainGridTable table-sm mb-0" ForeColor="White" ID="gvFabricationCanada" runat="server" AutoGenerateColumns="false" DataKeyNames="id"
                                        EnableModelValidation="True" ShowFooter="false" OnRowEditing="gvFabricationCanada_RowEditing" OnRowDeleting="gvFabricationCanada_RowDeleting"
                                        OnRowCommand="gvFabricationCanada_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Task #" SortExpression="TaskNumber">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskNumber" runat="server" Text='<%# Eval("TaskNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Nature of Task" SortExpression="NatureOfTask">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNatureOfTask" runat="server" Text='<%# Eval("NatureOfTask") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Release Type" SortExpression="ReleaseType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReleaseType" runat="server" Text='<%# Eval("ReleaseType") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Project Designer" SortExpression="ProjectDesigner">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectDesigner" runat="server" Text='<%# Eval("ProjectDesigner") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="End Date" SortExpression="EndDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reviewed By" SortExpression="ReviewedBy">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReviewedBy" runat="server" Text='<%# Eval("ReviewedBy") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Sent To Nesting" SortExpression="SentToNesting">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSentToNesting" runat="server" Text='<%# Eval("SentToNesting") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Modify">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" Text="Send To Nesting" CommandName="Send" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'><i class="far fa-paper-plane" title="Send To Nesting"></i></asp:LinkButton>
                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                         <i class="far fa-times-circle"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade pt-2" id="fabChinaTab" role="tabpanel" aria-labelledby="fabricationChina-tab">
                        <div class="row">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Fabrication China Information</h5>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>FAB Project Designer</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectDesignerChina" DataValueField="EmployeeID" DataTextField="Abbrivation" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>FAB Project Reviewer</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectReviewerChina" DataValueField="EmployeeID" DataTextField="Abbrivation" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>FAB Drawing %</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFabDrawingPercentage" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="10">10%</asp:ListItem>
                                        <asp:ListItem Value="20">20%</asp:ListItem>
                                        <asp:ListItem Value="30">30%</asp:ListItem>
                                        <asp:ListItem Value="40">40%</asp:ListItem>
                                        <asp:ListItem Value="50">50%</asp:ListItem>
                                        <asp:ListItem Value="60">60%</asp:ListItem>
                                        <asp:ListItem Value="70">70%</asp:ListItem>
                                        <asp:ListItem Value="80">80%</asp:ListItem>
                                        <asp:ListItem Value="90">90%</asp:ListItem>
                                        <asp:ListItem Value="100">100%</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Fabrication Start Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabStartDateChina" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender10" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabStartDateChina" TargetControlID="txtFabStartDateChina"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Fabrication End Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabEndDateChina" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender16" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabEndDateChina" TargetControlID="txtFabEndDateChina"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Manufacturing Facility</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlManuFacChina" DataTextField="FacilityName" DataValueField="ID" runat="server" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Issued For</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlIssued" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="D">Drawings</asp:ListItem>
                                        <asp:ListItem Value="P">Production</asp:ListItem>
                                        <asp:ListItem Value="B">Drawings and Production</asp:ListItem>
                                        <%-- Value=B for BOTH --%>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Release to China</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtFabReleasedDateChina" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender14" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabReleasedDateChina" TargetControlID="txtFabReleasedDateChina"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Expected Submission Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtExpectedSubmissionDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtExpectedSubmissionDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtExpectedSubmissionDate" TargetControlID="txtExpectedSubmissionDate"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Actual Submission Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtActualSubmissionDate" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtActualSubmissionDate_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtActualSubmissionDate" TargetControlID="txtActualSubmissionDate"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label class="text-danger">Status*</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFabStatus" runat="server">
                                        <asp:ListItem Value="0">Not Started</asp:ListItem>
                                        <asp:ListItem Value="6">In Process</asp:ListItem>
                                        <asp:ListItem Value="8">Submit For Review to India</asp:ListItem>
                                        <asp:ListItem Value="5">Completed</asp:ListItem>
                                        <asp:ListItem Value="1">In Production Canada</asp:ListItem>
                                        <asp:ListItem Value="2">Shipped</asp:ListItem>
                                        <asp:ListItem Value="3">Arrived</asp:ListItem>
                                        <asp:ListItem Value="4">In Production China</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Reviewed By</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReviewedByChina" runat="server" DataTextField="Name" DataValueField="EmployeeID" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Corrected By</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFabChinaCorrectedBy" runat="server" DataTextField="Abbrivation" DataValueField="EmployeeID"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Ship Date From China</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipDateFromChina" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtShipDateFromChina_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipDateFromChina" TargetControlID="txtShipDateFromChina"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Ex. Arrival Date from China</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtExpectedArrivalDatefromChina" AutoComplete="off" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender33" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtExpectedArrivalDatefromChina" TargetControlID="txtExpectedArrivalDatefromChina"></asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-sm-2 ">
                                <div class="form-group">
                                    <label>Container#</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtContainerNo" runat="server" MaxLength="50">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Production Status</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductionStatus" runat="server">
                                        <asp:ListItem Value="">Select</asp:ListItem>
                                        <asp:ListItem Value="F">Fully Completed</asp:ListItem>
                                        <asp:ListItem Value="P">Partially Completed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label>Production Remarks</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtProductionRemarks" TextMode="MultiLine" runat="server" oninput="return limitMultiLineInputLength(this, 500)">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-sm-4">
                                <label>&nbsp;</label>
                                <div class="form-group">
                                    <asp:Button ID="btnFabChinaDailyReport" runat="server" CssClass="btn btn-primary btn-sm mb-3" CausesValidation="false"
                                        Text="Daily Report" OnClick="btnFabChinaDailyReport_Click" />
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
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtReleasetoNesting" AutoComplete="off" runat="server" OnBlur="validateDate(this)" Enabled="false"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtReleasetoNesting" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtReleasetoNesting" TargetControlID="txtReleasetoNesting"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group">
                                    <label>Completion Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtProjectReleasedToShop" AutoComplete="off" runat="server" OnBlur="validateDate(this)" Enabled="false"></asp:TextBox>
                                    <asp:CalendarExtender ID="caltxtProjectReleasedToShop" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtProjectReleasedToShop" TargetControlID="txtProjectReleasedToShop"></asp:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                                <div class="form-group chosenFullWidth">
                                    <label>Project Status(Nesting)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNestingStatus" runat="server" Enabled="false">
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

                        <div class="row pt-3">
                            <div class="col-sm-12">
                                <h5 class="text-uppercase">Nesting Tasks</h5>
                                <div class="table-responsive">
                                    <asp:GridView CssClass="table mainGridTable table-sm mb-0" ForeColor="White" ID="gvNestingTasks" runat="server" AutoGenerateColumns="false" DataKeyNames="id"
                                        EnableModelValidation="True" ShowFooter="true" OnRowEditing="gvNestingTasks_RowEditing" OnRowDeleting="gvNestingTasks_RowDeleting" OnRowCancelingEdit="gvNestingTasks_RowCancelingEdit"
                                        OnRowUpdating="gvNestingTasks_RowUpdating" OnRowCommand="gvNestingTasks_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Task #" SortExpression="TaskNumber">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskNumber" runat="server" Text='<%# Eval("TaskNumber") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTaskNumber_EditNesting" runat="server" Text='<%#Eval("TaskNumber") %>'></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Nature of Task" SortExpression="NatureOfTask">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNatureOfTask" runat="server" Text='<%# Eval("NatureOfTask") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNatureOfTask_EditNesting" runat="server">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Value="NR">New Release</asp:ListItem>
                                                        <asp:ListItem Value="SP">Service Parts</asp:ListItem>
                                                        <asp:ListItem Value="RW">Rework</asp:ListItem>
                                                        <asp:ListItem Value="U">Urgent</asp:ListItem>
                                                        <asp:ListItem Value="E">Expedited</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblNatureOfTask_EditNesting" runat="server" Text='<%#Eval("NatureOfTask") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNatureOfTask_FooterNesting" runat="server">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Value="NR">New Release</asp:ListItem>
                                                        <asp:ListItem Value="SP">Service Parts</asp:ListItem>
                                                        <asp:ListItem Value="RW">Rework</asp:ListItem>
                                                        <asp:ListItem Value="U">Urgent</asp:ListItem>
                                                        <asp:ListItem Value="E">Expedited</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblNatureOfTask_FooterNesting" runat="server" Text='<%#Eval("NatureOfTask") %>' Visible="false"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Assigned From" SortExpression="AssignedFrom">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAssignedFrom" runat="server" Text='<%# Eval("AssignedFrom") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAssignedFrom_EditNesting" runat="server">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Value="F">Fabrication</asp:ListItem>
                                                        <asp:ListItem Value="S">Shop</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblAssignedFrom_EditNesting" runat="server" Text='<%#Eval("AssignedFrom") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAssignedFrom_FooterNesting" runat="server">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Value="F">Fabrication</asp:ListItem>
                                                        <asp:ListItem Value="S">Shop</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblAssignedFrom_FooterNesting" runat="server" Text='<%#Eval("AssignedFrom") %>' Visible="false"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Task Type" SortExpression="TaskType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskType" runat="server" Text='<%# Eval("TaskType") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTaskType_EditNesting" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                                                    <asp:Label ID="lblTaskType_EditNesting" runat="server" Width="140px" Text='<%#Eval("TaskType") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTaskType_FooterNesting" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                                                    <asp:Label ID="lblTaskType_FooterNesting" runat="server" Width="140px" Text='<%#Eval("TaskType") %>' Visible="false"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Project Engineer" SortExpression="ProjectEngineer">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectEngineer" runat="server" Text='<%# Eval("ProjectEngineer") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectEngineer_EditNesting" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                                                    <asp:Label ID="lblProjectEngineer_EditNesting" runat="server" Width="140px" Text='<%#Eval("ProjectEngineer") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectEngineer_FooterNesting" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                                                    <asp:Label ID="lblProjectEngineer_FooterNesting" runat="server" Width="140px" Text='<%#Eval("ProjectEngineer") %>' Visible="false"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtStartDate_EditNesting" OnBlur="validateDate(this)" runat="server"
                                                        Width="100%" Text='<%#Eval("StartDate") %>'></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtStartDate_EditNesting_Extender" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtStartDate_EditNesting" TargetControlID="txtStartDate_EditNesting">
                                                    </asp:CalendarExtender>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtStartDate_FooterNesting" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtStartDate_FooterNesting_Extender" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtStartDate_FooterNesting" TargetControlID="txtStartDate_FooterNesting">
                                                    </asp:CalendarExtender>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="End Date" SortExpression="EndDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtEndDate_EditNesting" OnBlur="validateDate(this)" runat="server"
                                                        Width="100%" Text='<%#Eval("EndDate") %>'></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtEndDate_EditNesting_Extender" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtEndDate_EditNesting" TargetControlID="txtEndDate_EditNesting">
                                                    </asp:CalendarExtender>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtEndDate_FooterNesting" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtEndDate_FooterNesting_Extender" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtEndDate_FooterNesting" TargetControlID="txtEndDate_FooterNesting">
                                                    </asp:CalendarExtender>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Sent Date" SortExpression="SentDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSentDate" runat="server" Text='<%# Eval("SentDate") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtSentDate_EditNesting" OnBlur="validateDate(this)" runat="server"
                                                        Width="100%" Text='<%#Eval("SentDate") %>'></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtSentDate_EditNesting_Extender" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtSentDate_EditNesting" TargetControlID="txtSentDate_EditNesting">
                                                    </asp:CalendarExtender>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtSentDate_FooterNesting" OnBlur="validateDate(this)" runat="server" Width="100%"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtSentDate_FooterNesting_Extender" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtSentDate_FooterNesting" TargetControlID="txtSentDate_FooterNesting">
                                                    </asp:CalendarExtender>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus_EditNesting" runat="server">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Value="0">Not started</asp:ListItem>
                                                        <asp:ListItem Value="1">In Progress</asp:ListItem>
                                                        <asp:ListItem Value="2">Completed</asp:ListItem>
                                                        <asp:ListItem Value="3">Shipment within 4 weeks</asp:ListItem>
                                                        <asp:ListItem Value="4">(P.O / Drawings) Not Received</asp:ListItem>
                                                        <asp:ListItem Value="5">On Hold</asp:ListItem>
                                                        <asp:ListItem Value="6">Used from Stock</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblStatus_EditNesting" runat="server" Text='<%#Eval("Status") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus_FooterNesting" runat="server">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Value="0">Not started</asp:ListItem>
                                                        <asp:ListItem Value="1">In Progress</asp:ListItem>
                                                        <asp:ListItem Value="2">Completed</asp:ListItem>
                                                        <asp:ListItem Value="3">Shipment within 4 weeks</asp:ListItem>
                                                        <asp:ListItem Value="4">(P.O / Drawings) Not Received</asp:ListItem>
                                                        <asp:ListItem Value="5">On Hold</asp:ListItem>
                                                        <asp:ListItem Value="6">Used from Stock</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblStatus_FooterNesting" runat="server" Text='<%#Eval("Status") %>' Visible="false"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Sent To Production" SortExpression="Sent To Production">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSentToProduction" runat="server" Text='<%# Eval("SentToProduction") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Modify">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" Text="Send To Production" CommandName="Send" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'><i class="far fa-paper-plane" title="Send To Production"></i></asp:LinkButton>
                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                         <i class="far fa-times-circle"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                                </EditItemTemplate>

                                                <FooterTemplate>
                                                    <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddRecord" runat="server" Text="Add" CommandName="Insert" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' />
                                                </FooterTemplate>

                                                <ItemStyle Width="120px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
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
                        <div class="col-12">
                            <div class="col-12">
                                <div class="form-group">
                                    <label class="boldtext"></label>
                                </div>
                            </div>
                        </div>

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

                                <input type="hidden" id="hdchk" runat="server" value="" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfFabricationCanadaId" runat="server" Value="-1" />
            <asp:HiddenField ID="hfShipToArriveDate" runat="server" Value="-1" />
            <asp:HiddenField ID="hfShipToArriveDateFillDetail" runat="server" Value="-1" />
            <asp:HiddenField ID="hfProjectStatus" runat="server" Value="-1" />
            <asp:HiddenField ID="hfPNumber" runat="server" Value="-1" />
            <asp:HiddenField ID="HfJObID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfReleased" runat="server" Value="" />
            <asp:HiddenField ID="hfCurrentUser" runat="server" Value="" />
            <asp:HiddenField ID="hfDataKeys" runat="server" Value="" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="lnkDowload" />
            <asp:PostBackTrigger ControlID="btnInf" />
            <%--<asp:PostBackTrigger ControlID="btnFabChinaDailyReport" />--%>
            <asp:PostBackTrigger ControlID="btnCuspack" />
            <asp:PostBackTrigger ControlID="btnAcknoledgement" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
        });

        function PageLoaded(sender, args) {
            DDLName();
        }
        $.when.apply($, PageLoaded).then(function () {
            DDLName();
        });

        function DDLName() {
            $('#<%=ddlProjectDesigner.ClientID%>').chosen();
            $('#<%=ddlProjectDesignerChina.ClientID%>').chosen();
            $('#<%=ddlProjectReviewerChina.ClientID%>').chosen();
            $('#<%=ddlFabDrawingPercentage.ClientID%>').chosen();
            $('#<%=ddlManuFac.ClientID%>').chosen();
            $('#<%=ddlManuFacChina.ClientID%>').chosen();
            $('#<%=ddlReviewedBy.ClientID%>').chosen();
            $('#<%=ddlReviewedByChina.ClientID%>').chosen();
            $('#<%=ddlNestingStatus.ClientID%>').chosen();
            $('#<%=ddlFabStatus.ClientID%>').chosen();
            $('#<%=ddlPurchasedItems.ClientID%>').chosen();
            $('#<%=ddlIssued.ClientID%>').chosen();
            $('#<%=ddlFabChinaCorrectedBy.ClientID%>').chosen();
            $('#<%=ddlProductionStatus.ClientID%>').chosen();
            $('#<%=ddlNatureOfTask_Grid.ClientID%>').chosen();
            $('#<%=ddlReleaseType_Grid.ClientID%>').chosen();
            $('#<%=ddlProjectDesigner_Grid.ClientID%>').chosen();
            $('#<%=ddlReviewedBy_Grid.ClientID%>').chosen();
            $('#<%=ddlWarehouse.ClientID%>').chosen();
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
        }

        function SetCSSFab() {

            document.getElementById("fabTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("sdTab").className = 'tab-pane fade pt-2';
            document.getElementById("sd-tab").className = 'nav-link';
            document.getElementById("fab-tab").className = 'nav-link active';
        }

        function SetCSSFirst() {
            document.getElementById("sdTab").className = 'tab-pane fade show active pt-2';
        }

        function SetCSS() {
            document.getElementById("sdTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("sd-tab").className = 'nav-link active';
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

        function SetCSSNesting() {
            document.getElementById("nesTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("sdTab").className = 'tab-pane fade pt-2';
            document.getElementById("sd-tab").className = 'nav-link';
            document.getElementById("nes-tab").className = 'nav-link active';
        }

        function SetCSSFabChina() {
            document.getElementById("fabChinaTab").className = 'tab-pane fade show active pt-2';
            document.getElementById("sdTab").className = 'tab-pane fade pt-2';
            document.getElementById("sd-tab").className = 'nav-link';
            document.getElementById("fabChina-tab").className = 'nav-link active';
        }

        function disableTabs(CountryID) {
            if (CountryID == 13) {
                SetCSSFabChina();
                document.getElementById('sd-tab').classList.add('disabled');
                document.getElementById('fab-tab').classList.add('disabled');
                document.getElementById('nes-tab').classList.add('disabled');
                document.getElementById('Model-tab').classList.add('disabled');
            }
        }


        function CheckFileValidations() {
            var fileInput = document.getElementById('<%= fileInput.ClientID %>');
            var file = fileInput.files[0];

            const MAX_FILE_SIZE = 819200;
            const ALLOWED_FILE_TYPE = 'application/pdf';

            // Check file size
            if (file.size > MAX_FILE_SIZE) {
                var filesize = "File size exceeds 800 KB. Please upload a smaller file.";
                toastr.error(filesize, '', { 'timeOut': 5000, 'hideDuration': 100, 'closeButton': true });
                fileInput.value = '';
                return;
            }

            // Check file type
            if (file.type !== ALLOWED_FILE_TYPE) {
                var filetype = "Only PDF files are allowed. Please upload a PDF file.";
                toastr.error(filetype, '', { 'timeOut': 5000, 'hideDuration': 100, 'closeButton': true });
                fileInput.value = '';
                return;
            }
        }
    </script>
</asp:Content>
