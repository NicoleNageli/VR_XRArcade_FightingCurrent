using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectJellyfish : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;
    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        MasterInfo.jellyfishCount++;
        this.gameObject.SetActive(false);
    }
}
