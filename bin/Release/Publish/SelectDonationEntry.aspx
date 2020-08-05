<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="SelectDonationEntry.aspx.cs" Inherits="FundingMaktab.SelectDonationEntry" %>

<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Select Account and Their Type</h4>
                                <form id="form1" class="mt-4" runat="server">
                                   
                                
                                    <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Account</label>
                                        <div class="col-lg-12">
                                            <asp:DropDownList ID="DropDownList1" CssClass="custom-select col-6" AutoPostBack="false" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Type</label>
                                        <div class="col-lg-12">
                                            <asp:DropDownList ID="DropDownList2" CssClass="custom-select col-6" AutoPostBack="false" runat="server"></asp:DropDownList>
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