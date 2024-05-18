using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitQuest;

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

            // Show the friends list form
            CombatSystem CombatForm = new CombatSystem();
            CombatForm.Show();
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
            this.Hide();
            TrainingProgram TrainingProgramForm = new TrainingProgram(userProfile);
            TrainingProgramForm.Show();
            // Show the training program form
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

        // Constructor to initialize variables
        public Profile(string name, int id, int age, int level)
        {
            this.name = name;
            this.id = id;
            this.age = age;
            this.level = level;
        }

        public int Age
        {
            get { return age; }
        }

        public int Level
        {
            get { return level; }
        }
    }


    
}
