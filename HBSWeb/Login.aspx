﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HBSWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <style>
        body {
            background: #eee !important;
            background-color: #124e78;
        }

        footer {
            position: fixed;
            bottom: 1rem;
            left: 20vh;
        }

        .login-form {
            border-radius: 1.5rem;
            text-align: center;
            position: relative;
            margin: 5rem auto;
            border: 1px solid #888;
            max-width: 440px;
            text-align: center;
            box-shadow: 0.75rem 1.5rem 3rem rgba(0, 0, 0, .5);
            padding: 2rem;
        }

        .checkbox {
            font-weight: normal;
        }

        .form-control {
            position: relative;
            font-size: 1.4rem;
            height: auto;
        }

        #usernameTextBox, #passwordTextBox, #loginButton, #errorMessageLabel {
            display: inline;
            margin: 1rem auto;
            border-radius: 1rem;
            padding: 1rem;
        }

        #errorMessageLabel {
            color: white;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="container body-content">
            <div class="wrapper" style="margin-top: 10rem; text-align: center;">
                <h2>Welcome to Straight Walls Ltd!</h2>
                <h3>Please fill the login form to access your details</h3>
                <div class="login-form">
                    <div id="LogoutMessageAlert" class="alert alert-success" role="alert" runat="server" visible="false">You have successfully logged out.</div>
                    <h2 class="form-signin-heading">Login</h2>
                    <asp:TextBox ID="usernameTextBox" runat="server" placeholder="Username" CssClass="form-control" required="true"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="passwordTextBox" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control" required="true"></asp:TextBox>
                    <br />
                    <p>
                        <asp:Button ID="loginButton" runat="server" CssClass="btn btn-lg btn-success btn-block" Text="Login" OnClick="loginRequest" />
                    </p>
                    <p>
                        <asp:Label ID="errorMessageLabel" runat="server" CssClass="label-danger form-control"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </form>
    <footer>
        <p>&copy; <%: DateTime.Now.Year %> - Madalin Preda Solutions</p>
    </footer>
</body>
</html>
