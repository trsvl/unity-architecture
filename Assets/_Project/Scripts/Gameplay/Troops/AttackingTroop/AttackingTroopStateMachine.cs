using _Project.Scripts.Gameplay.Troops;
using _Project.Scripts.Utils;
using UnityEngine;

namespace _Project.Scripts.Gameplay._troops
{
    public class AttackingTroopStateMachine
    {
        private readonly AttackingTroop _troop;
        private readonly AttackingTroopAnimationListener _animationListener;
        private readonly StopWatchTimer _attackTimer;


        public AttackingTroopStateMachine(AttackingTroop troop, AttackingTroopAnimationListener animationListener,
            StopWatchTimer attackTimer)
        {
            _troop = troop;
            _animationListener = animationListener;
            _attackTimer = attackTimer;
        }

        public StateMachine GetStateMachine()
        {
            var stateMachine = new StateMachine();

            var idleNode = Idle();

            var movement = Movement();
            var chase = Chase();
            var attack = Attack();

            stateMachine.AddTransition(movement);
            stateMachine.AddTransition(chase);
            stateMachine.AddTransition(attack);
            stateMachine.AddTransition(AttackToIdle(attack.Node, idleNode));

            stateMachine.CurrentStateNode = idleNode;

            return stateMachine;
        }

        private TransitionStateNode AttackToIdle(IStateNode from, IStateNode to)
        {
            var transitionStateNode = new TransitionStateNode(from, to, Condition);
            return transitionStateNode;

            bool Condition()
            {
                return !_troop.AttackTimer.IsReady && _troop.AnimationListener.IsReadyForNextAnimation;
            }
        }

        private IStateNode Idle()
        {
            var idle = new Idle(_animationListener);
            return idle;
        }

        private StateNode Chase()
        {
            var chase = new Chase(_animationListener, _troop);

            StateNode stateNode = new StateNode(chase, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTarget) return false;


                Vector2 directionToTarget =
                    _troop.ClosestTarget.position - _troop.transform.position;
                float distanceToTarget = directionToTarget.magnitude;

                return _troop.ClosestTarget && distanceToTarget > _troop.Config.AttackRange;
            }
        }

        private StateNode Movement()
        {
            var move = new Move(_animationListener, _troop);

            StateNode stateNode = new StateNode(move, Condition);
            return stateNode;

            bool Condition()
            {
                return !_troop.ClosestTarget;
            }
        }

        private StateNode Attack()
        {
            var attack = new Attack(_animationListener, _troop, _attackTimer);

            StateNode stateNode = new StateNode(attack, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTarget) return false;

                Vector2 directionToTarget =
                    _troop.ClosestTarget.position - _troop.transform.position;
                float distanceToTarget = directionToTarget.magnitude;
                return _troop.AnimationListener.IsReadyForAttack && _troop.AttackTimer.IsReady &&
                       _troop.ClosestTarget && distanceToTarget < _troop.Config.AttackRange;
            }
        }
    }
}