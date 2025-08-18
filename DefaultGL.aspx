<%@ Page Title="" Language="C#" MasterPageFile="~/MainGaylord.master" AutoEventWireup="true" CodeFile="DefaultGL.aspx.cs" Inherits="_DefaultGL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success btn-sm mb-3" Text="Generate Code" OnClick="btnSubmit_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>