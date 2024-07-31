using System;
using System.Runtime.Serialization;
using Assignment3.ProblemDomain;
namespace Assignment3.Utility
{
    [Serializable]
    public class Node
    {
        public User Value { get; set; }
        public Node Next { get; set; }
        public Node(User value)
        {
            Value = value;
        }
    }
}
