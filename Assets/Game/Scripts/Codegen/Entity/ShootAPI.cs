/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class ShootAPI
    {
        ///Keys
        public const int ShootDirection = 5; // Vector3
        public const int Ammo = 6; // ReactiveVariable<uint>
        public const int MaxAmmo = 7; // ReactiveVariable<uint>
        public const int ShootPoint = 20; // Transform
        public const int OnShootRequested = 21; // BaseEvent
        public const int OnShot = 22; // BaseEvent
        public const int FireRate = 46; // ReactiveVariable<float>
        public const int AmmoRestoreTime = 49; // float
        public const int ReloadTime = 50; // float
        public const int OnRemoveBullet = 52; // BaseEvent<IEntity>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 GetShootDirection(this IEntity obj) => obj.GetValue<Vector3>(ShootDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootDirection(this IEntity obj, out Vector3 value) => obj.TryGetValue(ShootDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootDirection(this IEntity obj, Vector3 value) => obj.AddValue(ShootDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootDirection(this IEntity obj) => obj.HasValue(ShootDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootDirection(this IEntity obj) => obj.DelValue(ShootDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootDirection(this IEntity obj, Vector3 value) => obj.SetValue(ShootDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<uint> GetAmmo(this IEntity obj) => obj.GetValue<ReactiveVariable<uint>>(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAmmo(this IEntity obj, out ReactiveVariable<uint> value) => obj.TryGetValue(Ammo, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAmmo(this IEntity obj, ReactiveVariable<uint> value) => obj.AddValue(Ammo, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAmmo(this IEntity obj) => obj.HasValue(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAmmo(this IEntity obj) => obj.DelValue(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAmmo(this IEntity obj, ReactiveVariable<uint> value) => obj.SetValue(Ammo, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<uint> GetMaxAmmo(this IEntity obj) => obj.GetValue<ReactiveVariable<uint>>(MaxAmmo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxAmmo(this IEntity obj, out ReactiveVariable<uint> value) => obj.TryGetValue(MaxAmmo, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxAmmo(this IEntity obj, ReactiveVariable<uint> value) => obj.AddValue(MaxAmmo, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxAmmo(this IEntity obj) => obj.HasValue(MaxAmmo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxAmmo(this IEntity obj) => obj.DelValue(MaxAmmo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxAmmo(this IEntity obj, ReactiveVariable<uint> value) => obj.SetValue(MaxAmmo, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetShootPoint(this IEntity obj) => obj.GetValue<Transform>(ShootPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootPoint(this IEntity obj, out Transform value) => obj.TryGetValue(ShootPoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootPoint(this IEntity obj, Transform value) => obj.AddValue(ShootPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootPoint(this IEntity obj) => obj.HasValue(ShootPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootPoint(this IEntity obj) => obj.DelValue(ShootPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootPoint(this IEntity obj, Transform value) => obj.SetValue(ShootPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetOnShootRequested(this IEntity obj) => obj.GetValue<BaseEvent>(OnShootRequested);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnShootRequested(this IEntity obj, out BaseEvent value) => obj.TryGetValue(OnShootRequested, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnShootRequested(this IEntity obj, BaseEvent value) => obj.AddValue(OnShootRequested, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnShootRequested(this IEntity obj) => obj.HasValue(OnShootRequested);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnShootRequested(this IEntity obj) => obj.DelValue(OnShootRequested);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnShootRequested(this IEntity obj, BaseEvent value) => obj.SetValue(OnShootRequested, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetOnShot(this IEntity obj) => obj.GetValue<BaseEvent>(OnShot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnShot(this IEntity obj, out BaseEvent value) => obj.TryGetValue(OnShot, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnShot(this IEntity obj, BaseEvent value) => obj.AddValue(OnShot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnShot(this IEntity obj) => obj.HasValue(OnShot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnShot(this IEntity obj) => obj.DelValue(OnShot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnShot(this IEntity obj, BaseEvent value) => obj.SetValue(OnShot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetFireRate(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(FireRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetFireRate(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(FireRate, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddFireRate(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(FireRate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFireRate(this IEntity obj) => obj.HasValue(FireRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelFireRate(this IEntity obj) => obj.DelValue(FireRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFireRate(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(FireRate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetAmmoRestoreTime(this IEntity obj) => obj.GetValue<float>(AmmoRestoreTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAmmoRestoreTime(this IEntity obj, out float value) => obj.TryGetValue(AmmoRestoreTime, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAmmoRestoreTime(this IEntity obj, float value) => obj.AddValue(AmmoRestoreTime, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAmmoRestoreTime(this IEntity obj) => obj.HasValue(AmmoRestoreTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAmmoRestoreTime(this IEntity obj) => obj.DelValue(AmmoRestoreTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAmmoRestoreTime(this IEntity obj, float value) => obj.SetValue(AmmoRestoreTime, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetReloadTime(this IEntity obj) => obj.GetValue<float>(ReloadTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetReloadTime(this IEntity obj, out float value) => obj.TryGetValue(ReloadTime, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddReloadTime(this IEntity obj, float value) => obj.AddValue(ReloadTime, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasReloadTime(this IEntity obj) => obj.HasValue(ReloadTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelReloadTime(this IEntity obj) => obj.DelValue(ReloadTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetReloadTime(this IEntity obj, float value) => obj.SetValue(ReloadTime, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<IEntity> GetOnRemoveBullet(this IEntity obj) => obj.GetValue<BaseEvent<IEntity>>(OnRemoveBullet);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnRemoveBullet(this IEntity obj, out BaseEvent<IEntity> value) => obj.TryGetValue(OnRemoveBullet, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnRemoveBullet(this IEntity obj, BaseEvent<IEntity> value) => obj.AddValue(OnRemoveBullet, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnRemoveBullet(this IEntity obj) => obj.HasValue(OnRemoveBullet);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnRemoveBullet(this IEntity obj) => obj.DelValue(OnRemoveBullet);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnRemoveBullet(this IEntity obj, BaseEvent<IEntity> value) => obj.SetValue(OnRemoveBullet, value);
    }
}
