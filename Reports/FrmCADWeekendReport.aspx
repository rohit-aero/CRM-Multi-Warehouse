<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FrmCADWeekendReport.aspx.cs" Inherits="Reports_FrmCADWeekendReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_FrmCadWeekendReport" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">CAD Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">
                        <div class="form-group">
                            <label>Select Past Days</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddlDays">
                                <asp:ListItem Value="-1" Selected>1</asp:ListItem>
                                <asp:ListItem Value="-2">2</asp:ListItem>
                                <asp:ListItem Value="-3">3</asp:ListItem>
                                <asp:ListItem Value="-4">4</asp:ListItem>
                                <asp:ListItem Value="-5">5</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label class="col-12">&nbsp;</label>
                            <asp:Button ID="btnExportToPDF" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" Text="Preview Report" OnClientClick="window.document.forms[0].target='_blank';" OnClick="btnExportToPDF_Click" />
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <%-- </div>--%>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToPDF" />
        </Triggers>
    </asp:UpdatePanel>
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
            $('#<%=ddlDays.ClientID%>').chosen();
        }
    </script>
</asp:Content>
