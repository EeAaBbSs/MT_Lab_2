using System;
using System.Collections.Generic;
using System.Text;

namespace MT_Lab_2
{
    class NodeLParent
    {
        public const string CODE = "1";
        public NodeLParent(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node ThisNode { get; set; }
    }
}
