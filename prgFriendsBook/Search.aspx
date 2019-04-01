<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Dashboard - FriendsBook</title>

  <!-- Bootstrap core CSS -->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Custom styles for this template -->
  <link href="css/simple-sidebar.css" rel="stylesheet">

    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 33%;
            height: 47px;
        }
        .auto-style2 {
            width: 33%;
            height: 47px;
        }
    </style>

</head>

<body>

    <form id="form1" runat="server">

  <div class="d-flex" id="wrapper">

    <!-- Sidebar -->
    <div class="bg-light border-right" id="sidebar-wrapper">
      <div class="sidebar-heading">F r i e n d s B o o k</div>
      <div class="list-group list-group-flush">
        <a href="Dashboard.aspx" class="list-group-item list-group-item-action bg-light">Dashboard</a>
        <a href="MessageCenter.aspx" class="list-group-item list-group-item-action bg-light">Messages</a>
        <a href="Search.aspx" class="list-group-item list-group-item-action bg-light">Search Users</a>
      </div>
    </div>
    <!-- /#sidebar-wrapper -->

    <!-- Page Content -->
    <div id="page-content-wrapper">

      <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
        <button class="btn btn-primary" id="menu-toggle">Hide Menu</button>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav ml-auto mt-2 mt-lg-0">
            <li class="nav-item active">
              <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
            </li>
            <li class="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                My Account
              </a>
              <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown">
                <a class="dropdown-item" href="Settings.aspx">My settings</a>
                <a class="dropdown-item" href="MessageCenter.aspx">My Messages</a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" href="Logout.aspx">Log out</a>
              </div>
            </li>
          </ul>
        </div>
      </nav>

      <div class="container-fluid">
        <asp:Label runat="server" ID="lblNumMessage" ForeColor="Black" Font-Size="Larger">W h a t e v e r </asp:Label>
          <br />
          <br />
          <table style="width:100%;  padding:10px;">
              <tr>
                  <td style="padding: 10px; width:33%;">
                      <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="S e a r c h   U s e r"></asp:Label>
                  </td>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
              </tr>
              <tr>
                  <td style="padding: 10px; width:33%;" class="text-right">
                      <asp:Label ID="Label2" runat="server" Text="Country"></asp:Label>
                  </td>
                  <td style="padding: 10px; width:33%;">
                      <asp:DropDownList ID="cboCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboCountry_SelectedIndexChanged">
                      </asp:DropDownList>
                  </td>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
              </tr>
              <tr>
                  <td style="padding: 10px; width:33%;" class="text-right">
                      <asp:CheckBox ID="chkCity" runat="server" Text="Search by City"  />
                  </td>
                  <td style="padding: 10px; width:33%;">
                      <asp:DropDownList ID="cboCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboCity_SelectedIndexChanged">
                      </asp:DropDownList>
                  </td>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
              </tr>
              <tr>
                  <td style="padding: 10px; width:33%;" class="text-right">
                      <asp:CheckBox ID="chkGender" runat="server" Text="Searcy by Gender" />
                  </td>
                  <td style="padding: 10px; width:33%;">
                      <asp:DropDownList ID="cboGender" runat="server">
                      </asp:DropDownList>
                  </td>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
              </tr>
              <tr>
                  <td style="padding: 10px; " class="auto-style1">
                      <asp:CheckBox ID="chkRace" runat="server" Text="Search by Race" />
                  </td>
                  <td style="padding: 10px; " class="auto-style2">
                      <asp:DropDownList ID="cboRace" runat="server">
                      </asp:DropDownList>
                  </td>
                  <td style="padding: 10px; " class="auto-style2"></td>
              </tr>
              <tr>
                  <td style="padding: 10px; width:33%;" class="text-right">
                      <asp:CheckBox ID="chkLanguage" runat="server" Text="Search by Language" />
                  </td>
                  <td style="padding: 10px; width:33%;">
                      <asp:DropDownList ID="cboLanguage" runat="server">
                      </asp:DropDownList>
                  </td>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
              </tr>
              <tr>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
                  <td style="padding: 10px; width:33%;">
                      <asp:Button ID="btnSearch" runat="server" Text="Search" Width="347px" Font-Size="Larger" OnClick="btnSearch_Click" />
                  </td>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
              </tr>
              <tr>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
                  <td style="padding: 10px; width:33%;">
            <asp:GridView ID="gridSearchResult" style="padding:20px;" runat="server" HorizontalAlign="Center">
            </asp:GridView>
                  </td>
                  <td style="padding: 10px; width:33%;">&nbsp;</td>
              </tr>
          </table>
      </div>
    </div>
    <!-- /#page-content-wrapper -->

  </div>
  <!-- /#wrapper -->

  <!-- Bootstrap core JavaScript -->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Menu Toggle Script -->
  <script>
      $("#menu-toggle").click(function (e) {
          e.preventDefault();
          $("#wrapper").toggleClass("toggled");
          $("#menu-toggle").text(function () {
              if ($("#menu-toggle").text() == "Show Menu")
                  return "Hide Menu";
              else
                  return "Show Menu";
          });
      })
  </script>

    </form>

</body>

</html>