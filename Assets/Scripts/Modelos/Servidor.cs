using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Modelos
{
    [Serializable]
    public class Servidor
    {
        public string name { get; set; }
        public int number_players { get; set; }
        public string ip_address { get; set; }
        public int port { get; set; }
    }
}
