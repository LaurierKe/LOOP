using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private CharacterController  _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,  Input.GetAxisRaw("Vertical")).normalized * speed;
        
        _characterController.Move(input* Time.deltaTime) ;
    }
}
