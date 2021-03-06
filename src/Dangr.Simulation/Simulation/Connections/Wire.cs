﻿// -----------------------------------------------------------------------
//  <copyright file="Wire.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Connections
{
    using System;
    using System.Collections.Generic;
    using Dangr.Simulation.Components;
    using Dangr.Simulation.Types;

    public class Wire : SimulationComponent
    {
        public int BitWidth { get; }

        public PullBehavior PullDirection { get; set; } = PullBehavior.Unchanged;

        public event EventHandler<DataValueChangedEventArgs> DataValueChanged;

        private readonly IDictionary<WriteConnection, DataValue> inputConnections;

        private DataValue value;

        public Wire(SimulationEngine engine, int bitWidth)
            : base(engine)
        {
            this.BitWidth = bitWidth;
            this.inputConnections = new Dictionary<WriteConnection, DataValue>();
        }

        public void UpdateInput(WriteConnection input, DataValue value)
        {
            this.inputConnections[input] = value;
            this.OnInputUpdated(this, EventArgs.Empty);
        }

        public override void Update()
        {
            this.value = DataValue.Merge(this.inputConnections.Values, this.PullDirection);
            this.OnDataValueChanged(this.value);

            base.Update();
        }

        private void OnDataValueChanged(DataValue dataValue)
        {
            this.DataValueChanged?.Invoke(this, new DataValueChangedEventArgs(dataValue));
        }

        public static void Connect(SimulationEngine engine, params IConnection[] connections)
        {
            if (connections.Length == 0)
            {
                return;
            }

            int bitWidth = connections[0].DataBitWidth;
            var wire = new Wire(engine, bitWidth);

            Wire.Connect(wire, connections);
        }

        public static void Connect(Wire wire, params IConnection[] connections)
        {
            foreach (IConnection connection in connections)
            {
                connection.ConnectTo(wire);
            }
        }
    }
}