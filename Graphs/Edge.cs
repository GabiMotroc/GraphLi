using System.Collections.Generic;

namespace Graphs
{
    public interface IEdge<T>
    {
        T node { get; set; }
    }

    public class Edge<T> : IEdge<T>
    {
        public T node { get; set; }
        public Edge(T node)
        {
            this.node = node;
        }
        public Edge()
        {

        }
    }
}
