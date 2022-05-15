
using UnityEngine;

public class EnemyFirePoint : MonoBehaviour
{
    [SerializeField] private Transform enemy;
    public GameObject wizard;

    private void Update()
    {
            transform.localScale = enemy.localScale;
        Disable();
        
       
        
    }
    private void Disable()
    {
        if (!wizard.activeSelf)
        {
            this.GetComponent<EnemyFirePoint>().enabled = true;
           
        }
        
            
        
    }

}
