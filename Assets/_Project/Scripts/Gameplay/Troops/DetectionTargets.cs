using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Troops
{
    public class DetectionTargets : MonoBehaviour
    {
        private Troop _troop;
        private readonly List<Collider2D> targets = new();


        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            _troop = GetComponent<Troop>();
        }

        private void Update()
        {
            print("UPDATE");
            if (!_troop.ClosestTargetCollider && targets.Count > 0)
            {
                FindTheClosestTarget();
            }
            else if (_troop.ClosestTargetCollider && !targets.Contains(_troop.ClosestTargetCollider))
            {
                print("remove target");
                _troop.ClosestTargetCollider = null;
            }
        }

        private void FindTheClosestTarget()
        {
            print("finding the closest target");
            float closestDistance = Mathf.Infinity;
            Collider2D closestTarget = null;

            foreach (var targetCollider in targets)
            {
                Vector2 directionToTarget = targetCollider.transform.localPosition - transform.localPosition;
                float directionSqr = directionToTarget.sqrMagnitude;

                if (directionSqr < closestDistance)
                {
                    closestDistance = directionSqr;
                    closestTarget = targetCollider;
                }
            }

            if (closestTarget &&
                closestTarget.TryGetComponent<IDamageable>(out IDamageable closestDamageableTarget))
            {
                _troop.ClosestTargetCollider = closestTarget;
                _troop.ClosestDamageableTarget = closestDamageableTarget;
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