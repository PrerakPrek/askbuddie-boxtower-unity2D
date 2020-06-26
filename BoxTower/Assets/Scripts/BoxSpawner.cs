using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject Box;



    void Start()
    {
        //SpawnBox();
    }

    public void SpawnBox()
    {
        GameObject m_box = Instantiate(Box);
        m_box.transform.position = transform.position;
    }
    


  
}
