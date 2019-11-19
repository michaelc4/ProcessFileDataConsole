using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessFileDataConsole;
using Raven.Client.Documents;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tweetinvi.Models;
using static ProcessFileDataConsole.Principal;

namespace UnitTestProjeto
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void MethodTestBinarySearch()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            path = path.Replace("\\UnitTestProjeto\\bin", "");
            string strNameFileIndice = path + "\\ArquivoIndice.txt";
            BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
            StrFileIndice objeto = new StrFileIndice();
            if (bsa.BinarySearchById(1170023482421325824, strNameFileIndice, ref objeto))
            {
                Assert.AreEqual(1170023482421325824, objeto.Id);
            }
        }

        [TestMethod]
        public void MethodTestTrie()
        {
            var root = new TrieNode();
            Trie.Add("ata", 1000, root);
            Trie.Add("ata", 1100, root);
            Trie.Add("eta", 1200, root);
            if (Trie.Search("ata", root, out List<long> enderecos))
            {
                CollectionAssert.AreEqual(enderecos, new List<long>() { 1000, 1100 });
            }
        }

        [TestMethod]
        public void MethodTestGravaDados()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            path = path.Replace("\\UnitTestProjeto\\bin", "");
            string strNameFile = path + "\\ArquivoDados.txt";
            string strNameFileIndice = path + "\\ArquivoIndice.txt";

            List<ITweet> listaTweets = new List<ITweet>();
            Tweets tweets = new Tweets();
            listaTweets.AddRange(tweets.BuscarTweets("", "", "", "", "#RockBand"));

            Principal p = new Principal();
            p.strNameFile = strNameFile;
            p.strNameFileIndice = strNameFileIndice;
            p.GravarDados(listaTweets);
            BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
            StrFileIndice objeto = new StrFileIndice();
            if (bsa.BinarySearchById(1170023482421325824, strNameFileIndice, ref objeto))
            {
                Assert.AreEqual(1170023482421325824, objeto.Id);
            }
        }

        [TestMethod]
        public void MethodTestEnderecoIndice()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            path = path.Replace("\\UnitTestProjeto\\bin", "");
            string strNameFile = path + "\\ArquivoDados.txt";
            string strNameFileIndice = path + "\\ArquivoIndice.txt";

            BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
            StrFileIndice objeto = new StrFileIndice();
            if (bsa.BinarySearchById(1170023482421325824, strNameFileIndice, ref objeto))
            {
                FileStream fsDados = new FileStream(strNameFile, FileMode.Open);
                fsDados.Seek(objeto.Posicao, SeekOrigin.Begin);
                StrFile oReturn = bsa.GetFileValue<StrFile>(fsDados);
                Assert.AreEqual(1170023482421325824, oReturn.Id);

                fsDados.Close();
                fsDados.Dispose();
            }
        }

        [TestMethod]
        public void MethodTestListMemory()
        {
            List<IndiceHashData> listaHashData = new List<IndiceHashData>();
            listaHashData.Clear();
            for (int i = 0; i < 1000; i++)
            {
                IndiceHashData ihashd = new IndiceHashData();
                ihashd.hash = i;
                ihashd.enderecos = new List<long>();
                listaHashData.Add(ihashd);
            }

            string data1 = "22/12/2019";
            data1 = data1.Substring(0, 2) + data1.Substring(3, 2);
            int hashResult1 = int.Parse(data1) % 1000;
            var ihd1 = listaHashData.Where(x => x.hash == hashResult1).FirstOrDefault();
            ihd1.enderecos.Add(1000);

            string data2 = "23/12/2019";
            data2 = data2.Substring(0, 2) + data2.Substring(3, 2);
            int hashResult2 = int.Parse(data2) % 1000;
            var ihd2 = listaHashData.Where(x => x.hash == hashResult2).FirstOrDefault();
            ihd2.enderecos.Add(1100);

            string data3 = "22/12/2019";
            data3 = data3.Substring(0, 2) + data3.Substring(3, 2);
            int hashResult3 = int.Parse(data3) % 1000;
            var ihd3 = listaHashData.Where(x => x.hash == hashResult3).FirstOrDefault();
            ihd3.enderecos.Add(1200);

            string data = "2212";
            int hashResult = int.Parse(data) % 1000;
            var ihd = listaHashData.Where(x => x.hash == hashResult).FirstOrDefault();
            CollectionAssert.AreEqual(ihd.enderecos, new List<long>() { 1000, 1200 });
        }

        [TestMethod]
        public void MethodTestCriptografia()
        {
            Criptografia cpt = new Criptografia();
            cpt.Key = "Teste";

            string name = "Código criptografado";
            string resultado = cpt.Decrypt(cpt.Encrypt(name));
            Assert.AreEqual(name, resultado);
        }

        [TestMethod]
        public void MethodTestRegistroDesempenho()
        {
            var documentStoreTwitter = new DocumentStore
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "Database_Twitter"
            };

            documentStoreTwitter.Initialize();
            DesempenhoDao desempenhoDao = new DesempenhoDao(documentStoreTwitter);

            var des = new DesempenhoModel();
            des.NomeTeste = "Teste";
            des.TempoExecucao = 0.25;
            desempenhoDao.Store(des);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MethodTestBuscaBanda()
        {
            var documentStoreTwitter = new DocumentStore
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "Database_Twitter"
            };

            documentStoreTwitter.Initialize();
            TwitterDao twitterDao = new TwitterDao(documentStoreTwitter);

            int num = twitterDao.GetBuscaBanda("Queen");
            Assert.IsTrue(num > 0);
        }
    }
}
