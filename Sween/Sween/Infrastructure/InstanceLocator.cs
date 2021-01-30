using Sween.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure
{
    class InstanceLocator
    {
        #region Properties
        public MainViewModels Main { get; set; }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModels();
        }
        #endregion
    }
}
