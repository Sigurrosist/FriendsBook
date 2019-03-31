<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageCenter.aspx.cs" Inherits="MessageCenter" %>

<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Message Center - FriendsBook</title>

  <!-- Bootstrap core CSS -->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Custom styles for this template -->
  <link href="css/simple-sidebar.css" rel="stylesheet">

    <style type="text/css">
        .auto-style1 {
            width: 33%;
            height: 26px;
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
                <a class="dropdown-item" href="#">My settings</a>
                <a class="dropdown-item" href="#">My Messages</a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" href="Logout.aspx">Log out</a>
              </div>
            </li>
          </ul>
        </div>
      </nav>

        <div class="container-fluid">
        <asp:Label runat="server" class="mt-4" ID="lblNumMessage" Font-Size="Larger">You have 0 New Messages</asp:Label>  
          <hr />        
      </div>
          <br />
          <br />
          <table style="width:100%;">
              <tr>
                  <td class="auto-style1"></td>
                  <td class="auto-style1">
                      <asp:ListBox ID="lstMessage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstMessage_SelectedIndexChanged" Width="390px"></asp:ListBox>
                  </td>
                  <td class="auto-style1"></td>
              </tr>
              <tr>
                  <td style="width:33%;">&nbsp;</td>
                  <td style="width:33%;">
                      <asp:TextBox ID="txtMessage" runat="server" Height="281px" ReadOnly="True" Width="384px"></asp:TextBox>
                  </td>
                  <td style="width:33%;">&nbsp;</td>
              </tr>
              <tr>
                  <td style="width:33%;">&nbsp;</td>
                  <td style="width:33%;">
                      <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete This Message" Width="393px" />
                      <br />
                      <asp:Button ID="btnWrite" runat="server" OnClick="btnWrite_Click" Text="Write a message" Width="393px" />
                  </td>
                  <td style="width:33%;">&nbsp;</td>
              </tr>
              <tr>
                  <td style="width:33%;">&nbsp;</td>
                  <td style="width:33%;" class="text-center">
                      <asp:Label ID="lblMessage" runat="server" ForeColor="#660066"></asp:Label>
                  </td>
                  <td style="width:33%;">&nbsp;</td>
              </tr>
          </table>
          <br />
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