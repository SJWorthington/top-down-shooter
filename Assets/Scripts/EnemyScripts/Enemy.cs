using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public abstract void Attack();
    internal abstract void returnToPool();

    private void OnCollisionEnter2D(Collision2D collision) {
        returnToPool();
    }
}
