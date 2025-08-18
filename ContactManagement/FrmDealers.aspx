<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmDealers.aspx.cs" Inherits="ContactManagement_FrmDealers" %>

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
                            <h4 class="title-hyphen position-relative">Dealer Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-auto col-md-auto mb-3">
                                <label class="mb-0">Dealers</label></div>
                            <div class="col-sm col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDealer" runat="server" DataTextField="CompanyName" DataValueField="DealerID" AutoPostBack="True" OnSelectedIndexChanged="ddlDealer_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnProposals" runat="server" CssClass="btn btn-info btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Related Proposals" Enabled="false" OnClick="btnProposals_Click" />
                                <asp:Button ID="btnProjects" runat="server" CssClass="btn btn-primary btn-sm" Text="Related Projects" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnProjects_Click" />
                                  <asp:Button ID="btnExportData" runat="server" CssClass="btn btn-secondary btn-sm" Text="Export" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnExportData_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label></div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Dealer Details</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Company*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCompanyName" autocomplete="off" MaxLength="100" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Federal ID</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFedral" autocomplete="off" MaxLength="11" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Upload W9 Form</label>
                            <asp:FileUpload ID="fpUploadW9Form" CssClass="btn btn-success btn-sm btn-block" runat="server" />
                            <asp:LinkButton ID="lnkAttachment" runat="server" OnClick="lnkAttachment_Click"></asp:LinkButton>
                            <div id="dvLatUpdatedDate" runat="server" visible="false">                              
                                <asp:Label ID="lnkLastUpdatedDate" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Region</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRegion" runat="server" DataTextField="Region" DataValueField="RegionID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Country" DataValueField="CountryID" ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>State</label>
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" DataValueField="StateID" DataTextField="State" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                                <div class="input-group-prepend pl-1">
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStateAb" DataValueField="StateID" DataTextField="Sabb" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStateAb_SelectedIndexChanged"></asp:DropDownList></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Zip Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtZipCode" onkeypress="return onlyNumbers(event);" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtMainPhone" onkeypress="return onlyNumbers(event);" onblur="phoneMask(this)" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Toll Free</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTollFree" onkeypress="return onlyNumbers(event);" onblur="phoneMask(this)" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Fax</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtMainFax" onkeypress="return onlyNumbers(event);" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Toll Fax</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtTollFax" onkeypress="return onlyNumbers(event);" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Food Preference</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFoodPre" runat="server" DataTextField="FoodType" DataValueField="FoodId"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Agreed Discount %</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDiscount" autocomplete="off" runat="server" MaxLength="5" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Sales Rep</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRep" runat="server" DataTextField="TSM" DataValueField="RepID"></asp:DropDownList>
                        </div>
                    </div>
                   <div class="col-sm-3 d-flex align-items-center">
                        <div class="form-group mb-0">
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <div class="input-group-prepend pr-3">Head Office (Tick if Yes)</div>
                                <asp:CheckBox ID="chkHeadOffice" runat="server" AutoPostBack="True" Enabled="False" OnCheckedChanged="chkHeadOffice_CheckedChanged" />
                            </div>
                        </div>
                    </div>
                   
                        <div class="col-sm-6 col-md-3">
                            <div class="form-group">
                                <label>Head Office</label>
                                <div class="row">
                                    <div class="col-10">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlHeadOffice" runat="server" DataTextField="CompanyName" DataValueField="DealerID" AutoPostBack="True" OnSelectedIndexChanged="ddlHeadOffice_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <asp:Button ID="btnEditHeadOffice" CssClass="btn btn-success btn-sm" CausesValidation="false" Enabled="false" runat="server" Text="Edit"
                                    OnClick="btnEditHeadOffice_Click"></asp:Button>
                                </div>   
                                
                            </div>
                        </div>            
                         <div class="col-sm-3 d-flex align-items-center">
                        <div class="form-group mb-0">
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <div class="input-group-prepend pr-3">Dealer Rebate Program (Tick if Yes)</div>
                                <asp:CheckBox ID="chkAgree" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label>Preferences</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPrefrences" autocomplete="off" oninput="return limitMultiLineInputLength(this, 250)" runat="server" Height="43px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                <asp:ListItem Value="2">In-Active</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Contact Details</h5>
                    </div>
                    <div class="col-12">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvMember" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="ContactID" AllowPaging="false"
                                EmptyDataText="No Member has been added." OnRowDeleting="gvMember_RowDeleting" EnableModelValidation="True"
                                OnPageIndexChanging="gvMember_PageIndexChanging" OnRowEditing="gvMember_RowEditing" OnRowUpdating="gvMember_RowUpdating"
                                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                ForeColor="Black" OnRowCancelingEdit="gvMember_RowCancelingEdit">
                                <Columns>
                                    <asp:TemplateField HeaderText="Title*">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <%-- <asp:DropDownList ID="ddlTitleIn" runat="server" DataTextField="Title" DataValueField="Title"></asp:DropDownList>--%>
                                            <asp:TextBox ID="txtTitleIn" MaxLength="35" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Text='<%# Eval("Title") %>'></asp:TextBox>
                                            <asp:Label ID="lblTitleIn" runat="server" Text='<%# Eval("Title") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name*">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFName" MaxLength="20" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Text='<%# Eval("FName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLName" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtLName" MaxLength="20" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Text='<%# Eval("LName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Extension">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtExtension" MaxLength="6" CssClass="form-control form-control-sm" autocomplete="off" runat="server" Text='<%# Eval("Extension") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblExtension" runat="server" Text='<%# Eval("Extension") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control form-control-sm" MaxLength="25" onkeypress="return onlyNumbers(event);" onblur="phoneMask(this)" autocomplete="off" Text='<%# Eval("Phone") %>' Width="140"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cell ">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCell" runat="server" CssClass="form-control form-control-sm" onkeypress="return onlyNumbers(event);" MaxLength="25" onblur="phoneMask(this)" autocomplete="off" Text='<%# Eval("Cell") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCell" runat="server" Text='<%# Eval("Cell") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-sm" oninput="emailMask(this)" MaxLength="40" Text='<%# Eval("email") %>' Width="140"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modify">
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Member ?');" CommandName="Delete"><i class="far fa-times-circle" title="Delete"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="142px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                        <div class="table-responsive">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <th>Title*</th>
                                    <th>First Name*</th>
                                    <th>Last Name</th>
                                    <th>Extension</th>
                                    <th>Phone</th>
                                    <th>Cell</th>
                                    <th>Email</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTitle" runat="server" DataTextField="Title" DataValueField="Title">
    </asp:DropDownList>--%>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtTitle" MaxLength="35" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtFName" MaxLength="30" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtLName" MaxLength="30" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtExtension" MaxLength="6" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtPhone" onkeypress="return onlyNumbers(event);" MaxLength="25" onblur="phoneMask(this)" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtCell" onkeypress="return onlyNumbers(event);" MaxLength="25" onblur="phoneMask(this)" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" runat="server" oninput="emailMask(this)" MaxLength="40" autocomplete="off" />
                                    </td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddMember" runat="server" Text="Add Contact" OnClick="btnAddMember_Click" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="Hfw9formpath" runat="server" />
             <asp:HiddenField ID="HfHeadOffW9path" runat="server" />
                <asp:ModalPopupExtender ID="ModalPopupExtenderShowParts" runat="server" TargetControlID="LinkButton3"
                PopupControlID="PanelHeadOffice" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
                </asp:ModalPopupExtender>
                   
                <asp:Panel ID="PanelHeadOffice" runat="server" CssClass="ReportsModalPopup" Style="display: none;" Width="85%" Height="97%"> 
                <div class="position-relative h-100">   
                     <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="ImageButton1" runat="server" ImageUrl="../images/closebtnCircle.png"
                    AlternateText="Close Popup" ToolTip="Close Popup"  />                           
                    <div class="overflow-auto h-100">
                         <div class="col-12" style="position: sticky;top: 0; z-index: 107; background: white; padding: 10px;">
                            <div class="row" >
                            <div class="col-12">
                            <div class="form-group">
                            <asp:Button ID="btnHeadOfficeUpdate" CssClass="btn btn-success btn-sm" CausesValidation="false" runat="server" Text="Update" OnClick="btnHeadOfficeUpdate_Click">
                            </asp:Button>
                             <asp:Button ID="btnHeadOfficeCancel" CssClass="btn btn-danger btn-sm" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnHeadOfficeCancel_Click">
                            </asp:Button>
                            </div>
                            </div>        
                            </div>   
                           </div>   
                        <div class="table-responsive" style="position: sticky;width: 100%; height: 100%; overflow-y: auto;">   
                          <div class="col-12">                     
                             <div class="row pt-3">
                        <div class="col-12">
                        <asp:Label ID="Label1" runat="server"></asp:Label></div>
                        <div class="col-12">
                        <h5 class="text-uppercase">Dealer Details</h5>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label class="text-danger">Company*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeCompany"  autocomplete="off" MaxLength="100" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Federal ID</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeFedID" autocomplete="off" MaxLength="11" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Upload W9 Form</label>
                            <asp:FileUpload ID="fpHeadOfficeW9" CssClass="btn btn-success btn-sm btn-block" runat="server" />
                            <asp:LinkButton ID="lnkHeadOfficeW9" runat="server" OnClick="lnkHeadOfficeW9_Click"></asp:LinkButton>
                            <div id="dvHeadOfficeUpdatedDatetime" runat="server" visible="false">                              
                                <asp:Label ID="lblHeadOfficeUpdatedDatetime" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOffAddress" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group chosenFullWidth">
                            <label>Region</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlHeadOffRegion" runat="server" DataTextField="Region" DataValueField="RegionID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group chosenFullWidth">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" DataTextField="Country" DataValueField="CountryID" ID="ddlHeadOfficeCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHeadOfficeCountry_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group chosenFullWidth">
                            <label>State</label>
                            <div class="row">
                                <div class="col-8">
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlHeadOffState" DataValueField="StateID" DataTextField="State" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHeadOffState_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                             <div class="col-4">
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlHeadOfficeStateAbb" DataValueField="StateID" DataTextField="Sabb" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHeadOfficeStateAbb_SelectedIndexChanged"></asp:DropDownList></div>    
                            </div>    
                           
                        </div>

                    </div>  
               
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOffCity" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Zip Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOffZipCode" onkeypress="return onlyNumbers(event);" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOffPhone" onkeypress="return onlyNumbers(event);" onblur="phoneMask(this)" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Toll Free</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOffTollFree" onkeypress="return onlyNumbers(event);" onblur="phoneMask(this)" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Fax</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeFax" onkeypress="return onlyNumbers(event);" autocomplete="off" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Toll Fax</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeTollFax" onkeypress="return onlyNumbers(event);" autocomplete="off" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group chosenFullWidth">
                            <label>Food Preference</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlHeadOfficeFoodPref" runat="server" DataTextField="FoodType" DataValueField="FoodId"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label>Agreed Discount %</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOffAgreedDiscount" autocomplete="off" MaxLength="5" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group chosenFullWidth">
                            <label>Sales Rep</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlHeadOffSalesRep" runat="server" DataTextField="TSM" DataValueField="RepID"></asp:DropDownList>
                        </div>
                    </div>   
                    <div class="col-sm-3 d-flex align-items-center">
                        <div class="form-group mb-0">
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <div class="input-group-prepend pr-3">Dealer Rebate Program (Tick if Yes)</div>
                                <asp:CheckBox ID="chkHeadOffAgreement" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="form-group">
                            <label>Preferences</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficePref" autocomplete="off" oninput="return limitMultiLineInputLength(this, 250)" runat="server" Height="43px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group chosenFullWidth">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlHeadOfficeStatus" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                <asp:ListItem Value="2">In-Active</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                              <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Contact Details</h5>
                    </div>
                    <div class="col-12">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvDealerHOMember" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="ContactID" AllowPaging="false"
                                EmptyDataText="No Member has been added." OnRowDeleting="gvDealerHOMember_RowDeleting" EnableModelValidation="True"
                                OnPageIndexChanging="gvDealerHOMember_PageIndexChanging" OnRowEditing="gvDealerHOMember_RowEditing" OnRowUpdating="gvDealerHOMember_RowUpdating"
                                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                ForeColor="Black" OnRowCancelingEdit="gvDealerHOMember_RowCancelingEdit">
                                <Columns>
                                    <asp:TemplateField HeaderText="Title*">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHOTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <%-- <asp:DropDownList ID="ddlTitleIn" runat="server" DataTextField="Title" DataValueField="Title"></asp:DropDownList>--%>
                                            <asp:TextBox ID="txtHOTitleIn" MaxLength="35" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Text='<%# Eval("Title") %>'></asp:TextBox>
                                            <asp:Label ID="lblHOTitleIn" runat="server" Text='<%# Eval("Title") %>' Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name*">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHOFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHOFName" MaxLength="20" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Text='<%# Eval("FName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHOLName" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHOLName" MaxLength="20" CssClass="form-control form-control-sm" runat="server" autocomplete="off" Text='<%# Eval("LName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Extension">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHOExtension" MaxLength="6" CssClass="form-control form-control-sm" autocomplete="off" runat="server" Text='<%# Eval("Extension") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblHOExtension" runat="server" Text='<%# Eval("Extension") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHOPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHOPhone" runat="server" CssClass="form-control form-control-sm" MaxLength="25" onkeypress="return onlyNumbers(event);" onblur="phoneMask(this)" autocomplete="off" Text='<%# Eval("Phone") %>' Width="140"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cell ">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHOCell" runat="server" CssClass="form-control form-control-sm" onkeypress="return onlyNumbers(event);" MaxLength="25" onblur="phoneMask(this)" autocomplete="off" Text='<%# Eval("Cell") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblHOCell" runat="server" Text='<%# Eval("Cell") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHOEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHOEmail" runat="server" CssClass="form-control form-control-sm" oninput="emailMask(this)" MaxLength="40" Text='<%# Eval("email") %>' Width="140"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modify">
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkHOUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkHOCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnHOEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnHODelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Member ?');" CommandName="Delete"><i class="far fa-times-circle" title="Delete"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="142px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                        <div class="table-responsive">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <th>Title*</th>
                                    <th>First Name*</th>
                                    <th>Last Name</th>
                                    <th>Extension</th>
                                    <th>Phone</th>
                                    <th>Cell</th>
                                    <th>Email</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTitle" runat="server" DataTextField="Title" DataValueField="Title">
    </asp:DropDownList>--%>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeTitle" MaxLength="35" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeFName" MaxLength="30" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeLName" MaxLength="30" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeExtension" MaxLength="6" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficePhone" onkeypress="return onlyNumbers(event);" MaxLength="25" onblur="phoneMask(this)" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeCell" onkeypress="return onlyNumbers(event);" MaxLength="25" onblur="phoneMask(this)" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtHeadOfficeEmail" runat="server" oninput="emailMask(this)" MaxLength="40" autocomplete="off" />
                                    </td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnHOAddMember" runat="server" Text="Add Contact" OnClick="btnHOAddMember_Click" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                            </div>   
                        </div>
                    </div>
                </div>
                </asp:Panel>
                <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton> 
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnProposals"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnSave"></asp:PostBackTrigger>
             <asp:PostBackTrigger ControlID="btnHeadOfficeUpdate"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="lnkAttachment"></asp:PostBackTrigger>     
              <asp:PostBackTrigger ControlID="lnkHeadOfficeW9"></asp:PostBackTrigger>        
            <asp:PostBackTrigger ControlID="btnExportData"></asp:PostBackTrigger>      
        </Triggers>
    </asp:UpdatePanel>
     <CR:CrystalReportViewer ID="rptDealersReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlDealer.ClientID%>').chosen();
            $('#<%=ddlFoodPre.ClientID%>').chosen();
            $('#<%=ddlHeadOffice.ClientID%>').chosen();
            $('#<%=ddlRegion.ClientID%>').chosen();
            $('#<%=ddlRep.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlStateAb.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlHeadOfficeCountry.ClientID%>').chosen();
            $('#<%=ddlHeadOffState.ClientID%>').chosen();
            $('#<%=ddlHeadOfficeStateAbb.ClientID%>').chosen();
            $('#<%=ddlHeadOffRegion.ClientID%>').chosen();
            $('#<%=ddlHeadOffSalesRep.ClientID%>').chosen();
            $('#<%=ddlHeadOfficeStatus.ClientID%>').chosen();
            $('#<%=ddlHeadOfficeFoodPref.ClientID%>').chosen();
        }
    </script>
</asp:Content>