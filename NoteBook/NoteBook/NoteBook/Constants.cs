using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace NoteBook
{
    public class Constants
    {
        public const string DatabaseFileName = "MyNote.db3";



        public const SQLite.SQLiteOpenFlags Flags =
            //Open Database in Read And Write Mode
            SQLite.SQLiteOpenFlags.ReadWrite |

            //Create Database if it doesnt exist

            SQLite.SQLiteOpenFlags.Create |

            //Enable multiThreading Database Access

            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get {

                var basePath = Environment.GetFolderPath
                    (Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            
            }
           
        }






    }
}
