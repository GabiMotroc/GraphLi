
using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
    public interface IGraph<T, N, E> : IGraph
        where N : INode<T>, new()
        where E : IEdge<T>, new()
    {
        Dictionary<N, HashSet<E>> AdjacencyList { get; }

        IEnumerator GetEnumerator();
    }

    public interface IGraph

    {

    }

}
