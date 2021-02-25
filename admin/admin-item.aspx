<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin-item.aspx.cs" Inherits="ERU_Lib.admin.admin_item" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="Start your development with a Dashboard for Bootstrap 4.">
  <meta name="author" content="Creative Tim">
  <title>ERULIB</title>
  <!-- Favicon -->
  <link rel="icon" href="../assets/img/brand/favicon.png" type="image/png">
  <!-- Fonts -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700">
  <!-- Icons -->
  <link rel="stylesheet" href="../assets/vendor/nucleo/css/nucleo.css" type="text/css">
  <link rel="stylesheet" href="../assets/vendor/@fortawesome/fontawesome-free/css/all.min.css" type="text/css">
  <!-- Argon CSS -->
  <link rel="stylesheet" href="../assets/css/argon.css?v=1.2.0" type="text/css">
</head>

<body class="g-sidenav-show g-sidenav-pinned bg-primary">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" EnablePageMethods="true"></asp:ScriptManager>
  <!-- Sidenav -->
  <nav class="sidenav navbar navbar-vertical  fixed-left  navbar-expand-xs navbar-light bg-white border-right"  style="border-color:rgba(0,0,0,0.3) !important;" id="sidenav-main">
    <div class="scroll-wrapper scrollbar-inner" style="position: relative;"><div class="scrollbar-inner scroll-content" style="height: 921px; margin-bottom: 0px; margin-right: 0px; max-height: none;">
      <!-- Brand -->
      <div class="sidenav-header  align-items-center">
        <a class="navbar-brand" href="javascript:void(0)">
          <img src="../assets/img/theme/react.jpg" class="navbar-brand-img" alt="...">
        </a>
      </div>
      <div class="navbar-inner">
        <!-- Collapse -->
        <div class="collapse navbar-collapse" id="sidenav-collapse-main">
          <!-- Nav items -->
          <ul class="navbar-nav">
            <li class="nav-item">
              <a class="nav-link" href="admin.aspx">
                <i class="ni ni-tv-2 text-primary"></i>
                <span class="nav-link-text active">Kategori ve Masa İşlemleri</span>
              </a>
            </li>
            <li class="nav-item active">
              <a class="nav-link" href="admin-item.aspx">
                <i class="ni ni-planet text-orange"></i>
                <span class="nav-link-text">Kitap İşlemleri</span>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="admin-delivery.aspx">
                <i class="ni ni-pin-3 text-primary"></i>
                <span class="nav-link-text">Kitap Teslim İşlemleri
                </span>
              </a>
            </li>
          </ul>    
        </div>
      </div>
    </div><div class="scroll-element scroll-x"><div class="scroll-element_outer"><div class="scroll-element_size"></div><div class="scroll-element_track"></div><div class="scroll-bar" style="width: 0px;"></div></div></div><div class="scroll-element scroll-y"><div class="scroll-element_outer"><div class="scroll-element_size"></div><div class="scroll-element_track"></div><div class="scroll-bar" style="height: 0px;"></div></div></div></div>
  </nav>
  <!-- Main content -->
  <div class="main-content" id="panel">
    <!-- Topnav -->
    <nav class="navbar navbar-top navbar-expand navbar-dark bg-primary border-bottom">
      <div class="container-fluid">
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <!-- Search form -->
          
          <!-- Navbar links -->
          
          <ul class="navbar-nav align-items-center  ml-auto ml-md-0 ">
            <li class="nav-item dropdown">
              <a class="nav-link pr-0" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <div class="media align-items-center">
                  <span class="avatar avatar-sm rounded-circle">
                    <img alt="Image placeholder" src="../assets/img/theme/bootstrap.jpg">
                  </span>
                  <div class="media-body  ml-2  d-none d-lg-block">
                  </div>
                </div>
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>    
    
    <!-- Page content -->
    <div style="padding:0px 65px;margin-top:50px;width:97%;margin-left:auto;margin-right:auto;background-color:#ebebeb;box-shadow: 0 2px 4px 0 rgba(0,0,0,.6);">
        <div class="col-md-12">
            <div class="row justify-content-between" style="padding:50px 0px;">
                <div class="col-md-4" style="padding:15px 20px;box-shadow: 0 2px 4px 0 rgba(0,0,0,.6);">
                    <h3>Kategoriler</h3>


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

                    <div class="form-group mb-3" runat="server">
                      <div class="input-group input-group-alternative">
                        <div class="input-group-prepend">
                          <span class="input-group-text"><i class="ni ni-circle-08"></i></span>
                        </div>
                        <asp:TextBox id="TextBox1" class="form-control" placeholder="Ürün ismini girin!" type="text" runat="server"></asp:TextBox>
                      &nbsp;</div>
                    </div>

                    <div class="form-group mb-3" runat="server">
                      <div class="input-group input-group-alternative">
                        <div class="input-group-prepend">
                          <span class="input-group-text"><i class="ni ni-circle-08"></i></span>
                        </div>
                        <asp:TextBox id="TextBox2" class="form-control" placeholder="Ürün ismini girin!" type="text" runat="server"></asp:TextBox>
                      &nbsp;</div>
                    </div>

                    <div class="text-center">
                          <strong>
                            <asp:Label ID="Label1" runat="server" Text="Bu isimde bir kitap zaten mevcut." CssClass="alert alert-warning" style="display:none;"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="Kitap eklendi." CssClass="alert alert-success" style="display:none;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="Kitap güncellendi." CssClass="alert alert-warning" style="display:none;"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="Kitap silindi." CssClass="alert alert-danger" style="display:none;"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text="Bilgiler boş geçilemez." CssClass="alert alert-warning" style="display:none;"></asp:Label>
                          </strong>
                    </div>

                    <div id="add" visible="false" runat="server">
                        <button class="btn btn-success float-left" runat="server" onserverclick="addBtn">Ekle</button>
                    </div>
                    <div id="update" visible="false" runat="server">
                        <button class="btn btn-primary float-left" runat="server" onserverclick="updateBtn">Güncelle</button>
                        <button class="btn btn-warning float-right" runat="server" onserverclick="deleteBtn">Sil</button>
                    </div>
                </div>
                <div class="col-md-7" style="padding:15px 20px;box-shadow: 0 2px 4px 0 rgba(0,0,0,.6);">
                     <table border="1" id="tableSiparis" style="width:100%;margin-bottom:40px;border-collapse:unset;border-color:rgba(0,0,0,0.6);margin-right:auto;">
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
    </div>
    
  </div>
  <!-- Core -->
  <script src="assets/vendor/jquery/dist/jquery.min.js"></script>
  <script src="assets/vendor/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
  <script src="assets/vendor/js-cookie/js.cookie.js"></script>
  <script src="assets/vendor/jquery.scrollbar/jquery.scrollbar.min.js"></script>
  <script src="assets/vendor/jquery-scroll-lock/dist/jquery-scrollLock.min.js"></script>
  <!-- Optional JS -->
  <script src="assets/vendor/chart.js/dist/Chart.min.js"></script>
  <script src="assets/vendor/chart.js/dist/Chart.extension.js"></script>
  <!-- Argon JS -->
  <script src="assets/js/argon.js?v=1.2.0"></script><div class="backdrop d-xl-none" data-action="sidenav-unpin" data-target="undefined"></div><div style="left: -1000px; overflow: scroll; position: absolute; top: -1000px; border: none; box-sizing: content-box; height: 200px; margin: 0px; padding: 0px; width: 200px;"><div style="border: none; box-sizing: content-box; height: 200px; margin: 0px; padding: 0px; width: 200px;"></div></div>
</form>
</body>
</html>
