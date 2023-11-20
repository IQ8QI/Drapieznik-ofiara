namespace Drapieznik_ofiara
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_exit_program = new Button();
            button_start_simulation = new Button();
            button_stop_simulation = new Button();
            pictureBox1 = new PictureBox();
            button_reset_simulation = new Button();
            hunt_success = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            prey_success = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hunt_success).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prey_success).BeginInit();
            SuspendLayout();
            // 
            // button_exit_program
            // 
            button_exit_program.Location = new Point(12, 393);
            button_exit_program.Name = "button_exit_program";
            button_exit_program.Size = new Size(155, 45);
            button_exit_program.TabIndex = 2;
            button_exit_program.Text = "Exit Program";
            button_exit_program.UseVisualStyleBackColor = true;
            button_exit_program.Click += exit_program_click;
            // 
            // button_start_simulation
            // 
            button_start_simulation.Location = new Point(12, 12);
            button_start_simulation.Name = "button_start_simulation";
            button_start_simulation.Size = new Size(155, 45);
            button_start_simulation.TabIndex = 3;
            button_start_simulation.Text = "Start Simulation";
            button_start_simulation.UseVisualStyleBackColor = true;
            button_start_simulation.Click += start_simulation_click;
            // 
            // button_stop_simulation
            // 
            button_stop_simulation.Location = new Point(12, 63);
            button_stop_simulation.Name = "button_stop_simulation";
            button_stop_simulation.Size = new Size(155, 45);
            button_stop_simulation.TabIndex = 4;
            button_stop_simulation.Text = "Stop Simulation";
            button_stop_simulation.UseVisualStyleBackColor = true;
            button_stop_simulation.Click += stop_simulation_click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(173, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1063, 619);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // button_reset_simulation
            // 
            button_reset_simulation.Location = new Point(12, 114);
            button_reset_simulation.Name = "button_reset_simulation";
            button_reset_simulation.Size = new Size(155, 45);
            button_reset_simulation.TabIndex = 6;
            button_reset_simulation.Text = "Reset Simulation";
            button_reset_simulation.UseVisualStyleBackColor = true;
            button_reset_simulation.Click += reset_simulation_click;
            // 
            // hunt_success
            // 
            hunt_success.Location = new Point(12, 180);
            hunt_success.Maximum = 20;
            hunt_success.Name = "hunt_success";
            hunt_success.Size = new Size(155, 45);
            hunt_success.TabIndex = 7;
            hunt_success.Value = 10;
            hunt_success.ValueChanged += predator_success_changed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 162);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 8;
            label1.Text = "Predator success rate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 210);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 10;
            label2.Text = "Prey success rate";
            // 
            // prey_success
            // 
            prey_success.Location = new Point(12, 228);
            prey_success.Maximum = 20;
            prey_success.Name = "prey_success";
            prey_success.Size = new Size(155, 45);
            prey_success.TabIndex = 9;
            prey_success.Value = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 643);
            Controls.Add(label2);
            Controls.Add(prey_success);
            Controls.Add(label1);
            Controls.Add(hunt_success);
            Controls.Add(button_reset_simulation);
            Controls.Add(pictureBox1);
            Controls.Add(button_stop_simulation);
            Controls.Add(button_start_simulation);
            Controls.Add(button_exit_program);
            Name = "Form1";
            Text = "Main Simulation window";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)hunt_success).EndInit();
            ((System.ComponentModel.ISupportInitialize)prey_success).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button_exit_program;
        private Button button_start_simulation;
        private Button button_stop_simulation;
        private PictureBox pictureBox1;
        private Button button_reset_simulation;
        private TrackBar hunt_success;
        private Label label1;
        private Label label2;
        private TrackBar prey_success;
    }
}