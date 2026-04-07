using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    AudioSource aud;
    public AudioClip getSE;
    Animator animator;
    Rigidbody2D rigid2D;
    float jumpForce = 550.0f;
    float walkForce = 20.0f;
    float maxWalkSpeed = 4.0f;

    [SerializeField]
    float checkSpeed;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cherry")
        {
            Debug.Log("체리");
            Destroy(other.gameObject);
            this.aud.PlayOneShot(this.getSE);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.aud = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y < 0.001f)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }


        float xSpeed = Mathf.Abs(this.rigid2D.velocity.x);

        // 가속도 제한두고 이동
        if (xSpeed < this.maxWalkSpeed) 
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 캐릭터 방향 전환
        if (key != 0)
        {
            transform.localScale = new Vector3(key * 5, 5, 1);
        }

        // 애니메이션 전환
        if (key != 0 && xSpeed > 0f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }
}
