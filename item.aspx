<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="item.aspx.cs" Inherits="ERU_Lib.item" %>

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
            <div class="row">
                <div class="col-md-5 mx-5" style="box-shadow: 0 2px 4px 0 rgba(0,0,0,.85);margin-top:9%;background-color:#fff;border-radius:10px;padding:10px;">
                    <p style="font-size:30px;">Kitap Ödünç Alma</p>
                    <br />
                     <div runat="server" class="form-group mb-3">
                      <div class="input-group input-group-alternative">
                        <div class="input-group-prepend">
                          <span class="input-group-text"><i class="ni ni-album-2"></i></span>
                        </div>
                        <asp:Dropdownlist id="DropDownList1" OnSelectedIndexChanged="OnSelectedIndexChanged" AutoPostBack="true" class="form-control" type="text" runat="server">
                          </asp:Dropdownlist>
                      </div>
                    </div>

                    <div runat="server" class="form-group mb-3">
                      <div class="input-group input-group-alternative">
                        <div class="input-group-prepend">
                          <span class="input-group-text"><i class="ni ni-album-2"></i></span>
                        </div>
                        <asp:Dropdownlist id="DropDownList2" OnSelectedIndexChanged="OnSelectedIndexChanged2" AutoPostBack="true" class="form-control" type="text" runat="server">
                          </asp:Dropdownlist>
                      </div>
                    </div>

                    <div class="form-group mb-3" id="writerDiv" runat="server">
                      <div class="input-group input-group-alternative">
                        <div class="input-group-prepend">
                          <span class="input-group-text"><i class="ni ni-circle-08"></i></span>
                        </div>
                        <asp:Label id="labelWriter" class="form-control" placeholder="Yazar ismi buraya gelecek." type="text" runat="server"></asp:Label>
                      &nbsp;</div>
                    </div>

                     <div class="text-center">
                          <strong>
                            <asp:Label ID="Label1" runat="server" Text="Bu kitap biraz önce ödünç verildi." CssClass="alert alert-warning" style="display:none;"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="Kitap ödünç alındı." CssClass="alert alert-success" style="display:none;"></asp:Label>
                          </strong>
                    </div>

                    <button class="btn btn-success float-left" runat="server" style="margin-bottom:20px;" onserverclick="getItem">Ekle</button>
                </div>
            </div>
        </div>

        <!-- Core theme JS-->
        <script src="assets2/js/scripts.js"></script>
        </form>
    </body>
</html>
