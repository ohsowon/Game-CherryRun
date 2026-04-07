using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign00Director : MonoBehaviour
{
    GameObject message;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "sign_00" && other != null)
        {
            this.message.GetComponent<TextMeshProUGUI>().text = "Beware of Wild Bear! " + "Press the °Ë key to move";

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("¿Ãµø");
                SceneManager.LoadScene("Collect01Scene");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "sign_00" && other != null)
        {
            this.message.GetComponent<TextMeshProUGUI>().text = "";
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
