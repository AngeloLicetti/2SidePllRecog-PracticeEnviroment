using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2SidePllRecog_PracticeEnviroment
{
    public partial class Form1 : Form
    {
        Proceso proceso = new Proceso();
        public Form1()
        {
            InitializeComponent();
        }

        private void cbG1_CheckedChanged(object sender, EventArgs e)
        {
            checkearGrupo(cbG1, gb1);
        }

        private void cbG2_CheckedChanged(object sender, EventArgs e)
        {
            checkearGrupo(cbG2, gb2);
        }

        private void cbG3_CheckedChanged(object sender, EventArgs e)
        {
            checkearGrupo(cbG3, gb3);
        }

        private void cbG4_CheckedChanged(object sender, EventArgs e)
        {
            checkearGrupo(cbG4, gb4);
        }

        private void cbG5_CheckedChanged(object sender, EventArgs e)
        {
            checkearGrupo(cbG5, gb5);
        }

        private void cbG6_CheckedChanged(object sender, EventArgs e)
        {
            checkearGrupo(cbG6, gb6);
        }

        private void cbG7_CheckedChanged(object sender, EventArgs e)
        {
            checkearGrupo(cbG7, gb7);
        }

        private void cbG8_CheckedChanged(object sender, EventArgs e)
        {
            checkearGrupo(cbG8, gb8);
        }

        public void checkearGrupo(CheckBox cb, GroupBox gb)
        {
            if (cb.Checked == true)
            {
                foreach (CheckBox c in gb.Controls)
                {
                    c.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox c in gb.Controls)
                {
                    c.Checked = false;
                }
            }
        }

        public void agregarGrupo (Control gb)
        {
            foreach (Control c in gb.Controls)
            {
                if(c is CheckBox)
                {
                agregarCaso(c);
                }
            }
        }

        public void agregarCaso (Control cb)
        {
            if (cb is CheckBox)
            {
                if (((CheckBox)cb).Checked)
                {
                    string numeroDeCaso = cb.Name.Substring(2);
                    proceso.agregarScramble(Convert.ToInt32(numeroDeCaso));
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            generar();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                generar();
            }
        }
        public void generar()
        {
            try
            {
                proceso = new Proceso();

                foreach (Control g in gbCases.Controls)
                {
                    if (g is GroupBox)
                    {
                        agregarGrupo(g);
                    }
                }

                proceso.ingresarNumeroDeScrambles(Convert.ToInt32(txtNumber.Text));

                txtScrambles.Text = proceso.scramblesGenerados();

            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un número de scrambles estúpido.", "Pensando ps oe");
                txtNumber.Clear();
            }
            finally
            {
                txtNumber.Focus();
            }
        }
    }
}
