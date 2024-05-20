using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitQuest
{
    public partial class Clan : Form
    {
        string connectionString;
        private Profile userProfile;
        private string team_id;

        public Clan(Profile userProfile)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
            InitializeComponent();
            this.userProfile = userProfile;
            this.team_id = userProfile.Team_id;

            // Check if team_id is null and perform the desired action
            if (string.IsNullOrEmpty(this.team_id))
            {
               
                //show team making menu
            }
            else
            {
                // Proceed with loading clan details if team_id is not null
                LoadClanDetails();
            }
        }

        private void LoadClanDetails()
        {
            // Code to load clan details based on team_id
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu MainMenuForm = new MainMenu();
            MainMenuForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Clan_Load(object sender, EventArgs e)
        {

        }
    }
}