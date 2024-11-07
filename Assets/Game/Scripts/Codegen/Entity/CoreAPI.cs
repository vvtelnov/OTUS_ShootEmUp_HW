/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class CoreAPI
    {
        ///Keys
        public const int Transform = 10; // Transform
        public const int TargetTransform = 18; // Transform


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetTransform(this IEntity obj) => obj.GetValue<Transform>(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTransform(this IEntity obj, out Transform value) => obj.TryGetValue(Transform, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTransform(this IEntity obj, Transform value) => obj.AddValue(Transform, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTransform(this IEntity obj) => obj.HasValue(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTransform(this IEntity obj) => obj.DelValue(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTransform(this IEntity obj, Transform value) => obj.SetValue(Transform, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetTargetTransform(this IEntity obj) => obj.GetValue<Transform>(TargetTransform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTargetTransform(this IEntity obj, out Transform value) => obj.TryGetValue(TargetTransform, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTargetTransform(this IEntity obj, Transform value) => obj.AddValue(TargetTransform, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTargetTransform(this IEntity obj) => obj.HasValue(TargetTransform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTargetTransform(this IEntity obj) => obj.DelValue(TargetTransform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTargetTransform(this IEntity obj, Transform value) => obj.SetValue(TargetTransform, value);
    }
}
