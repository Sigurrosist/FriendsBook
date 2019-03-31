<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>LogIn _ FRIENDSBOOK</title>

  <!-- Bootstrap core CSS -->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Custom styles for this template -->
  <link href="css/the-big-picture-login.css" rel="stylesheet">

</head>

<body>

  <!-- Navigation -->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-bottom">
    <div class="container">
      <a class="navbar-brand" href="#">F R I E N D S B O O K</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item active">
            <a class="nav-link" href="Home.aspx">H O M E
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Login.aspx">L O G I N</a>
              <span class="sr-only">(current)</span>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Register.aspx">R E G I S T E R</a>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <!-- Page Content -->
  <section>
    <div class="container">
      <div class="row">
        <div class="col-lg-6">
          <h1 class="mt-5">F R I E N D S B O O K</h1>
          <p>Meet new people, find yourself a good community!</p>
            <hr style="padding:50px;" />
                      <div class="rows">
              <div class="col-md-4"></div>
              <div class="col-md-4">
                  <form id="formLogin" runat="server">
                  <table style="width:100%; padding:50px;">
                      <tr>
                          <td style="padding:25px;">
                              <asp:Label ID="Label1" runat="server" Text="User ID"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:TextBox ID="txtUserID" runat="server" placeholder="Enter your ID"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;">
                              <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:TextBox ID="txtPassword" runat="server" type="password" placeholder="Enter your password"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td>&nbsp;</td>
                          <td style="padding:25px;">
                              <asp:Button ID="btnLogin" runat="server" Text="Login" type="submit" OnClick="btnLogin_Click" />
                          </td>
                      </tr>
                      <tr>
                          <td>&nbsp;</td>
                          <td style="padding:25px;">
                              <asp:Literal ID="litMessage" runat="server"></asp:Literal>
                          </td>
                      </tr>
                  </table>
                  </form>
              </div>
              <div class="col-md-4"></div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- Bootstrap core JavaScript -->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>


</body>

</html>
