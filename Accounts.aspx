<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="Accounts.aspx.cs" Inherits="FundingMaktab.Accounts" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of Accounts</h4>


                                <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Account Name</th>
                                                <th>Initial Amount</th>
                                                <th>Description</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th>Account Name</th>
                                                <th>Initial Amount</th>
                                                <th>Description</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Acc_Name") %></td>
                                                <td><%#Eval("Acc_InitialAmount") %></td>
                                                <td><%#Eval("Acc_Desc") %></td>
                                                
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

