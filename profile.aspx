<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="ERU_Lib.profile" %>

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
        <script src="https://use.fontawesome.com/releases/v5.15.1/js/all.js" crossorigin="anonymous"></script>
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:500,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Muli:400,400i,800,800i" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="assets2/css/styles.css" rel="stylesheet" />
    </head>
    <body id="page-top">
        <form id="form1" runat="server">
        <!-- Navigation-->
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top" id="sideNav">
            <a class="navbar-brand js-scroll-trigger">
                <span class="d-none d-lg-block"><img class="img-fluid img-profile rounded-circle mx-auto mb-2" src="assets2/img/profile.png" alt="" /></span>
            </a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav">
                    <li class="nav-item"><asp:Label CssClass="h3" runat="server" ID="fullname"></asp:Label></li>
                    <li class="nav-item"><a class="nav-link js-scroll-trigger" href="index.aspx">Ana Sayfa</a></li>
                    <li class="nav-item"><a class="nav-link js-scroll-trigger" href="item.aspx">Kitap İşlemleri</a></li>
                    <li class="nav-item"><a class="nav-link js-scroll-trigger" href="appointment.aspx">Randevu İşlemleri</a></li>
                    <li class="nav-item"><a class="nav-link js-scroll-trigger" href="profile.aspx">Hesap Bilgileri</a></li>
                    <li class="nav-item"><a class="nav-link js-scroll-trigger h3" style="{color:black;
    }:hover {color:white !important }" runat="server" onserverclick="logout">Çıkış Yap</a></li>
                </ul>
            </div>
        </nav>
        <!-- Page Content-->
            <div class="col-md-5" style="margin-left:50px;box-shadow: 0 2px 4px 0 rgba(0,0,0,.85);margin-top:12%;background-color:#fff;border-radius:10px;padding:10px;">
                <asp:TextBox style="margin-top:30px;" ID="username" runat="server" class="form-control" placeholder="Kullanıcı Adı" type="text"/>

                <Asp:TextBox style="margin-top:30px;" ID="password" runat="server" class="form-control" placeholder="Şifre" type="password"/>

                <Asp:TextBox style="margin-top:30px;" ID="name" runat="server" class="form-control" placeholder="Adı" type="text"/>

                <Asp:TextBox style="margin-top:30px;" ID="surname" runat="server" class="form-control" placeholder="Soyadı" type="text"/>

                <Asp:DropDownList style="margin-top:30px;" ID="age" runat="server" class="form-control" placeholder="Yaş" type="text">
                    <asp:ListItem Selected="True">18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                </asp:DropDownList>

                <Asp:TextBox style="margin-top:30px;height:100px;" TextMode="MultiLine" ID="address" runat="server" class="form-control" placeholder="Adres" type="password"/>

                <div runat="server" id="loginError" class="alert alert-warning" role="alert" style="margin-left:auto;margin-right:auto;margin-top:10px;display:none;">
                    <strong>Hata!</strong> Kullanıcı Adı zaten mevcut.
                </div>

                <div runat="server" id="registerError" class="alert alert-warning" role="alert" style="margin-left:auto;margin-right:auto;margin-top:10px;display:none;">
                    <strong>Hata!</strong> Bazı alanlar doldurulmadı.
                </div>

                <div runat="server" id="Div1" class="alert alert-success" role="alert" style="margin-left:auto;margin-right:auto;margin-top:10px;display:none;">
                    <strong>Başarılı!</strong> Bilgileriniz değiştirildi.
                </div>

                <div class="text-center" style="margin-left:auto;margin-right:auto;margin-top:20px;">
                    <asp:Button type="button" runat="server" onclick="updateBtn_Click" class="btn btn-secondary" style="width:200px;" Text="Güncelle"/>
                </div>
            </div>

        <!-- Core theme JS-->
        <script src="assets2/js/scripts.js"></script>
       </form>
    </body>
</html>
