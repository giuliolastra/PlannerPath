using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PlannerPath.Utility;
using System.Diagnostics;

namespace PlannerPath.GUI
{
    class CreateTreeControl
    {
        Tree TempTree;
        String Path;

        /* create tree */
        public CreateTreeControl(int depth, int splitsize, LinkedList<PlannerPath.Utility.Attribute> vertexesAttributes, LinkedList<PlannerPath.Utility.Attribute> edgesAttributes, String path, String treetype)
        {
            String messageBoxTitle = "Create Tree";

            this.Path = path;

            this.TempTree = new Tree(depth, splitsize, vertexesAttributes, edgesAttributes, true);
            this.TempTree.type = treetype;


            //Generate tree file and...
            if (this.generateTreeFile() == false)
            {
                MessageBox.Show("Problems while storing file into file. Please click 0K and wait for upload to DB", messageBoxTitle);
            }
            else
            {
                MessageBox.Show("Your tree is in the file. Please click 0K and wait for upload to DB", messageBoxTitle);

                var Engine = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "engine.exe",
                        Arguments = "upload " + this.TempTree.getXMLPath(),
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
                MessageBox.Show(Output, messageBoxTitle);
            }

        }
        
        /* this function calls the method that effectively builds the XML file */
        public bool generateTreeFile()
        {

            return TempTree.ToFile(this.Path);
        }
    }
}
