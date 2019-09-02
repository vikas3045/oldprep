using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class GraphAdjM
    {
        //Variables and props
        private bool[,] _adjMatrix;
        private int _vertexCount;

        public int VertexCount
        {
            get
            {
                return _vertexCount;
            }
            private set
            {
                _vertexCount = value;
            }
        }

        //Constructor
        public GraphAdjM(int vertexCount)
        {
            VertexCount = vertexCount;
            _adjMatrix = new bool[VertexCount, VertexCount];
        }

        //Methods
        public void AddEdge(int i, int j)
        {
            if (i >= 0 && i < VertexCount && j > 0 && j < VertexCount)
            {
                _adjMatrix[i, j] = true;
                _adjMatrix[j, i] = true;
            }
        }

        public void RemoveEdge(int i, int j)
        {
            if (i >= 0 && i < VertexCount && j > 0 && j < VertexCount)
            {
                _adjMatrix[i, j] = false;
                _adjMatrix[j, i] = false;
            }
        }

        public bool IsEdge(int i, int j)
        {
            if (i >= 0 && i < VertexCount && j > 0 && j < VertexCount)
            {
                return _adjMatrix[i, j];
            }

            return false;
        }
    }

    public class GraphAdjL
    {
        //Variables and props
        private List<int> _vertices;
        private LinkedList<int>[] _edges;
        private int _vertexCount;
        public int VertexCount
        {
            get
            {
                return _vertexCount;
            }
            private set
            {
                _vertexCount = value;
            }
        }

        //Constructor
        public GraphAdjL(int vertexCount)
        {
            VertexCount = vertexCount;
            _vertices = new List<int>();
            _edges = new LinkedList<int>[VertexCount];
            for (int i = 0; i < vertexCount; i++)
                _edges[i] = new LinkedList<int>();
        }

        //Methods
        public void AddVertex(int vertex)
        {
            if (_vertices.IndexOf(vertex) == -1)
                _vertices.Add(vertex);
        }

        public void AddEdge(int source, int destination)
        {
            int i = _vertices.IndexOf(source);
            int j = _vertices.IndexOf(destination);
            if (i != -1 || j != -1)
            {
                _edges[i].AddFirst(destination);
                _edges[j].AddFirst(source);
            }
        }

        public List<int> GetVertices()
        {
            return _vertices;
        }

        public LinkedList<int> GetAdjacent(int vertex)
        {
            return _edges[vertex];
        }

        public void RemoveEdge(int source, int destination)
        {

        }
    }
}
