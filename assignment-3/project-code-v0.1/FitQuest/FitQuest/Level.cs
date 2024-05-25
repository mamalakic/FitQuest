using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;

namespace FitQuest
{
    public class Level
    {
        public int Count { get; private set; }
        public string EnemyName { get; private set; }
        public int EnemyHP { get; private set; }
        public int RewardGold { get; private set; }
        public int RewardPoints { get; private set; }
        public int LevelNum { get; private set; }

        public Level (int count)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
            string query = "SELECT * FROM level WHERE count = @count";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@count", count);
                connection.Open();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.Count = Convert.ToInt32(reader["count"]);
                        this.EnemyName = reader["enemy_name"].ToString();
                        this.EnemyHP = Convert.ToInt32(reader["enemy_hp"]);
                        this.RewardGold = Convert.ToInt32(reader["reward_gold"]);
                        this.RewardPoints = Convert.ToInt32(reader["reward_points"]);
                        this.LevelNum = count;
                    }
                    else
                    {
                        throw new Exception("Level not found");
                    }
                }
            }
        }
    }
}
