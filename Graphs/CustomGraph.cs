using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
    public class CustomGraph<T, N, E> : IEnumerable, IGraph<T, N, E>
        where N : INode<T>, new()
        where E : IEdge<T>, new()
    {
        public Dictionary<N, HashSet<E>> AdjacencyList { get; } = new Dictionary<N, HashSet<E>>();

        public CustomGraph() { }
        public CustomGraph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var item in vertices)
                AddVertex(item);

            foreach (var item in edges)
                AddEdge(item);
        }

        protected virtual void AddEdge(Tuple<T, T> item)
        {
            N node = new N();
            node.id = item.Item1;
            E edge = new E();
            edge.node = item.Item2;

            AdjacencyList[node].Add(edge);
        }

        protected virtual void AddVertex(T item)
        {
            N node = new N();
            node.id = item;

            AdjacencyList[node] = new HashSet<E>();
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
