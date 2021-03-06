﻿using Aurora.Profiles.Payday_2.GSI;
using Aurora.Profiles.Payday_2.Layers;
using Aurora.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Aurora.Profiles.Payday_2
{
    public class PD2 : Application
    {
        public PD2()
            : base(new LightEventConfig { Name = "Payday 2", ID = "pd2", AppID= "218620", ProcessNames = new[] { "payday2_win32_release.exe" }, ProfileType = typeof(PD2Profile), OverviewControlType = typeof(Control_PD2), GameStateType = typeof(GSI.GameState_PD2), Event = new GameEvent_PD2(), IconURI = "Resources/pd2_64x64.png" })
        {
            var extra = new List<LayerHandlerEntry>
            {
                new LayerHandlerEntry("PD2Background", "Payday 2 Background Layer", typeof(PD2BackgroundLayerHandler)),
                new LayerHandlerEntry("PD2Flashbang", "Payday 2 Flashbang Layer", typeof(PD2FlashbangLayerHandler)),
                new LayerHandlerEntry("PD2States", "Payday 2 States Layer", typeof(PD2StatesLayerHandler)),
            };

            Global.LightingStateManager.RegisterLayerHandlers(extra, false);

            foreach (var entry in extra)
            {
                Config.ExtraAvailableLayers.Add(entry.Key);
            }

            
        }
    }
}
