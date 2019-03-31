using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class WriteMessage : System.Web.UI.Page
{
    static OleDbConnection myCon;
    static OleDbDataReader myRdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/friendsbookDB1.mdb"));
        myCon.Open();
        OleDbCommand myCmd = new OleDbCommand("select UserID, FirstName, LastName, UserName from Users", myCon);
        myRdr = myCmd.ExecuteReader();
        if (!Page.IsPostBack)
            fillCboBox();
    }
    private void fillCboBox()
    {
        while(myRdr.Read())
        {
            ListItem temp = new ListItem();
            temp.Text = myRdr["FirstName"].ToString() + ", " + myRdr["LastName"].ToString() + " - " + myRdr["UserName"].ToString();
            temp.Value = myRdr["UserID"].ToString();
            cboRecipient.Items.Add(temp);
        }
    }
}