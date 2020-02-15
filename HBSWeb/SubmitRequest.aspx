<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="SubmitRequest.aspx.cs" Inherits="HBSWeb.SubmitRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Submit a Holiday Request</h3>
        <div class="row">
            <div class="col-md-6">
                <h4>Select Start Date</h4>
                <asp:Calendar ID="cal_start_date" runat="server" FirstDayOfWeek="Monday"></asp:Calendar>
            </div>
            <div class="col-md-6">
                <h4>Select End Date</h4>
                <asp:Calendar ID="cal_end_date" runat="server" FirstDayOfWeek="Monday"></asp:Calendar>
            </div>
            </div>
        <br />
        <asp:Label ID="lbl_summary" runat="server" BorderStyle="Dotted" BorderWidth="1px" Height="25px"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btn_preview" runat="server" CssClass="btn btn-lg btn-primary" Text="Preview Request" OnClick="btn_preview_Click" />
        <br />
        <br />
        <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-lg btn-danger" Text="Submit" OnClick="btn_login_Click" OnClientClick="return Confirm_Submit();"/>
    </div>
</asp:Content>
