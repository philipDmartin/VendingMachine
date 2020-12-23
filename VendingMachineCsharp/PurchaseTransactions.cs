using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCsharp
{
    public class PurchaseTransactions
    {
        public int Id { get; set; }

        public int PurchaseTotal { get; set; }

        public int PurchaseQty { get; set; }

        public DateTime Time { get; set; }

        public int ProductId { get; set; }

        public int VendingMachineId { get; set; }
    }
}