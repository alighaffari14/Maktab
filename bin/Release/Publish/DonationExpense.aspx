<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="DonationExpense.aspx.cs" Inherits="FundingMaktab.DonationExpense" %>

<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Expense</h4>
                                <form id="form1" class="form" runat="server">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Account</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox1" ReadOnly="true" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Purpose</label>
                                        <div class="col-10">
                                            <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="custom-select col-12" runat="server"></asp:DropDownList>
                                            
                                        </div>
                                    </div>
                                     <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Custodian</label>
                                        <div class="col-10">
                                             <asp:DropDownList ID="DropDownList4" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="true"  CssClass="custom-select col-12" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Branch</label>
                                        <div class="col-10">
                                            <asp:DropDownList ID="DropDownList2" AutoPostBack="true" CssClass="custom-select col-12"  runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Custodian In Hand Amount</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox4" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Purpose Total Amount</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox3" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                   <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Date</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox2" CssClass="form-control" type="date" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Expense Amount</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox5" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                
                                    <div class="form-group">
                                        
                                        <asp:Button ID="Button1"  CssClass="btn btn-success mr-2" OnClick="Button2_Click" runat="server" Text="Save" />
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
