/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class MovementAPI
    {
        ///Keys
        public const int MoveSpeed = 1; // float
        public const int MoveDirection = 2; // ReactiveVariable<Vector3>
        public const int RotationSpeed = 3; // float
        public const int RotateDirection = 4; // Vector3
        public const int Acceleration = 15; // float
        public const int Deceleration = 16; // float
        public const int HasInertness = 17; // bool
        public const int FollowRadius = 19; // float


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetMoveSpeed(this IEntity obj) => obj.GetValue<float>(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveSpeed(this IEntity obj, out float value) => obj.TryGetValue(MoveSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveSpeed(this IEntity obj, float value) => obj.AddValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveSpeed(this IEntity obj, float value) => obj.SetValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<Vector3> GetMoveDirection(this IEntity obj) => obj.GetValue<ReactiveVariable<Vector3>>(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveDirection(this IEntity obj, out ReactiveVariable<Vector3> value) => obj.TryGetValue(MoveDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveDirection(this IEntity obj, ReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveDirection(this IEntity obj, ReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetRotationSpeed(this IEntity obj) => obj.GetValue<float>(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRotationSpeed(this IEntity obj, out float value) => obj.TryGetValue(RotationSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRotationSpeed(this IEntity obj, float value) => obj.AddValue(RotationSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRotationSpeed(this IEntity obj) => obj.HasValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRotationSpeed(this IEntity obj) => obj.DelValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRotationSpeed(this IEntity obj, float value) => obj.SetValue(RotationSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 GetRotateDirection(this IEntity obj) => obj.GetValue<Vector3>(RotateDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRotateDirection(this IEntity obj, out Vector3 value) => obj.TryGetValue(RotateDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRotateDirection(this IEntity obj, Vector3 value) => obj.AddValue(RotateDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRotateDirection(this IEntity obj) => obj.HasValue(RotateDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRotateDirection(this IEntity obj) => obj.DelValue(RotateDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRotateDirection(this IEntity obj, Vector3 value) => obj.SetValue(RotateDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetAcceleration(this IEntity obj) => obj.GetValue<float>(Acceleration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAcceleration(this IEntity obj, out float value) => obj.TryGetValue(Acceleration, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAcceleration(this IEntity obj, float value) => obj.AddValue(Acceleration, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAcceleration(this IEntity obj) => obj.HasValue(Acceleration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAcceleration(this IEntity obj) => obj.DelValue(Acceleration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAcceleration(this IEntity obj, float value) => obj.SetValue(Acceleration, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetDeceleration(this IEntity obj) => obj.GetValue<float>(Deceleration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDeceleration(this IEntity obj, out float value) => obj.TryGetValue(Deceleration, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDeceleration(this IEntity obj, float value) => obj.AddValue(Deceleration, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDeceleration(this IEntity obj) => obj.HasValue(Deceleration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDeceleration(this IEntity obj) => obj.DelValue(Deceleration);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDeceleration(this IEntity obj, float value) => obj.SetValue(Deceleration, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetHasInertness(this IEntity obj) => obj.GetValue<bool>(HasInertness);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetHasInertness(this IEntity obj, out bool value) => obj.TryGetValue(HasInertness, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddHasInertness(this IEntity obj, bool value) => obj.AddValue(HasInertness, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasHasInertness(this IEntity obj) => obj.HasValue(HasInertness);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelHasInertness(this IEntity obj) => obj.DelValue(HasInertness);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetHasInertness(this IEntity obj, bool value) => obj.SetValue(HasInertness, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetFollowRadius(this IEntity obj) => obj.GetValue<float>(FollowRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetFollowRadius(this IEntity obj, out float value) => obj.TryGetValue(FollowRadius, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddFollowRadius(this IEntity obj, float value) => obj.AddValue(FollowRadius, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFollowRadius(this IEntity obj) => obj.HasValue(FollowRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelFollowRadius(this IEntity obj) => obj.DelValue(FollowRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFollowRadius(this IEntity obj, float value) => obj.SetValue(FollowRadius, value);
    }
}
