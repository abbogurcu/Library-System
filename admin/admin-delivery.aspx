<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin-delivery.aspx.cs" Inherits="ERU_Lib.admin.admin_delivery" %>

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
            <li class="nav-item">
              <a class="nav-link" href="admin-item.aspx">
                <i class="ni ni-planet text-orange"></i>
                <span class="nav-link-text">Kitap İşlemleri</span>
              </a>
            </li>
             <li class="nav-item active">
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
    
        <!-- Page Content-->
        <div class="container-fluid p-0">
            <div class="row justify-content-center">
                <div class="col-md-10" style="background-color:#ebebeb;border-radius:10px;padding:15px;box-shadow: 0 2px 4px 0 rgba(0,0,0,.85);margin-top:9%;">
                    <p style="font-size:30px;">Kitap Teslim Durumu</p>
                    <br />
                    <p><asp:TextBox ID="username" OnTextChanged="OnTextChanged" placeholder="Kullanıcı adı giriniz!" style="font-size:30px;" runat="server"></asp:TextBox></p>
                    <p style="font-size:20px;" runat="server" id="tableBookEmpty">Ödünç verilmiş kitap yoktur.</p>  
                    <div runat="server" id="tableBook">
                    <table border="1" style="margin-bottom:40px;border-collapse:unset;border-color:rgba(0,0,0,0.6);width:97%;margin-right:auto;">
                        <tbody>
                            <tr class="alert alert-info h6 text-center">
                                <th style="font-size:24px;" scope="col">Kitap Adı</th>
                                <th style="font-size:24px;max-width:150px;" scope="col">Kullanıcı Adı</th>
                                <th style="font-size:24px;max-width:250px;" scope="col">Adı Soyadı</th>
                                <th style="font-size:24px;max-width:100px;" scope="col">Kategori</th>
                                <th style="font-size:24px;max-width:150px;" scope="col">Alma Tarihi</th>
                                <th style="font-size:24px;max-width:150px;" scope="col">Son Teslim Tarihi</th>
                                <th style="font-size:24px;max-width:150px;" scope="col">Durum</th>
	                        </tr>
                            <asp:Repeater runat="server" ID="Repeater1" OnItemCommand="OnItemCommand">
                                <ItemTemplate>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="Label1" style="color:black;"><%# Eval("username") %></asp:Label>
                                            </div>
                                        </td>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="Label2" style="color:black;"><%# Eval("name")+" "+ Eval("surname") %></asp:Label>
                                            </div>
                                        </td>
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
                                        <td>
                                            <div class="text-center h4">
                                                <h4><asp:LinkButton CommandName="Update" CommandArgument='<%# Eval("itemID") %>' Text="Teslim Al"  class="fa-border text-center btn-outline-primary" style="padding:5px 5px;margin-top:5px;width: 80%;border-radius: 20px;display:inline-block;border-color:rgba(0,0,0,0.5);" runat="server">
                                                        </asp:LinkButton></h4>
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
