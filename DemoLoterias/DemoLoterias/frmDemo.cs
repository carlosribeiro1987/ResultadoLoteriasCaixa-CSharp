using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loterias;

namespace DemoLoterias {
    public partial class frmDemoLoteria : Form {
        public frmDemoLoteria() {
            InitializeComponent();
        }

        private void cmbSelecLoteria_SelectedValueChanged(object sender, EventArgs e) {
            btnResultado.Enabled = (cmbSelecLoteria.Text != "Selecione a loteria desejada...");
            txtConcurso.Text = string.Empty;
            txtDataSorteio.Text = string.Empty;
            txtResultado.Text = string.Empty;
        }

        private void btnResultado_Click(object sender, EventArgs e) {
            switch (cmbSelecLoteria.Text) {
                case "Mega Sena":
                    MegaSena megasena = new MegaSena();
                    if (megasena.ObteveResultado) {
                        string resultado = string.Empty;
                        txtConcurso.Text = Convert.ToString(megasena.Concurso);
                        txtDataSorteio.Text = megasena.DataSorteio.ToShortDateString();
                        txtResultado.Text = megasena.ResultadoString;
                    }
                    else {
                        txtResultado.Text = "Não foi possível obter o resultado.";
                    }
                    break;
                case "Lotofácil":
                    Lotofacil lotofacil = new Lotofacil();
                    if (lotofacil.ObteveResultado) {
                        txtConcurso.Text = Convert.ToString(lotofacil.Concurso);
                        txtDataSorteio.Text = lotofacil.DataSorteio.ToShortDateString();
                        string resultado = string.Empty;
                        for (int i = 0; i < lotofacil.ResultadoArray.Length; i++) {
                            if (i == 4 || i == 9)
                                resultado += lotofacil.ResultadoArray[i]+"\r\n";
                            else
                                resultado += lotofacil.ResultadoArray[i] + " ";
                        }
                        txtResultado.Text = resultado;
                    }
                    else {
                        txtResultado.Text = "Não foi possível obter o resultado.";
                    }
                    break;
                case "Lotomania":
                    LotoMania lotomania = new LotoMania();
                    if (lotomania.ObteveResultado) {
                        txtConcurso.Text = Convert.ToString(lotomania.Concurso);
                        txtDataSorteio.Text = lotomania.DataSorteio.ToShortDateString();
                        string resultado = string.Empty;
                        for (int i = 0; i < lotomania.ResultadoArray.Length; i++) {
                            if (i == 4 || i == 9 || i == 14)
                                resultado += lotomania.ResultadoArray[i] + "\r\n";
                            else
                                resultado += lotomania.ResultadoArray[i] + " ";
                        }
                        txtResultado.Text = resultado;
                    }
                    else {
                        txtResultado.Text = "Não foi possível obter o resultado.";
                    }
                    break;
                case "Dupla Sena":
                    DuplaSena duplasena = new DuplaSena();
                    if (duplasena.ObteveResultado) {
                        txtConcurso.Text = Convert.ToString(duplasena.Concurso);
                        txtDataSorteio.Text = duplasena.DataSorteio.ToShortDateString();
                        txtResultado.Text = "1º Sorteio: " + duplasena.PrimeiroResultadoString;
                        txtResultado.Text += "\r\n\r\n2º Sorteio: " + duplasena.SegundoResultadoString;
                    }
                    else {
                        txtResultado.Text = "Não foi possível obter o resultado.";
                    }
                    break;
                case "Quina":
                    Quina quina = new Quina();
                    if (quina.ObteveResultado) {
                        txtConcurso.Text = Convert.ToString(quina.Concurso);
                        txtDataSorteio.Text = quina.DataSorteio.ToShortDateString();
                        txtResultado.Text = quina.ResultadoString;
                    }
                    else {
                        txtResultado.Text = "Não foi possível obter o resultado.";
                    }
                    break;
                case "Loteria Federal":
                    LoteriaFederal federal = new LoteriaFederal();
                    if (federal.ObteveResultado) {
                        txtConcurso.Text = Convert.ToString(federal.Concurso);
                        txtDataSorteio.Text = federal.DataSorteio.ToShortDateString();
                        txtResultado.Text = string.Format("1º sorteio: {0}\tPrêmio: {1:C}\r\n", federal.PrimeiroSorteio, federal.PrimeiroPremio);
                        txtResultado.Text += string.Format("2º sorteio: {0}\tPrêmio: {1:C}\r\n", federal.SegundoSorteio, federal.SegundoPremio);
                        txtResultado.Text += string.Format("3º sorteio: {0}\tPrêmio: {1:C}\r\n", federal.TerceiroSorteio, federal.TerceiroPremio);
                        txtResultado.Text += string.Format("4º sorteio: {0}\tPrêmio: {1:C}\r\n", federal.QuartoSorteio, federal.QuartoPremio);
                        txtResultado.Text += string.Format("5º sorteio: {0}\tPrêmio: {1:C}\r\n", federal.QuintoSorteio, federal.QuintoPremio);
                    }
                    else {
                        txtResultado.Text = "Não foi possível obter o resultado.";
                    }
                    break;
                default:
                    txtResultado.Text = "Nenhuma Loteria selecionada!";
                    break;
            }
        }

    }
}
