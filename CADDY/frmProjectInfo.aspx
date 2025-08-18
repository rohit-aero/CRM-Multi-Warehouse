<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmProjectInfo.aspx.cs" Inherits="CADDY_frmProjectInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCusId" runat="server" Value="-1" />
            <asp:HiddenField ID="hfJobDetails" runat="server" Value="-1" />
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Caddy Project Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="row mb-3">
                            <div class="col-sm-3">
                                <label class="mb-0">Caddy No./Description</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookUpJobDes" runat="server" DataTextField="JobDescription" DataValueField="ProjectID" AutoPostBack="true" OnSelectedIndexChanged="ddlLookUpJobDes_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnAddTasks" runat="server" CssClass="btn btn-primary btn-sm" Text="Add Tasks" OnClick="btnAddTasks_Click" Enabled="false" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click" />                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Add Project Details</h5>
                    </div>
                    <div class="col-sm-3 col-md-2">
                        <div class="form-group">
                            <label class="text-danger">Caddy No.*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtJobNo" AutoComplete="off" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <div class="form-group">
                            <label class="text-danger">Job Name*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtJobName" AutoComplete="off" MaxLength="500" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-2">
                        <div class="form-group">
                            <label class="text-danger">Job Type*</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlJobType" runat="server" DataTextField="JobTypeName" DataValueField="JobTypeID" OnSelectedIndexChanged="ddlJobType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-2">
                        <div class="form-group">
                            <label>Project Manager</label>
                            <div class="input-group input-group-sm d-flex align-items-center">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjManagerCaddy" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-12" id="dvModelText" runat="server" visible="false">                       
                            <div class="form-group">
                                <label>Model:</label>
                                <label id="lblText_1" class="boldtext"></label>
                            </div>                       
                    </div>
                    <div class="col-12" id="dvhoods" runat="server" visible="false">
                        <div class="row pt-3 custom-checkbox-align">
                            <div class="col-sm-6 col-md-1">
                                <div class="form-group">
                                    <b>
                                        <label>Hoods</label></b>
                                    <asp:CheckBoxList ID="chkModel" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValueHoods();"></asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12" id="dvconveyor" runat="server" visible="false">

                        <div class="row pt-3 custom-checkbox-align">

                            <div class="col-sm-6 col-md-1">
                                <div class="form-group">
                                    <b>
                                        <label>Conveyor</label></b>
                                    <asp:CheckBoxList ID="chk5" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-1">
                                <div class="form-group">
                                    <b>
                                        <label>SDT</label></b>
                                    <asp:CheckBoxList ID="chk1" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-1">
                                <div class="form-group">
                                    <b>
                                        <label>CDT</label></b>
                                    <asp:CheckBoxList ID="chk2" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-1">
                                <div class="form-group">
                                    <b>
                                        <label>Sink</label></b>
                                    <asp:CheckBoxList ID="chk3" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-2">
                                <div class="form-group">
                                    <b>
                                        <label>Tray Make Up</label></b>
                                    <asp:CheckBoxList ID="chk6" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-2">
                                <div class="form-group">
                                    <b>
                                        <label>Power Turn Loader/Unloader</label></b>
                                    <asp:CheckBoxList ID="chk7" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-1">
                                <div class="form-group">
                                    <b>
                                        <label>RET</label></b>
                                    <asp:CheckBoxList ID="chk4" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-1">
                                <div class="form-group">
                                    <b>
                                        <label>Miselleneous</label></b>
                                    <asp:CheckBoxList ID="chk8" runat="server" JSvalue="modelid" DataTextField="name" DataValueField="modelid" onchange="GetValue();"></asp:CheckBoxList>
                                </div>
                            </div>
                            <input type="hidden" id="hdchk" runat="server" value="" />
                        </div>
                    </div>



                </div>
            </div>
            <asp:HiddenField ID="hfProjectID" runat="server" />
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
            $('#<%=ddlJobType.ClientID%>').chosen();
            $('#<%=ddlProjManagerCaddy.ClientID%>').chosen();
            $('#<%=ddlLookUpJobDes.ClientID%>').chosen();
        }
        function GetValue() {
            document.getElementById('lblText_1').innerHTML = '';
            var chkBoxCategory = new Array();
            chkBoxCategory.push(document.getElementById('<%= chk5 .ClientID %>'));
            chkBoxCategory.push(document.getElementById('<%= chk1 .ClientID %>'));
            chkBoxCategory.push(document.getElementById('<%= chk2 .ClientID %>'));
            chkBoxCategory.push(document.getElementById('<%= chk3 .ClientID %>'));
            chkBoxCategory.push(document.getElementById('<%= chk6 .ClientID %>'));
            chkBoxCategory.push(document.getElementById('<%= chk7 .ClientID %>'));
            chkBoxCategory.push(document.getElementById('<%= chk4 .ClientID %>'));
            chkBoxCategory.push(document.getElementById('<%= chk8 .ClientID %>'));            
            for (var i_1 = 0; i_1 < chkBoxCategory.length; i_1++) {
                var options = chkBoxCategory[i_1].getElementsByTagName('input');
                var listOfSpans = chkBoxCategory[i_1].getElementsByTagName('span');
                var checkBoxSelectedItems = new Array();
                var checkBoxSelectedText = new Array();
                for (var i_2 = 0; i_2 < options.length; i_2++) {
                    if (options[i_2].checked) {
                        checkBoxSelectedItems.push(listOfSpans[i_2].attributes["JSvalue"].value);
                        var ins = '';
                        if (document.getElementById('lblText_1').innerHTML != '') {
                            ins = ',';
                        }
                        checkBoxSelectedText.push(ins + listOfSpans[i_2].attributes["JSText"].value);
                    }
                }
                document.getElementById('lblText_1').innerHTML += checkBoxSelectedText;
            }
            var lblText = document.getElementById('lblText_1').innerHTML.replaceAll(",/", "/");
            lblText = lblText.replaceAll(",", "/");
            lblText = lblText.replaceAll("//", "/");
            document.getElementById('lblText_1').innerHTML = lblText;
            var temp = true;
            return temp;
        }

        function GetValueHoods() {
            document.getElementById('lblText_1').innerHTML = '';
            var chkBoxCategory = new Array();
            chkBoxCategory.push(document.getElementById('<%= chkModel .ClientID %>'));
            for (var i_1 = 0; i_1 < chkBoxCategory.length; i_1++) {
                var options = chkBoxCategory[i_1].getElementsByTagName('input');
                var listOfSpans = chkBoxCategory[i_1].getElementsByTagName('span');
                var checkBoxSelectedItems = new Array();
                var checkBoxSelectedText = new Array();

                for (var i_2 = 0; i_2 < options.length; i_2++) {
                    if (options[i_2].checked) {
                        checkBoxSelectedItems.push(listOfSpans[i_2].attributes["JSvalue"].value);
                        var ins = '';
                        if (document.getElementById('lblText_1').innerHTML != '') {
                            ins = ',';
                        }
                        checkBoxSelectedText.push(ins + listOfSpans[i_2].attributes["JSText"].value);
                    }
                }

                document.getElementById('lblText_1').innerHTML += checkBoxSelectedText;
            }
            var lblText = document.getElementById('lblText_1').innerHTML.replaceAll(",/", "/");
            lblText = lblText.replaceAll(",", "/");
            lblText = lblText.replaceAll("//", "/");
            document.getElementById('lblText_1').innerHTML = lblText;
            var temp = true;
            return temp;
        }

    </script>
</asp:Content>
