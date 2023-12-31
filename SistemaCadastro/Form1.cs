using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;
        public Form1()
        {
            InitializeComponent();
            pessoas = new List<Pessoa>();

   // ========> Adicionar itens no ComboBox <============
            txtEstado.Items.Add("Casado");
            txtEstado.Items.Add("Solteiro");
            txtEstado.Items.Add("Viuvo");
            txtEstado.Items.Add("Separado");
    // ========> deixar pré selecionado na ComboBox <=========
            txtEstado.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach(Pessoa pessoa in pessoas)
            {
                if(pessoa.Nome == txtNome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

    // =======> Para o campo não ficar vazio <=========
             if(txtNome.Text == "")
            {
                MessageBox.Show("Preencha o seu NOME"); 
                txtNome.Focus();
                return;
            }

    // =======> Para o campo não ficar vazio <=========
            if (txtTelefone.Text == "(  )        - ")
            {
                MessageBox.Show("Preencha o seu TELEFONE");
                txtTelefone.Focus();
                return;
            }

            char sexo;

            if (radioM.Checked)
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = txtEstado.SelectedItem.ToString(); 
            p.Telefone = txtTelefone.Text;
            p.CasaPropria = checkCasa.Checked;
            p.Veiculo = checkVeiculo.Checked;
            p.Sexo = sexo;

            if (index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas [index] = p;
            }
            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = 0;
            indice = lista.SelectedIndex;
            pessoas.RemoveAt(indice);
            Listar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtData.Text = "";
            txtEstado.SelectedIndex = 0;
            checkCasa.Checked = false;
            checkVeiculo .Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            txtNome.Focus();

        }

        private void Listar() // ========> Método para listar as informações <=========
        {
            lista.Items.Clear();
            foreach (Pessoa p in pessoas)
            {
                lista.Items.Add(p.Nome);
            }
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtNome.Text = p.Nome;
            txtData.Text = p.DataNascimento;
            txtEstado.SelectedItem = p.EstadoCivil;
            checkCasa.Checked = p.CasaPropria;
            checkVeiculo.Checked = p.Veiculo;
            
            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default: 
                    radioO.Checked = true; 
                    break;
            }
        }
    }
}
