<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appointment.aspx.cs" Inherits="ERU_Lib.appointment" %>

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
            <div class="row justify-content-between">
                <div class="col-md-4" style="margin-left:30px;box-shadow: 0 2px 4px 0 rgba(0,0,0,.85);margin-top:9%;background-color:#fff;border-radius:10px;padding:10px;">
                    <p style="font-size:30px;">Randevu Alma</p>
                    <asp:Label ID="uyari" runat="server" Text="Randevular 1 saatlik dilimler şeklinde alınmaktadır." CssClass="alert alert-danger"></asp:Label>
                    <br />
                    <br />
                          <!-- Masa -->
                          <asp:Calendar AutoPostBack="true" runat="server" style="margin-bottom:25px;" CssClass="p" ID="Calendar1" OnSelectionChanged="OnCalendarChanged"></asp:Calendar>

                    <!-- Saat -->
                        <asp:Dropdownlist style="margin-bottom:25px;" id="times" OnSelectedIndexChanged="OnTimesChanged" AutoPostBack="true" class="form-control" type="text" runat="server">
                            <asp:ListItem Value="12" Selected="True">12:00</asp:ListItem>
                            <asp:ListItem Value="13">13:00</asp:ListItem>
                            <asp:ListItem Value="14">14:00</asp:ListItem>
                            <asp:ListItem Value="15">15:00</asp:ListItem>
                            <asp:ListItem Value="16">16:00</asp:ListItem>
                          </asp:Dropdownlist>

                    <asp:Repeater runat="server" ID="Repeater1" OnItemDataBound="OnItemDataBound" OnItemCommand="OnItemCommand">
                        <ItemTemplate>
                            <asp:Button runat="server" style="margin-right:10px;font-size:20px;" ID="table" Text='<%# Eval("tables") %>' CommandName="Click"/>
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <br />
                    <br />
                     <div class="text-left">
                          <strong>
                            <asp:Label runat="server" ID="selectedTable" CssClass="alert alert-warning h5" style="margin:35px 0px;"/>
                            <asp:Label runat="server" ID="getTable" CssClass="alert alert-warning h5" style="margin:35px 0px;display:none;"/>
                            <asp:Label ID="Label1" runat="server" Text="Bu randevu biraz önce ödünç verildi." CssClass="alert alert-warning" style="display:none;"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="Randevu alındı." CssClass="alert alert-success" style="display:none;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="Günümüz veya ileri tarihli bir gün seçiniz." CssClass="alert alert-warning" style="display:none;"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="Lütfen masa seçiniz." CssClass="alert alert-warning" style="display:none;"></asp:Label>
                          </strong>
                    </div>
                    <br />
                    <br />
                    <button class="btn btn-info float-left p" runat="server" onserverclick="getAppo" style="margin-bottom:15px;font-size:24px;">Randevu Al</button>
                </div>
                <div class="col-md-7" style="margin-right:30px;box-shadow: 0 2px 4px 0 rgba(0,0,0,.85);margin-top:9%;background-color:#fff;border-radius:10px;padding:10px;">
                    <p style="font-size:30px;">Randevu Geçmişi</p>
                    <br />
                    <table border="1" id="tableSiparis" style="margin-bottom:40px;border-collapse:unset;border-color:rgba(0,0,0,0.6);width:97%;margin-right:auto;">
                        <tbody>
                            <tr class="alert alert-info h6 text-center">
                                <th style="font-size:24px;" scope="col">Tarih</th>
                                <th style="font-size:24px;max-width:160px;" scope="col">Saat</th>
                                <th style="font-size:24px;max-width:200px;" scope="col">Masa</th>
	                        </tr>
                            <asp:Repeater runat="server" ID="Repeater2">
                                <ItemTemplate>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="item" style="color:black;"><%# Eval("customDate") %></asp:Label>
                                            </div>
                                        </td>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="category" style="color:black;"><%# Eval("timePeriod") %>:00</asp:Label>
                                            </div>
                                        </td>
                                        <td>  
                                            <div class="text-center h4">
                                                <asp:Label runat="server" id="getDate" style="color:black;"><%# Eval("tableName") %></asp:Label>
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
