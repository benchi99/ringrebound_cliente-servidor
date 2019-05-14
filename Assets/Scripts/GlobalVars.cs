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
    }
}
