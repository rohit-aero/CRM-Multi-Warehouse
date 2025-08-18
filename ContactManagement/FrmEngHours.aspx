<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FrmEngHours.aspx.cs" Inherits="ContactManagement_FrmEngHours" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>          
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="col-8">
                   <%-- Project Info Start --%>
                   <fieldset>
                    <legend><b>Project Information</b></legend>
                    <div class="row mb-1 customSelects">
                                <label class="col-xl-2 mb-0">Project</label>
                                <div class="col-xl-10 mb-2">
                                    <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProjectNo" DataTextField="ProjectName" DataValueField="PNumber" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProjectNo_SelectedIndexChanged"></asp:DropDownList>
                                </div>  
                                 <label class="col-xl-2 mb-0">Department Name</label>
                                <div class="col-xl-10 mb-2">
                                   <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEngDepartment" DataTextField="DepartmentName" DataValueField="Departmentid" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEngDepartment_SelectedIndexChanged"></asp:DropDownList>
                                </div>                             
                                <label class="col-xl-2 mb-0">Employee Name</label>
                                <div class="col-xl-10 mb-2">
                                   <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEngEmployee" DataTextField="EmployeeName" DataValueField="EmployeeID" runat="server"></asp:DropDownList>
                                </div>
                                <label class="col-xl-2 mb-0">Date</label>
                                <div class="col-xl-10 mb-2">
                                    <div class="d-flex align-items-center">
                                        <asp:TextBox CssClass="form-control form-control-sm" ID="txtDate" runat="server" autocomplete="off" Style="width: 180px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtendergvFollowupDate" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDate" TargetControlID="txtDate"></asp:CalendarExtender>                                        
                                    </div>
                                </div>
                                <label class="col-xl-2 mb-0">Nature Of Task</label>
                                <div class="col-xl-10 mb-2">
                                    <asp:DropDownList ID="ddlNatureOfTask" CssClass="form-control form-control-sm" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Proposal Drawing</asp:ListItem>
                                        <asp:ListItem Value="2">Job Drawing</asp:ListItem>
                                        <asp:ListItem Value="3">Revit</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label class="col-xl-2 mb-0">Category</label>
                                <div class="col-xl-10 mb-2">
                                    <asp:DropDownList ID="ddlCategory" CssClass="form-control form-control-sm" runat="server">
                                         <asp:ListItem Value="0">Select</asp:ListItem>
                                         <asp:ListItem Value="1">New</asp:ListItem>
                                         <asp:ListItem Value="2">Revision</asp:ListItem>
                                         <asp:ListItem Value="3">Correction</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label class="col-xl-2 mb-0">Start Time</label>
                                <div class="col-xl-10 mb-2">
                                    <div class="row">
                                        <div class="col-auto mb-2">
                                            <div class="d-flex align-items-center">
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtStartTime" runat="server" onchange="checkTime(this)" autocomplete="off" onkeydown="javascript:if(event.keyCode==8||event.keyCode==46){this.value='__:__';}" onmouseup="SetFocus(this);" onblur="javascript:if(this.value=='__:__'){this.value='';}" AutoPostBack="True" Width="52px" OnTextChanged="txtStartTime_TextChanged1"></asp:TextBox><span class="pl-2">(12:00 Hour)</span>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtStartTime" PromptCharacter="_" ClearMaskOnLostFocus="false" MaskType="Number" Mask="99:99" InputDirection="LeftToRight"></asp:MaskedEditExtender>
                                            </div>
                                        </div>
                                        <div class="col-auto mb-2">
                                            <div class="d-flex align-items-center">
                                                <label class="pr-3 mb-0">End Time</label>
                                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtFinishTime" runat="server" autocomplete="off" onchange="checkTime(this)" onkeydown="javascript:if(event.keyCode==8||event.keyCode==46){this.value='__:__';}" onmouseup="SetFocus(this);" onblur="javascript:if(this.value=='__:__'){this.value='';}" AutoPostBack="True" Width="52px" OnTextChanged="txtFinishTime_TextChanged"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFinishTime" PromptCharacter="_" ClearMaskOnLostFocus="false" MaskType="Number" Mask="99:99" InputDirection="LeftToRight"></asp:MaskedEditExtender>
                                                <span class="pl-2">(24:00 Hour)</span>
                                            </div>
                                        </div>
                                        <div class="col-auto mb-2">
                                            <div class="d-flex align-items-center">
                                                <label class="pr-3 mb-0">Hours Worked</label>
                                                <div class="">
                                                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtTotalHours" runat="server" Enabled="false" Width="52px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            <div class="col-sm-6 justify-content-center" id="dvMsg" runat="server" visible="false">
                            <strong class="text-center"><asp:Label runat="server" CssClass="alert alert-success d-block py-1 mb-0"  ID="lblMsg"></asp:Label></strong>
                            </div>  
                                <div class="offset-xl-2 col-xl-10">
                                <asp:Button CssClass="btn btn-success btn-sm" ID="btnAdd" runat="server" Text="Save" OnClick="btnAdd_Click" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>       
                            </div>
                </fieldset>
                </div>
                <div class="table-responsive">
                <asp:GridView CssClass="mainGridTable table table-sm" ID="gvCaptureData"  DataKeyNames="EmployeeTimeid"
                    runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowUpdating="gvCaptureData_RowUpdating" OnRowCommand="gvCaptureData_RowCommand">
                    <Columns>                    
                        <asp:BoundField DataField="ProposalID" HeaderText="Project No">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>   
                        <asp:BoundField DataField="DepartmentName" HeaderText="Department Name">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                 
                        <asp:BoundField DataField="Employee" HeaderText="Employee Name">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TaskDate" HeaderText="Task Date">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                       
                        <asp:BoundField DataField="TaskNatureName" HeaderText="Task Nature">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TaskCategoryName" HeaderText="Task Category">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StartTime" HeaderText="Start Time">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EndTime" HeaderText="Finish Time">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalTime" HeaderText="Total Hours">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                 
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" CommandName="Update" runat="server">Edit</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lnkDelete" CommandName="Delete" OnClientClick="return confirm('Are you sure to Delete this ?');" Visible="false" runat="server">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
            <asp:HiddenField ID="hfEmployeerowid" runat="server" />
            <asp:HiddenField ID="HfProjectNo" runat="server" />
            <script type="text/javascript">
                $(document).ready(function () {
                    document.getElementById("navbarDropdown3").className = 'nav-link dropdown-toggle active';
                    document.getElementById("LT").className = 'dropdown-item active';
                });

                function checkTime(field) {
                    var errorMsg = "";

                    // regular expression to match required time format
                    re = /^(\d{1,2}):(\d{2})(:00)?([ap]m)?$/;

                    if (field.value != "") {
                        if (regs = field.value.match(re)) {
                            if (regs[4]) {
                                // 12-hour time format with am/pm
                                if (regs[1] < 1 || regs[1] > 12) {
                                    errorMsg = "Invalid value for hours: " + regs[1];

                                }
                            } else {
                                // 24-hour time format
                                if (regs[1] > 23) {
                                    errorMsg = "Invalid value for hours: " + regs[1];

                                }
                            }
                            if (!errorMsg && regs[2] > 59) {
                                errorMsg = "Invalid value for minutes: " + regs[2];

                            }
                        } else {
                            errorMsg = "Invalid time format: " + field.value;

                        }
                    }

                    if (errorMsg != "") {
                        alert(errorMsg);
                        field.value = "__:__";
                        field.focus();
                        return false;
                    }

                    return true;
                }


                $(document).ready(function () {
                    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
                });
                function PageLoaded(sender, args) {
                    ddl();
                }
                $.when.apply($, PageLoaded).then(function () {

                    ddl();
                });
                function ddl() {
                    $('#<%=ddlProjectNo.ClientID%>').chosen();    
                    $('#<%=ddlEngDepartment.ClientID%>').chosen();  
                      $('#<%=ddlEngEmployee.ClientID%>').chosen();
                    $('#<%=ddlNatureOfTask.ClientID%>').chosen();
                    $('#<%=ddlCategory.ClientID%>').chosen();
        }

        function SetFocus(ctrl) {
            ctrl.setSelectionRange(0, 0);
        }




            </script>
        </ContentTemplate>      
    </asp:UpdatePanel>
</asp:Content>