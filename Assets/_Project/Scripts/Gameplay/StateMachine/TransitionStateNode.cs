using System;

namespace _Project.Scripts.Gameplay
{
    public class TransitionStateNode
    {
        public IStateNode FromNode { get; private set; }
        public IStateNode ToNode { get; private set; }
        public Func<bool> Condition { get; private set; }


        public TransitionStateNode(IStateNode fromNode, IStateNode toNode, Func<bool> condition)
        {
            FromNode = fromNode;
            ToNode = toNode;
            Condition = condition;
        }
    }
}