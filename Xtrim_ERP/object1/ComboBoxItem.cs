﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ComboBoxItem
    {
        public String Text { get; set; }
        public String Value { get; set; }

        public override String ToString()
        {
            return Text;
        }
    }
}
