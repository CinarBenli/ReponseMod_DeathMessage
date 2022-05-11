using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReponseMod_DeathMessage
{
    public class Class1: RocketPlugin<Config>
    {
        protected override void Load()
        {
            base.Load();
            UnturnedPlayerEvents.OnPlayerDeath += Death;
        }

        private void Death(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
          UnturnedPlayer pl = UnturnedPlayer.FromCSteamID(murderer);
            if (Configuration.Instance.Language == "TR")
            {

                if (cause == EDeathCause.GUN || cause == EDeathCause.MELEE || cause == EDeathCause.KILL || cause == EDeathCause.ROADKILL || cause == EDeathCause.GRENADE || cause == EDeathCause.VEHICLE || cause == EDeathCause.LANDMINE || cause == EDeathCause.MISSILE || cause == EDeathCause.CHARGE || cause == EDeathCause.SENTRY)
                {
                    Message($"<color=orange>{player.CharacterName}</color>, <color=green>{pl.CharacterName}</color> Adlı Kullanıcı Tarafından <color=yellow>{pl.Player.equipment.asset.name}</color> İle Öldürüldü <color=red>[<color=orange>HP</color><color=white>{pl.Health}</color>]</color>");
                    return;
                }
                Message($"<color=orange>{player.CharacterName}</color>, Öldü!");
            }
            else
            {

                if (cause == EDeathCause.GUN || cause == EDeathCause.MELEE || cause == EDeathCause.KILL || cause == EDeathCause.ROADKILL || cause == EDeathCause.GRENADE || cause == EDeathCause.VEHICLE || cause == EDeathCause.LANDMINE || cause == EDeathCause.MISSILE || cause == EDeathCause.CHARGE || cause == EDeathCause.SENTRY)
                {
                    Message($"<color=orange>{player.CharacterName}</color>, <color=green>{pl.CharacterName}</color> By The Named User <color=yellow>{pl.Player.equipment.asset.name}</color> Was Killed With <color=red>[<color=orange>HP</color><color=white>{pl.Health}</color>]</color>");
                    return;
                }
                Message($"<color=orange>{player.CharacterName}</color>, Died!");
            }
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            {"WarningExit","<color=red>WARNİNG |</color>You Can't Get Off Because The Car Is Packed"},
            {"WarningSpeed","<color=red>WARNİNG |</color>You Can't Perform This Operation Because The Car Is Fast."},
            {"WarningSeat","<color=red>WARNİNG |</color>You Can't Get in the Driver's Seat Because The Car Isn't Yours."},
            {"GettingIntoTheCar","<color=red>WARNİNG |</color> You'll Be In the Car In 5 Seconds."}


        };

        public void Message(string Message)
        {
            ChatManager.serverSendMessage(Message, Color.white, null, null, EChatMode.SAY, Configuration.Instance.ServerLogo, true);
        }
    }
}
