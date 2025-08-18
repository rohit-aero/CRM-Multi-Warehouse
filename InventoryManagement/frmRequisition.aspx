<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmRequisition.aspx.cs" Inherits="INVManagement_frmRequisition " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Requisition Maintenance</h4>
                        </div>
                    </div>
                </div>
           
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-6">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Requisition</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPreparedByList" runat="server" DataTextField="FirstName" DataValueField="EmployeeID" AutoPostBack="True" OnSelectedIndexChanged="ddlPreparedByList_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlReq" runat="server" DataTextField="ReqNo" DataValueField="Requisitionid" AutoPostBack="True" OnSelectedIndexChanged="ddlReq_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="Add New Requisition" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Save" OnClientClick="return confirm('Are you sure.?');" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-sm" CausesValidation="false" Text="Approve & Submit" Visible="false" OnClientClick="return confirm('Are you sure to Submit this requisition.?');"  />
                                <asp:Button ID="btnGenerate" runat="server" CausesValidation="false" Enabled="false" CssClass="btn btn-primary btn-sm" OnClientClick="window.document.forms[0].target='_blank';" Text="Generate Requisition" OnClick="btnGenerate_Click" />
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
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Requisition Information</h5>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Requisition #*</label>
                            <asp:TextBox ID="txtReqNo" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="text-danger">Prepared By*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPreparedby" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Approved By</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlApprovedby" runat="server" DataTextField="FirstName" DataValueField="EmployeeID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Requested Arrival Date</label>
                            <asp:TextBox ID="txtTentativeshipdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtTentativeshipdate" TargetControlID="txtTentativeshipdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-sm-6 col-md-3 col-lg-2" style="display: none;">
                        <div class="form-group">
                            <label>Actual Ship Date</label>
                            <asp:TextBox ID="txtActualShipdate" CssClass="form-control form-control-sm" autocomplete="off" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtActualShipdate" TargetControlID="txtActualShipdate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                </div>
                 
                <div class="row border-top pt-3">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Requisition details with quantities</h5>
                        <div class="table-responsive" style="overflow-x:inherit !important;">
                            <table class="table mainGridTable table-sm" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>                               
                                    <th  style="width: 20%;">Part#/Description*</th>
                                     <th style="width: 20%;display:none">Description</th>                   
                                    <th  style="width: 10%;">Product Code</th>    
                                    <th  style="width: 10%;">Department</th>                   
                                    <th style="width: 5%;">UM</th>                                  
                                    <th style="width: 10%;" >Order Qty*</th>
                                    <th style="width: 5%;">Priority</th>
                                    <th style="width: 30%;">Comments</th>
                                    <th></th>
                                </tr>
                                <tr>         
                                    <td>
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartno" runat="server" DataTextField="PartNumber" DataValueField="Partid" AutoPostBack="True" OnSelectedIndexChanged="ddlfooterpartno_SelectedIndexChanged">
                                            <%--<asp:ListItem Selected="True"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                        
                                    <td style="display:none">
                                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlfooterpartinfo" runat="server" DataTextField="PartDescription" DataValueField="Partid" AutoPostBack="true" OnSelectedIndexChanged="ddlfooterpartinfo_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                           <td>
                                        <asp:label ID="lblProductCode" runat="server" Enabled="false"></asp:label>
                                    </td>
                          <td>
                                        <asp:label ID="lblDepartment" runat="server" Enabled="false"></asp:label>
                                    </td>    
                                                                           <td>
                                        <asp:label  ID="lblUm" runat="server" Enabled="false"></asp:label>
                                    </td>                                            
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtfooterqty" MaxLength="5" onkeypress="return onlyDotsAndNumbers(this,event);" runat="server" autocomplete="off" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkfooterPriority" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control form-control-sm text-left" ID="txtcomments" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info btn-sm rounded" ID="btnAdd" runat="server" Text="Add" CommandName="Insert" OnClick="btnAdd_Click" />
                                </tr>
                            </table>

</div>
                            <asp:Panel ID="pangvRequititionDetails" runat="server">
                                <div class="row pt-3">
                                    <div class="col-12">
                                        <div class="table-responsive">
                                            <asp:GridView BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                                                ForeColor="Black" GridLines="Vertical" Width="100%"
                                                ID="gvRequition" runat="server" AutoGenerateColumns="False" DataKeyNames="ReqDetailid" CssClass="table mainGridTable table-sm"
                                                EnableModelValidation="True" OnRowDeleting="gvRequition_RowDeleting">
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Part#/Description" HeaderStyle-Width="19%">
<%--                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblgvEditPartNum" runat="server"></asp:Label>
                                                        </EditItemTemplate>--%>
                                                        <ItemTemplate>                                                           <asp:Label ID="lblpartnumber" runat="server" Text='<%# Eval("Partnumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                        <HeaderStyle Width="19%" />
                                                    </asp:TemplateField>
                 
                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%" Visible="false">
                                                  
                                                        <ItemStyle />
