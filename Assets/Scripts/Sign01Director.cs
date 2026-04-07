using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign01Director : MonoBehaviour
{
    GameObject message;
    public int count;

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "sign_01" || other.gameObject.tag == "door") && other != null)
        {
            if (this.count > 0)
            {
                this.message.GetComponent<TextMeshProUGUI>().text = "You need " + this.count + " more cherries";
            }
            else if (this.count == 0)
            {
                this.message.GetComponent<TextMeshProUGUI>().text = "Press the °Ë key to move";

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("¿Ãµø");

                    if (other.gameObject.tag == "sign_01")
                    {
                        SceneManager.LoadScene("Collect02Scene");
                    }
                    else if (other.gameObject.tag == "door")
                    {                  
                        SceneManager.LoadScene("BattleScene");
                    }

                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.tag == "sign_01" || other.gameObject.tag == "door") && other != null)
        {
            this.message.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cherry")
        {
            this.count--;
            Debug.Log(this.count);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        this.message = GameObject.Find("message");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
