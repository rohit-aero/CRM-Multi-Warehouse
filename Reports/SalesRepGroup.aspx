<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SalesRepGroup.aspx.cs" Inherits="Reports_SalesRepGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <h4 class="title-hyphen position-relative mb-3">Hobart US Sales</h4>
            </div>
            <%--            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>--%>
            <div class="col-12 row">
                <div class="row col-7">
                    <div class="col-sm-auto">
                        <div class="form-group mb-0">
                            <label>Ship to Arrive Date from</label>
                            <asp:TextBox ID="txtFromDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>

                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group mb-0">
                            <label>Ship to Arrive Date to</label>
                            <asp:TextBox ID="txtToDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtToDate"></asp:CalendarExtender>

                        </div>
                    </div>

                    <div class="col-sm-auto">
                        <div class="form-group chosenFullWidth">
                            <label>Product Line</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLineList" runat="server" DataTextField="Name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlProductLineList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-auto">
                        <div class="form-group chosenFullWidth">
                            <label>Rep Group</label>
                            <asp:DropDownList ID="ddlSalesRepGroup" CssClass="form-control form-control-sm" runat="server" DataTextField="Name" DataValueField="ID" onchange="GetData(this.value);">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-auto">
                        <div class="form-group chosenFullWidth">
                            <label>Destination Rep</label>
                            <asp:DropDownList ID="ddlRep" CssClass="form-control form-control-sm" runat="server" DataTextField="RepName" DataValueField="RepID" Enabled="false">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-auto">
                        <div class="form-group mb-0 flex-column">
                            <label>&nbsp;</label>
                            <div>
                                <asp:Button ID="btnGenerate" CssClass="btn btn-success btn-sm" runat="server" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview Report" OnClick="btnGenerate_Click" />
                                <asp:Button ID="btnGenExcel" CssClass="btn btn-info btn-sm" runat="server" CausesValidation="false" Text="Export to Excel" OnClick="btnGenExcel_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-5 pl-0">
                    <div class="row">
                        <div class="col-12 pt-2">
                            <div class="d-flex align-items-center mb-2">
                                <h5>
                                    <strong>Help Section</strong>
                                </h5>
                            </div>
                        </div>

                        <div class="col-12">
                            <ul>
                                <li>Date is based on <strong>Invoice Date</strong>.</li>
                                <li>Projects with <strong>Active & Confirmed </strong>status are shown in reports.</li>
                                <li>Projects with <strong>NetEqPrice</strong> <i>greater then</i> <strong>zero </strong>are shown in the report.</li>
                                <li>Projects with selected <strong>Rep Groups</strong> are shown in the report.</li>
                                <li><strong>Product Line </strong>dropdown is there to load Rep Groups and doesnot filter data directly</li>
                                <li>Projects with Rep <strong>Tom Letizia</strong> are <strong>not</strong> shown in the report.</li>
                                <li><strong>USD</strong> currency projects shown in the report.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSalesRepGroup" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
    <script type="text/javascript">
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
            $('#<%=ddlSalesRepGroup.ClientID%>').chosen();
            $('#<%=ddlProductLineList.ClientID%>').chosen();
            //$('#<%=ddlRep.ClientID%>').chosen();
        }

        function GetData(id) {
            if (id == 10) {
                $('#<%=ddlRep.ClientID%>').prop('disabled', false);
            }
            else {
                $('#<%=ddlRep.ClientID%>').prop('disabled', true);
                $('#<%=ddlRep.ClientID%>').value = "-1";
            }
        }
    </script>
</asp:Content>