<%--                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblgvEditPartDesc" runat="server"></asp:Label>
                                                        </EditItemTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPartinfo" runat="server" Text='<%# Eval("PartDesc") %>'></asp:Label>
                                                            <asp:Label ID="lblpartid" runat="server" Text='<%# Eval("Partid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />
                                                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Code" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
<%--                    <EditItemTemplate>
                        <asp:Label ID="lblgvEditProductCode" runat="server" 
                            Text='<%# Eval("ProductCode") %>'></asp:Label>
                    </EditItemTemplate>--%>
                    <ItemTemplate>
                    <asp:Label ID="lblgvProductCode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="10%" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
<%--                    <EditItemTemplate>
                        <asp:Label ID="lblgvEditDepartment" runat="server" 
                            Text='<%# Eval("Department") %>'></asp:Label>
                    </EditItemTemplate>--%>
                    <ItemTemplate>
                    <asp:Label ID="lblgvDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="10%" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>                  
                <asp:TemplateField HeaderText="UM" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Left">
<%--                    <EditItemTemplate>
                        <asp:Label ID="lblgvEditum" runat="server" Text='<%# Eval("UM") %>'></asp:Label>
                    </EditItemTemplate>--%>
                    <ItemTemplate>
                        <asp:Label ID="lblgvUM" runat="server" Text='<%# Eval("UM") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="5%" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                                  
            <asp:TemplateField HeaderText="Order Qty" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Right" >
 <%--               <EditItemTemplate>
                <asp:TextBox ID="txtgvOrderQty" runat="server" Text='<%# Eval("PartQty") %>'
                    autocomplete="off" MaxLength="5" CssClass="form-control form-control-sm text-right" onkeypress="return onlyDotsAndNumbers(this,event);"
                    ></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("PartQty") %>' autocomplete="off" MaxLength="5" CssClass="form-control form-control-sm text-right" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="10%" />
                <ItemStyle HorizontalAlign="Right" />

            </asp:TemplateField>
            <asp:TemplateField FooterStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="Priority" ItemStyle-CssClass="ws-nowrap">
<%--                <EditItemTemplate>
                <asp:CheckBox ID="chkgvPriority" runat="server"  Checked='<%# Eval("Priority") %>' />
                </EditItemTemplate>--%>
            <ItemTemplate>
                <asp:CheckBox ID="chkpriority" Checked='<%# Eval("Priority") %>' runat="server" />
            </ItemTemplate>
            <FooterStyle HorizontalAlign="Center" />
            <HeaderStyle Width="5%" />
            <ItemStyle CssClass="ws-nowrap" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="30%" HeaderText="Comments" ItemStyle-HorizontalAlign="Left" >
<%--            <EditItemTemplate>
            <asp:TextBox ID="txtgvComments" runat="server" TextMode="MultiLine" CssClass="form-control form-control-sm text-left" Text='<%# Eval("Comments") %>'></asp:TextBox>
            </EditItemTemplate>--%>
            <ItemTemplate>
            <asp:TextBox ID="txtcomments" runat="server" Text='<%# Eval("Comments") %>' CssClass="form-control form-control-sm text-left" autocomplete="off"></asp:TextBox>
                                                    
            </ItemTemplate>
            <FooterStyle HorizontalAlign="Left" />
            <HeaderStyle Width="30%" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="ws-nowrap" HeaderStyle-Width="8%" FooterStyle-HorizontalAlign="Center">    
                                                        <ItemTemplate>                 
                                                            <asp:LinkButton CssClass="btn btn-info btn-danger" ID="Delete" runat="server" CommandName="Delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <HeaderStyle />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" Wrap="True" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        
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
                        $('#<%=ddlReq.ClientID%>').chosen();                        
                       <%-- $('#<%=ddlReqNo.ClientID%>').chosen();
                        $('#<%=ddlReqStatus.ClientID%>').chosen();--%>
                        $('#<%=ddlPreparedby.ClientID%>').chosen();
                        $('#<%=ddlApprovedby.ClientID%>').chosen();
                        $('#<%=ddlfooterpartinfo.ClientID%>').chosen();
                        $('#<%=ddlfooterpartno.ClientID%>').chosen();                       
                         $('#<%=ddlPreparedByList.ClientID%>').chosen();                    
                       <%-- var dropdown = document.getElementById('<%=((DropDownList)gvRequition.FooterRow.FindControl("ddlfooterpartinfo")).ClientID %>');
                        $(dropdown).chosen();
                        var dropdown2 = document.getElementById('<%=((DropDownList)gvRequition.FooterRow.FindControl("ddlfooterpartno")).ClientID %>');
                        $(dropdown2).chosen();--%>
                    }
                </script>
                <asp:HiddenField ID="hfpartid" runat="server" />
                <CR:CrystalReportViewer ID="rptRequisition" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerate" />
        </Triggers>
    </asp:UpdatePanel>   
<asp:UpdateProgress ID="UpdateProgressloader" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
<ProgressTemplate>            
<div class="spinner">
    <div class="center-div">
        <div class="inner-div">
            <div class="loader"></div>
        </div>
    </div>
</div>   
</ProgressTemplate>
</asp:UpdateProgress> 
</asp:Content>
