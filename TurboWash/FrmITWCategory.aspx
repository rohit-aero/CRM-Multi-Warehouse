<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmITWCategory.aspx.cs" Inherits="TurboWash_FrmITWCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()">
                                <i class="fas fa-chevron-left fa-sm"></i>
                                Back
                            </button>
                            <h4 class="title-hyphen position-relative">TurboWash Category Maintenance</h4>
                        </div>
                    </div>
                </div>
                <div class="row col-5 pl-0 pb-2">
                    <div class="col-7">
                        <label>Category</label>
                        <asp:DropDownList ID="ddlCategoryLookupList" runat="server" DataTextField="text" DataValueField="id" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoryLookupList_SelectedIndexChanged"
                            CssClass="form-control form-control-sm">
                        </asp:DropDownList>
                    </div>

                    <div class="col-5 row">
                        <label class="col-12">&nbsp;</label>
                        <div class="col-12">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-success btn-sm" CausesValidation="false" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-danger btn-sm" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-3">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">TurboWash Category Information</h5>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Category*</label>
                            <asp:TextBox ID="txtCategory" runat="server" MaxLength="50" AutoComplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-auto">
                        <div class="col-12">
                            <label>Options Applicable</label>
                        </div>
                        <div class="col-sm-auto d-flex align-items-center">
                            <div class="d-flex">
                                <div class="form-check pr-4">
                                    <asp:CheckBox CssClass="form-check-input" ID="chkOptionsApplicable" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-auto">
                        <div class="col-12">
                            <label>Active</label>
                        </div>
                        <div class="col-sm-auto d-flex align-items-center">
                            <div class="d-flex">
                                <div class="form-check pr-4">
                                    <asp:CheckBox CssClass="form-check-input" ID="chkActive" runat="server" />                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
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
            $('#<%=ddlCategoryLookupList.ClientID%>').chosen();
        }
    </script>
</asp:Content>

