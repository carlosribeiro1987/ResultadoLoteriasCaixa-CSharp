//=======================================================================================================================//
// ClassLibrary para obtenção de resultados das loterias da Caixa Economica Federal.                                     //
// Copyright 2017 - Carlos Ribeiro (https://github.com/carlosribeiro1987)                                                //
// Licenciada sob a GPL v.3  (https://www.gnu.org/licenses/gpl-3.0.txt)                                                  //
// --------------------------------------------------------------------------------------------------------------------- //
// Para obtençao dos daodos no site da Caixa, foi utilizado o package DCSoup https://github.com/matarillo/dcsoup         //
// DCSoup - Copyright (c) 2009, 2010, 2011, 2012, 2013, 2014 Jonathan Hedley <jonathan@hedley.net>                       //
// Licenciado sob a MIT License (https://opensource.org/licenses/MIT)                                                    //
//=======================================================================================================================//

using Supremes;
using System;


namespace Loterias {
    public class LoteriaFederal {
        private string strResultado = string.Empty;
        private int concurso;
        private DateTime dataConcurso;
        private bool obteveResultado = false;
        private string sorteio1 = string.Empty;
        private string sorteio2 = string.Empty;
        private string sorteio3 = string.Empty;
        private string sorteio4 = string.Empty;
        private string sorteio5 = string.Empty;
        private decimal premio1 = 0.00M;
        private decimal premio2 = 0.00M;
        private decimal premio3 = 0.00M;
        private decimal premio4 = 0.00M;
        private decimal premio5 = 0.00M;
        /// <summary>
        /// Obtém o resultado do último concurso da Loteria Federal
        /// </summary>
        public LoteriaFederal() {
            UltimoSorteio();
        }
        /// <summary>
        /// Obtém os dados do último sorteio no site da Caixa
        /// </summary>
        private void UltimoSorteio() {
            try {
                Resultados resultado = new Resultados();
                string txtSorteio = resultado.Federal;
                txtSorteio = txtSorteio.Replace(txtSorteio.Substring(0, txtSorteio.IndexOf("1º ")), "");

                sorteio1 = txtSorteio.Substring((txtSorteio.IndexOf("1º ")+3), 5);
                sorteio2 = txtSorteio.Substring((txtSorteio.IndexOf("2º ") + 3), 5);
                sorteio3 = txtSorteio.Substring((txtSorteio.IndexOf("3º ") + 3), 5);
                sorteio4 = txtSorteio.Substring((txtSorteio.IndexOf("4º ") + 3), 5);
                sorteio5 = txtSorteio.Substring((txtSorteio.IndexOf("5º ") + 3), 5);

                //Premios
                string tempPremio;
                //1º premio
                txtSorteio = txtSorteio.Replace(txtSorteio.Substring(0, (txtSorteio.IndexOf(sorteio1) +6)), "");
                tempPremio = txtSorteio.Substring(0, txtSorteio.IndexOf(" 2º")).Replace(".", "");
                premio1 = Convert.ToDecimal(tempPremio);
                //2º premio
                txtSorteio = txtSorteio.Replace(txtSorteio.Substring(0, (txtSorteio.IndexOf(sorteio2) + 6)), "");
                tempPremio = txtSorteio.Substring(0, txtSorteio.IndexOf(" 3º")).Replace(".", "");
                premio2 = Convert.ToDecimal(tempPremio);
                //3º premio
                txtSorteio = txtSorteio.Replace(txtSorteio.Substring(0, (txtSorteio.IndexOf(sorteio3) + 6)), "");
                tempPremio = txtSorteio.Substring(0, txtSorteio.IndexOf(" 4º")).Replace(".", "");
                premio3 = Convert.ToDecimal(tempPremio);
                //4º premio
                txtSorteio = txtSorteio.Replace(txtSorteio.Substring(0, (txtSorteio.IndexOf(sorteio4) + 6)), "");
                tempPremio = txtSorteio.Substring(0, txtSorteio.IndexOf(" 5º")).Replace(".", "");
                premio4 = Convert.ToDecimal(tempPremio);
                //5º premio
                txtSorteio = txtSorteio.Replace(txtSorteio.Substring(0, (txtSorteio.IndexOf(sorteio5) + 6)), "");
                tempPremio = txtSorteio.Substring(0, txtSorteio.IndexOf(" Concurso")).Replace(".", "");
                premio5 = Convert.ToDecimal(tempPremio);

                concurso = Convert.ToInt32(txtSorteio.Substring((txtSorteio.IndexOf("Concurso ") + 9), 5));
                txtSorteio = txtSorteio.Replace(txtSorteio.Substring(0, (txtSorteio.IndexOf(" - ") + 3)), "");
                string txtData = txtSorteio.Replace(" Confira o resultado › ", "").ToLower();
                dataConcurso = Convert.ToDateTime(txtData);

                obteveResultado = true;
                return;
            }
            catch {
                obteveResultado = false;
                return;
            }
        }
        /// <summary>
        /// Retorna primeiro o sorteio em uma string
        /// </summary>
        public string PrimeiroSorteio {
            get {
                if (obteveResultado)
                    return sorteio1;
                else
                    return string.Empty;

            }
        }
        /// <summary>
        /// Retorna o segundo sorteio em uma string
        /// </summary>
        public string SegundoSorteio {
            get {
                if (obteveResultado)
                    return sorteio2;
                else
                    return string.Empty;

            }
        }
        /// <summary>
        /// Retorna o terceiro sorteio em uma string
        /// </summary>
        public string TerceiroSorteio {
            get {
                if (obteveResultado)
                    return sorteio3;
                else
                    return string.Empty;

            }
        }
        /// <summary>
        /// retorna o quarto sorteio em uma string
        /// </summary>
        public string QuartoSorteio {
            get {
                if (obteveResultado)
                    return sorteio4;
                else
                    return string.Empty;

            }
        }
        /// <summary>
        /// Retorna o quinto sorteio em uma string
        /// </summary>
        public string QuintoSorteio {
            get {
                if (obteveResultado)
                    return sorteio5;
                else
                    return string.Empty;

            }
        }
        
