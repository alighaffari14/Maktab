<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="GetFailedStudents.aspx.cs" Inherits="FundingMaktab.GetFailedStudents" %>

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
                                                <th>Total Marks</th>
                                                <th>Obtained Marks</th>
                                                <th>Exam Date</th>
                                                <th>Status</th>

                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                               <th>Student Name</th>
                                                <th>Father Name</th>
                                                <th>Class</th>
                                                <th>Center</th>
                                                <th>Total Marks</th>
                                                <th>Obtained Marks</th>
                                                <th>Exam Date</th>
                                                <th>Status</th>
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
                                                <td><%#Eval("TotalMarks") %></td>
                                                <td><%#Eval("ObtainedMarks") %></td>
                                                <td><%#Eval("Exam_Date") %></td>
                                                <td><%#Eval("Status") %></td>
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

      <script src="assets/node_modules/jquery/jquery-3.2.1.min.js"></script>

    <!-- Bootstrap tether Core JavaScript -->
    <script src="assets/node_modules/popper/popper.min.js"></script>
    <script src="assets/node_modules/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- slimscrollbar scrollbar JavaScript -->
    <script src="dist/js/perfect-scrollbar.jquery.min.js"></script>
    <!--Wave Effects -->
    <script src="dist/js/waves.js"></script>
    <!--Menu sidebar -->
    <script src="dist/js/sidebarmenu.js"></script>
    <!--stickey kit -->
    <script src="assets/node_modules/sticky-kit-master/dist/sticky-kit.min.js"></script>
    <script src="assets/node_modules/sparkline/jquery.sparkline.min.js"></script>
    <!--Custom JavaScript -->
    <script src="dist/js/custom.min.js"></script>
  


</asp:Content>
