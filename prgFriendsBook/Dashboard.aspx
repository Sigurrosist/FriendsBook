<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

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

</head>

<body>

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
                  <div>
                     <img src="https://image.flaticon.com/icons/svg/78/78373.svg" class="img-thumbnail" />
                  </div>
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
        <asp:Label runat="server" class="mt-4" ID="lblNumMessage" Font-Size="Larger">You have 0 New Messages</asp:Label>  
          <hr />        
        <asp:Label runat="server" ID="lblRandomSaying" ForeColor="YellowGreen" Font-Size="Larger">W h a t e v e r </asp:Label>
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

</body>

</html>
