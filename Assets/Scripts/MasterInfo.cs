using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int jellyfishCount = 0;
    [SerializeField] GameObject jellyfishDisplay;
    void Update()
    {
        jellyfishDisplay.GetComponent<TMPro.TMP_Text>().text = "JELLYFISH: " + jellyfishCount;
    }
}
