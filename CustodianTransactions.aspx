<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="CustodianTransactions.aspx.cs" Inherits="FundingMaktab.CustodianTransactions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of Custodian Transactions</h4>

                                  <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Custodian Name</th>
                                                <th>Purpose</th>
                                                <th>Amount</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                               <th>Custodian Name</th>
                                                <th>Purpose</th>
                                                <th>Amount</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Custodian_Name") %></td>
                                                <td><%#Eval("Purpose_Name") %></td>
                                                <td><%#Eval("Amount") %></td>
                                                
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