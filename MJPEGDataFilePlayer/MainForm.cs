using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace MJPEGDataFilePlayer
{
    public partial class MainForm : Form
    {
        const string m_titleString = "MJPEG Data File Player";
        string m_targetFilePath = "";
        AnalyseMJPEGDataFile m_analyse = null;
        int m_maxFrameNo = -1;
        int m_nowFrameNo = -1;
        bool m_isPlay = false;
        bool m_isPause = false;
        bool m_isStop = true;
        Thread m_playThread = null;


        public MainForm()
        {
            InitializeComponent();

            this.fpsTextBox.Mask = "99999";
            this.fpsTextBox.ValidatingType = typeof(int);
            this.fpsTextBox.TypeValidationCompleted += fpsTextBox_TypeValidationCompleted;

            this.saveImgtoolTip.SetToolTip(saveImgButton, "Save one frame image.");

            this.pictureBox.AllowDrop = true;
        }

        void fpsTextBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("Please input numeric.");
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = showSelectOpenFileDlg();
            if (filePath != "")
            {
                openFile(filePath);
            }            
        }

        private void openFile(string filePath)
        {
            m_targetFilePath = filePath;
            this.Text = m_titleString + "  [" + m_targetFilePath + "]";

            m_analyse = new AnalyseMJPEGDataFile(m_targetFilePath);
            if (m_analyse.IsEnableData)
            {
                initRadioBtnAndResetStatus(true);
                m_maxFrameNo = m_analyse.MaxFrameCount;
                m_nowFrameNo = 1;
                showImg(m_nowFrameNo);
                initTrackBer(m_analyse.MaxFrameCount);
            }
            else
            {
                MessageBox.Show("File read error.");
            }
        }

        private string showSelectOpenFileDlg()
        {
            string resultFilePath = "";
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                resultFilePath = ofd.FileName;
            }
            return resultFilePath;
        }

        private void showImg(int frameNo)
        {
            byte[] frame = m_analyse.GetJpegFrame(frameNo);
            if (frame.Length > 0)
            {
                Image img = m_analyse.ByteArrayToImage(frame);
                m_analyse.ResizeImage(ref img, this.pictureBox.Width, this.pictureBox.Height);
                pictureBox.Image = img;
                setFrameNoLabel(frameNo, m_maxFrameNo);
                setTrackBarValue(frameNo);
                Application.DoEvents();
            }
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if ((m_analyse == null) || (m_analyse.IsEnableData == false)) return;

            showImg(m_nowFrameNo);
        }

        private void setFrameNoLabel(int nowFrameNo, int maxFrameNo)
        {
            this.frameCountLabel.Text = nowFrameNo.ToString() + " / " + maxFrameNo.ToString();
        }

        private void frameNextButton_Click(object sender, EventArgs e)
        {
            if ((m_analyse == null) || (m_analyse.IsEnableData == false)) return;

            if ((m_nowFrameNo + 1) <= m_analyse.MaxFrameCount)
            {
                m_nowFrameNo += 1;
                showImg(m_nowFrameNo);
            }
        }

        private void framePrevButton_Click(object sender, EventArgs e)
        {
            if ((m_analyse == null) || (m_analyse.IsEnableData == false)) return;

            if (0 < (m_nowFrameNo - 1))
            {
                m_nowFrameNo -= 1;
                showImg(m_nowFrameNo);
            }
        }

        private void initTrackBer(int maxFrameCount)
        {
            this.trackBar.Minimum = 1;
            this.trackBar.Maximum = maxFrameCount;
            this.trackBar.Value = 1;
            this.trackBar.TickFrequency = 10;
            this.trackBar.SmallChange = 1;
            this.trackBar.LargeChange = 10;
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if ((m_analyse == null) || (m_analyse.IsEnableData == false)) return;

            if ((0 < this.trackBar.Value) && (this.trackBar.Value <= m_analyse.MaxFrameCount))
            {
                m_nowFrameNo = this.trackBar.Value;
                showImg(m_nowFrameNo);
            }
        }

        private void setTrackBarValue(int nowFrameNo)
        {
            this.trackBar.Value = nowFrameNo;
        }

        private void initRadioBtnAndResetStatus(bool abortThread)
        {
            this.playRadioButton.Checked = false;
            this.pauseRadioButton.Checked = false;
            this.stopRadioButton.Checked = true;
            m_isPlay = false;
            m_isPause = false;
            m_isStop = true;

            if (abortThread && (m_playThread != null) && m_playThread.IsAlive)
            {
                m_playThread.Abort();
            }
        }

        private void playRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool isPlay = this.playRadioButton.Checked;
            bool isPause = this.pauseRadioButton.Checked;
            bool isStop = this.stopRadioButton.Checked;

            if (isPlay && !m_isPlay)
            {
                m_isPause = false;
                m_isStop = false;
                m_isPlay = true;

                m_playThread = new Thread(new ThreadStart(playMJPEG));
                m_playThread.Start();
            }
            else if (isPause || isStop)
            {
                if (m_isPause && isStop)
                {
                    initTrackBer(m_analyse.MaxFrameCount);
                }
                m_isPlay = isPlay;
                m_isPause = isPause;
                m_isStop = isStop;
            }
        }

        private void playMJPEG()
        {
            if ((m_analyse == null) || (m_analyse.IsEnableData == false)) return;

            for (; m_nowFrameNo <= m_analyse.MaxFrameCount; m_nowFrameNo++)
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                this.Invoke((Action)(() =>
                {
                    showImg(m_nowFrameNo);
                }));
                sw.Stop();

                double waitMillisec = 30;
                int fps;
                if (int.TryParse(this.fpsTextBox.Text, out fps))
                {
                    waitMillisec = ((double)1 / (double)fps) * 1000;
                }
                waitMillisec = waitMillisec - sw.ElapsedMilliseconds;
                if (waitMillisec > 0)
                {
                    System.Threading.Thread.Sleep((int)waitMillisec);
                }

                if (m_nowFrameNo == m_analyse.MaxFrameCount)
                {
                    this.Invoke((Action)(() =>
                    {
                        initRadioBtnAndResetStatus(false);
                    }));
                    break;
                }
                else if (m_isStop)
                {
                    this.Invoke((Action)(() =>
                    {
                        initRadioBtnAndResetStatus(false);
                        initTrackBer(m_analyse.MaxFrameCount);
                    }));
                    break;
                }
                else if (m_isPause)
                {
                    break;
                }
            }

            if (m_analyse.MaxFrameCount < m_nowFrameNo)
            {
                m_nowFrameNo = m_analyse.MaxFrameCount;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            initRadioBtnAndResetStatus(true);
        }

        private void saveImgButton_Click(object sender, EventArgs e)
        {
            if ((m_analyse == null) || (m_analyse.IsEnableData == false)) return;

            byte[] frame = m_analyse.GetJpegFrame(m_nowFrameNo);
            if (frame.Length > 0)
            {
                string filePath = showSelectSaveFileDlg();
                if (filePath != "")
                {
                    Image img = m_analyse.ByteArrayToImage(frame);
                    img.Save(filePath);
                }
            }
        }

        private string showSelectSaveFileDlg()
        {
            string resultFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog();

            //sfd.FileName = "test.jpg";
            //sfd.InitialDirectory = @"C:\";
            sfd.Filter = "jpg(*.jpg)|*.jpg;|All File(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                resultFilePath = sfd.FileName;
            }
            return resultFilePath;
        }

        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            openFile(filePath);
        }

    }
}
