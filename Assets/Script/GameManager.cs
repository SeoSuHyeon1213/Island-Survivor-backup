using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameoverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;

    

    private bool isGameover;
    private float surviveTime;
    private int bonusScore;
    float bestTime;
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);
        bestTime = PlayerPrefs.GetFloat("BestTime");

        float finalScore = surviveTime + bonusScore;
        if (finalScore > bestTime) //새로운 기록 달성시 bestTime 갱신
        {
            bestTime = finalScore;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = " " + (int)bestTime;

    }
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime");
        recordText.text = " " + (int)bestTime;
        surviveTime = 0;
        bonusScore = 0;
        isGameover = false;
        //PlayerPrefs가 항목 값으로 저장 bestTime이 없으면 0을 반환
        
        
    }
    void Update()
    {
       
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = " " + (((int)surviveTime) + bonusScore);
            
        }


        // else
        // {
        //     var touchScreen = Touchscreen.current;

        //     // 첫 번째 손가락의 터치 상태 확인 (메인 버튼 등 UI 위 터치는 무시)
        //     if (touchScreen != null && touchScreen.primaryTouch.press.wasPressedThisFrame)
        //     {
        //         int touchId = touchScreen.primaryTouch.touchId.ReadValue();
        //         if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject(touchId))
        //             SceneManager.LoadScene(1);
        //     }

        //     // 마우스 클릭 (메인 버튼 등 UI 위 클릭은 무시)
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject())
        //             SceneManager.LoadScene(1);
        //     }
        // }

        

    }


    public void AddScore(int score)
    {
        bonusScore += score;
    }
    
}


