using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int[,] matrizPrincipal;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            matrizPrincipal = geraMatrizAleatoria();
            richTextBox1.Text = matrizParaTexto(matrizPrincipal, false);
        }

        string matrizParaTexto(int[,] matriz, bool transp)
        {
            int i, j, N, M;
            string result = "";
            if (transp)
            {
                N = (int)numericUpDown2.Value;
                M = (int)numericUpDown1.Value;
            }
            else
            {
                N = (int)numericUpDown1.Value;
                M = (int)numericUpDown2.Value;
            }
            for(i=0; i<N; i++)
            {
                for(j=0; j<M; j++)
                {
                    result += matriz[i,j] + "\t";
                }
                result += "\n";
            }
            return result;
        }

        int[,] geraMatrizAleatoria()
        {
            Random rnd = new Random();
            int[,] result = new int[(int)numericUpDown1.Value, (int)numericUpDown2.Value];
            int i, j;
            for (i=0; i<numericUpDown1.Value; i++)
            {
                for (j=0; j<numericUpDown2.Value; j++)
                {
                    result[i, j] = rnd.Next(1, 100);
                }
            }
            return result;
        }

        int[,] retornaTransposta(int[,] matriz)
        {
            int i, j;
            int[,] transp = new int[(int)numericUpDown2.Value, (int)numericUpDown1.Value];
            for (i = 0; i < numericUpDown1.Value; i++)
            {
                for (j = 0; j < numericUpDown2.Value; j++)
                {
                    if (j != i)
                    {
                        transp[j, i] = matriz[i, j];
                    }
                }
            }
            return transp;
        }

        private void Transposta_Click(object sender, EventArgs e)
        {
            string temp = matrizParaTexto(retornaTransposta(matrizPrincipal), true);
            richTextBox1.Text = temp;
        }
    }
}
