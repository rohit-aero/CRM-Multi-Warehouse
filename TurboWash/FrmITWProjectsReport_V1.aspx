<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmITWProjectsReport_V1.aspx.cs" Inherits="TurboWash_FrmITWProjectsReport_V1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content_ITWProjectsReport" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_ITWProjectsReport" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">ITW Projects Report</h4>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>PO Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPOType" runat="server" DataTextField="text" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>                  

                    <div class="col-2">
                        <div class="form-group">
                            <label id="lblFrom" runat="server">PO Received Date From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPODateFrom" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtPODateFrom_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtPODateFrom" TargetControlID="txtPODateFrom"></asp:CalendarExtender>

                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label id="lblTo" runat="server">PO Received Date To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPODateTo" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtPODateTo_Extender" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtPODateTo" TargetControlID="txtPODateTo"></asp:CalendarExtender>
                        </div>
                    </div>                    

                    <div class="col-sm-3 pl-0">
                        <div class="form-group">
                            <label>&nbsp;</label>
                            <div class="col-auto">
                                <asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClick="btnReport_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Report" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
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
            DDL();
        }

        $.when.apply($, PageLoaded).then(function () {
            DDL();
        });

        function DDL() {
            $('#<%=ddlPOType.ClientID%>').chosen();            
        }
    </script>
</asp:Content>
