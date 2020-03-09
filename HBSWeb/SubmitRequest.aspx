<%@ Page Title="Create request" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="SubmitRequest.aspx.cs" Inherits="HBSWeb.SubmitRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <h3>Submit a Holiday Request</h3>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
                <h4>Select Start Date</h4>
            </div>
            <div class="col-md-3">
                <asp:Calendar ID="startDateCalendar" runat="server" FirstDayOfWeek="Monday" OnSelectionChanged="verifySelectedDate" SelectedDayStyle-BackColor="#33CC33" ShowGridLines="True">
<SelectedDayStyle BackColor="#33CC33"></SelectedDayStyle>
                    <WeekendDayStyle BackColor="#FFCC00" />
                </asp:Calendar>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <br />  
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
                <h4>Select End Date</h4>
            </div>
            <div class="col-md-3">
                <asp:Calendar ID="endDateCalendar" runat="server" FirstDayOfWeek="Monday" OnSelectionChanged="verifySelectedDate" SelectedDayStyle-BackColor="#33CC33" ShowGridLines="True">
<SelectedDayStyle BackColor="#33CC33"></SelectedDayStyle>
                    <WeekendDayStyle BackColor="#FFCC00" />
                </asp:Calendar>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <asp:Label ID="holidaRequestMessage" runat="server" CssClass="holiday-request-message"></asp:Label>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6" style="text-align: right">
                <asp:Button ID="submitButton" runat="server" CssClass="btn btn-lg btn-danger" Text="Submit" OnClick="submitHolidayRequest" OnClientClick="return Confirm_Submit();" />
            </div>
            <div class="col-md-3">
            </div>
        </div>
    </div>
</asp:Content>
