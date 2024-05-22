using System;
using System.Collections.Generic;
using System.Drawing;

public class PathFinder
{
    public List<Point> FindPathTo(Point position, Point location, float[,] heightMap)
    {
        int rows = heightMap.GetLength(0);
        int cols = heightMap.GetLength(1);

        PriorityQueue<Node, float> openList = new PriorityQueue<Node, float>();
        HashSet<Node> closedList = new HashSet<Node>();

        Node startNode = new Node(position, null);
        openList.Enqueue(startNode, 0);

        Dictionary<Point, Node> pathMap = new Dictionary<Point, Node>();
        pathMap[position] = startNode;

        Point[] directions = new Point[]
        {
            new Point(0, 1),
            new Point(0, -1),
            new Point(1, 0),
            new Point(-1, 0)
        };

        while (openList.Count > 0)
        {
            Node currentNode = openList.Dequeue();
            Point currentPoint = currentNode.Point;

            if (currentPoint == location)
            {
                List<Point> path = new List<Point>();
                while (currentNode != null)
                {
                    path.Add(currentNode.Point);
                    currentNode = currentNode.Parent;
                }
                path.Reverse();
                return path;
            }

            closedList.Add(currentNode);

            foreach (Point dir in directions)
            {
                Point neighborPoint = new Point(currentPoint.X + dir.X, currentPoint.Y + dir.Y);

                if (neighborPoint.X < 0 || neighborPoint.X >= cols || neighborPoint.Y < 0 || neighborPoint.Y >= rows)
                    continue;

                if (closedList.Contains(new Node(neighborPoint, null)))
                    continue;

                float gCost = currentNode.GCost + GetLengthBetweenDot(currentPoint, neighborPoint, heightMap);

                float hCost = (float)Math.Sqrt(Math.Pow(neighborPoint.X - location.X, 2) + Math.Pow(neighborPoint.Y - location.Y, 2));

                float fCost = gCost + hCost;

                Node neighborNode;

                if (pathMap.ContainsKey(neighborPoint))
                {
                    neighborNode = pathMap[neighborPoint];

                    if (gCost >= neighborNode.GCost)
                        continue;

                    neighborNode.Parent = currentNode;
                    neighborNode.GCost = gCost;
                }
                else
                {
                    neighborNode = new Node(neighborPoint, currentNode);
                    neighborNode.GCost = gCost;
                    neighborNode.HCost = hCost;
                    neighborNode.FCost = fCost;

                    pathMap[neighborPoint] = neighborNode;
                }

                openList.Enqueue(neighborNode, neighborNode.FCost);
            }
        }

        return new List<Point>();
    }
    float GetLengthBetweenDot(Point point1, Point point2, float[,] heightMap)
    {
        float heightDiff1 = heightMap[point1.Y, point1.X] > 0.45f ? heightMap[point1.Y, point1.X] + 20f : heightMap[point1.Y, point1.X];
        float heightDiff2 = heightMap[point2.Y, point2.X] > 0.45f ? heightMap[point2.Y, point2.X] + 20f : heightMap[point2.Y, point2.X];
        heightDiff1 = heightMap[point1.Y, point1.X] < -0.1f ? heightMap[point1.Y, point1.X] + 20f : heightMap[point1.Y, point1.X];
        heightDiff2 = heightMap[point2.Y, point2.X] < -0.1f ? heightMap[point2.Y, point2.X] + 20f : heightMap[point2.Y, point2.X];
        float heightDiff = heightDiff2 - heightDiff1;
        return (float)Math.Sqrt((Math.Pow(heightDiff, 2) + 1));
    }
    public List<Point> RemoveEverySecondPoint(List<Point> path)
    {
        List<Point> newPath = new List<Point>();

        for (int i = 0; i < path.Count; i += 2)
        {
            newPath.Add(path[i]);
        }

        return newPath;
    }
    private class Node
    {
        public Point Point { get; }
        public Node Parent { get; set; }
        public float GCost { get; set; }
        public float HCost { get; set; }
        public float FCost { get; set; }

        public Node(Point point, Node parent)
        {
            this.Point = point;
            this.Parent = parent;
        }

        public override bool Equals(object obj)
        {
            return obj is Node other && Point.Equals(other.Point);
        }

        public override int GetHashCode()
        {
            return Point.GetHashCode();
        }
    }
}
