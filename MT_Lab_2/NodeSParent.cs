using System;
using System.Collections.Generic;
using System.Text;

namespace MT_Lab_2
{
    class NodeSParent
    {
        public const string CODE = "0"; 
        public NodeSParent(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node ThisNode { get; set; }
    }
}
