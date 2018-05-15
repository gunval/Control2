using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control2
{
    class Table
    {
        private List<string> headers = new List<string>();
        private List<int> numbers = new List<int>();
        private List<string> data = new List<string>();

        private const string RIGHTCOL = "| ";
        private const string LEFTCOL = " |";
        private const char UNDERLINE = '-';

        public void header(params string[] headerName)
        {
            foreach (string a in headerName)
            {
                headers.Add(a);
                numbers.Add(a.Length);
            }
        }

        public void Add(string value)
        {
            data.Add(value);

            int count = value.ToCharArray().Length;

            int index = (data.Count - 1) % headers.Count;
            if (numbers[index] < count)
                numbers[index] = count;
        }

        public void export()
        {
            string headerLine = RIGHTCOL;
            string datas = "";
            int counter = 0;

            //データの整形
            for (int i = 0; i < data.Count / headers.Count; ++i)
            {
                datas += RIGHTCOL;
                for (int j = 0; j < headers.Count; ++j)
                {
                    string f = "{0,-" + numbers[j] + "}" + LEFTCOL;
                    datas += string.Format(f, data[counter++]);
                }
                datas += "\n";
            }

            //headerLineの整形
            for (int h = 0; h < headers.Count; ++h)
            {
                string f = "{0,-" + numbers[h] + "}" + LEFTCOL;
                headerLine += string.Format(f, headers[h]);
            }

            //header
            Console.WriteLine(headerLine);
            Console.WriteLine(new string(UNDERLINE, headerLine.Length));
            Console.Write(datas);
        }
    }
}