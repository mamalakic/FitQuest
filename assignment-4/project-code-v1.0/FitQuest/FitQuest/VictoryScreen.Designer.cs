namespace FitQuest
{
    partial class VictoryScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VictoryScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GoldValueLabel = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.itemsTitleLabel = new System.Windows.Forms.Label();
            this.itemsListLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Victory!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold";
            // 
            // GoldValueLabel
            // 
            this.GoldValueLabel.AutoSize = true;
            this.GoldValueLabel.Location = new System.Drawing.Point(99, 100);
            this.GoldValueLabel.Name = "GoldValueLabel";
            this.GoldValueLabel.Size = new System.Drawing.Size(35, 13);
            this.GoldValueLabel.TabIndex = 2;
            this.GoldValueLabel.Text = "label3";
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.Transparent;
            this.btnGoBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGoBack.FlatAppearance.BorderSize = 0;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.Location = new System.Drawing.Point(3, 369);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(178, 50);
            this.btnGoBack.TabIndex = 16;
            this.btnGoBack.Text = "Exit";
            this.btnGoBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // itemsTitleLabel
            // 
            this.itemsTitleLabel.AutoSize = true;
            this.itemsTitleLabel.Location = new System.Drawing.Point(236, 82);
            this.itemsTitleLabel.Name = "itemsTitleLabel";
            this.itemsTitleLabel.Size = new System.Drawing.Size(32, 13);
            this.itemsTitleLabel.TabIndex = 17;
            this.itemsTitleLabel.Text = "Items";
            // 
            // itemsListLabel
            // 
            this.itemsListLabel.AutoSize = true;
            this.itemsListLabel.Location = new System.Drawing.Point(236, 99);
            this.itemsListLabel.Name = "itemsListLabel";
            this.itemsListLabel.Size = new System.Drawing.Size(35, 13);
            this.itemsListLabel.TabIndex = 18;
            this.itemsListLabel.Text = "label3";
            // 
            // VictoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemsListLabel);
            this.Controls.Add(this.itemsTitleLabel);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.GoldValueLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VictoryScreen";
            this.Size = new System.Drawing.Size(701, 422);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GoldValueLabel;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Label itemsTitleLabel;
        private System.Windows.Forms.Label itemsListLabel;
    }
}
