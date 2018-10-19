using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Projekt_1
{

    class Receipt : Form
    {
        public Receipt()
        {

            Text = "Shopping Cart made by M & M 2017";
            Size = new Size(600, 550);
            StartPosition = FormStartPosition.CenterScreen;

            
            TableLayoutPanel mainTableReceipt = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 7,
                Dock = DockStyle.Fill,
                BackColor = Color.LightCyan
            };

            mainTableReceipt.Controls.Add(Projekt_1.DataGridView2, 1, 3);


            //Design.
            Controls.Add(mainTableReceipt);
            mainTableReceipt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            mainTableReceipt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
            mainTableReceipt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));

            mainTableReceipt.RowStyles.Add(new RowStyle(SizeType.Percent, 2));
            mainTableReceipt.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            mainTableReceipt.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            mainTableReceipt.RowStyles.Add(new RowStyle(SizeType.Percent, 58));
            mainTableReceipt.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            mainTableReceipt.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            mainTableReceipt.RowStyles.Add(new RowStyle(SizeType.Percent, 2));




            //Creation of Labels from method in another file.
            var receipt = VisualItems.CreateLabel("Receipt", 28, (AnchorStyles.Top));
            mainTableReceipt.Controls.Add(receipt, 1, 1);

            var confirmed = VisualItems.CreateLabel("You purchase has been confirmed.", 14, AnchorStyles.Top);
            mainTableReceipt.Controls.Add(confirmed, 1, 2);

           
            Projekt_1.LabelTotalPay.Text = "Total: " + Projekt_1.LabelTotalPay.Text;
            mainTableReceipt.Controls.Add(Projekt_1.LabelTotalPay, 1, 4);


            //Creation of buttons from method in another file.
            var buttonClose = VisualItems.CreateButton("Close");
            mainTableReceipt.Controls.Add(buttonClose, 1, 5);



            //Eventhandelers
            buttonClose.Click += ButtonClose_Click;

        }



        public void ButtonClose_Click(object sender, EventArgs e)
        {
            var formMain = new Projekt_1();
            Close();
            formMain.Show();
            Projekt_1.ClearAll();
        }


    }

}




