using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace MJPEGDataFilePlayer
{
    class AnalyseMJPEGDataFile
    {
        static ImageConverter imgconv = new ImageConverter();
        string m_targetFilePath = "";
        Tuple<long, long>[] m_soiEoiIndexInfo;

        public bool IsEnableData
        {
            get { return (m_soiEoiIndexInfo.Length > 0); }
        }

        public int MaxFrameCount
        {
            get { return m_soiEoiIndexInfo.Length; }
        }

        public AnalyseMJPEGDataFile(string filePath)
        {
            m_targetFilePath = filePath;
            m_soiEoiIndexInfo = getSoiEoiIndexArray();
        }

        private Tuple<long, long>[] getSoiEoiIndexArray()
        {
            var list = new List<Tuple<long, long>>();

            const int maxBuffSize = 100000000;
            byte[] buff = new byte[maxBuffSize];

            using (FileStream fs = new FileStream(m_targetFilePath, FileMode.Open, FileAccess.Read))
            {
                int remain = (int)fs.Length;
                int readCount = 0;
                long startSoiIndex = -1;

                while (remain > 0)
                {
                    int readSize = fs.Read(buff, 0, Math.Min(maxBuffSize, remain));

                    list.AddRange(getSoiEoiIndexArray(buff, Math.Min(maxBuffSize, remain), readCount, ref startSoiIndex));

                    readCount += readSize;
                    remain -= readSize;
                }
            }

            return list.ToArray();
        }

        private Tuple<long, long>[] getSoiEoiIndexArray(byte[] buff, int maxdataLen, int indexOffset, ref long startSoiIndex)
        {
            var list = new List<Tuple<long, long>>();
            long soiIndex = startSoiIndex;
            long eoiIndex = -1;
            byte beforeData = 0x00;

            for (int i = 0; i < maxdataLen; i++)
            {
                byte data = buff[i];

                // SOI (Start of Image) : 0xFFD8
                bool isSOI = ((beforeData == 0xFF) && (data == 0xD8));
                // EOI (End of Image) : 0xFFD9
                bool isEOI = ((beforeData == 0xFF) && (data == 0xD9));

                if (isSOI)
                {
                    soiIndex = (i - 1) + indexOffset;
                }
                else if (isEOI)
                {
                    eoiIndex = (i - 1) + indexOffset;
                    list.Add(new Tuple<long, long>(soiIndex, eoiIndex));
                    soiIndex = -1;
                    eoiIndex = -1;
                }
                beforeData = data;
            }
            startSoiIndex = soiIndex;

            return list.ToArray();
        }

        public byte[] GetJpegFrame(int frameNo)
        {
            if (m_soiEoiIndexInfo.Length <= (frameNo - 1)) return new byte[0];

            long soiIndex = m_soiEoiIndexInfo[frameNo - 1].Item1;
            long eoiIndex = m_soiEoiIndexInfo[frameNo - 1].Item2;
            long size = eoiIndex - soiIndex + 1;

            byte[] buff = new byte[size];

            using (FileStream fs = new FileStream(m_targetFilePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    fs.Seek(soiIndex, SeekOrigin.Begin);
                    int readSize = fs.Read(buff, 0, buff.Length);
                }
                catch { }
            }
            return buff;
        }

        public Image ByteArrayToImage(byte[] b)
        {
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        public void ResizeImage(ref Image image, int width, int height)
        {
            float scale = Math.Min((float)width / (float)image.Width, (float)height / (float)image.Height);
            int widthToScale = (int)(image.Width * scale);
            int heightToScale = (int)(image.Height * scale);

            using (Bitmap bitmap = new Bitmap(width, height))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                SolidBrush solidBrush = new SolidBrush(Color.DimGray);
                graphics.FillRectangle(solidBrush, new RectangleF(0, 0, width, height));
                graphics.DrawImage(image, 0, 0, widthToScale, heightToScale);

                image =(Image)bitmap.Clone();
            }
        }
    }
}
