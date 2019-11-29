using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;

namespace Graficos
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private DesempenhoDao desempenhoDao;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
            ShowCharts();
        }

        private void InitializeDatabase()
        {
            var documentStore = new DocumentStore
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "Database_Twitter"
            };

            documentStore.Initialize();
            desempenhoDao = new DesempenhoDao(documentStore);
        }

        private void ShowCharts()
        {
            List<string> filtro1 = new List<string>();
            filtro1.Add("Tempo todos dados(Arquivo)");
            filtro1.Add("Tempo todos dados(BD)");

            var dadosPesquisa1 = this.desempenhoDao.GetDadosByFiltro(filtro1);
            List<Dados> listaDados1 = new List<Dados>();
            string nomeTeste1 = "";
            foreach (var dados in dadosPesquisa1)
            {
                if (nomeTeste1 != dados.NomeTeste)
                {
                    nomeTeste1 = dados.NomeTeste;
                    listaDados1 = new List<Dados>();

                    LineSeries series = new LineSeries
                    {
                        Title = nomeTeste1,
                        DependentValuePath = "Valor",
                        IndependentValuePath = "Data",
                        ItemsSource = listaDados1
                    };
                    mcChartTodosDados.Series.Add(series);
                }

                Dados d = new Dados();
                d.Data = dados.Data;
                d.Valor = dados.TempoExecucao / 1000;
                listaDados1.Add(d);
            }

            List<string> filtro2 = new List<string>();
            filtro2.Add("Tempo dado índice(Arquivo)");
            filtro2.Add("Tempo índice(BD)");

            var dadosPesquisa2 = this.desempenhoDao.GetDadosByFiltro(filtro2);
            List<Dados> listaDados2 = new List<Dados>();
            string nomeTeste2 = "";
            foreach (var dados in dadosPesquisa2)
            {
                if (nomeTeste2 != dados.NomeTeste)
                {
                    nomeTeste2 = dados.NomeTeste;
                    listaDados2 = new List<Dados>();

                    LineSeries series = new LineSeries
                    {
                        Title = nomeTeste2,
                        DependentValuePath = "Valor",
                        IndependentValuePath = "Data",
                        ItemsSource = listaDados2
                    };
                    mcChartBusca.Series.Add(series);
                }

                Dados d = new Dados();
                d.Data = dados.Data;
                d.Valor = dados.TempoExecucao;
                listaDados2.Add(d);
            }

            List<string> filtro3 = new List<string>();
            filtro3.Add("Tempo hipótese(Arquivo)");
            filtro3.Add("Tempo hipótese(BD)");

            var dadosPesquisa3 = this.desempenhoDao.GetDadosByFiltro(filtro3);
            List<Dados> listaDados3 = new List<Dados>();
            string nomeTeste3 = "";
            foreach (var dados in dadosPesquisa3)
            {
                if (nomeTeste3 != dados.NomeTeste)
                {
                    nomeTeste3 = dados.NomeTeste;
                    listaDados3 = new List<Dados>();

                    LineSeries series = new LineSeries
                    {
                        Title = nomeTeste3,
                        DependentValuePath = "Valor",
                        IndependentValuePath = "Data",
                        ItemsSource = listaDados3
                    };
                    mcChartHipotese.Series.Add(series);
                }

                Dados d = new Dados();
                d.Data = dados.Data;
                d.Valor = dados.TempoExecucao / 1000;
                listaDados3.Add(d);
            }

            List<string> filtro4 = new List<string>();
            filtro4.Add("Tempo dado hashtag(Arquivo)");
            filtro4.Add("Tempo dado data(Arquivo)");
            filtro4.Add("Tempo dado trie(Arquivo)");

            var dadosPesquisa4 = this.desempenhoDao.GetDadosByFiltro(filtro4);
            List<Dados> listaDados4 = new List<Dados>();
            string nomeTeste4 = "";
            foreach (var dados in dadosPesquisa4)
            {
                if (nomeTeste4 != dados.NomeTeste)
                {
                    nomeTeste4 = dados.NomeTeste;
                    listaDados4 = new List<Dados>();

                    LineSeries series = new LineSeries
                    {
                        Title = nomeTeste4,
                        DependentValuePath = "Valor",
                        IndependentValuePath = "Data",
                        ItemsSource = listaDados4
                    };
                    mcChartBuscaGeral.Series.Add(series);
                }

                Dados d = new Dados();
                d.Data = dados.Data;
                d.Valor = dados.TempoExecucao;
                listaDados4.Add(d);
            }
        }
    }

    public class Dados
    {
        public DateTime Data { get; set; }
        public double Valor { get; set; }
    }
}
