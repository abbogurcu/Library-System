<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ERU_Lib.login" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>ERU Lib</title>
        <link rel="icon" type="image/x-icon" href="assets2/img/favicon.ico" />
        <!-- Font Awesome icons (free version)-->
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:500,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Muli:400,400i,800,800i" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="assets2/css/styles.css" rel="stylesheet" />
    </head>
    <body id="page-top" style="background-color:#ebebeb;">
        <form id="form1" runat="server">
        <!-- Page Content-->
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top" style="border-radius:50px;width: 500px;margin-left:auto;margin-right:auto;height: 60%; top: 20%;box-shadow: 0 2px 4px 0 rgba(0,0,0,.8);" id="sideNav">
            <a class="navbar-brand js-scroll-trigger" style="margin:0px !important;">
                <span class="d-none d-lg-block"><img class="img-fluid img-profile rounded-circle mx-auto mb-2" src="assets2/img/profile.png" alt="" /></span>
            </a>
            
            <div class="container">
                <div class="row">
                    <asp:TextBox style="margin-top:50px;" ID="username" runat="server" class="form-control" placeholder="Kullanıcı Adı" type="text"/>

                    <Asp:TextBox style="margin-top:50px;" ID="password" runat="server" class="form-control" placeholder="Şifre" type="password"/>

                    <div runat="server" id="loginError" visible="false" class="alert alert-warning" role="alert" style="margin-left:auto;margin-right:auto;margin-top:20px;">
                        <strong>Hata!</strong> Kullanıcı Adı veya Şifre Hatalı.
                    </div>

                    <div class="text-center" style="margin-left:auto;margin-right:auto;margin-top:30px;">
                      <asp:Button type="button" runat="server" onclick="loginBtn_Click" class="btn btn-secondary" style="width:200px;" Text="Giriş"/>
                    </div>

                    <a href="register.aspx" style="position: absolute; bottom: 10px;color:white!important; left: 35%;">Kayıtlı değil misiniz?</a>
                </div>
            </div>
        </nav>



        <!-- Core theme JS-->
        <script src="assets2/js/scripts.js"></script>
        </form>
    </body>
</html>
