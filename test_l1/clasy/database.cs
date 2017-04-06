using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_l1.clasy
{
  public class database

        /*Tohle je datázový script od malýho důležité je aby byl public a jinak ho celí skopírujete a upravíte všude ve <> názec třídy plus to opravíte v SQL příkazech v []*/
    {
        // SQLite connection
        private SQLiteAsyncConnection Database; 

        public database(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<trida>().Wait();
        }
        // Query
        public Task<List<trida>> GetItemsAsync()
        {
            return Database.Table<trida>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<trida>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<trida>("SELECT * FROM [trida] ");
        }
        public Task<List<trida>> GetItemssearch(string item) //přidávný item pro vyhledávač příkaz vybere ze třidy [] nešco [] - tohle je atribut v třídě kterému odpovídá předávaný string "item"
        {
            return Database.QueryAsync<trida>("SELECT * FROM [trida] WHERE [ISBN]" + item );
        }


        public Task<int> SaveItemAsync(trida item)
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

        public Task<List<trida>> DeleteItemAsync(int item)
        {
            return Database.QueryAsync<trida>("DELETE FROM [trida] WHERE [ID] = " + item); //to samé jako u vyhledávače jen neprovede select, ale vymazání 
        }
    }
}
