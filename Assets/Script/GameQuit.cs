using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuit : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        // 안드로이드 뒤로가기 버튼 처리
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                    Application.Quit();
            }
        }
        
    }
}
