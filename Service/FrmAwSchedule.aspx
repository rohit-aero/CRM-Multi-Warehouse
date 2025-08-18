<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmAwSchedule.aspx.cs" Inherits="Service_FrmAwSchedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <h4 class="title-hyphen position-relative">Aerowerk Schedule</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-md-9 col-lg-2">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">JobId</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddljobid" DataTextField="JobID" DataValueField="JobID" OnSelectedIndexChanged="ddljobid_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-9 col-lg-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Job Name</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddljobname" DataTextField="JobName" DataValueField="JobID" OnSelectedIndexChanged="ddljobname_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" OnClick="btnSave_Click" Text="Save" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row border-top pt-3">
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Required Ship Date</label>
                            <asp:TextBox ID="txtRequiredshipdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtRequiredshipdate" TargetControlID="txtRequiredshipdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" DataTextField="Name" DataValueField="id" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="row border-top pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Department Status</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Nesting</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNesting" DataTextField="Name" DataValueField="id" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Laser</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLaser" DataTextField="Name" DataValueField="id" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Forming</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlForming" DataTextField="Name" DataValueField="id" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Welding</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlWelding" DataTextField="Name" DataValueField="id" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Polishing</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPolishing" DataTextField="Name" DataValueField="id" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Shipping</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlShipping" DataTextField="Name" DataValueField="id" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row  pt-3">
                    <div class="col-12">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h5 class="text-uppercase">Details</h5>
                    </div>
                    <div class="col-12">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table mainGridTable table-sm" ID="gvMember" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="id" AllowPaging="True"
                                EmptyDataText="No Details has been added." OnRowDeleting="gvMember_RowDeleting" EnableModelValidation="True"
                                OnPageIndexChanging="gvMember_PageIndexChanging" OnRowEditing="gvMember_RowEditing" OnRowUpdating="gvMember_RowUpdating"
                                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                ForeColor="Black" OnRowCancelingEdit="gvMember_RowCancelingEdit">
                                <Columns>

                                    <asp:TemplateField HeaderText="Pack No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPackNo" runat="server" Text='<%# Eval("PackNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPackNo" MaxLength="20" runat="server" autocomplete="off" Text='<%# Eval("PackNo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part#">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPart" runat="server" Text='<%# Eval("PartNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPartNo" MaxLength="20" runat="server" autocomplete="off" Text='<%# Eval("PartNumber") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part Description">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPartDescription" MaxLength="25" autocomplete="off" runat="server" Text='<%# Eval("PartDescription") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPartDescription" runat="server" Text='<%# Eval("PartDescription") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rlease Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRleaseDate" MaxLength="10" runat="server" Text='<%# Eval("ReleaseDate") %>'></asp:Label>
                                               <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtRleaseDate" TargetControlID="txtRleaseDate">
                                        </asp:CalendarExtender>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRleaseDate" runat="server" MaxLength="12" autocomplete="off" Text='<%# Eval("ReleaseDate") %>' Width="140"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="140px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Modify">
                                        <EditItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="btnEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Details ?');" CommandName="Delete"><i class="far fa-times-circle" title="Delete"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="142px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                        <div class="table-responsive">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>

                                    <th>Pack No</th>
                                    <th>Part#</th>
                                    <th>Part Description</th>
                                    <th>Rlease Date</th>
                                    <th></th>
                                </tr>
                                <tr>

                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtPackNo" MaxLength="30" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtPartNo" MaxLength="30" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtPartDescription" MaxLength="25" autocomplete="off" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtRleaseDate" MaxLength="12" autocomplete="off" runat="server" />
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                            PopupButtonID="txtRleaseDate" TargetControlID="txtRleaseDate">
                                        </asp:CalendarExtender>
                                    </td>

                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAddMember" runat="server" Text="Add " OnClick="btnaddSchedule_click" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            </div>
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
                        $('#<%=ddljobid.ClientID%>').chosen();
                        $('#<%=ddljobname.ClientID%>').chosen();
                        $('#<%=ddlNesting.ClientID%>').chosen();
                        $('#<%=ddlLaser.ClientID%>').chosen();
                        $('#<%=ddlForming.ClientID%>').chosen();
                        $('#<%=ddlWelding.ClientID%>').chosen();
                        $('#<%=ddlPolishing.ClientID%>').chosen();
                        $('#<%=ddlShipping.ClientID%>').chosen();
                        $('#<%=ddlStatus.ClientID%>').chosen();



                    }
                </script>

            <asp:HiddenField ID="hfpartid" runat="server" />
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
