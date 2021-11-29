using System;
using System.Collections.Generic;

namespace Graphs
{
    public class UndirectedGraph <T, N, E> : CustomGraph<T, N, E>
        where N : INode<T>, new()
        where E : IEdge<T>, new()
    {
        public UndirectedGraph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges) : base(vertices, edges)
        {
            
        }
        protected override void AddEdge(Tuple<T, T> item)
        {
            N node = new N();
            E edge = new E();

            node.id = item.Item1;
            edge.node = item.Item2;
            AdjacencyList[node].Add(edge);

            N node1 = new N();
            E edge1 = new E();
            node1.id = item.Item2;
            edge1.node = item.Item1;
            AdjacencyList[node1].Add(edge1);

        }
    }
}