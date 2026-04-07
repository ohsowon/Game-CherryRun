using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid2D;
    float jumpForce = 550.0f;
    float walkForce = 0.04f;
    float span = 2.0f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        this.rigid2D = GetComponent<Rigidbody2D>();
        this.player = GameObject.Find("player");
    }

 

    // Update is called once per frame
    void Update()
    {
        int key = 0;

        if (this.player.transform.position.x <= transform.position.x)
        {
            key = -1;
            transform.Translate(walkForce * key, 0, 0);
        }
        else
        {
            key = 1;
            transform.Translate(walkForce * key, 0, 0);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key * 4, 4, 1);
        }

        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

    }
}
