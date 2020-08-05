<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddAccountPurpose.aspx.cs" Inherits="FundingMaktab.AddAccountPurpose" %>

<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Add Account's Purpose</h4>
                                <form id="form1" class="form" runat="server">
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="col-2 col-form-label">Purpose Name</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox1" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                <div class="form-group row">
                                        <label for="example-month-input2" class="col-2 col-form-label">Account Name</label>
                                        <div class="col-10">
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
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

</asp:Content>