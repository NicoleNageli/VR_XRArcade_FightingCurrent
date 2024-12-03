using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    [SerializeField]
    private Transform demoCube;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(10f, 2f)
        .SetEase(Ease.InBounce)
        .SetLoops(-1, LoopType.Yoyo);

        demoCube.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360)
        .SetEase(Ease.InOutQuad)
        .SetLoops(-1);

        demoCube.DOLocalMoveY(2, 2f)
        .SetEase(Ease.InOutCubic)
        .SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
