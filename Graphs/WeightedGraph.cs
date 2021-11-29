using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
    public interface IWeightedGraph<T, N, E, W> : IGraph<T, N, E>
        where N : INode<T>, new()
        where E : IWeightedEdge<T, W>, new()
        where W : struct, IConvertible, IComparable<W>
    {

    }
    public class WeightedGraph<T, N, E, W> : CustomGraph<T, N, E>, IWeightedGraph<T, N, E, W>
        where N : INode<T>, new()
        where E : IWeightedEdge<T, W>, new()
        where W : struct, IConvertible, IComparable<W>
    {
        public WeightedGraph()
        {
            
        }
        public WeightedGraph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T, W>> edges)
        {
            foreach (var item in vertices)
                AddVertex(item);

            foreach (var item in edges)
                AddEdge(item);
        }
        
        private void AddEdge(Tuple<T, T, W> item)
        {
            var node = new N();
            node.id = item.Item1;

            var edge = new E();
            edge.node = item.Item2;
            edge.weight = item.Item3;
            AdjacencyList[node].Add(edge);
        }
    }
}