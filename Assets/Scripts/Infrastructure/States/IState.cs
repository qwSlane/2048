﻿namespace Infrastructure.States {

    public interface IState: IExitableState {

        void Enter();

    }

    public interface IExitableState {
        void Exit();
    }
    
    public interface IPayloadState<TPayload>: IExitableState {

        void Enter(TPayload payLoad);
    }

}