﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MT_Lab_2
{
    class NodeSParent
    {
        public NodeSParent(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node Node { get; set; }
        public string Code { get; set; }
    }
}
