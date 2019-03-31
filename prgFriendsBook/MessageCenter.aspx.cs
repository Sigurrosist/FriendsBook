using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class MessageCenter : System.Web.UI.Page
{
    static OleDbConnection myCon;
    static DataSet MessUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        MessUser = new DataSet();
        myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/friendsbookDB1.mdb"));
        myCon.Open();
        OleDbCommand myCmd = new OleDbCommand("select * from Messages where ReceiverID = " + Session["User"].ToString(), myCon);
        OleDbDataAdapter myadp = new OleDbDataAdapter(myCmd);
        myadp.Fill(MessUser, "Message");
        OleDbCommand myCmd2 = new OleDbCommand("select * from Users", myCon);
        OleDbDataAdapter myAdp = new OleDbDataAdapter(myCmd2);
        myAdp.Fill(MessUser, "User");
        lblNumMessage.Text = "You have " + numberMessage() + " messages";

        if(!Page.IsPostBack) 
        fillListBox();
    }

    protected void btnWrite_Click(object sender, EventArgs e)
    {
        Response.Redirect("WriteMessage.aspx");
    }

    private int numberMessage()
    {
        int num = 0;
        num = MessUser.Tables["Message"].Rows.Count;
        return num;
    }

    private void fillListBox()
    {
        foreach (DataRow myrow in MessUser.Tables["Message"].Rows)
        {
            DataRow[] tmprow = MessUser.Tables["User"].Select("UserID = " + myrow["SenderID"].ToString());
            string messageid = myrow["MessageID"].ToString();
            string sendername = tmprow[0]["FirstName"].ToString() + ", " + tmprow[0]["LastName"].ToString();
            string messagetime = myrow["MessageTime"].ToString();
            string title = myrow["Title"].ToString();

            ListItem tmpitem = new ListItem(sendername + " : " + title + " - " + messagetime, messageid);
            lstMessage.Items.Add(tmpitem);
        }
    }

    private void displayMessage()
    {
        DataRow[] tmprow = MessUser.Tables["Message"].Select("MessageID = " + lstMessage.SelectedValue);
        string message = tmprow[0]["Message"].ToString();
        txtMessage.Text = message;
    }

    protected void lstMessage_SelectedIndexChanged(object sender, EventArgs e)
    {
        displayMessage();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        OleDbCommand myCmdDel = new OleDbCommand("delete from Messages where MessageID=" + lstMessage.SelectedValue, myCon);
        int del = myCmdDel.ExecuteNonQuery();
        lblMessage.Text = (del != 0) ? "Message is successfully deleted" : "Delete failed";
        lstMessage.Items.Clear();

        MessUser.Tables.Remove("Message");
        OleDbCommand myCmd = new OleDbCommand("select * from Messages where ReceiverID = " + Session["User"].ToString(), myCon);
        OleDbDataAdapter myadp = new OleDbDataAdapter(myCmd);
        myadp.Fill(MessUser, "Message");
        fillListBox();
        txtMessage.Text = "";
    }
}