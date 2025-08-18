<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmShopDwgIssueLogReport.aspx.cs" Inherits="Reports_FrmShopDwgIssueLogReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Shop Drawing Issue Log Report</h4>
                        </div>
                    </div>
                </div>    
                <div class="row">
                    <div class="col-sm-12">
                         <h5 class="text-uppercase">Filters</h5>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Date Identified From</label>
                            <asp:TextBox ID="txtFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtFrom" TargetControlID="txtFrom">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Date Identified To</label>
                            <asp:TextBox ID="txtTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="txtTo_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtTo" TargetControlID="txtTo">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Impact</label>
                            <asp:DropDownList ID="ddlImpact" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Category</label>
                            <asp:DropDownList ID="ddlCategory" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Responsible Person</label>
                            <asp:DropDownList ID="ddlResponsiblePerson" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Issue ID</label>
                            <asp:DropDownList ID="ddlIssues" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="text"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-4">
                        <div class="form-group">
                            <label>Job ID/ Job Name</label>
                            <asp:DropDownList ID="ddlJobs" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="form-group">
                            <label>Issue Description</label>
                            <asp:TextBox ID="txtIssueDescription" CssClass="form-control form-control-sm" autocomplete="off" runat="server" MaxLength="50" AutoPostBack="true" OnTextChanged="txtIssueDescription_TextChanged">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                <div class="col-sm-12">
                    <h5 class="text-uppercase">Group By</h5>
                </div>
                <div class="col-2">
                        <div class="form-group">
                            <label>Group By</label>
                            <asp:DropDownList ID="ddlGroupBy" CssClass="form-control form-control-sm" runat="server">
                                <asp:ListItem Value="">Issue ID</asp:ListItem>
                                <asp:ListItem Value="C">Category</asp:ListItem>
                                <asp:ListItem Value="I">Impact</asp:ListItem>
                                <asp:ListItem Value="R">Responsible Person</asp:ListItem>
                                <asp:ListItem Value="S">Status</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                 </div>
                </div>         
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                           <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-primary btn-sm" Text="Preview" CausesValidation="false" OnClick="btnPreview_Click" OnClientClick="window.document.forms[0].target='_blank';" />
                            <asp:Button ID="btnExportExcel" runat="server" CssClass="btn btn-info btn-sm" Text="Export to Excel" CausesValidation="false" OnClick="btnExportExcel_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPreview" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
        </Triggers>
    </asp:UpdatePanel>
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
            $('#<%=ddlIssues.ClientID%>').chosen();
            $('#<%=ddlJobs.ClientID%>').chosen();
            $('#<%=ddlImpact.ClientID%>').chosen();
            $('#<%=ddlCategory.ClientID%>').chosen();
            $('#<%=ddlResponsiblePerson.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlGroupBy.ClientID%>').chosen();
        }

    </script>
</asp:Content>
