using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiE10.Core.Interfaces
{
    public interface IBindableE10View
    {
        void Bind(IE10Tracker tracker);

        void Unbind();
    }
}
