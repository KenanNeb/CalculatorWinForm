using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double ResultValue = 0;
        string OperationPerformed = "";
        bool IsOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (txtBx_Result.Text == "0" || IsOperationPerformed)
                txtBx_Result.Clear();

            IsOperationPerformed = false;
            if (sender is Button btn)
            {
                //btn - ni deyisende noqte qoymaq olur
                //amma belede noqte qoymaq olmur
                if(btn.Text == ".")
                {
                    if(txtBx_Result.Text.Contains("."))
                       txtBx_Result.Text = txtBx_Result.Text + btn.Text;
                }
                else
                {
                    txtBx_Result.Text = txtBx_Result.Text + btn.Text;
                }
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if(ResultValue != 0)
                {
                    btn_equal.PerformClick();
                    OperationPerformed = btn.Text;
                    lbl_currentOperation.Text = ResultValue + " " + OperationPerformed;
                    IsOperationPerformed = true;
                }
                else
                {
                    OperationPerformed = btn.Text;
                    ResultValue = double.Parse(txtBx_Result.Text);
                    lbl_currentOperation.Text = ResultValue + " " + OperationPerformed;
                    IsOperationPerformed = true;
                }               
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtBx_Result.Text = "0";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtBx_Result.Text = "0";
            ResultValue = 0;
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            switch (OperationPerformed)
            {
                case "+":
                    txtBx_Result.Text=(ResultValue + double.Parse(txtBx_Result.Text)).ToString();
                    break;
                case "-":                   
                    txtBx_Result.Text = (ResultValue - double.Parse(txtBx_Result.Text)).ToString();                   
                    break;
                case "*":
                    txtBx_Result.Text = (ResultValue * double.Parse(txtBx_Result.Text)).ToString();
                    break;
                case "/":
                 if (double.Parse(txtBx_Result.Text) > 0)
                    {
                      txtBx_Result.Text = (ResultValue / double.Parse(txtBx_Result.Text)).ToString();
                    }
                 else
                    {
                        //kodun bu hissesinde exception atir 
                        txtBx_Result.Text = "Cannot divide by zero";
                    }
                    break;
                default:
                    break;
            }
            ResultValue = double.Parse(txtBx_Result.Text);
            lbl_currentOperation.Text = "";
        }

        private void btn_PlusMinus_MouseClick(object sender, MouseEventArgs e)
        {
            txtBx_Result.Text = (-1 * double.Parse(txtBx_Result.Text)).ToString();
        }

        private void btn_square_MouseClick(object sender, MouseEventArgs e)
        {
            txtBx_Result.Text = (double.Parse(txtBx_Result.Text) * 
                double.Parse(txtBx_Result.Text)).ToString();
        }
    }
}
