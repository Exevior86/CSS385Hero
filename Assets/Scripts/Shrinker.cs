using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinker : MonoBehaviour
{
    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        //float endTime = HeroBehavior.cooldown;
        rt.sizeDelta = new Vector2((200 / HeroBehavior.cooldown) * HeroBehavior.cooldownTimer , rt.rect.height);
    }
}
