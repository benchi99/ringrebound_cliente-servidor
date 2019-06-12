using Assets.Scripts.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utils
{
    /// <summary>
    /// Ya que la implementación de Unity para serializar y deserializar JSONs es
    /// una jodidísma basura, voy a tener que hacerlo YO MISMO. GRACIAS POR NADA
    /// UNITY DE LOS COJONES. ADIOS HORAS DE SUEÑOOOOOOOO.
    /// </summary>
    public class ServerJsonParser
    {
        public static List<Servidor> Parse(string data)
        {
            List<Servidor> servidores = new List<Servidor>();

            string cleandata = data.Substring(1, data.Length - 2);

            string[] objects = cleandata.Split('}');

            foreach (string obj in objects)
            {
                if (obj.Length > 0)
                {
                    string[] singleobject = obj.Split(',');
                    string name = "" , ip = "";
                    int max_players = 0, port = 0000;
                
                    foreach (string item in singleobject)
                    {
                        string value = item.Substring(item.IndexOf(':') + 1);
                        if (item.StartsWith("{\"name"))
                        {
                            name = value.Replace('"', ' ').Trim();
                        }
                        else if (item.StartsWith("\"ip_"))
                        {
                            ip = value.Replace('"', ' ').Trim();
                        }
                        else if (item.StartsWith("\"number"))
                        {
                            max_players = int.Parse(value);
                        }
                        else if (item.StartsWith("\"port"))
                        {
                            port = int.Parse(value);
                        }

                    }

                    Servidor servidor = new Servidor();
                    servidor.name = name;
                    servidor.ip_address = ip;
                    servidor.number_players = max_players;
                    servidor.port = port;

                    servidores.Add(servidor);
                }
            }

            return servidores;

        }
        
    }
}
