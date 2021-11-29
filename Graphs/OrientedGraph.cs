using System;
using System.Collections.Generic;

namespace Graphs
{
    public class OrientedGraph<T> : CustomGraph<T, Node<T>, Edge<T>>
    {
        public OrientedGraph()
        {
        }

        public OrientedGraph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges) 
            : base(vertices, edges)
        {
            
        }
    }
}