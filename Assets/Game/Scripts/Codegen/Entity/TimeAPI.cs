/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class TimeAPI
    {
        ///Keys
        public const int Timer = 27; // Timer
        public const int TimerDuration = 28; // float


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Timer GetTimer(this IEntity obj) => obj.GetValue<Timer>(Timer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTimer(this IEntity obj, out Timer value) => obj.TryGetValue(Timer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTimer(this IEntity obj, Timer value) => obj.AddValue(Timer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTimer(this IEntity obj) => obj.HasValue(Timer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTimer(this IEntity obj) => obj.DelValue(Timer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTimer(this IEntity obj, Timer value) => obj.SetValue(Timer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetTimerDuration(this IEntity obj) => obj.GetValue<float>(TimerDuration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTimerDuration(this IEntity obj, out float value) => obj.TryGetValue(TimerDuration, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTimerDuration(this IEntity obj, float value) => obj.AddValue(TimerDuration, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTimerDuration(this IEntity obj) => obj.HasValue(TimerDuration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTimerDuration(this IEntity obj) => obj.DelValue(TimerDuration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTimerDuration(this IEntity obj, float value) => obj.SetValue(TimerDuration, value);
    }
}
