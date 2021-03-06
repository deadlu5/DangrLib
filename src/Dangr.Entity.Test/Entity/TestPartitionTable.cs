﻿// -----------------------------------------------------------------------
//  <copyright file="TestPartitionTable.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Entity
{
    using Dangr.Core.Entity;
    using Dangr.Core.Util;

    public class TestPartitionTable : IdPartitionTable
    {
        public TestPartitionTable()
        {
            this.AddId(TestIds.TestEntity, (uint) IdCounter.Range.OneMillion);
        }
    }
}