using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;
using System.Threading.Tasks;

namespace _Project.Scripts.GameSystemLogic
{
    public class GameContextInstaller : MonoBehaviour, IInstaller
    {
        [FormerlySerializedAs("context")] [SerializeField]
        private GameContext gameContext;


        public Task Register()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var targetInterfaces = new[]
            {
                typeof(IStartGame),
                typeof(IPauseGame),
                typeof(IResumeGame),
                typeof(IFinishGame)
            };

            var typesWithInterfaces = assembly.GetTypes()
                .Where(type =>
                    targetInterfaces.Any(i => i.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract));

            foreach (var type in typesWithInterfaces)
            {
                if (Activator.CreateInstance(type) is { } instance)
                {
                    gameContext.AddListener(instance);
                }
            }

            gameContext.StartGame();

            return Task.CompletedTask;
        }
    }
}