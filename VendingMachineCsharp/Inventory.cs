using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCsharp
{
    public class Inventory
    {
        public int Id { get; set; }

        public int Qty { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int VendingMachineId { get; set; }
    }
}
