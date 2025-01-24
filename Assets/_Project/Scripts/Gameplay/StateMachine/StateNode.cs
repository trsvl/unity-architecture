using System;

namespace _Project.Scripts.Gameplay
{
    public class StateNode
    {
        public IMachineState State { get; private set; }
        public Func<bool> Condition { get; private set; }


        public StateNode(IMachineState state, Func<bool> condition)
        {
            State = state;
            Condition = condition;
        }
    }
}