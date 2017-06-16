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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supremes;

namespace Loterias {
    public class MegaSena {
        private string[] arrResultado;
        private string strResultado;
        private int concurso;
        private DateTime dataConcurso;
        private bool obteveResultado = false;

        public MegaSena() {
            UltimoSorteio();
        }

        private void UltimoSorteio() {
            try {
                var pagina = Dcsoup.Parse(new Uri("http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/"), 8000);
                var divResultado = pagina.Select("div.resultado-loteria");
                var ulSorteio = divResultado.Select("ul.mega-sena");
                strResultado = ulSorteio.Text;
                arrResultado = strResultado.Split(' ');
                var divConcurso = pagina.Select("div#resultados").Select("div.title-bar").Select("h2");
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
            get { return obteveResultado; }
        }


    }
}

