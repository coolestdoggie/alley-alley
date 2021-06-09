using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStrategy
{
    float Speed { get; set; } 

    void Move();
}
    

