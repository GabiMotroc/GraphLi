using System;
using System.Numerics;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = GetExampleGraph();

            var algorithms = new Algorithms();

            var result = algorithms.BFS(graph, new Node<int>(10));
            foreach (var item in result)
            {
                System.Console.WriteLine(item.id);
            }

            var weightedGraph = GetWeightedGraphExample();

            result = algorithms.DFS(weightedGraph, new Node<int>(1));
            foreach (var item in result)
            {
                System.Console.WriteLine(item.id);
            }

            var result1 = algorithms.Dijkstra(weightedGraph, new Node<int>(1));
            foreach (var item in result1)
            {
                System.Console.WriteLine(item.Key.id);
                System.Console.WriteLine(item.Value);
            }
        }

        private static WeightedGraph<int, Node<int>, WeightedEdge<int, float>, float> GetWeightedGraphExample()
        {

            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var weightedEdges = new[]{Tuple.Create(1,2,12f), Tuple.Create(1,3,20f),
                Tuple.Create(2,4,3f), Tuple.Create(3,5,9f), Tuple.Create(3,6,2f),
                Tuple.Create(4,7,4f), Tuple.Create(7,5,2f), Tuple.Create(5,8,6f),
                Tuple.Create(5,6,4f), Tuple.Create(8,9,1f), Tuple.Create(8,10,7f),
                Tuple.Create(9,10,30f)};

            var graph = new WeightedGraph<int, Node<int>, WeightedEdge<int, float>, float>(vertices, weightedEdges);
            return graph;
        }

        private static OrientedGraph<int> GetExampleGraph()
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(8,10),
                Tuple.Create(9,10)};

            var graph = new OrientedGraph<int>(vertices, edges);
            return graph;
        }
    }
}
