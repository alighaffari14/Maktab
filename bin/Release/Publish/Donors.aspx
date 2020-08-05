<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="Donors.aspx.cs" Inherits="FundingMaktab.Donors" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
                   <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">List of Donors</h4>
                                <div id="basicgrid" class="jsgrid" style="position: relative; height: 500px; width: 100%;">
                                    <div class="jsgrid-grid-header jsgrid-header-scrollbar">
                                        <table class="jsgrid-table table table-striped table-hover">
                                            <tr class="jsgrid-header-row">
                                                <th class="jsgrid-header-cell jsgrid-header-sortable" style="width: 127px;">Name</th>
                                                <th class="jsgrid-header-cell jsgrid-align-right jsgrid-header-sortable" style="width: 70px;">City</th>
                                                <th class="jsgrid-header-cell jsgrid-align-center jsgrid-header-sortable" style="width: 200px;">Country</th>

                                            </tr>
                                           

                                        </table>

                                    </div>
                                    <div class="jsgrid-grid-body" style="height: 296px;">
                                        <table class="jsgrid-table table table-striped table-hover">
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server"> 
                                                    <ItemTemplate>
                                            <tr class="jsgrid-row">
                                            <td class="jsgrid-cell" style="width: 163px;"><%#Eval("Donar_Name") %></td>
                                                <td class="jsgrid-cell jsgrid-align-center" style="width: 85px;"><%#Eval("Donar_City") %></td>
                                                <td class="jsgrid-cell jsgrid-align-center" style="width: 200px;"><%#Eval("Donar_Country") %></td>
                                                <td class="jsgrid-cell jsgrid-control-field jsgrid-align-center" style="width: 50px;">
                                                    <button class="jsgrid-button jsgrid-edit-button" onclick="window.location.href='UpdateDonor.aspx?Donar_Id=<%#Eval("Donar_Id") %>';" type="button" title="Edit">
                                                    </button>
                                                    <button class="jsgrid-button jsgrid-delete-button" type="button" title="Delete"></button>

                                                </td>

                                            </tr>
                                                        </ItemTemplate>
                                                </asp:Repeater>
                                               
                                               </tbody>

                                        </table>

                                    </div>
                                    <%--Below table data from page to page--%>
                                   <%-- <div class="jsgrid-pager-container" style="">
                                        <div class="jsgrid-pager">Pages: <span class="jsgrid-pager-nav-button jsgrid-pager-nav-inactive-button">
                                            <a href="javascript:void(0);">First</a></span>
                                            <span class="jsgrid-pager-nav-button jsgrid-pager-nav-inactive-button">
                                                <a href="javascript:void(0);">Prev</a>

                                            </span>
                                            <span class="jsgrid-pager-page jsgrid-pager-current-page">1</span>
                                            <span class="jsgrid-pager-page"><a href="javascript:void(0);">2</a></span>
                                            <span class="jsgrid-pager-page"><a href="javascript:void(0);">3</a></span>
                                            <span class="jsgrid-pager-page"><a href="javascript:void(0);">4</a></span>
                                            <span class="jsgrid-pager-page"><a href="javascript:void(0);">5</a></span>
                                            <span class="jsgrid-pager-nav-button"><a href="javascript:void(0);">...</a></span>
                                            <span class="jsgrid-pager-nav-button"><a href="javascript:void(0);">Next</a></span> 
                                            <span class="jsgrid-pager-nav-button"><a href="javascript:void(0);">Last</a></span> &nbsp;&nbsp; 1 of 7 </div>

                                    </div>--%>
                                    <div class="jsgrid-load-shader" style="display: none; position: absolute; top: 0px; right: 0px; bottom: 0px; left: 0px; z-index: 1000;">

                                    </div>
                                    <div class="jsgrid-load-panel" style="display: none; position: absolute; top: 50%; left: 50%; z-index: 1000;">Please, wait...</div>

                                </div>
                            </div>
                        </div>
                    </div>
    </div>
</asp:Content>
