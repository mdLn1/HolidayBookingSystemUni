<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="SubmitRequest.aspx.cs" Inherits="HBSWeb.SubmitRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Submit a Holiday Request</h3>
        <asp:Calendar ID="cal_start_date" runat="server" FirstDayOfWeek="Monday"></asp:Calendar>
        <asp:Calendar ID="cal_end_date" runat="server" FirstDayOfWeek="Monday"></asp:Calendar>
        <asp:Label ID="lbl_summary" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-lg btn-primary" Text="Submit" OnClick="btn_login_Click" />
    </div>
    
</asp:Content>
