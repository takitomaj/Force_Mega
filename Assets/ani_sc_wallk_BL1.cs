using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ani_sc_wallk_BL1 : StateMachineBehaviour
{
    public float Speed = 2.5f;
    
    Transform player;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float dist = Vector2.Distance(player.position, rb.position);
        if(dist<18f) { 
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPosition= Vector2.MoveTowards(rb.position,target,Speed*Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    /*
     *  StartCoroutine(voltear(2f,treu));
       

 
     IEnumerator voltear( float segundos, bool derecha)
    {

        yield return new WaitForSeconds(segundos);
        if (derecha) { 
            boss.Rotate(0f, 180f, 0f);
        }else{
            boss.Rotate(0f, 0f, 0f);
        }
    }
     */


}
