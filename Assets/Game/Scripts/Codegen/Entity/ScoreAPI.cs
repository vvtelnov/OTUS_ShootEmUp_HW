/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class ScoreAPI
    {
        ///Keys
        public const int Score = 44; // ReactiveVariable<int>
        public const int StartScore = 45; // int


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetScore(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(Score);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetScore(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(Score, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddScore(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(Score, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasScore(this IEntity obj) => obj.HasValue(Score);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelScore(this IEntity obj) => obj.DelValue(Score);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetScore(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(Score, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetStartScore(this IEntity obj) => obj.GetValue<int>(StartScore);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetStartScore(this IEntity obj, out int value) => obj.TryGetValue(StartScore, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddStartScore(this IEntity obj, int value) => obj.AddValue(StartScore, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasStartScore(this IEntity obj) => obj.HasValue(StartScore);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelStartScore(this IEntity obj) => obj.DelValue(StartScore);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetStartScore(this IEntity obj, int value) => obj.SetValue(StartScore, value);
    }
}
