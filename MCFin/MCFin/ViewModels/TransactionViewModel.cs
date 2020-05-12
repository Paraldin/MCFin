using MCFin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCFin.ViewModels
{
    public class TransactionViewModel : BaseViewModel
    {
        public Transaction BaseTransaction { get; set; }
        private string _color;
        public string Color
        {
            get { return _color; }
            set
            {
                SetProperty(ref _color, value);
            }
        }
    }
}
