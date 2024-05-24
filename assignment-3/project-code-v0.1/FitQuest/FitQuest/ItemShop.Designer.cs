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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.attributeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemAttributes = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.itemsList.ShowItemToolTips = true;
            this.itemsList.Size = new System.Drawing.Size(785, 602);
            this.itemsList.TabIndex = 4;
            this.itemsList.UseCompatibleStateImageBehavior = false;
            this.itemsList.SelectedIndexChanged += new System.EventHandler(this.itemsList_SelectedIndexChanged);
            // 
            // purchaseButton
            // 
            this.purchaseButton.BackColor = System.Drawing.Color.LimeGreen;
            this.purchaseButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.purchaseButton.Location = new System.Drawing.Point(1242, 587);
            this.purchaseButton.Name = "purchaseButton";
            this.purchaseButton.Size = new System.Drawing.Size(159, 113);
            this.purchaseButton.TabIndex = 6;
            this.purchaseButton.Text = "PURCHASE";
            this.purchaseButton.UseVisualStyleBackColor = false;
            this.purchaseButton.Click += new System.EventHandler(this.purchaseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label1.Location = new System.Drawing.Point(1151, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 55);
            this.label1.TabIndex = 8;
            this.label1.Text = "Item Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FitQuest.Properties.Resources.placeholder;
            this.pictureBox1.Location = new System.Drawing.Point(1195, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 160);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // attributeColumn
            // 
            this.attributeColumn.Text = "Attribute";
            // 
            // valueColumn
            // 
            this.valueColumn.Text = "Value";
            this.valueColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // itemAttributes
            // 
            this.itemAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.attributeColumn,
            this.valueColumn});
            this.itemAttributes.HideSelection = false;
            this.itemAttributes.Location = new System.Drawing.Point(1152, 330);
            this.itemAttributes.Name = "itemAttributes";
            this.itemAttributes.Size = new System.Drawing.Size(249, 251);
            this.itemAttributes.TabIndex = 7;
            this.itemAttributes.UseCompatibleStateImageBehavior = false;
            this.itemAttributes.View = System.Windows.Forms.View.Details;
            this.itemAttributes.SelectedIndexChanged += new System.EventHandler(this.itemAttributes_SelectedIndexChanged);
            // 
            // ItemShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1444, 849);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemAttributes);
            this.Controls.Add(this.purchaseButton);
            this.Controls.Add(this.itemsList);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.clantablabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ItemShop";
            this.Text = "FitQuest";
            this.Load += new System.EventHandler(this.ItemShop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clantablabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListView itemsList;
        private System.Windows.Forms.Button purchaseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColumnHeader attributeColumn;
        private System.Windows.Forms.ColumnHeader valueColumn;
        private System.Windows.Forms.ListView itemAttributes;
    }
}