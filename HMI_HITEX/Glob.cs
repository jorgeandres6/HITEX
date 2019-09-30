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
        private static string _User_type = "";

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

        public static string User_type
        {
            get { return _User_type; }
            set { _User_type = value; }
        }
    }
}
