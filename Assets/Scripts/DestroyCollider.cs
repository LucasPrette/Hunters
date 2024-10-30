using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollider : MonoBehaviour
{

    private Rigidbody2D body;
    public Transform playerCheck;
    public LayerMask playerLayer;


    void Start() {

    }


    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            print("mouse button 0 clicked");
            checkPlayer();
        }
    }



    bool checkPlayer() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerCheck.position, 0.9f, playerLayer);

        for(int i = 0; i < colliders.Length; i++) {
            if(colliders[i].gameObject != gameObject) {
                Destroy(gameObject);
                return true;
            }
        }
        return false;
    }
}