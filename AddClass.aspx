<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddClass.aspx.cs" Inherits="FundingMaktab.AddClass" %>

<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Add Class</h4>
                                <form id="form1" class="form" runat="server">
                                    
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Class Name</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox1" CssClass="form-control" type="text" runat="server"></asp:TextBox>
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