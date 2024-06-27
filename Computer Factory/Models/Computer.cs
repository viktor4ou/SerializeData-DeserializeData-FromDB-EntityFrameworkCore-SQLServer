using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Factory.Models
{
    public class Computer
    {
        public Computer(string model, string processor, int memory,string graphics, decimal price)
        {
            Model = model;
            Processor = processor;
            Memory = memory;
            Graphics = graphics;
            Price = price;
        }

        public int ComputerId { get; set; }
        public string Model { get; set; }
        public string Processor { get; set; }
        public int Memory { get; set; }
        public string Graphics { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Model} , {Processor}, {Memory}, {Graphics}, {Price}";
        }
    }
}
