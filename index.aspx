<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ERU_Lib.index" %>

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
    <body id="page-top"  style="background-color:#ebebeb;">
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
        <div class="container-fluid p-0">
            <div class="row justify-content-center">
                <div class="col-md-10" style="box-shadow: 0 2px 4px 0 rgba(0,0,0,.85);margin-top:9%;">
                    <p style="font-size:30px;">Kitap Alma Geçmişi</p>
                    <br />
                    <table border="1" id="tableSiparis" style="margin-bottom:40px;border-collapse:unset;border-color:rgba(0,0,0,0.6);width:97%;margin-right:auto;">
                        <tbody>
                            <tr class="alert alert-info h6 text-center">
                                <th style="font-size:24px;" scope="col">Kitap Adı</th>
                                <th style="font-size:24px;max-width:160px;" scope="col">Kategori</th>
                                <th style="font-size:24px;max-width:200px;" scope="col">Alma Tarihi</th>
                                <th style="font-size:24px;max-width:200px;" scope="col">Son Teslim Tarihi</th>
	                        </tr>
                            <asp:Repeater runat="server" ID="Repeater1">
                                <ItemTemplate>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="item" style="color:black;"><%# Eval("item") %></asp:Label>
                                            </div>
                                        </td>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="category" style="color:black;"><%# Eval("cat") %></asp:Label>
                                            </div>
                                        </td>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="getDate" style="color:black;"><%# Eval("getDay") %></asp:Label>
                                            </div>
                                        </td>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="giveDate" style="color:black;"><%# Eval("giveDate") %></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <!-- Core theme JS-->
        <script src="assets2/js/scripts.js"></script>
        </form>
    </body>
</html>
