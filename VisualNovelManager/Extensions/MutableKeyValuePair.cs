﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Extensions
{
    public class MutableKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public MutableKeyValuePair(TKey item1, TValue item2)
        {
            Key = item1;
            Value = item2;
        }
    }
}
