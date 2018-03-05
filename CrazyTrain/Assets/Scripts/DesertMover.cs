using UnityEngine;
using System.Collections;

public class DesertMover : MonoBehaviour
{
    public Transform ground1;
    public Transform ground2;

    float multiper = 1;
    public Transform player;
    Transform currentGround;

    bool isGround1=true;
    int offset = 27;

    private void Start()
    {
        currentGround = ground1;    
    }

    void Update()
    {
        ChangeBG();
    }

    void ChangeBG()
    {
        if (player.position.x - currentGround.position.x > offset)
        {
            isGround1 = !isGround1;

            currentGround.position = new Vector3(offset*2 + currentGround.position.x, currentGround.position.y, currentGround.position.z);
            currentGround = isGround1 == true ? ground1 : ground2;
           
            multiper++;
        }
    }
}
