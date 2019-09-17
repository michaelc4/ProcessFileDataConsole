using System.IO;
using System.Threading;

namespace ProcessFileDataConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int stackSize = 1024 * 1024 * 64;
            Thread th = new Thread(() =>
            {
                string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                path = path.Replace("\\ProcessFileDataConsole\\bin", "");
                string strNameFile = path + "\\ArquivoDados.txt";
                string strNameFileIndice = path + "\\ArquivoIndice.txt";
                Principal p = new Principal();
                p.Start(strNameFile, strNameFileIndice);
            },
            stackSize);
            th.Start();
            th.Join();
        }
    }
}
