<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddAccountAssignTypes.aspx.cs" Inherits="FundingMaktab.AddAccountAssignTypes" %>

<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Assign Account with their Types</h4>
                                <form id="form1" class="form" runat="server">
                                   
                                
                                    <div class="form-group row">
                                        <label for="example-month-input2" class="col-2 col-form-label">Account</label>
                                        <div class="col-10">
                                            <asp:DropDownList ID="DropDownList1" CssClass="custom-select col-12" AutoPostBack="false" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="example-month-input2" class="col-2 col-form-label">Type</label>
                                        <div class="col-10">
                                            <asp:DropDownList ID="DropDownList2" CssClass="custom-select col-12" AutoPostBack="false" runat="server"></asp:DropDownList>
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