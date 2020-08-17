using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.Linq;


using NoteBook.Models;
namespace NoteBook.Data
{
    public class NoteItemDatabase
    {



        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>

        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public NoteItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }


        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Note).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Note)).ConfigureAwait(false);
                }
            }
        }

        public Task<List<Note>> GetItemsAsync()
        { 
            return Database.Table<Note>().ToListAsync();
        }


        public Task<List<Note>> SearchItemAsync(string str)
        {
            var NormalisedQuery = str?.ToLower() ?? "";
            var SearchResults= Database.Table<Note>().Where(f => f.Title.ToLower().Contains(str) || f.Notes.ToLower().Contains(NormalisedQuery)).ToListAsync();
                    return SearchResults;
        }
            
      


        public Task<int> SaveItemAsync(Note item)
            {
                if (item.ID != 0)
                {
                    return Database.UpdateAsync(item);
                }
                else
                {
                    return Database.InsertAsync(item);
                }

            }

            public Task<int> DeleteItemAsync(Note item)
            {
                return Database.DeleteAsync(item);
            }
        public Task<int> DeleteItemsAsync()
        {
            return Database.DeleteAllAsync<Note>();
        }



    }

}

