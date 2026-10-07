using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform shot;
    public float min = 0.5f ;
    public float max = 3f ;

    public float minLimit = 0.1f; // min/max가 줄어들 수 있는 최소 한계값
    public float decreaseRate = 0.01f; // 초당 min/max 감소량 (스폰 주기 단축 속도)

    Transform target;

    float rate;
    float timeAfterSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeAfterSpawn = 0f;
        rate = Random.Range(min,max);
        target = FindFirstObjectByType<PlayerController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        // 시간이 지날수록 스폰 주기(min~max)를 점점 짧게
        min = Mathf.Max(minLimit, min - decreaseRate * Time.deltaTime);
        max = Mathf.Max(minLimit, max - decreaseRate * Time.deltaTime);

        if (timeAfterSpawn >= rate)
        {
            timeAfterSpawn = 0f;
            GameObject o = Instantiate(prefab, shot.position, shot.rotation);
            o.transform.LookAt(target);
            rate = Random.Range(min, max);
            
        }
    }
}
