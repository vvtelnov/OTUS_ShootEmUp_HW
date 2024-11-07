/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class PoolAPI
    {
        ///Keys
        public const int Prefab = 23; // SceneEntity
        public const int PoolContainer = 24; // Transform
        public const int WorldContainer = 25; // Transform
        public const int InitalCount = 26; // int


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SceneEntity GetPrefab(this IEntity obj) => obj.GetValue<SceneEntity>(Prefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetPrefab(this IEntity obj, out SceneEntity value) => obj.TryGetValue(Prefab, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddPrefab(this IEntity obj, SceneEntity value) => obj.AddValue(Prefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasPrefab(this IEntity obj) => obj.HasValue(Prefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelPrefab(this IEntity obj) => obj.DelValue(Prefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetPrefab(this IEntity obj, SceneEntity value) => obj.SetValue(Prefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetPoolContainer(this IEntity obj) => obj.GetValue<Transform>(PoolContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetPoolContainer(this IEntity obj, out Transform value) => obj.TryGetValue(PoolContainer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddPoolContainer(this IEntity obj, Transform value) => obj.AddValue(PoolContainer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasPoolContainer(this IEntity obj) => obj.HasValue(PoolContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelPoolContainer(this IEntity obj) => obj.DelValue(PoolContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetPoolContainer(this IEntity obj, Transform value) => obj.SetValue(PoolContainer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetWorldContainer(this IEntity obj) => obj.GetValue<Transform>(WorldContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetWorldContainer(this IEntity obj, out Transform value) => obj.TryGetValue(WorldContainer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddWorldContainer(this IEntity obj, Transform value) => obj.AddValue(WorldContainer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasWorldContainer(this IEntity obj) => obj.HasValue(WorldContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelWorldContainer(this IEntity obj) => obj.DelValue(WorldContainer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWorldContainer(this IEntity obj, Transform value) => obj.SetValue(WorldContainer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetInitalCount(this IEntity obj) => obj.GetValue<int>(InitalCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetInitalCount(this IEntity obj, out int value) => obj.TryGetValue(InitalCount, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddInitalCount(this IEntity obj, int value) => obj.AddValue(InitalCount, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasInitalCount(this IEntity obj) => obj.HasValue(InitalCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelInitalCount(this IEntity obj) => obj.DelValue(InitalCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInitalCount(this IEntity obj, int value) => obj.SetValue(InitalCount, value);
    }
}
