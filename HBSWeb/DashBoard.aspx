<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="HBSWeb.DashBoard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Holiday Booking System</h1>
        <p class="lead">Straight Walls Ltd - Holiday Booking system.</p>
        <div id="HolidayRequestAlert" class="alert alert-success" role="alert" runat="server" visible="false">Holiday Request Succesfully submitted</div>
    </div>
</asp:Content>
