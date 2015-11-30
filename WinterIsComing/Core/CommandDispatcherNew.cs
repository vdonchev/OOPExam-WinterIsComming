namespace WinterIsComing.Core
{
    using Commands;

    public class CommandDispatcherNew : CommandDispatcher
    {
        public override void SeedCommands()
        {
            base.SeedCommands();
            
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
        }
    }
}