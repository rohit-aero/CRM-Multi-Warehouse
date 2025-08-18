<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="FrmPartsInfoOLD.aspx.cs" Inherits="INVManagement_FrmPartsInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-12 pt-2 piDiv position-sticky">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex align-items-center mb-2">
                            <button type="button" class="btn btn-info btn-sm mr-3" onclick="previousPage()"><i class="fas fa-chevron-left fa-sm"></i>Back</button>
                            <h4 class="title-hyphen position-relative">Parts Information</h4>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6 mb-3">
                        <div class="row">
                            <label class="col-auto mb-0">Job ID</label>
                            <div class="col chosenFullWidth">
                                <asp:DropDownList CssClass="form-control" ID="ddlJobID" runat="server" DataValueField="JobID" DataTextField="ProjectName" AutoPostBack="True" OnSelectedIndexChanged="ddlJobID_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm col-md col-lg col-xl-auto">
                        <div class="row">
                            <div class="col-auto">
                                <asp:Button ID="btnDownloader" runat="server" CssClass="btn btn-primary btn-sm" Visible="false" CausesValidation="false" OnClick="btnDownloader_Click" />
                                <asp:Button ID="btnDownloadPdf" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false" Text="DownloadPdf" OnClientClick="downloadFiles()" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <div class="col-12 pt-2">
                    <div class="row d-flex justify-content-center">
                        <div class="col-md-11 mx-auto">
                            <div class="row">
                                <div class="col-12">
                                    <h5 class="text-uppercase">Part Description</h5>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <label class="col-auto">Product</label>
                                        <div class="col chosenFullWidth">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlProduct" runat="server" DataTextField="Product" DataValueField="Productid" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md">
                                    <div class="row">
                                        <label class="col-sm-auto">Part Description</label>
                                        <div class="col chosenFullWidth">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlPartsDetail" DataTextField="PartDetails" DataValueField="Partid" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="row">
                                        <label class="col-sm-auto">Quantity</label>
                                        <div class="col">
                                            <asp:TextBox CssClass="form-control form-control-sm text-right" ID="txtQty" AutoComplete="off" MaxLength="6" runat="server" placeholder="In Feet" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2" style="display: none">
                                    <div class="row">
                                        <label class="col-sm-auto">File Name List</label>
                                        <div class="col">
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddlFileName" runat="server"></asp:DropDownList>
                                            <asp:HiddenField ID="hdFileName" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-auto">
                                    <asp:Button CssClass="btn btn-success btn-sm" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12 pt-3">
                    <div class="table-responsive">
                        <asp:GridView CssClass="table mainGridTable table-sm" ID="gvDetail" runat="server" AutoGenerateColumns="False" EmptyDataText="No Parts has been Added"
                            EnableModelValidation="True" DataKeyNames="Partinfoid" OnRowDeleting="gvDetail_RowDeleting" OnRowCancelingEdit="gvDetail_RowCancelingEdit" OnRowEditing="gvDetail_RowEditing" OnRowUpdating="gvDetail_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="Part Description" HeaderStyle-Width="70%">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEditPartDes" runat="server" Text='<%#Eval("PartNumber") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPartDes" runat="server" Text='<%#Eval("PartNumber") %>'></asp:Label>
                                        <asp:Label ID="lblPartId" runat="server" Visible="false" Text='<%#Eval("PartId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="15%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("qty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Modify" HeaderStyle-Width="15%">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" CssClass="btn btn-success btn-sm" runat="server" CommandName="Update"><i class="far fa-save" title="Update"></i></asp:LinkButton>
                                        &nbsp;<asp:LinkButton CssClass="btn btn-danger btn-sm" ID="lnkCancel" runat="server" CommandName="cancel"><i class="fas fa-redo" title="Redo"></i></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        &nbsp;<asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-info btn-sm" CommandName="edit"><i class="far fa-edit" title="Edit"></i></asp:LinkButton>
                                        &nbsp;
				                    <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure to delete. ?');" runat="server" CommandName="Delete"><i class="fas fa-times" title="Delete"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
            <script type="text/javascript">
                $(document).ready(function () {
                    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
                });
                function PageLoaded(sender, args) {
                    DDLName();
                }
                $.when.apply($, PageLoaded).then(function () {
                    DDLName();
                });
                function DDLName() {
                    $('#<%=ddlJobID.ClientID%>').chosen();
                    $('#<%=ddlProduct.ClientID%>').chosen();
                    $('#<%=ddlPartsDetail.ClientID%>').chosen();
                }

                function downloadFiles() {
                    var fileNames = document.getElementById('<%=ddlFileName.ClientID%>');

                    for (let i = 0; i < fileNames.length; i++) {
                        document.getElementById("<%=hdFileName.ClientID%>").value = fileNames.options[i].innerHTML;
                        window.open("FrmPartsInfo.aspx?fileName=" + fileNames.options[i].innerHTML);
                    }
                }
            </script>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="btnDownloadPdf" />--%>
            <asp:PostBackTrigger ControlID="btnDownloader" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
