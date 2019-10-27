using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessFileDataConsole;
using System.Collections.Generic;
using System.IO;
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
    }
}
