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

        /* create tree */
        public CreateTreeControl(int depth, int splitsize, LinkedList<ProjectONE.Utility.Attribute> vertexesAttributes, LinkedList<ProjectONE.Utility.Attribute> edgesAttributes, String path, String treetype)
        {
            String messageBoxTitle = "Create Tree";

            this.Path = path;

            this.TempTree = new Tree(depth, splitsize, vertexesAttributes, edgesAttributes, true);
            this.TempTree.type = treetype;

            Engine engine = new Engine();

            //Generate tree file and...
            if(this.generateTreeFile() == false)
                MessageBox.Show("Problems while storing file into file. Wait for upload to DB...",messageBoxTitle);
            else
                MessageBox.Show("Your tree is in the file. Wait for upload to DB...",messageBoxTitle);
            //and then upload it to DB
            if(!engine.uploadTree(this.TempTree.getXMLPath()))
                MessageBox.Show("Problems while uploading tree to database",messageBoxTitle);
            else
                MessageBox.Show("Your tree is on the Database",messageBoxTitle);

        }
        
        /* this function calls the method that effectively builds the XML file */
        public bool generateTreeFile()
        {

            return TempTree.ToFile(this.Path);
        }
    }
}
