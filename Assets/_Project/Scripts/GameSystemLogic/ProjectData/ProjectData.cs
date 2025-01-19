using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.GameSystemLogic
{
    public class ProjectData : MonoBehaviour
    {
        public static ProjectData Instance;

        public int Currency { get; private set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            DontDestroyOnLoad(this);
            InitializeData();
        }

        private void InitializeData()
        {
            Currency = 228;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main Menu");
            }
            
        }
    }
}