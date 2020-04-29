using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections;
using System.Threading;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System.Windows.Forms;

namespace Compras
{
    public class Processo
    {
        MLContext mlcontext;

        public List<Cliente> _ListaCliente;

        public List<Historico> _ListaHistorico;

        public Processo(string urlCliente, string urlHistorico)
        {
            mlcontext = new MLContext();
            GetAllClientes(urlCliente);
            Thread.Sleep(50);
            GetAllHistorico(urlHistorico);
        }

        private async void GetAllClientes(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    using (var client = new HttpClient())
                    {
                        using (var response = await client.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                                _ListaCliente = JsonConvert.DeserializeObject<Cliente[]>(ProdutoJsonString).ToList();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void GetAllHistorico(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    using (var historico = new HttpClient())
                    {
                        using (var response = await historico.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                                _ListaHistorico = JsonConvert.DeserializeObject<Historico[]>(ProdutoJsonString).ToList();
                                _ListaHistorico.ForEach(h => { h.cliente = Convert.ToInt32(h.cliente.Replace(".", "")).ToString(); });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteCompra> GetListaClientesMaiorValor()
        {
            List<ClienteCompra> Lista = new List<ClienteCompra>();
            ClienteCompra resultado;
            _ListaHistorico.OrderByDescending(x => x.valorTotal).ToList().ForEach(z =>
            {
                resultado = new ClienteCompra();
                resultado.Nome = _ListaCliente.Where(c => c.id == Int32.Parse(z.cliente)).FirstOrDefault().nome;
                resultado.ValorTotal = z.valorTotal;
                Lista.Add(resultado);
            });
            return Lista;
        }

        public List<ClienteCompra> GetMaiorClienteCompra()
        {
            ClienteCompra resultado;
            List<ClienteCompra> Lista = new List<ClienteCompra>();
            _ListaHistorico.Where(h => Convert.ToDateTime(h.data).Year == 2016 && h.itens.Count == 1).ToList().OrderByDescending(x => x.valorTotal).ToList().ForEach(z =>
            {
                resultado = new ClienteCompra();
                resultado.Nome = _ListaCliente.Where(c => c.id == Int32.Parse(z.cliente)).FirstOrDefault().nome;
                resultado.ValorTotal = z.valorTotal;
                Lista.Add(resultado);
            });
            return Lista;
        }

        public ArrayList GetClientesFieis()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            List<ClienteFiel> Lista = new List<ClienteFiel>();
            _ListaHistorico.ForEach(h =>
            {
                if (dict.ContainsKey(h.cliente))
                {
                    dict[h.cliente] += 1;
                }
                else
                {
                    dict.Add(h.cliente, 1);
                }

            });

            ArrayList arrlista = new ArrayList();
            foreach (var item in dict)
            {
                ClienteFiel _ClienteFiel = new ClienteFiel();
                _ClienteFiel.Nome = _ListaCliente.Where(c => c.id == Int32.Parse(item.Key)).FirstOrDefault().nome;
                _ClienteFiel.Total = item.Value;
                arrlista.Add(_ClienteFiel);
            }

            arrlista.Sort(new Comparer());

            arrlista.Reverse();

            return arrlista;
        }

        public class Comparer : IComparer
        {
            int IComparer.Compare(Object xx, Object yy)
            {
                ClienteFiel x = (ClienteFiel)xx;
                ClienteFiel y = (ClienteFiel)yy;
                //sort by age
                return x.Total.CompareTo(y.Total);
            }
        }

        public List<Recomendacao> Recomendar()
        {
            ClienteProduto resultado;
            List<ClienteProduto> Lista = new List<ClienteProduto>();
            _ListaHistorico.OrderBy(w => w.cliente).ToList().ForEach(z =>
            {
                if (z.itens != null)
                {
                    z.itens.ForEach(i => {
                        resultado = new ClienteProduto();
                        resultado.Cliente = Int32.Parse(z.cliente);
                        resultado.Produto = i.produto;
                        Lista.Add(resultado);
                    });
                }
            });
            List<Recomendacao> ListaRecomendacao = new List<Recomendacao>();

            var result = Lista.GroupBy(x => new { x.Cliente, x.Produto }).Select(g => new { g.Key.Cliente, g.Key.Produto, Quantidade = g.Count() }).ToList();

            Recomendacao _Recomendacao;
            if (result != null)
            {
                result.ForEach(x =>
                {
                    _Recomendacao = new Recomendacao();
                    _Recomendacao.Cliente = x.Cliente;
                    _Recomendacao.Produto = x.Produto;
                    //_Recomendacao.Quantidade = x.Quantidade;

                    ListaRecomendacao.Add(_Recomendacao);
                });
            }

            Recomendacao[] arrRecomendacao = ListaRecomendacao.ToArray();

            var json = JsonConvert.SerializeObject(ListaRecomendacao);

            IDataView trainingDataView = mlcontext.Data.LoadFromEnumerable<Recomendacao>(arrRecomendacao);

            var dataProcessingPipeline = mlcontext.Transforms.Conversion.MapValueToKey(outputColumnName: "clienteEncoded", inputColumnName: nameof(Recomendacao.Cliente))
               .Append(mlcontext.Transforms.Conversion.MapValueToKey(outputColumnName: "produtoEncoded", inputColumnName: nameof(Recomendacao.Produto)));

            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            options.MatrixColumnIndexColumnName = "clienteEncoded";
            options.MatrixRowIndexColumnName = "produtoEncoded";
            options.LabelColumnName = "Label";
            options.NumberOfIterations = 20;
            options.ApproximationRank = 100;

            var trainingPipeLine = dataProcessingPipeline.Append(mlcontext.Recommendation().Trainers.MatrixFactorization(options));

            ITransformer model = trainingPipeLine.Fit(trainingDataView);

            IDataView testDataView = mlcontext.Data.LoadFromEnumerable<Recomendacao>(arrRecomendacao);
            var prediction = model.Transform(testDataView);
            var metrics = mlcontext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

            var predictionengine = mlcontext.Model.CreatePredictionEngine<Recomendacao, ProdutoPredileto>(model);

            var movieratingprediction = predictionengine.Predict(
                new Recomendacao()
                {
                    Cliente = 6,
                    Produto = "Wente Reliz Creek Pinot Noir"
                }
            );

            MessageBox.Show("For cliente: Pamela produto predileto (1 - 5 stars) for produto : Wente Reliz Creek Pinot Noir is:" + Math.Round(movieratingprediction.Score, 1));

            return ListaRecomendacao;
        }
    }
}
