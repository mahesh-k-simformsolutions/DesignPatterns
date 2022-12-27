﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractPattern.Interface;
namespace AbstractPattern.Concrete
{
    class OnePlus : IPhone
    {
        private string model;
        private string battery;
        public OnePlus(string model, string battery)
        {
            this.model = model;
            this.battery = battery;
        }
        public string Battery()
        {
            return battery;
        }

        public string Model()
        {
            return model;
        }
        public override string ToString()
        {
            return $"Iphone:{this.model}--{this.battery}";
        }
    }
}
