using System;
using System.Diagnostics;

namespace PlannerPath.GUI
{
    class CalculusManagerControl
    {
        /*parameter passing Type, vertex A and vertex B to Engine */
        public CalculusManagerControl (string type, string vertexA, string vertexB)
        {

            var Engine = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "engine.exe",
                    Arguments = "calculus " + type + " " + vertexA + " " + vertexB,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            // uploaded to DB using Engine
            Engine.Start();

            String Output = "";

            while (!Engine.StandardOutput.EndOfStream)
            {
                Output = Output + Environment.NewLine + Engine.StandardOutput.ReadLine();
            }

            returnSum(Output);
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
