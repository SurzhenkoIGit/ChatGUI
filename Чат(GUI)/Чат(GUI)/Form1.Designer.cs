namespace Чат_GUI_
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txb_chat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.txb_msg = new System.Windows.Forms.TextBox();
            this.txb_userName = new System.Windows.Forms.TextBox();
            this.btn_EnterChat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_chat
            // 
            this.txb_chat.BackColor = System.Drawing.SystemColors.Control;
            this.txb_chat.Enabled = false;
            this.txb_chat.Location = new System.Drawing.Point(15, 161);
            this.txb_chat.Multiline = true;
            this.txb_chat.Name = "txb_chat";
            this.txb_chat.ReadOnly = true;
            this.txb_chat.Size = new System.Drawing.Size(540, 233);
            this.txb_chat.TabIndex = 14;
            this.txb_chat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_chat_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Чат:";
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(462, 411);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(93, 23);
            this.btn_send.TabIndex = 12;
            this.btn_send.Text = "Отправить";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txb_msg
            // 
            this.txb_msg.Enabled = false;
            this.txb_msg.Location = new System.Drawing.Point(15, 413);
            this.txb_msg.Name = "txb_msg";
            this.txb_msg.Size = new System.Drawing.Size(421, 20);
            this.txb_msg.TabIndex = 11;
            this.txb_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_msg_KeyDown);
            // 
            // txb_userName
            // 
            this.txb_userName.Location = new System.Drawing.Point(134, 17);
            this.txb_userName.Name = "txb_userName";
            this.txb_userName.Size = new System.Drawing.Size(137, 20);
            this.txb_userName.TabIndex = 10;
            // 
            // btn_EnterChat
            // 
            this.btn_EnterChat.Location = new System.Drawing.Point(287, 15);
            this.btn_EnterChat.Name = "btn_EnterChat";
            this.btn_EnterChat.Size = new System.Drawing.Size(75, 23);
            this.btn_EnterChat.TabIndex = 9;
            this.btn_EnterChat.Text = "Войти в чат";
            this.btn_EnterChat.UseVisualStyleBackColor = true;
            this.btn_EnterChat.Click += new System.EventHandler(this.btn_EnterChat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите ваше имя";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 450);
            this.Controls.Add(this.txb_chat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txb_msg);
            this.Controls.Add(this.txb_userName);
            this.Controls.Add(this.btn_EnterChat);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_chat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txb_msg;
        private System.Windows.Forms.TextBox txb_userName;
        private System.Windows.Forms.Button btn_EnterChat;
        private System.Windows.Forms.Label label1;
    }
}

