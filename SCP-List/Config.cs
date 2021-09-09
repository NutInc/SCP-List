namespace SCP_List
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Whether the player has to be a SCP to run the command.")]
        public bool MustBeSCP { get; set; } = true;
    }
}
