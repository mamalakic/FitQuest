using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FitQuest
{
    public partial class MainMenu : Form
    {
        private Profile userProfile;

        public MainMenu()
        {
            InitializeComponent();

            // Initialize the user profile with only the id
            userProfile = new Profile("John Doe");

            // Load the rest of the profile details from the database
            string connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
            userProfile.LoadProfileFromDatabase(connectionString, textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            this.Hide();

            // Check if exercises are populated
            if (userProfile.AreExercisesPopulated())
            {
                Console.WriteLine("Training program is chosen:");
                foreach (var category in userProfile.Exercises.Keys)
                {
                    Console.WriteLine($"{category} exercises: {string.Join(", ", userProfile.Exercises[category])}");
                }
                // Show the friends list form
                CombatSystem CombatForm = new CombatSystem();
                CombatForm.Show();
            }
            else
            {
                Console.WriteLine("Training program not chosen");
                this.Hide();
                TrainingProgram TrainingProgramForm = new TrainingProgram(userProfile);
                TrainingProgramForm.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            this.Hide();

            // Show the friends list form
            FriendsList FriendsListForm = new FriendsList();
            FriendsListForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Clan ClanForm = new Clan(userProfile);
            ClanForm.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show the friends list form
            Inventory invBackpack = new Inventory();
            invBackpack.Show();
        }
    }

    public class Profile
    {
        // Variables for character profile
        public string id;
        private int age;
        private int level;
        private string team_id;
        private Dictionary<string, List<string>> exercises;

        // Constructor to initialize variables with only id
        public Profile(string user_id)
        {
            this.id = user_id;
            this.exercises = new Dictionary<string, List<string>>()
            {
                { "Push", new List<string>() },
                { "Pull", new List<string>() },
                { "Legs", new List<string>() }
            };
        }

        // Method to populate profile details from database
        public void LoadProfileFromDatabase(string connectionString, System.Windows.Forms.TextBox textBox1)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT age, level, team_id FROM Profiles WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        age = reader.GetInt32(reader.GetOrdinal("age"));
                        level = reader.GetInt32(reader.GetOrdinal("level"));
                        team_id = reader.IsDBNull(reader.GetOrdinal("team_id")) ? null : reader.GetString(reader.GetOrdinal("team_id"));

                        // Populate textBox1 with the profile info
                        textBox1.Text = $"ID: {id}, Age: {age}, Level: {level}, Team ID: {(team_id ?? "null")}";
                    }
                    else
                    {
                        // If no profile exists with the given ID
                        textBox1.Text = "There isn't a profile with that name.";
                    }
                }
            }
        }

        // Getters, setters
      

        public int Age
        {
            get { return age; }
        }

        public int Level
        {
            get { return level; }
        }

        public string Team_id
        {
            get { return team_id; }
        }

        public Dictionary<string, List<string>> Exercises
        {
            get { return exercises; }
            set { exercises = value; }
        }

        public bool AreExercisesPopulated()
        {
            return exercises.Any(kv => kv.Value != null && kv.Value.Count > 0);
        }
    }

    public class Exercise
    {
        public string Name { get; set; }
    }

}