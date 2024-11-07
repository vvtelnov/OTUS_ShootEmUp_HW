/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Contexts;
using System.Runtime.CompilerServices;
using Atomic.Entities;

namespace Atomic.Contexts
{
	public static class GameContextAPI
	{
		///Keys
		public const int Player = 1; // SceneEntity
		public const int BulletSystem = 2; // SceneEntity
		public const int ZombieSystem = 3; // SceneEntity


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetPlayer(this IContext obj) => obj.ResolveValue<SceneEntity>(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayer(this IContext obj, out SceneEntity value) => obj.TryResolveValue(Player, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayer(this IContext obj, SceneEntity value) => obj.AddValue(Player, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayer(this IContext obj) => obj.DelValue(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayer(this IContext obj, SceneEntity value) => obj.SetValue(Player, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayer(this IContext obj) => obj.HasValue(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetBulletSystem(this IContext obj) => obj.ResolveValue<SceneEntity>(BulletSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletSystem(this IContext obj, out SceneEntity value) => obj.TryResolveValue(BulletSystem, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBulletSystem(this IContext obj, SceneEntity value) => obj.AddValue(BulletSystem, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletSystem(this IContext obj) => obj.DelValue(BulletSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletSystem(this IContext obj, SceneEntity value) => obj.SetValue(BulletSystem, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletSystem(this IContext obj) => obj.HasValue(BulletSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetZombieSystem(this IContext obj) => obj.ResolveValue<SceneEntity>(ZombieSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetZombieSystem(this IContext obj, out SceneEntity value) => obj.TryResolveValue(ZombieSystem, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddZombieSystem(this IContext obj, SceneEntity value) => obj.AddValue(ZombieSystem, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelZombieSystem(this IContext obj) => obj.DelValue(ZombieSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetZombieSystem(this IContext obj, SceneEntity value) => obj.SetValue(ZombieSystem, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasZombieSystem(this IContext obj) => obj.HasValue(ZombieSystem);
    }
}
