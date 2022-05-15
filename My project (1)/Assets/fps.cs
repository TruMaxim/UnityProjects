using UnityEngine.UI;
using UnityEngine;

public class fps : MonoBehaviour
{
    public Text TextFPS;
    private float timeCount = 0.0f;
    private int fpsCount = 0;


    void Update()
    {
        if (timeCount >= 1)
        {
            if (TextFPS != null)
                TextFPS.text = $"FPS: {fpsCount}";
            timeCount = 0.0f;
            fpsCount = 0;
        }
        timeCount += Time.deltaTime;
        fpsCount += 1;
    }
}
