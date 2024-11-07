/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class HealthAPI
    {
        ///Keys
        public const int HitPoints = 11; // ReactiveVariable<int>
        public const int MaxHitPoints = 12; // ReactiveVariable<int>
        public const int IsDead = 14; // ReactiveVariable<bool>
        public const int OnDeath = 34; // BaseEvent<IEntity>
        public const int OnTakeDamage = 13; // BaseEvent<int>
        public const int OnDamageIsTaken = 43; // BaseEvent


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetHitPoints(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetHitPoints(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(HitPoints, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddHitPoints(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(HitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasHitPoints(this IEntity obj) => obj.HasValue(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelHitPoints(this IEntity obj) => obj.DelValue(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetHitPoints(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(HitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetMaxHitPoints(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(MaxHitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxHitPoints(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(MaxHitPoints, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxHitPoints(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(MaxHitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxHitPoints(this IEntity obj) => obj.HasValue(MaxHitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxHitPoints(this IEntity obj) => obj.DelValue(MaxHitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxHitPoints(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(MaxHitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<bool> GetIsDead(this IEntity obj) => obj.GetValue<ReactiveVariable<bool>>(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsDead(this IEntity obj, out ReactiveVariable<bool> value) => obj.TryGetValue(IsDead, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsDead(this IEntity obj, ReactiveVariable<bool> value) => obj.AddValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsDead(this IEntity obj) => obj.HasValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsDead(this IEntity obj) => obj.DelValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsDead(this IEntity obj, ReactiveVariable<bool> value) => obj.SetValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<IEntity> GetOnDeath(this IEntity obj) => obj.GetValue<BaseEvent<IEntity>>(OnDeath);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnDeath(this IEntity obj, out BaseEvent<IEntity> value) => obj.TryGetValue(OnDeath, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnDeath(this IEntity obj, BaseEvent<IEntity> value) => obj.AddValue(OnDeath, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnDeath(this IEntity obj) => obj.HasValue(OnDeath);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnDeath(this IEntity obj) => obj.DelValue(OnDeath);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnDeath(this IEntity obj, BaseEvent<IEntity> value) => obj.SetValue(OnDeath, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<int> GetOnTakeDamage(this IEntity obj) => obj.GetValue<BaseEvent<int>>(OnTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnTakeDamage(this IEntity obj, out BaseEvent<int> value) => obj.TryGetValue(OnTakeDamage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnTakeDamage(this IEntity obj, BaseEvent<int> value) => obj.AddValue(OnTakeDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnTakeDamage(this IEntity obj) => obj.HasValue(OnTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnTakeDamage(this IEntity obj) => obj.DelValue(OnTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnTakeDamage(this IEntity obj, BaseEvent<int> value) => obj.SetValue(OnTakeDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetOnDamageIsTaken(this IEntity obj) => obj.GetValue<BaseEvent>(OnDamageIsTaken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnDamageIsTaken(this IEntity obj, out BaseEvent value) => obj.TryGetValue(OnDamageIsTaken, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnDamageIsTaken(this IEntity obj, BaseEvent value) => obj.AddValue(OnDamageIsTaken, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnDamageIsTaken(this IEntity obj) => obj.HasValue(OnDamageIsTaken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnDamageIsTaken(this IEntity obj) => obj.DelValue(OnDamageIsTaken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnDamageIsTaken(this IEntity obj, BaseEvent value) => obj.SetValue(OnDamageIsTaken, value);
    }
}
