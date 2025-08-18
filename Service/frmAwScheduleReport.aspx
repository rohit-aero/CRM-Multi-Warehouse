<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="frmAwScheduleReport.aspx.cs" Inherits="Reports_frmAwScheduleReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-auto mx-auto innerMain">
        <div class="row pt-3 flex-column">
            <div class="col-12">
                <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                <h4 class="title-hyphen position-relative mb-3">Aerowerks Service Shipment Schedule Report</h4>
                <%--<h5 class="text-uppercase">Select Filters</h5>--%>
            </div>
            <div class="col-12">
                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
            </div>
        </div>
        <div id="divOrders" runat="server">
            <div class="row">
                <div class="col-sm-3">
                    <div class="row">
                        <label class="col-md-4">Report Type</label>
                        <div class="col-md-8">
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlType" runat="server" onchange="ChangeText();">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Release Date Report</asp:ListItem>
                            <asp:ListItem Value="2">Required Ship Date Report</asp:ListItem>
                        </asp:DropDownList>
                        </div>                       
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="row">
                        <label class="col-md-5" id="lblFrom">Date From</label>
                        <div class="col-md-7">
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFromDate" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtFromDate"></asp:CalendarExtender>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="row">
                        <label class="col-md-5" id="lblTo">Date To</label>
                        <div class="col-md-7">
                             <asp:TextBox CssClass="form-control form-control-sm" ID="txtEndDate" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="btnCal1" TargetControlID="txtEndDate"></asp:CalendarExtender>
                            </div>                       
                    </div>
                </div>

                 <div class="col-sm-9 mt-3">
                    <div class="row">
                        <label class="col-md-1">Job#/Name</label>
                        <div class="col-md-11">
                        <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobNo" DataTextField="ProjectName" DataValueField="JobID" runat="server">
                        </asp:DropDownList>
                       </div>                       
                    </div>
                </div>
                <div class="col-sm-auto mt-3">
                    <div class="form-group mb-0 flex-column">                        
                        <div>
                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnGenrate" runat="server" Text="Preview Report" OnClick="btnGenrate_Click" CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" />
                            <%--<asp:Button CssClass="btn btn-info btn-sm" ID="btnGenerateExcel" runat="server" CausesValidation="false" Text="Export To Excel" OnClick="btnGenerateExcel_Click" />--%>
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="Cancel" OnClick="btnClear_Click" />
                        </div>
                    </div>
                </div>
               
            </div>
              
        </div>
    </div>
    <CR:CrystalReportViewer ID="rptSales" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
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
              $('#<%=ddlType.ClientID%>').chosen();
        }
        function ChangeText(){
            var typename = document.getElementById('<%=ddlType.ClientID%>').value;
            if (typename == "0") {
                document.getElementById('lblFrom').innerHTML = "Date From";
                document.getElementById('lblTo').innerHTML = "Date To";
                document.getElementById('<%=txtFromDate.ClientID%>').value="";
                document.getElementById('<%=txtEndDate.ClientID%>').value="";
            }
            else if (typename == "1") {
                document.getElementById('lblFrom').innerHTML = "Release Date From";
                document.getElementById('lblTo').innerHTML = "Release Date To";
            }
            else if (typename == "2") {
                document.getElementById('lblFrom').innerHTML = "Required Ship Date From";
                document.getElementById('lblTo').innerHTML = "Required Ship Date To";
            }
        }
    </script>
</asp:Content>