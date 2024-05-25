using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FitQuest
{
    public partial class Map : Form
    {
        private Profile userProfile;
        private Level currentLevel;

        public Map(Profile userProfile)
        {
            this.userProfile = userProfile;
            InitializeComponent();
            CreateNodes();
        }


        private void CreateNodes()
        {
            // Define node positions and level numbers
            Dictionary<Point, int> nodePositions = new Dictionary<Point, int>
            {
                { new Point(700, 500), 1 },
                { new Point(462, 519), 2 },
                { new Point(192, 532), 3 },
                { new Point(80, 430), 4 },
                { new Point(342, 367), 5 },
                { new Point(618, 354), 6 },
                { new Point(560, 234), 7 },
                { new Point(345, 265), 8 },
                { new Point(71, 250), 9 },
                { new Point(115, 95), 10 },
                { new Point(315, 79), 11 },
                { new Point(498, 46), 12 }
            };

            foreach (var entry in nodePositions)
            {
                Point pos = entry.Key;
                int level = entry.Value;

                Button nodeButton = new Button
                {
                    Size = new Size(30, 30),
                    Location = pos,
                    BackColor = Color.Red,
                    Tag = level, // Set the Tag property to the level number
                    FlatStyle = FlatStyle.Flat
                };

                nodeButton.Click += NodeButton_Click;
                nodeButton.MouseEnter += NodeButton_MouseEnter;
                nodeButton.MouseLeave += NodeButton_MouseLeave;

                pictureBox1.Controls.Add(nodeButton);
            }
        }

        private void NodeButton_Click(object sender, EventArgs e)
        {
            Button node = sender as Button;
            if (node != null)
            {
                int levelNumber = Convert.ToInt32(node.Tag); // Convert Tag to int

                try
                {
                    currentLevel = new Level(levelNumber);
                    MessageBox.Show($"Level {currentLevel.Count}selected!\nEnemy: {currentLevel.EnemyName}\nHP: {currentLevel.EnemyHP}\n\nClick on Commence Battle to start Combat!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void NodeButton_MouseEnter(object sender, EventArgs e)
        {
            Button node = sender as Button;
            if (node != null)
            {
                node.BackColor = Color.Blue; // Highlight on hover
            }
        }

        private void NodeButton_MouseLeave(object sender, EventArgs e)
        {
            Button node = sender as Button;
            if (node != null)
            {
                node.BackColor = Color.Red; // Reset color when not hovering
            }
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
                CombatSystem CombatForm = new CombatSystem(userProfile, currentLevel);
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

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu MainMenuForm = new MainMenu();
            MainMenuForm.Show();
            this.Hide();
        }
    }
}
