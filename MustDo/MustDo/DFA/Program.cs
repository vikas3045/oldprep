using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> zEdges = new List<int>() { 0, 2, 1 };
            List<int> oneEdges = new List<int>() { 1, 0, 2 };
            List<int> acceptStates = new List<int>() { 0 };
            int startState = 0;
            int n = 5;

            var result = automata(zEdges, oneEdges, acceptStates, startState, n);

            Console.ReadLine();
        }
        public static int automata(List<int> zEdges, List<int> oneEdges, List<int> acceptStates, int startState, int n)
        {
            List<int> currentComb = new List<int>();
            Result res = new Result();
            Dictionary<string, int> dicMemo = new Dictionary<string, int>();
            GetNumberOfAcceptedInputs(currentComb, res, zEdges, oneEdges, acceptStates, startState, n, dicMemo);

            return res.Val;
        }

        public static void GetNumberOfAcceptedInputs(List<int> currentComb, Result res, List<int> zEdges, List<int> oneEdges, List<int> acceptStates, int startState, int n, Dictionary<string, int> dicMemo)
        {
            if (currentComb.Count > n)
                return;


            if (currentComb.Count == n && ProcessInput(currentComb, zEdges, oneEdges, acceptStates, startState))
            {
                var key = string.Join("|", currentComb);
                if (dicMemo.ContainsKey(key))
                    res.Val = dicMemo[key];
                res.Val += 1;
                dicMemo.Add(key, res.Val);
            }
            List<int> subCombZero = new List<int>(currentComb);
            subCombZero.Add(0);
            GetNumberOfAcceptedInputs(subCombZero, res, zEdges, oneEdges, acceptStates, startState, n, dicMemo);

            List<int> subCombOne = new List<int>(currentComb);
            subCombOne.Add(1);
            GetNumberOfAcceptedInputs(subCombOne, res, zEdges, oneEdges, acceptStates, startState, n, dicMemo);

        }

        public static bool ProcessInput(List<int> inputArr, List<int> zEdges, List<int> oneEdges, List<int> acceptStates, int startState)
        {
            int nextState = ComputeState(inputArr[0], startState, zEdges, oneEdges);

            for (int i = 1; i < inputArr.Count; i++)
            {
                nextState = ComputeState(inputArr[i], nextState, zEdges, oneEdges);
            }

            if (acceptStates.IndexOf(nextState) != -1)
                return true;
            else
                return false;
        }

        public static int ComputeState(int input, int currentState, List<int> zEdges, List<int> oneEdges)
        {
            if (input == 0)
            {
                return zEdges[currentState];
            }
            else
            {
                return oneEdges[currentState];
            }
        }

        public class Result
        {
            public int Val { get; set; }
        }
    }
}
