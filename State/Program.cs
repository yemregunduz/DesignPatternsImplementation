using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new();
            ModifiedState modifiedState = new();
            modifiedState.DoAction(context);
            DeletedState deleted = new();
            deleted.DoAction(context);

            Console.WriteLine("Context state: {0}",context.GetState().ToString());

        }
    }
    interface IState
    {
        void DoAction(Context context );
    }
    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Modified.");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Modified";
        }
    }
    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Deleted.");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Added.");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }
    class Context
    {
        IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }
        public IState GetState()
        {
            return _state;
        }
    }
}
