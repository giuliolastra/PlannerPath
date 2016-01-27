using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectONE.GUI
{
    class CalculusManagerControl
    {
        public CalculusManagerControl (string type, string vertexA, string vertexB)
        {
            Engine engine = new Engine();
            engine.performCalculus(type, vertexA, vertexB);
        }
    }


}
