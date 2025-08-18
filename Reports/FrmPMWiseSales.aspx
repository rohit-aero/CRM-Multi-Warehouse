<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmPMWiseSales.aspx.cs" Inherits="Reports_FrmPMWiseSales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content_SalesActivity" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_SalesActivity" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">PM Wise Sales Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="row">
                            <div class="col-2">
                                <div class="form-group">
                                    <label>Year</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlYears" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-2">
                                <div class="form-group">
                                    <label>Project Manager</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectManager" runat="server" DataTextField="text" DataValueField="id">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-5">
                                <label>&nbsp;</label>
                                <div class="form-group">
                                    <asp:Button ID="btnReport" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';"
                                        Text="Generate Report" OnClick="btnReport_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
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
            $('#<%=ddlYears.ClientID%>').chosen();
            $('#<%=ddlProjectManager.ClientID%>').chosen();
        }
    </script>
</asp:Content>
