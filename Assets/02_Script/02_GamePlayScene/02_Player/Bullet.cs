using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    { }
    void Update()
    { }
    internal void OnDisapearEdge() 
    {
        Destroy(gameObject);
    }
    internal void OnDisapearFoe()
    {
        Destroy(gameObject);
    }
    internal void OnDisapearPlayer()
    {
        Destroy(gameObject);
    }
}
