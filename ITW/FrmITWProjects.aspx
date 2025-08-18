<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmITWProjects.aspx.cs" Inherits="ITW_FrmITWProjects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">LookUp</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Department</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDepartmentHeaderList" runat="server"
                                    DataTextField="Name" DataValueField="ID" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDepartmentHeaderList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">PO#</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPOHeaderList" runat="server"
                                    DataTextField="PO" DataValueField="ID" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlPOHeaderList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-auto mx-auto innerMain">
                <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">ITW Project Information</h5>
                    </div>
                    <div class="row">
                        <div class="col-sm-auto ">
                            <div class="form-group d-flex flex-row flex-wrap">
                                <div class="col-sm-auto">
                                    <div>
                                        <label>Department *</label>
                                    </div>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="ID">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-auto">
                                    <label>PO Number *</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" MaxLength="80" AutoComplete="off" ID="txtPONumber" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-auto">
                                    <label>PO Rec Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtPORecDate" AutoComplete="off" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtPORecDate" TargetControlID="txtPORecDate">
                                    </asp:CalendarExtender>
                                </div>
                                <div class="col-sm-auto">
                                    <label>PO Release Date</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtPOReleaseDate" AutoComplete="off" runat="server"></asp:TextBox>
                                     <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtPOReleaseDate" TargetControlID="txtPOReleaseDate">
                                    </asp:CalendarExtender>
                                </div>
                                <div class="col-sm-auto">
                                    <label>VM Order ID</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtVMOrderID" MaxLength="80" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-auto">
                                    <label>PO Cost</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtPOCost" onkeypress="return onlyDotsAndNumbers(this,event);" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-auto">
                                    <label>Comments</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtComments" AutoComplete="off" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox>
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
            $('#<%=ddlDepartment.ClientID%>').chosen();
            $('#<%=ddlPOHeaderList.ClientID%>').chosen();
            $('#<%=ddlDepartmentHeaderList.ClientID%>').chosen();
        }
    </script>
</asp:Content>