using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksLanther : MonoBehaviour
{
    public GameObject fireworks;

    private int firingflag = 0;

    void Update()
    {
        if (firingflag == 0)
        {
            Invoke("Firing1", 0.0f);
            Invoke("Firing2", 0.4f);
            Invoke("Firing3", 0.8f);
            firingflag = 1;
            Invoke("ResetFlag", 2.0f);
        }
    }

    private void Firing1()
    {
        Instantiate(fireworks, new Vector3(6.0f, 3.0f, 0.0f), Quaternion.identity);
    }
    private void Firing2()
    {
        Instantiate(fireworks, new Vector3(-5.0f, 0.0f, 0.0f), Quaternion.identity);
    }
    private void Firing3()
    {
        Instantiate(fireworks, new Vector3(2.0f, -3.0f, 0.0f), Quaternion.identity);
    }
    private void ResetFlag()
    {
        //クローン削除
        var clones = GameObject.FindGameObjectsWithTag("fireworks");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        firingflag = 0;
    }
}
