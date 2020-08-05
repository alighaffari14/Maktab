<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddMuallim.aspx.cs" Inherits="FundingMaktab.AddMuallim" %>


<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Add Muallim</h4>
                                <form id="form1" class="form" runat="server">
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Name</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox1" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Father Name</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox2" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Deeni Taleem</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox3" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Dunyawi Taleem</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox4" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Contact Number</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox5" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Madrisah of Muallim Education</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox6" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                 <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Select Center</label>
                                        <div class="col-10">
                                            <asp:DropDownList ID="DropDownList3" CssClass="custom-select col-12" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        
                                        <asp:Button ID="Button1"  CssClass="btn btn-success mr-2"  OnClick="Button1_Click" runat="server" Text="Save" />
                                        <asp:Button ID="Button2" CssClass="btn btn-dark" runat="server" Text="Cancel" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

</asp:Content>