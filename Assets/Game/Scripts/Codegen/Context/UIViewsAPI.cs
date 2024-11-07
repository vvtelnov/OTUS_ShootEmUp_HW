/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Contexts;
using System.Runtime.CompilerServices;
using Game.Scripts.UI.Health.Views;
using Game.Scripts.UI.Ammo.Views;
using Game.Scripts.UI.Score.Views;
using Game.Scripts.UI.Score.Presenters;
using Game.Scripts.UI.GameOver.Views;

namespace Atomic.Contexts
{
	public static class UIViewsAPI
	{
		///Keys
		public const int HitPointsView = 4; // IHealthAmountView
		public const int MaxHitPointsView = 5; // IHealthMaxAmountView
		public const int AmmoView = 6; // IAmmoAmountView
		public const int MaxAmmoView = 7; // IMaxAmmoView
		public const int ScoreView = 8; // IScoreView
		public const int RankView = 9; // IRankView
		public const int Ranks = 10; // Ranks
		public const int GameOverView = 11; // IGameOverView


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IHealthAmountView GetHitPointsView(this IContext obj) => obj.ResolveValue<IHealthAmountView>(HitPointsView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHitPointsView(this IContext obj, out IHealthAmountView value) => obj.TryResolveValue(HitPointsView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHitPointsView(this IContext obj, IHealthAmountView value) => obj.AddValue(HitPointsView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHitPointsView(this IContext obj) => obj.DelValue(HitPointsView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHitPointsView(this IContext obj, IHealthAmountView value) => obj.SetValue(HitPointsView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHitPointsView(this IContext obj) => obj.HasValue(HitPointsView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IHealthMaxAmountView GetMaxHitPointsView(this IContext obj) => obj.ResolveValue<IHealthMaxAmountView>(MaxHitPointsView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxHitPointsView(this IContext obj, out IHealthMaxAmountView value) => obj.TryResolveValue(MaxHitPointsView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMaxHitPointsView(this IContext obj, IHealthMaxAmountView value) => obj.AddValue(MaxHitPointsView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxHitPointsView(this IContext obj) => obj.DelValue(MaxHitPointsView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxHitPointsView(this IContext obj, IHealthMaxAmountView value) => obj.SetValue(MaxHitPointsView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxHitPointsView(this IContext obj) => obj.HasValue(MaxHitPointsView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAmmoAmountView GetAmmoView(this IContext obj) => obj.ResolveValue<IAmmoAmountView>(AmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmoView(this IContext obj, out IAmmoAmountView value) => obj.TryResolveValue(AmmoView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAmmoView(this IContext obj, IAmmoAmountView value) => obj.AddValue(AmmoView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmoView(this IContext obj) => obj.DelValue(AmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmoView(this IContext obj, IAmmoAmountView value) => obj.SetValue(AmmoView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmoView(this IContext obj) => obj.HasValue(AmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IMaxAmmoView GetMaxAmmoView(this IContext obj) => obj.ResolveValue<IMaxAmmoView>(MaxAmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxAmmoView(this IContext obj, out IMaxAmmoView value) => obj.TryResolveValue(MaxAmmoView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMaxAmmoView(this IContext obj, IMaxAmmoView value) => obj.AddValue(MaxAmmoView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxAmmoView(this IContext obj) => obj.DelValue(MaxAmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxAmmoView(this IContext obj, IMaxAmmoView value) => obj.SetValue(MaxAmmoView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxAmmoView(this IContext obj) => obj.HasValue(MaxAmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IScoreView GetScoreView(this IContext obj) => obj.ResolveValue<IScoreView>(ScoreView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetScoreView(this IContext obj, out IScoreView value) => obj.TryResolveValue(ScoreView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddScoreView(this IContext obj, IScoreView value) => obj.AddValue(ScoreView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelScoreView(this IContext obj) => obj.DelValue(ScoreView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetScoreView(this IContext obj, IScoreView value) => obj.SetValue(ScoreView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasScoreView(this IContext obj) => obj.HasValue(ScoreView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRankView GetRankView(this IContext obj) => obj.ResolveValue<IRankView>(RankView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRankView(this IContext obj, out IRankView value) => obj.TryResolveValue(RankView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRankView(this IContext obj, IRankView value) => obj.AddValue(RankView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRankView(this IContext obj) => obj.DelValue(RankView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRankView(this IContext obj, IRankView value) => obj.SetValue(RankView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRankView(this IContext obj) => obj.HasValue(RankView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Ranks GetRanks(this IContext obj) => obj.ResolveValue<Ranks>(Ranks);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRanks(this IContext obj, out Ranks value) => obj.TryResolveValue(Ranks, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRanks(this IContext obj, Ranks value) => obj.AddValue(Ranks, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRanks(this IContext obj) => obj.DelValue(Ranks);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRanks(this IContext obj, Ranks value) => obj.SetValue(Ranks, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRanks(this IContext obj) => obj.HasValue(Ranks);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IGameOverView GetGameOverView(this IContext obj) => obj.ResolveValue<IGameOverView>(GameOverView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameOverView(this IContext obj, out IGameOverView value) => obj.TryResolveValue(GameOverView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddGameOverView(this IContext obj, IGameOverView value) => obj.AddValue(GameOverView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameOverView(this IContext obj) => obj.DelValue(GameOverView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameOverView(this IContext obj, IGameOverView value) => obj.SetValue(GameOverView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameOverView(this IContext obj) => obj.HasValue(GameOverView);
    }
}
