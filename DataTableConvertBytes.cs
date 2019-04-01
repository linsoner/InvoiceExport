using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BaiwangExport
{
    public class DataTableConvertBytes
    {
        public static void SaveToFile(byte[] value, string filePath)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate))
            {
                fs.Write(value, 0, value.Length);
                fs.Flush();
                fs.Close();
            }
        }

        public static byte[] GetBytesFromFile(string filePath)
        {
            System.IO.Stream theStream = null;
            System.IO.MemoryStream tempStream = null;
            try
            {
                theStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                int b1;
                tempStream = new System.IO.MemoryStream();
                while ((b1 = theStream.ReadByte()) != -1)
                {
                    tempStream.WriteByte(((byte)b1));
                }
                return tempStream.ToArray();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if (theStream != null)
                    theStream.Close();
                if (tempStream != null)
                    tempStream.Close();
            }

            return null;
        }
        public static byte[] ConvertDataTableToBytes(DataTable dt)
        {
            byte[] bArrayResult = null; //用于存放序列化后的数据
            dt.RemotingFormat = SerializationFormat.Binary; //指定DataSet串行化格式是二进制
            MemoryStream ms = new MemoryStream();//定义内存流对象，用来存放DataSet序列化后的值
            IFormatter IF = new BinaryFormatter();//产生二进制序列化格式
            IF.Serialize(ms, dt);//串行化到内存中
            bArrayResult = ms.ToArray(); // 将DataSet转化成byte[]
            ms.Close();
            ms.Dispose();
            return bArrayResult;
        }

        public static DataTable ConvertBytesToDataTable(byte[] binaryData)
        {
            MemoryStream ms = new MemoryStream(binaryData);//创建内存流
            IFormatter bf = new BinaryFormatter();//产生二进制序列化格式
            object obj = bf.Deserialize(ms);//反串行化到内存中
                                            //类型检验
            ms.Close();
            if (obj is DataTable)
            {
                DataTable dataSetResult = (DataTable)obj;
                return dataSetResult;
            }
            else
            {
                return null;
            }
        }
    }
}
