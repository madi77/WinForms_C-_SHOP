using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Projekt_1
{
    class FileHandler
    {
        public static DataGridView DataGridFromFile(string path)
        {
            DataGridView dataGridView = VisualItems.CreateDataGridView();

            //string[] words = WordsFrom(path);
            //dataGridView.Rows.Add(words);
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                dataGridView.Rows.Add(words);
            }
            return dataGridView;
        }

        public static List<string> CouponsFromFile(string path)
        {
            List<string> coupons = new List<string>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                foreach (var word in words)
                {
                    coupons.Add(word);
                }
            }
            return coupons;
        }

        public static string[] WordsFrom(string path)
        {
            string lines = File.ReadAllText(path);
            string[] words = lines.Split(',');
            return words;
        }

    }


}
