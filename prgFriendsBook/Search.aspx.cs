using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Search : System.Web.UI.Page
{
    static OleDbConnection myCon;
    static OleDbDataReader CityRdr, CountryRdr, GenderRdr, LanguagesRdr, MessagesRdr, RaceRdr, UserLangRdr, UsersRdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        fillDataReaders();

        if (!Page.IsPostBack)
        {
            fillComboBoxes();
            cboCity.Visible = chkCity.Visible = false;
            //numOfMessage();
        }

    }

    private void numOfMessage()
    {
        int num = 0;
        while(MessagesRdr.Read())
        {
            num += (MessagesRdr["ReceiverID"].ToString() == Session["User"].ToString()) ? 1 : 0;
        }
        lblNumMessage.Text = "You have " + num + " messages";
    }

    private void fillDataReaders()
    {
        myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/friendsbookDB1.mdb"));
        myCon.Open();
        OleDbCommand fillCity = new OleDbCommand("select * from City", myCon);
        CityRdr = fillCity.ExecuteReader();

        OleDbCommand fillCountry = new OleDbCommand("select * from Country", myCon);
        CountryRdr = fillCountry.ExecuteReader();

        OleDbCommand fillGender = new OleDbCommand("select * from Gender", myCon);
        GenderRdr = fillGender.ExecuteReader();

        OleDbCommand fillLanguages = new OleDbCommand("select * from Languages", myCon);
        LanguagesRdr = fillLanguages.ExecuteReader();

        OleDbCommand fillMessages = new OleDbCommand("select * from Messages", myCon);
        MessagesRdr = fillMessages.ExecuteReader();

        OleDbCommand fillRace = new OleDbCommand("select * from Race", myCon);
        RaceRdr = fillRace.ExecuteReader();

        OleDbCommand fillUserLang = new OleDbCommand("select * from UserLang", myCon);
        UserLangRdr = fillUserLang.ExecuteReader();

        OleDbCommand fillUsers = new OleDbCommand("select * from Users", myCon);
        UsersRdr = fillUsers.ExecuteReader();
    }

    private void fillComboBoxes()
    {
        cboCountry.DataTextField = "CountryName";
        cboCountry.DataValueField = "CountryID";
        cboCountry.DataSource = CountryRdr;
        cboCountry.DataBind();

        cboGender.DataTextField = "GenderDesc";
        cboGender.DataValueField = "GenderID";
        cboGender.DataSource = GenderRdr;
        cboGender.DataBind();

        cboRace.DataTextField = "RaceDesc";
        cboRace.DataValueField = "RaceID";
        cboRace.DataSource = RaceRdr;
        cboRace.DataBind();

        cboLanguage.DataTextField = "LanguageDesc";
        cboLanguage.DataValueField = "LanguageID";
        cboLanguage.DataSource = LanguagesRdr;
        cboLanguage.DataBind();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sql = "select UserName, Email, Birthdate from Users";
        if (chkCity.Checked || chkGender.Checked || chkLanguage.Checked || chkRace.Checked)
        {
            sql += " where ";
            if (chkCity.Checked)
            {
                if (cboCity.SelectedValue.ToString() != "0")
                {
                    sql += "CityID = " + cboCity.SelectedValue.ToString() + " and ";
                }
                else
                {
                    // for case that the user selected all cities
                }
            }
            sql += (chkGender.Checked) ? "GenderID = " + cboGender.SelectedValue.ToString() + " and " : "";
            sql += (chkLanguage.Checked) ? "LanguageID = " + cboLanguage.SelectedValue.ToString() + " and " : "";
            sql += (chkRace.Checked) ? "RaceID = " + cboRace.SelectedValue.ToString() + " and " : "";
            sql = sql.Substring(0, sql.Length - 5);
        }

        OleDbCommand searchCmd = new OleDbCommand(sql, myCon);
        OleDbDataReader searchedUsers = searchCmd.ExecuteReader();
        gridSearchResult.DataSource = searchedUsers;
        gridSearchResult.DataBind();
    }

    private void fillCities()
    {
        cboCity.Visible = chkCity.Visible = true;
        cboCity.Items.Clear();
        ListItem temp = new ListItem("All cities", "0");
        cboCity.Items.Add(temp);
        while (CityRdr.Read())
        {
            if(CityRdr["CountryID"].ToString() == cboCountry.SelectedValue.ToString())
            {
                temp = new ListItem(CityRdr["CityDesc"].ToString(), CityRdr["CityID"].ToString());
                cboCity.Items.Add(temp);
            }
        }
    }

    protected void chkCountry_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCountry.Checked)
        {
            chkCity.Visible = cboCity.Visible = true;
            fillCities();
        }
    }

    protected void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillCities();
    }
}