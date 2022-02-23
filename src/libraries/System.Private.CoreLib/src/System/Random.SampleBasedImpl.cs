// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    public partial class Random
    {
        /// <summary>
        /// Provides a <see cref="Random"/> implementation where all public overridable members that rely on the <see cref="Random.Sample"/> method.
        /// </summary>
        private sealed class SampleBasedImpl : ImplBase
        {
            private readonly Random _parent;

            internal SampleBasedImpl(Random parent) => _parent = parent;

            public override double Sample() =>
                // not even the Sample method is overridden: using Shared.NextDouble as a fallback
                Shared._impl.NextDouble();

            public override int Next() => (int)(_parent.Sample() * int.MaxValue);

            public override int Next(int maxValue) => (int)(_parent.Sample() * maxValue);

            public override int Next(int minValue, int maxValue) => (int)(_parent.Sample() * (uint)(maxValue - minValue)) + minValue;

            public override long NextInt64() => (int)(_parent.Sample() * long.MaxValue);

            public override long NextInt64(long maxValue) => (long)(_parent.Sample() * maxValue);

            public override long NextInt64(long minValue, long maxValue) => (long)(_parent.Sample() * (ulong)(maxValue - minValue)) + minValue;

            public override float NextSingle() => (float)_parent.Sample();

            public override double NextDouble() => _parent.Sample();

            public override void NextBytes(byte[] buffer) => NextBytes(buffer.AsSpan());

            public override void NextBytes(Span<byte> buffer)
            {
                for (int i = 0; i < buffer.Length; i++)
                    buffer[i] = (byte)Next();
            }
        }
    }
}
