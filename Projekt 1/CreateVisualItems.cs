using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Projekt_1
{
    class VisualItems
    {

        //Genral font for the project.
        private static string ChoosenFont = "Microsoft Sans Serif";
        //Almost General size of font
        private static int FontSize = 15;

        public static TableLayoutPanel CreateTableLayoutPanel(int columnCount, int rowCount, Color color)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                ColumnCount = columnCount,
                RowCount = rowCount,
                Dock = DockStyle.Fill,
                BackColor = color
            };
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            return tableLayoutPanel;
        }

        public static DataGridView CreateDataGridView()
        {
            DataGridView dataGridView = new DataGridView
            {
                ColumnCount = 3,
                BackgroundColor = SystemColors.ControlLightLight,
                Dock = DockStyle.Fill,
                ColumnHeadersHeight = 45,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
            };
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[0].Name = "Product Name";
            dataGridView.Columns[0].Width = 75;
            dataGridView.Columns[1].Name = "Unite Price";
            dataGridView.Columns[1].Width = 75;
            dataGridView.Columns[2].Name = "Qty ";
            dataGridView.Columns[2].Width = 50;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(ChoosenFont, 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowsDefaultCellStyle.Font = new Font(ChoosenFont, 10);

            return dataGridView;
        }

        public static Button CreateButton(string buttonText)
        {
            Button button = new Button
            {
                Dock = DockStyle.Fill,
                Font = new Font(ChoosenFont, FontSize),
                Text = buttonText,
                UseVisualStyleBackColor = true,
            };
            return button;
        }

        public static Label CreateLabel(string lableText, int fontSize, AnchorStyles anchor)
        {
            Label label = new Label
            {
                Anchor = anchor,
                AutoSize = true,
                Font = new Font(ChoosenFont, fontSize),
                Text = lableText,
                TextAlign = ContentAlignment.MiddleCenter
            };
            return label;
        }

        public static TextBox CreatTextBox()
        {
            TextBox textBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font(ChoosenFont, FontSize),
            };
            return textBox;
        }
    }
}
