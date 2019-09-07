using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torch.Commands;
using Torch.Commands.Permissions;
using VRage.Game.ModAPI;

namespace TorchBalanceCommandPlugin
{

    [Category("addbalance")]
    public class TorchBalanceCommands : CommandModule
    {
        [Command("player","adds given balance to the player","addbalance player [playerName or SteamId] [amount]")]
        [Permission(MyPromoteLevel.Admin)]
        public void AddPlayerBalance()
        {
            if (Context.Args.Count != 2)
            {
                Context.Respond("try !addbalance player [player name or steamId] [amount]");
                return;
            }

            //Try find the player by name or steam id
            List<IMyPlayer> player = new List<IMyPlayer>();
            ulong steamid;
            MyAPIGateway.Players.GetPlayers(player,
                (x) => x.DisplayName == Context.Args[0]
                || (ulong.TryParse(Context.Args[0], out steamid) && x.SteamUserId == steamid));

            if (player.Count == 0)
            {
                Context.Respond($"player {Context.Args[0]} not found");
                return;
            }

            //Try parse amount
            long amount;
            if (!long.TryParse(Context.Args[1], out amount))
            {
                Context.Respond($"{Context.Args[1]} is not a valid amount");
                return;
            }

            player.First().RequestChangeBalance(amount);
            Context.Respond($"Player {Context.Args[0]} balance changed by {amount}");
        }
        
        [Command("faction", "adds given balance to the faction", "addbalance faction [factionTag] [amount]")]
        [Permission(MyPromoteLevel.Admin)]
        public void AddFactionBalance()
        {
       
            if (Context.Args.Count != 2)
            {
                Context.Respond("try !addbalance faction [factionTag] [amount]");
                return;
            }

            //Try find the faction by name
            IMyFaction faction = MyAPIGateway.Session.Factions.Factions
                .FirstOrDefault(f => string.Compare(f.Value.Tag, Context.Args[0], true) == 0).Value;

            if (faction == null)
            {
                Context.Respond($"faction {Context.Args[0]} not found");
                return;
            }

            //Try parse amount
            long amount;
            if (!long.TryParse(Context.Args[1], out amount))
            {
                Context.Respond($"{Context.Args[1]} is not a valid amount");
                return;
            }

            faction.RequestChangeBalance(amount);
            Context.Respond($"Faction {Context.Args[0]} balance changed by {amount}");
    }
    }
}
