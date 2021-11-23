using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform ChildTarget;

    [SerializeField] float LayerOffset = 1.5f;
    [SerializeField] float LayerInterval = 1f;
    [SerializeField] float MaxLayers = 3;
    float currentLayer = 0;
    bool canJumpLayers = true;

    [SerializeField] float RotationSpeed = 10;


    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        if(verticalInput < -0.2f)
            verticalInput = -1;
        else if(verticalInput > 0.2f)
            verticalInput = 1;
        else
            verticalInput = 0;

        if(verticalInput == 0){
            canJumpLayers = true;
        } else if(canJumpLayers){
            if(verticalInput == 1 && currentLayer < MaxLayers){
                currentLayer++;
                canJumpLayers = false;
            } else if(verticalInput == -1 && currentLayer > 0){
                currentLayer--;
                canJumpLayers = false;
            }
        }
        ChildTarget.localPosition = new Vector3(0,LayerOffset + LayerInterval*currentLayer,0);

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        float currentLayerCircumference = 2*Mathf.PI*(LayerOffset + LayerInterval*currentLayer);
        float degree = (360*RotationSpeed/currentLayerCircumference)*Time.deltaTime;

        transform.Rotate(new Vector3(0,0,-degree*horizontalInput));
    }
}
