using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Draft_
{
    class Information
    {
        public string code { get => code; set => code = value; }
        public string module { get => module; set => module = value; }
        public int credits { get => credits; set => credits = value; }
        public int hours { get => hours; set => hours = value; }

        public DateTime date { get; set; }
        public int weeks { get; set; }

        public Information(string code, string module, int credits, int hours)
        {
            this.code = code;
            this.module = module;
            this.credits = credits;
            this.hours = hours;
        }

    }
}
