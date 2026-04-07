using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlatformConroller : MonoBehaviour
{
    GameObject platform;
    GameObject message;
    AudioSource aud;
    public AudioClip pullSE;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "lever_up")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.aud.PlayOneShot(this.pullSE);
                this.platform.transform.Translate(0, 0.15f, 0);
            }
        }

        if (other.gameObject.tag == "lever_down")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.aud.PlayOneShot(this.pullSE);
                this.platform.transform.Translate(0, -0.15f, 0);
            }
        }

        if (other.gameObject.tag == "lever_right")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.aud.PlayOneShot(this.pullSE);
                this.platform.transform.Translate(0.15f, 0, 0);
            }
        }

        if (other.gameObject.tag == "lever_left")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.aud.PlayOneShot(this.pullSE);
                this.platform.transform.Translate(-0.15f, 0, 0);
            }
        }

        if ((other.gameObject.tag == "door"))
        {
            this.message.GetComponent<TextMeshProUGUI>().text = "Press the °Ë key to move";

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("¿Ãµø");
                SceneManager.LoadScene("Collect03Scene");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "door")
        {
            this.message.GetComponent<TextMeshProUGUI>().text = "";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        this.platform = GameObject.Find("platform");
        this.aud = GetComponent<AudioSource>();
        this.message = GameObject.Find("message");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
