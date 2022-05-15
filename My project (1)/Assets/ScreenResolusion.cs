using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading;

public class ScreenResolusion : MonoBehaviour
{
    private static Resolution nowResolution;
    //public float timer;
    public Text nowResolutionScreen;
    private static Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        nowResolution = Screen.currentResolution;
        //SceneManager.LoadScene("Splash screen");
        Screen.SetResolution(resolutions[resolutions.Length-1].width, resolutions[resolutions.Length - 1].height, true);
        ResolusionTextUpdate();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ResolusionTextUpdate()
    {
        Thread thread = new Thread(RTU);
        thread.Start();
    }

    public void RTU()
    {
        Thread.Sleep(1000);
        nowResolutionScreen.text = $"{Screen.currentResolution.width} x {Screen.currentResolution.height}";
    }

    public void ExitGame()
    {
        //Screen.SetResolution(nowResolution.width, nowResolution.height);
        Application.Quit();
    }

    public void SetResolusionOrigin()
    {
        //Screen.SetResolution(nowResolution.width, nowResolution.height, true, nowResolution.refreshRate);
        Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
        ResolusionTextUpdate();
    }

    public void SetResolusionFullHD()
    {
        Screen.SetResolution(1920, 1080, true);
        ResolusionTextUpdate();
    }

    public void SetResolusionHD()
    {
        Screen.SetResolution(1280, 720, true);
        ResolusionTextUpdate();
    }

    public void SetResolusionFullHD60()
    {
        Screen.SetResolution(1920, 1200, true);
        ResolusionTextUpdate();
    }

}
