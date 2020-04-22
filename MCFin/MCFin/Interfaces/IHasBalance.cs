using System;
using System.Collections.Generic;
using System.Text;

namespace MCFin.Interfaces
{
    public interface IHasBalance
    {
        void UpdateBalance(decimal amount);
    }
}
