using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Services;

namespace Teams.ViewModels
{
    class ViewModelLocator
    {
        private readonly IMediator mediator;

        public ViewModelLocator()
        {
            mediator = new Mediator();
        }
    }
}
