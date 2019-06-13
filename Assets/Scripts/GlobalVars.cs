using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Esta clase contendrá variables comunes a todos
    /// los scripts.
    /// </summary>
    public class GlobalVars
    {
        //Controla si el jugador ha activado el menú de pausa.
        public static bool IsInPauseMenu = false;

        public static readonly FullScreenMode[] fullScreenModes = {
            FullScreenMode.ExclusiveFullScreen,
            FullScreenMode.FullScreenWindow,
            FullScreenMode.MaximizedWindow,
            FullScreenMode.Windowed
        };

        public static float sensibilidadRaton = 150;

        public static readonly string BASE_WEBURL = "http://damnation.ddns.net:8000/ringrebound/api/gameservers/";

        public static readonly string LOCAL_WEBURL = "http://localhost:8000/ringrebound/api/gameservers/";

        public static int serverId = 0;
    }
}
