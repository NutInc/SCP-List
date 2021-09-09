namespace SCP_List
{
    using System;
    using Exiled.API.Features;
    
    public class SCPList : Plugin<Config>
    {
        public override string Author { get; } = "Parkeymon";
        public override string Name { get; } = "SCPList";
        public override string Prefix { get; } = "scplist";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 8, 0, 0);

        public static SCPList Singleton;

        public override void OnEnabled()
        {
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}
