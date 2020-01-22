﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop
{
    class Shoe
    {
        public byte Number { get; set; }
        public string Color { get; set; }
        public uint Price { get; set; }

        public Shoe(byte number, string color, uint price)
        {
            Number = number;
            Color = color;
            Price = price;
        }

        public override string ToString()
        {
            return this.Number + ", " + this.Color + ", " + this.Price;
        }
    }
}
