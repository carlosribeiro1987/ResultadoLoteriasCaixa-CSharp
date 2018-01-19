# ResultadoLoteriasCaixa-CSharp
### ClassLibrary desenvolvida em C# para a obtenção dos resultados das Loterias da Caixa.



Atualmente (16 de março de 2017) este repositório contém classes para a obtenção do último resultado das seguintes loterias: Dupla Sena, Loteria Federal, Lotofácil, Lotomania, Mega Sena e Quina.
As classes para obtenção dos outros resultados das demais serão adicionadas em breve.
Métodos para busca de resultados pelo número do concurso serão adicionados posteriormente.

> ###### Alterações feitas no dia 19 de janeiro de 2018
> Devido a mudanças no site da Caixa, foram feitas modificações para garantir o funcionamento das classes contidas nesta biblioteca.

### Características
* A conexão ao site da Caixa é efetuada quando as classes são instanciadas.
* A propriedade booleana **ObteveResultado** pode ser utilizada para verificar se a conexão ao site da Caixa foi bem sucedida ou para controle de erros (usando *try...catch*, *if...else*, etc.).
* Os resultados podem ser retornados em propriedades do tipo **string[]** (Ex.: ["01", "02", "03", "04", ...]) usando a propriedade **ResultadoArray** ou **string** (Ex.: "01 02 03 04 ...") usando a propriedade **ResultadoString**.
* A data do sorteio é retornada no fomato **DateTime**.
* O número do concurso é retornado no formato **int**.

### Futuras Atualizações

Futuramente serão adicionados os resultados das outras loterias e métodos para busca por número do concurso. 

Caso eu sinta a necessidade de algum método adicional, será adicionado posteriormente.

Alterações serão feitas caso haja alguma alteração no site da Caixa e as classes parem de funcionar.

Se você sentiu necessidade de algo, [envie-me um e-mail](mailto:carlos.ribeiro.537h@gmail.com).

### LICENÇA

Os arquivos contidos neste repositório (com exceção do DCSoup) estão disponibilizados sob a licença [**GPL v3**](https://www.gnu.org/licenses/gpl-3.0.en.html).

O pacote [**DCSoup**](https://github.com/matarillo/dcsoup) utilizado para a obtenção dos dados no site da Caixa foi criado por [Jonathan Hedley](mailto:jonathan@hedley.net) e foi disponibilizado sob a [**MIT License**](https://opensource.org/licenses/MIT).

Para dúvidas ou sugestões [envie-me um e-mail](mailto:carlos.ribeiro.537h@gmail.com).

