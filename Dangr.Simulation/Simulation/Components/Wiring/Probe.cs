﻿// -----------------------------------------------------------------------
//  <copyright file="Probe.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-06-14</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Wiring
{
    using System;
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;

    public class Probe : SimulationEntity
    {
        private DataValue dataValue;
        private RadixType radix = RadixType.Binary;
        private string value;

        private DataValue DataValue
        {
            set
            {
                this.dataValue = value;
                this.Value = this.radix.Convert(this.dataValue);
            }
        }

        public int DataBitWidth { get; }

        public string Value
        {
            get { return this.value; }
            private set
            {
                this.value = value;
                this.OnOutputUpdated(this.value);
            }
        }

        public RadixType Radix
        {
            get { return this.radix; }
            set
            {
                this.radix = value;
                this.Value = this.radix.Convert(this.dataValue);
            }
        }

        public ReadConnection In { get; }

        public event EventHandler<ProbeValueUpdatedEventArgs> OutputUpdated;

        public Probe(SimulationEngine engine, int dataBitWidth)
            : base(engine)
        {
            this.DataBitWidth = dataBitWidth;
            this.DataValue = DataValue.Floating(this.DataBitWidth);
            this.In = new ReadConnection(this.DataBitWidth);
            this.In.DataValueChanged += this.OnInputDataValueChanged;
        }

        private void OnInputDataValueChanged(object sender, DataValueChangedEventArgs eventArgs)
        {
            this.DataValue = this.In.DataValue;
        }

        private void OnOutputUpdated(string value)
        {
            this.OutputUpdated?.Invoke(this, new ProbeValueUpdatedEventArgs(value));
        }

        public class ProbeValueUpdatedEventArgs : EventArgs
        {
            public string Value { get; }

            public ProbeValueUpdatedEventArgs(string value)
            {
                this.Value = value;
            }
        }
    }
}