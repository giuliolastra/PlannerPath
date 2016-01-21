using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectONE.Utility;

namespace ProjectONE.GUI
{
    class CreateTreeControl
    {
        Tree TempTree;
        String Path;

        public CreateTreeControl(int depth, int splitsize, LinkedList<ProjectONE.Utility.Attribute> vertexesAttributes, LinkedList<ProjectONE.Utility.Attribute> edgesAttributes, String path, String treetype)
        {
            this.Path = path;

            this.TempTree = new Tree(depth, splitsize, vertexesAttributes, edgesAttributes, true);
            this.TempTree.type = treetype;

            Engine engine = new Engine();

            if(generateTreeFile() == false)
                MessageBox.Show("Problems while storing file into file");
            else
                MessageBox.Show("Your tree is in the file");
            if(!engine.uploadTree(this.TempTree.getXMLPath()))
                MessageBox.Show("Problems while uploading tree to database");
            else
                MessageBox.Show("Your tree is on the Database");

        }

        public bool generateTreeFile()
        {
            return TempTree.ToFile(this.Path);
        }
    }
}
