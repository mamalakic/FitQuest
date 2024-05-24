using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            /*
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
    }
}
