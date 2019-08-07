using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_HITEX
{
    static class Glob
    {
        private static int _Mpos = 1;
        private static string _User = "";

        public static int Mpos
        {
            get { return _Mpos; }
            set { _Mpos = value; }
        }

        public static string User
        {
            get { return _User; }
            set { _User = value; }
        }
    }
}
