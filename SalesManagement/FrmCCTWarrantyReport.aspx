<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FrmCCTWarrantyReport.aspx.cs" Inherits="FrmCCTWarrantyReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Warranty Report</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <%--<div class="col-6 col-sm-4 col-md-3 col-lg-2 "style="display:none;">
<div class="form-group">
<label>Rep Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtProposalName" AutoComplete="off" runat="server"></asp:TextBox>
</div>
</div>--%>
                    <%--    <div class="col-6 col-sm-4 col-md-3 col-lg-2 ">
<div class="form-group">
<label>Rep Name</label>
<asp:TextBox CssClass="form-control form-control-sm" ID="txtRepName" AutoComplete="off" runat="server"></asp:TextBox>
</div>
</div>--%>
                         <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" AutoComplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>End Date</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txttodate" runat="server" AutoComplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txttodate" TargetControlID="txttodate"></asp:CalendarExtender>
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
                    <div class="col">
                        <asp:GridView ID="gvProposalSearch" runat="server" AutoGenerateColumns="False" Visible="False" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="3" DataKeyNames="JobID" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="100%"
                            OnRowDataBound="gvProposalSearch_RowDataBound" OnRowCommand="gvProposalSearch_RowCommand" CssClass="table mainGridTable table-sm"
                            Style="font-size: small" AllowSorting="True" OnPageIndexChanging="gvProposalSearch_PageIndexChanging" OnSorting="gvProposalSearch_Sorting" BackColor="White" BorderColor="#999999">

                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="PNumber" HeaderText="Proposal#" SortExpression="PNumber">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JobID" HeaderText="Job#" SortExpression="JobID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Job Name" HeaderText="Project Name" SortExpression="Job Name">
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
                                <asp:BoundField DataField="NetEqPrice" HeaderText="Net Eq. Price" DataFormatString="{0:C2}" SortExpression="NetEqPrice">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ShipDate" HeaderText="Ship Date" DataFormatString="{0:C2}" SortExpression="ShipDate">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="Warranty Start" HeaderText="Warranty Start" DataFormatString="{0:C2}" SortExpression="Warranty Start">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Warranty End" HeaderText="Warranty End" DataFormatString="{0:C2}" SortExpression="Warranty End">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>                             
                                <asp:BoundField DataField="ModelName" HeaderText="Model Name" SortExpression="ModelName">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Consultant" HeaderText="Consultant" SortExpression="Consultant">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Dealer" HeaderText="Dealer" SortExpression="Dealer">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Destination Rep" HeaderText="Destination Rep" SortExpression="Destination Rep">
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
                  

                    }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
