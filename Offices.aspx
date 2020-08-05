<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="Offices.aspx.cs" Inherits="FundingMaktab.Offices" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of All Centers</h4>

                                <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                 <th>REG.No</th>
                                                <th>Center Name</th>
                                                <th>Village/Mohalla</th>
                                                <th>Tehsil & District</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                 <th>REG.No</th>
                                                <th>Center Name</th>
                                                <th>Village/Mohalla</th>
                                                <th>Tehsil & District</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Registeration_Number") %></td>
                                                <td><%#Eval("Office_Name") %></td>
                                                <td><%#Eval("Village_Mohalla") %></td>
                                                <td><%#Eval("Tehsil_District") %></td>
                                                
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