using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Gaming
{
    public static partial class Container
    {
        public static ITrack Track;
        public static IGamingApp SGApp;

        static Container()
        {
            Container.Track = new CoreTrack();
        }


    }
}
