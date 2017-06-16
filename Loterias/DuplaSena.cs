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
        private string[] arrResultado = null;
        private string[] primSorteio = null;
        private string[] segSorteio = null;
        private string strPrimResultado = string.Empty;
        private string strSegResultado = string.Empty;
        private string strResultados = string.Empty;
        private int concurso = 0;
        private DateTime dataConcurso;
        private bool obteveResultado = false;

        public DuplaSena() {
            UltimoSorteio();
        }

        private void UltimoSorteio() {
            try {
                var pagina = Dcsoup.Parse(new Uri("http://loterias.caixa.gov.br/wps/portal/loterias/landing/duplasena/"), 8000);
                var divResultado = pagina.Select("div.resultado-loteria");
                var ulSorteio = divResultado.Select("ul.dupla-sena");
                strResultados = ulSorteio.Text;
                arrResultado = strResultados.Split(' ');
                for (int i = 0; i < 6; i++) {
                    primSorteio[i] = arrResultado[i + 2];
                    strPrimResultado += primSorteio[i];
                    segSorteio[i] = arrResultado[i + 10];
                    strSegResultado += segSorteio[i];
                }
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
            get { return dataConcurso.Date; }
        }

    }
}
