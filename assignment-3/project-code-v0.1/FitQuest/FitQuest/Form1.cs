using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitQuest
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        public static void Main(string[] args)
        {
            Profile profile = new Profile("John Doe", 25, 5);

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
