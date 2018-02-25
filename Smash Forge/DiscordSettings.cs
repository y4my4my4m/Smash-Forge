﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash_Forge
{
    class DiscordSettings
    {
        public enum ImageKeyMode
        {
            Default,
            UserPicked,
            LastFileOpened
        }

        // Fields to be saved between runs
        public static ImageKeyMode imageKeyMode;
        public static string userPickedImageKey = "forge";
        public static bool useUserModName;
        public static string userNamedMod = "ModNameHere";
        public static bool showLastOpenedFile;
        public static bool showTimeElapsed;
        public static DiscordController DiscordController;

        public static void Update()
        {
            if (imageKeyMode == ImageKeyMode.Default)
            {
                DiscordController.presence = new DiscordRpc.RichPresence()
                {
                    smallImageKey = "",
                    smallImageText = "",
                    largeImageKey = "forge",
                    largeImageText = ""
                };
            }
            else if (imageKeyMode == ImageKeyMode.UserPicked)
            {
                DiscordController.presence = new DiscordRpc.RichPresence()
                {
                    smallImageKey = "",
                    smallImageText = "",
                    largeImageKey = userPickedImageKey,
                    largeImageText = ""
                };
            }
            else
            {
                string key = "file";
                if (lastFileOpened.EndsWith("vbn"))
                    key = "vbn";
                if (lastFileOpened.EndsWith("nud"))
                    key = "nud";
                if (lastFileOpened.EndsWith("nut"))
                    key = "nut";
                if (lastFileOpened.EndsWith("omo") || lastFileOpened.EndsWith("anim") || lastFileOpened.EndsWith("pac"))
                    key = "big_icon_anim";

                DiscordController.presence = new DiscordRpc.RichPresence()
                {
                    smallImageKey = "",
                    smallImageText = "",
                    largeImageKey = userPickedImageKey,
                    largeImageText = ""
                };
            }

            if (!useUserModName)
                DiscordController.presence.state = "Working on a mod";
            else
                DiscordController.presence.state = $"Working on {userNamedMod}";

            DiscordRpc.UpdatePresence(DiscordController.presence);
        }

        //Temporary, don't save to config
        public static string lastFileOpened = null;
    }
}
