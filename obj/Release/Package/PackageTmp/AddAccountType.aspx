<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AddAccountType.aspx.cs" Inherits="FundingMaktab.AddAccountType" %>


<asp:Content ID="bodycontent" ContentPlaceHolderID="body" runat="server">

    <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Add Account's Type</h4>
                                <form id="form1" class="mt-4" runat="server">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                    <div class="form-group row">
                                        <label for="example-text-input" class="control-label">Account Type Name</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="textBox1" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group row">
                                        <label for="example-text-input" class="control-label">Description</label>
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="textBox2" CssClass="form-control" type="text" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                  <%--  <div class="form-group row">
                                        <label for="example-search-input" class="control-label">Search</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="search" value="How do I shoot web" id="example-search-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-email-input" class="control-label">Email</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="email" value="bootstrap@example.com" id="example-email-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-url-input" class="control-label">URL</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="url" value="https://getbootstrap.com" id="example-url-input">
                                        </div>
                                    </div>--%>
                                   <%-- <div class="form-group row">
                                        <label for="example-tel-input" class="control-label">Telephone</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="tel" value="1-(555)-555-5555" id="example-tel-input">
                                        </div>
                                    </div>--%>
                                   <%-- <div class="form-group row">
                                        <label for="example-password-input" class="control-label">Password</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="password" value="hunter2" id="example-password-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-number-input" class="control-label">Number</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="number" value="42" id="example-number-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-datetime-local-input" class="control-label">Date and time</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="datetime-local" value="2011-08-19T13:45:00" id="example-datetime-local-input">
                                        </div>
                                    </div>--%>
                                   <%-- <div class="form-group row">
                                        <label for="example-date-input" class="control-label">Date</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="date" value="2011-08-19" id="example-date-input">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="example-month-input" class="control-label">Month</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="month" value="2011-08" id="example-month-input">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="example-week-input" class="control-label">Week</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="week" value="2011-W33" id="example-week-input">
                                        </div>
                                    </div>--%>
                                    <%--<div class="form-group row">
                                        <label for="example-time-input" class="control-label">Time</label>
                                        <div class="col-lg-12">
                                            <input class="form-control" type="time" value="13:45:00" id="example-time-input">
                                        </div>
                                    </div>--%>
                                   <%-- <div class="form-group row">
                                        <label for="example-month-input2" class="control-label">Select</label>
                                        <div class="col-lg-12">
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
