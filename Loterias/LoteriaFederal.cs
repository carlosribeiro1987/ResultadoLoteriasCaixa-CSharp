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
        private string[] arrResultado = null;
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
                var pagina = Dcsoup.Parse(new Uri("http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/"), 10000);
                var divResultado = pagina.Select("div.resultado-loteria");
                var tableSorteio = divResultado.Select("table.resultado-table").Select("tboby");
                strResultado = tableSorteio.Text;
                arrResultado = strResultado.Split(' ');
                sorteio1 = arrResultado[1];
                sorteio2 = arrResultado[4];
                sorteio3 = arrResultado[7];
                sorteio4 = arrResultado[10];
                sorteio5 = arrResultado[13];
                premio1 = Convert.ToDecimal(arrResultado[2]);
                premio2 = Convert.ToDecimal(arrResultado[5]);
                premio3 = Convert.ToDecimal(arrResultado[8]);
                premio4 = Convert.ToDecimal(arrResultado[11]);
                premio5 = Convert.ToDecimal(arrResultado[14]);
                var divConcurso = pagina.Select("div#resultados").Select("div.title-bar").Select("h2");
                var spanConcurso = divConcurso.Select("span");
                concurso = Convert.ToInt32(spanConcurso.Text.Substring(9, 5));
                dataConcurso = Convert.ToDateTime(spanConcurso.Text.Substring(16, 10));
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
                    return string.Format("{0:C", premio1);
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
                    return string.Format("{0:C", premio2);
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
                    return string.Format("{0:C", premio3);
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
                    return string.Format("{0:C", premio4);
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
                    return string.Format("{0:C", premio5);
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
