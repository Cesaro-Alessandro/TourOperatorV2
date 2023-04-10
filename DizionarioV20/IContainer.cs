using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizionarioV20
{
    public interface IContainer
    {
        bool isEmpty();
        void makeEmpty();
        int size();
    }
}
