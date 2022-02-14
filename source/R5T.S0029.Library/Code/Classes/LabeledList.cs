using System;
using System.Collections.Generic;


namespace R5T.S0029.Library
{
    public class LabeledList<T> : ILabeled
    {
        public string Label { get; set; }
        public List<T> Items { get; } = new List<T>();
    }
}
