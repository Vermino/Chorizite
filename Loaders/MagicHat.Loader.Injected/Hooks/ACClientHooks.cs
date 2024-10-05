﻿using AcClient;
using Iced.Intel;
using MagicHat.Core.Render;
using MagicHat.Loader.Injected.Lib;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicHat.Loader.Injected.Hooks {
    internal unsafe class ACClientHooks : HookBase {
        private static IHook<Client_Cleanup> _clientCleanupHook;
        private static IHook<Client_IsAlreadyRunning> _clientIsAlreadyRunningHook;
        private static IHook<UIFlow_UseNewMode> _uiFlowUseNewModeHook;

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Client_Cleanup(IntPtr client);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate byte Client_IsAlreadyRunning(IntPtr client);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate uint UIFlow_UseNewMode(UIFlow* uiFlow);

        internal static void Init() {
            _clientCleanupHook = CreateHook<Client_Cleanup>(typeof(ACClientHooks), nameof(Client_Cleanup_Impl), 0x004118D0);
            _clientIsAlreadyRunningHook = CreateHook<Client_IsAlreadyRunning>(typeof(ACClientHooks), nameof(Client_IsAlreadyRunning_Impl), 0x004122A0);
            _uiFlowUseNewModeHook = CreateHook<UIFlow_UseNewMode>(typeof(ACClientHooks), nameof(UIFlow_UseNewMode_Impl), 0x00479AA0);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvThiscall) })]
        private static void Client_Cleanup_Impl(IntPtr client) {
            InjectedLoader.Input?.HandleShutdown();
            _clientCleanupHook.OriginalFunction(client);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static byte Client_IsAlreadyRunning_Impl(IntPtr client) {
            _clientIsAlreadyRunningHook.OriginalFunction(client);
            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static uint UIFlow_UseNewMode_Impl(UIFlow* uiFlow) {
            var mode = uiFlow->_nextMode;
            var ret = _uiFlowUseNewModeHook.OriginalFunction(uiFlow);
            InjectedLoader.Render?.ShowGameScreen((GameScreen)mode);

            return ret;
        }
    }
}