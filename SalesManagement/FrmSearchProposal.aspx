<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FrmSearchProposal.aspx.cs" Inherits="SalesManagement_FrmSearchProposal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Proposal</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                        <div class="form-group">
                            <label>Proposal Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtProposalName" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Industry</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlIndustry" runat="server" DataTextField="name" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Prime Spec</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPrimeSpec" runat="server" DataTextField="CompetitorName" DataValueField="CompetitorID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="State" DataValueField="StateID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Consultant</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConsultant" runat="server" DataTextField="CompanyName" DataValueField="ConsultantID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Dealer</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddldealer" runat="server" DataTextField="Companyname" DataValueField="DealerID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Rep Group</label>
                            <asp:DropDownList ID="ddlSalesRepGroup" CssClass="form-control form-control-sm" runat="server" DataTextField="text" DataValueField="id">
                                <%-- <asp:ListItem Value="-1">All</asp:ListItem>
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
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Sales Rep</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlSalesRep" runat="server" DataTextField="SalesRep" DataValueField="RepID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4 col-lg-2">
                        <div class="form-group">
                            <label>Manager</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlManager" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Proposal Date From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Proposal Date To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txttodate" runat="server" AutoComplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txttodate" TargetControlID="txttodate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                        <div class="form-group srRadiosBtns">
                            <label>Include</label>
                            <asp:RadioButtonList ID="rdbOrderFor" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">Both P# and J#</asp:ListItem>
                                <asp:ListItem Value="1">Only J#</asp:ListItem>
                                <asp:ListItem Value="2">Only P#</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="row">
                            <%--                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group">
                                    <label>Model Name(Current Projects)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlModelNew" runat="server" DataTextField="Model" DataValueField="id"></asp:DropDownList>                                    
                                </div>
                            </div>--%>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group">
                                    <label>Model Name(Legacy Projects-Prior July 2023)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlModelName" runat="server" DataTextField="ModelName" DataValueField="ModelID"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                                <div class="form-group">
                                    <label>Conveyor Type(Legacy Projects-Prior July 2023)</label>
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlConveyorType" runat="server" DataTextField="ConveyorType" DataValueField="ConveyorTypeID"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
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
                                <asp:Button ID="btnSearchProposal" runat="server" CssClass="btn btn-secondary btn-sm" Text="Search" OnClick="btnSearchProposal_Click" />
                                <asp:Button ID="btnClearProposal" runat="server" CssClass="btn btn-danger btn-sm" Text="Clear Search" OnClick="btnClearProposal_Click" />
                                <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Enabled="false" Text="Export to Excel" OnClick="btnExportToExcel_Click1" />
                            </div>
                            <div class="col-md justify-content-center">
                                <strong class="text-center">
                                    <asp:Label CssClass="alert alert-success d-block py-1" ID="lblRecordsCount" runat="server" Text="Label" Visible="false"></asp:Label></strong>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12" style="overflow-x: auto; max-height: 400px; overflow-y: auto;">
                        <asp:GridView ID="gvProposalSearch" runat="server" AutoGenerateColumns="False" Visible="false" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="3" DataKeyNames="PNumber" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="100%"
                            OnRowDataBound="gvProposalSearch_RowDataBound" OnRowCommand="gvProposalSearch_RowCommand" CssClass="table mainGridTable table-sm"
                            Style="font-size: small" AllowSorting="true" OnPageIndexChanging="gvProposalSearch_PageIndexChanging" OnSorting="gvProposalSearch_Sorting">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="PNumber" HeaderText="Proposal#" SortExpression="PNumber">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JobID" HeaderText="Job#" SortExpression="JobID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProjectName" HeaderText="Project Name" SortExpression="ProjectName">
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
                                <asp:BoundField DataField="ConveyorType" HeaderText="Conveyor Type" SortExpression="ConveyorType">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Models" HeaderText="Model" SortExpression="Models">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CompetitorName" HeaderText="Prime Spec" SortExpression="CompetitorName">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ConsultantName" HeaderText="Consultant" SortExpression="ConsultantName">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DealerName" HeaderText="Dealer" SortExpression="DealerName">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SalesRep" HeaderText="Sales Rep" SortExpression="SalesRep">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Manager" HeaderText="Manager" SortExpression="Manager">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                                <asp:BoundField DataField="Industry" HeaderText="Industry" SortExpression="Industry">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                var opennewwindow = function (ds) {
                    window.location = "FrmProposals.aspx?ds=" + ds;
                }
                function exportTableToExcel() {
                    var tbl = $("[id$=gvProposalSearch]");
                    var rows = tbl.find('tr');
                    for (var index = 0; index < rows.length; index++) {
                        var row = rows[index];

                        var PNumber = $(row).find("[id*=PNumber]").text();

                        alert(PNumber);
                        var downloadLink;
                        var dataType = 'application/vnd.ms-excel';
                        var tableSelect = document.getElementById(tableID);
                        alert(tableSelect);
                        var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

                        // Specify file name
                        filename = filename ? filename + '.xls' : 'excel_data.xls';

                        // Create download link element
                        downloadLink = document.createElement("a");

                        document.body.appendChild(downloadLink);

                        if (navigator.msSaveOrOpenBlob) {
                            var blob = new Blob(['\ufeff', tableHTML], {
                                type: dataType
                            });
                            navigator.msSaveOrOpenBlob(blob, filename);
                        } else {
                            // Create a link to the file
                            downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

                            // Setting the file name
                            downloadLink.download = filename;

                            //triggering the function
                            downloadLink.click();
                        }
                    }
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
                    $('#<%=ddlConsultant.ClientID%>').chosen();
                    $('#<%=ddlConveyorType.ClientID%>').chosen();
                    $('#<%=ddlCountry.ClientID%>').chosen();
                    $('#<%=ddlIndustry.ClientID%>').chosen();
                    $('#<%=ddldealer.ClientID%>').chosen();
                    $('#<%=ddlModelName.ClientID%>').chosen();
                    $('#<%=ddlPrimeSpec.ClientID%>').chosen();
                    $('#<%=ddlSalesRep.ClientID%>').chosen();
                    $('#<%=ddlState.ClientID%>').chosen();
                    $('#<%=ddlModelNewMultiSelectList.ClientID%>').chosen();
                    $('#<%=ddlSalesRepGroup.ClientID%>').chosen();
                }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
