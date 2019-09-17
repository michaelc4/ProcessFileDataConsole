using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Tweetinvi.Models;

namespace ProcessFileDataConsole
{
    public class Principal
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct StrFile
        {
            public long Id;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
            public string Usuario;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string Mensagem;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string Data;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Pais;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
            public string HashTags;
            public long Elo;
            public char NewLine;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct StrFileIndice
        {
            public long Id;
            public long Posicao;
            public char NewLine;
        }

        private string strNameFile = "";
        private string strNameFileIndice = "";

        public void Start(string strNameFile, string strNameFileIndice)
        {
            this.strNameFile = strNameFile;
            this.strNameFileIndice = strNameFileIndice;

            int exit = -1;
            while (exit == -1)
            {
                Console.Clear();
                Console.WriteLine("Digite 0 para sair");
                Console.WriteLine("Digite 1 para buscar dados do Twitter");
                Console.WriteLine("Digite 2 Mostrar todos os valores");
                Console.WriteLine("Digite 3 Mostrar todos os índices");
                Console.WriteLine("Digite 4 Buscar posição tabela índices(Pesquisa Binária)");

                int entrada;
                try
                {
                    entrada = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    entrada = -1;
                }

                switch (entrada)
                {
                    case 0:
                        exit = entrada;
                        break;
                    case 1:
                        BuscaDadosTwitter();
                        break;
                    case 2:
                        GetAllStructureValue();
                        break;
                    case 3:
                        GetAllIndiceStructureValue();
                        break;
                    case 4:
                        GetPositionIndex();
                        break;
                }
            }
        }

        private void BuscaDadosTwitter()
        {
            Console.Clear();
            Console.WriteLine("Informe a consumer key");
            string consumerKey = Console.ReadLine();
            Console.WriteLine("Informe o consumer secret");
            string consumerSecret = Console.ReadLine();
            Console.WriteLine("Informe o access token");
            string accessToken = Console.ReadLine();
            Console.WriteLine("Informe o access token secret");
            string accessTokenSecret = Console.ReadLine();

            try
            {
                Console.WriteLine("Aguarde processando...");
                List<ITweet> listaTweets = new List<ITweet>();
                Tweets tweets = new Tweets();
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#RockBand"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rocklover"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rockalternativo"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rockindependiente"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#hardrock"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rockmusic"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rocknroll"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rockandroll"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#guitar"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#livemusic"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#liveshow"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#concert"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rockshow"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#heavymetal"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#metal"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#heavymerch"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#deathmetal"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#ThrashMetal"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#newrock"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#Metalplaylist"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rockplaylist"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#punkrock"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#hardcorepunk"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#punkspelomundo"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#Punk"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#alternativerock"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#alternativemetal"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#music"));
                listaTweets.AddRange(tweets.BuscarTweets(consumerKey, consumerSecret, accessToken, accessTokenSecret, "#rock"));
                GravarDados(listaTweets);

                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Dados inválidos.");
                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
        }

        private void GravarDados(IEnumerable<ITweet> tweetsPar)
        {
            var tweets = tweetsPar.Distinct().OrderBy(x => x.Id);
            foreach (var item in tweets)
            {
                StrFileIndice sfi = new StrFileIndice();
                BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                if (!bsa.BinarySearchById(item.Id, strNameFileIndice, ref sfi))
                {
                    StrFile strFile = new StrFile();
                    strFile.Id = item.Id;
                    if (item.FullText.Length > 500)
                        strFile.Mensagem = item.FullText.Substring(0, 500);
                    else
                        strFile.Mensagem = item.FullText;
                    strFile.Data = item.CreatedAt.ToString("dd/MM/yyyy");
                    strFile.Usuario = item.CreatedBy.Name;
                    strFile.Pais = item.Place != null && item.Place.Name != null ? item.Place.Name : "";

                    StringBuilder strHash = new StringBuilder();
                    if (item.Hashtags != null && item.Hashtags.Count > 0)
                    {
                        foreach (var hash in item.Hashtags)
                        {
                            strHash.Append(hash);
                        }
                    }
                    if (strHash.ToString().Length > 200)
                        strFile.HashTags = strHash.ToString().Substring(0, 200);
                    else
                        strFile.HashTags = strHash.ToString();
                    strFile.Elo = 0;
                    strFile.NewLine = '\n';
                    FileWrite fWrite = new FileWrite();
                    long position = fWrite.WriteStructure(strFile, strNameFile);

                    StrFileIndice strFileIndice = new StrFileIndice();
                    strFileIndice.Id = item.Id;
                    strFileIndice.Posicao = position;
                    strFileIndice.NewLine = '\n';
                    fWrite.WriteStructureIndex(strFileIndice, strNameFileIndice);
                }
            }
        }

        private void GetAllStructureValue()
        {
            try
            {
                using (FileStream readStream = new FileStream(strNameFile, FileMode.Open))
                {
                    while (readStream.Position < readStream.Length)
                    {
                        if (readStream.Position > 0)
                            readStream.Position += 1;

                        BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                        StrFile oReturn = bsa.GetFileValue<StrFile>(readStream);
                        Console.WriteLine(string.Format("ID: {0}|Usuário: {1}|Data:{2}|HashTags:{3}", oReturn.Id, oReturn.Usuario, oReturn.Data, oReturn.HashTags));
                    }
                }

                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetAllIndiceStructureValue()
        {
            try
            {
                using (FileStream readStream = new FileStream(strNameFileIndice, FileMode.Open))
                {
                    while (readStream.Position < readStream.Length)
                    {
                        if (readStream.Position > 0)
                            readStream.Position += 1;

                        BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                        StrFileIndice oReturn = bsa.GetFileValue<StrFileIndice>(readStream);
                        Console.WriteLine(string.Format("ID: {0}|Posição: {1}", oReturn.Id, oReturn.Posicao));
                    }
                }

                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetPositionIndex()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Informe o ID");
                long idBusca = long.Parse(Console.ReadLine());

                StrFileIndice sfi = new StrFileIndice();
                BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                if (bsa.BinarySearchById(idBusca, strNameFileIndice, ref sfi))
                {
                    Console.WriteLine("Índice encontrado.");
                    Console.WriteLine(string.Format("ID: {0}|Posição: {1}", sfi.Id, sfi.Posicao));
                }
                else
                {
                    Console.WriteLine("Índice ñ encontrado.");
                }

                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Dados inválidos.");
                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
        }
    }
}
