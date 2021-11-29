using System;
using System.Collections.Generic;

namespace Graphs
{
    public interface INode<T>
    {
        T id { get; set; }
        bool Equals(object obj);
        int GetHashCode();
    }

    public class Node<T> : INode<T>
    {
        public T id { get; set; }
        public Node(T id)
        {
            this.id = id;

        }
        public Node()
        {
            
        }

        public override bool Equals(object obj)
        {
            return obj is Node<T> node &&
                   EqualityComparer<T>.Default.Equals(id, node.id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
    }
}
