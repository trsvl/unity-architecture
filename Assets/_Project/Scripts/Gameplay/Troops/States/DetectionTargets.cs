using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class DetectionTargets : MonoBehaviour
    {
        private AttackingTroop _troop;
        private readonly List<Transform> targets = new();


        public void Init(AttackingTroop troop)
        {
            _troop = troop;
        }

        private void Update()
        {
            if (!_troop.ClosestTarget && targets.Count > 0)
            {
                FindTheClosestTarget();
            }
            else if (_troop.ClosestTarget && !targets.Contains(_troop.ClosestTarget))
            {
                _troop.ClosestTarget = null;
            }
        }

        private void FindTheClosestTarget()
        {
            float closestDistance = Mathf.Infinity;
            Transform closestTarget = null;

            foreach (var target in targets)
            {
                Vector2 directionToTarget = target.transform.localPosition - transform.localPosition;
                float directionSqr = directionToTarget.sqrMagnitude;

                if (directionSqr < closestDistance)
                {
                    closestDistance = directionSqr;
                    closestTarget = target;
                }
            }

            if (closestTarget &&
                closestTarget.TryGetComponent<IDamageable>(out IDamageable closestDamageableTarget))
            {
                _troop.ClosestTarget = closestTarget;
                _troop.ClosestDamageableTarget = closestDamageableTarget;
            }
        }

        private void OnTriggerEnter2D(Collider2D troopCollider)
        {
            if (troopCollider.CompareTag(_troop.OpponentTag))
            {
                AddTarget(troopCollider.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D troopCollider)
        {
            if (targets.Contains(troopCollider.transform))
            {
                RemoveTarget(troopCollider.transform);
            }
        }

        private void AddTarget(Transform target)
        {
            if (!targets.Contains(target))
            {
                targets.Add(target);
            }
        }

        private void RemoveTarget(Transform target)
        {
            if (targets.Contains(target))
            {
                targets.Remove(target);
            }
        }
    }
}