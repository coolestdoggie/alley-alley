using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] PlayerController player;
    float yVelocity = 0.0f;
    float smoothTime = 0.3f;

    private void Start()
    {
        transform.position = new Vector2(0f, player.transform.position.y);

    }

    void Update()
    {
        if (transform.position.y > player.transform.position.y)
        {
            return;
        }

        float newPosition = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref yVelocity, smoothTime);

        transform.position = new Vector2(0f, newPosition);
    }
}
