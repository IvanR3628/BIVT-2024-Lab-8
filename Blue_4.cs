using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;

        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            int add = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                if (Char.IsDigit(Input[i]))
                {
                    add = add * 10 + (int)(Input[i] - '0');
                } else
                {
                    _output += add;
                    add = 0;
                }
            }
            _output += add;
        }

        public override string ToString()
        {
            string result = $"{_output}";
            return result;
        }
    }
}
