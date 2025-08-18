<%@ Page Title="" Language="C#" MasterPageFile="~/Settings.master" CodeFile="logout.aspx.cs" Inherits="logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="spinner">
                <div class="center-div">
                    <div class="inner-div">
                        <div class="loader"></div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
