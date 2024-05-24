using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            var listViewItem2 = itemsList.Items.Add("Stemma");
            listViewItem2.ImageKey = "stemma";
            var listViewItem3 = itemsList.Items.Add("Aspida");
            listViewItem3.ImageKey = "aspida";
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
            selectedItem = itemsList.SelectedItems[0];

        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            //selectedItem.Text
        }
    }
}
