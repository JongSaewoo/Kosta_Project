using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public bool fatal = false;
    public GameObject limbPrefab;

    public void Hit()
    {
        Limb childlimb = transform.GetChild(0).GetComponentInChildren<Limb>();
        if (childlimb)
            childlimb.Hit();

        transform.localScale = Vector3.zero;

        GameObject spawnedLimb = Instantiate(limbPrefab, transform.parent);
        spawnedLimb.transform.parent = null;
        Destroy(spawnedLimb, 10);


        if (fatal)
        {
            Zombie zombieParent = GetComponentInParent<Zombie>();
            if (zombieParent)
                zombieParent.Death();
        }

        Destroy(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
            Hit();
    }
}
