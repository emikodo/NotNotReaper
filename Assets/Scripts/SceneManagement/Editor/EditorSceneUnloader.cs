using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoadAttribute]
public static class EditorSceneUnloader
{
#if UNITY_EDITOR
    private static List<int> previouslyLoadedScenes = new();

    static EditorSceneUnloader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode) OpenScenes();
        if (state == PlayModeStateChange.ExitingEditMode) CloseScenes();
    }


    private static void OpenScenes()
    {
        for (int i = 0; i < previouslyLoadedScenes.Count; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (!IsActiveScene(scene)) OpenScene(scene);
        }
    }

    private static void CloseScenes()
    {
        previouslyLoadedScenes.Clear();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (!IsActiveScene(scene))
            {
                previouslyLoadedScenes.Add(i);
                CloseScene(scene);
            }
        }
    }


    private static void OpenScene(Scene scene)
    {
        EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Additive);
    }

    private static void CloseScene(Scene scene)
    {
        EditorSceneManager.CloseScene(scene, false);
    }


    private static Scene activeScene
    {
        get { return SceneManager.GetActiveScene(); }
    }

    private static bool IsActiveScene(Scene scene)
    {
        return scene == activeScene;
    }
#endif
}