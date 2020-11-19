using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doABarrelRoll : MonoBehaviour
{
    public GameObject barrel;
   public Vector3[] positions = new Vector3[5];
    int pos = 1;
   
    // Start is called before the first frame update
    void Start()
    {
        positions[0] = new Vector3(0, -26, 0);
        positions[1] = new Vector3(-46, 0, 0);
        positions[2] = new Vector3(0, 29, 0);
        positions[3] = new Vector3(52, 0, 0);
        
    }

// Update is called once per frame
void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            barrel.transform.position = positions[pos];
            pos++;
            if (pos > 3){
                pos = 0;
            }
        }
    }
}
