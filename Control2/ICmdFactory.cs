namespace control2
{
    class ICmdFactory
    {
        private static readonly ICmdFactory instance = new ICmdFactory();

        static ICmdFactory()
        {
        }

        public static ICmdFactory getInstance()
        {
            return instance;
        }

        public ICmd create(string key = null)
        {
            ICmd command = null;
            switch (key)
            {
                case "-l":
                    command = new CmdListing();
                    break;
                case "-w":
                    command = new CmdSearchWord();
                    break;
                case "-m":
                    command = new CmdSendMessage();
                    break;
                case "-s":
                    command = new CmdSendMessageText();
                    break;
                case "-g":
                    command = new CmdSendMessageGetText();
                    break;
                case "-ie":
                    command = new CmdSendMessageGetIEDoument();
                    break;
                default:
                    command = new CmdNullable();
                    break;
            }
            return command;
        }
    }
}