using System.Collections.Generic;

namespace _Project.Scripts.Gameplay
{
    public class StateMachine
    {
        private readonly List<StateNode> _states = new();
        private readonly List<StateNode> _statesFixedUpdate = new();
        private readonly List<TransitionStateNode> _transitionStates = new();

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

        public void AddTransition(TransitionStateNode node)
        {
            _transitionStates.Add(node);
        }

        public void AddTransitionFixedUpdate(StateNode node)
        {
            _statesFixedUpdate.Add(node);
        }

        public void RemoveTransition(StateNode node)
        {
            _states.Remove(node);
        }

        public void RemoveTransition(TransitionStateNode node)
        {
            _transitionStates.Remove(node);
        }
        
        public void RemoveTransitionFixedUpdate(StateNode node)
        {
            _statesFixedUpdate.Remove(node);
        }

        public void Update()
        {
            foreach (var localState in _states)
            {
                if (_currentStateNode != localState.Node && localState.Condition())
                {
                    _currentStateNode.OnExit();
                    _currentStateNode = localState.Node;
                    _currentStateNode.OnEnter();
                }
            }

            foreach (var localState in _transitionStates)
            {
                if (_currentStateNode == localState.FromNode && localState.Condition())
                {
                    _currentStateNode.OnExit();
                    _currentStateNode = localState.ToNode;
                    _currentStateNode.OnEnter();
                }
            }

            _currentStateNode.Update();
        }

        public void FixedUpdate()
        {
            foreach (var localState in _statesFixedUpdate)
            {
                if (_currentStateNode != localState.Node && localState.Condition())
                {
                    _currentStateNode.OnExit();
                    _currentStateNode = localState.Node;
                    _currentStateNode.OnEnter();
                }
            }
            
            _currentStateNode.FixedUpdate();
        }
    }
}