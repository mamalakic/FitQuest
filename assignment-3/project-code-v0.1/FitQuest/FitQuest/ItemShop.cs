using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FitQuest
{
    public partial class ItemShop : Form
    {
        private ListViewItem selectedItem;

        public ItemShop()
        {
            InitializeComponent();
            var imageList = new ImageList();
            imageList.Images.Add("Flaming Sword", Image.FromFile(@"C:\Users\Achilleas\Documents\GitHub\FitQuest\assignment-3\project-code-v0.1\FitQuest\spathi.png"));
            imageList.Images.Add("\"King of the castle\" pin hahaha", Image.FromFile(@"C:\Users\Achilleas\Documents\GitHub\FitQuest\assignment-3\project-code-v0.1\FitQuest\stemma.png"));
            imageList.Images.Add("Grenade \"Grenade\"", Image.FromFile(@"C:\Users\Achilleas\Documents\GitHub\FitQuest\assignment-3\project-code-v0.1\FitQuest\aspida.png"));
            itemsList.LargeImageList = imageList;
            imageList.ImageSize = new Size(64, 64);

            itemsList.DrawItem += ItemsList_DrawItem;
            /*
            var imageList = new ImageList();
            imageList.Images.Add("spathi", Image.FromFile(@"C:\Users\Achilleas\Documents\GitHub\FitQuest\assignment-3\project-code-v0.1\FitQuest\spathi.png"));
            imageList.Images.Add("stemma", Image.FromFile(@"C:\Users\Achilleas\Documents\GitHub\FitQuest\assignment-3\project-code-v0.1\FitQuest\stemma.png"));
            imageList.Images.Add("aspida", Image.FromFile(@"C:\Users\Achilleas\Documents\GitHub\FitQuest\assignment-3\project-code-v0.1\FitQuest\aspida.png"));
            itemsList.LargeImageList = imageList;
            imageList.ImageSize = new Size(64, 64);

            var listViewItem1 = itemsList.Items.Add("Spathi");
            listViewItem1.ImageKey = "spathi";
            listViewItem1.ToolTipText = "Einai ena spathi";
            var listViewItem2 = itemsList.Items.Add("Stemma");
            listViewItem2.ImageKey = "stemma";
            var listViewItem3 = itemsList.Items.Add("Aspida");
            listViewItem3.ImageKey = "aspida";

            //itemAttributes.Items.Add("Attribute").SubItems.Add("Damage");
            //itemAttributes.Items.Add("Value").SubItems.Add("+5");
            
            ListViewItem item1 = new ListViewItem("Something");
            item1.SubItems.Add("SubItem1a");
            item1.SubItems.Add("SubItem1b");
            item1.SubItems.Add("SubItem1c");

            ListViewItem item2 = new ListViewItem("Something2");
            item2.SubItems.Add("SubItem2a");
            item2.SubItems.Add("SubItem2b");
            item2.SubItems.Add("SubItem2c");
            
            itemAttributes.Items.AddRange(new ListViewItem[] { item1, item2 });
            */
            ListViewItem item = new ListViewItem("Strength");
            item.SubItems.Add("+5");
            itemAttributes.Items.Add(item);

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //leaves the clan camp
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

                                ListViewItem item = new ListViewItem(name);
                                item.SubItems.Add(category); // HOW TO???
                                item.ImageKey = name;
                                item.ToolTipText = description;

                                itemsList.Items.Add(item);
                                //TODO category?
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
                selectedItem = itemsList.SelectedItems[0];
            }

        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            //selectedItem.Text
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

            // Draw item image
            e.Graphics.DrawImage(e.Item.ImageList.Images[e.Item.ImageKey], imageX, imageY);

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
            SizeF categoryNameSize = e.Graphics.MeasureString(e.Item.SubItems[1].Text, e.Item.Font);
            textY += (int)categoryNameSize.Height + 2; // Add some spacing
            textX = e.Bounds.Left + (e.Bounds.Width - (int)categoryNameSize.Width) / 2;
            e.Graphics.DrawString(e.Item.SubItems[1].Text, e.Item.Font, Brushes.Red, textX, textY);
        }


    }
}
