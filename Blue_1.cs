using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;

        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = new string[0];
        }

        public override void Review()
        {
            string[] lains = Input.Split(' ');
            string lain = "";
            for (int i = 0; i < lains.Length; i++)
            {
                if ((lain == "" && lains[i].Length <= 50) || (lain != "" && lain.Length + lains[i].Length < 50))
                {
                    if (lain != "") lain += " ";
                    lain += lains[i];
                } else
                {
                    Array.Resize(ref _output, _output.Length + 1);
                    _output[_output.Length - 1] = lain;
                    lain = "";
                    i--;
                }
            }
            Array.Resize(ref _output, _output.Length + 1);
            _output[_output.Length - 1] = lain;
        }

        public override string ToString()
        {
            return String.Join('\n', _output);
        }
    }
}
