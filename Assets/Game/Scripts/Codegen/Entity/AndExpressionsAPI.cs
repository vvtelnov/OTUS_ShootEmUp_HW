/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class AndExpressionsAPI
    {
        ///Keys
        public const int CanMove = 38; // AndExpression
        public const int CanAttack = 9; // AndExpression
        public const int CanShoot = 35; // AndExpression
        public const int CanSpawn = 29; // AndExpression
        public const int CanRotate = 41; // AndExpression
        public const int CanTakeDamage = 42; // AndExpression
        public const int CanAddAmmoToMagazine = 51; // AndExpression


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanMove(this IEntity obj) => obj.GetValue<AndExpression>(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanMove(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanMove, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanMove(this IEntity obj, AndExpression value) => obj.AddValue(CanMove, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanMove(this IEntity obj) => obj.HasValue(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanMove(this IEntity obj) => obj.DelValue(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanMove(this IEntity obj, AndExpression value) => obj.SetValue(CanMove, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanAttack(this IEntity obj) => obj.GetValue<AndExpression>(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanAttack(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanAttack, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanAttack(this IEntity obj, AndExpression value) => obj.AddValue(CanAttack, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanAttack(this IEntity obj) => obj.HasValue(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanAttack(this IEntity obj) => obj.DelValue(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanAttack(this IEntity obj, AndExpression value) => obj.SetValue(CanAttack, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanShoot(this IEntity obj) => obj.GetValue<AndExpression>(CanShoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanShoot(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanShoot, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanShoot(this IEntity obj, AndExpression value) => obj.AddValue(CanShoot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanShoot(this IEntity obj) => obj.HasValue(CanShoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanShoot(this IEntity obj) => obj.DelValue(CanShoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanShoot(this IEntity obj, AndExpression value) => obj.SetValue(CanShoot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanSpawn(this IEntity obj) => obj.GetValue<AndExpression>(CanSpawn);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanSpawn(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanSpawn, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanSpawn(this IEntity obj, AndExpression value) => obj.AddValue(CanSpawn, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanSpawn(this IEntity obj) => obj.HasValue(CanSpawn);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanSpawn(this IEntity obj) => obj.DelValue(CanSpawn);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanSpawn(this IEntity obj, AndExpression value) => obj.SetValue(CanSpawn, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanRotate(this IEntity obj) => obj.GetValue<AndExpression>(CanRotate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanRotate(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanRotate, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanRotate(this IEntity obj, AndExpression value) => obj.AddValue(CanRotate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanRotate(this IEntity obj) => obj.HasValue(CanRotate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanRotate(this IEntity obj) => obj.DelValue(CanRotate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanRotate(this IEntity obj, AndExpression value) => obj.SetValue(CanRotate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanTakeDamage(this IEntity obj) => obj.GetValue<AndExpression>(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanTakeDamage(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanTakeDamage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanTakeDamage(this IEntity obj, AndExpression value) => obj.AddValue(CanTakeDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanTakeDamage(this IEntity obj) => obj.HasValue(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanTakeDamage(this IEntity obj) => obj.DelValue(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanTakeDamage(this IEntity obj, AndExpression value) => obj.SetValue(CanTakeDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanAddAmmoToMagazine(this IEntity obj) => obj.GetValue<AndExpression>(CanAddAmmoToMagazine);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanAddAmmoToMagazine(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanAddAmmoToMagazine, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanAddAmmoToMagazine(this IEntity obj, AndExpression value) => obj.AddValue(CanAddAmmoToMagazine, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanAddAmmoToMagazine(this IEntity obj) => obj.HasValue(CanAddAmmoToMagazine);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanAddAmmoToMagazine(this IEntity obj) => obj.DelValue(CanAddAmmoToMagazine);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanAddAmmoToMagazine(this IEntity obj, AndExpression value) => obj.SetValue(CanAddAmmoToMagazine, value);
    }
}
