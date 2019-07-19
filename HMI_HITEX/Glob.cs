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

        public static int Mpos
        {
            get { return _Mpos; }
            set { _Mpos = value; }
        }
    }
}
