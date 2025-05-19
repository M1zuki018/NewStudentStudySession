using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript_0 : MonoBehaviour
{
    [SerializeField] private string _text = "text";
  
    private void Start()
    {
        Debug.Log(_text);
    }
}
