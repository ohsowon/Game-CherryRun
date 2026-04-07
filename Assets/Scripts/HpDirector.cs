using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpDirector : MonoBehaviour
{
    AudioSource aud;
    public AudioClip damageSE;
    public AudioClip attackSE;
    GameObject message;
    GameObject playerHPUI;
    GameObject bearHPUI;
    GameObject bear;
    int playerHP = 100;
    int bearHP = 100;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bear")
        {
            if (transform.position.y > this.bear.transform.position.y)
            {
                Debug.Log("공격");
                this.aud.PlayOneShot(this.attackSE);
                this.bearHP -= 10;
            }
            else
            {
                Debug.Log("피해");
                this.aud.PlayOneShot(this.damageSE);
                this.playerHP -= 10;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "spike")
        {
            Debug.Log("피해");
            this.aud.PlayOneShot(this.damageSE);
            this.playerHP -= 10;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "door" && this.bearHP == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("EndingScene");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        this.aud = GetComponent<AudioSource>();
        this.message = GameObject.Find("message");
        this.playerHPUI = GameObject.Find("playerHP");
        this.bearHPUI = GameObject.Find("bearHP");
        this.bear = GameObject.Find("bear");
    }
    

    void Update()
    {
        this.playerHPUI.GetComponent<TextMeshProUGUI>().text = "" + this.playerHP;
        this.bearHPUI.GetComponent<TextMeshProUGUI>().text = "" + this.bearHP;

        if (this.bearHP == 0)
        {
            Destroy(this.bear);
            this.message.GetComponent<TextMeshProUGUI>().text = "Press the ↑ key to escape!";
        }

        if (this.playerHP == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Collect02Scene");
        }
    }
}
