<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="Muallims.aspx.cs" Inherits="FundingMaktab.Muallims" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of Muallimeen</h4>

                                <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Muallim Name</th>
                                                <th>Father Name</th>
                                                <th>World Education</th>
                                                <th>Islamic Education</th>
                                                <th>Contact Number</th>
                                                <th>Education from Madrisah</th>
                                                <th>Center Name</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th>Muallim Name</th>
                                                <th>Father Name</th>
                                                <th>World Education</th>
                                                <th>Islamic Education</th>
                                                <th>Contact Number</th>
                                                <th>Education from Madrisah</th>
                                                <th>Center Name</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                               <td><%#Eval("Name") %></td>
                                                <td><%#Eval("Father_Name") %></td>
                                                <td><%#Eval("Deeni_Taleem") %></td>
                                                <td><%#Eval("Dunyawi_Taleem") %></td>
                                                <td><%#Eval("Contact_Number") %></td>
                                                <td><%#Eval("Madrisah_Education_Name") %></td>
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

