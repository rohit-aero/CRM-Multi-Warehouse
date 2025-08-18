<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmAwScheduleNew.aspx.cs" Inherits="FrmAwScheduleNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col pt-2 pb-3 border-bottom piDiv position-sticky">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Aerowerks Service Shipment Schedule Details</h4>
                        </div>
                    </div>
                </div>
                <div class="row pb-3">
                    <div class="col-sm-7 col-md-8 col-lg-8 col-xl">
                        <div class="row">
                            <div class="col-8">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Job #</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList ID="ddlJobNo" runat="server" DataTextField="ProjectName" DataValueField="JobID" CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="mb-0">Pack No.</label>
                                    </div>
                                    <div class="col-sm chosenFullWidth">
                                        <asp:DropDownList ID="ddlPackNo" runat="server" DataTextField="PackNo" DataValueField="Id" CssClass="form-control form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlTicketNo_SelectedIndexChanged"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-sm-12">
                                <label class="mb-0">&nbsp;</label>
                            </div>
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm" Text="Create New Pack" OnClick="btnNew_Click" Enabled="false" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnReports" runat="server" CssClass="btn btn-info btn-sm" Text="Report" OnClick="btnReports_Click" />
                                <asp:Button ID="btnPDF" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm" Visible="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview" OnClick="btnPDF_Click" />
                                <asp:Button ID="btnPreview" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm" Visible="false" Text="Export to Doc" OnClick="btnPreview_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <asp:Panel ID="PanPersonelInformation" runat="server">
                    <div class="row pt-3">
                        <div class="col-12">
                            <h5 class="text-uppercase">Schedule Details</h5>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <label class="text-danger">Pack No.*</label>
                                <asp:TextBox ID="txtTicketno" CssClass="form-control form-control-sm" autocomplete="off" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <label class="text-danger">Release Date*</label>
                                <asp:TextBox ID="txtReleaseDate" CssClass="form-control form-control-sm" AutoComplete="off" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtReleaseDate" TargetControlID="txtReleaseDate">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                         <div class="col-sm-2 m-1">
                            <div class="form-group">  
                                 <label style="display:none"></label>                             
                                <asp:Button ID="btnPartsPreview" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm mt-4" Enabled="false" OnClientClick="window.document.forms[0].target='_blank';" Text="Preview" OnClick="btnPartsPreview_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pangvSummary" runat="server">
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvSummary" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                    EnableModelValidation="True" ShowFooter="True" OnRowCancelingEdit="gvSummary_RowCancelingEdit" OnRowEditing="gvSummary_RowEditing" OnRowUpdating="gvSummary_RowUpdating" OnRowDeleting="gvSummary_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HfTicketid" runat="server" Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part No">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPartNo" runat="server" MaxLength="20" Text='<%# Eval("PartNumber") %>' class="form-control form-control-sm"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterPartNo" MaxLength="20" runat="server" Text='<%# Eval("PartNumber") %>' class="form-control form-control-sm"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartNo" runat="server" Text='<%# Eval("PartNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                            <ItemStyle />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Part Desc.*">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPartDesc" MaxLength="250" runat="server" TextMode="MultiLine" Text='<%# Eval("PartDescription") %>' class="form-control form-control-sm"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterPartDesc" MaxLength="250" TextMode="MultiLine" runat="server" Text='<%# Eval("PartDescription") %>' class="form-control form-control-sm"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartDesc" runat="server" Text='<%# Eval("PartDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="15%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty.">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPartQty" MaxLength="6" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);" Text='<%# Eval("PartQty") %>' class="form-control form-control-sm"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtPartQtyFooter" MaxLength="6" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);" Text='<%# Eval("PartQty") %>' class="form-control form-control-sm"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartQty" runat="server" Text='<%# Eval("PartQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Required Ship date*">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtReqShipDate" runat="server" Text='<%# Eval("ReqShipDate") %>' class="form-control form-control-sm"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvSummDate" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtReqShipDate" TargetControlID="txtReqShipDate">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtReqShipDateFooter" runat="server" Text='<%# Eval("ReqShipDate") %>' class="form-control form-control-sm"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvSummDate" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtReqShipDateFooter" TargetControlID="txtReqShipDateFooter">
                                                </asp:CalendarExtender>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblReqShipDate" runat="server" Text='<%# Eval("ReqShipDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="7%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part Req On Site">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPartReqOnSite" runat="server" Text='<%# Eval("PartReqOnSite") %>' class="form-control form-control-sm"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvSummDate_1" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtPartReqOnSite" TargetControlID="txtPartReqOnSite">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtPartReqOnSiteFooter" runat="server" Text='<%# Eval("PartReqOnSite") %>' class="form-control form-control-sm"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvSummDate_1" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtPartReqOnSiteFooter" TargetControlID="txtPartReqOnSiteFooter">
                                                </asp:CalendarExtender>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartReqOnSite" runat="server" Text='<%# Eval("PartReqOnSite") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="7%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ship Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtShipDate" runat="server" Text='<%# Eval("ShipDate") %>' class="form-control form-control-sm"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvSummDate_2" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtShipDate" TargetControlID="txtShipDate">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtShipDateFooter" runat="server" Text='<%# Eval("ShipDate") %>' class="form-control form-control-sm"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtendergvSummDate_2" runat="server" Format="MM/dd/yyyy"
                                                    PopupButtonID="txtShipDateFooter" TargetControlID="txtShipDateFooter">
                                                </asp:CalendarExtender>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtShipDate" runat="server" Text='<%# Eval("ShipDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="7%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nesting">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlNesting" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlFooterNesting" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNesting" runat="server" Text='<%# Eval("NestingStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="8%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Laser">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlLaser" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlFooterLaser" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLaser" runat="server" Text='<%# Eval("LaserStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="8%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Forming">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlForming" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlFooterForming" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblForming" runat="server" Text='<%# Eval("FormingStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="8%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Welding">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlWelding" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlFooterWelding" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblWelding" runat="server" Text='<%# Eval("WeldingStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="8%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Polishing">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlPolishing" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlFooterPolishing" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPolishing" runat="server" Text='<%# Eval("PolishingStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="8%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Final">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlFinal" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlFooterFinal" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFinal" runat="server" Text='<%# Eval("FinalStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="8%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Shipping">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlShiping" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlFooterShiping" CssClass="form-control form-control-sm" DataTextField="StatusName" DataValueField="Statusid" runat="server"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipping" runat="server" Text='<%# Eval("ShippingStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="8%" />
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="ws-nowrap" FooterStyle-HorizontalAlign="Center">
                                            <EditItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                                &nbsp;
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                                &nbsp;
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" CommandName="Insert" OnClick="btnAdd_Click" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="lnkEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                                &nbsp;<asp:LinkButton CssClass="btn btn-info btn-danger" ID="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure to delete. ?');"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <asp:HiddenField ID="HfCustomerDetailid" runat="server" />
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
                    $('#<%=ddlJobNo.ClientID%>').chosen();
                    $('#<%=ddlPackNo.ClientID%>').chosen();
                }
            </script>
            <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPreview" />
            <asp:PostBackTrigger ControlID="btnPDF" />
            <asp:PostBackTrigger ControlID="btnPartsPreview" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
