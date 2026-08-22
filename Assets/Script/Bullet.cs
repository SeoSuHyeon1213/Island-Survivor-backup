using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 8f;
    private Rigidbody rb;
    public GameObject effect;
    public AudioSource audio;
    public AudioClip DieClip;

    public GameManager gameManager;

    public float nearMissDistance = 3f;

    private Transform player;
    private bool bonusGiven = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.PlayOneShot(DieClip);
            Instantiate(effect, other.transform.position, Quaternion.identity); //생성(이펙트 변수, 위치, 회전(이펙트라서 회전 필요없음)) 



            PlayerController pc = other.GetComponent<PlayerController>();

            if (pc != null)
            {
                pc.Die();
                GameObject.Find("GameMusic").GetComponent<AudioSource>().Stop();
                GameObject.Find("GameoverMusic").GetComponent<AudioSource>().Play();
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed; //forward(0,0,1) 방향으로

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        Destroy(gameObject, 2f);
    }

    //아슬아슬하게 피하기
    void Update()
    {
        if (player == null || bonusGiven)
        {
            return;
        }

        CheckNearMiss();

        
        
    }

    void CheckNearMiss()
    {
        if (bonusGiven) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= nearMissDistance)
        {
            gameManager.AddScore(4); //범위를 빠져나갔으므로 보너스 지급
            bonusGiven = true;
        }
    }
}

