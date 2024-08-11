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
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket调试助手开发
{
    public enum MessageType
    {
        ASCII,
        UTF8,
        Hex,
        File,
        JSON
    }
    public partial class Sever : Form
    {
        public Sever()
        {
            InitializeComponent();
        }
        private Socket socket;
        //存放客户ip和对应的socket对象
        private Dictionary<string, Socket> clientList = new Dictionary<string, Socket>();
        private void Sever_Load(object sender, EventArgs e)
        {
            //动态的宽度
            this.receiveMessage.Columns[1].Width = this.receiveMessage.ClientSize.Width - this.receiveMessage.Columns[0].Width;
            cbo_MsgType.DataSource = System.Enum.GetNames(typeof(MessageType));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //创建socket对象
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //获取ip
            IPAddress ip = IPAddress.Parse(txtIP.Text.Trim());
            //拼接地址ip+端口号
            IPEndPoint address = new IPEndPoint(ip, int.Parse(txtPort.Text));
            //绑定这个地址
            try
            {
                socket.Bind(address);

            }
            catch (Exception ex)
            {
                // receiveMessage.Text = "绑定失败";
                AddLog(2, "服务器开启失败");
            }
            //监听，参数是
            socket.Listen(2);

            Task.Run(new Action(() => CheckListening()));
            AddLog(0, "服务器开启成功");

            this.btnStart.Enabled = false;
        }

        private void CheckListening()
        {
            while (true)
            {
                //用来连接的socket
                var ClientAccept = socket.Accept();

                string client = ClientAccept.RemoteEndPoint.ToString();
                AddLog(0, client + "连接成功");
                UpdateOnline(client, true);
                clientList.Add(client, ClientAccept);
                //接受消息
                Task.Run(() => ReceiveMassage(ClientAccept));

            }
        }

        private void ReceiveMassage(Socket clientAccept)
        {
            while (true)
            {
                //创建一个字节数组
                byte[] buffer = new byte[1024];
                int length = -1;
                string client = clientAccept.RemoteEndPoint.ToString();
                //接受消息存入缓冲区，返回接受数据的字节数
                try
                {
                    length = clientAccept.Receive(buffer);
                }
                catch
                {

                    UpdateOnline(client, false);
                    AddLog(2, client + "断开连接");
                    clientList.Remove(client);
                    break;
                }
                if (length > 0)
                {
                    //处理数据
                    string msg = Encoding.Default.GetString(buffer, 0, length);
                    AddLog(0, client + ":" + msg);

                }
                else
                {

                    UpdateOnline(client, false);
                    AddLog(2, client + "断开连接");
                    clientList.Remove(client);
                    break;
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



        //在线列表的更新
        private void UpdateOnline(string client, bool operate)
        {
            if (!this.listOnline.InvokeRequired)
            {
                if (operate)
                {
                    this.listOnline.Items.Add(client);
                }
                else
                {
                    foreach (string item in this.listOnline.Items)
                    {
                        if (item == client)
                        {
                            this.listOnline.Items.Remove(item);
                            break;
                        }
                    }

                }
            }
            else
            {
                Invoke(new Action(() =>
                {
                    if (operate)
                    {
                        this.listOnline.Items.Add(client);
                    }
                    else
                    {
                        foreach (string item in this.listOnline.Items)
                        {
                            if (item == client)
                            {
                                this.listOnline.Items.Remove(item);
                                break;
                            }
                        }

                    }
                }));
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            //
            if (this.listOnline.SelectedItem != null)
            {
                string client = this.listOnline.SelectedItem.ToString();
                byte[] Massage = SelectMsg();

                clientList[client].Send(Massage);

            }
            else
            {
                MessageBox.Show("请选择发送客户端对象");
            }
        }

        private byte[] SelectMsg()
        {
            byte[] Massage = new byte[] { };
            switch (cbo_MsgType.SelectedIndex)
            {

                case 0:
                    byte[] ASCIImsg = Encoding.ASCII.GetBytes(this.sendMessage.Text.Trim());
                    var ASCIIlist = ASCIImsg.ToList();
                    ASCIIlist.Insert(0, 0);

                    Massage = ASCIIlist.ToArray();

                    break;
                case 1:

                    byte[] msg = Encoding.Default.GetBytes(this.sendMessage.Text.Trim());
                    var list = msg.ToList();
                    list.Insert(0, 1);
                    Massage = list.ToArray();

                    break;
                case 2:
                    byte[] Hexmsg = Encoding.Default.GetBytes(this.sendMessage.Text.Trim());
                    byte[] sendmsg = new byte[Hexmsg.Length + 1];
                    Array.Copy(Hexmsg, 0, sendmsg, 1, Hexmsg.Length);
                    sendmsg[0] = 2;
                    Massage = sendmsg;
                    break;
                //文件
                case 3:
                    string client = this.listOnline.SelectedItem.ToString();
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Title = "请选择文件";
                    ofd.ShowDialog();
                    fileText.Text = ofd.FileName;
                    string filename = Path.GetFileName(fileText.Text);
                    // filename = '1' + filename;


                    //发送文件名
                    byte[] MassageFileName = Encoding.UTF8.GetBytes("文件名："+filename);
                    var list1 = MassageFileName.ToList();
                    list1.Insert(0, 1);
                    var MassageFileName1 = list1.ToArray();
                    clientList[client].Send(MassageFileName1);




                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        byte[] buffer = new byte[1024];
                        while (true)
                        {
                            int i = fs.Read(buffer, 0, buffer.Length);
                            //string str=Encoding.Default.GetString(buffer);

                            // var send= Encoding.Default.GetBytes(str);
                            var Massage1 = new byte[buffer.Length + 1];
                            Array.Copy(buffer, 0, Massage1, 1, buffer.Length);
                            Massage = Massage1;
                            if (i == 0)
                            {
                                break;
                            }

                        }


                    }

                    Massage[0] = (byte)MessageType.File;
                    break;
                case 4:
                    break;
            }

            return Massage;
        }






        private void btnSendMany_Click(object sender, EventArgs e)
        {
            if (listOnline.SelectedItems.Count > 0)
            {
                foreach (string item in listOnline.SelectedItems)
                {
                    clientList[item].Send(Encoding.Default.GetBytes(this.sendMessage.Text.Trim()));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCPClient client = new TCPClient();
            client.Show();
        }
    }
}
