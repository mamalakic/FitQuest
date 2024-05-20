using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FitQuest
{
    public partial class TrainingProgram : Form
    {
        private int userAge;
        private int userLevel;
        string connectionString;
        private Profile userProfile;

        public TrainingProgram(Profile userProfile)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
            InitializeComponent();
            userAge = userProfile.Age;
            userLevel = userProfile.Level;
            this.userProfile = userProfile;

            // Populate the buttons with exercise programs
            getPrograms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            chooseProgram("Push");
            CombatSystem CombatForm = new CombatSystem();
            CombatForm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            chooseProgram("Pull");
            CombatSystem CombatForm = new CombatSystem();
            CombatForm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Hide the current form (main menu)
            chooseProgram("Legs");
            CombatSystem CombatForm = new CombatSystem();
            CombatForm.Show();
            this.Hide();
        }
        public class Exercise
        {
            public string Name { get; set; }
        }
        private void getPrograms()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM TrainingProgram";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                DataTable dt = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);


                var (pushExercises, pullExercises, legExercises) = calculateTrainingProgram(dt, userAge, userLevel);


                // Convert exercise names to Exercise objects
                List<Exercise> exercises = pushExercises.Select(ex => new Exercise { Name = ex }).ToList();
                // Print them in the grid views
                dataGridView1.DataSource = exercises;

                exercises = pullExercises.Select(ex => new Exercise { Name = ex }).ToList();
                dataGridView2.DataSource = exercises;

                exercises = legExercises.Select(ex => new Exercise { Name = ex }).ToList();
                dataGridView3.DataSource = exercises;
            }
        }

        private (List<string> pushExercises, List<string> pullExercises, List<string> legExercises) calculateTrainingProgram(DataTable dt, int age, int level)
        {
            var pushExercises = new List<string>();
            var pullExercises = new List<string>();
            var legExercises = new List<string>();

            // Filter exercises based on age and level
            foreach (DataRow row in dt.Rows)
            {
                string exerciseName = row["exercise_name"].ToString();
                string category = row["muscle"].ToString();

                //  categorize exercises based on muscle category
                if (category == "Push")
                {
                    pushExercises.Add(exerciseName);
                }
                else if (category == "Pull")
                {
                    pullExercises.Add(exerciseName);
                }
                else if (category == "Legs")
                {
                    legExercises.Add(exerciseName);
                }
            }


            return (pushExercises, pullExercises, legExercises);
        }


        private void TrainingProgram_Load(object sender, EventArgs e)
        {
            // You can perform any necessary initialization here
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

   

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            chooseProgram("makeOwnProgram");
        }

        private void chooseProgram(string text)  //This can be modified to it chooses programs based on age, level, weight etc.
        {
            if (text == "Push")
            {
                userProfile.Exercises["Push"] = (dataGridView1.DataSource as List<Exercise>)?.Select(ex => ex.Name).ToList();
            }
            else if (text == "Pull")
            {
                userProfile.Exercises["Pull"] = (dataGridView2.DataSource as List<Exercise>)?.Select(ex => ex.Name).ToList();
            }
            else if (text == "Legs")
            {
                userProfile.Exercises["Legs"] = (dataGridView3.DataSource as List<Exercise>)?.Select(ex => ex.Name).ToList();
            }
            else if (text == "makeOwnProgram")
            {
               
            }
            else if (text == "choosePastProgram")
            {

            }
        }



    }

    
}