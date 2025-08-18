<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="frmModel.aspx.cs" Inherits="ContactManagement_frmModel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
        <%--<asp:HiddenField ID="hfCusId" runat="server" Value="-1" />--%>
       <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <h4 class="title-hyphen position-relative">Model Main Child</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7 col-md-7 col-lg-6">
                        <div class="row">
                            <div class="col-sm-auto mb-3">
                                <label class="mb-0">Model</label>
                            </div>
                            <div class="col-sm mb-3">
                                <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlTest" runat="server" DataTextField="Category" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged "></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
       <div class="col-12">
<div class="row pt-3">
        <div class="col-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
        <div class="col-12"><h5 class="text-uppercase">Model Information</h5></div>
        <div class="col-sm-6 col-md-3">
<div class="form-group">
<asp:CheckBoxList ID="chkChild" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
    <div class="col-sm-6 col-md-3">
<div class="form-group">
<label id="lblText"></label>                    
</div>
</div>
</div>
</div>
       <div class="col-12">
<div class="row pt-3">
<div class="col-12"><asp:Label ID="Label1" runat="server"></asp:Label></div>
<div class="col-12"><h5 class="text-uppercase">Model Information Type 2</h5></div>
<div class="col-sm-6 col-md-1">
<div class="form-group">
    <b><label>SDT</label></b>
<asp:CheckBoxList ID="chk1" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
   <div class="col-sm-6 col-md-1">
<div class="form-group">
     <b><label>CDT</label></b>
<asp:CheckBoxList ID="chk2" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
   <div class="col-sm-6 col-md-1">
<div class="form-group">
     <b><label>Sink</label></b>
<asp:CheckBoxList ID="chk3" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
  <div class="col-sm-6 col-md-1">
<div class="form-group">
     <b><label>RET</label></b>
<asp:CheckBoxList ID="chk4" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
    <div class="col-sm-6 col-md-1">
<div class="form-group">
     <b><label>Conveyor</label></b>
<asp:CheckBoxList ID="chk5" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
    <div class="col-sm-6 col-md-1">
<div class="form-group">
     <b><label>Tray Make Up</label></b>
<asp:CheckBoxList ID="chk6" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
    <div class="col-sm-6 col-md-2">
<div class="form-group">
     <b><label>Tite Turn Unit</label></b>
<asp:CheckBoxList ID="chk7" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
    <div class="col-sm-6 col-md-2">
<div class="form-group">
     <b><label>Tite Turn Unit</label></b>
<asp:CheckBoxList ID="chk8" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
    <div class="col-sm-6 col-md-1">
<div class="form-group">
     <b><label>Miselleneous</label></b>
<asp:CheckBoxList ID="chk9" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>
</div>
</div>
    <div class="col-sm-6 col-md-1">
<div class="form-group">
<b><label>Show Conveyor</label></b> 
    <asp:CheckBoxList ID="chk10" runat="server" JSvalue="id" DataTextField="name" DataValueField="id" onchange="GetValue();"></asp:CheckBoxList>                
</div>
</div>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
    <script type="text/javascript">        
        function GetValue() {                                                                                             
            var chkBox = document.getElementById('<%= chkChild.ClientID %>');
            var options = chkBox.getElementsByTagName('input');
            var listOfSpans = chkBox.getElementsByTagName('span');
            var checkBoxSelectedItems1 = new Array();
            var checkBoxSelectedText= new Array();
            for (var i = 0; i < options.length; i++)
            {
                if(options[i].checked)
                {
                    checkBoxSelectedItems1.push(listOfSpans[i].attributes["JSvalue"].value);
                    checkBoxSelectedText.push(listOfSpans[i].attributes["JSText"].value);
                }
            }
            //alert(checkBoxSelectedItems1);
            document.getElementById('lblText').innerHTML = checkBoxSelectedText;
    }
    </script>
</asp:Content>