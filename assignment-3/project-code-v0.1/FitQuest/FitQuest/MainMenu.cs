using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace FitQuest
{
    
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            this.Hide();

            // Show the friends list form
            CombatSystem CombatForm = new CombatSystem();
            CombatForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

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

        }
    }

    public class Profile
    {
        // Variables for character profile
        private string name;
        private int age;
        private int level;
        private bool hasProgram;

        // Constructor to initialize variables
        public Profile(string name, int age, int level)
        {
            this.name = name;
            this.age = age;
            this.level = level;
        }

        // Method to display character profile
        public bool getProfileHasProgram()
        {
            return hasProgram;
        }
    }
}