        /// <summary>
        /// Retorna o valor do primeiro prêmio em uma string no formato monetário (R$ 1.234,56)
        /// </summary>
        public string PrimeiroPremio {
            get {
                if (obteveResultado)
                    return string.Format("{0:C}", premio1);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        ///  Retorna o valor do segundo prêmio em uma string no formato monetário (R$ 1.234,56)
        /// </summary>
        public string SegundoPremio {
            get {
                if (obteveResultado)
                    return string.Format("{0:C}", premio2);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        ///  Retorna o valor do terceiro prêmio em uma string no formato monetário (R$ 1.234,56)
        /// </summary>
        public string TerceiroPremio {
            get {
                if (obteveResultado)
                    return string.Format("{0:C}", premio3);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        ///  Retorna o valor do quarto prêmio em uma string no formato monetário (R$ 1.234,56)
        /// </summary>
        public string QuartoPremio {
            get {
                if (obteveResultado)
                    return string.Format("{0:C}", premio4);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        ///  Retorna o valor do quinto prêmio em uma string no formato monetário (R$ 1.234,56)
        /// </summary>
        public string QuintoPremio {
            get {
                if (obteveResultado)
                    return string.Format("{0:C}", premio5);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// Retorna a data do sorteio
        /// </summary>
        public DateTime DataSorteio {
            get {
                if (obteveResultado)
                    return dataConcurso.Date;
                else
                    return Convert.ToDateTime("00/00/0000").Date;
            }
        }

        /// <summary>
        /// Retorna o numero do concurso
        /// </summary>
        public int Concurso {
            get {
                if (obteveResultado)
                    return concurso;
                else
                    return 0;
            }
        }
        /// <summary>
        /// Retorna true caso a conexão ao site da Caixa tenha sido bem sucedida.
        /// Retorna false em caso contrário.
        /// </summary>
        public bool ObteveResultado {
            get { return obteveResultado; }
        }
    }
}
