using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Common.Communication
{
    public class JsonNetworkSerializer
    {
       
        
        //private readonly Socket _socket;
        //private readonly NetworkStream _stream;
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        public JsonNetworkSerializer(NetworkStream stream)
        {
            //_socket = s;
            //_stream = new NetworkStream(_socket);
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream) { AutoFlush = true };
        }
        public void Send(object o) {
            _writer.WriteLine(JsonSerializer.Serialize(o));
        }
        public T Receive<T>() {
            string json = _reader.ReadLine();
            if (json == null)
                throw new IOException("Connection closed by remote host.");
            return JsonSerializer.Deserialize<T>(json);
        }
        public T ReadType<T>(object obj) where T : class{
            return obj == null ? null : JsonSerializer.Deserialize<T>((JsonElement)obj);
        }
        public void Close() {
            _reader.Close();
            _writer.Close();
        }
    }
}
