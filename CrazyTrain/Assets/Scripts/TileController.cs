using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour 
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
