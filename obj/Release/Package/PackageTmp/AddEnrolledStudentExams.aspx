<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddEnrolledStudentExams.aspx.cs" Inherits="FundingMaktab.AddEnrolledStudentExams" %>


<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Student's Exam Marking Monthly</h4>
                                <form id="form1" class="form" runat="server">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                    <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Select Center</label>
                                        <div class="col-10">
                                            <asp:DropDownList ID="DropDownList3" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" CssClass="custom-select col-12" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Select Class</label>
                                        <div class="col-10">
                                            <asp:DropDownList ID="DropDownList4" AutoPostBack=True OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" CssClass="custom-select col-12" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Exam Semester</label>
                                        <div class="col-10">
                                            <asp:DropDownList ID="DropDownList2" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="custom-select col-12" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                         <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Exam Date</label>
                                        <div class="col-4">
                                            <asp:TextBox ID="TextBox2" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                        <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Total Marks</label>
                                        <div class="col-4">
                                            <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                  <%--   <asp:Button ID="Button3"  CssClass="btn btn-success mr-2"  OnClick="Button1_Click" runat="server" Text="Get Students" />--%>
                                     <hr />
                                    <h4 class="rpanel-title" style="text-align:center">Student's Exams Marking</h4>
                                    <hr />
                                   <br />
                                     
    <div id="basicgrid" class="jsgrid" style="position: relative; height: 400px; width: 100%;">
        <div class="jsgrid-grid-header jsgrid-header-scrollbar">
      <asp:gridview ID="Gridview1" CssClass="jsgrid-table table table-striped table-hover" runat="server" ShowFooter="true" 
            AutoGenerateColumns="false">
            <Columns>
            <asp:BoundField DataField="Student_Id" HeaderStyle-CssClass="jsgrid-header-cell jsgrid-header-sortable" HeaderText="Student ID" />
                <asp:BoundField DataField="Student_Name" HeaderText="Student Name" />
            <asp:TemplateField HeaderText="Obtained Marks">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Obtained Marks" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
        </div>
        </div>
        <asp:Button ID="Button1" CssClass="btn btn-success mr-2"  runat="server" Text="Save" onclick="Button1_Click" />
    </div>
                                 
                                                    </ContentTemplate>
                                         </asp:UpdatePanel>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

</asp:Content>