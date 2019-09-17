using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ProcessFileDataConsole
{
    class FileWrite
    {
        public long WriteStructure<T>(T oStruct, string filename)
        {
            try
            {
                long position = 0;
                using (FileStream writeStream = new FileStream(filename, FileMode.Open))
                {
                    byte[] buf = getBytes(oStruct);
                    if (writeStream.Length > 0)
                    {
                        position = writeStream.Length + 1;
                        writeStream.Position = position;
                    }
                    writeStream.Write(buf);
                }

                return position;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void WriteStructureIndex<T>(T oStruct, string filename)
        {
            FileStream writeStream = new FileStream(filename, FileMode.Open);
            try
            {
                writeStream.Seek(0, SeekOrigin.Begin);
                if (writeStream.Length <= 0)
                {
                    byte[] buf = getBytes(oStruct);
                    writeStream.Write(buf);
                }
                else
                {
                    bool achou = false;
                    while (writeStream.Position < writeStream.Length)
                    {
                        if (writeStream.Position > 0)
                            writeStream.Position += 1;

                        long idStruct = 0;
                        foreach (var field in oStruct.GetType().GetFields())
                            if (field.Name.ToLower() == "id")
                                idStruct = (long)field.GetValue(oStruct);
                        long idObject = 0;
                        BinarySearchAlgorithm bsa = new BinarySearchAlgorithm();
                        T oReturn = bsa.GetFileValue<T>(writeStream);
                        foreach (var field in oReturn.GetType().GetFields())
                            if (field.Name.ToLower() == "id")
                                idObject = (long)field.GetValue(oReturn);
                        if (idStruct < idObject)
                        {
                            achou = true;
                            writeStream.Position -= 24;
                            byte[] buf = getBytes(oStruct);
                            writeStream.Write(buf);
                            writeStream.Close();
                            writeStream.Dispose();
                            RuntimeHelpers.EnsureSufficientExecutionStack();
                            WriteStructureIndex(oReturn, filename);
                            return;
                        }
                        else if (idStruct == idObject)
                        {
                            achou = true;
                            writeStream.Close();
                            writeStream.Dispose();
                            return;
                        }
                    }

                    if (!achou)
                    {
                        byte[] buf = getBytes(oStruct);
                        writeStream.Position = writeStream.Length + 1;
                        writeStream.Write(buf);
                    }
                }
                writeStream.Close();
                writeStream.Dispose();
            }
            catch (Exception ex)
            {
                writeStream.Close();
                writeStream.Dispose();
                throw ex;
            }
        }

        private byte[] getBytes(object str)
        {
            try
            {
                int size = Marshal.SizeOf(str);
                byte[] arr = new byte[size];

                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(str, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
                Marshal.FreeHGlobal(ptr);
                return arr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
