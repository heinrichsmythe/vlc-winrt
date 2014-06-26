﻿using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using VLC_WINRT.Common;
using VLC_WINRT_APP.ViewModels;
using VLC_WINRT_APP.ViewModels.Others.VlcExplorer;

namespace VLC_WINRT_APP.Commands.RemovableDevices
{
    public class RemovableDeviceClickedCommand : AlwaysExecutableCommand
    {
        public override void Execute(object parameter)
        {
            FileExplorerViewModel fileExplorer = (parameter as SelectionChangedEventArgs).AddedItems[0] as FileExplorerViewModel;
            Locator.ExternalStorageVM.CurrentStorageVM = fileExplorer;
            Task.Run(()=>Locator.ExternalStorageVM.CurrentStorageVM.GetFiles());
        }
    }
}
