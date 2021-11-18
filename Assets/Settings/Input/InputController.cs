using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Controls controls;
    
    private void Awake() {
        controls = new Controls();
    }

    private void OnEnable() {
        controls.Gameplay.Enable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
