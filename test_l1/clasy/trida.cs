using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_l1.clasy
{
    public class trida //public !!!
    {
        [PrimaryKey, AutoIncrement] //musí být u databáze
        public int ID { get; set; }
        public string name { get; set; }
        public string autor { get; set; }
        public int strany { get; set; }
        public string ISBN { get; set; }

        public trida()
        {

        }

        public override string ToString() //oreride string (tohle bude vypsáno v seznamu listview)
        {
            return name + " - " + ISBN;   
        }
    }
}
