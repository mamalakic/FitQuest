using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FitQuest
{
    public partial class MainMenu : Form
    {
        private Profile userProfile;

        public MainMenu()
        {
            InitializeComponent();
            // Initialize the user profile (example values)
            userProfile = new Profile("John Doe", 1, 25, 10);
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
            Clan ClanForm = new Clan();
            ClanForm.Show();
            this.Hide();

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }

    public class Profile
    {
        // Variables for character profile
        private string name;
        private int id;
        private int age;
        private int level;
        private Dictionary<string, List<string>> exercises;

        // Constructor to initialize variables
        public Profile(string name, int id, int age, int level)
        {
            this.name = name;
            this.id = id;
            this.age = age;
            this.level = level;
            this.exercises = new Dictionary<string, List<string>>()
            {
                { "Push", new List<string>() },
                { "Pull", new List<string>() },
                { "Legs", new List<string>() }
            };
        }

        public int Age
        {
            get { return age; }
        }

        public int Level
        {
            get { return level; }
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