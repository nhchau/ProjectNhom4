using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHost_Form
{
    class Endpoint
    {
        public string Address { get; set; }
        public string Binding { get; set; }

        public Endpoint(string address, string binding)
        {
            this.Address = address;
            this.Binding = binding;
        }
    }
}
