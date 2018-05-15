using System.Collections.Generic;

namespace control2
{
    interface ICmd
    {
        void setParameter(params string[] param);
        void execute();
    }
}