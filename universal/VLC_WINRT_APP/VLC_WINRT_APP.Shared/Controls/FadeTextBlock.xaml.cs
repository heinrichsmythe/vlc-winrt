﻿using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.Extensions;

namespace VLC_WINRT_APP.Controls
{
    public sealed partial class FadeTextBlock : UserControl
    {
        private DispatcherTimer Timer;
        public FadeTextBlock()
        {
            this.InitializeComponent();
        }

        void CreateDispatcher()
        {
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 5);
            Timer.Tick += async (sender, o) => await Hide();
        }

        public async Task Show()
        {
            await App.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.FadeIn();
                if (Timer == null || !Timer.IsEnabled)
                {
                    CreateDispatcher();
                    Timer.Start();
                }
            });
        }

        async Task Hide()
        {
            await App.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.FadeOut();
                Timer.Stop();
            });
        }
    }
}
