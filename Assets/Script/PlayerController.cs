using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    Animator animator;
    //public VariableJoystick joy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gm = FindFirstObjectByType<GameManager>();
        gm.EndGame();

    }
    void Start()
    {
        //으헤
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); //축 값 지정
        Vector3 move = h * Vector3.right + v * Vector3.forward; //(h에 right, v에 forward) * 축 값 => 이동 방향과 크기*/

        //Vector3 move = new Vector3(joy.Horizontal, 0, joy.Vertical);

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move); //입력 방향(LookRotation)으로 회전 값(Quaternion)을 생성후 transform.rotation에 대입
            transform.Translate(Vector3.forward * speed * Time.deltaTime); //바라본 방향으로 이동
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

            /*if (Input.GetKey(KeyCode.UpArrow) == true)
            {
                playerRigidbody.AddForce(0f, 0f, speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) == true)
            {
                playerRigidbody.AddForce(0f, 0f, -speed);
            }
            if (Input.GetKey(KeyCode.RightArrow) == true)
            {
                playerRigidbody.AddForce(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow) == true)
            {
                playerRigidbody.AddForce(-speed, 0f, 0f);
            }*/
        }
}
