using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SymbolTable symbolTable = new SymbolTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configure the DataGridView
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Key";
            dataGridView1.Columns[1].Name = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = keyTextBox.Text;
            string value = valueTextBox.Text;

            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                symbolTable.AddEntry(key, value);
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Please enter both key and value.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                string key = keyTextBox.Text;

                if (!string.IsNullOrEmpty(key))
                {
                    if (symbolTable.RemoveEntry(key))
                    {
                        RefreshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Entry not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a key to remove.");
                }
            }
    }

        private void button3_Click(object sender, EventArgs e)
        {
            string key = keyTextBox.Text;
            string result = symbolTable.SearchEntry(key);
            MessageBox.Show(result);
        }
        private void RefreshDataGridView()
        {
            dataGridView1.Rows.Clear();

            foreach (var entry in symbolTable.GetAllEntries())
            {
                dataGridView1.Rows.Add(entry.Key, entry.Value);
            }
        }

    }
    public class SymbolTable
    {
        private Dictionary<string, string> table;

        public SymbolTable()
        {
            table = new Dictionary<string, string>();
        }

        public void AddEntry(string key, string value)
        {
            int hash = key.GetHashCode();
            string hashedKey = hash.ToString();

            if (!table.ContainsKey(hashedKey))
            {
                table[hashedKey] = value;
            }
            else
            {
                table[hashedKey] = value; // Overwrite existing value
            }
        }

        public bool RemoveEntry(string key)
        {
            int hash = key.GetHashCode();
            string hashedKey = hash.ToString();

            return table.Remove(hashedKey);
        }

        public string SearchEntry(string key)
        {
            int hash = key.GetHashCode();
            string hashedKey = hash.ToString();

            if (table.ContainsKey(hashedKey))
            {
                return table[hashedKey];
            }

            return "Entry not found";
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllEntries()
        {
            foreach (var entry in table)
            {
                yield return new KeyValuePair<string, string>(entry.Key, entry.Value);
            }
        }
    }
}


