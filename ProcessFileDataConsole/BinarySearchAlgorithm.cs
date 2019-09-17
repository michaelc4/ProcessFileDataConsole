using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ProcessFileDataConsole
{
    public class BinarySearchAlgorithm
    {
        public bool BinarySearchById<T>(long idBusca, string filename, ref T returnObject)
        {
            try
            {
                bool achou = false;
                long tamanhoBytes = Marshal.SizeOf(typeof(T)) + 1;
                long index = 0;
                T registroIndice = Activator.CreateInstance<T>();

                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    long numMaxRegistros = (long)Math.Ceiling(fs.Length / (double)tamanhoBytes);
                    fs.Seek(0, SeekOrigin.Begin);
                    BinarySearch(fs, idBusca, fs.Position, fs.Length, tamanhoBytes, numMaxRegistros, ref index, ref registroIndice, ref achou);
                    returnObject = registroIndice;
                }

                GC.Collect();
                return achou;
            }
            catch (Exception)
            {
                GC.Collect();
                return false;
            }
        }

        private void BinarySearch<T>(FileStream readStream, long idBusca, long inicio, long fim, long tamanhoBytes, long numMaxRegistros, ref long index, ref T registro, ref bool achou)
        {
            try
            {
                if (!achou && (fim - inicio) > 0 && index <= numMaxRegistros)
                {
                    long meio = (long)Math.Round((((double)inicio + fim) / tamanhoBytes) / 2);
                    meio *= tamanhoBytes;
                    readStream.Seek(meio, SeekOrigin.Begin);
                    var oReturn = GetFileValue<T>(readStream);
                    long idObject = 0;
                    foreach (var field in oReturn.GetType().GetFields())
                        if (field.Name.ToLower() == "id")
                            idObject = (long)field.GetValue(oReturn);
                    if (idObject == idBusca)
                    {
                        achou = true;
                        registro = oReturn;
                    }
                    else if (idObject > idBusca)
                    {
                        index++;
                        RuntimeHelpers.EnsureSufficientExecutionStack();
                        BinarySearch(readStream, idBusca, inicio, meio, tamanhoBytes, numMaxRegistros, ref index, ref registro, ref achou);
                    }
                    else
                    {
                        index++;
                        RuntimeHelpers.EnsureSufficientExecutionStack();
                        BinarySearch(readStream, idBusca, meio, fim, tamanhoBytes, numMaxRegistros, ref index, ref registro, ref achou);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public T GetFileValue<T>(FileStream readStream)
        {
            try
            {
                byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
                readStream.Read(buffer, 0, buffer.Length);
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                T oReturn = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                handle.Free();
                return oReturn;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
