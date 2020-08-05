<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddDonor.aspx.cs" Inherits="FundingMaktab.AddDonor" %>


<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Add Donor</h4>
                                <form id="form1" class="mt-4" runat="server">
                                    <div class="form-group row">
                                        <label for="example-text-input" class="control-label">Name</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="txtName" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group row">
                                        <label for="txtCity" class="control-label">City</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="txtCity" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group row">
                                        <label for="example-text-input" class="control-label">Country</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="txtCountry" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        
                                        <asp:Button ID="Button1"  CssClass="btn btn-success mr-2" AutoPostback = true  OnClick="Button1_Click" runat="server" Text="Save" />
                                        <asp:Button ID="Button2" CssClass="btn btn-dark" runat="server" Text="Cancel" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

</asp:Content>
