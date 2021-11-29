using System;
using System.Collections.Generic;
using System.Reflection;

namespace Graphs
{
    class Algorithms
    {
        public HashSet<N> DFS<T, N, E>(IGraph<T, N, E> graph, N start)
            where N : INode<T>, new()
            where E : IEdge<T>, new()
        {
            var visited = new HashSet<N>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<N>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    var currentNode = new N();
                    currentNode.id = neighbor.node;
                    if (!visited.Contains(currentNode))
                        stack.Push(currentNode);
                }
            }

            return visited;
        }

        public HashSet<N> BFS<T, N, E>(IGraph<T, N, E> graph, N start)
            where N : INode<T>, new()
            where E : IEdge<T>, new()
        {
            var visited = new HashSet<N>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<N>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    var currentNode = new N();
                    currentNode.id = neighbor.node;
                    if (!visited.Contains(currentNode))
                        queue.Enqueue(currentNode);
                }
            }

            return visited;
        }



        public Dictionary<N, W> Dijkstra<T, N, E, W>(IWeightedGraph<T, N, E, W> graph, N start)
            where N : INode<T>, new()
            where E : IWeightedEdge<T, W>, new()
            where W : struct, IConvertible, IComparable<W>
        {
            Dictionary<N, W> distance = new Dictionary<N, W>();
            
            var queue = new Queue<N>();
            queue.Enqueue(start);
            
            var test = new W();
            test = ReadStaticField<W>("MaxValue");

            foreach (var vertex in graph.AdjacencyList.Keys)
            {
                // queue.Enqueue(vertex);
                distance[vertex] = test;
            }
            distance[start] = default(W);

            while(queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var neighbor in graph.AdjacencyList[currentNode])
                {
                    N nextNode = GetTheNodeConnectedByEdge(neighbor);

                    queue.Enqueue(nextNode);

                    UpdateDistanceIfSmaller(distance, currentNode, neighbor, nextNode);

                }
            }
            
            return distance;

            static void UpdateDistanceIfSmaller(Dictionary<N, W> distance, N currentNode, E neighbor, N nextNode)
            {
                if (neighbor.Add(distance[currentNode]).CompareTo(distance[nextNode]) < 0)
                    distance[nextNode] = neighbor.Add(distance[currentNode]);
            }

            static N GetTheNodeConnectedByEdge(E neighbor)
            {
                var nextNode = new N();
                nextNode.id = neighbor.node;
                return nextNode;
            }
        }

        private static W ReadStaticField<W>(string name)
        {
            FieldInfo field = typeof(W).GetField(name,
                BindingFlags.Public | BindingFlags.Static);
            if (field == null)
            {
                // There's no TypeArgumentException, unfortunately. You might want
                // to create one :)
                throw new InvalidOperationException
                    ("Invalid type argument for NumericUpDown<T>: " +
                     typeof(W).Name);
            }
            return (W)field.GetValue(null);
        }
    }
}