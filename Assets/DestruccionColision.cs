using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionColision : MonoBehaviour
{
    /*
     * public GameObject hitEffectM
     * ... dentro de onColision:
     *  GameObject effect = Instantiate( hitEffect, transform.position, Quaternion.identity);
     *  Destroy(effect,5f); // asi reproduce la animacion
     */

    // alternativamente destruye la bala luego de tantos segundos
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
