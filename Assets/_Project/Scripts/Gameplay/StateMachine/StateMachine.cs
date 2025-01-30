using System.Collections.Generic;

namespace _Project.Scripts.Gameplay
{
    public class StateMachine
    {
        private readonly List<StateNode> _states = new();

        public IStateNode CurrentStateNode
        {
            get => _currentStateNode;
            set
            {
                _currentStateNode = value;
                _currentStateNode.OnEnter();
            }
        }

        private IStateNode _currentStateNode;


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
                if (_currentStateNode != node.Node && node.Condition())
                {
                    _currentStateNode.OnExit();
                    _currentStateNode = node.Node;
                    _currentStateNode.OnEnter();
                }
            }

            _currentStateNode.Update();
        }

        public void FixedUpdate()
        {
            _currentStateNode.FixedUpdate();
        }
    }
}