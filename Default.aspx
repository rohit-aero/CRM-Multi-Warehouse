<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMain.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="container-xl" style="display: none;">
                <div class="row align-items-center">

                    <div class="col-md-5 mt-md-4">
                        <img src="images/ursImage.jpg" class="img-fluid mx-auto img-thumbnail rounded" alt="Aerowerks Machine" />
                    </div>
                    <div class="col-md mt-md-4">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">First</th>
                                        <th scope="col">Last</th>
                                        <th scope="col">Handle</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th scope="row">1</th>
                                        <td>Mark</td>
                                        <td>Otto</td>
                                        <td>@mdo</td>
                                    </tr>
                                    <tr>
                                        <th scope="row">2</th>
                                        <td>Jacob</td>
                                        <td>Thornton</td>
                                        <td>@fat</td>
                                    </tr>
                                    <tr>
                                        <th scope="row">3</th>
                                        <td>Larry the Bird</td>
                                        <td>@twitter</td>
                                        <td>@facebook</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div id="old" runat="server" visible="false">
                <fieldset style="width: 28%; display: none;">
                    <legend>
                        <asp:Literal ID="ltList" runat="server"></asp:Literal></legend>
                    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <Columns>
                            <asp:BoundField DataField="EmpName" HeaderText="Happy Birthday !!">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dob" HeaderText="DOB">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#0856a1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFFFF" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </fieldset>
                <div class="col-sm">
                    <fieldset>
                        <legend>Currently Logged In Users</legend>
                        <asp:GridView ID="gvActiveUsers" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                            BackColor="#DEBA84" BorderColor="#0856A1" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                            <Columns>
                                <asp:BoundField DataField="EmployeeName" HeaderText="User" />
                            </Columns>
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#0856a1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFFFF" ForeColor="#000000" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </fieldset>
                </div>
                <div class="col-sm">
                    <fieldset>
                        <legend>Office Ext. Canada</legend>
                        <div style="width: 100%;">
                            <asp:GridView ID="gvExt" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                                BackColor="#DEBA84" BorderColor="#0856A1" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ext" HeaderText="Ext.">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <HeaderStyle BackColor="#0856a1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle ForeColor="#000000" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFFFF" ForeColor="#000000" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                    </fieldset>
                </div>
                <div class="col-sm">
                    <fieldset>
                        <legend>Office Ext. India</legend>
                        <div style="width: 100%; overflow: auto">
                            <asp:GridView ID="gvExtIndia" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                                BackColor="#DEBA84" BorderColor="#0856A1" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ext" HeaderText="Ext.">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <HeaderStyle BackColor="#0856a1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFFFF" ForeColor="#000000" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="row">

                    <div class="col-sm col-md-12">
                        <button id="opener" type="button" runat="server" visible="false" class="btn btn-success btn-sm" data-toggle="modal" title="Show Pending Followups List" data-target="#myModal" data-backdrop="static" data-keyboard="false">Show Pending Followups List</button>
                        <button id="openerNotFollowedup" type="button" runat="server" visible="false" class="btn btn-success btn-sm" data-toggle="modal" title="Show Not Followedup List" data-target="#myModal2" data-backdrop="static" data-keyboard="false">Show Not Followedup List</button>
                        <asp:Button ID="btnopener" runat="server" class="btn btn-success btn-sm" Text="Show Pending Followups List" Visible="false" OnClick="btnopener_Click" />
                        <asp:Button ID="btnopenerNotFollowedup" class="btn btn-success btn-sm" runat="server" Visible="false" Text="Show Not Followedup List" OnClick="btnopenerNotFollowedup_Click" />
                        <asp:Button ID="btnShipDateUpdates" class="btn btn-success btn-sm" runat="server" Visible="false" Text="Ship Date History" OnClick="btnShipDateUpdates_Click" />
                        <asp:Button ID="btnEngineerTask" class="btn btn-success btn-sm" Visible="false" runat="server" Text="Pending Tasks List" OnClick="btnEngineerTask_Click" />
                        <button id="btnTrackContainerJobs" type="button" runat="server" visible="false" class="btn btn-success btn-sm" data-toggle="modal" title="Track Jobs Status" data-target="#containerJobsModal" data-backdrop="static" data-keyboard="false">Track Container Jobs</button>
                        <asp:Button ID="btnTrackJobs" class="btn btn-success btn-sm" runat="server" Visible="false" Text="Track Jobs Status" OnClick="btnTrackJobs_Click" />

                        <div id="dvMsg" runat="server" visible="false">
                            <strong class="text-center">
                                <asp:Label runat="server" CssClass="alert alert-success d-block py-1 mb-0" ID="lblMsg"></asp:Label></strong>
                        </div>
                    </div>
                    <div class="col-sm col-md-6">
                    </div>
                </div>
            </div>
            <div class="table-responsive eoeTable" style="height: 750px; display: none">
                <asp:GridView ID="gvSearch" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="verticalHeading mx-auto text-center"
                    EnableModelValidation="True" OnRowDataBound="gvSearch_RowDataBound">
                </asp:GridView>
            </div>
            <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header d-flex justify-content-between align-items-center w-100">
                            <div class="d-flex align-items-center">
                                <h5 class="modal-title mb-0" id="Header" runat="server"></h5>
                            </div>

                            <div class="d-flex align-items-center">
                                <asp:Button
                                    CssClass="btn btn-primary btn-sm mr-2"
                                    ID="btnExportToExcel_PendingFollowupList"
                                    CausesValidation="false"
                                    runat="server"
                                    Text="Export To Excel"
                                    OnClick="btnExportToExcel_PendingFollowupList_Click" />

                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                        </div>
                        <div class="modal-body" style="height: 500px; overflow-y: scroll;">
                            <%-- <p>Here are Proposals you haven't followed up.</p>--%>
                            <asp:GridView ID="gvPendingList" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True" Width="100%" AutoGenerateColumns="false"
                                BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowCommand="gvPendingList_RowCommand" OnRowDataBound="gvPendingList_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="PNumber" HeaderText="P#" />
                                    <asp:BoundField DataField="JobID" HeaderText="J#" />
                                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />
                                    <asp:BoundField DataField="followupdate" HeaderText="Followed up Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="nextfollowupdate" HeaderText="Scheduled Followup Date" DataFormatString="{0:MM/dd/yyyy}" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div id="myModal2" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header d-flex justify-content-between align-items-center w-100">
                            <div class="d-flex align-items-center">
                                <h5 class="modal-title mb-0" id="H1" runat="server"></h5>
                            </div>

                            <div class="d-flex align-items-center">
                                <asp:Button
                                    CssClass="btn btn-primary btn-sm mr-2"
                                    ID="btnExportToExcel_NotFollowedupList"
                                    CausesValidation="false"
                                    runat="server"
                                    Text="Export To Excel"
                                    OnClick="btnExportToExcel_NotFollowedupList_Click" />

                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                        </div>
                        <div class="modal-body" style="height: 500px; overflow-y: scroll;">
                            <%-- <p>Here are Proposals you haven't followed up.</p>--%>
                            <asp:GridView ID="gvListNot" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True" Width="100%" AutoGenerateColumns="false"
                                BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField DataField="ProposalDate" HeaderText="Proposal Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="Manager" HeaderText="PM" />
                                    <asp:BoundField DataField="Project Stage" HeaderText="Stage" />
                                    <asp:BoundField DataField="PNumber" HeaderText="P#" />
                                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />
                                    <asp:BoundField DataField="City" HeaderText="City" />
                                    <asp:BoundField DataField="State" HeaderText="State" />
                                    <asp:BoundField DataField="NetEqPrice" HeaderText="NetEqPrice" DataFormatString="{0:0.00}" />

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div id="myModal3" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header d-flex justify-content-between align-items-center w-100">
                            <div class="d-flex align-items-center">
                                <h5 class="modal-title mb-0" id="H2" runat="server"></h5>
                            </div>
                            <div class="d-flex align-items-center">
                                <asp:Button
                                    CssClass="btn btn-primary btn-sm mr-2"
                                    ID="btnExportToExcel_ShipDateHistory"
                                    CausesValidation="false"
                                    runat="server"
                                    Text="Export To Excel"
                                    OnClick="btnExportToExcel_ShipDateHistory_Click" />
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                        </div>
                        <div class="modal-body" style="height: 500px; overflow-y: scroll;">
                            <%-- <p>Here are Proposals you haven't followed up.</p>--%>
                            <asp:GridView ID="gvShipDateUpdates" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True" Width="100%" AutoGenerateColumns="false"
                                BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField DataField="JobID" HeaderText="Job ID" />
                                    <asp:BoundField DataField="OldShipDate" HeaderText="Old Ship Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="NewShipDate" HeaderText="New Ship Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="FirstName" HeaderText="Updated By" />
                                    <asp:BoundField DataField="UpdatedDate" HeaderText="Updated On" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnEngineerTask"
                PopupControlID="Panel_EngineerPendingTasks" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel_EngineerPendingTasks" runat="server" CssClass="ReportsModalPopup" Style="display: none" Width="80%" Height="60%">
                <div class="position-relative h-100">
                    <asp:ImageButton CssClass="position-absolute crossCloseBtn" ID="btnClose" runat="server" Style="z-index: 9" ImageUrl="../images/closebtnCircle.png"
                        AlternateText="Close Popup" ToolTip="Close Popup" />
                    <div class="row">
                        <div class="col-12">
                            <h5>&nbsp;</h5>
                        </div>
                    </div>
                    <div class="overflow-auto h-100">
                        <div class="col-12">
                            <div class="col-12">
                                <div class="form-group">
                                    <h5 class="modal-title" id="EngineerTaskHeader" runat="server"></h5>
                                    </b>
                                </div>
                            </div>

                            <div class="col-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="gvEngineerTask" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True" Width="100%" AutoGenerateColumns="false"
                                        BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="ID" OnRowEditing="gvEngineerTask_Editing" EmptyDataText="No Pending Task">
                                        <Columns>
                                            <asp:BoundField DataField="PNumber" HeaderText="PNumber" />
                                            <asp:BoundField DataField="PName" HeaderText="Project Name" />
                                            <asp:BoundField DataField="Priority" HeaderText="Priority" />
                                            <asp:BoundField DataField="Task" HeaderText="Task" />
                                            <asp:TemplateField HeaderText="Update Task">
                                                <ItemTemplate>
                                                    <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit">
                                                <i class="far fa-edit" title="Edit"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>                
            </asp:Panel>

            <div id="containerJobsModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="containerJobsLabel" aria-hidden="true">
                <div class="modal-dialog modal-xl">
                    <div class="modal-content">
                        <div class="modal-header d-flex justify-content-between align-items-center w-100">
                            <div class="d-flex align-items-center">
                                <h5 class="modal-title mb-0" id="containerJobsHeader" runat="server"></h5>
                            </div>
                            <div class="d-flex align-items-center">
                                <asp:Button
                                    CssClass="btn btn-primary btn-sm mr-2"
                                    ID="btnExportToExcel_TrackJobStatus"
                                    CausesValidation="false"
                                    runat="server"
                                    Text="Export To Excel"
                                    OnClick="btnExportToExcel_TrackJobStatus_Click" />
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                        </div>
                        <div class="modal-body" style="height: 500px; overflow-y: scroll;">
                            <%-- <p>Here are Proposals you haven't followed up.</p>--%>
                            <asp:GridView ID="gvContainerJobs" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True" Width="100%" AutoGenerateColumns="true"
                                BorderWidth="1px" CellPadding="3" CellSpacing="2">
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12" id="divDashboard" runat="server">
                <div class="container-fluid p-0 m-0 mt-1">
                    <%--                    <ul class="nav nav-tabs" id="dashboardTabs" role="tablist">
                       <li class="nav-item">
                            <a class="nav-link active" id="tab-one-tab" data-toggle="tab" href="#tab-one" role="tab">Sales Target vs Actual Sales</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="tab-two-tab" data-toggle="tab" href="#tab-two" role="tab">YTD Quotes</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="tab-three-tab" data-toggle="tab" href="#tab-three" role="tab">YTD Orders</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="tab-four-tab" data-toggle="tab" href="#tab-four" role="tab">Shipped Projects</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="tab-five-tab" data-toggle="tab" href="#tab-five" role="tab">Sales Region Wise</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="tab-six-tab" data-toggle="tab" href="#tab-six" role="tab">Sales Rep Wise</a>
                        </li>
                    </ul>--%>

                    <div class="tab-content p-3 border-top-0" id="dashboardTabsContent">
                        <!-- Tab 1 -->
                        <div class="tab-pane fade show active" id="tab-one" role="tabpanel" aria-labelledby="tab-one-tab">
                            <div class="row border-bottom">
                                <h4 class="col-12 title-hyphen">Sales Target vs Actual Sales <%= DateTime.Now.Year %></h4>
                                <div class="col-4">
                                    <div class="col-12">
                                        <div class="table-responsive eoeTable">
                                            <asp:GridView ID="gvProjectedVsActual" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True"
                                                AutoGenerateColumns="False" OnRowDataBound="gvProjectedVsActual_RowDataBound" ShowFooter="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr.No." HeaderStyle-CssClass="align-right" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSrNo" runat="server" Text='<%# Eval("SrNo") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Month">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMonth" runat="server" Text='<%# Eval("Month") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Projected Sale" HeaderStyle-CssClass="align-right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProjectedSale" runat="server" Text='<%# Eval("ProjectedSales", "{0:C0}") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Actual Sales" HeaderStyle-CssClass="align-right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblActualSale" runat="server" Text='<%# Eval("ActualSales", "{0:C0}") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-8">
                                    <div id="ProjectsVsActualChart" class="h-100 w-100"></div>
                                </div>
                            </div>

                            <div class="row border-bottom" style="display: none;">
                                <h4 class="col-12 title-hyphen">Sales Target vs Actual Sales</h4>
                                <div class="col-8">
                                    <div class="col-12 border-bottom">
                                        <div class="form-group mb-0">
                                            <label>Sales Target</label>
                                            <label runat="server" id="lblSalesTarget"></label>
                                            <br />
                                            <label runat="server" id="lblUSTarget"></label>
                                            <label runat="server" id="lblCADTarget"></label>
                                        </div>
                                    </div>

                                    <div class="col-12 border-bottom">
                                        <div class="form-group mb-0">
                                            <label>Actual Sales To Date</label>
                                            <label runat="server" id="lblActualSales"></label>
                                            <br />
                                            <label runat="server" id="lblUSSales"></label>
                                            <label runat="server" id="lblCADSales"></label>
                                        </div>
                                    </div>

                                    <div class="col-4">
                                        <div class="form-group">
                                            <label>Target Completion - </label>
                                            <label runat="server" id="lblTargetCompletion"></label>
                                            <br />
                                            <label runat="server" id="lblUSCompletionPercent"></label>
                                            <label runat="server" id="lblCADCompletionPercent"></label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-4">
                                    <div id="chtTotal" style="height: 200px;"></div>
                                </div>
                            </div>
                        </div>

                        <!-- Tab 2 -->
                        <div class="tab-pane fade" id="tab-two" role="tabpanel" aria-labelledby="tab-two-tab">
                            <!-- Paste content from collapseTwo here -->
                            <div class="row border-bottom">
                                <div class="col-sm-12">
                                    <h4 class="title-hyphen position-relative">YTD Quotes</h4>
                                </div>
                                <div class="col-6">
                                    <div class="col-12">
                                        <div class="table-responsive eoeTable">
                                            <asp:GridView ID="gvQuotesMonthly" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True"
                                                AutoGenerateColumns="False" OnRowDataBound="gvQuotesMonthly_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Month">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMonth" runat="server" Text='<%# Eval("QuoteMonth") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="200px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No. of Quotes Generated" HeaderStyle-CssClass="align-right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNoofQuotesGenerated" runat="server" Text='<%# Eval("MonthlyQuoteCount") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="200px" HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Amount (In $)" HeaderStyle-CssClass="align-right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Eval("MonthlyTotal", "{0:C}") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="200px" HorizontalAlign="Right" />
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div id="YTDComboChart_div"></div>
                                </div>
                            </div>
                        </div>

                        <!-- Tab 3 -->
                        <div class="tab-pane fade" id="tab-three" role="tabpanel" aria-labelledby="tab-three-tab">
                            <!-- Paste content from collapseThree here -->
                            <div class="row border-bottom">
                                <h4 class="col-12 title-hyphen position-relative">YTD Orders</h4>
                                <div class="col-6">
                                    <div class="col-sm-6" id="dvOrdersBooked" runat="server">
                                        <div class="form-group">
                                            <label class="mb-0">No. of Orders Booked (US + CAD):</label>
                                            <asp:Label ID="lblNoofOrdersBooked" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-sm-6" id="dvTotal" runat="server">
                                        <div class="form-group">
                                            <label>Total (US + CAD):</label>
                                            <asp:Label ID="lblValueofOrders" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-12 row">
                                        <div class="col-12">
                                            <div class="table-responsive eoeTable">
                                                <asp:GridView ID="gvOrders" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True"
                                                    AutoGenerateColumns="False" OnRowDataBound="gvOrders_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Month">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMonthOrders" runat="server" Text='<%# Eval("OrdersMonth") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="US PO  Booked" HeaderStyle-CssClass="align-right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUSAPOCount" runat="server" Text='<%# Eval("USOrderCount") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20%" HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="US PO Rec." HeaderStyle-CssClass="align-right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalUSAPORec" runat="server" Text='<%# Eval("TotalUSPORec", "{0:C}") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20%" HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CAD PO  Booked" HeaderStyle-CssClass="align-right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCanadaPOCount" runat="server" Text='<%# Eval("CanadaOrderCount") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20%" HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CAD PO Rec." HeaderStyle-CssClass="align-right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalCanadaPORec" runat="server" Text='<%# Eval("TotalCanadaPORec", "{0:C}") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20%" HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div id="YTDOrdersComboChart_div"></div>
                                </div>
                            </div>
                        </div>

                        <!-- Tab 4 -->
                        <div class="tab-pane fade" id="tab-four" role="tabpanel" aria-labelledby="tab-four-tab">
                            <!-- Paste content from collapseFour here -->
                            <div class="row border-bottom">
                                <h4 class="col-12 title-hyphen">Shipped Projects</h4>
                                <div class="col-6">
                                    <div class="col-12 border-bottom">
                                        <div class="form-group mb-0">
                                            <label>Projects Shipped</label>
                                            <label runat="server" id="lblTotalProjectsShipped"></label>
                                            <br />
                                            <label runat="server" id="lblUSProjectsShipped"></label>
                                            <label runat="server" id="lblCADProjectsShipped"></label>
                                        </div>
                                    </div>

                                    <div class="col-12 border-bottom">
                                        <div class="form-group mb-0">
                                            <label>Values of Projects Shipped</label>
                                            <label runat="server" id="lblValuesOfProjectsShipped"></label>
                                            <br />
                                            <label runat="server" id="lblUSProjectsShippedAmount"></label>
                                            <label runat="server" id="lblCADProjectsShippedAmount"></label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div id="chtComboChart"></div>
                                </div>
                            </div>
                        </div>

                        <!-- Tab 5 -->
                        <div class="tab-pane fade" id="tab-five" role="tabpanel" aria-labelledby="tab-five-tab">
                            <!-- Paste content from collapseFive here -->
                            <div class="row border-bottom">
                                <h4 class="col-12 title-hyphen">Sales Region Wise</h4>
                                <div class="col-6">
                                    <label class="col-10 mb-0 border-bottom" runat="server" id="lblTotalSales"></label>
                                    <div class="col-12 row">
                                        <div class="col-12">
                                            <div class="table-responsive eoeTable">
                                                <asp:GridView ID="gvSalesMonthWiseSearch" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="table mainGridTable table-sm mb-0"
                                                    EnableModelValidation="True" AutoGenerateColumns="false" OnRowDataBound="gvSalesMonthWiseSearch_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Region">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRegion" runat="server" Text='<%# Eval("Region") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sales" HeaderStyle-CssClass="align-right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNetAmount" runat="server" Text='<%# "$" + String.Format("{0:N2}", Eval("NetAmount")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-6">
                                    <div id="chtBarChart"></div>
                                </div>
                            </div>
                        </div>

                        <!-- Tab 6 -->
                        <div class="tab-pane fade" id="tab-six" role="tabpanel" aria-labelledby="tab-six-tab">
                            <!-- Paste content from collapseFive here -->
                            <div class="row border-bottom">
                                <h4 class="col-12 title-hyphen">Sales Rep Wise</h4>
                                <div class="col-6 ">
                                    <div class="col-12 row ">
                                        <div class="col-5 pl-0" style="display: none">
                                            <div class="form-group">
                                                <label>Regions</label>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRegions" DataTextField="text" DataValueField="id" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-5 pl-0">
                                            <div class="form-group chosenFullWidth">
                                                <label>Reps</label>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReps" DataTextField="text" DataValueField="id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReps_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <%--<div class="col-2">
                                            <label>&nbsp;</label>
                                            <div class="form-group">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Search" OnClick="btnSearch_Click" />
                                            </div>
                                        </div>--%>
                                    </div>
                                    <div class="col-12 pl-0">
                                        <div class="table-responsive eoeTable" style="height: 515px">
                                            <asp:GridView ID="gvSalesMonthWiseSearch_Rep" runat="server" CellPadding="3" EmptyDataText="No Items Found" Width="100%" CssClass="table mainGridTable table-sm mb-0"
                                                EnableModelValidation="True" AutoGenerateColumns="false" OnRowDataBound="gvSalesMonthWiseSearch_Rep_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Rep">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRep" runat="server" Text='<%# Eval("Rep") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sales" HeaderStyle-CssClass="align-right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNetAmount" runat="server" Text='<%# "$" + String.Format("{0:N2}", Eval("NetAmount")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row border-bottom">
                            <h4 class="col-12 title-hyphen">Quotes vs Orders <%= DateTime.Now.Year %></h4>
                            <div class="col-4">
                                <%--                                <div class="col-sm-6" id="Div1" runat="server">
                                        <div class="form-group">
                                            <label class="mb-0">No. of Orders Booked (US + CAD):</label>
                                            <asp:Label ID="Label1" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-sm-6" id="Div2" runat="server">
                                        <div class="form-group">
                                            <label>Total (US + CAD):</label>
                                            <asp:Label ID="Label2" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>--%>
                                <div class="col-12">
                                    <div class="table-responsive eoeTable">
                                        <asp:GridView ID="gvQuotesandOrders" CssClass="table mainGridTable table-sm" runat="server" EnableModelValidation="True"
                                            AutoGenerateColumns="False" OnRowDataBound="gvQuotesandOrders_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Month">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuotesandOrdersMonth" runat="server" Text='<%# Eval("MonthName") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Quotes Sent" HeaderStyle-CssClass="align-right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalQuotesSent" runat="server" Text='<%# Eval("MonthlyQuoteCount") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Value of Quotes Sent" HeaderStyle-CssClass="align-right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalQuotesValue" runat="server" Text='<%# Eval("TotalQuoteValue","{0:$#,##0}") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Orders  Booked" HeaderStyle-CssClass="align-right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrdersbooked" runat="server" Text='<%# Eval("OrderCount") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Value of Orders" HeaderStyle-CssClass="align-right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblValueofOrders" runat="server" Text='<%# Eval("TotalBookedValue", "{0:$#,##0}") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>
                            <div class="col-8">
                                <div id="YTDQuotesandOrdersComboChart_div" class="h-100 w-100"></div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <asp:HiddenField ID="hfModalScroll" runat="server" />
            <asp:HiddenField ID="HfCheckOpenParts" runat="server" Value="-1" />
            <asp:HiddenField ID="HfReminderCheck" runat="server" Value="-1" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel_PendingFollowupList" />
            <asp:PostBackTrigger ControlID="btnExportToExcel_NotFollowedupList" />
            <asp:PostBackTrigger ControlID="btnExportToExcel_ShipDateHistory" />
            <asp:PostBackTrigger ControlID="btnExportToExcel_TrackJobStatus" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upAccordion" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function bindScrollTracker() {
            var modalBody = $('#myModal .modal-body');
            modalBody.off('scroll'); // Unbind previous if any
            modalBody.on('scroll', function () {
                document.getElementById('<%= hfModalScroll.ClientID %>').value = $(this).scrollTop();
            });
        }

        // Bind after modal is fully shown
        $('#myModal').on('shown.bs.modal', function () {
            bindScrollTracker();
        });

        // Also bind after UpdatePanel refresh
        if (typeof (Sys) !== "undefined") {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                bindScrollTracker();
            });
        }

        function ShowPoup() {
            //jQuery.noConflict();
            $('#myModal').modal('show');
        }

        function ShowPoupNew() {
            //jQuery.noConflict();
            $('#myModal2').modal('show');
        }

        function ShowPoupShipDates() {
            //jQuery.noConflict();
            $('#myModal3').modal('show');
        }

        function ShowContainerJobs() {
            //jQuery.noConflict();
            $('#containerJobsModal').modal('show');
        }

        //Common Chart Load
        function loadChartData(options) {
            $.ajax({
                type: "POST",
                url: options.url,
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    const result = response.d;
                    const chartDataArray = [options.headers];
                    if (!Array.isArray(result)) {
                        console.warn("Unexpected data format from server:", result);
                        return;
                    }
                    result.forEach(function (item) {
                        const rows = options.rowBuilder(item);
                        if (Array.isArray(rows[0])) {
                            rows.forEach(r => chartDataArray.push(r));
                        } else {
                            chartDataArray.push(rows);
                        }
                    });
                    drawGenericChart(chartDataArray, options.chartOptions, options.containerId, options.chartType, options.formatterCallback);
                },
                error: function (xhr, status, error) {
                    console.error("Error loading chart:", error);
                }
            });
        }

        function drawGenericChart(chartDataArray, chartOptions, containerId, chartType, formatterCallback) {
            chartType = chartType || 'ColumnChart';
            const data = google.visualization.arrayToDataTable(chartDataArray);

            if (chartOptions.formatter) {
                const formatter = new google.visualization.NumberFormat(chartOptions.formatter);
                formatter.format(data, 1); // Format second column
            }

            //For Multi Bars Number format
            if (typeof formatterCallback === 'function') {
                formatterCallback(data);
            }

            let chart;
            switch (chartType) {
                case 'BarChart':
                    chart = new google.visualization.BarChart(document.getElementById(containerId));
                    break;
                case 'PieChart':
                    chart = new google.visualization.PieChart(document.getElementById(containerId));
                    break;
                case 'LineChart':
                    chart = new google.visualization.LineChart(document.getElementById(containerId));
                    break;
                default:
                    chart = new google.visualization.ColumnChart(document.getElementById(containerId));
            }

            chart.draw(data, chartOptions.options);
        }

        const projectedVsSalesObj = [
                {
                    url: "../Default.aspx/GetProjectsSalesVsActualSales",
                    headers: ["Month", "Projected Sales", "Actual Sales"],
                    containerId: "ProjectsVsActualChart",
                    chartType: "ComboChart",
                    rowBuilder: function (item) {
                        return [item.Month, parseFloat(item.ProjectedSales), parseInt(item.ActualSales)];
                    },
                    chartOptions: {
                        options: {
                            chartArea: {
                                left: 100,
                                right: 5,
                            },
                            title: 'Sales ' + new Date().getFullYear(),
                            hAxis: {
                                textStyle: { fontSize: 10, bold: true },
                                slantedText: false,
                                slantedTextAngle: 90
                            },
                            vAxes: {
                                0: { title: 'Amount ($)', textStyle: { fontSize: 12, bold: true } }
                            },
                            seriesType: 'bars',
                            //width: 850,
                            //height: 500,
                            series: {
                                0: { color: '#0856a1' }, // Targeted Sales (bar)
                                1: { color: '#f86d3b' }  // Actual Sales (bar)
                            },
                            legend: {
                                position: "top",
                                textStyle: { fontSize: 10, bold: true },
                                alignment: "start"
                            },
                            titleTextStyle: { fontSize: 12, bold: true },
                            colors: ['#0856a1', '#f86d3b'] // Bar colors for Targeted and Actual totals
                        }
                    },
                    formatterCallback: function (dataTable) {
                        const formatter = new google.visualization.NumberFormat({
                            prefix: '$',
                            fractionDigits: 0
                        });

                        const formatter1 = new google.visualization.NumberFormat({
                            prefix: '$',
                            fractionDigits: 0
                        });

                        formatter.format(dataTable, 1);
                        formatter1.format(dataTable, 2);
                    }
                }
        ];

        function projectedVsSales() {
            //console.log("projectedvsSales");
            var config = projectedVsSalesObj[0];
            if (config && config.containerId) {
                var container = document.getElementById(config.containerId);

                if (container) {
                    var style = window.getComputedStyle(container);
                    var isVisible = style.display !== 'none' && style.visibility !== 'hidden' && style.opacity !== '0';

                    if (isVisible) {
                        loadChartData(config);
                    } else {
                        console.warn("Container is hidden:", config.containerId);
                    }
                }
            }
        }        

        google.charts.load('current', { packages: ['corechart', 'bar'] });

        //google.charts.setOnLoadCallback(drawAllCharts);        

        google.charts.setOnLoadCallback(function () {           
            setTimeout(() => {
                projectedVsSales();
                YTDQuotesandOrders();
            }, 1000);
        });                

        const chartConfigsOrdersandQuotes = [
            {
                url: "../Default.aspx/GetYTDQuotesandOrdersMonthlyTotal",
                headers: ["Month", "Total Quotes Sent", "Value of Quotes Sent", "Orders Booked", "Value of Orders"],
                containerId: "YTDQuotesandOrdersComboChart_div",
                chartType: "ComboChart",
                rowBuilder: function (item) {
                    return [item.MonthName, parseInt(item.MonthlyQuoteCount), parseFloat(item.TotalQuoteValue),
                        parseInt(item.OrderCount), parseInt(item.TotalBookedValue)];
                },
                chartOptions: {
                    options: {
                        chartArea: {
                            left: 100,
                            right: 80,
                            bottom: 80,
                            width: '100%' // Increase to use full container width
                        },
                        hAxis: {
                            slantedText: false,
                            textStyle: { fontSize: 10, bold: true },
                        },
                        title: 'Quotes vs Orders ' + new Date().getFullYear(),
                        vAxes: {
                            0: { title: "Total Amount ($)", textStyle: { fontSize: 12, bold: true }, },
                            1: { title: "Count Quotes and Orders", textStyle: { fontSize: 12, bold: true }, },
                        },
                        seriesType: 'bars',
                        series: {
                            0: { type: 'line', color: '#3366CC', targetAxisIndex: 1 },
                            2: { type: 'line', color: '#FF0000', targetAxisIndex: 1 },
                            1: { color: '#0856a1' },
                            4: { color: '#f86d3b' }

                        },
                        legend: {
                            position: "top",
                            textStyle: { fontSize: 10, bold: true },
                            alignment: "start"
                        },
                        titleTextStyle: { fontSize: 12, bold: true },
                        colors: ['#0856a1', '#f86d3b'] // Bar colors for Targeted and Actual totals
                    }
                },
                formatterCallback: function (dataTable) {
                    const formatter = new google.visualization.NumberFormat({
                        prefix: '$',
                        fractionDigits: 0
                    });

                    const formatter1 = new google.visualization.NumberFormat({
                        prefix: '$',
                        fractionDigits: 0
                    });

                    formatter.format(dataTable, 2);
                    formatter1.format(dataTable, 4);
                }
            }

        ];

        function YTDQuotesandOrders() {
            var config = chartConfigsOrdersandQuotes[0];
            if (config && config.containerId) {
                var container = document.getElementById(config.containerId);

                if (container) {
                    var style = window.getComputedStyle(container);
                    var isVisible = style.display !== 'none' && style.visibility !== 'hidden' && style.opacity !== '0';

                    if (isVisible) {
                        console.log(config);
                        loadChartData(config);
                    } else {
                        console.warn("Container is hidden:", config.containerId);
                    }
                }
            }
        }

        Sys.Application.add_load(function () {
            projectedVsSales();
            YTDQuotesandOrders();
        });

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
            $('#<%=ddlReps.ClientID%>').chosen();
        }
    </script>

    <CR:CrystalReportViewer ID="rptRequisition" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
