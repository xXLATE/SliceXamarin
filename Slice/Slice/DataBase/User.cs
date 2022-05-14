using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Slice.DataBase
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
