﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public interface IWildcardsForbider
    {
        bool ForbidWildcards(string word);
    }
}
