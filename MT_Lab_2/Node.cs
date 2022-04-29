using System;
using System.Collections.Generic;
using System.Text;

namespace MT_Lab_2
{
    class Node
    {
        public Node(int originValue)
        {
            OriginValue = originValue;
        }
        public Node(int smallValue, int largeValue)
        {
            Value = smallValue + largeValue;
        }
        public string OriginCode { get; set; }
        public int OriginValue { get; set; }
        public NodeSParent SmallParent { get; set; }
        public NodeLParent LargeParent { get; set; }
        public int Value { get; set; }
        //public Node Child { get; set; }
        //public string Code { get; set; }
    }
}
