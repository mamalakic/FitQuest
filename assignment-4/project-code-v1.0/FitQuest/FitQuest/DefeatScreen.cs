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
        private MainMenu mainmenu;
        public DefeatScreen(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainmenu = mainMenu;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            this.Hide();

            // Show the menu form
            
            mainmenu.Show();
            // close parent form
            this.Hide(); 
            this.FindForm().Close();
        }


    }
}
