<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master"  CodeFile="FrmCaddyEngTasks.aspx.cs" Inherits="CADDY_FrmCaddyEngTasks" %>

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
                            <h4 class="title-hyphen position-relative">CADDY Engineering Tasks</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-6 col-xl-8">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Caddy#, Name</label>
                            </div>
                            <div class="col-sm-9 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPNumberHeaderList" runat="server" DataTextField="JobDescription" DataValueField="JobNo" AutoPostBack="True" OnSelectedIndexChanged="ddlPNumberHeaderList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                           <div class="col-auto">
                           <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Cancel" OnClick="btnCancel_Click"  /> 
                           
                           <asp:Button ID="btnGenerateReport" runat="server" CssClass="btn btn-secondary btn-sm" Text="Daily Report" OnClick="btnGenerateReport_Click"  CausesValidation="false" OnClientClick="window.document.forms[0].target='_blank';" Enabled="false" />
                           
                            <asp:Button ID="btnReportType" runat="server" CssClass="btn btn-success btn-sm" Text="Generate Report" OnClick="btnReportType_Click" />
                            
                           <asp:Button ID="btnFilterDate" runat="server" CssClass="btn btn-success btn-sm" Text="Filter Data" OnClick="btnFilterDate_Click" Visible="false" />

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
                        <h5 class="text-uppercase">Project Information</h5>
                    </div>
                    <div class="col-sm-2 chosenFullWidth">    
                        <label class="text-danger">Caddy No*</label>
                   <asp:Panel ID="JobNumber" runat="server" Style="height: 200px; overflow: scroll;display: none;"></asp:Panel>
                        <asp:Panel ID="PanelJobNumber" runat="server" DefaultButton="SearchJobNumberButton">
                                        <asp:TextBox ID="txtJobNumber" placeholder="Type Job Number" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEventForPName(event)" onkeypress="return EnterEventForPName(event)">
                                        </asp:TextBox>
                                       <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtJobNumber"
                                            CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="JobNumber"
                                            ServicePath="../AutoComplete.asmx" ServiceMethod="SearchCADDYJobNumber" CompletionListCssClass="autocomplete" />
                                            <asp:Button ID="SearchJobNumberButton" runat="server" Text="Submit" Style="display: none" OnClick="txtJobNumber_TextChanged" />
                                        </asp:Panel>     
                    </div>
                    <div class="col-sm-4 chosenFullWidth"> 
                        <label class="text-danger">Job Name*</label>      
                         <asp:Panel ID="JobName" runat="server" Style="height: 200px; overflow: scroll;
                            display: none;"></asp:Panel>
                     <asp:Panel ID="PanelJobName" runat="server" DefaultButton="SearchJobNameButton">
                                             <asp:TextBox ID="txtJobName" placeholder="Type Job Name" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" OnBlur="return ClickEvent(event)" onkeypress="return EnterEvent(event)">
                                        </asp:TextBox>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtJobName"
                                            CompletionInterval="1" CompletionSetCount="10" MinimumPrefixLength="1" CompletionListElementID="JobName"
                                            ServicePath="../AutoComplete.asmx" ServiceMethod="SearchCADDYJobName" CompletionListCssClass="autocomplete" />
                           
                         <asp:Button ID="SearchJobNameButton" runat="server" Text="Submit" Style="display: none" OnClick="txtJobName_TextChanged" />
                                        </asp:Panel>                  
                    </div>  
                     <div class="col-sm-3 ">
                        <div class="form-group">
                            <label>Job Type</label>
                            <asp:TextBox ID="txtJobType" CssClass="form-control form-control-sm boldtext" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3 ">
                        <div class="form-group">
                            <label>Models</label>
                            <asp:TextBox ID="txtModels" CssClass="form-control form-control-sm boldtext" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>  
                     <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Project Manager</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtProjManaCaddy"  runat="server" Enabled="false">                                
                            </asp:TextBox>
                        </div>
                    </div>
                     <div class="col-sm-2 ">
                        <div class="form-group">
                          <%--  <label>Save/Update</label>--%>
                            <br />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm mt-2"    Text="Save" OnClick="btnSave_Click"   />                             
                        </div>
                    </div>
                                            

                </div>
            </div>
            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Task Information</h5>                       
                    </div>
                   <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Project Type*</label>
                             <asp:DropDownList ID="ddlProjectType" CssClass="form-control form-control-sm" autocomplete="off" runat="server" 
                                 DataTextField="ProjectTypeName" DataValueField="ProjectTypeID" AutoPostBack="True" 
                                 OnSelectedIndexChanged="ddlProjectType_SelectedIndexChanged">
                                 </asp:DropDownList>
                          <%--  <asp:DropDownList ID="ddlProjectType" CssClass="form-control form-control-sm" autocomplete="off" runat="server" DataTextField="ProjectTypeName" DataValueField="ProjectTypeID">                                
                            </asp:DropDownList>    --%>                        
                        </div>
                    </div> 
                    <div class="col-sm-2" id="DivProjectManager" runat="server" visible="false">
                        <div class="form-group">
                            <label>Project Manager</label>
                             <asp:DropDownList ID="ddlProjectManager" CssClass="form-control form-control-sm" autocomplete="off" runat="server" 
                                 DataTextField="EmployeeName" DataValueField="EmployeeID">
                                 </asp:DropDownList>                                              
                        </div>
                    </div>
                    
                      <div class="col-sm-2"  id="dvItemNo" runat="server" visible="false">
                        <div class="form-group">
                            <label class="text-danger">Item No*</label>
                            <asp:TextBox ID="txtItemNo" CssClass="form-control form-control-sm" autocomplete="off" runat="server" MaxLength="50">                                
                            </asp:TextBox>                            
                        </div>
                         </div>
                          <div class="col-sm-2" id="dvModelType" runat="server" visible="false">
                        <div class="form-group">
                            <label class="text-danger">Model Type*</label>
                            <asp:DropDownList ID="ddlModelType" CssClass="form-control form-control-sm" autocomplete="off" runat="server" DataTextField="Model" DataValueField="ModelId">         
                            </asp:DropDownList>                            
                        </div>
                     </div>                          
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Nature Of Task</label>
                            <asp:DropDownList ID="ddlNatureOfTask" CssClass="form-control form-control-sm" autocomplete="off" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">New</asp:ListItem>                               
                                <asp:ListItem Value="2">Correction</asp:ListItem>
                                <asp:ListItem Value="3">Revision A</asp:ListItem>
                                <asp:ListItem Value="4">Revision B</asp:ListItem>
                                <asp:ListItem Value="5">Revision C</asp:ListItem>
                                <asp:ListItem Value="6">Revision D</asp:ListItem>
                                <asp:ListItem Value="7">Revision E</asp:ListItem>
                                <asp:ListItem Value="8">Revision F</asp:ListItem>
                                <asp:ListItem Value="9">Revision G</asp:ListItem>
                                <asp:ListItem Value="10">Revision H</asp:ListItem>
                                <asp:ListItem Value="11">Revision I</asp:ListItem>
                                <asp:ListItem Value="12">Revision J</asp:ListItem>
                                <asp:ListItem Value="13">Revision K</asp:ListItem>
                                <asp:ListItem Value="14">Revision L</asp:ListItem>
                                <asp:ListItem Value="15">Revision M</asp:ListItem>
                                <asp:ListItem Value="16">Revision N</asp:ListItem>
                                <asp:ListItem Value="17">Revision O</asp:ListItem>
                                <asp:ListItem Value="18">Revision P</asp:ListItem>
                                <asp:ListItem Value="19">Revision Q</asp:ListItem>
                                <asp:ListItem Value="20">Revision R</asp:ListItem>
                                <asp:ListItem Value="21">Revision S</asp:ListItem>
                                <asp:ListItem Value="22">Revision T</asp:ListItem>
                                <asp:ListItem Value="23">Revision U</asp:ListItem>
                                <asp:ListItem Value="24">Revision V</asp:ListItem>
                                <asp:ListItem Value="25">Revision W</asp:ListItem>
                                <asp:ListItem Value="26">Revision X</asp:ListItem>
                                <asp:ListItem Value="27">Revision Y</asp:ListItem>
                                <asp:ListItem Value="28">Revision Z</asp:ListItem>                                
                            </asp:DropDownList>                            
                        </div>
                    </div>
                    <div class="col-sm-2" id="dvCorrection" runat="server" visible="false">
	                    <div class="form-group">
		                    <label>Correction</label>
		                    <asp:TextBox CssClass="form-control form-control-sm" ID="txtCorrection" runat="server"  MaxLength="5" autocomplete="off">
		                    </asp:TextBox>
	                    </div>
                    </div>
                    <div class="col-sm-2 " style="display:none">
                        <div class="form-group srRadiosBtns">
                            <label>Project Accepted</label>
                <asp:RadioButtonList ID="rdbProjectAccepted" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
               </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Project Engineer(Assigned To)</label>
                            <asp:DropDownList ID="ddlAssignedToEng" CssClass="form-control form-control-sm" autocomplete="off" runat="server" DataTextField="EmployeeName" DataValueField="EmployeeID">                               
                            </asp:DropDownList>                            
                        </div>
                    </div>
                  <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Prioriy*</label>
                            <asp:DropDownList ID="ddlPriority" CssClass="form-control form-control-sm" autocomplete="off" runat="server">                               
                                <asp:ListItem Value="1">Regular</asp:ListItem>  
                                <asp:ListItem Value="2">Urgent</asp:ListItem>                             
                            </asp:DropDownList>                            
                        </div>
                    </div>
                      <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Date Req. Forwarded To India</label>
                 <asp:TextBox ID="txtReqForwardToIndia" CssClass="form-control form-control-sm " autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="caltxtReqForwardToIndia" runat="server" 
                                Format="MM/dd/yyyy"
                                PopupButtonID="txtReqForwardToIndia" TargetControlID="txtReqForwardToIndia">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                 <div class="col-sm-2 ">
                        <div class="form-group">
                            <label>Project Due Date</label>
                 <asp:TextBox ID="txtProjectDueDate" CssClass="form-control form-control-sm" autocomplete="off" runat="server" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                Format="MM/dd/yyyy"
                                PopupButtonID="txtProjectDueDate" TargetControlID="txtProjectDueDate">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Date Sent To Caddy</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtProjectSendToCaddy" runat="server" autocomplete="off" OnBlur="validateDate(this)">
                            </asp:TextBox>
                            <asp:CalendarExtender ID="caltxtProjectSendToCaddy" runat="server" Format="MM/dd/yyyy"
                                PopupButtonID="txtProjectSendToCaddy" TargetControlID="txtProjectSendToCaddy">
                            </asp:CalendarExtender>             
                        </div>
                    </div>
                <div class="col-sm-2">
                        <div class="form-group">
                            <label class="text-danger">Status*</label>
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control form-control-sm"  runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">                   
                            </asp:DropDownList>
                        </div>
                    </div>

 <div class="col-sm-2" id="pnlProgress" runat="server" visible="false">
	<div class="form-group">
                <label class="text-danger">Progress*</label>
                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProgress" runat="server">
                <asp:ListItem Value="-1">Select</asp:ListItem>
                <asp:ListItem Value="0">0%</asp:ListItem>
                <asp:ListItem Value="1">10%</asp:ListItem>
                <asp:ListItem Value="2">20%</asp:ListItem>
                <asp:ListItem Value="3">30%</asp:ListItem>
                <asp:ListItem Value="4">40%</asp:ListItem>
                <asp:ListItem Value="5">50%</asp:ListItem>
                <asp:ListItem Value="6">60%</asp:ListItem>
                <asp:ListItem Value="7">70%</asp:ListItem>
                <asp:ListItem Value="8">80%</asp:ListItem>
                <asp:ListItem Value="9">90%</asp:ListItem>
                </asp:DropDownList>
	</div>
