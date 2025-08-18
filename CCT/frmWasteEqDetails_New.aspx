<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="frmWasteEqDetails_New.aspx.cs" Inherits="CCT_frmWasteEqDetails_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pb-3 pt-2 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Waste Equipment Details</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl-9">
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="row">
                                    <label class="mb-0 col-12">Tracking#</label>
                                    <div class="col-12">
                                        <asp:DropDownList ID="ddlTrackingNumberLookupList" runat="server" DataValueField="TrackingNo" CssClass="w-100" DataTextField="TrackingNo" AutoPostBack="True" OnSelectedIndexChanged="ddlTrackingNumberLookupList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm chosenFullWidth">
                                <div class="row">
                                    <label class="mb-0 col-12">Project Name</label>
                                    <div class="col-12">
                                        <asp:DropDownList ID="ddlProjectLookupList" runat="server" DataValueField="JobID" CssClass="w-100" DataTextField="ProjectName" AutoPostBack="True" OnSelectedIndexChanged="ddlProjectLookupList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl">
                        <div class="row">
                            <div class="col-12">
                                <label class="mb-0">&nbsp;</label>
                            </div>
                            <div class="col-auto">
                                <asp:Button ID="btnSave" CssClass="btn btn-success btn-sm" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-secondary btn-sm" Enabled="true" OnClick="btnFilterForm_Click" Text="Filter Data" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                                <%--<asp:Button ID="btnPreviewReport" runat="server" CssClass="btn btn-secondary btn-sm" Text="Preview Report" OnClick="btnPreviewReport_Click" />--%>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Manufacturer*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlManufacturer" runat="server" DataValueField="ManufacturerId" DataTextField="ManufacturerName" AutoPostBack="True" OnSelectedIndexChanged="ddlManufacturer_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Waste equipment*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlWasteEq" runat="server" DataValueField="WasteEqId" DataTextField="WasteEqName" AutoPostBack="True" OnSelectedIndexChanged="ddlWasteEq_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Accessory*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAccessory" runat="server" DataTextField="AccName" DataValueField="AccId">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Used From Stock*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlUsedFromStock" runat="server">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>JobID</label>
                            <asp:DropDownList ID="ddlJobID" runat="server" DataValueField="JobID" CssClass="w-100" DataTextField="JobID"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Tracking#*</label>
                            <asp:TextBox ID="txtTrackingNo" runat="server" MaxLength="50" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Service Provider</label>
                            <asp:TextBox ID="txtServiceProvider" runat="server" MaxLength="50" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Est. Delivery Date</label>
                            <asp:TextBox ID="txtEstDeliveryDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtEstDeliveryDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtEstDeliveryDate" TargetControlID="txtEstDeliveryDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Req. By Shop on</label>
                            <asp:TextBox ID="txtReqByShopDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReqByShopDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReqByShopDate" TargetControlID="txtReqByShopDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Received Date</label>
                            <asp:TextBox ID="txtReceivedDate" CssClass="form-control form-control-sm" runat="server" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReceivedDate_Extender" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtReceivedDate" TargetControlID="txtReceivedDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-4 col-lg-4">
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 500)" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm mb-0" ShowFooter="false" ID="gvWasteEqDetails" DataKeyNames="id" runat="server"
                                AutoGenerateColumns="false" EnableModelValidation="True" OnRowEditing="gvWasteEqDetails_RowEditing" OnRowDeleting="gvWasteEqDetails_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Tracking #">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTrackingNo" runat="server" Text='<%# Eval("TrackingNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="JobID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJobID" runat="server" Text='<%# Eval("JobID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Manufacturer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblManufacturer" runat="server" Text='<%# Eval("MakerName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Waste equipment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWasteEqName" runat="server" Text='<%# Eval("WasteEqName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Accessory">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccessoryName" runat="server" Text='<%# Eval("AccName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Used From Stock">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsedFromStock" runat="server" Text='<%# Eval("UsedFromStock") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="300px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Est. Delivery Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEstDeliveryDate" runat="server" Text='<%# Eval("EstDeliveryDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Required By Shop On">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequiredByShop" runat="server" Text='<%# Eval("RequiredByShop") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Received Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceivedDate" runat="server" Text='<%# Eval("ReceivedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" Width="300px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm" ID="lnkEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" title="Delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure.?');">
                                                <i class="far fa-times-circle"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HiddenID" runat="server" Value="0" />
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
            $('#<%=ddlTrackingNumberLookupList.ClientID%>').chosen();
            $('#<%=ddlProjectLookupList.ClientID%>').chosen();
            $('#<%=ddlManufacturer.ClientID%>').chosen();
            $('#<%=ddlWasteEq.ClientID%>').chosen();
            $('#<%=ddlAccessory.ClientID%>').chosen();
            $('#<%=ddlUsedFromStock.ClientID%>').chosen();
            $('#<%=ddlJobID.ClientID%>').chosen();
        }

    </script>
</asp:Content>
