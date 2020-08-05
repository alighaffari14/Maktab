<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AccountTypes.aspx.cs" Inherits="FundingMaktab.AccountTypes" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of Accounts Type</h4>

                                   <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Account Type Name</th>
                                                <th>Description</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th>Account Name</th>
                                                <th>Description</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Acc_Type_Name") %></td>
                                                <td><%#Eval("Acc_Type_Description") %></td>
                                                
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