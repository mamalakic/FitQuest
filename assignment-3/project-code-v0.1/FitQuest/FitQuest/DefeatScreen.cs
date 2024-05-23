﻿using System;
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
    public partial class DefeatScreen : UserControl
    {
        public DefeatScreen()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            this.Hide();

            // Show the menu form
            MainMenu MenuForm = new MainMenu();
            MenuForm.Show();
        }
    }
}
