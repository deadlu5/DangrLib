﻿// -----------------------------------------------------------------------
//  <copyright file="SimulationEntity.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Types
{
    using Dangr.Core.Util;

    /// <summary>
    /// Base class for an entity that is part of the simulation engine.
    /// </summary>
    public abstract class SimulationEntity
    {
        private static readonly IdCounter IdCounter = new IdCounter(ulong.MinValue, ulong.MaxValue);

        /// <summary>
        /// Gets the globally unique identifier for this <see cref="SimulationEntity" /> .
        /// </summary>
        public ulong Id { get; }

        /// <summary>
        /// Gets the <see cref="SimulationEngine" /> this <see cref="SimulationEntity" /> is a part of.
        /// </summary>
        protected SimulationEngine Engine { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationEntity" /> class.
        /// </summary>
        /// <param name="engine">
        /// The <see cref="SimulationEngine" /> this <see cref="SimulationEntity" /> is a part of.
        /// </param>
        protected SimulationEntity(SimulationEngine engine)
        {
            this.Id = SimulationEntity.IdCounter.GetId();
            this.Engine = engine;
        }
    }
}