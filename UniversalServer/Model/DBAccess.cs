using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace UniversalServer.Model
{
    public delegate EventHandler ErrorEventHandler(string msg);
    public class DBAccess
    {
        public event ErrorEventHandler ErrorMessage;

        public void Database()
            //postgres://vkizatgz:NBribTWPJUXRh05uZE3WZkmDhHF-K4Um@balarama.db.elephantsql.com/vkizatgz
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=Balarama.db.elephantsql.com; Username=vkizatgz;Password=NBribTWPJUXRh05uZE3WZkmDhHF-K4Um; Database=vkizatgz");
            conn.Open();
        }
       
        public void InsertData(TempValue t, HumidValue h, PressureValue p, DateTime dt, string ipa)
        {
           
            
        }
    }
}
