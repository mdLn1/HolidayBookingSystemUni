<%@ Page Title="Requests" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="RequestsHistory.aspx.cs" Inherits="HBSWeb.RequestsHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Holiday Request History</h3>
        <div>
            <asp:Table ID="RequestHistoryTable" runat="server" Width="100%" CssClass="table table-hover"> 
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
