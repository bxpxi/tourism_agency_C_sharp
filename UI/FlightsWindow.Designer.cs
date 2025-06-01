using System.ComponentModel;

namespace UI
{
    partial class FlightsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            label5 = new System.Windows.Forms.Label();
            FlightsView = new System.Windows.Forms.DataGridView();
            label6 = new System.Windows.Forms.Label();
            BuyButton = new System.Windows.Forms.Button();
            NoOfSeatsBox = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            ClientNameBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            DatePicker = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            DestinationBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            FilteredFlightsView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FlightsView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FilteredFlightsView).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(FlightsView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(BuyButton);
            splitContainer1.Panel2.Controls.Add(NoOfSeatsBox);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(ClientNameBox);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(DatePicker);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(DestinationBox);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(FilteredFlightsView);
            splitContainer1.Size = new System.Drawing.Size(1641, 482);
            splitContainer1.SplitterDistance = 794;
            splitContainer1.TabIndex = 0;
            splitContainer1.Text = "splitContainer1";
            // 
            // label5
            // 
            label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            label5.Location = new System.Drawing.Point(211, 14);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(177, 36);
            label5.TabIndex = 1;
            label5.Text = "See All Flights";
            // 
            // FlightsView
            // 
            FlightsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FlightsView.Location = new System.Drawing.Point(0, 53);
            FlightsView.Name = "FlightsView";
            FlightsView.RowHeadersWidth = 62;
            FlightsView.Size = new System.Drawing.Size(797, 429);
            FlightsView.TabIndex = 0;
            FlightsView.Text = "dataGridView1";
            FlightsView.CellFormatting += FlightsView_CellFormatting;
            FlightsView.SelectionChanged += FlightsView_SelectionChanged;
            // 
            // label6
            // 
            label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            label6.Location = new System.Drawing.Point(195, 14);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(177, 36);
            label6.TabIndex = 2;
            label6.Text = "Search";
            label6.Click += label6_Click;
            // 
            // BuyButton
            // 
            BuyButton.Location = new System.Drawing.Point(432, 376);
            BuyButton.Name = "BuyButton";
            BuyButton.Size = new System.Drawing.Size(75, 55);
            BuyButton.TabIndex = 9;
            BuyButton.Text = "BUY";
            BuyButton.UseVisualStyleBackColor = true;
            BuyButton.Click += BuyButton_Click;
            // 
            // NoOfSeatsBox
            // 
            NoOfSeatsBox.Location = new System.Drawing.Point(172, 409);
            NoOfSeatsBox.Name = "NoOfSeatsBox";
            NoOfSeatsBox.Size = new System.Drawing.Size(200, 31);
            NoOfSeatsBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(47, 417);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(119, 23);
            label4.TabIndex = 7;
            label4.Text = "No. of seats:";
            // 
            // ClientNameBox
            // 
            ClientNameBox.Location = new System.Drawing.Point(172, 361);
            ClientNameBox.Name = "ClientNameBox";
            ClientNameBox.Size = new System.Drawing.Size(200, 31);
            ClientNameBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(43, 361);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(123, 31);
            label3.TabIndex = 5;
            label3.Text = "Client name:";
            // 
            // DatePicker
            // 
            DatePicker.Location = new System.Drawing.Point(624, 197);
            DatePicker.Name = "DatePicker";
            DatePicker.Size = new System.Drawing.Size(200, 31);
            DatePicker.TabIndex = 4;
            DatePicker.ValueChanged += DatePicker_ValueChanged;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(624, 160);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(100, 23);
            label2.TabIndex = 3;
            label2.Text = "Date:";
            // 
            // DestinationBox
            // 
            DestinationBox.Location = new System.Drawing.Point(624, 101);
            DestinationBox.Name = "DestinationBox";
            DestinationBox.Size = new System.Drawing.Size(185, 31);
            DestinationBox.TabIndex = 2;
            DestinationBox.TextChanged += DestinationBox_TextChanged;
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(624, 62);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(123, 36);
            label1.TabIndex = 1;
            label1.Text = "Destination:";
            // 
            // FilteredFlightsView
            // 
            FilteredFlightsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FilteredFlightsView.Location = new System.Drawing.Point(2, 53);
            FilteredFlightsView.Name = "FilteredFlightsView";
            FilteredFlightsView.RowHeadersWidth = 62;
            FilteredFlightsView.Size = new System.Drawing.Size(607, 278);
            FilteredFlightsView.TabIndex = 0;
            FilteredFlightsView.Text = "FilteredFlightsView";
            FilteredFlightsView.CellFormatting += FilteredFlightsView_CellFormatting;
            FilteredFlightsView.SelectionChanged += FilteredFlightsView_SelectionChanged;
            // 
            // FlightsWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1641, 482);
            Controls.Add(splitContainer1);
            Text = "FlightsWindow";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FlightsView).EndInit();
            ((System.ComponentModel.ISupportInitialize)FilteredFlightsView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ClientNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NoOfSeatsBox;

        private System.Windows.Forms.DateTimePicker DatePicker;

        private System.Windows.Forms.DataGridView FilteredFlightsView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DestinationBox;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView FlightsView;

        #endregion
        }
}