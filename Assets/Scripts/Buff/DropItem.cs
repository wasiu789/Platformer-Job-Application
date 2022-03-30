using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField]
    public GameObject[] dropitems;
    private int itemNum;
    private int randNum;
    private Transform Epos;

    private void Start()
    {
        Epos = GetComponent<Transform>();
        Debug.Log(dropitems);
    }

    public void DropItems()
    {
        //Generates a random number fromm 0 to 100;
        randNum = Random.Range(0, 101); 
        Debug.Log("Random Number is " + randNum);


        //The Rare Item
        if (randNum >= 95) 
        {
            //Checks hat is itemNum2 and drops it at the position of the object
            itemNum = 2;
            Instantiate(dropitems[itemNum], Epos.position, Quaternion.identity);
          


        }
        //The Uncommon Item
        else if (randNum > 75 && randNum < 95) 
        {

            itemNum = 1;
            
            Instantiate(dropitems[itemNum], Epos.position, Quaternion.identity);
           

        }
        //The Common Item
        else if (randNum > 40 && randNum <= 75)
        {
            
            itemNum = 0;
            
            Instantiate(dropitems[itemNum], Epos.position, Quaternion.identity);
           

        }
    }
}
