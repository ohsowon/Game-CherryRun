using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDirector : MonoBehaviour
{
    public GameObject cherryPrefab;
    AudioSource aud;
    public AudioClip shakeSE;
    int shake = 0;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "tree")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.shake++;
                this.aud.PlayOneShot(this.shakeSE);
                Debug.Log("Изµй");
            }
        }

        if (this.shake == 3 || this.shake == 7)
        {
            GameObject go = Instantiate(cherryPrefab);
            go.transform.position = new Vector3(-6, 0, 0);
            this.shake++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

      
    }
}
