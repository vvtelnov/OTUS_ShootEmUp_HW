/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class AttackAPI
    {
        ///Keys
        public const int OnAttacked = 36; // BaseEvent<int>
        public const int AttackDamage = 37; // int
        public const int AttackRate = 47; // ReactiveVariable<float>
        public const int AttackRadius = 48; // ReactiveVariable<float>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<int> GetOnAttacked(this IEntity obj) => obj.GetValue<BaseEvent<int>>(OnAttacked);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetOnAttacked(this IEntity obj, out BaseEvent<int> value) => obj.TryGetValue(OnAttacked, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddOnAttacked(this IEntity obj, BaseEvent<int> value) => obj.AddValue(OnAttacked, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasOnAttacked(this IEntity obj) => obj.HasValue(OnAttacked);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelOnAttacked(this IEntity obj) => obj.DelValue(OnAttacked);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOnAttacked(this IEntity obj, BaseEvent<int> value) => obj.SetValue(OnAttacked, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetAttackDamage(this IEntity obj) => obj.GetValue<int>(AttackDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackDamage(this IEntity obj, out int value) => obj.TryGetValue(AttackDamage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackDamage(this IEntity obj, int value) => obj.AddValue(AttackDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackDamage(this IEntity obj) => obj.HasValue(AttackDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackDamage(this IEntity obj) => obj.DelValue(AttackDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackDamage(this IEntity obj, int value) => obj.SetValue(AttackDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetAttackRate(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(AttackRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackRate(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(AttackRate, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackRate(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(AttackRate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackRate(this IEntity obj) => obj.HasValue(AttackRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackRate(this IEntity obj) => obj.DelValue(AttackRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackRate(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(AttackRate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetAttackRadius(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(AttackRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackRadius(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(AttackRadius, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackRadius(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(AttackRadius, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackRadius(this IEntity obj) => obj.HasValue(AttackRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackRadius(this IEntity obj) => obj.DelValue(AttackRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackRadius(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(AttackRadius, value);
    }
}
