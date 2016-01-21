using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectONE
{
    using System;
    using System.Xml;
    public class Engine
    {
        
        public Engine()
        {

        /*
            @Todo:  Rendere Engine richiamabile da un ambiente esterno.
    
        */

        }

        public bool uploadTree(String treeFile)
        {   
            Uploader uploader = new Uploader();
            return uploader.SaveToDB(treeFile);
        }


    }
}