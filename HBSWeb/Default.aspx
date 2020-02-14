<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HBSWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HBS - Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <style>
        body {
            background: #eee !important;
        }

        .form-signin {
            max-width: 380px;
            padding: 15px 45px 45px;
            margin: 0 auto;
            background-color: #fff;
            border: 1px solid rgba(0,0,0,0.1);
        }

        .checkbox {
            font-weight: normal;
        }

        .form-control {
            position: relative;
            font-size: 16px;
            height: auto;
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container body-content">
            <div class="wrapper">
                <div class="form-signin">
                    <h2 class="form-signin-heading">HBS - Login</h2>
                    <asp:TextBox ID="tb_username" runat="server" placeholder="Username" CssClass="form-control" required="true"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="tb_password" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control" required="true"></asp:TextBox>
                    <br />
                    <p>
                        <asp:Button ID="btn_login" runat="server" CssClass="btn btn-lg btn-primary btn-block" Text="Login" OnClick="btn_login_Click" />
                    </p>
                    <p>
                        &nbsp;</p>
                    <p>
                        <asp:Label ID="lbl_errorMsg" runat="server" BackColor="#CC3300" BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px" ForeColor="Black" Width="100%"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
