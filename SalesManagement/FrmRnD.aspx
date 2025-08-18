<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmRnD.aspx.cs" Inherits="SalesManagement_FrmRnD" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col pt-2 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Research Project Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl-9">
                        <div class="row">
                            <div class="col-sm-3 col-md-2">
                                <label class="mb-0">Project Name</label>
                            </div>
                            <div class="col-sm-9 col-md-10">
                                <asp:DropDownList ID="ddlPName" runat="server" DataTextField="ProjectName" DataValueField="id" CssClass="w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlPName_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3 col-md-2 mt-3">
                                <label class="mb-0">Project Number</label>
                            </div>
                            <div class="col-sm-9 col-md-10 mt-3">
                                <asp:DropDownList ID="ddlPNumber" runat="server" DataTextField="ProjectName" DataValueField="id" CssClass="w-100" AutoCompleteMode="SuggestAppend" AutoPostBack="True" OnSelectedIndexChanged="ddlPNumber_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl">
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-sm btn-block" Text="Add Project" OnClick="btnAdd_Click" />
                            </div>
                            <div class="col-sm-6">
                                <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-secondary btn-sm btn-block" Text="Search" Enabled="True" OnClick="btnSearchProposal_Click" />
                            </div>
                            <div class="col-sm-6 mt-3">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm btn-block" Text="Save" OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click" />
                            </div>
                            <div class="col-sm-6 mt-3">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm btn-block" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row pb-3">
                    <div class="col">
                        <h4 class="title-hyphen position-relative">Project Details</h4>
                        <div class="col-sm-12">
                            <asp:Label runat="server" Text="" ID="lblPShow"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-12">
                <div class="row">
                    <div class="col-12">
                        <h5 class="text-uppercase">Basic Info</h5>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Project Number</label>
                            <asp:TextBox ID="txtProjectNumber" runat="server" CssClass="form-control form-control-sm" MaxLength="50" Enabled="false" autocomplete="off"></asp:TextBox>
                            <%--<asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="TextBox2" TargetControlID="TextBox2"></asp:CalendarExtender>--%>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Project Name</label>
                            <asp:TextBox ID="txtProjectName" runat="server" CssClass="form-control form-control-sm" MaxLength="50" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Project Date</label>
                            <asp:TextBox ID="txtProDate" runat="server" CssClass="form-control form-control-sm" MaxLength="50" Enabled="false" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>ShipToArriveDate</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtShipToArrive" AutoComplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender23" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtShipToArrive" TargetControlID="txtShipToArrive"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Fabrication Date Issue</label>
                            <asp:TextBox ID="txtFabDate" runat="server" autocomplete="off" CssClass="form-control form-control-sm"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFabDate" TargetControlID="txtFabDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Nesting Date Issue</label>
                            <asp:TextBox ID="txtNesDate" runat="server" CssClass="form-control form-control-sm" MaxLength="50" autocomplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtNesDate" TargetControlID="txtNesDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Project Eng.</label>
                            <asp:DropDownList ID="ddlProjectEng" runat="server" DataTextField="Name" DataValueField="EmployeeID" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Reviewed By</label>
                            <asp:DropDownList ID="ddlReviewed" runat="server" DataTextField="Name" DataValueField="EmployeeID" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Other Info</h5>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Model</label>
                            <asp:DropDownList ID="ddlModel" runat="server" DataTextField="ModelName" DataValueField="ModelID" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Conveyor Type</label>
                            <asp:DropDownList ID="ddlConType" runat="server" DataTextField="ConveyorType" DataValueField="ConveyorTypeID" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Currency</label>
                            <asp:DropDownList ID="ddlCurrency" runat="server" DataTextField="Currency" DataValueField="CurrencyID" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Equipment Price($)</label>
                            <asp:TextBox ID="txtEqPrice" runat="server" Style="text-align: right" MaxLength="15" autocomplete="off" onchange="getCalc();getPer()" CssClass="form-control form-control-sm" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>

                </div>


            </div>
            <div class="row mx-0 pt-2">
                <div class="col-12">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </div>
            <asp:HiddenField ID="HfJObID" runat="server" Value="-1" />
        </ContentTemplate>
    </asp:UpdatePanel>
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
            $('#<%=ddlPName.ClientID%>').chosen();
           $('#<%=ddlPNumber.ClientID%>').chosen();
           $('#<%=ddlProjectEng.ClientID%>').chosen();
           $('#<%=ddlReviewed.ClientID%>').chosen();
           $('#<%=ddlModel.ClientID%>').chosen();
           $('#<%=ddlConType.ClientID%>').chosen();
           $('#<%=ddlCurrency.ClientID%>').chosen();

       }
    </script>
</asp:Content>
