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

        ServerController sc = new ServerController();
        Options opt = new Options();


        int runtime_limit = 0;
        int runtime_count = 0;
        int runtime_mode = 1; // Es soll drei Modi geben: 1: Durchgehend Daten Schreiben, 2: Nur nach Befehl eine bestimmte Anzahl schreiben, 3: Auf Befehl im Modus zwei warten.
        int runtime_mode_check = 1; // Muss immer mit aktuellen runtime_mode gleich sein. 

        bool runtime_unlimited = true;
        bool runtime_stop = false;

        NpgsqlConnection conn = new NpgsqlConnection("Server=Balarama.db.elephantsql.com; Username=vkizatgz;Password=NBribTWPJUXRh05uZE3WZkmDhHF-K4Um; Database=vkizatgz");
        public event ErrorEventHandler ErrorMessage;


        public void Database_Connect()
        //postgres://vkizatgz:NBribTWPJUXRh05uZE3WZkmDhHF-K4Um@balarama.db.elephantsql.com/vkizatgz
        {
            conn.Open();
            opt.Show();
        }

        public void InsertData(TempValue t, HumidValue h, PressureValue p, DateTime dt, string ipa)
        {

            //MessageBox.Show(Convert.ToString(runtime_stop));
            if (runtime_stop == true)
            {
                runtime_mode = 3;
            }
            if (runtime_stop == false)
            {
                runtime_mode = runtime_mode_check;
            }


            #region Statemachine
            switch (runtime_mode)
            {

                //Lade Daten durchgehend hoch
                case 1:
                    var cmd_a = new NpgsqlCommand("INSERT INTO messwerte(temparatur, luftfeuchtigkeit, luftdruck) VALUES(@t,@h,@p)", conn);
                    cmd_a.Parameters.AddWithValue("t", @t.Value);
                    cmd_a.Parameters.AddWithValue("h", @h.Value);
                    cmd_a.Parameters.AddWithValue("p", @p.Value);

                    cmd_a.ExecuteNonQuery();
                    break;

                //Nur die vordefinierte Anzahl an Daten hochladen
                case 2:
                    if (runtime_limit != runtime_count)
                    {
                        var cmd = new NpgsqlCommand("INSERT INTO messwerte(temparatur, luftfeuchtigkeit, luftdruck) VALUES(@t,@h,@p)", conn);
                        cmd.Parameters.AddWithValue("t", @t.Value);
                        cmd.Parameters.AddWithValue("h", @h.Value);
                        cmd.Parameters.AddWithValue("p", @p.Value);
                        cmd.ExecuteNonQuery();
                        runtime_count += 1;

                        if (runtime_limit == runtime_count)
                        {
                            runtime_stop = true;
                            runtime_count = 0;
                        }
                    }
                    break;

                // Warte auf Uploadbefehl
                case 3:
                    break;

            }
            #endregion

            #region backupcode
            /*var cmd = new NpgsqlCommand("INSERT INTO messwerte(temparatur, luftfeuchtigkeit, luftdruck) VALUES(@t,@h,@p)", conn);

            cmd.Parameters.AddWithValue("t", @t.Value);
            cmd.Parameters.AddWithValue("h", @h.Value);
            cmd.Parameters.AddWithValue("p", @p.Value);
            
            cmd.ExecuteNonQuery();*/
            #endregion
            Update();
        }

        public void Receive_Settings(int runtime, bool setting)
        {
            runtime_limit = runtime;
            runtime_unlimited = setting;
        }

        public void Mode_Switch(int new_mode)
        {
            runtime_mode = new_mode;
            runtime_mode_check = runtime_mode;
        }

        public void Get_Runtime()
        {
            runtime_stop = opt.Mode_Stop();

        }

        public void Update()
        {
            Get_Runtime();
        }

    }
}
