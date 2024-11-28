using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Source.Testing
{
    public class CheatCommands : MonoBehaviour
    {
        static bool isInitialized = false;

#if UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            if (!isInitialized)
            {
                GameObject go = new GameObject("CheatCommands");
                go.AddComponent<CheatCommands>();
                DontDestroyOnLoad(go);
                isInitialized = true;
            }
        }

        private void Start()
        {
            G.fader.FadeOut();
        }
#endif

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadScene();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                G.dungeon.ProcessBattle().Forget();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                try
                {
                    SaveSystem.Save(G.state);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                G.ui.ShowUnitPickerAsync();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                G.ui.OpenQuestBoard();
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                G.main.StartNextDay();
            }
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void OnDestroy()
        {
            isInitialized = false;
        }
    }
}