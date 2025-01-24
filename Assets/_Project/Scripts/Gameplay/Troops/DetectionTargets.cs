using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class DetectionTargets : MonoBehaviour
    {
        [SerializeField] private Troop _troop;

        private readonly List<Collider2D> targets = new();


        private void Update()
        {
            if (_troop.closestTargetCollider && targets.Count > 0)
            {
            }
        }

        public void FindTheClosestTarget()
        {
            float closestDistance = Mathf.Infinity;
            Collider2D closestTarget = null;

            foreach (var targetCollider in targets)
            {
                Vector2 directionToTarget = targetCollider.transform.position - transform.position;
                float directionSqr = directionToTarget.sqrMagnitude;

                if (directionSqr < closestDistance)
                {
                    closestDistance = directionSqr;
                    closestTarget = targetCollider;
                }
            }

            if (closestTarget != null &&
                closestTarget.TryGetComponent<IDamageable>(out IDamageable closestDamageableTarget))
            {
                _troop.closestTargetCollider = closestTarget;
                _troop.closestDamageableTarget = closestDamageableTarget;
            }
        }

        private void OnTriggerEnter2D(Collider2D troopCollider)
        {
            if (troopCollider.TryGetComponent<IDamageable>(out _))
            {
                AddTarget(troopCollider);
            }
        }

        private void OnTriggerExit2D(Collider2D troopCollider)
        {
            if (targets.Contains(troopCollider))
            {
                RemoveTarget(troopCollider);
            }
        }

        private void AddTarget(Collider2D target)
        {
            if (!targets.Contains(target))
            {
                targets.Add(target);
            }
        }

        private void RemoveTarget(Collider2D target)
        {
            if (targets.Contains(target))
            {
                targets.Remove(target);
            }
        }
    }
}