using System;
using System.Collections.Generic;

class Solution
{
    public string solution(int[] A, int[] B)
    {
        int N = A.Length + 1;

        // Create an adjacency list to represent the tree
        List<int>[] tree = new List<int>[N];
        for (int i = 0; i < N; i++)
        {
            tree[i] = new List<int>();
        }

        // Populate the adjacency list
        for (int i = 0; i < A.Length; i++)
        {
            tree[A[i]].Add(B[i]);
            tree[B[i]].Add(A[i]);
        }

        int[] dist = new int[N];
        int[] maxDistNode = new int[2];

        // First BFS to find the farthest node from any starting node
        BFS(tree, 0, dist, maxDistNode);

        int[] dist2 = new int[N];

        // Second BFS starting from the farthest node found in the first BFS
        BFS(tree, maxDistNode[0], dist2, maxDistNode);

        // The maximum distance between two nodes is the diameter of the tree
        int diameter = dist2[maxDistNode[0]];

        // Calculate the result based on the diameter
        int result = CalculateResult(diameter);

        return result.ToString();
    }

    private void BFS(List<int>[] tree, int start, int[] dist, int[] maxDistNode)
    {
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[tree.Length];

        queue.Enqueue(start);
        visited[start] = true;
        dist[start] = 0;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            foreach (var neighbor in tree[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    dist[neighbor] = dist[current] + 1;
                    queue.Enqueue(neighbor);

                    // Keep track of the farthest node and its distance
                    if (dist[neighbor] > dist[maxDistNode[0]])
                    {
                        maxDistNode[0] = neighbor;
                        maxDistNode[1] = dist[neighbor];
                    }
                }
            }
        }
    }

    private int CalculateResult(int diameter)
    {
        // Calculate the result based on the diameter
        if (diameter % 2 == 0)
        {
            return (diameter / 2 + 1) * (diameter / 2);
        }
        else
        {
            return (diameter / 2 + 1) * (diameter / 2) + (diameter / 2 + 1);
        }
    }
}

class Program
{
    static void Main()
    {
        // Sample data
        int[] A = { 0, 1, 1, 3, 3, 6, 7 };
        int[] B = { 1, 2, 3, 4, 5, 3, 5 };

        // Create an instance of the Solution class
        Solution solution = new Solution();

        // Call the solution method with the sample data
        string result = solution.solution(A, B);

        // Print the result
        Console.WriteLine(result);
    }
}
