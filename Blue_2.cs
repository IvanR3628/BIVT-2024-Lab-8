using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _tool;

        public string Output => _output;

        public string Tool => _tool;

        public Blue_2(string input, string tool) : base(input)
        {
            _output = "";
            _tool = tool;
        }

        public override void Review()
        {
            string[] lains = Input.Split(' ');
            for (int i = 0; i < lains.Length; i++)
            {
                if (lains[i].Contains(_tool))
                {
                    for (int j = 0; j < lains[i].Length; j++)
                    {

                        if (Char.IsPunctuation(lains[i][j]))
                        {
                            if (j == 0) _output += " ";
                            _output += lains[i][j];
                        }
                    }
                    continue;
                }
                if (_output != "") _output += " ";
                _output += lains[i];
            }
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
