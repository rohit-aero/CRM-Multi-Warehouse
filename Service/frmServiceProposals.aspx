<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true"
    CodeFile="frmServiceProposals.aspx.cs" Inherits="Service_frmServiceProposals" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Service Proposals Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-8">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Service Proposal</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPNumber" runat="server" DataTextField="ProposalNo" DataValueField="ProposalNo" AutoPostBack="True" OnSelectedIndexChanged="ddlPNumber_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnNewPNo" CausesValidation="false" runat="server" Text="New P#" OnClick="btnNewPNo_Click" />
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" CausesValidation="false" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Service Proposal Information</h5>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Service P#*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtServicePNo" autocomplete="off" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Service J#</label>
                            <div class="input-group input-group-sm">
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtServiceJNo" autocomplete="off" Enabled="false" runat="server"></asp:TextBox>
                                <div class="input-group-prepend p-1">
                                    <asp:ImageButton ID="imgSJID" runat="server" Height="20px" ToolTip="Service Job#" ImageUrl="~/images/goto.png" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Width="20px" OnClick="imgSJID_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Product Line*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLine" runat="server" DataTextField="Conveyorname" DataValueField="Conveyorid"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Comments</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPComments" MaxLength="250" autocomplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                        <div class="form-group">
                            <label>Ref. Job ID</label>
                            <div class="input-group input-group-sm">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobID" runat="server" DataTextField="JobName" DataValueField="JobID" AutoPostBack="True" OnSelectedIndexChanged="ddlJobID_SelectedIndexChanged"></asp:DropDownList>
                                <div class="input-group-prepend p-1">
                                    <asp:ImageButton ID="imgJobID" runat="server" Height="20px" ToolTip="Ref Job#" ImageUrl="~/images/goto.png" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" OnClick="imgJobID_Click" Width="20px" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Old Project Value($)</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtNetEqPrice" autocomplete="off" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Service Assigned To</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAssignedto" runat="server" DataTextField="fname" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Technician</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTechnician" runat="server" DataTextField="fname" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Assessment Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAssessmentDate" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtAssessmentDate" TargetControlID="txtAssessmentDate"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Quote Sent Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtQuoteSentDate" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtQuoteSentDate" TargetControlID="txtQuoteSentDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Quote Amount($)</label>
                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtQuoteAmount" autocomplete="off" onkeyup="javascript:this.value=Comma(this.value);" MaxLength="25" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem Value="1">Visit Scheduled</asp:ListItem>
                                <asp:ListItem Value="2">Visit done</asp:ListItem>
                                <asp:ListItem Value="3">Quote Sent</asp:ListItem>
                                <asp:ListItem Value="4">PO received</asp:ListItem>
                                <asp:ListItem Value="5">Repair Done</asp:ListItem>
                                <asp:ListItem Value="6">Invoiced</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Nature of Task*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNature" runat="server">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem Value="1">Repair</asp:ListItem>
                                <asp:ListItem Value="2">Retrofit</asp:ListItem>
                                <asp:ListItem Value="3">Replacement</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="gvPanel" runat="server">
                <div class="col-12">
                    <div class="row pt-3">
                        <div class="col-12">
                            <div>
                                <table border="1" cellpadding="0" cellspacing="0" class="table mainGridTable table-sm">
                                    <tr>
                                        <th style="width: 24%;">Date</th>
                                        <th style="width: 66%;">Remarks</th>
                                        <th style="width: 10%;"></th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDate" CssClass="form-control form-control-sm" runat="server" autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDate" TargetControlID="txtDate"></asp:CalendarExtender>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control form-control-sm" runat="server" TextMode="MultiLine" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ID="gvProposalDetails" runat="server" DataKeyNames="SerProposalDetailid"
                                    AutoGenerateColumns="False" EnableModelValidation="True" OnRowCancelingEdit="gvProposalDetails_RowCancelingEdit"
                                    OnRowEditing="gvProposalDetails_RowEditing" OnRowDeleting="gvProposalDetails_RowDeleting" OnRowUpdating="gvProposalDetails_RowUpdating">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditDate" CssClass="form-control form-control-sm" Text='<%# Eval("DetailsDate") %>' runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtEditDate" TargetControlID="txtEditDate"></asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("DetailsDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="24%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditSummary" CssClass="form-control form-control-sm" Text='<%# Eval("Summary") %>' autocomplete="off" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Summary") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-CssClass="ws-nowrap" FooterStyle-HorizontalAlign="Center">
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
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="10%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
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
            $('#<%=ddlJobID.ClientID%>').chosen();
            $('#<%=ddlAssignedto.ClientID%>').chosen();
            $('#<%=ddlTechnician.ClientID%>').chosen();
            $('#<%=ddlPNumber.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlNature.ClientID%>').chosen();
            $('#<%=ddlProductLine.ClientID%>').chosen();
        }
    </script>
</asp:Content>
