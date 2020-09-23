<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="Students.aspx.cs" Inherits="FundingMaktab.Students" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of All Students</h4>
                               <div class="table-responsive m-t-40">
                                   <table id="example23" class="display nowrap table table-hover table-striped table-bordered" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Student Name</th>
                                                <th>Father Name</th>
                                                <th>Class</th>
                                                <th>Center</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th>Student Name</th>
                                                <th>Father Name</th>
                                                <th>Class</th>
                                                <th>Center</th>
                                            </tr>
                                        </tfoot>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Student_Name") %></td>
                                                <td><%#Eval("Father_Name") %></td>
                                                <td><%#Eval("Class_Name") %></td>
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
