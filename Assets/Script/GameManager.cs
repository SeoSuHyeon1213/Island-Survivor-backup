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
    public PlayerController1 playerController;

    

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
            PlayerPrefs.Save();
        }
   
        //여기에 비활성화 표시
        playerController.joy.gameObject.SetActive(false);
         
        recordText.text = " " + (int)bestTime;

    }
    void Awake()
    {
        Instance = this;
        playerController = FindFirstObjectByType<PlayerController1>();
    }
    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime");
        recordText.text = " " + (int)bestTime;
        surviveTime = 0;
        bonusScore = 0;
        isGameover = false;
        playerController.joy.gameObject.SetActive(true);
        //PlayerPrefs가 항목 값으로 저장 bestTime이 없으면 0을 반환
        
        
    }
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = " " + (((int)surviveTime) + bonusScore);
            
        }
               

    }


    public void AddScore(int score)
    {
        bonusScore += score;
    }
    
}


