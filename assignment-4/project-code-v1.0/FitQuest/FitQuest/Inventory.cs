﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Configuration;

namespace FitQuest
{
    public partial class Inventory : Form
    {

        private Profile userProfile;
        private string id;
        private int Gold;
        private bool accessedFromCombatSystem = false;
        private MainMenu mainmenu;

        public Inventory(MainMenu mainmenu, Profile userProfile, bool accessedFromCombatSystem)
        {
            this.mainmenu = mainmenu;
            this.userProfile = userProfile;
            this.id = userProfile.id;
            this.Gold = userProfile.Gold;
            InitializeComponent();
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.accessedFromCombatSystem = accessedFromCombatSystem;

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadInventoryData(accessedFromCombatSystem);
            if (accessedFromCombatSystem)
            {
                button2.Visible = false;
                button6.Visible = false;
            }

            else
            {
                button5.Visible = false;
            }
        }

        public void LoadInventoryData(bool accessedFromCombatSystem)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT il.Name, il.Category, il.Description, inv.quantity, ia.Attribute, ia.Value
                FROM Inventory inv
                JOIN ItemList il ON inv.itemID = il.ID
                LEFT JOIN ItemAttributes ia ON il.ID = ia.ID
                WHERE inv.playerID = @playerID AND inv.quantity > 0";

                    if (accessedFromCombatSystem)
                    {
                        query += " AND il.Category = 'Consumable'";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@playerID", this.id);
                        Console.WriteLine("Query prepared.");

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            listView1.Items.Clear();

                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                string category = reader["Category"].ToString();
                                string description = reader["Description"].ToString();
                                string quantity = reader["quantity"].ToString();
                                string attribute = reader["Attribute"]?.ToString() ?? "N/A";
                                string value = reader["Value"]?.ToString() ?? "N/A";

                                ListViewItem item = new ListViewItem(name);
                                item.SubItems.Add(category);
                                item.SubItems.Add(description);
                                item.SubItems.Add(quantity);
                                item.SubItems.Add(attribute);
                                item.SubItems.Add(value);
                                listView1.Items.Add(item);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                textBox6.Text = selectedItem.SubItems[0].Text;
                textBox7.Text = selectedItem.SubItems[1].Text;
                textBox8.Text = selectedItem.SubItems[2].Text;
                textBox9.Text = selectedItem.SubItems[3].Text;
                textBox10.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to equip.");
                return;
            }

            ListViewItem selectedItem = listView1.SelectedItems[0];
            string category = selectedItem.SubItems[1].Text;

            if (category == Item.categories.Consumable.ToString())
            {
                MessageBox.Show("Please select a non-consumable item to equip.");
                return;
            }

            int quantity;
            if (!int.TryParse(selectedItem.SubItems[3].Text, out quantity))
            {
                MessageBox.Show("Invalid quantity for the selected item.");
                return;
            }

            string name = selectedItem.SubItems[0].Text;
            MessageBox.Show($"You equipped: {name}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to use.");
                return;
            }

            ListViewItem selectedItem = listView1.SelectedItems[0];
            string category = selectedItem.SubItems[1].Text;

            if (category != Item.categories.Consumable.ToString())
            {
                MessageBox.Show("Please select a consumable item to use.");
                return;
            }

            int quantity;
            if (!int.TryParse(selectedItem.SubItems[3].Text, out quantity))
            {
                MessageBox.Show("Invalid quantity for the selected item.");
                return;
            }

            string name = selectedItem.SubItems[0].Text;
            MessageBox.Show($"You used: {name}");

            //Update quantity in the database or remove item if quantity reaches zero
            if (quantity > 0)
            {
                quantity--;

                if (quantity == 0)
                {
                    //Delete the item from the database
                    string deleteQuery = "DELETE FROM Inventory WHERE itemID = @itemID AND playerID = @playerID";
                    ExecuteNonQuery(deleteQuery, selectedItem);
                    listView1.Items.Remove(selectedItem);
                }
                else
                {
                    //Update the quantity in the database
                    string updateQuery = "UPDATE Inventory SET quantity = @quantity WHERE itemID = @itemID AND playerID = @playerID";
                    ExecuteNonQuery(updateQuery, selectedItem, quantity);
                    selectedItem.SubItems[3].Text = quantity.ToString();
                }
            }
            else
            {
                MessageBox.Show("This item has already been used up.");
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int quantity = int.Parse(selectedItem.SubItems[3].Text);
                int value = int.Parse(selectedItem.SubItems[4].Text);

                if (quantity > 0)
                {
                    quantity--;

                    if (quantity == 0)
                    {
                        // Delete the item from the database
                        string deleteQuery = "DELETE FROM Inventory WHERE Name = @name AND Category = @category AND Description = @description";
                        ExecuteNonQuery(deleteQuery, selectedItem);
                        listView1.Items.Remove(selectedItem);
                    }
                    else
                    {
                        // Update the quantity in the database
                        string updateQuery = "UPDATE Inventory SET Quantity = @quantity WHERE Name = @name AND Category = @category AND Description = @description";
                        ExecuteNonQuery(updateQuery, selectedItem, quantity);
                        selectedItem.SubItems[3].Text = quantity.ToString();
                    }

                    this.Gold += value;
                    string updateGoldQuery = "UPDATE Profiles SET gold = @gold WHERE id = @id";
                    UpdateUserGold(updateGoldQuery, this.id, this.Gold);

                    MessageBox.Show($"You just got {value} gold. Item sold successfully.");
                }
            }
        }
        private void ExecuteNonQuery(string query, ListViewItem item, int? quantity = null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Retrieve item details
                    string itemName = item.SubItems[0].Text;
                    string itemCategory = item.SubItems[1].Text;
                    string itemDescription = item.SubItems[2].Text;

                    // Get itemID from ItemList table
                    string itemIdQuery = "SELECT ID FROM ItemList WHERE Name = @name AND Category = @category AND Description = @description";

                    using (SQLiteCommand itemIdCommand = new SQLiteCommand(itemIdQuery, connection))
                    {
                        itemIdCommand.Parameters.AddWithValue("@name", itemName);
                        itemIdCommand.Parameters.AddWithValue("@category", itemCategory);
                        itemIdCommand.Parameters.AddWithValue("@description", itemDescription);

                        var itemId = itemIdCommand.ExecuteScalar();

                        if (itemId != null)
                        {
                            // Update quantity in Inventory table
                            string updateInventoryQuery = "UPDATE Inventory SET quantity = quantity - @quantity WHERE itemID = @itemID AND playerID = @playerID";

                            using (SQLiteCommand updateInventoryCommand = new SQLiteCommand(updateInventoryQuery, connection))
                            {
                                updateInventoryCommand.Parameters.AddWithValue("@itemID", itemId);
                                updateInventoryCommand.Parameters.AddWithValue("@playerID", userProfile.id);
                                updateInventoryCommand.Parameters.AddWithValue("@quantity", quantity ?? 1); // If quantity is not provided, assume 1
                                updateInventoryCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Item not found in ItemList.");
                        }
                    }
                }
            }
        }

        private void UpdateUserGold(string query, string userId, int newGoldAmount)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@gold", newGoldAmount);
                        command.Parameters.AddWithValue("@id", userId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating gold: " + ex.Message);
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (accessedFromCombatSystem)
            {

            }
            else
            {
                mainmenu.Show();
                mainmenu.refreshMainMenu();
            }
            this.Hide();
        }
    }
}