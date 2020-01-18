using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChecker : MonoBehaviour
{
    int count;
    public GameObject game,text;
    
    void Start()
    {
        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
            StartCoroutine(Counter());
        text.GetComponent<MeshRenderer>().enabled = true;
        count++;
        text.GetComponent<TextMesh>().text = count + "/" + "30";
        
    }
    IEnumerator Counter()
    {
        yield return new WaitForSeconds(3);
        Debug.Log(count);
        game.GetComponent<CheckPointTrigger>().OpenClose = -1;
        
    }
}
