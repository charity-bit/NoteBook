using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace NoteBook.Models
{
    public class Note
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }



    }
}
