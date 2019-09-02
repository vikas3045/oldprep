using System;
using System.Collections.Generic;

namespace Trie
{
    public class TrieNode
    {
        public char Value { get; set; }
        public List<TrieNode> Children { get; set; }
        public int Depth { get; set; }
        public TrieNode Parent { get; set; }

        public bool IsLeaf
        {
            get
            {
                return Children.Count == 0;
            }
        }

        public TrieNode(char value, int depth, TrieNode parent)
        {
            Children = new List<TrieNode>();
            Value = value;
            Depth = depth;
            Parent = parent;
        }

        public TrieNode FindChildNode(char value)
        {
            if (Children != null)
            {
                foreach (TrieNode child in Children)
                {
                    if (child.Value == value)
                        return child;
                }
            }

            return null;
        }
    }

    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode('^', 0, null);
        }

        public TrieNode Prefix(string word)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var character in word)
            {
                currentNode = currentNode.FindChildNode(character);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        public void Insert(string word)
        {
            var commonPrefix = Prefix(word);
            var current = commonPrefix;

            for (var i = current.Depth; i < word.Length; i++)
            {
                var newNode = new TrieNode(word[i], current.Depth + 1, current);
                current.Children.Add(newNode);
                current = newNode;
            }

            current.Children.Add(new TrieNode('$', current.Depth + 1, current));
        }

        public bool Search(String word)
        {
            var prefix = Prefix(word);
            return prefix.Depth == word.Length && prefix.FindChildNode('$') != null;
        }
    }
}
