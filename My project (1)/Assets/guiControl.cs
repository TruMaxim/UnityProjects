using UnityEngine.SceneManagement;
using UnityEngine;

public class guiControl : MonoBehaviour
{
    public void GoToMain()
    {
        SceneManager.LoadScene("settings");
    }
}
