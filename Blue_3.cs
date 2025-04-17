using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char letter, double ratio)[] _output;
        private int[] _counter;

        public (char letter, double ratio)[] Output => _output;

        public Blue_3(string input) : base(input)
        {
            _output = new (char letter, double ratio)[0];
            _counter = new int[0];
        }

        public override void Review()
        {
            double sum = 0;
            string[] lains = Input.Split(' ');
            bool skip;
            for (int i = 0; i < lains.Length; i++)
            {
                skip = false;
                for (int k = 0; k < lains[i].Length; k++) {
                    if (Char.IsDigit(lains[i][0])) break;
                    if (Char.IsLetter(lains[i][k]))
                    {
                        sum++;
                        for (int j = 0; j < _counter.Length; j++)
                        {
                            if (_output[j].letter == Char.ToLower(lains[i][k]))
                            {
                                _counter[j]++;
                                skip = true;
                                break;
                            }
                        }
                        if (skip) break;
                        Array.Resize(ref _output, _output.Length + 1);
                        Array.Resize(ref _counter, _counter.Length + 1);
                        _output[_output.Length - 1] = (Char.ToLower(lains[i][k]), 0);
                        _counter[_counter.Length - 1] = 1;
                        break;
                    }
                }
            }
            for (int i = 0; i < _output.Length; i++)
            {
                _output[i].ratio = (_counter[i] / sum) * 100;
            }
            Sort();
        }

        private void Sort()
        {
            for (int i = 0; i < _output.Length; i++)
            {
                for (int j = 0; j < _output.Length - i - 1; j++)
                {
                    if ((_output[j].ratio < _output[j + 1].ratio) 
                        || ((_output[j].ratio == _output[j + 1].ratio) && (_output[j].letter > _output[j + 1].letter)))
                    {
                        (_output[j], _output[j + 1]) = (_output[j + 1], _output[j]);
                        (_counter[j], _counter[j + 1]) = (_counter[j + 1], _counter[j]);
                    }
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                if (i != 0) result += "\n";
                result += $"{_output[i].letter} - {_output[i].ratio:f4}";
            }
            return result;
        }
    }
}
