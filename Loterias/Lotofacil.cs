//=======================================================================================================================//
// ClassLibrary para obtenção de resultados das loterias da Caixa Economica Federal.                                     //
// Copyright 2017 - Carlos Ribeiro (https://github.com/carlosribeiro1987)                                                //
// Licenciada sob a GPL v.3  (https://www.gnu.org/licenses/gpl-3.0.txt)                                                  //
// --------------------------------------------------------------------------------------------------------------------- //
// Para obtençao dos daodos no site da Caixa, foi utilizado o package DCSoup https://github.com/matarillo/dcsoup         //
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

        public Lotofacil() {
            UltimoSorteio();
        }
        
        /// <summary>
        /// Obtém o resultado do último sorteio da lotofácil à partir da Internet.<para/>
        /// Retorna um array com os números sorteados ou null se não for possível conectar.
        /// </summary>
        /// <returns>Se a conexão ao site da Caixa for bem-sucedida retorna um array de string com os números do último sorteio. <para/>
        /// Caso contrário retorna null.</returns>
        /// 
        private void UltimoSorteio() {
            try {
                var pagina = Dcsoup.Parse(new Uri("http://loterias.caixa.gov.br/wps/portal/loterias/landing/lotofacil"), 8000);
                var tableSorteio = pagina.Select("table.lotofacil");
                strResultado = tableSorteio.Text;
                arrResultado = strResultado.Split(' ');
                var divConcurso = pagina.Select("div#resultados");
                var spanConcurso = divConcurso.Select("span");
                concurso = Convert.ToInt32(spanConcurso.Text.Substring(9, 4));
                dataConcurso = Convert.ToDateTime(spanConcurso.Text.Substring(15, 10));
                obteveResultado = true;
                return;
            }
            catch {
                obteveResultado = false;
                return;
            }
        }

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

        public DateTime DataConcurso {
            get {
                if (obteveResultado) {
                    return dataConcurso.Date;
                }
                else {
                    return Convert.ToDateTime("00/00/0000").Date;
                }
            }
        }
        public bool ObteveResultado {
            get {
                return obteveResultado;
            }
        }
    }
    
}
