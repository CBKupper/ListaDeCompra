using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeCompras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // verificar se txbproduto esta vazio
            if (txbProduto.Text.Length == 0)
            {
                MessageBox.Show("O nome do produto não estar vazio!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Mudar a cor de fundo e do texto:
                txbProduto.BackColor = Color.Red;
                txbProduto.ForeColor = Color.White;

            }
            else if (txbProduto.Text.Length < 2)
            {
                MessageBox.Show("O nome do produto precisa ter no mínimo duas letras!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbProduto.BackColor = Color.Red;
                txbProduto.ForeColor = Color.White;
            }
            else
            { 
                //Verificar se o item ja esta na lista:
                if(libCompras.Items.Contains(txbProduto.Text))
                {
                    MessageBox.Show("ja existe!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else 
                {
                    //Adicionar o item na lista:
                    libCompras.Items.Add(txbProduto.Text);

                    //Mostrar a mensagem de sucesso:
                    MessageBox.Show($"{txbProduto.Text} foi adicionado a lista de compras!", "Show!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // retornar o txbproduto a cor normal:
                    txbProduto.BackColor = Color.White;
                    txbProduto.ForeColor = Color.Black;

                    // Limpar o campo
                    txbProduto.Text = "";

                }

                    
                

            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Perguntar
            DialogResult resposta = MessageBox.Show("Tem certeza que deseja apagar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             
            // Se optar por "Sim", apagar:
            if(resposta == DialogResult.Yes)
            {
                libCompras.Items.Clear();


            }
  
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verificar se o úsuario não selecionou nada:
            if(libCompras.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um item para remover!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }else
            {
                //Salvar temporariamente o nome do item que sera removido:
                string itemRemovido = libCompras.SelectedItem.ToString();


                // Remover o item selecionado:
                libCompras.Items.RemoveAt(libCompras.SelectedIndex);

                MessageBox.Show($"{itemRemovido} foi removido da lista!", "Show!", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }



        }

        private void txbProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Precionar o btnadicionar:
                btnAdicionar.PerformClick();

            }
        }
    }
}
