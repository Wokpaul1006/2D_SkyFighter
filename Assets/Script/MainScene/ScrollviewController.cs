using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollviewController : MonoBehaviour
{
    [SerializeField] List<GameObject> ShipList;
    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    // Update is called once per frame

    private void Populate()
    {
        for(int i = 0; i < ShipList.Count; i++) 
        {
            ShipList[i] = Instantiate(ShipList[i], transform);
        } 
    }
}
