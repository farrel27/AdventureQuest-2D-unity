using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState2 : StateMachineBehaviour
{
    Transform target;
    public float speed = 3;
    Transform borderCheck;
    Transform borderCheck2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        borderCheck = animator.GetComponent<Yillo>().borderCheck;
        borderCheck2 = animator.GetComponent<Yillo>().borderCheck2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 newPos = new Vector2(target.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 1.5f)
            animator.SetBool("isAttacking", true);

        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 3) == false || Physics2D.Raycast(borderCheck2.position, Vector2.down, 3) == false || distance > 10)
            animator.SetBool("isChasing", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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
}
