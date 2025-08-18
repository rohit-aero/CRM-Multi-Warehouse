<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmDelayedProjects.aspx.cs" Inherits="Reports_FrmDelayedProjects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Delayed Projects Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-8">
                        <div class="row">
                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label>Ship Date From</label>
                                    <asp:TextBox ID="txtDateFrom" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                    </asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateFrom_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtDateFrom" TargetControlID="txtDateFrom">
                                    </asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label>Ship Date To</label>
                                    <asp:TextBox ID="txtDateTo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                                    </asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateTo_Extender" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtDateTo" TargetControlID="txtDateTo">
                                    </asp:CalendarExtender>
                                </div>
                            </div>

                            <div class="col-sm-4">
                                <label>&nbsp;</label>
                                <div class="form-group">
                                    <asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary btn-sm" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';"
                                        Text="Generate Report" OnClick="btnReport_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-4">
                        <div class="row pt-3">
                            <div class="d-flex align-items-center mb-2">
                                <h4>
                                    <strong>Help Section: </strong>
                                </h4>
                            </div>
                            <div class="col-12 pt-2">
                                <div class="d-flex align-items-center mb-2">
                                    <h5>
                                        <strong>Delayed Projects</strong>
                                    </h5>
                                </div>
                                <div class="col-12">
                                    <ul>
                                        <li>New Ship Date should be <strong>greater then</strong> Old Ship Date.</li>
                                        <li>Date is based on <strong>Ship Date</strong>.</li>
                                        <li>Projects which has both(old and new) Ship Dates are shown in the report.</li>
                                    </ul>
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

        }
    </script>
</asp:Content>
