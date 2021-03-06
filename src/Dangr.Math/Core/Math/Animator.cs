﻿// -----------------------------------------------------------------------
//  <copyright file="Animator.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Math
{
    /// <summary>
    /// Animates a value from <see cref="Animator.StartValue" /> to 
    /// <see cref="Animator.EndValue" /> based off of time T from 0
    /// to 1.
    /// </summary>
    public abstract class Animator
    {
        private readonly float range;
        private float t;

        /// <summary>
        /// Gets the animated value when <see cref="Animator.T" /> = 0.
        /// </summary>
        public float StartValue { get; }

        /// <summary>
        /// Gets the animated value when <see cref="Animator.T" /> = 1.
        /// </summary>
        public float EndValue { get; }

        /// <summary>
        /// Gets the animated value at the current T.
        /// </summary>
        public float Value { get; private set; }

        /// <summary>
        /// Gets or sets the current <see cref="Animator.T" /> value for the animation. Clamped between 0 and 1.
        /// </summary>
        public float T
        {
            get { return this.t; }
            set
            {
                this.t = MathHelper.Clamp(value, 0.0f, 1.0f);
                this.CalculateValue();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator" /> class.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        protected Animator(float minValue, float maxValue)
        {
            this.StartValue = minValue;
            this.EndValue = maxValue;

            this.range = this.EndValue - this.StartValue;
            this.Value = this.StartValue;
        }

        /// <summary>
        /// Calculates the new value as a scale from 0 to 1.
        /// </summary>
        /// <param name="v">The input parameter as a value from 0 to 1.</param>
        /// <returns>The new value as a scale from 0 to 1.</returns>
        protected abstract float CalculateScale(float v);

        private void CalculateValue()
        {
            float scaledT = this.CalculateScale(this.T);
            this.Value = (this.range * scaledT) + this.StartValue;
        }
    }
}