using System.Collections.Generic;
using System.Linq;

namespace ProcessFileDataConsole
{
    public class Trie
    {
        private static void Insert(string key, long address, TrieNode root)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();
                pCrawl = pCrawl.children[index];
            }

            pCrawl.final = true;
            pCrawl.enderecos.Add(address);
        }

        public static void Add(string key, long address, TrieNode root)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl == null || pCrawl.children[index] == null)
                {
                    Insert(key, address, root);
                }
                pCrawl = pCrawl.children[index];
            }

            if (pCrawl != null && pCrawl.final && !pCrawl.enderecos.Contains(address))
            {
                pCrawl.enderecos.Add(address);
            }
        }

        public static bool Search(string key, TrieNode root, out List<long> addresses)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;
            addresses = new List<long>();

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl == null || pCrawl.children[index] == null)
                    return false;
                pCrawl = pCrawl.children[index];
            }

            if (pCrawl != null && pCrawl.final)
            {
                addresses = pCrawl.enderecos;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public bool final;
        public List<long> enderecos = new List<long>();

        public TrieNode()
        {
            final = false;
            for (int i = 0; i < 26; i++)
                children[i] = null;
        }
    };
}
