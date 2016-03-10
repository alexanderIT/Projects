namespace Game.Common
{
    using System;

    public interface IUserInput
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        void ProcessInput();//check what is pressed and produce action
    }
}
