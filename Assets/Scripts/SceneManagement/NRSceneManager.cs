using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotReaper.SceneManagement
{
    public class NRSceneManager : MonoBehaviour
    {

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void LoadScenes()
        {
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                SceneManager.LoadScene(i, LoadSceneMode.Additive);
            }

        }
    }
}
