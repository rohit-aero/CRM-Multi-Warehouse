<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FrmRegions.aspx.cs" Inherits="Administration_FrmRegions" %>

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
                                <label class="mb-0">Country</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountryHeaderList" runat="server"
                                    DataTextField="Country" DataValueField="CountryID" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCountryHeaderList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Regions</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRegionHeaderList" runat="server"
                                    DataTextField="RegionName" DataValueField="RegionID" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlRegionHeaderList_SelectedIndexChanged">
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
                        <h5 class="text-uppercase">Region Information</h5>
                    </div>
                    <div class="row">
                        <div class="col-sm-auto ">
                            <div class="form-group d-flex flex-row flex-wrap">
                                <div class="col-sm-auto">
                                    <div>
                                        <label>Country *</label>
                                    </div>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-auto">
                                    <label>Region Name *</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" MaxLength="50" AutoComplete="off" ID="txtRegionName" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-auto">
                                    <label>Director</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDirector" MaxLength="20" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-auto">
                                    <label>Director Phone</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDirectorPhone" MaxLength="15" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-auto">
                                    <label>Director Email</label>
                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtDirectorEmail" MaxLength="50" AutoComplete="off" runat="server"></asp:TextBox>
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
            $('#<%=ddlCountryHeaderList.ClientID%>').chosen();
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlRegionHeaderList.ClientID%>').chosen();
        }
    </script>
</asp:Content>