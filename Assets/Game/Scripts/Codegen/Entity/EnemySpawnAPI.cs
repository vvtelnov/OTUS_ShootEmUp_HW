/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class EnemySpawnAPI
    {
        ///Keys
        public const int OnEnemySpawnRequested = 32; // BaseEvent
        public const int OnEnemyIsSpawning = 39; // BaseEvent<Vector3>
        public const int OnEnemySpawned = 8; // BaseEvent
        public const int SpawnDistance = 40; // float


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetOnEnemySpawnRequested(this IEntity obj) => obj.GetValue<BaseEvent>(OnEnemySpawnRequested);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnEnemySpawnRequested(this IEntity obj, out BaseEvent value) => obj.TryGetValue(OnEnemySpawnRequested, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnEnemySpawnRequested(this IEntity obj, BaseEvent value) => obj.AddValue(OnEnemySpawnRequested, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnEnemySpawnRequested(this IEntity obj) => obj.HasValue(OnEnemySpawnRequested);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnEnemySpawnRequested(this IEntity obj) => obj.DelValue(OnEnemySpawnRequested);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnEnemySpawnRequested(this IEntity obj, BaseEvent value) => obj.SetValue(OnEnemySpawnRequested, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<Vector3> GetOnEnemyIsSpawning(this IEntity obj) => obj.GetValue<BaseEvent<Vector3>>(OnEnemyIsSpawning);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnEnemyIsSpawning(this IEntity obj, out BaseEvent<Vector3> value) => obj.TryGetValue(OnEnemyIsSpawning, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnEnemyIsSpawning(this IEntity obj, BaseEvent<Vector3> value) => obj.AddValue(OnEnemyIsSpawning, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnEnemyIsSpawning(this IEntity obj) => obj.HasValue(OnEnemyIsSpawning);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnEnemyIsSpawning(this IEntity obj) => obj.DelValue(OnEnemyIsSpawning);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnEnemyIsSpawning(this IEntity obj, BaseEvent<Vector3> value) => obj.SetValue(OnEnemyIsSpawning, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetOnEnemySpawned(this IEntity obj) => obj.GetValue<BaseEvent>(OnEnemySpawned);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnEnemySpawned(this IEntity obj, out BaseEvent value) => obj.TryGetValue(OnEnemySpawned, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnEnemySpawned(this IEntity obj, BaseEvent value) => obj.AddValue(OnEnemySpawned, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnEnemySpawned(this IEntity obj) => obj.HasValue(OnEnemySpawned);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnEnemySpawned(this IEntity obj) => obj.DelValue(OnEnemySpawned);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnEnemySpawned(this IEntity obj, BaseEvent value) => obj.SetValue(OnEnemySpawned, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetSpawnDistance(this IEntity obj) => obj.GetValue<float>(SpawnDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSpawnDistance(this IEntity obj, out float value) => obj.TryGetValue(SpawnDistance, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSpawnDistance(this IEntity obj, float value) => obj.AddValue(SpawnDistance, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSpawnDistance(this IEntity obj) => obj.HasValue(SpawnDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSpawnDistance(this IEntity obj) => obj.DelValue(SpawnDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSpawnDistance(this IEntity obj, float value) => obj.SetValue(SpawnDistance, value);
    }
}
