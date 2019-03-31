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

    protected void btnWrite_Click(object sender, EventArgs e)
    {
        string title = txtSubject.Text;
        string message = txtMessage.Text;
        string receiver = cboRecipient.SelectedValue.ToString();
        string senduser = Session["User"].ToString();
        string currentTime = DateTime.Now.ToString("h:mm:ss tt");
        string sql = "insert into Messages (SenderID, ReceiverID, Message, MessageTime, Title) values (@senduser, @receiver, @message, @currentTime, @title)";
        OleDbCommand insertCommand = new OleDbCommand(sql, myCon);
        insertCommand.Parameters.AddWithValue("senduser", senduser);
        insertCommand.Parameters.AddWithValue("receiver", receiver);
        insertCommand.Parameters.AddWithValue("message", message);
        insertCommand.Parameters.AddWithValue("currentTime", currentTime);
        insertCommand.Parameters.AddWithValue("title", title);

        int messageDone = insertCommand.ExecuteNonQuery();
        string result = "";
        result += (messageDone == 1) ? "Message to " + cboRecipient.SelectedItem.Text + " is successfully sent!" : "Message is not sent!";
        litMessage.Text = result;
    }
}