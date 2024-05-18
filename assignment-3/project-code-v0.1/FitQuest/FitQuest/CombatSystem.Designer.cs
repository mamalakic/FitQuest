﻿namespace FitQuest
{
    partial class CombatSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombatSystem));
            this.combatTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyPictureBox = new System.Windows.Forms.PictureBox();
            this.enemyHealthBar = new System.Windows.Forms.ProgressBar();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.attackButton = new System.Windows.Forms.Button();
            this.fleeButton = new System.Windows.Forms.Button();
            this.healthBarLabel = new System.Windows.Forms.Label();
            this.playerCharacterPictureBox = new System.Windows.Forms.PictureBox();
            this.enemyNameLabel = new System.Windows.Forms.Label();
            this.nodeInfo = new System.Windows.Forms.Label();
            this.secondsPassedLabel = new System.Windows.Forms.Label();
            this.timeCounterGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCharacterPictureBox)).BeginInit();
            this.timeCounterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // combatTimer
            // 
            this.combatTimer.Tick += new System.EventHandler(this.combatTimer_Tick);
            // 
            // enemyPictureBox
            // 
            this.enemyPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.enemyPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enemyPictureBox.BackgroundImage")));
            this.enemyPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemyPictureBox.Location = new System.Drawing.Point(720, 123);
            this.enemyPictureBox.Name = "enemyPictureBox";
            this.enemyPictureBox.Size = new System.Drawing.Size(203, 355);
            this.enemyPictureBox.TabIndex = 0;
            this.enemyPictureBox.TabStop = false;
            // 
            // enemyHealthBar
            // 
            this.enemyHealthBar.Location = new System.Drawing.Point(691, 94);
            this.enemyHealthBar.Name = "enemyHealthBar";
            this.enemyHealthBar.Size = new System.Drawing.Size(261, 23);
            this.enemyHealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.enemyHealthBar.TabIndex = 1;
            this.enemyHealthBar.Click += new System.EventHandler(this.enemyHealthBar_Click);
            // 
            // inventoryButton
            // 
            this.inventoryButton.Location = new System.Drawing.Point(12, 486);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(154, 54);
            this.inventoryButton.TabIndex = 2;
            this.inventoryButton.Text = "Inventory";
            this.inventoryButton.UseVisualStyleBackColor = true;
            // 
            // attackButton
            // 
            this.attackButton.Location = new System.Drawing.Point(172, 486);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(154, 54);
            this.attackButton.TabIndex = 3;
            this.attackButton.Text = "Attack";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // fleeButton
            // 
            this.fleeButton.Location = new System.Drawing.Point(332, 486);
            this.fleeButton.Name = "fleeButton";
            this.fleeButton.Size = new System.Drawing.Size(154, 54);
            this.fleeButton.TabIndex = 4;
            this.fleeButton.Text = "Flee combat";
            this.fleeButton.UseVisualStyleBackColor = true;
            // 
            // healthBarLabel
            // 
            this.healthBarLabel.AutoSize = true;
            this.healthBarLabel.Location = new System.Drawing.Point(807, 101);
            this.healthBarLabel.Name = "healthBarLabel";
            this.healthBarLabel.Size = new System.Drawing.Size(35, 13);
            this.healthBarLabel.TabIndex = 5;
            this.healthBarLabel.Text = "label1";
            this.healthBarLabel.Click += new System.EventHandler(this.healthBarLabel_Click);
            // 
            // playerCharacterPictureBox
            // 
            this.playerCharacterPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.playerCharacterPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playerCharacterPictureBox.BackgroundImage")));
            this.playerCharacterPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playerCharacterPictureBox.Location = new System.Drawing.Point(30, 153);
            this.playerCharacterPictureBox.Name = "playerCharacterPictureBox";
            this.playerCharacterPictureBox.Size = new System.Drawing.Size(182, 314);
            this.playerCharacterPictureBox.TabIndex = 6;
            this.playerCharacterPictureBox.TabStop = false;
            this.playerCharacterPictureBox.Click += new System.EventHandler(this.playerCharacterPictureBox_Click);
            // 
            // enemyNameLabel
            // 
            this.enemyNameLabel.AutoSize = true;
            this.enemyNameLabel.Location = new System.Drawing.Point(807, 78);
            this.enemyNameLabel.Name = "enemyNameLabel";
            this.enemyNameLabel.Size = new System.Drawing.Size(35, 13);
            this.enemyNameLabel.TabIndex = 7;
            this.enemyNameLabel.Text = "label1";
            this.enemyNameLabel.Click += new System.EventHandler(this.enemyNameLabel_Click);
            // 
            // nodeInfo
            // 
            this.nodeInfo.AutoSize = true;
            this.nodeInfo.Location = new System.Drawing.Point(451, 12);
            this.nodeInfo.Name = "nodeInfo";
            this.nodeInfo.Size = new System.Drawing.Size(35, 13);
            this.nodeInfo.TabIndex = 8;
            this.nodeInfo.Text = "label1";
            this.nodeInfo.Click += new System.EventHandler(this.nodeInfo_Click);
            // 
            // secondsPassedLabel
            // 
            this.secondsPassedLabel.AutoSize = true;
            this.secondsPassedLabel.Location = new System.Drawing.Point(6, 16);
            this.secondsPassedLabel.Name = "secondsPassedLabel";
            this.secondsPassedLabel.Size = new System.Drawing.Size(35, 13);
            this.secondsPassedLabel.TabIndex = 9;
            this.secondsPassedLabel.Text = "label1";
            this.secondsPassedLabel.Click += new System.EventHandler(this.ticksPassedLabel_Click);
            // 
            // timeCounterGroupBox
            // 
            this.timeCounterGroupBox.Controls.Add(this.secondsPassedLabel);
            this.timeCounterGroupBox.Location = new System.Drawing.Point(30, 12);
            this.timeCounterGroupBox.Name = "timeCounterGroupBox";
            this.timeCounterGroupBox.Size = new System.Drawing.Size(200, 35);
            this.timeCounterGroupBox.TabIndex = 10;
            this.timeCounterGroupBox.TabStop = false;
            this.timeCounterGroupBox.Text = "Time";
            // 
            // CombatSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(963, 552);
            this.Controls.Add(this.timeCounterGroupBox);
            this.Controls.Add(this.nodeInfo);
            this.Controls.Add(this.enemyNameLabel);
            this.Controls.Add(this.playerCharacterPictureBox);
            this.Controls.Add(this.healthBarLabel);
            this.Controls.Add(this.fleeButton);
            this.Controls.Add(this.attackButton);
            this.Controls.Add(this.inventoryButton);
            this.Controls.Add(this.enemyHealthBar);
            this.Controls.Add(this.enemyPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CombatSystem";
            this.Text = "FitQuest";
            this.Load += new System.EventHandler(this.CombatSystem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.enemyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCharacterPictureBox)).EndInit();
            this.timeCounterGroupBox.ResumeLayout(false);
            this.timeCounterGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer combatTimer;
        private System.Windows.Forms.PictureBox enemyPictureBox;
        private System.Windows.Forms.ProgressBar enemyHealthBar;
        private System.Windows.Forms.Button inventoryButton;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Button fleeButton;
        private System.Windows.Forms.Label healthBarLabel;
        private System.Windows.Forms.PictureBox playerCharacterPictureBox;
        private System.Windows.Forms.Label enemyNameLabel;
        private System.Windows.Forms.Label nodeInfo;
        private System.Windows.Forms.Label secondsPassedLabel;
        private System.Windows.Forms.GroupBox timeCounterGroupBox;
    }
}