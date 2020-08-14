<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="MuallimProgress.aspx.cs" Inherits="FundingMaktab.MuallimProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of All Centers</h4>

                                <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Muallim Name</th>
                                                <th>Center Name</th>
                                                <th>Shariya</th>
                                                <th>Visting Date</th>
                                                <th>Total Obtained Marks</th>
                                                <th>Remarks</th>

                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th>Muallim Name</th>
                                                <th>Center Name</th>
                                                <th>Shariya</th>
                                                <th>Visting Date</th>
                                                <th>Total Obtained Marks</th>
                                                <th>Remarks</th>

                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Name") %></td>
                                                <td><%#Eval("Office_Name") %></td>
                                                <td><%#Eval("Shariya") %></td>
                                                <td><%#Eval("Visiting_Date") %></td>
                                                <td><%#Eval("Total_Obtained_Marks") %></td>
                                                <td><%#Eval("Remarks") %></td>
                                                
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
