using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private SkeletonAnimation _animation;
    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        _animation.AnimationName = "";
    }
}
