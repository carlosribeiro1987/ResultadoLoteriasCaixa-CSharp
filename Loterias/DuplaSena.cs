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
    public class DuplaSena {
        private string[] primSorteio = new string[6];
        private string[] segSorteio = new string[6];
        private string strPrimResultado = string.Empty;
        private string strSegResultado = string.Empty;
        private string strResultados = string.Empty;
        private int concurso = 0;
        private DateTime dataConcurso;
        private bool obteveResultado = false;

        /// <summary>
        /// Obtém o resultado do último concurso da DuplaSena
        /// </summary>
        public DuplaSena() {
            UltimoSorteio();
        }
        /// <summary>
        /// Obtém os dados do sorteio no site da Caixa
        /// </summary>
        private void UltimoSorteio() {
            try {
                Resultados resultado = new Resultados();
                string txtSorteio = resultado.DuplaSena;
                strPrimResultado = txtSorteio.Substring((txtSorteio.IndexOf("1º sorteio ") + 11), 17);
                strSegResultado = txtSorteio.Substring((txtSorteio.IndexOf("2º sorteio ") + 11), 17);
                primSorteio = strPrimResultado.Split(' ');
                segSorteio = strSegResultado.Split(' ');
               // strResultado = txtSorteio.Substring(10, 59);
               // arrResultado = strResultado.Split(' ');
                concurso = Convert.ToInt32(txtSorteio.Substring((txtSorteio.IndexOf("Concurso ") + 9), 4));
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
        /// Retorna o primeiro sorteio em um array de string
        /// </summary>
        public string[] PrimeiroSorteioArray{
            get {
                if (obteveResultado) {
                    return primSorteio;
                }
                else {
                    return null;
                }
            }
        }
        /// <summary>
        /// Retorna o segundo sorteio em um array de string
        /// </summary>
        public string[] SegundoSorteioArray {
            get {
                if (obteveResultado) {
                    return segSorteio;
                }
                else {
                    return null;
                }
            }
        }
        /// <summary>
        /// Retorna o primeiro sorteio em uma string
        /// </summary>
        public string PrimeiroResultadoString {
            get {
                if (obteveResultado) {
                    return strPrimResultado;
                }
                else {
                    return "";
                }
            }
        }
        /// <summary>
        /// Retorna o segundo sorteio em uma string
        /// </summary>
        public string SegundoResultadoString {
            get {
                if (obteveResultado) {
                    return strSegResultado;
                }
                else {
                    return "";
                }
            }
        }
        /// <summary>
        /// Retorna o número do concurso
        /// </summary>
        public int Concurso {
            get {
                if (obteveResultado) {
                    return concurso;
                }
                else {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Retorna a data do sorteio
        /// </summary>
        public DateTime DataSorteio {
            get { return dataConcurso.Date; }
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
