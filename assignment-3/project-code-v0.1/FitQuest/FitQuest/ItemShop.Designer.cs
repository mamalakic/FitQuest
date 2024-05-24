namespace FitQuest
{
    partial class ItemShop
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
            this.clantablabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.itemsList = new System.Windows.Forms.ListView();
            this.purchaseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clantablabel
            // 
            this.clantablabel.AutoSize = true;
            this.clantablabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F);
            this.clantablabel.Location = new System.Drawing.Point(532, 14);
            this.clantablabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clantablabel.Name = "clantablabel";
            this.clantablabel.Size = new System.Drawing.Size(356, 81);
            this.clantablabel.TabIndex = 2;
            this.clantablabel.Text = "Item Shop";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.backButton.Location = new System.Drawing.Point(45, 29);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.backButton.Size = new System.Drawing.Size(189, 83);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // itemsList
            // 
            this.itemsList.HideSelection = false;
            this.itemsList.Location = new System.Drawing.Point(312, 98);
            this.itemsList.Name = "itemsList";
            this.itemsList.Size = new System.Drawing.Size(785, 602);
            this.itemsList.TabIndex = 4;
            this.itemsList.UseCompatibleStateImageBehavior = false;
            this.itemsList.SelectedIndexChanged += new System.EventHandler(this.itemsList_SelectedIndexChanged);
            // 
            // purchaseButton
            // 
            this.purchaseButton.BackColor = System.Drawing.Color.LimeGreen;
            this.purchaseButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.purchaseButton.Location = new System.Drawing.Point(1186, 124);
            this.purchaseButton.Name = "purchaseButton";
            this.purchaseButton.Size = new System.Drawing.Size(127, 88);
            this.purchaseButton.TabIndex = 6;
            this.purchaseButton.Text = "PURCHASE";
            this.purchaseButton.UseVisualStyleBackColor = false;
            this.purchaseButton.Click += new System.EventHandler(this.purchaseButton_Click);
            // 
            // ItemShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1444, 849);
            this.Controls.Add(this.purchaseButton);
            this.Controls.Add(this.itemsList);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.clantablabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ItemShop";
            this.Text = "FitQuest";
            this.Load += new System.EventHandler(this.ItemShop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clantablabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListView itemsList;
        private System.Windows.Forms.Button purchaseButton;
    }
}