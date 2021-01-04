using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineCsharp.Repositories;

namespace VendingMachineCsharp
{
    static class Program
    {
        public static VendingMachine myVendingMachine;

        public static Inventory myInventory;

        public static InventoryService myInventoryService;

        public static VendingMachineStateEnum programState;

        public static void ManageState(VendingMachineStateEnum currentState)
        {
            Program.programState = currentState;

            Form1.ActiveForm.Controls["textBoxVMStateViewer"].Text = Program.programState.ToString();

            switch (currentState)
            {
                case VendingMachineStateEnum.NoQuarter:
                    Form1.ActiveForm.Controls["button1"].Enabled = true; //Insrt
                    Form1.ActiveForm.Controls["button2"].Enabled = false; //Eject

                    Form1.ActiveForm.Controls["button3"].Enabled = false; //Sprite
                    Form1.ActiveForm.Controls["button3"].Text = "Sprite" + Environment.NewLine + "(" + GetInventory("Sprite") + ")"; //Sprite

                    Form1.ActiveForm.Controls["button4"].Enabled = false; //Coke
                    Form1.ActiveForm.Controls["button4"].Text = "Coke" + Environment.NewLine + "(" + GetInventory("Coke") + ")"; //Coke

                    Form1.ActiveForm.Controls["button6"].Enabled = true; //Purchase Transaction
                    break;
                case VendingMachineStateEnum.Sold:
                    Form1.ActiveForm.Controls["button1"].Enabled = true; //Insrt
                    Form1.ActiveForm.Controls["button2"].Enabled = false; //Eject

                    Form1.ActiveForm.Controls["button3"].Enabled = false; //Sprite
                    Form1.ActiveForm.Controls["button3"].Text = "Sprite" + Environment.NewLine + "(" + GetInventory("Sprite") + ")"; //Sprite

                    Form1.ActiveForm.Controls["button4"].Enabled = false; //Coke
                    Form1.ActiveForm.Controls["button4"].Text = "Coke" + Environment.NewLine + "(" + GetInventory("Coke") + ")"; //Coke

                    Form1.ActiveForm.Controls["button6"].Enabled = true; //Purchase Transaction
                    break;
                case VendingMachineStateEnum.HasQuarter:
                    Form1.ActiveForm.Controls["button1"].Enabled = true; //Insrt
                    Form1.ActiveForm.Controls["button2"].Enabled = true; //Eject

                    //if CheckInventory("Sprite") then {
                    if (GetInventory("Sprite")>0)
                    { 
                        Form1.ActiveForm.Controls["button3"].Enabled = true;
                        Form1.ActiveForm.Controls["button3"].Text = "Sprite" + Environment.NewLine + "(" + GetInventory("Sprite") + ")"; //Sprite

                    }
                    else
                    {
                        Form1.ActiveForm.Controls["button3"].Enabled = false;
                        Form1.ActiveForm.Controls["button3"].Text = "Sprite" + Environment.NewLine + "(" +  "0" + ")"; //Sprite
                    }

                    //if CheckInventory("coke") then {
                    if (GetInventory("Coke")>0)
                    {
                        Form1.ActiveForm.Controls["button4"].Enabled = true;
                        Form1.ActiveForm.Controls["button4"].Text = "Coke" + Environment.NewLine + "(" + GetInventory("Coke") + ")"; //Coke

                    }
                    else
                    {
                        Form1.ActiveForm.Controls["button4"].Enabled = false;
                        Form1.ActiveForm.Controls["button4"].Text = "Coke" + Environment.NewLine + "(" + "0" + ")"; //Coke

                    }

                    Form1.ActiveForm.Controls["button6"].Enabled = true; //Purchase Transaction
                    break;
                case VendingMachineStateEnum.SoldOut:   //Sold out means both product is sold out

                    if (GetInventory("Sprite")>0)
                    {
                        Form1.ActiveForm.Controls["button3"].Enabled = true;
                        Form1.ActiveForm.Controls["button3"].Text = "Sprite" + Environment.NewLine + "(" + GetInventory("Sprite") + ")"; //Sprite
                    }
                    else
                    {
                        Form1.ActiveForm.Controls["button3"].Enabled = false;
                        Form1.ActiveForm.Controls["button3"].Text = "Sprite" + Environment.NewLine + "(" + "0" + ")"; //Sprite
                    }

                    if (GetInventory("Coke")>0)
                    {
                        Form1.ActiveForm.Controls["button4"].Enabled = true;
                        Form1.ActiveForm.Controls["button4"].Text = "Coke" + Environment.NewLine + "(" + GetInventory("Coke") + ")"; //Coke

                    }
                    else
                    {
                        Form1.ActiveForm.Controls["button4"].Enabled = false;
                        Form1.ActiveForm.Controls["button4"].Text = "Coke" + Environment.NewLine + "(" + "0" + ")"; //Coke
                    }

                    Form1.ActiveForm.Controls["button1"].Enabled = false; //Insrt
                    Form1.ActiveForm.Controls["button2"].Enabled = false; //Eject

                    Form1.ActiveForm.Controls["button3"].Enabled = false; //Sprite
                    Form1.ActiveForm.Controls["button3"].Text = "Sprite" + Environment.NewLine + "(" + GetInventory("Sprite") + ")"; //Sprite

                    Form1.ActiveForm.Controls["button4"].Enabled = false; //Coke
                    Form1.ActiveForm.Controls["button4"].Text = "Coke" + Environment.NewLine + "(" + GetInventory("Coke") + ")"; //Coke

                    Form1.ActiveForm.Controls["button6"].Enabled = true; //Purchase Transaction
                    break;
            }
            
            if ((Form1.ActiveForm.Controls["Button4"].Text == "Coke" + Environment.NewLine + "(" + 0 + ")")
                       && (Form1.ActiveForm.Controls["Button3"].Text == "Sprite" + Environment.NewLine + "(" + 0 + ")"))
            {
                Form1.ActiveForm.Controls["button1"].Enabled = false; //Insrt
                Program.programState = VendingMachineStateEnum.SoldOut;
            }
            else
            {
                Form1.ActiveForm.Controls["button1"].Enabled = true; //Insrt
            }
        }

        public static int GetInventory(string currentProduct)
        {
            List<Inventory> myInventoryList;

            myInventoryService = new InventoryService();
            myInventoryList = myInventoryService.GetAll();
           
            foreach (var inventory in myInventoryList)
            {
                if (inventory.Product.Name == currentProduct)
                {
                    return inventory.Qty;
                }
            }
        
            return 0;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            myVendingMachine = new VendingMachine();
        }
    }
}
