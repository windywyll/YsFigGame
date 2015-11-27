using UnityEngine;
using System.Collections;

public class ScriptTitleScreen : MonoBehaviour
{

	public void StartGame (string SceneToLoad)
    {
        Application.LoadLevel(SceneToLoad);
    }
}
