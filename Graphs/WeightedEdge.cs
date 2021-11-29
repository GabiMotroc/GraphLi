using System;

namespace Graphs
{
    public interface IWeightedEdge<T, W> : IEdge<T>
        where W : struct, IConvertible, IComparable<W>
    {
        W weight { get; set;}

        W Add(W number);
    }

    public class WeightedEdge<T, W> : IWeightedEdge<T, W>
        where W : struct, IConvertible, IComparable<W>
    {

        public T node { get; set; }
        public W weight { get; set; }
        public WeightedEdge(T node, W weight)
        {
            this.node = node;
            this.weight = weight;
        }
        public WeightedEdge()
        {

        }

        public W Add(W number)
        {
            dynamic a = number;
            dynamic b = weight;
            return a + b;
        }
    }
}