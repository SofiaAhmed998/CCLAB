using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question2
{
    public partial class Form1 : Form
    {
        private Parser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new Parser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            bool isParsed = parser.Parse(input);
            label1.Text = isParsed ? "Parsing Successful" : "Parsing Failed";
        }
    }
    public class Parser
    {
        private string[] tokens;
        private int index;

        public bool Parse(string input)
        {
            tokens = Tokenize(input);
            index = 0;

            return ParseList();
        }

        private bool ParseList()
        {
            // List -> Item Rest
            if (ParseItem())
            {
                return ParseRest();
            }
            return false;
        }

        private bool ParseRest()
        {
            // Rest -> , Item Rest | ε
            if (Match(","))
            {
                index++;
                if (ParseItem())
                {
                    return ParseRest();
                }
                return false;
            }
            return true; // Rest can also be ε
        }

        private bool ParseItem()
        {
            // Item -> id | num | string
            if (Match("id") || Match("num") || Match("string"))
            {
                index++;
                return true;
            }
            return false;
        }

        private bool Match(string expectedToken)
        {
            return index < tokens.Length && tokens[index] == expectedToken;
        }

        private string[] Tokenize(string input)
        {
            // Simple tokenization for demonstration purposes
            return input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
