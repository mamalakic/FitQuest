using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
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
        private SQLiteConnection connection;


        public Clan(Profile userProfile)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
            this.connection = new SQLiteConnection(connectionString); // Initialize the connection

            InitializeComponent();
            this.userProfile = userProfile;
            this.team_id = userProfile.Team_id;
            

            // Check if team_id is null
            if (true)
                //if (string.IsNullOrEmpty(this.team_id))               DELETE THIS WHEN DONE WITH CREATING/JOINING CLAN CODE-----------------------------------
            {
                notinaclanPanel.Visible = true;
                createaclanPanel.Visible = false;
                //show team making menu
            }
            else
            {
                //load clan details if team_id is not null (user is in a clan)
                LoadClanCamp();
            }
        }

        private void LoadClanCamp()
        {
            clancampPanel.Visible = true;
            clannamecampLabel.Text = "Clan's " + team_id + " Camp";

        }

        private void backButton_Click(object sender, EventArgs e)
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

        private void createaclanbutton_Click(object sender, EventArgs e)
        {
           
        }

        private void confirmcreateButton_Click_1(object sender, EventArgs e)
        {
            string teamName = clannameTextBox.Text.Trim(); // Get the team name from the textbox
            bool formGood = false;
            connection.Open();
            formGood = checkForm(teamName);
            if (formGood)
            {

                string updateQuery = $"UPDATE Profiles SET team_id = @TeamID WHERE id = '" + userProfile.id + "';";

                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@TeamID", teamName);
                    updateCommand.ExecuteNonQuery();
                }

                string insertQuery = "INSERT INTO teams (team_id) VALUES ('" + teamName+ "');";

                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {
                    insertCommand.ExecuteNonQuery();
                }


                invitefriendspanel.Visible = true;
                createaclanPanel.Visible = false;

                // SQL query to get friends
                string query = "SELECT * FROM Friends";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);

                // DataTable to hold the data
                DataTable dt = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);

                // Add a CheckBox column to the DataTable
                DataColumn selectColumn = new DataColumn("Select", typeof(bool));
                dt.Columns.Add(selectColumn);

                // Set the DataSource of the DataGridView
                dataGridView1.DataSource = dt;

                // Set DataGridView properties for the checkbox
                dataGridView1.Columns["Select"].DisplayIndex = 0;
                dataGridView1.Columns["Select"].HeaderText = "Select";

            }

            // Close the connection
            connection.Close();
        }

        private bool checkForm(string teamName)
        {
            // Check if the team name is empty
            if (string.IsNullOrWhiteSpace(teamName))
            {
                // Show an error message or handle the empty name case as needed
                MessageBox.Show("Please enter a valid team name.");
                return false;
            }

          

            // SQL command to check if the team name exists in the "teams" table
            string query = "SELECT COUNT(*) FROM teams WHERE team_id = '" + teamName + "';";

            // Create and execute the command
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                // Add parameter for the team id
                command.Parameters.AddWithValue("@TeamID", teamName);

                // Execute the query
                int count = Convert.ToInt32(command.ExecuteScalar());
                Debug.WriteLine(count);
                // If count is greater than 0, it means the name already exists
                if (count > 0)
                {
                    MessageBox.Show("The name is already taken.");
                    return false;
                }
                else
                {
                    this.team_id = teamName;
                    return true;
                }
            }
        }


        private void createaclanbutton_Click_1(object sender, EventArgs e)
        {
            notinaclanPanel.Visible = false;
            createaclanPanel.Visible = true;
        }

        private void createaclanLabel_Click(object sender, EventArgs e)
        {

        }

        private void namerrorLabel_Click(object sender, EventArgs e)
        {

        }

        

        private void invitedoneButton_Click(object sender, EventArgs e)
        { 
            // Initialize a list to keep selected names
            List<string> selectedNames = new List<string>();

            // Loop through the DataGridView rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Check if the CheckBox is selected
                if (row.Cells["Select"].Value != DBNull.Value && row.Cells["Select"].Value != null)
                {
                    // Get the friend's name and add to the list
                    string name = row.Cells["friendID"].Value.ToString(); // Adjust column name as necessary
                    selectedNames.Add(name);
                }
            }

            // Convert the list of names to a single string
            string selectedNamesString = string.Join(", ", selectedNames);

            insertIntoTeam(selectedNamesString);
            invitefriendspanel.Visible = false;
            LoadClanCamp();
        }

        private void insertIntoTeam(string Names)
        {

        }
    }
    }

