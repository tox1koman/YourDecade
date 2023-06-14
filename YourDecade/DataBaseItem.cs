using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace YourDecade
{
    [Table("Groups")]
    public class DataBaseItem
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Subgoals { get; set; }
        public DataBaseItem()
        {
            Subgoals = "";
        }

        public DataBaseItem(string name, string groupName) 
        {
            Name = name;
            GroupName = groupName;
            Subgoals = "";
        }
    }
}
