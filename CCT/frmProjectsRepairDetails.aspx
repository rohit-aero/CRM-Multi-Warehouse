<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmProjectsRepairDetails.aspx.cs" Inherits="CCT_frmProjectsRepairDetails" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-12 pb-3 pt-2 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Project Repair Details</h4>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl-9">
                        <div class="row">
                            <div class="col-sm-3 col-md-2">
                                <label class="mb-0">Job ID</label>
                            </div>
                            <div class="col-sm-9 col-md-10">
                                <asp:DropDownList ID="ddlJobID" DataValueField="JobID" DataTextField="JobID" runat="server" AutoPostBack="True" CssClass="w-100" OnSelectedIndexChanged="ddlJobID_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3 col-md-2 mt-3">
                                <label class="mb-0">Project Name</label>
                            </div>
                            <div class="col-sm-9 col-md-10 mt-3">
                                <asp:DropDownList ID="ddlProjectName" DataValueField="JobID" DataTextField="projectName" CssClass="w-100" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProjectName_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl">
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnSave" CssClass="btn btn-success btn-sm btn-block" runat="server" Text="Save" OnClick="btnSave_Click" />
                            </div>
                            <div class="col-sm-6">
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm btn-block" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">

                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Date(After Shipped)</h5>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Installation By</label>
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <asp:DropDownList ID="ddlInstallationby" DataTextField="Desc" Font-Bold="true" Enabled="false" CssClass="form-control form-control-sm" DataValueField="InstallationByID" runat="server"></asp:DropDownList>
                                <div class="input-group-prepend pl-1">
                                    <asp:DropDownList ID="ddlInstallatorA" DataTextField="FirstName" Font-Bold="true" DataValueField="EmployeeID" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Installation Start</label>
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <asp:TextBox ID="txtInstallDate" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender16" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtInstallDate" TargetControlID="txtInstallDate">
                                </asp:CalendarExtender>
                                <div class="input-group-prepend pl-1">
                                    <asp:DropDownList ID="ddlInstallatorB" DataTextField="FirstName" DataValueField="EmployeeID" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Installation End</label>
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <asp:TextBox ID="txtInstallationCompletionDate" runat="server" CssClass="form-control form-control-sm" Enabled="false" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtInstallationCompletionDate" TargetControlID="txtInstallationCompletionDate">
                                </asp:CalendarExtender>
                                <div class="input-group-prepend pl-1">
                                    <asp:DropDownList ID="ddlInstallorC" DataTextField="FirstName" DataValueField="EmployeeID" CssClass="form-control form-control-sm" Font-Bold="true" runat="server" Enabled="false">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Demo</label>
                            <asp:TextBox ID="txtDemoDate" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtDemoDate" TargetControlID="txtDemoDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Warranty Start</label>
                            <asp:TextBox ID="txtWarrantyStartDate" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtWarrantyStartDate" TargetControlID="txtWarrantyStartDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Warranty End</label>
                            <asp:TextBox ID="txtWarrantyEndDate" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtWarrantyEndDate" TargetControlID="txtWarrantyEndDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Follow Up</label>
                            <asp:TextBox ID="txtFollowUpDate" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtFollowUpDate" TargetControlID="txtFollowUpDate">
                            </asp:CalendarExtender>
                        </div>

                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Care Package</label>
                            <asp:TextBox ID="txtCustCarePackageSendDate" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtCustCarePackageSendDate" TargetControlID="txtCustCarePackageSendDate">
                            </asp:CalendarExtender>
                            <asp:Label ID="lblcarepakage" runat="server" Text="(Send To Customer)"></asp:Label>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Manuals Dispatched</label>
                            <asp:TextBox ID="txtmanualDispatchDate" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtmanualDispatchDate" TargetControlID="txtmanualDispatchDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                </div>

                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Shipping Information</h5>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Shipper</label>
                            <asp:DropDownList ID="ddlShipperID" DataTextField="Name" CssClass="form-control form-control-sm" Font-Bold="true" DataValueField="ShipperID" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Ship Date</label>
                            <asp:TextBox ID="txtShipDate" runat="server" CssClass="form-control form-control-sm" Enabled="false" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtShipDate" TargetControlID="txtShipDate">
                            </asp:CalendarExtender>
                            <asp:Label ID="lblShipDate" runat="server" Text="(Ship From Aerowerks)"></asp:Label>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Ship To Arrive</label>
                            <asp:TextBox ID="txtShipToArrive" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender10" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtShipToArrive" TargetControlID="txtShipToArrive">
                            </asp:CalendarExtender>
                            <asp:Label ID="lblShipToArrive" runat="server" Text="(Customer Wants Date)"></asp:Label>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Arrival Date</label>
                            <asp:TextBox ID="txtArrivalDate" runat="server" Enabled="false" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender11" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtArrivalDate" TargetControlID="txtArrivalDate">
                            </asp:CalendarExtender>
                            <asp:Label ID="lblArrivalDate" runat="server" Text="(Customer's Site Date)"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Reps Information</h5>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Consultant Rep</label>
                            <asp:DropDownList ID="ddlConsultantRep" DataTextField="TSM" CssClass="form-control form-control-sm" DataValueField="RepID" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Origination Rep</label>
                            <asp:DropDownList ID="ddlOriginationRep" DataTextField="TSM" CssClass="form-control form-control-sm" DataValueField="RepID" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Destination Rep</label>
                            <asp:DropDownList ID="ddlDestinationRep" DataTextField="TSM" CssClass="form-control form-control-sm" DataValueField="RepID" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Dealer</label>
                            <asp:DropDownList ID="ddlDealer" DataTextField="CompanyName" CssClass="form-control form-control-sm" DataValueField="DealerID" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Consultant</label>
                            <asp:DropDownList ID="ddlConsultant" DataTextField="CompanyName" CssClass="form-control form-control-sm" DataValueField="ConsultantID" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>
                </div>


                <asp:Panel ID="PanelgvDisplay" runat="server" Enabled="false">
                    <div class="row border-top pt-3">
                        <div class="col-12">
                            <h5 class="text-uppercase">Add New Record</h5>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Ticket #</label>
                                <asp:Label ID="lblTicketNo" runat="server" Text="" CssClass="form-control form-control-sm"></asp:Label>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Category</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="1">Repair</asp:ListItem>
                                    <asp:ListItem Value="2">Install Issue</asp:ListItem>
                                    <asp:ListItem Value="3">Modification</asp:ListItem>
                                    <asp:ListItem Value="4">Inspections</asp:ListItem>
                                    <asp:ListItem Value="5">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Issue</label>
                                <asp:TextBox ID="txtIssue" runat="server" TextMode="MultiLine" CssClass="form-control form-control-sm" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Issue Open</label>
                                <asp:TextBox ID="txtIssueopen" runat="server" autocomplete="off" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender12" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtIssueopen" TargetControlID="txtIssueopen">
                                </asp:CalendarExtender>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Issue Close</label>
                                <asp:TextBox ID="txtIssueClose" runat="server" autocomplete="off" CssClass="form-control form-control-sm" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender13" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtIssueClose" TargetControlID="txtIssueClose">
                                </asp:CalendarExtender>
                            </div>
                        </div>


                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Promised Date</label>
                                <asp:TextBox ID="txtPromised" runat="server" CssClass="form-control form-control-sm" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender14" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtPromised" TargetControlID="txtPromised">
                                </asp:CalendarExtender>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Follow Up</label>
                                <asp:TextBox ID="txtFollowup" runat="server" CssClass="form-control form-control-sm" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender15" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtFollowup" TargetControlID="txtFollowup">
                                </asp:CalendarExtender>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Status</label>
                                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="1">Done</asp:ListItem>
                                    <asp:ListItem Value="2">Progress</asp:ListItem>
                                    <asp:ListItem Value="3">Pending Info/On Hold</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Assigned To</label>
                                <asp:TextBox ID="txtAssignedto" runat="server" CssClass="form-control form-control-sm" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Service PO</label>
                                <asp:TextBox ID="txtServicePO" runat="server" CssClass="form-control form-control-sm" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Hobart Service Branch</label>
                                <asp:DropDownList ID="ddlHobartServiceBranch" DataTextField="RepsLocation" DataValueField="ServiceRepID" runat="server" CssClass="form-control form-control-sm"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelgvTicketDetails" runat="server">
                    <div class="row">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvProjectRepairDetails" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowEditing="gvProjectRepairDetails_RowEditing"
                                    DataKeyNames="TicketNo" EmptyDataText="No Data has been added." OnRowCancelingEdit="gvProjectRepairDetails_RowCancelingEdit" OnRowUpdating="gvProjectRepairDetails_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Ticket No">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblgvTicketno" runat="server" Text='<%# Eval("TicketNo") %>' Width="120px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvTicketNumber" runat="server" Text='<%# Eval("TicketNo") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Category">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlgvCategory" runat="server" DataTextField="Task" DataValueField="Task" Width="120px">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="Repair">Repair</asp:ListItem>
                                                    <asp:ListItem Value="Install Issue">Install Issue</asp:ListItem>
                                                    <asp:ListItem Value="Modification">Modification</asp:ListItem>
                                                    <asp:ListItem Value="Inspections">Inspections</asp:ListItem>
                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblCategorySelect" runat="server" Text='<%# Eval("Task") %>' Visible="false"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemCategory" runat="server" Text='<%# Eval("Task") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Issue">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvIssue" runat="server" TextMode="MultiLine" Text='<%# Eval("Issue") %>' Width="120px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemIssue" runat="server" Text='<%# Eval("Issue") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Issue Open">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvIssueOpen" runat="server" Text='<%# Eval("IssueOpenDate") %>' Width="120px" OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvIssueOpen" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtgvIssueOpen" TargetControlID="txtgvIssueOpen">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemIssueOpen" runat="server" Text='<%# Eval("IssueOpenDate") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Issue Close">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvIssueClose" runat="server" Text='<%# Eval("IssueCloseDate") %>' Width="120px" OnBlur="validateDate(this)"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvIssueClose" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtgvIssueClose" TargetControlID="txtgvIssueClose">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemIssueClose" runat="server" Text='<%# Eval("IssueCloseDate") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Promised Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvPromisedDate" runat="server" Text='<%# Eval("PromisedDate") %>' OnBlur="validateDate(this)" Width="120px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvPromisedDate" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtgvPromisedDate" TargetControlID="txtgvPromisedDate">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemPromisedDate" runat="server" Text='<%# Eval("PromisedDate") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Follow Up">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvFollowup" runat="server" Text='<%# Eval("FollowUpDate") %>' OnBlur="validateDate(this)" Width="120px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvFollowupDate" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtgvFollowup" TargetControlID="txtgvFollowup">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemFollowup" runat="server" Text='<%# Eval("FollowUpDate") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlgvStatus" runat="server" DataTextField="Status" DataValueField="Status" Width="120px">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="Done">Done</asp:ListItem>
                                                    <asp:ListItem Value="Progress">Progress</asp:ListItem>
                                                    <asp:ListItem Value="Pending Info/On Hold">Pending Info/On Hold</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblStatusSelect" runat="server" Text='<%# Eval("Status") %>' Visible="false"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemStatus" runat="server" Text='<%# Eval("Status") %>' Width="120px"> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Assigned To">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvAssignedTo" runat="server" Text='<%# Eval("AssignTo") %>' Width="120px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemAssignedTo" runat="server" Text='<%# Eval("AssignTo") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Service PO">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgvServicePO" runat="server" Text='<%# Eval("ServicePO") %>' Width="120px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemServicePO" runat="server" Text='<%# Eval("ServicePO") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Hobart Service Branch">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlgvHobartServiceBranch" runat="server" Width="120px" DataTextField="RepsLocation" DataValueField="ServiceRepID">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblHobartBarnchSelect" runat="server" Text='<%# Eval("HobartServiceBranch") %>' Visible="false"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvItemHobartServiceBranch" runat="server" Text='<%# Eval("HobartServiceBranch") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update">Update</asp:LinkButton>
                                                &nbsp;
                                                 <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>

            <script type="text/javascript">
                $(document).ready(function () {

                    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
                });
                function PageLoaded(sender, args) {

                    DDL();

                }
                $.when.apply($, PageLoaded).then(function () {
                    DDL();

                });

                function DDL() {
                    $('#<%=ddlJobID.ClientID%>').chosen();
                    $('#<%=ddlProjectName.ClientID%>').chosen();
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
