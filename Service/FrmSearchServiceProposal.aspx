<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FrmSearchServiceProposal.aspx.cs" Inherits="Service_FrmSearchServiceProposal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12">
                <div class="row">
                    <div class="col-12 pt-2">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Search Service Proposal</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Service P#</label>
                             <asp:TextBox CssClass="form-control form-control-sm" ID="txtServiceP" runat="server" AutoComplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Product Line</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProductLine" runat="server" DataTextField="Conveyorname" DataValueField="Conveyorid"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Service Assigned To</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlAssignedTo" runat="server" DataTextField="fname" DataValueField="id"></asp:DropDownList>
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
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server">
                            <asp:ListItem>All</asp:ListItem>
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
                            <label>Nature of Task</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlNature" runat="server">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem Value="1">Repair</asp:ListItem>
                            <asp:ListItem Value="2">Retrofit</asp:ListItem>
                            <asp:ListItem Value="3">Replacement</asp:ListItem>   
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Quote Sent Date From</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtQuoteSentFrom" runat="server" AutoComplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtQuoteSentFrom" TargetControlID="txtQuoteSentFrom"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label>Quote Sent Date To</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtQuoteSentTo" runat="server" AutoComplete="off"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtQuoteSentTo" TargetControlID="txtQuoteSentTo"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-3 col-lg-4">
                        <div class="form-group srRadiosBtns">
                            <label>Include</label>
                            <asp:RadioButtonList ID="rdbInclude" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">Both P# and J#</asp:ListItem>
                                <asp:ListItem Value="1">Only J#</asp:ListItem>
                                <asp:ListItem Value="2">Only P#</asp:ListItem>
                            </asp:RadioButtonList>
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
                        <asp:GridView ID="gvProposalSearch" runat="server" AutoGenerateColumns="False" Visible="false" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="3" DataKeyNames="PNo" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="100%"
                            OnRowDataBound="gvProposalSearch_RowDataBound" OnRowCommand="gvProposalSearch_RowCommand" CssClass="table mainGridTable table-sm"
                            Style="font-size: small" AllowSorting="true" OnPageIndexChanging="gvProposalSearch_PageIndexChanging" OnSorting="gvProposalSearch_Sorting">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="PNo" HeaderText="Service P#" SortExpression="PNo">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JNO" HeaderText="Service JP#" SortExpression="JNO">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Ref. JobID" HeaderText="Ref.JobID" SortExpression="Ref. JobID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Conveyor Type" HeaderText="Product Line" SortExpression="Conveyor Type">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Assigned To" HeaderText="Service Assigned To" SortExpression="Assigned To">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Technician" HeaderText="Technician" SortExpression="Technician">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Assessment Date" HeaderText="Assessment Date" DataFormatString="{0:d}" SortExpression="Assessment Date">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quote Sent Date" HeaderText="Quote Sent Date" DataFormatString="{0:d}" SortExpression="Quote Sent Date">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Quote Amount" HeaderText="Quote Amount" DataFormatString="{0:C2}" SortExpression="Quote Amount">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nature" HeaderText="Nature of Task" SortExpression="Nature">
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
                        $('#<%=ddlProductLine.ClientID%>').chosen();
                        $('#<%=ddlAssignedTo.ClientID%>').chosen();
                    $('#<%=ddlTechnician.ClientID%>').chosen();
                    $('#<%=ddlStatus.ClientID%>').chosen();
                    $('#<%=ddlNature.ClientID%>').chosen();
                    }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>