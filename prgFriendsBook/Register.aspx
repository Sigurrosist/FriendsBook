<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Register _ FRIENDSBOOK</title>

  <!-- Bootstrap core CSS -->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Custom styles for this template -->
  <link href="css/the-big-picture-login.css" rel="stylesheet">

    <style type="text/css">
        .auto-style1 {
            width: 567px;
        }
    </style>

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
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Register.aspx">R E G I S T E R</a>
                            <span class="sr-only">(current)</span>
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
                  <form id="formRegister" method="post" action= "Login.aspx" runat="server">
                  <table style="width:100%; padding:50px;">
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:TextBox ID="txtEmail" runat="server" type="email" placeholder="Enter your Email address"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:TextBox ID="txtFirstName" runat="server" type="text" placeholder="Enter your first name"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:TextBox ID="txtLastName" runat="server" type="text" placeholder="Enter your last name"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label4" runat="server" Text="User ID"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:TextBox ID="txtUserID" runat="server" type="text" placeholder="Enter your ID for login"></asp:TextBox>
                              <asp:Button ID="btnIDValidate" runat="server" Text="Validate your ID" />
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:TextBox ID="txtPassword" runat="server" type="password" placeholder="Enter your password for login"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label6" runat="server" Text="Gender"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:DropDownList ID="cboGender" runat="server"></asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label7" runat="server" Text="Spoken Languages"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:DropDownList ID="cboLanguage" runat="server"></asp:DropDownList>
                              <asp:Button ID="btnAddLang" runat="server" Text="Add this language" />
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label8" runat="server" Text="Race"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:DropDownList ID="cboRace" runat="server"></asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label9" runat="server" Text="Country"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:DropDownList ID="cboCountry" runat="server"></asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label10" runat="server" Text="City"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:DropDownList ID="cboCity" runat="server"></asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label11" runat="server" Text="Can't find your city?"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:Textbox ID="txtNewCity" runat="server" placeholder="Enter your city name"></asp:Textbox>
                              <asp:Button ID="btnNewCity" runat="server" Text="Add" />
                          </td>
                      </tr>
                      <tr>
                          <td style="padding:25px;" class="auto-style1">
                              <asp:Label ID="Label12" runat="server" Text="Birthday"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <p><asp:Label runat="server" Text="Year  : "></asp:Label><asp:DropDownList runat="server" ID="cboYear"></asp:DropDownList></p>
                              <p><asp:Label runat="server" Text="Month : "></asp:Label><asp:DropDownList runat="server" ID="cboMonth"></asp:DropDownList></p>
                              <p><asp:Label runat="server" Text="Day   : "></asp:Label><asp:DropDownList runat="server" ID="cboDay"></asp:DropDownList></p>
                          </td>
                      </tr>
                      <tr>
                           <td style="padding:25px;" class="auto-style1">
                               <asp:Label runat="server" Text="Check all information and click Register button!"></asp:Label>
                          </td>
                          <td style="padding:25px;">
                              <asp:Button ID="btnSubmit" runat="server" Text="Register" Width="200px"></asp:Button>
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