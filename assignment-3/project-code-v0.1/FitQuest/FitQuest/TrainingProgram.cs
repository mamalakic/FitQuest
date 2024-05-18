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
    
    public partial class TrainingProgram : Form
    {
        public TrainingProgram()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            this.Hide();

            
        }

       
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            this.Hide();

          
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            // Show the friends list form
            
        }
        private void getProfile(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void createProfileForm(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void createDangerWarning(object sender, DataGridViewCellEventArgs e)
        {

        }


    }


}
