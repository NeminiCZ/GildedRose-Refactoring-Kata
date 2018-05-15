﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    interface IItems
    {
        string Name { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }

        void UpdateQuality();
    }
}
