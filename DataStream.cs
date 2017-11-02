using System;
using System.IO;
using System.Text;

namespace ex0dusStreams {

    public class DataStream : Stream {

        private Stream stream;

        public override bool CanRead { get { return stream.CanRead; } }
        public override bool CanSeek { get { return stream.CanSeek; } }
        public override bool CanWrite { get { return stream.CanWrite; } }
        public override long Length { get { return stream.Length; } }

        public override long Position { get { return stream.Position; }
                                        set { stream.Position = Position; } }

        public DataStream(Stream stream) {

            this.stream = stream;

        }

        public short ReadShort() {

            byte[] bytes = new byte[2];
            Read(bytes, 0, bytes.Length);
            return Convert.ToInt16(bytes);

        }

        public int ReadInt() {

            byte[] bytes = new byte[4];
            Read(bytes, 0, bytes.Length);
            return Convert.ToInt32(bytes);

        }

        public long ReadLong() {

            byte[] bytes = new byte[8];
            Read(bytes, 0, bytes.Length);
            return Convert.ToInt64(bytes);

        }

        public String ReadUTF() {
            
            byte[] bytes = new byte[ReadShort()];
            return Encoding.UTF8.GetString(bytes);

        }

        public void WriteShort(short value) {

            byte[] write = BitConverter.GetBytes(value);
            Write(write);

        }

        public void WriteInt(int value) {

            byte[] write = BitConverter.GetBytes(value);
            Write(write);

        }

        public void WriteLong(long value) {

            byte[] write = BitConverter.GetBytes(value);
            Write(write);

        }

        public void WriteUTF(string value) {

            WriteShort((short) value.Length);
            byte[] write = Encoding.ASCII.GetBytes(value);
            Write(write);

        }

        public override void Close() {

            stream.Close();
            base.Close();

        }

        public override void Flush() {

            stream.Flush();

        }

        public override int Read(byte[] buffer, int offset, int count) {

            return stream.Read(buffer, offset, count);

        }

        public override long Seek(long offset, SeekOrigin origin) {

            return stream.Seek(offset, origin);

        }

        public override void SetLength(long value) {

            stream.SetLength(value);

        }

        public void Write(byte[] buffer) {

            Write(buffer, 0, buffer.Length);

        }

        public override void Write(byte[] buffer, int offset, int count) {

            stream.Write(buffer, offset, count);

        }

    }

}
