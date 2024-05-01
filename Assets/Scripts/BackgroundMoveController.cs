using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMoveController : MonoBehaviour
{
    [SerializeField]
    private float backgroundMoveSpeed = 3f;

    private float backgroundPositionY = 0f;
    private float backgroundSizeY;

    void Start()
    {
        var image = GetComponent<SpriteRenderer>();
        backgroundSizeY = image.bounds.size.y;
    }

    private void Update()
    {
        backgroundPositionY += Time.deltaTime * backgroundMoveSpeed;
        backgroundPositionY = Mathf.Repeat(backgroundPositionY, backgroundSizeY);
        transform.position = new Vector3(0, -backgroundPositionY, 0);
    }
}
