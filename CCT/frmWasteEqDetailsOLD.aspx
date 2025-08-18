<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmWasteEqDetailsOLD.aspx.cs" Inherits="CCT_frmWasteEqDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                    <label class="mb-0 col-12">Job ID</label>
                                    <div class="col-12"><asp:DropDownList ID="ddlJobId" runat="server" DataValueField="JobID" CssClass="w-100" DataTextField="JobID" AutoPostBack="True" OnSelectedIndexChanged="ddlJobId_SelectedIndexChanged"></asp:DropDownList></div>
                                </div>
                            </div>
                            <div class="col-sm chosenFullWidth">
                                <div class="row">
                                    <label class="mb-0 col-12">Project Name</label>
                                    <div class="col-12"><asp:DropDownList ID="ddlproject" runat="server" DataValueField="JobID" CssClass="w-100" DataTextField="projectName" AutoPostBack="True" OnSelectedIndexChanged="ddlproject_SelectedIndexChanged"></asp:DropDownList></div>
                                </div>
                            </div>                           
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl">
                        <div class="row">
                            <div class="col-12"><label class="mb-0">&nbsp;</label></div>
                            <div class="col-auto">
                                <asp:Button ID="btnSave" CssClass="btn btn-success btn-sm" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnPreviewReport" runat="server" CssClass="btn btn-secondary btn-sm" Text="Preview Report" OnClick="btnPreviewReport_Click"  />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <asp:Panel ID="PanDetails" runat="server">
                    <div class="row pt-3">
                        <div class="col-12">
                            <h5 class="text-uppercase">Details</h5>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Released Date</label>
                                <asp:TextBox ID="txtReleasedDate" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtReleasedDate" TargetControlID="txtReleasedDate">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label>Ship Date</label>
                                <asp:TextBox ID="txtShipDate" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                    PopupButtonID="txtShipDate" TargetControlID="txtShipDate">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="gvPanel" runat="server">
                    <div class="row pt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView CssClass="table mainGridTable table-sm mb-0" ShowFooter="true" ID="gvWasteEqDetails" DataKeyNames="id" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowCancelingEdit="gvWasteEqDetails_RowCancelingEdit" OnRowEditing="gvWasteEqDetails_RowEditing" OnRowUpdating="gvWasteEqDetails_RowUpdating">
                                    <Columns>
                                        <%--<asp:TemplateField HeaderText="Manufacturer*">
                                            <EditItemTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlgvmanufacturer" runat="server" DataValueField="makerid" DataTextField="makername" AutoPostBack="True" OnSelectedIndexChanged="ddlgvmanufacturer_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblgvmanufact" runat="server" Visible="false" Text='<%# Bind("makerid") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlftmanufacturer" runat="server" DataValueField="makerid" DataTextField="makername" AutoPostBack="True" OnSelectedIndexChanged="ddlftmanufacturer_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblgvmanufact" runat="server" Visible="false" Text='<%# Bind("makerid") %>'></asp:Label>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvmanufacturer" runat="server" Text='<%# Eval("makername") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Waste equipment*">
                                            <EditItemTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlgvwasteeq" runat="server" DataValueField="wasteeqid" DataTextField="WasteEqName" AutoPostBack="True" OnSelectedIndexChanged="ddlgvwasteeq_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblgvwateequp" runat="server" Visible="false" Text='<%# Bind("eqid") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlftwasteeqmanufacturer" runat="server" DataValueField="wasteeqid" DataTextField="WasteEqName" AutoPostBack="True" OnSelectedIndexChanged="ddlftwasteeqmanufacturer_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvwateeq" runat="server" Text='<%# Eval("WasteEqName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Accessory*">
                                            <EditItemTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlgvacc" runat="server" DataTextField="acc_name" DataValueField="accid">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblgvac" runat="server" Visible="false" Text='<%# Bind("accid") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlftacc" runat="server" DataTextField="acc_name" DataValueField="accid">
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvacc" runat="server" Text='<%# Eval("acc_name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Used From Stock*">
                                            <EditItemTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlgvusedforstock" runat="server">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblgvusedinstock" Visible="false" runat="server" Text='<%# Eval("usedfromstock") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlftusedforstock" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvusedforstock" runat="server" Text='<%# Eval("usedfromstock") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="300px" />
                                        </asp:TemplateField> --%>
                                        <asp:TemplateField HeaderText="Requested On*">
                                            <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditRequestedOn" CssClass="form-control form-control-sm" Text='<%# Eval("requestondate") %>' runat="server"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtEditRequestedOn" TargetControlID="txtEditRequestedOn">
                                                        </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                            <asp:TextBox ID="txtFRequestedOn" CssClass="form-control form-control-sm" Text='<%# Eval("requestondate") %>' runat="server"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy"
                                                            PopupButtonID="txtFRequestedOn" TargetControlID="txtFRequestedOn">
                                                            </asp:CalendarExtender>
                                            </FooterTemplate>
                                         
                                            <ItemTemplate>
                                                <asp:Label ID="lblRequestedOn" runat="server" Text='<%# Eval("requestondate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>     
                                        <asp:TemplateField HeaderText="Tracking #*">
                                        <EditItemTemplate>
                                        <asp:TextBox ID="txtEdittrackingno" CssClass="form-control form-control-sm" Text='<%# Eval("trackingno") %>' runat="server"></asp:TextBox>                                        
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:TextBox ID="txtFTrackingNo" CssClass="form-control form-control-sm" Text='<%# Eval("trackingno") %>' runat="server"></asp:TextBox>                                   
                                        </FooterTemplate>                                            
                                        <ItemTemplate>
                                        <asp:Label ID="lblTrackingNo" runat="server" Text='<%# Eval("trackingno") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>  
                                        <asp:TemplateField HeaderText="Est. Delivery Date*">
                                        <EditItemTemplate>
                                        <asp:TextBox ID="txtEditEstDeliveryDate" CssClass="form-control form-control-sm" Text='<%# Eval("estimatdeliverydate") %>' runat="server"></asp:TextBox>        
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtEditEstDeliveryDate" TargetControlID="txtEditEstDeliveryDate">
                                        </asp:CalendarExtender>                                
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:TextBox ID="txtFEstDeliveryDate" CssClass="form-control form-control-sm" Text='<%# Eval("estimatdeliverydate") %>' runat="server"></asp:TextBox> 
                                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format="MM/dd/yyyy"
                                        PopupButtonID="txtFEstDeliveryDate" TargetControlID="txtFEstDeliveryDate">
                                        </asp:CalendarExtender>                                  
                                        </FooterTemplate>                                            
                                        <ItemTemplate>
                                        <asp:Label ID="lblEstDeliveryDate" runat="server" Text='<%# Eval("estimatdeliverydate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="Required By Shop On">
                                            <EditItemTemplate>
                                               <asp:TextBox ID="txtEditreqonshopon" CssClass="form-control form-control-sm" Text='<%# Eval("reqbyshopon") %>' runat="server"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFreqonshopon" CssClass="form-control form-control-sm" Text='<%# Eval("reqbyshopon") %>' runat="server"></asp:TextBox>
                                            </FooterTemplate>                                     
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvreqonshopon" runat="server" Text='<%# Eval("reqbyshopon") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="200px" />
                                        </asp:TemplateField>   
                                        <asp:TemplateField HeaderText="Received Date*">
                                            <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditreceiveddate" CssClass="form-control form-control-sm" Text='<%# Eval("acc_recieved") %>' runat="server"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="MM/dd/yyyy"
                                                        PopupButtonID="txtEditreceiveddate" TargetControlID="txtEditreceiveddate">
                                                        </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                            <asp:TextBox ID="txtFReceivedDate" CssClass="form-control form-control-sm" Text='<%# Eval("acc_recieved") %>' runat="server"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="MM/dd/yyyy"
                                                            PopupButtonID="txtFReceivedDate" TargetControlID="txtFReceivedDate">
                                                            </asp:CalendarExtender>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblReceiveddate" runat="server" Text='<%# Eval("acc_recieved") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>                                                                         
                                        <asp:TemplateField HeaderText="Remarks">
                                            <EditItemTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlgvremarks" runat="server" Width="100%" DataTextField="remarks" DataValueField="Remarkid">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblgvremark" Visible="false" runat="server" Text='<%# Eval("remarks") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlftgvremarks" runat="server" Width="100%" DataTextField="remarks" DataValueField="Remarkid">
                                                </asp:DropDownList>
                                                <asp:Label ID="lbleditgvremark" Visible="false" runat="server" Text='<%# Eval("remarks") %>'></asp:Label>
                                            </FooterTemplate>                                      
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvremarks" runat="server" Text='<%# Eval("remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="300px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-success btn-sm" ID="lnkUpdate" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                                &nbsp;
                                            <br />
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="Cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnAdd" CssClass="btn btn-info btn-sm rounded" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                            </FooterTemplate>
                                            <FooterStyle HorizontalAlign="Center" Width="150px" />
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm" ID="lnkEdit" runat="server" CommandName="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
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
                    $('#<%=ddlJobId.ClientID%>').chosen();
                    $('#<%=ddlproject.ClientID%>').chosen();                    
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>