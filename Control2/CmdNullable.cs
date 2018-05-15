using System.Collections.Generic;

namespace control2
{
    class CmdNullable : ICmd
    {
        public void setParameter(params string[] param)
        {
        }

        public void execute()
        {
        }

        public bool checkArgument(string[] argc)
        {
            return true;
        }
    }
}