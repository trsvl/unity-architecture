using UnityEngine;

namespace _Project.Scripts.Gameplay.Buildings
{
    public class BuildingsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Castle castlePrefab;
        [SerializeField] private Transform leftCastlePoint;
        [SerializeField] private Transform rightCastlePoint;


        public void Register(Container container)
        {
            var left = Instantiate(castlePrefab, leftCastlePoint);
            left.Init(Team.Player);
            var right = Instantiate(castlePrefab, rightCastlePoint);
            right.Init(Team.Enemy);
        }
    }
}