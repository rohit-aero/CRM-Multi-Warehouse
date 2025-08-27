<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="FrmSearchProject.aspx.cs" Inherits="SalesManagement_FrmSearchProject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Project</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Project Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtProjectName" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Model Name</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlModelName" runat="server" DataTextField="ModelName" DataValueField="ModelID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Conveyor Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConveyorName" runat="server" DataTextField="ConveyorType" DataValueField="ConveyorTypeID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2" style="display: none;">
                        <div class="form-group">
                            <label>Business Type</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlBusinessName" runat="server" DataTextField="Desc" DataValueField="BusinessTypeID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountryName" runat="server" DataTextField="Country" DataValueField="CountryID" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStateName" runat="server" DataTextField="State" DataValueField="StateID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Consultant</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConsultantName" runat="server" DataTextField="Companyname" DataValueField="ConsultantID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Dealer</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDealerName" runat="server" DataTextField="Companyname" DataValueField="DealerID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Rep Group</label>
                            <asp:DropDownList ID="ddlSalesRepGroup" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id">
                                <%--                                <asp:ListItem Value="-1">All</asp:ListItem>
                                <asp:ListItem Value="Hobart">Hobart (All Regions)</asp:ListItem>
                                <asp:ListItem Value="Burlis">Burlis-Lawson Group</asp:ListItem>
                                <asp:ListItem Value="Equipment Preference">EPI</asp:ListItem>
                                <asp:ListItem Value="Hri">HRI</asp:ListItem>
                                <asp:ListItem Value="KLH">KLH</asp:ListItem>
                                <asp:ListItem Value="Posternak">PBAC</asp:ListItem>
                                <asp:ListItem Value="Premier Marketing Group">PMG</asp:ListItem>
                                <asp:ListItem Value="Professional Manufacturers">PMR</asp:ListItem>
                                <asp:ListItem Value="Squier">Squier</asp:ListItem>
                                <asp:ListItem Value="Woolsey">Woolsey Associates</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Sales Rep</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlRepName" runat="server" DataTextField="RepName" DataValueField="RepID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Manager</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlManager" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>PO#</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPONo" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Ship Date From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Ship Date To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtToDate" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtToDate" TargetControlID="txtToDate">
                            </asp:CalendarExtender>
                        </div>

                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Manufacturing Facility</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlMfacility" runat="server" DataTextField="FacilityName" DataValueField="ID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-12 col-sm-4 col-md-3 col-lg-10">
                                <div class="form-group">
                                    <label>Model Name(Current Projects)</label>
                                    <asp:ListBox CssClass="form-control form-control-sm" ID="ddlModelNewMultiSelectList" runat="server" DataTextField="Model" DataValueField="id" SelectionMode="multiple"></asp:ListBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-12">

                        <div class="row">
                            <div class="col-md-auto">
                                <asp:Button CssClass="btn btn-secondary btn-sm" ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear Search" />
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnExportToExcel" CausesValidation="false" runat="server" Enabled="false" Text="Export To Excel" OnClick="btnExportToExcel_Click1" />

                            </div>
                            <div class="col-md justify-content-center">
                                <strong class="text-center">
                                    <asp:Label CssClass="alert alert-success d-block py-1" ID="lblRecordsCount" runat="server" Text="Label" Visible="false"></asp:Label></strong>
                            </div>
                        </div>
                    </div>

                </div>            
                <div class="col-12" style="overflow-x: auto; max-height: 400px; overflow-y: auto;">                
                        <asp:GridView CssClass="table mainGridTable table-sm" ID="gvSearchProject" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="JobID" AllowSorting="true"
                            EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Style="font-size: small"
                            Width="100%" OnRowDataBound="gvSearchProject_RowDataBound" OnRowCommand="gvSearchProject_RowCommand" OnSorting="gvSearchProject_Sorting" OnPageIndexChanging="gvSearchProject_PageIndexChanging">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="JobID" HeaderText="J#" SortExpression="JobID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProposalID" HeaderText="P#" SortExpression="ProposalID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CompanyName" HeaderText="Name" SortExpression="CompanyName">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JobType" HeaderText="Type" SortExpression="JobType">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ExistingJob" HeaderText="Existing Job#" SortExpression="ExistingJob">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C2}" SortExpression="Price">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Installation" HeaderText="Installation" DataFormatString="{0:C2}" SortExpression="Installation">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Freight" HeaderText="Freight" DataFormatString="{0:C2}" SortExpression="Freight">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Conveyor Type" HeaderText="Conveyor Type" SortExpression="Conveyor Type">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DealerName" HeaderText="Dealer" SortExpression="DealerName">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ConsultantName" HeaderText="Consultant" SortExpression="ConsultantName">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SalesRepname" HeaderText="Sales Rep" SortExpression="SalesRepname">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Manager" HeaderText="Manager" SortExpression="Manager">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>                    
                </div>               
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExporttoExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        var opennewwindow = function (jid) {
            window.location = "FrmProjects.aspx?jid=" + jid;
        }

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
            $('#<%=ddlModelNewMultiSelectList.ClientID%>').chosen();
            $('#<%=ddlConsultantName.ClientID%>').chosen();
            $('#<%=ddlConveyorName.ClientID%>').chosen();
            $('#<%=ddlCountryName.ClientID%>').chosen();
            $('#<%=ddlDealerName.ClientID%>').chosen();
            $('#<%=ddlModelName.ClientID%>').chosen();
            $('#<%=ddlRepName.ClientID%>').chosen();
            $('#<%=ddlStateName.ClientID%>').chosen();
            $('#<%=ddlSalesRepGroup.ClientID%>').chosen();
            $('#<%=ddlManager.ClientID%>').chosen();

        }
        function printGrid() {

            var gridData = document.getElementById('<%=gvSearchProject.ClientID %>');
            var prtWindow = window.open('', '', 'left=100,top=100,right=100,bottom=100,width=700,height=500');
            var str = "Search Project Details";
            prtWindow.document.title = str;
            window.name = prtWindow.document.title;
            prtWindow.document.write('<html><head><title>' + window.name + '</title></head>');
            prtWindow.document.write('<body style="background:none !important;position:center">');
            prtWindow.document.write('<h1 style="text-align:center">' + str + '</h1>')
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            //get pop up window rows 
            var rows = prtWindow.document.getElementById('<%=gvSearchProject.ClientID %>').rows;
            //for (var i = 0; i < rows.length; i++) {
            // remove first column            
            //rows[i].deleteCell(12);
            //}        
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }

    </script>
</asp:Content>
