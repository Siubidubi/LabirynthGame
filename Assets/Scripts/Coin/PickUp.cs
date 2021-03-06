using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void Pick()
    {
        Debug.Log("Podniesiono");
        Destroy(this.gameObject);
    }
    
}
