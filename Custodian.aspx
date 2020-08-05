<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="Custodian.aspx.cs" Inherits="FundingMaktab.Custodian" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of Custodians</h4>

                                <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Custodian Name</th>
                                                <th>CNIC</th>
                                                <th>Contact</th>
                                                <th>Address</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th>Custodian Name</th>
                                                <th>CNIC</th>
                                                <th>Contact</th>
                                                <th>Address</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Custodian_Name") %></td>
                                                <td><%#Eval("Custodian_Nic") %></td>
                                                <td><%#Eval("Custodian_Contact") %></td>
                                                <td><%#Eval("Custodian_Address") %></td>
                                                
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
