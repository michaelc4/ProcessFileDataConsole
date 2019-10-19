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

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct StrFileIndiceHashtags
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Hashtag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
            public long[] Ids;
            public char NewLine;
        }

        private struct IndiceHashData
        {
            public int hash;
            public List<long> enderecos;
        }

        private string strNameFile = "";
        private string strNameFileIndice = "";
        private string strNameIndiceHashtags = "";
        private List<IndiceHashData> listaHashData = new List<IndiceHashData>();

        public void Start(string strNameFile, string strNameFileIndice, string strNameIndiceHashtags)
        {
            this.strNameFile = strNameFile;
            this.strNameFileIndice = strNameFileIndice;
            this.strNameIndiceHashtags = strNameIndiceHashtags;

            int exit = -1;
            while (exit == -1)
            {
                Console.Clear();
                Console.WriteLine("Digite 0 para sair");
                Console.WriteLine("Digite 1 para buscar dados do Twitter");
                Console.WriteLine("Digite 2 Mostrar todos os valores");
                Console.WriteLine("Digite 3 Mostrar todos os índices");
                Console.WriteLine("Digite 4 Buscar posição tabela índices(Pesquisa Binária)");
                Console.WriteLine("Digite 5 Buscar dados pelo índice(Pesquisa Binária)");
                Console.WriteLine("Digite 6 Gerar índice hashtags");
                Console.WriteLine("Digite 7 Mostrar todos os índices HashTag");
                Console.WriteLine("Digite 8 Buscar dados pela HashTag");
                Console.WriteLine("Digite 9 Carregar indice hash por data");
                Console.WriteLine("Digite 10 Buscar dados por data(índice hash)");

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
                    case 5:
                        GetPositionIndexData();
                        break;
                    case 6:
                        GenerateAllIndiceHashtags();
                        break;
                    case 7:
                        GetAllIndiceHashStructureValue();
                        break;
                    case 8:
                        GetPositionIndexDataByHashTag();
                        break;
                    case 9:
                        CarregarIndiceHashData();
                        break;
                    case 10:
                        GetdataIndexHash();
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
                        Console.WriteLine(string.Format("ID: {0}|Usuário: {1}|Data: {2}|HashTags: {3}", oReturn.Id, oReturn.Usuario, oReturn.Data.Trim() + "9", oReturn.HashTags));
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

        private void GetPositionIndexData()
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
                    FileStream fsDados = new FileStream(strNameFile, FileMode.Open);
                    fsDados.Seek(sfi.Posicao, SeekOrigin.Begin);
                    StrFile oReturn = bsa.GetFileValue<StrFile>(fsDados);
                    Console.WriteLine(string.Format("Id: {0}", oReturn.Id));
                    Console.WriteLine(string.Format("Usuário: {0}", oReturn.Usuario));
                    Console.WriteLine(string.Format("Mensagem: {0}", oReturn.Mensagem));
                    Console.WriteLine(string.Format("Data: {0}", oReturn.Data.Trim() + "9"));
                    Console.WriteLine(string.Format("País: {0}", oReturn.Pais));
                    Console.WriteLine(string.Format("Hashtags: {0}", oReturn.HashTags));
                    Console.WriteLine("");

                    fsDados.Close();
                    fsDados.Dispose();
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

        private void GenerateAllIndiceHashtags()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Aguarde. Gerando índice.");

                List<FileStream> listaStream = new List<FileStream>();
                listaStream.Add(new FileStream(strNameFile, FileMode.Open));
                listaStream.Add(new FileStream(strNameIndiceHashtags, FileMode.Open));

                listaStream[0].Seek(0, SeekOrigin.Begin);
                while (listaStream[0].Position < listaStream[0].Length)
                {
                    if (listaStream[0].Position > 0)
                        listaStream[0].Position += 1;

                    BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                    StrFile oReturn = bsa.GetFileValue<StrFile>(listaStream[0]);
                    string[] hashtagsarray = oReturn.HashTags.Split("#");
                    foreach (string hashtag in hashtagsarray)
                    {
                        if (hashtag.Trim() != "" && (hashtag.ToLower().Contains("rock") || hashtag.ToLower().Contains("metal") || hashtag.ToLower().Contains("punk") || hashtag.ToLower().Contains("hard")))
                        {
                            FileWrite fw = new FileWrite();
                            bool achou = false;
                            string hashtagAux = "#" + hashtag.Trim();
                            listaStream[1].Seek(0, SeekOrigin.Begin);
                            while (listaStream[1].Position < listaStream[1].Length)
                            {
                                if (listaStream[1].Position > 0)
                                    listaStream[1].Position += 1;

                                StrFileIndiceHashtags oReturnInd = bsa.GetFileValue<StrFileIndiceHashtags>(listaStream[1]);
                                if (oReturnInd.Hashtag.Trim() == hashtagAux.Trim())
                                {
                                    achou = true;
                                    for (int i = 1; i < 1000; i++)
                                    {
                                        if (oReturnInd.Ids[i] == 0)
                                        {
                                            oReturnInd.Ids[i] = oReturn.Id;
                                            break;
                                        }
                                    }
                                    long tamanhoBytes = Marshal.SizeOf(typeof(StrFileIndiceHashtags));
                                    if (listaStream[1].Position > 0)
                                        listaStream[1].Position -= tamanhoBytes;
                                    byte[] buf = fw.GetBytes(oReturnInd);
                                    listaStream[1].Write(buf);
                                }
                            }

                            if (!achou)
                            {
                                StrFileIndiceHashtags sfih = new StrFileIndiceHashtags();
                                sfih.Hashtag = hashtagAux;
                                sfih.Ids = new long[1000];
                                sfih.Ids[0] = oReturn.Id;
                                sfih.NewLine = '\n';
                                long position = 0;
                                if (listaStream[1].Length > 0)
                                {
                                    position = listaStream[1].Length + 1;
                                    listaStream[1].Position = position;
                                }
                                byte[] buf = fw.GetBytes(sfih);
                                listaStream[1].Write(buf);
                            }
                        }
                    }
                }

                listaStream[0].Close();
                listaStream[1].Close();
                listaStream[0].Dispose();
                listaStream[1].Dispose();

                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetAllIndiceHashStructureValue()
        {
            try
            {
                using (FileStream readStream = new FileStream(strNameIndiceHashtags, FileMode.Open))
                {
                    while (readStream.Position < readStream.Length)
                    {
                        if (readStream.Position > 0)
                            readStream.Position += 1;

                        BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                        StrFileIndiceHashtags oReturn = bsa.GetFileValue<StrFileIndiceHashtags>(readStream);
                        StringBuilder ids = new StringBuilder();
                        for (int i = 0; i < 1000; i++)
                        {
                            if (oReturn.Ids[i] != 0)
                            {
                                if (i == 0)
                                {
                                    ids.Append(oReturn.Ids[i]);
                                }
                                else
                                {
                                    ids.Append("," + oReturn.Ids[i]);
                                }
                            }
                        }
                        Console.WriteLine(string.Format("HashTag: {0}|Ids: [{1}]", oReturn.Hashtag, ids.ToString().Trim()));
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

        private void GetPositionIndexDataByHashTag()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Informe a HashTag");
                string hashTagBusca = Console.ReadLine();

                if (hashTagBusca.Trim() == "")
                    throw new Exception("Erro");

                List<FileStream> listaStream = new List<FileStream>();
                listaStream.Add(new FileStream(strNameFile, FileMode.Open));
                listaStream.Add(new FileStream(strNameIndiceHashtags, FileMode.Open));

                while (listaStream[1].Position < listaStream[1].Length)
                {
                    if (listaStream[1].Position > 0)
                        listaStream[1].Position += 1;

                    BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                    StrFileIndiceHashtags oReturn = bsa.GetFileValue<StrFileIndiceHashtags>(listaStream[1]);
                    if (oReturn.Hashtag.Contains(hashTagBusca.Trim()))
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            if (oReturn.Ids[i] == 0)
                                break;

                            StrFileIndice sfi = new StrFileIndice();
                            if (bsa.BinarySearchById(oReturn.Ids[i], strNameFileIndice, ref sfi))
                            {
                                listaStream[0].Seek(sfi.Posicao, SeekOrigin.Begin);
                                StrFile oReturnData = bsa.GetFileValue<StrFile>(listaStream[0]);
                                Console.WriteLine(string.Format("Id: {0}", oReturnData.Id));
                                Console.WriteLine(string.Format("Usuário: {0}", oReturnData.Usuario));
                                Console.WriteLine(string.Format("Mensagem: {0}", oReturnData.Mensagem));
                                Console.WriteLine(string.Format("Data: {0}", oReturnData.Data.Trim() + "9"));
                                Console.WriteLine(string.Format("País: {0}", oReturnData.Pais));
                                Console.WriteLine(string.Format("Hashtags: {0}", oReturnData.HashTags));
                                Console.WriteLine("---------------------------------------------------------------------");
                            }
                        }
                    }
                }

                listaStream[0].Close();
                listaStream[1].Close();
                listaStream[0].Dispose();
                listaStream[1].Dispose();

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

        private void CarregarIndiceHashData()
        {
            Console.Clear();
            Console.WriteLine("Carregando. Aguarde...");
            listaHashData.Clear();
            for (int i = 0; i < 1000; i++)
            {
                IndiceHashData ihd = new IndiceHashData();
                ihd.hash = i;
                ihd.enderecos = new List<long>();
                listaHashData.Add(ihd);
            }

            try
            {
                using (FileStream readStream = new FileStream(strNameFile, FileMode.Open))
                {
                    while (readStream.Position < readStream.Length)
                    {
                        if (readStream.Position > 0)
                            readStream.Position += 1;
                        long posicao = readStream.Position;

                        BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                        StrFile oReturn = bsa.GetFileValue<StrFile>(readStream);
                        string data = oReturn.Data.Trim() + "9";
                        data = data.Substring(0, 2) + data.Substring(3, 2);
                        int hashResult = int.Parse(data) % 1000;
                        var ihd = listaHashData.Where(x => x.hash == hashResult).FirstOrDefault();
                        ihd.enderecos.Add(posicao);
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

        private void GetdataIndexHash()
        {
            Console.Clear();
            if (listaHashData.Count == 0)
            {
                Console.WriteLine("Lista de índices vazia");
                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Informe a Data");
                string dataInput = Console.ReadLine();

                try
                {
                    DateTime dataBusca;
                    if (DateTime.TryParse(dataInput, out dataBusca))
                    {
                        string data = dataBusca.ToString("ddMM");
                        int hashResult = int.Parse(data) % 1000;
                        var ihd = listaHashData.Where(x => x.hash == hashResult).FirstOrDefault();
                        if (ihd.enderecos.Count == 0)
                        {
                            Console.WriteLine("Nenhum dado encontrado para a data informada.");
                        }
                        else
                        {
                            List<FileStream> listaStream = new List<FileStream>();
                            listaStream.Add(new FileStream(strNameFile, FileMode.Open));

                            BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();

                            foreach (long endereco in ihd.enderecos)
                            {
                                listaStream[0].Seek(endereco, SeekOrigin.Begin);
                                StrFile oReturnData = bsa.GetFileValue<StrFile>(listaStream[0]);

                                string dataP = dataBusca.ToString("dd/MM/yyyy");
                                if (dataP == oReturnData.Data.Trim() + "9")
                                {
                                    Console.WriteLine(string.Format("Id: {0}", oReturnData.Id));
                                    Console.WriteLine(string.Format("Usuário: {0}", oReturnData.Usuario));
                                    Console.WriteLine(string.Format("Mensagem: {0}", oReturnData.Mensagem));
                                    Console.WriteLine(string.Format("Data: {0}", oReturnData.Data.Trim() + "9"));
                                    Console.WriteLine(string.Format("País: {0}", oReturnData.Pais));
                                    Console.WriteLine(string.Format("Hashtags: {0}", oReturnData.HashTags));
                                    Console.WriteLine("---------------------------------------------------------------------");
                                }
                            }

                            listaStream[0].Close();
                            listaStream[0].Dispose();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data inválida.");
                    }

                    Console.WriteLine("Pressione uma tecla para continuar.");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
