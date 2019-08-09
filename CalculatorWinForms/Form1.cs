using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinForms
{
    public partial class Form1 : Form
    {
        string equation = "";
        string firstnum, secondnum = "";
        bool phase1 = true;
        string operation = "";

        public Form1()
        {
            InitializeComponent();
        }



        public void UpdateTbxResult(object sender, EventArgs args)
        {
            if (phase1)
            {
                firstnum += (sender as Button).Text;
                tbxResult.Text = firstnum;
            }
            else
            {
                secondnum += (sender as Button).Text;
                tbxResult.Text = secondnum;
            }
            equation += (sender as Button).Text;
            tbxEquation.Text = equation;

        }

        public void GetOperation(object sender, EventArgs args)
        {
            operation = (sender as Button).Text;
            phase1 = false;
            equation += $" {operation} ";
            tbxEquation.Text = equation;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            tbxResult.Text = Calculate(firstnum, secondnum, operation);
        }

        private string Calculate(string fnum, string snum, string sign)
        {
            switch (sign)
            {
                case "/":
                    {
                        phase1 = true;

                        if (Convert.ToInt16(snum) == 0)
                            return "dzielenie przez 0";

                        return (Convert.ToDouble(fnum) / Convert.ToDouble(snum)).ToString();
                    }
                case "*":
                    {
                        phase1 = true;
                        return (Convert.ToDouble(fnum) * Convert.ToDouble(snum)).ToString();
                    }
                case "+":
                    {
                        phase1 = true;
                        return (Convert.ToDouble(fnum) + Convert.ToDouble(snum)).ToString();
                    }
                case "-":
                    {
                        phase1 = true;
                        return (Convert.ToDouble(fnum) - Convert.ToDouble(snum)).ToString();
                    }
                default:
                    {
                        phase1 = true;
                        return "jebać disa kurwe";
                    }
            }


        }

        

        private void ClearTextBoxes(object sender, EventArgs e)
        {
            tbxEquation.Text = tbxResult.Text = equation = firstnum = secondnum = operation = "";
        }





    }
}
