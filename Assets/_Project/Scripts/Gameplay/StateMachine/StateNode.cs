using System;

namespace _Project.Scripts.Gameplay
{
    public class StateNode
    {
        public IStateNode Node { get; private set; }
        public Func<bool> Condition { get; private set; }


        public StateNode(IStateNode node, Func<bool> condition)
        {
            Node = node;
            Condition = condition;
        }
    }
}