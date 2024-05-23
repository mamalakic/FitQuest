using System;
using System.CodeDom;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitQuest
{
    public partial class CombatSystem : Form
    {
        private readonly int afkMaxSeconds = 10;
        private readonly int inactivityMaxSeconds = 5;
        private int inactivitySeconds = 0;
        // 0 is for afk timer, 1 is for waiting for activity
        private int inactiveTimerType = 0;

        private int combatTimeSeconds = 0;

        private Profile userProfile;
        public CombatSystem(Profile userProfile)
        {
            InitializeComponent();
            this.userProfile = userProfile;
        }

        private void CombatSystem_Load(object sender, EventArgs e)
        {
            // TODO: Get this from outside (based on room node)

            this.enemyHealthBar.Maximum = 100;
            this.enemyHealthBar.Value = this.enemyHealthBar.Maximum;
            this.healthBarLabel.Text = this.enemyHealthBar.Maximum.ToString() + "/" + this.enemyHealthBar.Maximum.ToString();
            this.enemyNameLabel.Text = "Goblin boss";

            this.nodeInfo.Text = getNodeInfo(1);
            PopulateExerciseDataGrid();

            this.secondsPassedLabel.Text = "00:00";
            combatTimer.Interval = 1000;
            combatTimer.Start();

            inactivityTimer.Interval = 1000; // 1 second
            StartInactivityTimer(0);


        }

        private void PopulateExerciseDataGrid()
        {
            DataTable exerciseTable = new DataTable();
            exerciseTable.Columns.Add("Exercise Name", typeof(string));
            exerciseTable.Columns.Add("Sets", typeof(int));
            exerciseTable.Columns.Add("Repetitions", typeof(int));

            foreach (var program in userProfile.Exercises.Values)
            {
                foreach (string exercise in program)
                {
                    DataRow row = exerciseTable.NewRow();
                    row["Exercise Name"] = exercise;
                    row["Sets"] = 3; // Default sets
                    row["Repetitions"] = 10; // Default repetitions
                    exerciseTable.Rows.Add(row);
                }
            }

            exerciseDataGrid.DataSource = exerciseTable;
            exerciseDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }



        private void attackButton_Click(object sender, EventArgs e)
        {
            if (exerciseDataGrid.SelectedRows.Count > 0)
            {
                //get the selected row
                DataGridViewRow selectedRow = exerciseDataGrid.SelectedRows[0];
                int repetitions = Convert.ToInt32(selectedRow.Cells["Repetitions"].Value);
                int sets = Convert.ToInt32(selectedRow.Cells["Sets"].Value);

                //reduce selected exercise's reps
                repetitions--;

                if (repetitions <= 0)
                {
                    //reduce set if done with the set's reps
                    sets--;
                    if (sets <= 0)
                    {
                        //remove exercise from the table when sets are done
                        exerciseDataGrid.Rows.Remove(selectedRow);
                    }
                    else
                    {
                        //restore reps if there are more sets
                        repetitions = 10;
                        selectedRow.Cells["Sets"].Value = sets;
                        selectedRow.Cells["Repetitions"].Value = repetitions;
                    }
                }
                else
                {
                    //update reps if reps there are more than 0
                    selectedRow.Cells["Repetitions"].Value = repetitions;
                }
            }

            // Call function to calculate damage
            int damageDeal = calculateDamage(1, 1, 1);
            reduceEnemyHealth(this.enemyHealthBar, 10);

            if (isEnemyDead(this.enemyHealthBar))
            {
                victorySequence();
            }
        }

        private void victorySequence()
        {
            combatTimer.Stop();
            inactivityTimer.Stop();

            saveBattleRecord();
            Rewards rewardsObj = calculateRewards();
            saveRewardsToAccount(rewardsObj);
            showVictoryScreen(rewardsObj);
        }

        private void defeatSequence()
        {
            saveBattleRecord();
            showDefeatScreen();
        }

        private void saveBattleRecord() 
        {
            // Save in database
        }

        // pass player or smth
        private Rewards calculateRewards()
        {
            // Given lvl and item bonuses get a "points value"
            // lvl + dayStreak
            int rewardPoints = 100;
            // divide that points value in various rewards (handled from rewards object)
            // rewards obj
            return new Rewards(100);
        }

        private void showVictoryScreen(Rewards rewardsObj)
        {
            // Create form or dim screen
            // from the reward obj passed show the rewards

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Visible)
                {
                    ctrl.Visible = false;
                }
            }

            this.Controls.Add(new VictoryScreen(rewardsObj));

        }

        private void showDefeatScreen()
        {
            // Create form or dim screen
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Visible)
                {
                    ctrl.Visible = false;
                }
            }

            this.Controls.Add(new DefeatScreen());
        }

        private bool saveRewardsToAccount(Rewards rewardsObj)
        {
            // Save in database

            // if successful return true
            return true;
        }


        private string getNodeInfo(int node)
        {
            return "Dreary Desert (lvl. 41)";
        }

        private bool isEnemyDead(ProgressBar enemyHealthBar)
        {
            if (enemyHealthBar.Value == 0)
            {
                return true;
            }

            return false;
        }
        private void StartInactivityTimer(int type)
        {
            inactivityTimer.Stop();
            inactiveTimerType = type;
            inactivitySeconds = 0;
            inactivityTimer.Start();

            // show activity confirmation
            if (inactiveTimerType == 1)
            {
                //ShowAfkCheckDialog()
            }
        }

        private bool reduceEnemyHealth(ProgressBar enemyHealthBar, int damage)
        {
            if (enemyHealthBar.Value == 0)
            {
                return false;
            }

            if (enemyHealthBar.Value < damage)
            {
                enemyHealthBar.Value = 0;
                this.healthBarLabel.Text = this.enemyHealthBar.Value.ToString() + "/" + this.enemyHealthBar.Maximum.ToString();
                return true;
            }

            enemyHealthBar.Value -= damage;
            this.healthBarLabel.Text = this.enemyHealthBar.Value.ToString() + "/" + this.enemyHealthBar.Maximum.ToString();
            return true;
        }

        // not int but obj
        private int calculateDamage(int enemyObj, int car, int currentRoom)
        {
            return 10;
        }


        public static string FormatSecondsToMMSS(int totalSeconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
            return timeSpan.ToString(@"mm\:ss");
        }

        private void combatTimer_Tick(object sender, EventArgs e)
        {
            this.combatTimeSeconds++;
            this.secondsPassedLabel.Text = FormatSecondsToMMSS(this.combatTimeSeconds);
        }

        // TODO: Tie inactivity to mouse clicks etc
        private void inactivityTimer_Tick(object sender, EventArgs e)
        {
            inactivitySeconds++;
            switch (this.inactiveTimerType)
            {
                // afk countdown
                case 0:
                    // original 300
                    if (inactivitySeconds == afkMaxSeconds)
                    {
                        afkCheckGroupBox.Visible = true;
                        StartInactivityTimer(1);
                    }
                    break;

                case 1:
                    // original 60
                    afkCheckButton.Text = "I'm here!\n(" + (inactivityMaxSeconds-inactivitySeconds) + "s left)";
                    if (inactivitySeconds == inactivityMaxSeconds)
                    {
                        defeatSequence();
                    }
                    break;

                default:
                    break;
            }

        }

        private void afkCheckButton_Click(object sender, EventArgs e)
        {
            // so he's here
            afkCheckGroupBox.Visible = false;
            StartInactivityTimer(0);
        }

        private void fleeButton_Click(object sender, EventArgs e)
        {
            defeatSequence();
        }
    }
}
