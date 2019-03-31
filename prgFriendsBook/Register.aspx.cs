using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Register : System.Web.UI.Page
{
    OleDbConnection myCon;
    OleDbDataReader UsersRdr;
    OleDbDataReader GenderRdr;
    OleDbDataReader LanguagesRdr;
    OleDbDataReader RaceRdr;
    OleDbDataReader CountryRdr;
    OleDbDataReader CityRdr;
    int countryID;
    bool idValidated;

    protected void Page_Load(object sender, EventArgs e)
    {
        initialize();
        if(!Page.IsPostBack)
        {
            fillCboBoxes();
        }
    }

    private void initialize()
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

        OleDbCommand fillRace = new OleDbCommand("select * from Race", myCon);
        RaceRdr = fillRace.ExecuteReader();

        OleDbCommand fillUsers = new OleDbCommand("select * from Users", myCon);
        UsersRdr = fillUsers.ExecuteReader();

        idValidated = false;
        countryID = 0;
    }

    private void fillCboBoxes()
    {
        while(GenderRdr.Read())
        {
            ListItem temp = new ListItem();
            temp.Text = GenderRdr["GenderDesc"].ToString();
            temp.Value = GenderRdr["GenderID"].ToString();
            cboGender.Items.Add(temp);
        }
        while(LanguagesRdr.Read())
        {
            ListItem temp = new ListItem();
            temp.Text = LanguagesRdr["LanguageDesc"].ToString();
            temp.Value = LanguagesRdr["LanguageID"].ToString();
            cboLanguage.Items.Add(temp);
        }
        while (RaceRdr.Read())
        {
            ListItem temp = new ListItem();
            temp.Text = RaceRdr["RaceDesc"].ToString();
            temp.Value = RaceRdr["RaceID"].ToString();
            cboRace.Items.Add(temp);
        }
        while (CountryRdr.Read())
        {
            ListItem temp = new ListItem();
            temp.Text = CountryRdr["CountryName"].ToString();
            temp.Value = CountryRdr["CountryID"].ToString();
            cboCountry.Items.Add(temp);
        }
        cboCity.Items.Add("Please select the country first");
        for(int i=1950; i<=2019; i++)
        {
            cboYear.Items.Add(i.ToString());
        }
        for(int i=1; i<=12; i++)
        {
            cboMonth.Items.Add(i.ToString());
        }
        cboDay.Items.Add("Please select the month first");
    }

    protected void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillCboCity();
    }

    private void fillCboCity()
    {
        while (CityRdr.Read())
        {
            if (CityRdr["CountryID"].ToString() == cboCountry.SelectedValue.ToString())
            {
                ListItem temp = new ListItem();
                temp.Text = CityRdr["CityDesc"].ToString();
                temp.Value = CityRdr["CityID"].ToString();
                cboCity.Items.Add(temp);
            }
        }
        if (cboCity.Items.Count == 0)
        {
            cboCity.Items.Add("There is no city data in " + cboCountry.SelectedItem.Text + ". Please add your city.");
        }
    }
}