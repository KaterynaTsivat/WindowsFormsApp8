
using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp8
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
        /// 

        class C_Duck 
        {
            
        
        
        }






        private void InitializeComponent()
        {
            //Написать игру «duck killer». На карте появляются утки, 
            //которые летают по карте, игрок стреляет по ним. За каждое 
            //попадание - добавляются монетки.
            //За монеты можно апгрейдить оружие , покупать другое . 
            //Утки должны иметь разные разновидности.
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "duten pula kuzda meti";

            this.BackColor = Color.AntiqueWhite;
            this.Size = new System.Drawing.Size(700, 700);
            this.StartPosition = FormStartPosition.CenterParent;

            duck_position.X = 350;
            duck_position.Y = 350;
            duck_position.Width = 50;
            duck_position.Height = 50;

            //2D буффер
            this.DoubleBuffered = true;
            //рисовать тут
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.Cursor.Dispose();

            this.Click += Form1_Click;
        }
        Point mouse_location = new Point();
        Rectangle duck_position = new Rectangle();
        bool isAlive = true;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_location.X = e.Location.X;
            mouse_location.Y = e.Location.Y;
            //запустить Paint()
            this.Invalidate();
        }
        Label label = new Label();


        private void Form1_Click(object sender, EventArgs e)
        {
            int xMous = mouse_location.X + 13;
            int yMous = mouse_location.Y + 13;
            label.Location = new Point(xMous, yMous);

            Point pointX = new Point(xMous);
            Point pointY = new Point(yMous);
            List<Point> tocka = new List<Point>();

            label.Size = new Size(4, 4);
            label.BackColor = Color.Black;
            this.Controls.Add(label);

            int x = 0;
            foreach (Point s in tocka)
            {
                x++;
                Label lab = new Label();
                // lab.Location = new Point(pointX, pointY);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Flush();
            GC.Collect();
            if (isAlive)
            {
                if (duck_position.IntersectsWith(
                   new Rectangle(
                       mouse_location,
                       new Size(35, 35)
                       )
               ))
                {
                    //MessageBox.Show("Kill duck!");
                    isAlive = false;
                }
                e.Graphics.DrawImage(Image.FromFile("duck_alive.png"), duck_position);
            }
            else
            {
                e.Graphics.DrawImage(Image.FromFile("duck_killed.png"), duck_position);
            }

            e.Graphics.DrawEllipse(Pens.Red,
                mouse_location.X, mouse_location.Y, 30, 30);
            Thread.Sleep(35);

        }
        #endregion
    }
}

