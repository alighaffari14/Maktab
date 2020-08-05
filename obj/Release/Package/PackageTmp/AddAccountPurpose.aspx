<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddAccountPurpose.aspx.cs" Inherits="FundingMaktab.AddAccountPurpose" %>


<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Add Account's Purpose</h4>
                                <form id="form1" class="mt-4" runat="server">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                    <div class="form-group row">
                                        <label for="example-text-input" class="control-label">Purpose Name</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="textBox1" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Account Name</label>
                                        <div class="col-lg-12">
                                            <asp:DropDownList ID="DropDownList1" CssClass="custom-select col-12" runat="server"></asp:DropDownList>
                                            <%--<select class="custom-select col-12" id="example-month-input2">
                                                <option selected="">Choose...</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </select>--%>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        
                                        <asp:Button ID="Button1"  CssClass="btn btn-success mr-2"  OnClick="Button1_Click" runat="server" Text="Save" />
                                        <asp:Button ID="Button2" CssClass="btn btn-dark" runat="server" Text="Cancel" />
                                    </div>
                                                    </ContentTemplate>
                                         </asp:UpdatePanel>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

</asp:Content>