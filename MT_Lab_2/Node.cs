﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MT_Lab_2
{
    class Node
    {
        public Node(string sign, int value)
        {
            Sign = sign;
            Value = value;
        }
        public Node(Node smallParent, Node largeParent, int value)
        {
            SmallParent = smallParent;
            LargeParent = largeParent;
            Value = value;
        }
        public string CodeBit { get; set; }
        public string Sign { get; set; }
        public Node SmallParent { get; set; }
        public Node LargeParent { get; set; }
        public int Value { get; set; }
    }
}
