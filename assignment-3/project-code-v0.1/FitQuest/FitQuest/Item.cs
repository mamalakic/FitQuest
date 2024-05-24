using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitQuest
{
    public class Item
    {
        private Hashtable stats = new Hashtable();
        private string name;
        private int value, quantity;
        public enum categories
        {
           Weapon = 0,
           Armour = 1,
           Consumable = 2
        };
        private categories category;

        public Item() {//TODO
            stats.Add("Damage", 5);
        }

        public categories getCategory()
        {
            return this.category;
        }
    }
}
