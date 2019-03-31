using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Dashboard : System.Web.UI.Page
{
    static OleDbConnection myCon;
    static OleDbDataReader messageReader;
    static OleDbDataReader sayingReader;
    protected void Page_Load(object sender, EventArgs e)
    {
        myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/friendsbookDB1.mdb"));
        myCon.Open();
        OleDbCommand myCmd = new OleDbCommand("select * from Messages where ReceiverID = " + Session["User"].ToString(), myCon);
        messageReader = myCmd.ExecuteReader();
        OleDbCommand myCmd1 = new OleDbCommand("select * from RandomSentences", myCon);
        sayingReader = myCmd1.ExecuteReader();
        lblNumMessage.Text = "You have " + numberMessage() + " messages";
        displaySentence();
    }
    private int numberMessage()
    {
        int num = 0;
        while (messageReader.Read())
        {
            num++;
        }
        return num;
    }

    private void displaySentence()
    {
        Random ran = new Random();
        int idx = ran.Next(1, 54);
        int num = 0;
        while(sayingReader.Read())
        {
            num++;
            if (num == idx)
            {
                lblRandomSaying.Text = sayingReader["Sentence"].ToString();
            }
        }
    }
}