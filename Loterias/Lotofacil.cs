﻿//=======================================================================================================================//
// ClassLibrary para obtenção de resultados das loterias da Caixa Economica Federal.                                     //
// Copyright 2017 - Carlos Ribeiro (https://github.com/carlosribeiro1987)                                                //
// Licenciada sob a GPL v.3  (https://www.gnu.org/licenses/gpl-3.0.txt)                                                  //
// --------------------------------------------------------------------------------------------------------------------- //
// Para obtençao dos dados no site da Caixa, foi utilizado o package DCSoup https://github.com/matarillo/dcsoup          //
// DCSoup - Copyright (c) 2009, 2010, 2011, 2012, 2013, 2014 Jonathan Hedley <jonathan@hedley.net>                       //
// Licenciado sob a MIT License (https://opensource.org/licenses/MIT)                                                    //
//=======================================================================================================================//

using System;
using Supremes;

namespace Loterias {
    public class Lotofacil {
        private string[] arrResultado;
        private string strResultado;
        private int concurso;
        private DateTime dataConcurso;
        bool obteveResultado = false;
        /// <summary>
        /// Obtém o resultado do último concurso da LotoFácil
        /// </summary>
        public Lotofacil() {
            UltimoSorteio();
        }

        /// <summary>
        /// Obtém os dados do sorteio no site da Caixa
        /// </summary>
        private void UltimoSorteio() {
            try {
                Resultados resultado = new Resultados();
                string txtSorteio = resultado.LotoFacil;
                strResultado = txtSorteio.Substring(10, 44);
                arrResultado = strResultado.Split(' ');
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
        /// Retorna o sorteio em um array de string
        /// </summary>
        public string[] ResultadoArray {
            get {
                if (obteveResultado) {
                    return arrResultado;
                }
                else {
                    return null;
                }
            }
        }
        /// <summary>
        /// Retorna o sorteio em uma string
        /// </summary>
        public string ResultadoString {
            get {
                if (obteveResultado) {
                    return strResultado;
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
            get {
                if (obteveResultado) {
                    return dataConcurso.Date;
                }
                else {
                    return Convert.ToDateTime("00/00/0000").Date;
                }
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
