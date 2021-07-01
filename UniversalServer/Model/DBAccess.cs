using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UniversalServer.Model
{
    public delegate EventHandler ErrorEventHandler(string msg);
    public class DBAccess
    {
        public event ErrorEventHandler ErrorMessage;
       
        public void InsertData(TempValue t, HumidValue h, PressureValue p, DateTime dt, string ipa)
        {
           
            
        }
    }
}
