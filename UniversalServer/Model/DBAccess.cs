using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;

namespace UniversalServer.Model
{
    public delegate EventHandler ErrorEventHandler(string msg);
    public class DBAccess
    {

        NpgsqlConnection conn = new NpgsqlConnection("Server=Balarama.db.elephantsql.com; Username=vkizatgz;Password=NBribTWPJUXRh05uZE3WZkmDhHF-K4Um; Database=vkizatgz");


        public event ErrorEventHandler ErrorMessage;


        public void Database()
        //postgres://vkizatgz:NBribTWPJUXRh05uZE3WZkmDhHF-K4Um@balarama.db.elephantsql.com/vkizatgz
        {
            conn.Open();
        }

        public void InsertData(TempValue t, HumidValue h, PressureValue p, DateTime dt, string ipa)
        {
            var cmd = new NpgsqlCommand("INSERT INTO messwerte(temparatur, luftfeuchtigkeit, luftdruck) VALUES(@t,@h,@p)", conn);

            cmd.Parameters.AddWithValue("t", @t.Value);
            cmd.Parameters.AddWithValue("h", @h.Value);
            cmd.Parameters.AddWithValue("p", @p.Value);
            
            cmd.ExecuteNonQuery();

        }


    }
}
