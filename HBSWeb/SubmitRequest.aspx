<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="SubmitRequest.aspx.cs" Inherits="HBSWeb.SubmitRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Submit a Holiday Request</h3>
        <div class="row">
            <div class="col-md-6">
                <h4>Select Start Date</h4>
                <asp:Calendar ID="startDateCalendar" runat="server" FirstDayOfWeek="Monday" OnSelectionChanged="verifySelectedDate"></asp:Calendar>
            </div>
            <div class="col-md-6">
                <h4>Select End Date</h4>
                <asp:Calendar ID="endDateCalendar" runat="server" FirstDayOfWeek="Monday" OnSelectionChanged="verifySelectedDate"></asp:Calendar>
            </div>
            </div>
        <br />
        <asp:Label ID="lbl_summary" runat="server" BorderStyle="Dotted" BorderWidth="1px" Height="25px"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="submitButton" runat="server" CssClass="btn btn-lg btn-danger" Text="Submit" OnClick="submitHolidayRequest" OnClientClick="return Confirm_Submit();"/>
    </div>
</asp:Content>
