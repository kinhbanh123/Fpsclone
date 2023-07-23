using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float secToShot = 5;
    [SerializeField] Animator animator;
    [SerializeField] float health = 1;
    bool isDie = false;
    int i = 0;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            health = health - 1;
            if (health <= 0.9999)
            {
                isDie = true;
                StartCoroutine(Die());
            }
        }

    }
    void Start()
    {
        StartCoroutine(Wait1Sec());
    }

        // Update is called once per frame
        IEnumerator Die()
        {
            animator.SetBool("Death", true);
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
        IEnumerator Wait1Sec()
        {
        
        while (isDie == false)
        {
            
            if (i == secToShot)
            {
                i = 0;
                Debug.Log("PEW");
            }
            else if (isDie == true)
            {
                Debug.Log("DaDie");
            }
            else
            {
                yield return new WaitForSeconds(1f);
                i = i +1;
                //Debug.Log(i);
            }

        }
      
        }

    
}
