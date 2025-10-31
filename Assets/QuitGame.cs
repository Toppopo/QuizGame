using UnityEngine;

public class QuitGame : MonoBehaviour
{
    float currentTime = 0;
    float elapsedTime = 5f;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > elapsedTime)
        {
            Application.Quit();
        }
    }
}
