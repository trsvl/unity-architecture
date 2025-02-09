using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops.Base
{
    public class TroopBaseStateMachine : ITroopStateMachine
    {
        private readonly TroopBase _troop;
        private readonly TroopBaseAnimationListener _baseAnimationListener;
        private readonly StopWatchTimer _attackTimer;
        private StateMachine _stateMachine;
        private IStateNode startingNode;


        public TroopBaseStateMachine(TroopBase troop, TroopBaseAnimationListener baseAnimationListener,
            StopWatchTimer attackTimer)
        {
            _troop = troop;
            _baseAnimationListener = baseAnimationListener;
            _attackTimer = attackTimer;
        }

        public StateMachine GetStateMachine()
        {
            _stateMachine = new StateMachine();

            var idle = Idle();
            var movement = Movement();
            var chase = Chase();
            var attack = Attack();

            _stateMachine.AddTransitionFixedUpdate(idle);
            _stateMachine.AddTransition(movement);
            _stateMachine.AddTransitionFixedUpdate(chase);
            _stateMachine.AddTransitionFixedUpdate(attack);

            _stateMachine.CurrentStateNode = idle.Node;
            startingNode = idle.Node;

            return _stateMachine;
        }

        public void OnDeath()
        {
            _stateMachine.CurrentStateNode.OnExit();
            _stateMachine.CurrentStateNode = startingNode;
        }

        private StateNode Idle()
        {
            var idle = new Idle(_baseAnimationListener, _troop);

            StateNode stateNode = new StateNode(idle, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTarget) return false;

                Vector2 directionToTarget =
                    _troop.ClosestDamageableTarget.Collider.ClosestPoint(_troop.Rb.position) - _troop.Rb.position;
                float distanceToTarget = directionToTarget.magnitude;

                return !_troop.AttackTimer.IsReady && distanceToTarget < _troop.Config.AttackRange;
            }
        }

        private StateNode Chase()
        {
            var chase = new Chase(_baseAnimationListener, _troop);

            StateNode stateNode = new StateNode(chase, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTarget) return false;

                Vector2 directionToTarget =
                    _troop.ClosestDamageableTarget.Collider.ClosestPoint(_troop.Rb.position) - _troop.Rb.position;
                float distanceToTarget = directionToTarget.magnitude;

                return distanceToTarget > _troop.Config.AttackRange;
            }
        }

        private StateNode Movement()
        {
            var move = new Move(_baseAnimationListener, _troop);

            StateNode stateNode = new StateNode(move, Condition);
            return stateNode;

            bool Condition()
            {
                return !_troop.ClosestTarget;
            }
        }

        private StateNode Attack()
        {
            var attack = new Attack(_baseAnimationListener, _troop, _attackTimer);

            StateNode stateNode = new StateNode(attack, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTarget) return false;

                Vector2 directionToTarget =
                    _troop.ClosestDamageableTarget.Collider.ClosestPoint(_troop.Rb.position) - _troop.Rb.position;
                float distanceToTarget = directionToTarget.magnitude;

                return _troop.AttackTimer.IsReady && distanceToTarget < _troop.Config.AttackRange;
            }
        }
    }
}