using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryGenerator : MonoBehaviour
{
    public GameObject cherryPrefab;
    float span = 0.5f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            GameObject go = Instantiate(cherryPrefab);
            float px = Random.Range(-8.5f, 8.5f);
            go.transform.position = new Vector3(px, 6, 0);
        }
    }
}
