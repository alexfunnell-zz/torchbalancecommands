using Sandbox.Engine.Multiplayer;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System.Collections.Generic;
using System.Diagnostics;
using Torch;
using Torch.API;
using Torch.Managers.PatchManager;
using VRage.Game.ModAPI;
using VRage.Network;

namespace TorchBalanceCommandPlugin
{
    /// <summary>
    /// Plugin that lets you profile entities 
    /// </summary>
    public class TorchBalanceCommandsPlugin : TorchPluginBase
    {
        /// <inheritdoc cref="TorchPluginBase.Init"/>
        public override void Init(ITorchBase torch)
        {
            Debugger.Launch();
        }

    }
}
