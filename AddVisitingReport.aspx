<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddVisitingReport.aspx.cs" Inherits="FundingMaktab.AddVisitingReport" %>

<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">
<%--     <script src="https://code.jquery.com/jquery-1.11.0.min.js"></script>
  <script lang="JavaScript" type="text/javascript" src="dist/js/sidebarmenu.js"></script>--%>
 
    <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Monthly Progress Report of Maktab</h4>
                                <form id="form1" class="mt-4" runat="server">
                                     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                    <div class="form-group row">
                                        <label for="DropDownList3" class="control-label">Select Center</label>
                                        <div class="col-10">
                                            
                                            <asp:DropDownList ID="DropDownList3" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true" CssClass="custom-select col-12" runat="server"></asp:DropDownList>
                                       
                                                </div>
                                    </div>
                                     <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Registeration Number</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox14" ReadOnly="true" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                         <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Visiting Date</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox15"  CssClass="form-control" type="date" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Village/Mohalla</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox1" ReadOnly="true" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Tehsil & District</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox2" ReadOnly="true" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Muallim/Muallima</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox3" ReadOnly="true" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Total VIP</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox4" ReadOnly="true" CssClass="form-control col-6" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Total Atfaal</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox5" ReadOnly="true" CssClass="form-control col-6" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Total Awwal</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox6" ReadOnly="true" CssClass="form-control col-6" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Total No.Of Students</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox7" ReadOnly="true" CssClass="form-control col-6" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                                     <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Shariya</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox16" CssClass="form-control col-6" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <hr />
                                    <h4 class="card-title" style="text-align:center; background-color:burlywood">Marking Section</h4>
                                    <hr />
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Disciplane</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox8" CssClass="form-control col-4" type="text" runat="server"></asp:TextBox><p class="text-left">Out of <b>15</b></p>
                                        </div>
                                    </div>
                                   <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Cleaning</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox9" CssClass="form-control col-4" type="text" runat="server"></asp:TextBox><p class="text-left">Out of <b>15</b></p>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Books Exam</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox10" CssClass="form-control col-4" type="text" runat="server"></asp:TextBox><p class="text-left">Out of <b>25</b></p>
                                        </div>
                                    </div>
                                     <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Oral Exam</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox11" CssClass="form-control col-4" type="text" runat="server"></asp:TextBox><p class="text-left">Out of <b>20</b></p>
                                        </div>
                                    </div>
                                     <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Copies</label>
                                        <div class="col-10">
                            
                                            <asp:TextBox ID="textBox12" AutoPostBack="true" OnTextChanged="textBox12_TextChanged" CssClass="form-control col-4" type="text" runat="server"></asp:TextBox><p class="text-left">Out of <b>25</b></p>

                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Total Marks</label>
                                        <div class="col-10">
                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group mt-5 row">
                                        <label for="example-text-input" class="control-label">Remarks</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="textBox13" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <hr />
                                     <h6 class="card-title" style="text-align:center; background-color:burlywood">Students taking the monthly exam</h6>
                                    <hr />


                                    <h6 class="card-subtitle"><b>Atfaal</b></h6>
                                    <div class="table-responsive">
                                    <table class="table table-bordered table-striped ">
                                        <thead>
                                            <tr>
                                                <th>Months</th>
                                                <th class="text-center"> 1st </th>
                                                <th class="text-center"> 2nd </th>
                                                <th class="text-center"> 3rd </th>
                                                <th class="text-center"> 4th </th>
                                                <th class="text-center"> 5th </th>
                                                <th class="text-center"> 6th </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                          
                                            <tr>
                                                
                                                <th class="text-nowrap" scope="row">Total Numbers</th>
                                                <td><asp:LinkButton ID="LinkButton1" OnClick="exam1Pageopening_click" runat="server"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton2" OnClick="exam2Pageopening_click" runat="server"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton3" OnClick="exam3Pageopening_click" runat="server"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton4" OnClick="exam4Pageopening_click" runat="server"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton5" OnClick="exam5Pageopening_click" runat="server"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton6" OnClick="exam6Pageopening_click" runat="server"><asp:Label ID="Label7" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                            </tr>
                                           
                                        </tbody>
                                    </table>
                                </div>


                                     <h6 class="card-subtitle"><b>Awwal</b></h6>
                                    <div class="table-responsive">
                                    <table class="table table-bordered table-striped ">
                                        <thead>
                                            <tr>
                                                <th>Months</th>
                                                <th class="text-center"> 1st </th>
                                                <th class="text-center"> 2nd </th>
                                                <th class="text-center"> 3rd </th>
                                                <th class="text-center"> 4th </th>
                                                <th class="text-center"> 5th </th>
                                                <th class="text-center"> 6th </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                          
                                            <tr>
                                                
                                                <th class="text-nowrap" scope="row">Total Numbers</th>
                                                <td><asp:LinkButton ID="LinkButton7" OnClick="Awwalexam1Pageopening_click" runat="server"><asp:Label ID="Label8" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton8" OnClick="Awwalexam2Pageopening_click" runat="server"><asp:Label ID="Label9" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton9" OnClick="Awwalexam3Pageopening_click" runat="server"><asp:Label ID="Label10" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton10" OnClick="Awwalexam4Pageopening_click" runat="server"><asp:Label ID="Label11" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton11" OnClick="Awwalexam5Pageopening_click" runat="server"><asp:Label ID="Label12" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="LinkButton12" OnClick="Awwalexam6Pageopening_click" runat="server"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></asp:LinkButton></td>
                                            </tr>
                                           
                                        </tbody>
                                    </table>
                                </div>


                                  <%--  <div class="form-group row">
                                        <label for="example-search-input" class="control-label">Search</label>
                                        <div class="col-10">
                                            <input class="form-control" type="search" value="How do I shoot web" id="example-search-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-email-input" class="control-label">Email</label>
                                        <div class="col-10">
                                            <input class="form-control" type="email" value="bootstrap@example.com" id="example-email-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-url-input" class="control-label">URL</label>
                                        <div class="col-10">
                                            <input class="form-control" type="url" value="https://getbootstrap.com" id="example-url-input">
                                        </div>
                                    </div>--%>
                                   <%-- <div class="form-group row">
                                        <label for="example-tel-input" class="control-label">Telephone</label>
                                        <div class="col-10">
                                            <input class="form-control" type="tel" value="1-(555)-555-5555" id="example-tel-input">
                                        </div>
                                    </div>--%>
                                   <%-- <div class="form-group row">
                                        <label for="example-password-input" class="control-label">Password</label>
                                        <div class="col-10">
                                            <input class="form-control" type="password" value="hunter2" id="example-password-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-number-input" class="control-label">Number</label>
                                        <div class="col-10">
                                            <input class="form-control" type="number" value="42" id="example-number-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-datetime-local-input" class="control-label">Date and time</label>
                                        <div class="col-10">
                                            <input class="form-control" type="datetime-local" value="2011-08-19T13:45:00" id="example-datetime-local-input">
                                        </div>
                                    </div>--%>
                                   <%-- <div class="form-group row">
                                        <label for="example-date-input" class="control-label">Date</label>
                                        <div class="col-10">
                                            <input class="form-control" type="date" value="2011-08-19" id="example-date-input">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="example-month-input" class="control-label">Month</label>
                                        <div class="col-10">
                                            <input class="form-control" type="month" value="2011-08" id="example-month-input">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="example-week-input" class="control-label">Week</label>
                                        <div class="col-10">
                                            <input class="form-control" type="week" value="2011-W33" id="example-week-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-time-input" class="control-label">Time</label>
                                        <div class="col-10">
                                            <input class="form-control" type="time" value="13:45:00" id="example-time-input">
                                        </div>
                                    </div>--%>
                                   <%-- <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Select</label>
                                        <div class="col-10">
                                            <select class="custom-select col-12" id="example-month-input2">
                                                <option selected="">Choose...</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </select>
                                        </div>
                                    </div>--%>
                                  
                                    <div class="form-group">
                                        
                                        <asp:Button ID="Button1"  CssClass="btn btn-success mr-2"  OnClick="Button1_Click" runat="server" Text="Save" />
                                        <asp:Button ID="Button2" CssClass="btn btn-dark" runat="server" Text="Cancel" />
                                    </div>
                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

   
</asp:Content>