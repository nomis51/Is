﻿using System.Numerics;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Is.Assertions;

[DebuggerStepThrough]
public static class Comparisons
{
	/// <summary>
	/// Asserts that the <paramref name="actual"/> floating point
	/// is approximately equal to <paramref name="expected"/>.
	/// </summary>
	/// <typeparam name="T">A type that implements <see cref="IFloatingPoint{TSelf}"/>.</typeparam>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsApproximately<T>(this T actual, T expected, T epsilon)
		where T : IFloatingPoint<T>
	{
		if(T.Abs(actual - expected) <= epsilon * T.Max(T.One, T.Abs(expected)))
			return true;

		throw new NotException(actual, "is not approximately", expected);
	}

	/// <summary>
	/// default epsilon is 1e-6.
	/// </summary>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsApproximately<T>(this T actual, T expected) where T : IFloatingPoint<T> =>
		actual.IsApproximately(expected, T.CreateChecked(1e-6));

	/// <summary>
	/// Asserts that the actual value is greater
	/// than the given <paramref name="other" /> value.
	/// </summary>
	/// <typeparam name="T">A type that implements <see cref="IComparable"/>.</typeparam>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsGreaterThan<T>(this T actual, T other)
		where T : IComparable<T>
	{
		if(actual.CompareTo(other) > 0)
			return true;

		throw new NotException(actual, "is not greater than", other);
	}

	/// <summary>
	/// Asserts that the actual value is smaller
	/// than the given <paramref name="other" /> value.
	/// </summary>
	/// <typeparam name="T">A type that implements <see cref="IComparable"/>.</typeparam>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsSmallerThan<T>(this T actual, T other)
		where T : IComparable<T>
	{
		if(actual.CompareTo(other) < 0)
			return true;

		throw new NotException(actual, "is not smaller than", other);
	}

	/// <summary>
	/// Asserts that the <paramref name="actual"/> value
	/// is between <paramref name="min"/> and <paramref name="max"/> exclusive bounds.
	/// </summary>
	/// <typeparam name="T">A type that implements <see cref="IComparable"/>.</typeparam>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsBetween<T>(this T actual, T min, T max) where T : IComparable<T> =>
		actual.IsGreaterThan(min) && actual.IsSmallerThan(max);

	/// <summary>
	/// Asserts that the actual value is not between
	/// the specified <paramref name="min"/> and <paramref name="max"/> exclusive bounds.
	/// </summary>
	/// <typeparam name="T">A type that implements <see cref="IComparable"/>.</typeparam>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsNotBetween<T>(this T actual, T min, T max)
		where T : IComparable<T>
	{
		if(actual.CompareTo(max) > 0 || actual.CompareTo(min) < 0)
			return true;

		throw new NotException(actual, $"is between {min} and {max}");
	}

	/// <summary>
	/// Asserts that the actual value is greater or equal
	/// the given <paramref name="other" /> value.
	/// </summary>
	/// <typeparam name="T">A type that implements <see cref="IComparable"/>.</typeparam>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAtLeast<T>(this T actual, T other)
		where T : IComparable<T>
	{
		if(actual.CompareTo(other) >= 0)
			return true;

		throw new NotException(actual, "is smaller than", other);
	}

	/// <summary>
	/// Asserts that the actual value is smaller or equal
	/// the given <paramref name="other" /> value.
	/// </summary>
	/// <typeparam name="T">A type that implements <see cref="IComparable"/>.</typeparam>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAtMost<T>(this T actual, T other)
		where T : IComparable<T>
	{
		if(actual.CompareTo(other) <= 0)
			return true;

		throw new NotException(actual, "is greater than", other);
	}

	/// <summary>
	/// Asserts that the <paramref name="actual"/> value
	/// is between <paramref name="min"/> and <paramref name="max"/> inclusive bounds.
	/// </summary>
	/// <typeparam name="T">A type that implements <see cref="IComparable"/>.</typeparam>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsInRange<T>(this T actual, T min, T max) where T : IComparable<T> =>
		actual.IsAtLeast(min) && actual.IsAtMost(max);

	/// <summary>
	/// Asserts that the actual numeric value is positive (greater than zero).
	/// </summary>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsPositive<T>(this T actual)
		where T : IComparable<T>
	{
		if (actual.CompareTo(default) > 0)
			return true;

		throw new NotException(actual, "is not positive");
	}

	/// <summary>
	/// Asserts that the actual numeric value is negative (less than zero).
	/// </summary>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsNegative<T>(this T actual)
		where T : IComparable<T>
	{
		if (actual.CompareTo(default) < 0)
			return true;

		throw new NotException(actual, "is not negative");
	}
}