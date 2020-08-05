<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddCustodian.aspx.cs" Inherits="FundingMaktab.AddCustodian" %>


<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Add Custodian</h4>
                                <form id="form1" class="mt-4" runat="server">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                    <div class="form-group row">
                                        <label for="example-text-input" class="control-label">Custodian Name</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="textBox1" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group row">
                                        <label for="example-text-input" class="control-label">CNIC</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="textBox2" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group row">
                                        <label for="example-text-input" class="control-label">Contact</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="textBox3" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group row">
                                        <label for="example-text-input" class="control-label">Address</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="textBox4" CssClass="form-control" type="text" runat="server"></asp:TextBox>
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