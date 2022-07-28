using Modul012DemoLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul012DemoApp
{
    public partial class Form1 : Form
    {
        private Calc calc;
        public Form1()
        {
            InitializeComponent();

            calc = new Calc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double result = calc.Addieren(12, 25);

            MessageBox.Show($"Ergebnis der Addition ist {result}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double result =  calc.Dividiere(0, 12);

                MessageBox.Show($"Ergebnis der Division ist {result}");
            }
            catch(CalcDivideByZeroException ex)
            {
                MessageBox.Show("Bitte nicht durch 0 teilen");
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CalcException ex)
            {
                MessageBox.Show("Ein Fehler bei der Calculation ist aufgetreten");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unbekannter Fehler aufgetreten");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           


            try
            {
                calc.MakeFormatException();
            }
            catch (CalcDivideByZeroException ex)
            {
                MessageBox.Show("Bitte nicht durch 0 teilen");
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CalcException ex)
            {
                MessageBox.Show("Ein Fehler bei der Calculation ist aufgetreten");

            }
            catch (Exception ex) //FormatException würde hier gematched
            {

                MessageBox.Show("Unbekannter Fehler aufgetreten");
                MessageBox.Show(ex.Message);
            }



           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                calc.MakeFormatException();
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
