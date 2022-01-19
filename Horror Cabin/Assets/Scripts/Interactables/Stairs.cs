using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    private PolygonCollider2D mCollider;
    
    private void Start() => mCollider = GetComponent<PolygonCollider2D>();

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Player") && Input.GetKey(KeyCode.S)) {
            mCollider.enabled = false;
            StartCoroutine(ColliderDeactivate());
        }
    }
    private IEnumerator ColliderDeactivate() {
        yield return new WaitForSeconds(1);
        mCollider.enabled = true;
        yield return null;
    }
}
