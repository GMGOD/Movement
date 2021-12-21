using UnityEngine;

public class AmbulationState : CharacterState
{
    private void OnEnable()
    {
        Character.Animator.CrossFade("Base Layer.Ambulation", 0.25f);
    }

    private void Update()
    {
        int contactCount = 0;

        Vector3 moveDirection = Character.Controller.MoveDirection;

        float targetSpeed = 0.0f;
        if (Character.Controller.IsMoving)
            targetSpeed = Character.Controller.IsRunning ? Character.RunSpeed : Character.MoveSpeed;
        Character.Controller.SetCurrentMoveSpeed(Character.Acceleration, targetSpeed);
        float moveSpeed = Character.Controller.CurrentMoveSpeed;

        if (Character.Controller.IsMoving)
        {
            float turnSpeed = Character.TurnSpeed;
            float groundClampSpeed = -Mathf.Tan(Mathf.Deg2Rad * Character.Controller.Mover.maxFloorAngle)
                * moveSpeed;

            Vector3 moveVelocity = moveDirection * moveSpeed;
            moveVelocity.y = groundClampSpeed;

            Quaternion rotationToMoveDirection = Quaternion.LookRotation(moveDirection);
            Character.transform.rotation = Quaternion.RotateTowards(Character.transform.rotation,
                rotationToMoveDirection, turnSpeed * Time.deltaTime);

            Character.Controller.Mover.Move(moveVelocity * Time.deltaTime, Character.Controller.moveContacts, out contactCount);
        }
        Character.Animator.SetFloat("MoveSpeed", moveSpeed / Character.RunSpeed);
    }
}
