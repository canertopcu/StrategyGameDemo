using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MyTest : MonoBehaviour
{
    [Inject] GameManager gameManager;
 
     
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError(gameManager.State);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
