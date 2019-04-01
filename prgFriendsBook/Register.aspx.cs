using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Register : System.Web.UI.Page
{
    static OleDbConnection myCon;
    static OleDbDataReader UsersRdr;
    static OleDbDataReader GenderRdr;
    static OleDbDataReader LanguagesRdr;
    static OleDbDataReader RaceRdr;
    static OleDbDataReader CountryRdr;
    static OleDbDataReader CityRdr;
    static int countryID;
    static string idValidated;

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
    }

    private void newCityEnrollment(bool isNewCity)
    {
        lblEnrolCity.Visible = txtNewCity.Visible = btnNewCity.Visible = isNewCity;
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
        fillCboCity();
        for(int i=1950; i<=2019; i++)
        {
            cboYear.Items.Add(i.ToString());
        }
        for(int i=1; i<=12; i++)
        {
            cboMonth.Items.Add(i.ToString());
        }
        fillCboDay();
        countryID = 0;
    }

    protected void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        newCityEnrollment(true);
        fillCboCity();
    }

    private void fillCboCity()
    {
        cboCity.Items.Clear();
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
            cboCity.Items.Add("There is no city data in " + cboCountry.SelectedItem.Text + ". Please add your city below.");
            newCityEnrollment(true);
        }
    }

    protected void btnIDValidate_Click(object sender, EventArgs e)
    {        
        lblValidateID.Text = (isValidateID()) ? "You can use this ID " : "ID already exists";
    }

    private bool isValidateID()
    {
        bool validated = true;
        while (UsersRdr.Read())
        {
            if (UsersRdr["UserName"].ToString() == txtUserID.Text.Trim())
            {
                validated = false;
                break;
            }
        }
        return validated;
    }

    protected void btnNewCity_Click(object sender, EventArgs e)
    {
        if (txtNewCity.Text != "")
        {
            bool ok2insert = true;

            while(CityRdr.Read())
            {
                if(CityRdr["CityDesc"].ToString() == txtNewCity.Text.Trim())
                {
                    ok2insert = false;
                    break;
                }
            }
            if (ok2insert)
            {
                string sql = "insert into City (CityDesc, CountryID) Values (@cityname, @countryid)";
                OleDbCommand insertCity = new OleDbCommand(sql, myCon);
                insertCity.Parameters.AddWithValue("cityname", txtNewCity.Text);
                insertCity.Parameters.AddWithValue("countryid", cboCountry.SelectedValue.ToString());
                int executeInsertCity = insertCity.ExecuteNonQuery();
                if(executeInsertCity>0)
                {
                    lblAddCity.Text = "New City Successfully Added : \n" + txtNewCity.Text + "\nPlease select the city from the city list above.";
                    txtNewCity.Text = "";
                }
                else
                {
                    lblAddCity.Text = "Your New city, " + txtNewCity.Text + " is not added successfully. Please try again.";
                }
                OleDbCommand fillCity = new OleDbCommand("select * from City", myCon);
                CityRdr = fillCity.ExecuteReader();
                fillCboCity();
            }
            else
            {
                lblAddCity.Text = "The city is already registered. Please select the city from the city list above.";
            }
        }
        else
        {
            lblAddCity.Text = "Please Enter your city name first";
        }
    }
    private bool isValidCity()
    {
        bool validcity = (cboCity.SelectedItem.Text.Contains("Please add your city below.")) ? false : true;
        return validcity;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isValidateID() && isValidCity())
        {
            string email = txtEmail.Text.Trim();
            string fname = txtFirstName.Text.Trim();
            string lname = txtLastName.Text.Trim();
            string gender = cboGender.SelectedValue.ToString();
            string race = cboRace.SelectedValue.ToString();
            string language = cboLanguage.SelectedValue.ToString();
            string city = cboCity.SelectedValue.ToString();
            string birthdate = cboYear.SelectedItem.Text + "-" + cboMonth.SelectedItem.Text + "-" + cboDay.SelectedItem.Text;
            string username = txtUserID.Text.Trim();
            string password = txtPassword.Text.Trim();

            string sql = "insert into Users " +
                "(Email, FirstName, LastName, GenderID, RaceID, CityID, LanguageID, BirthDate, UserName, [Password])" +
                " values (@email, @fname, @lname, @gender, @race, @city, @language, @birthdate, @username, @password)";
            OleDbCommand insertCommand = new OleDbCommand(sql, myCon);
            insertCommand.Parameters.AddWithValue("email", email);
            insertCommand.Parameters.AddWithValue("fname", fname);
            insertCommand.Parameters.AddWithValue("lname", lname);
            insertCommand.Parameters.AddWithValue("gender", gender);
            insertCommand.Parameters.AddWithValue("race", race);
            insertCommand.Parameters.AddWithValue("city", city);
            insertCommand.Parameters.AddWithValue("language", language);
            insertCommand.Parameters.AddWithValue("birthdate", birthdate);
            insertCommand.Parameters.AddWithValue("username", username);
            insertCommand.Parameters.AddWithValue("password", password);

            int executeInsertCommand = insertCommand.ExecuteNonQuery();
            
            if(executeInsertCommand > 0)
            {
                lblRegMessage.Text = "New user " + txtFirstName.Text + " is successfully registered.";
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblRegMessage.Text = "New user is not successfully registered. Please try again.";
            }
        }
        if (!isValidCity())
        {
            lblRegMessage.Text = "Please select your city from above and try again.";
        }
        else
        {
            lblRegMessage.Text = "Please validate your ID and try registering again";
        }

    }

    protected void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillCboDay();
    }
    private void fillCboDay()
    {
        int numdays = 0;
        if ((isLeapYear(Convert.ToInt32(cboYear.SelectedItem.Text))) && cboMonth.Text == "2")
        {
            numdays = 29;
        }
        else
        {
            if ((cboMonth.Text == "1") || (cboMonth.Text == "3") || (cboMonth.Text == "5") || (cboMonth.Text == "7") || (cboMonth.Text == "8") || (cboMonth.Text == "10") || (cboMonth.Text == "12"))
            {
                numdays = 31;
            }
            if ((cboMonth.Text == "4") || (cboMonth.Text == "6") || (cboMonth.Text == "9") || (cboMonth.Text == "11"))
            {
                numdays = 30;
            }
            if (cboMonth.Text == "2")
            {
                numdays = 28;
            }
        }
        for (int i = 1; i <= numdays; i++)
        {
            cboDay.Items.Add(i.ToString());
        }
    }
    private bool isLeapYear(int year)
    {
        bool leapyear = false;
        leapyear = (year % 4 == 0) ? true : false;
        return leapyear;
    }
}
