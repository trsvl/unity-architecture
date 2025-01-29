using _Project.Scripts.Gameplay.Troops;
using UnityEngine;

namespace _Project.Scripts.Gameplay._troops
{
    public class AttackingTroopStateMachine
    {
        private readonly AttackingTroop _troop;
        private readonly AttackingTroopAnimationListener _animationListener;
        private readonly DetectionTargets _detectionTargets;


        public AttackingTroopStateMachine(AttackingTroop troop, Animator animator, DetectionTargets detectionTargets)
        {
            _troop = troop;
            _animationListener = new AttackingTroopAnimationListener(animator);
            _detectionTargets = detectionTargets;
        }

        public StateMachine GetStateMachine()
        {
            var stateMachine = new StateMachine();

            var movement = Movement();
            var chase = Chase();
            var attack = Attack();

            stateMachine.AddTransition(movement);
            stateMachine.AddTransition(chase);
            stateMachine.AddTransition(attack);

            stateMachine.CurrentState = movement.State;

            return stateMachine;
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
                    _troop.ClosestTarget.transform.position - _troop.transform.position;
                float distanceToTarget = directionToTarget.magnitude;

                return _troop.ClosestTarget && distanceToTarget > _troop.Config.AttackRange;
            }
        }

        private StateNode Movement()
        {
            var move = new Move(_animationListener, _troop, _detectionTargets);

            StateNode stateNode = new StateNode(move, Condition);
            return stateNode;

            bool Condition()
            {
                return !_troop.ClosestTarget;
            }
        }

        private StateNode Attack()
        {
            var attack = new Attack(_animationListener, _troop);

            StateNode stateNode = new StateNode(attack, Condition);
            return stateNode;

            bool Condition()
            {
                if (!_troop.ClosestTarget) return false;

                Vector2 directionToTarget =
                    _troop.ClosestTarget.transform.position - _troop.transform.position;
                float distanceToTarget = directionToTarget.magnitude;
                return _troop.ClosestTarget && distanceToTarget < _troop.Config.AttackRange;
            }
        }
    }
}