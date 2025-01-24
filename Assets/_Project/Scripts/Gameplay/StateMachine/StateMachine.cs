using System.Collections.Generic;

namespace _Project.Scripts.Gameplay
{
    public class StateMachine
    {
        private readonly List<StateNode> _states = new();

        public IMachineState currentState;


        public void AddTransition(StateNode node)
        {
            _states.Add(node);
        }

        public void RemoveTransition(StateNode node)
        {
            _states.Remove(node);
        }

        public void Update()
        {
            foreach (var node in _states)
            {
                if (currentState != node.State && node.Condition())
                {
                    currentState.OnExit();

                    currentState = node.State;
                    currentState.OnEnter();
                }

                currentState.Update();
            }
        }
    }
}