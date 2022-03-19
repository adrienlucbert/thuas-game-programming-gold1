using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace PlayerStates
{
    public class IdleState : State
    {
        public override string GetName()
        {
            return "IdleState";
        }

        public override void Update()
        {
            if (Input.GetButtonDown("Jump"))
                this.context.SetState(new JumpingState());
            else if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
                this.context.SetState(new MovingState());
        }
    }

    public class MovingState : State
    {
        public override string GetName()
        {
            return "MovingState";
        }

        public override void Update()
        {
            if (Input.GetButtonDown("Jump"))
                this.context.SetState(new JumpingState());
            else if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
                this.context.SetState(new IdleState());
        }
    }

    public class JumpingState : State
    {
        public override string GetName()
        {
            return "JumpingState";
        }

        public override void Update()
        {
            if (Input.GetButtonDown("Jump"))
                this.context.SetState(new HoveringState());

        }
    }

    public class HoveringState : State
    {
        public override string GetName()
        {
            return "HoveringState";
        }

        public override void Update()
        {
            if (Input.GetButtonDown("Jump"))
                this.context.SetState(new IdleState());

        }
    }
}

public class PlayerController : MonoBehaviour, IStateContext
{
    [SerializeField] private PlayerViewModel viewModel;
    private State state;

    public void SetState(State newState)
    {
        this.state = newState;
        newState.SetContext(this);
        this.viewModel.StateName = state.GetName();
    }

    void Start()
    {
        this.SetState(new PlayerStates.IdleState());
    }

    void Update()
    {
        this.state.Update();
    }
}
