namespace segunda_tentativa
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bgConectaArd = new System.ComponentModel.BackgroundWorker();
            this.serialConexao = new System.IO.Ports.SerialPort(this.components);
            this.timerBuscaArd = new System.Windows.Forms.Timer(this.components);
            this.bgPesquisaCartao = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // bgConectaArd
            // 
            this.bgConectaArd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgConectaArd_DoWork);
            // 
            // serialConexao
            // 
            this.serialConexao.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialConexao_DataReceived);
            // 
            // timerBuscaArd
            // 
            this.timerBuscaArd.Interval = 4000;
            this.timerBuscaArd.Tick += new System.EventHandler(this.timerBuscaArd_Tick);
            // 
            // bgPesquisaCartao
            // 
            this.bgPesquisaCartao.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgPesquisaCartao_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgConectaArd;
        private System.IO.Ports.SerialPort serialConexao;
        private System.Windows.Forms.Timer timerBuscaArd;
        private System.ComponentModel.BackgroundWorker bgPesquisaCartao;
    }
}

