using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectONE
{
    using System;
    using System.Xml;
    using Utility;
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
            uploader.SaveToDB(treeFile);
            return true;
        }

        public String performCalculus(string type, string vertexA, string vertexB)
        {
            Calculus calculus = new Calculus();
            return calculus.PathCalculus(type, vertexA, vertexB);
        }


    }
}