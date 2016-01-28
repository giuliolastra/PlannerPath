﻿using System;
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

        /// <summary>
        /// Interface that asks Calculus Manager Form to show a window with the desidered information (info).
        /// You should only call this function, and not the one in CalculusManagerForm!
        /// </summary>
        /// <param name="info">The string that should be displayed (result of calculus)</param>
        public void returnSum(string info)
        {
            CalculusManagerForm.returnSum(info);
        }
    }


}
