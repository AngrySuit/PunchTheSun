using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDroper : MonoBehaviour
{
    [SerializeField] private GameObject bootleSmall;
    [SerializeField] private GameObject bootleLarge;
    [SerializeField] private GameObject Cigarete;

    public void DropItems()
    {
        float Drop = UnityEngine.Random.Range(0f, 1f);

        if (Drop < 0.1f )
        {
            GameObject.Instantiate(bootleLarge,transform.position,Quaternion.identity);
        }
        else if (Drop < 0.3f)
        {
            GameObject.Instantiate(bootleSmall, transform.position, Quaternion.identity);
        }
        else if (Drop < 0.7f)
        {
            GameObject.Instantiate(Cigarete, transform.position, Quaternion.identity);
        }
        else return;
    }
}
