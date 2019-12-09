using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test_dotween : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //transform.DOtween
        transform.DOMoveX(100, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