</div> 



      <div class="col-sm-4 ">
	<div class="form-group">
		<label>Remarks</label>
		<asp:TextBox CssClass="form-control form-control-sm" ID="txtRemarks" runat="server" TextMode="MultiLine" MaxLength="5" autocomplete="off" onkeypress="return limitMultiLineInputLength(this,500);">
		</asp:TextBox>
	</div>
</div>                    

    
 <div class="col-sm-4">
	<div class="form-group" id="dvProjectManager" runat="server" visible="false">
		<label>Remarks By PM</label>
		<asp:TextBox CssClass="form-control form-control-sm" ID="txtRemarksbyPM" runat="server" TextMode="MultiLine"  autocomplete="off" onkeypress="return limitMultiLineInputLength(this,500);">
		</asp:TextBox>
	</div>
</div>            

</div>

                <div class="row border-top pt-3" id="gvTaskDetails" runat="server" visible="false">
                    <div class="col-sm-12">
                        <h5 class="text-uppercase">Task Details</h5>
                        <div class="table-responsive">
                               <asp:GridView ID="gvCadEngTasks" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                                                ForeColor="Black"  GridLines="Vertical" Width="100%" Style="font-size: small" CssClass="table mainGridTable table-sm" OnRowDeleting="gvCadEngTasks_RowDeleting" DataKeyNames="EngTaskID" OnRowEditing="gvCadEngTasks_RowEditing">
                                   <Columns>
                                        <asp:BoundField HeaderText="Project Type" DataField="ProjectType" />    
                                       <asp:TemplateField HeaderText="Project Manager" Visible="false">
                                            <ItemTemplate>
                     <asp:Label ID="lblProjectManager" runat="server" Text='<%# Eval("ProjectManagerName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>         
                                        <asp:TemplateField HeaderText="Item No" Visible="false">
                                            <ItemTemplate>
                     <asp:Label ID="lblItemNo" runat="server" Text='<%# Eval("ItemNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="Model Type" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblModelType" runat="server" Text='<%# Eval("Model") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                             <asp:BoundField HeaderText="Nature Of Task" DataField="Nature" />           
                        <asp:TemplateField HeaderText="Correction" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCorrection" runat="server" Text='<%# Eval("Correction") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>              
                                       <asp:BoundField HeaderText="Project Eng.(Assigned To)" DataField="AssignedTo" />
                                           <asp:BoundField HeaderText="Priority" DataField="Priority"   />
                                              <asp:BoundField HeaderText="Req Forward To India" DataField="ReqFWDToIndia" DataFormatString="{0:MM/dd/yyyy}"  />
                                          <asp:BoundField HeaderText="Project Due Date" DataField="ProjectDueDate" DataFormatString="{0:MM/dd/yyyy}"  />             
   <asp:BoundField HeaderText="Sent To Caddy" DataField="SentToCaddy" DataFormatString="{0:MM/dd/yyyy}"  />
          <asp:BoundField HeaderText="Status" DataField="Status"   />
                                       <asp:BoundField HeaderText="Progress" DataField="Progress"   />
                          <asp:BoundField HeaderText="Remarks" DataField="Remarks" />
                                       <asp:TemplateField HeaderText="Remarks By PM" Visible="false">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblRemarksByPM" runat="server" Text='<%# Eval("RemarksByPM") %>'></asp:Label>
                                               </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Modify">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CommandName="Edit" CssClass="btn btn-primary btn-sm" Text="Edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                                <asp:LinkButton runat="server" CommandName="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure.?');" Text="Delete" title="Delete">
                                                <i class="far fa-times-circle"></i>
                                            </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   </Columns>
                        </asp:GridView>
                        </div>
                     
                    </div>
                </div>
             
            </div>         
            <asp:HiddenField ID="hfProjectID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfProjectEngID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfCheckProjectManageID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfJobType" runat="server" Value="-1" />
        </ContentTemplate> 
                 <Triggers>            
            <asp:PostBackTrigger ControlID="btnGenerateReport" />            
        </Triggers>
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
            $('#<%=ddlPNumberHeaderList.ClientID%>').chosen();
            $('#<%=ddlNatureOfTask.ClientID%>').chosen();
            $('#<%=ddlAssignedToEng.ClientID%>').chosen();
            $('#<%=ddlProjectType.ClientID%>').chosen();
            $('#<%=ddlStatus.ClientID%>').chosen();
            $('#<%=ddlPriority.ClientID%>').chosen();
            $('#<%=ddlProgress.ClientID%>').chosen();    
            $('#<%=ddlModelType.ClientID%>').chosen(); 
            $('#<%=ddlProjectManager.ClientID%>').chosen(); 
        }
       function EnterEventForPName(e) {                    
                   if (e.keyCode == 13) {
                            __doPostBack('<%=SearchJobNumberButton.UniqueID%>', "");
                            }
                    }
            function ClickEventForPName(e) {
                    __doPostBack('<%=SearchJobNumberButton.UniqueID%>', "");
            }

            function EnterEvent(e) {
                if (e.keyCode == 13) {
                    __doPostBack('<%=SearchJobNameButton.UniqueID%>', "");
                }
            }

            function ClickEvent(e) {
                __doPostBack('<%=SearchJobNameButton.UniqueID%>', "");
            }

        function ValidateDate(sender, args) {            
            var dateString = document.getElementById(sender.controltovalidate).value;
            var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;
            if (regex.test(dateString)) {
                var parts = dateString.split("/");
                var dt = new Date(parts[0] + "/" + parts[1] + "/" + parts[2]);
                args.IsValid = (dt.getMonth() + 1 == parts[1] && dt.getDate() == parts[0] && dt.getFullYear() == parts[2]);
            } else {
                args.IsValid = false;
            }
        }
        function limitMultiLineInputLength(inputElement, maxLength) {
            if (inputElement.value.length >= maxLength) {
                inputElement.value = inputElement.value.slice(0, maxLength);
            }
        }
    </script>
     <CR:CrystalReportViewer ID="rptEngTaskReport" runat="server" AutoDataBind="true" BestFitPage="False" Width="100%" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="None" />
</asp:Content>
