<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="Transactions.aspx.cs" Inherits="FundingMaktab.Transactions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of All Transactions</h4>

                                <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                 <th>CREDIT</th>
                                                <th>DEBIT</th>
                                                <th>Transaction Date</th>
                                                <th>Purpose</th>
                                                <th>Account</th>
                                                <th>Donor</th>
                                                <th>Custodian</th>
                                                <th>Branch</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                 <th>CREDIT</th>
                                                <th>DEBIT</th>
                                                <th>Transaction Date</th>
                                                <th>Purpose</th>
                                                <th>Account</th>
                                                <th>Donor</th>
                                                <th>Custodian</th>
                                                <th>Branch</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                                 <td><%#Eval("Transaction_Amount_Credit") %></td>
                                                <td><%#Eval("Transaction_Amount_Debit") %></td>
                                                <td><%#Eval("Transaction_Date") %></td>
                                                <td><%#Eval("Transaction_Purpose") %></td>
                                                <td><%#Eval("Acc_Name") %></td>
                                                <td><%#Eval("Donar_Name") %></td>
                                                <td><%#Eval("Custodian_Name") %></td>
                                                <td><%#Eval("Office_Name") %></td>
                                                
                                            </tr>
                                                    </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>

                                    </div>

                            </div>
                        </div>
                    </div>
    </div>
</asp:Content>