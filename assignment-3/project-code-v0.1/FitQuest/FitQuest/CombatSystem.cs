using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class CombatSystem : Form
    {
        // counts in 1
        int secondsAfk = 0;
        public CombatSystem()
        {
            InitializeComponent();
        }

        private void CombatSystem_Load(object sender, EventArgs e)
        {
            // TODO: Get this from outside (based on room node)
            this.enemyHealthBar.Maximum = 100;
            this.enemyHealthBar.Value = this.enemyHealthBar.Maximum;
            this.healthBarLabel.Text = this.enemyHealthBar.Maximum.ToString() + "/" + this.enemyHealthBar.Maximum.ToString();
            this.enemyNameLabel.Text = "Goblin boss";

            this.nodeInfo.Text = getNodeInfo(1);
            this.ticksPassedLabel.Text = "0";
            combatTimer.Interval = 1000;
            combatTimer.Start();
        }

        private void enemyHealthBar_Click(object sender, EventArgs e)
        {

        }

        private void healthBarLabel_Click(object sender, EventArgs e)
        {

        }

        private void enemyNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            // Call function to calculate damage
            int damageDeal = calculateDamage(1, 1, 1);

            reduceEnemyHealth(this.enemyHealthBar, 10);

            if (isEnemyDead(this.enemyHealthBar)) {
                victorySequence();
            }
        }

        private void victorySequence()
        {
            saveBattleRecord();
            calculateRewards();
            saveRewardsToAccount();
            showVictoryScreen();
        }

        private void fleeCombat()
        {
            defeatSequence();
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

        private void calculateRewards()
        {
            // Given lvl and item bonuses get a "points value"
            // divide that points value in various rewards
            // rewards obj
        }

        private void showVictoryScreen()
        {
            // Create form or dim screen
            // from the reward obj passed show the rewards
        }

        private void showDefeatScreen()
        {
            // Create form or dim screen
        }

        private void saveRewardsToAccount()
        {
            // Save in database
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

        private void afkCheck()
        {
            // see if player is ok
            // count 25 seconds if player not respond flee combat
            int secondsNotRespond = 0;

            while (secondsNotRespond < 25)
            {
                // if user press, cancel
            }

            defeatSequence();
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

        private void nodeInfo_Click(object sender, EventArgs e)
        {

        }

        private void combatTimer_Tick(object sender, EventArgs e)
        {
            secondsAfk += 1;
            int seconds = Int32.Parse(this.ticksPassedLabel.Text);
            seconds += 1;
            this.ticksPassedLabel.Text = seconds.ToString();

            if (secondsAfk == 45)
            {
                afkCheck();
            }
        }

        private void playerCharacterPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
