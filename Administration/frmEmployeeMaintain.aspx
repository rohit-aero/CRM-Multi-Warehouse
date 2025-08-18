<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmEmployeeMaintain.aspx.cs" Inherits="Administration_frmEmployeeMaintain" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Employee Information</h4>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-7 col-md-8 col-lg-5 col-xl-5">
                        <div class="row">
                            <div class="col-sm-3 col-md-auto mb-3">
                                <label class="mb-0">Lookup Employee</label>
                            </div>
                            <div class="col-sm-6 col-md mb-3 chosenFullWidth">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlLookupEmployee" runat="server" DataTextField="Employee" DataValueField="EmployeeID" OnSelectedIndexChanged="ddlLookupEmployee_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm col-md col-lg col-xl-auto">
                            <div class="row">
                                <div class="col-auto">
                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 border-top">
                <div class="row pt-3">
                    <div class="col-12">
                        <h5 class="text-uppercase">Employee Details</h5>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label class="text-danger">First Name*</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtFirstName" runat="server" MaxLength="30" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Last Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtLastName" runat="server" MaxLength="30" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Branch</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtBranch" runat="server" MaxLength="1" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>User Name</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtUserName" runat="server" MaxLength="10" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPasssword" runat="server" MaxLength="10" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAddress" runat="server" MaxLength="50" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Date of Birth</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtDOB" runat="server" autocomplete="off" OnBlur="validateDate(this)"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDOB" TargetControlID="txtDOB"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlCountry" runat="server" DataTextField="Country" DataValueField="CountryID" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>State</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlState" runat="server" DataTextField="state" DataValueField="StateID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtCity" runat="server" MaxLength="30" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Postal Code</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtPostalCode" runat="server" MaxLength="10" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Department</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDepartment" runat="server">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem Value="AC">Accounts</asp:ListItem>
                                <asp:ListItem Value="CC">Customer Care</asp:ListItem>
                                <asp:ListItem Value="CD">CD</asp:ListItem>
                                <%--  <asp:ListItem Value="E">Eng</asp:ListItem>--%>
                                <asp:ListItem Value="EC">Eng. Canada</asp:ListItem>
                                <asp:ListItem Value="EI">Eng. India</asp:ListItem>
                                <asp:ListItem Value="IT">IT</asp:ListItem>
                                <%--<asp:ListItem Value="M">Machenical</asp:ListItem>--%>
                                <asp:ListItem Value="O">Office</asp:ListItem>
                                <asp:ListItem Value="QT">Quotes</asp:ListItem>
                                <%--<asp:ListItem Value="S">S</asp:ListItem>--%>
                                <asp:ListItem Value="SD">Sales</asp:ListItem>
                                <asp:ListItem Value="TC">Technician</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Eng Department</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlEngDepartment" runat="server" DataTextField="name" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Division</label>
                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlDivision" runat="server" DataTextField="name" DataValueField="id">
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-2">
                        <div class="form-group">
                            <label>Home Phone</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtHomePhone" runat="server" MaxLength="15" autocomplete="off" onblur="phoneMask(this)">               
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label class="input-group-prepend pr-3">Active</label>
                            <asp:CheckBox ID="chkEmpStatus" runat="server"></asp:CheckBox>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtEmail" runat="server" MaxLength="50" autocomplete="off" oninput="emailMask(this)">                 
                            </asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2">
                        <div class="form-group">
                            <label>Abbrivation</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtAbbrivation" runat="server" MaxLength="100" autocomplete="off">                 
                            </asp:TextBox>
                        </div>
                    </div>

                    <div class="col-2 checkbox-inline" style="display:none">
                        <%--<div class="form-group mb-0">
                            <div class="input-group input-group-sm">
                                <div class="input-group-prepend pr-3 ">Permissions&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</div>
                                <asp:CheckBox ID="chkFull" runat="server" CssClass="custom-checkbox-align checkbox-inline" Text="Full"></asp:CheckBox>
                                &emsp;              
                                <asp:CheckBox ID="chkHalf" runat="server" CssClass="custom-checkbox-align checkbox-inline" Text="Half"></asp:CheckBox>
                                <asp:CheckBox ID="chkViewandMinimum" runat="server" CssClass="custom-checkbox-align checkbox-inline" Text="View & Minimum"></asp:CheckBox>
                                <asp:CheckBox ID="chkRestrict" runat="server" CssClass="custom-checkbox-align checkbox-inline" Text="Restrict"></asp:CheckBox>&emsp;  
                            <asp:CheckBox ID="chkViewOnly" runat="server" CssClass="custom-checkbox-align checkbox-inline" Text="View Only"></asp:CheckBox>
                            </div>
                        </div>--%>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Notes</label>
                            <asp:TextBox CssClass="form-control form-control-sm" ID="txtNotes" runat="server" TextMode="MultiLine" oninput="return limitMultiLineInputLength(this, 250)" autocomplete="off">                 
                            </asp:TextBox>
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
            $('#<%=ddlCountry.ClientID%>').chosen();
            $('#<%=ddlState.ClientID%>').chosen();
            $('#<%=ddlLookupEmployee.ClientID%>').chosen();
            $('#<%=ddlDepartment.ClientID%>').chosen();
            $('#<%=ddlDivision.ClientID%>').chosen();
            $('#<%=ddlEngDepartment.ClientID%>').chosen();           
        }

    </script>
</asp:Content>

