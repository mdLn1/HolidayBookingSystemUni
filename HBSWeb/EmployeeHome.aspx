<%@ Page Title="Requests" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="EmployeeHome.aspx.cs" Inherits="HBSWeb.RequestsHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Holiday Booking System</h1>
        <p class="lead">Straight Walls Ltd - Holiday Booking system.</p>
    <div id="HolidayRequestAlert" class="alert alert-success" role="alert" runat="server" visible="false">Success! Request submitted.</div>
        <h3>Holiday Request History</h3>
        <div>
            <asp:Table ID="requestsTable" runat="server" CssClass="table table-hover"> 
                <asp:TableRow>
                    <asp:TableCell>Start Date</asp:TableCell>
                    <asp:TableCell>End Date</asp:TableCell>
                    <asp:TableCell>Duration</asp:TableCell>
                    <asp:TableCell>Status</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
        </div>
    </div>
</asp:Content>
