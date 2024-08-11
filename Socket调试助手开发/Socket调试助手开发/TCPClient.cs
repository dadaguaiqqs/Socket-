using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket调试助手开发
{
    //客户端
    /* 第一步，调用socket（）函数，创建一个连接用的socket
     * 第二部，设置地址，ipaddress，ipendpoint
     * 第三部，调用connect（）函数连接服务器
     * 第四部，读写函数发送接收消息
     * 第五步，断开连接
     * 
     */

    public partial class TCPClient : Form
    {
        public TCPClient()
        {
            InitializeComponent();
            this.Load += TCPClient_Load;
        }



        private Socket socket;
        private void TCPClient_Load(object sender, EventArgs e)
        {
            //动态的宽度
            this.receiveMessage.Columns[1].Width = this.receiveMessage.ClientSize.Width - this.receiveMessage.Columns[0].Width;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(txtIP.Text.Trim());
            IPEndPoint address = new IPEndPoint(ip, int.Parse(txtPort.Text));
            //socket.Bind(address);
            try
            {
                socket.Connect(address);

            }
            catch
            {
                AddLog(2, "连接失败");
                return;
            }
            AddLog(0, "连接成功");



            Task.Run(new Action(() => { reveive_Message(); }));
            //this.btn_Connect.Enabled = false;
        }

        private void reveive_Message()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];
                int length = -1;
                length = socket.Receive(buffer);
                string msg = "";
                if (length > 0)
                {
                    switch (buffer[0])
                    {
                        case 0:
                            msg = Encoding.ASCII.GetString(buffer, 1, length-1);
                            break;
                        case 1:
                            msg = Encoding.UTF8.GetString(buffer, 1, length-1);
                            break;
                        case 2://HEX
                            msg=HexGetString(buffer, 1, length-1);
                            break;
                        case 3://文件

                            var path = txtSavePath.Text;
                            msg = Encoding.UTF8.GetString(buffer, 1, length-1);

                            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                               // byte[] fileBuffer=Encoding.Default.GetBytes(msg);
                                fs.Write(buffer, 1, buffer.Length-1);

                            }
                            break;
                        case 4:
                            break;
                        default:
                            msg = Encoding.Default.GetString(buffer, 1, length - 1);
                            break;


                    }


                    AddLog(0, msg);
                }

            }

        }
        #region 添加日志方法
        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="index"> list 图标索引</param>
        /// <param name="info"> 显示信息</param>

        private void AddLog(int index, string info)
        {
            if (!this.receiveMessage.InvokeRequired)
            {
                ListViewItem lst = new ListViewItem(" " + CurrentTime, index);
                lst.SubItems.Add(info);
                receiveMessage.Items.Insert(receiveMessage.Items.Count, lst);
            }
            else
            {
                Invoke(new Action(() =>
                {
                    ListViewItem lst = new ListViewItem(" " + CurrentTime, index);
                    lst.SubItems.Add(info);
                    receiveMessage.Items.Insert(receiveMessage.Items.Count, lst);
                }));
            }
        }

        #endregion
        /// <summary>
        /// 16进制转换
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string HexGetString(byte[] buffer,int start,int length)
        {
            string Result = string.Empty;
            byte[] res=new byte[length];
            if(buffer != null&&buffer.Length>=start+length)
            {
                Array.Copy(buffer, start, res, 0, length);
                string hex= Encoding.Default.GetString(res);
                if(hex.Contains(" "))
                {
                    string[] str=Regex.Split(hex, "\\s+",RegexOptions.IgnoreCase);
                    foreach(string item in str)
                    {
                        Result += "Ox" + item + " ";
                    }
                }
                else
                {
                    Result += "Ox" + hex;
                }
            }
            else
            {
                 Result="Error";
            }
            return Result;
        }


        private void btn_SendMessage_Click(object sender, EventArgs e)
        {
            if (socket != null)
            {
                socket.Send(Encoding.Default.GetBytes(sendMessage.Text.Trim()));
            }
        }

        private void TCPClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket?.Close();
        }

        private void btn_SendFile_Click(object sender, EventArgs e)
        {

        }

        private void btn_disConnect_Click(object sender, EventArgs e)
        {
            socket?.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            txtSavePath.Text = ofd.FileName;
        }
    }
}
