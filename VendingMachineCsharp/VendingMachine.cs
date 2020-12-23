using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCsharp
{
    public class VendingMachine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PricePerSoda { get; set; }

        public VendingMachineStateEnum VendingMachineStateEnum { get; set; }
    }
}