<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="FrmEngineerTaskStatus.aspx.cs" Inherits="SalesManagement_FrmEngineerTaskStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Engineer Tasks</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-8">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Task#</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTaskList" runat="server" DataTextField="PName" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlTaskList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="false" Text="Update" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                            <div class="col-12">
                                <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">Error message</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-3">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Task Information</h5>
                    </div>

                    <div class="col-sm-6 ">
                        <div class="form-group">
                            <label>Project Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" Enabled="false" ID="txtProjectName" runat="server">
                            </asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>JobID</label>
                            <asp:TextBox CssClass="form-control form-control-sm" Enabled="false" ID="txtJobID" runat="server">
                            </asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Task</label>
                            <asp:TextBox CssClass="form-control form-control-sm" Enabled="false" ID="txtTask" runat="server">
                            </asp:TextBox>
                        </div>
                    </div>


                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Project Engineer</label>
                            <asp:TextBox CssClass="form-control form-control-sm" Enabled="false" ID="txtProjectEngineer" runat="server">
                            </asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-8 ">
                        <div class="form-group">
                            <label id="lblComments">Remarks By Assignee</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtRemarks" runat="server" />
                        </div>
                    </div>

                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label id="lblPriority">Priority</label>
                            <asp:TextBox CssClass="form-control form-control-sm " Enabled="false" ID="txtPriority" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlStatus" runat="server" DataTextField="Status" DataValueField="ID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Project Sent To Customer</label>
                            <asp:TextBox ID="txtProjectSendToRCD" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtProjectSendToRCD" TargetControlID="txtProjectSendToRCD">
                            </asp:CalendarExtender>
                        </div>
                    </div>   
                    
                     <div class="col-sm-8 " style="display:none;">
                        <div class="form-group">
                            <label id="lblRemarksByEngineer">Remarks By Engineer</label>
                            <asp:TextBox CssClass="form-control form-control-sm " ID="txtRemarksByEngineer" runat="server" />
                        </div>
                    </div>                 
                </div>
            </div>
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
            $('#<%=ddlTaskList.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
        }
    </script>
</asp:Content>