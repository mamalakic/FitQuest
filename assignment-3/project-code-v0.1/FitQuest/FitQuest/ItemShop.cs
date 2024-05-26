using System;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace FitQuest
{
    public partial class ItemShop : Form
    {
        private ListViewItem selectedItem;
        private ImageList imageList; // Declare imageList here
        private Profile userProfile;

        public ItemShop(Profile userProfile)
        {
            InitializeComponent();

            imageList = new ImageList // Initialize imageList here
            {
                ImageSize = new Size(64, 64)
            };

            // Add images from resources
            imageList.Images.Add("Flaming sword", Properties.Resources.Flaming_Sword);
            imageList.Images.Add("King of the castle", Properties.Resources.King_of_the_castle);
            imageList.Images.Add("Grenade", Properties.Resources.Grenade);

            itemsList.LargeImageList = imageList;
            itemsList.View = View.LargeIcon;
            itemsList.DrawItem += ItemsList_DrawItem;

            ListViewItem item = new ListViewItem("Strength");
            item.SubItems.Add("+5");
            itemAttributes.Items.Add(item);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu MainMenuForm = new MainMenu();
            MainMenuForm.Show();
            this.Hide();
        }

        private void ItemShop_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM ItemList"; // Ensure this matches your table name
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            itemsList.Items.Clear();
                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                string category = reader["Category"].ToString();
                                string description = reader["Description"].ToString();
                                int gold = Convert.ToInt32(reader["Gold"]); // Retrieve gold value

                                ListViewItem item = new ListViewItem(name);
                                item.SubItems.Add(category); // Adding the category as a sub-item
                                item.SubItems.Add(gold.ToString()); // Adding gold value as a sub-item
                                item.ImageKey = name.ToLower(); // Ensure the key matches the added images
                                item.ToolTipText = description;

                                itemsList.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void itemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemsList.SelectedItems.Count > 0)
            {
                // Reset back color for previously selected item
                if (selectedItem != null)
                {
                    selectedItem.BackColor = Color.Transparent; // Reset back color
                }

                selectedItem = itemsList.SelectedItems[0];
                selectedItem.BackColor = Color.LightBlue; // Change back color for selected item

                // Display selected item's image in PictureBox
                string imageName = selectedItem.ImageKey;
                if (!string.IsNullOrEmpty(imageName) && imageList.Images.ContainsKey(imageName))
                {
                    pictureBox1.Image = imageList.Images[imageName];
                }
                else
                {
                    pictureBox1.Image = null; // No image found, clear PictureBox
                }
            }
        }


        private void purchaseButton_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                // Retrieve the gold value of the selected item
                int goldValue = Convert.ToInt32(selectedItem.SubItems[2].Text);

                // Deduct the gold value from the user's gold (assuming user's gold is stored in a variable named 'userGold')
                userGold -= goldValue;

                // Update user's gold in the database or wherever it's stored

                MessageBox.Show($"Purchased: {selectedItem.Text}");
            }
        }
        private void itemAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ItemsList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false; // Prevent the default drawing

            // Calculate image drawing position
            int imageX = e.Bounds.Left + (e.Bounds.Width - e.Item.ImageList.ImageSize.Width) / 2;
            int imageY = e.Bounds.Top;

            // Debugging: Check if image key exists
            if (e.Item.ImageList.Images.ContainsKey(e.Item.ImageKey))
            {
                e.Graphics.DrawImage(e.Item.ImageList.Images[e.Item.ImageKey], imageX, imageY);
            }
            else
            {
                MessageBox.Show($"ImageKey '{e.Item.ImageKey}' not found in ImageList.");
            }

            // Calculate text drawing position
            int textX = e.Bounds.Left + (e.Bounds.Width - (int)e.Graphics.MeasureString(e.Item.Text, e.Item.Font).Width) / 2;
            int textY = imageY + e.Item.ImageList.ImageSize.Height;

            // Calculate maximum text width based on item width
            int maxTextWidth = e.Bounds.Width;

            // Check if text width exceeds maximum
            if (e.Graphics.MeasureString(e.Item.Text, e.Item.Font).Width > maxTextWidth)
            {
                // Calculate maximum characters that can fit in the first row
                int maxCharsFirstRow = (int)(((double)maxTextWidth / e.Graphics.MeasureString(e.Item.Text, e.Item.Font).Width) * e.Item.Text.Length);

                // Determine text for the first and second row
                string firstRowText = e.Item.Text.Substring(0, maxCharsFirstRow);
                string secondRowText = e.Item.Text.Substring(maxCharsFirstRow);

                // Calculate position for the first row text to ensure it's centered
                int firstRowTextX = e.Bounds.Left + (e.Bounds.Width - (int)e.Graphics.MeasureString(firstRowText, e.Item.Font).Width) / 2;

                // Draw first row text
                e.Graphics.DrawString(firstRowText, e.Item.Font, Brushes.Black, firstRowTextX, textY);

                // Calculate second row text position
                textY += (int)e.Graphics.MeasureString(firstRowText, e.Item.Font).Height;
                textX = e.Bounds.Left + (e.Bounds.Width - (int)e.Graphics.MeasureString(secondRowText, e.Item.Font).Width) / 2;

                // Draw second row text
                e.Graphics.DrawString(secondRowText, e.Item.Font, Brushes.Black, textX, textY);
            }
            else
            {
                // Draw single row text if it fits within bounds
                textX = e.Bounds.Left + (e.Bounds.Width - (int)e.Graphics.MeasureString(e.Item.Text, e.Item.Font).Width) / 2;
                e.Graphics.DrawString(e.Item.Text, e.Item.Font, Brushes.Black, textX, textY);
            }

            // Draw category below item name with some spacing
            if (e.Item.SubItems.Count > 1)
            {
                SizeF categoryNameSize = e.Graphics.MeasureString(e.Item.SubItems[1].Text, e.Item.Font);
                textY += (int)categoryNameSize.Height + 2; // Add some spacing
                textX = e.Bounds.Left + (e.Bounds.Width - (int)categoryNameSize.Width) / 2;
                e.Graphics.DrawString(e.Item.SubItems[1].Text, e.Item.Font, Brushes.Red, textX, textY);
            }
        }

    }
}
