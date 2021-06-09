using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] float padding = .1f;

    float xMin;
    float xMax;

    IMoveStrategy moveStrategy;
    public IMoveStrategy MoveStrategy { get => moveStrategy; set => moveStrategy = value; }

    public float Padding { get => padding; set => padding = value; }

    private void Awake()
    {
        MoveStrategy = GetComponent<IMoveStrategy>();
    }

    public void Move()
    {
        MoveStrategy.Move();

    }

    

    public void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Padding;
    }
}
