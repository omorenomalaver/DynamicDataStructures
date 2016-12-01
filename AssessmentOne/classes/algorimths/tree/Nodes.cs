using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentOne.classes.algorimths.tree
{
    /// <summary>
    /// this class contains the objects of the binary tree object
    /// </summary>
    public class Nodes
    {
        public Nodes left;
        public Nodes right;
        public Nodes parent;
        public bool root;
        public int info;

        public Nodes()
        {
            root = false;
        }
    }
}
