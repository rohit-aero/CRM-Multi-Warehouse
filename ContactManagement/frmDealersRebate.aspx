<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmDealersRebate.aspx.cs" Inherits="ContactManagement_frmDealersRebate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Dealer Rebate Information</h4>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-5 col-xl-5">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Dealers</label>
                            </div>
                            <div class="col-sm-6 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookupDealers" runat="server" DataTextField="Dealer" DataValueField="DealerID" AutoPostBack="True" OnSelectedIndexChanged="ddlLookupDealers_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm col-md col-lg col-xl-auto">
                            <div class="row">
                                <div class="col-auto">
                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Enabled="false" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Add Dealer Rebate</h5>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Sales From*</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtSalesFrom" runat="server" MaxLength="18" autocomplete="off" onblur="limitToTwoDecimalPlaces(this)"
                                onkeypress="return onlyDotsAndNumbers(this,event);">      
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Sales To*</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtSalesTo" runat="server" MaxLength="18" autocomplete="off" onblur="limitToTwoDecimalPlaces(this)"
                                onkeypress="return onlyDotsAndNumbers(this,event);">    
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Percent*</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtPercent" runat="server" onblur="limitToTwoDecimalPlaces(this)" autocomplete="off" MaxLength="8"
                                onkeypress="return onlyDotsAndNumbers(this,event);">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Effective Date*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtEffectiveDate" runat="server" autocomplete="off" OnBlur="validateDate(this)">                                       
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CaltxtEffDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtEffectiveDate" TargetControlID="txtEffectiveDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">Calculated*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCalculated" runat="server" MaxLength="10" autocomplete="off">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="Y">Yearly</asp:ListItem>
                                <asp:ListItem Value="Q">Quarterly</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvManageDealerRebate" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                        EnableModelValidation="True" ForeColor="Black" GridLines="Vertical"
                        CssClass="table mainGridTable table-sm" DataKeyNames="DealerRebateID" OnRowEditing="gvManageDealerRebate_RowEditing" OnRowDeleting="gvManageDealerRebate_RowDeleting">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="SalesFrom" HeaderText="Sales From" HeaderStyle-CssClass="align-right">
                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SalesTo" HeaderText="Sales To" HeaderStyle-CssClass="align-right">
                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Percent" HeaderText="Percent" HeaderStyle-CssClass="align-right">
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EffectiveDate" HeaderText="Effective Date" HeaderStyle-CssClass="align-center">
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Calculated" HeaderText="Calculated">
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-CssClass="ws-nowrap" FooterStyle-HorizontalAlign="Center" HeaderText="Modify" HeaderStyle-CssClass="align-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="btn btn-primary btn-sm" Text="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="Delete" runat="server" OnClientClick="return confirm('Are you sure to delete. ?');" CommandName="Delete">
                                        <i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="HfDealerDebateID" runat="server" Value="-1" />
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
            $('#<%=ddlLookupDealers.ClientID%>').chosen();
            $('#<%=ddlCalculated.ClientID%>').chosen();
        }

    </script>
</asp:Content>

