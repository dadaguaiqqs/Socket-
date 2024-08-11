namespace Socket调试助手开发
{
    partial class TCPClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCPClient));
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_disConnect = new System.Windows.Forms.Button();
            this.btn_SendFile = new System.Windows.Forms.Button();
            this.btn_SendMessage = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.severAddress = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.fileText = new System.Windows.Forms.TextBox();
            this.sendMessage = new System.Windows.Forms.TextBox();
            this.receiveMessage = new System.Windows.Forms.ListView();
            this.infoTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(899, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "TCP客户端";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 69);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtSavePath);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btn_disConnect);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SendFile);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SendMessage);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Connect);
            this.splitContainer1.Panel1.Controls.Add(this.txtPort);
            this.splitContainer1.Panel1.Controls.Add(this.port);
            this.splitContainer1.Panel1.Controls.Add(this.txtIP);
            this.splitContainer1.Panel1.Controls.Add(this.severAddress);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.fileText);
            this.splitContainer1.Panel2.Controls.Add(this.sendMessage);
            this.splitContainer1.Panel2.Controls.Add(this.receiveMessage);
            this.splitContainer1.Size = new System.Drawing.Size(900, 478);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 21);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "庄子";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(18, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "用户名称";
            // 
            // btn_disConnect
            // 
            this.btn_disConnect.Location = new System.Drawing.Point(146, 287);
            this.btn_disConnect.Name = "btn_disConnect";
            this.btn_disConnect.Size = new System.Drawing.Size(75, 23);
            this.btn_disConnect.TabIndex = 4;
            this.btn_disConnect.Text = "断开连接";
            this.btn_disConnect.UseVisualStyleBackColor = true;
            this.btn_disConnect.Click += new System.EventHandler(this.btn_disConnect_Click);
            // 
            // btn_SendFile
            // 
            this.btn_SendFile.Location = new System.Drawing.Point(42, 287);
            this.btn_SendFile.Name = "btn_SendFile";
            this.btn_SendFile.Size = new System.Drawing.Size(75, 23);
            this.btn_SendFile.TabIndex = 4;
            this.btn_SendFile.Text = "发送文件";
            this.btn_SendFile.UseVisualStyleBackColor = true;
            this.btn_SendFile.Click += new System.EventHandler(this.btn_SendFile_Click);
            // 
            // btn_SendMessage
            // 
            this.btn_SendMessage.Location = new System.Drawing.Point(146, 244);
            this.btn_SendMessage.Name = "btn_SendMessage";
            this.btn_SendMessage.Size = new System.Drawing.Size(75, 23);
            this.btn_SendMessage.TabIndex = 4;
            this.btn_SendMessage.Text = "发送消息";
            this.btn_SendMessage.UseVisualStyleBackColor = true;
            this.btn_SendMessage.Click += new System.EventHandler(this.btn_SendMessage_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(42, 244);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 4;
            this.btn_Connect.Text = "连接服务器";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(101, 50);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(153, 21);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "5000";
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.port.ForeColor = System.Drawing.Color.Coral;
            this.port.Location = new System.Drawing.Point(17, 51);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(77, 14);
            this.port.TabIndex = 2;
            this.port.Text = "服务器端口";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(101, 14);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(153, 21);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "192.168.153.80";
            // 
            // severAddress
            // 
            this.severAddress.AutoSize = true;
            this.severAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.severAddress.ForeColor = System.Drawing.Color.Coral;
            this.severAddress.Location = new System.Drawing.Point(18, 15);
            this.severAddress.Name = "severAddress";
            this.severAddress.Size = new System.Drawing.Size(63, 14);
            this.severAddress.TabIndex = 0;
            this.severAddress.Text = "服务器IP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "选择文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileText
            // 
            this.fileText.Location = new System.Drawing.Point(4, 425);
            this.fileText.Name = "fileText";
            this.fileText.Size = new System.Drawing.Size(459, 21);
            this.fileText.TabIndex = 2;
            // 
            // sendMessage
            // 
            this.sendMessage.Location = new System.Drawing.Point(4, 283);
            this.sendMessage.Multiline = true;
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(585, 114);
            this.sendMessage.TabIndex = 1;
            // 
            // receiveMessage
            // 
            this.receiveMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.infoTime,
            this.info});
            this.receiveMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.receiveMessage.HideSelection = false;
            this.receiveMessage.Location = new System.Drawing.Point(4, 4);
            this.receiveMessage.Name = "receiveMessage";
            this.receiveMessage.Size = new System.Drawing.Size(585, 263);
            this.receiveMessage.SmallImageList = this.imageList1;
            this.receiveMessage.TabIndex = 0;
            this.receiveMessage.UseCompatibleStateImageBehavior = false;
            this.receiveMessage.View = System.Windows.Forms.View.Details;
            // 
            // infoTime
            // 
            this.infoTime.Width = 180;
            // 
            // info
            // 
            this.info.Width = 180;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "receive.ico");
            this.imageList1.Images.SetKeyName(1, "warning.ico");
            this.imageList1.Images.SetKeyName(2, "error.ico");
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(21, 155);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(265, 21);
            this.txtSavePath.TabIndex = 7;
            this.txtSavePath.Text = "C:\\Users\\sinso\\Desktop\\1234.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(18, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "接受文件位置";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "选择文件保存位置";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TCPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 548);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCPClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于Socket实现通信测试开发";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPClient_FormClosing);
            this.Load += new System.EventHandler(this.TCPClient_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fileText;
        private System.Windows.Forms.TextBox sendMessage;
        private System.Windows.Forms.ListView receiveMessage;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label severAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label port;
        private System.Windows.Forms.Button btn_disConnect;
        private System.Windows.Forms.Button btn_SendFile;
        private System.Windows.Forms.Button btn_SendMessage;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader infoTime;
        private System.Windows.Forms.ColumnHeader info;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button button2;
    }
}

