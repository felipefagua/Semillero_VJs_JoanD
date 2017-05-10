﻿using UnityEngine;
using System.Collections;

public class StatePursuitEnemy : State {
	public Transform enemy;
	public float speed;
	private Vector3 direcction;
    public GameObject me;
	public Transform myTransform;
    private EnemyHealth myHealt;
    private bool isDead = false;
    private Animator animator;

    public override void OnEntryAction(){
        animator = me.GetComponent<Animator>();
        playWalkingAnimation();
    }
	
	public override void OnUpdateAction(){
        if (me.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            isDead = true;
        }

        UnityEngine.AI.NavMeshAgent nav = me.GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.SetDestination(enemy.position);
	}
	
	public override void OnExitAction(){
        isDead = false;
	}
	public void transformRotation(){
		float orientation = Mathf.Atan2(direcction.x,direcction.z);
		orientation *= Mathf.Rad2Deg;
		Quaternion newRotation = new Quaternion();
		newRotation.eulerAngles = new Vector3(0,orientation,0);
		myTransform.rotation = newRotation;
	}
    public bool enemyOnAtackZone() {
        return Vector3.Distance(myTransform.position, enemy.position) <3;
    }
    public bool ImDead(){
        return isDead;
    }
    private void playWalkingAnimation() {
        animator.Play("Walk");
    }
}
