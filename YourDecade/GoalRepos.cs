using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourDecade
{
    public class GoalRepos
    {
        SQLiteConnection database;

        public GoalRepos(string path)
        {
            database = new SQLiteConnection(path);
            database.CreateTable<DataBaseItem>();
        }

        public IEnumerable<DataBaseItem> GetItems()
        {
            return database.Table<DataBaseItem>().ToList();
        }

        public DataBaseItem GetItem(int id)
        {
            return database.Get<DataBaseItem>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<DataBaseItem>(id);
        }
        public int SaveItem(DataBaseItem item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public void EraseDatabase()
        {
            database.DeleteAll<DataBaseItem>();
        }
    }
}
