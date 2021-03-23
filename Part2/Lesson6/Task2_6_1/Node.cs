using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_6_1
{
    public class Node //Вершина
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } //исходящие связи

        public override bool Equals(object obj)
        {
            var _retval = false;

            if (obj is null)
            {
                return _retval;
            }         

            var node = (Node)obj;
            _retval = (Value == node.Value);

            for (int i = 0; i < Edges.Count; i++)
            {
                _retval = _retval && ((node.Edges[i]?.Node?.Value ?? -1) == Edges[i].Node.Value);
            }

            return _retval;
        }
    }

}