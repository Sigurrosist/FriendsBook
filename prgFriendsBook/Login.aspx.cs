using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Login : System.Web.UI.Page
{
    static OleDbConnection myCon;
    static OleDbDataReader myRdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/friendsbookDB1.mdb"));
        myCon.Open();
        OleDbCommand myCmd = new OleDbCommand("select UserID, Username, Password from Users", myCon);
        myRdr = myCmd.ExecuteReader();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool loginSucceess = false;
        while(myRdr.Read())
        {
            if((myRdr["UserName"].ToString() == txtUserID.Text) && (myRdr["Password"].ToString() == txtPassword.Text))
            {
                loginSucceess = true;
                Session["User"] = myRdr["UserID"].ToString();
                break;
            }
        }

        if(loginSucceess)
        {
            litMessage.Text = Session["User"].ToString();
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            litMessage.Text = "Login Failed";
        }

    }
}