using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кривая_Коха
{
    public partial class Form1 : Form
    {
        public int iter = 7; //number of iteration

        public int lengh; // lengh of start line;

        public int recursLengh; //lengh of line after the iteration step;

        public Pen myPen;

        public Graphics graph;

        public Brush br;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        public void Fract(PointF cord1, PointF cord2, PointF cord3, int numberOfIteration)
        {
            if (numberOfIteration >= 0)
            {
                PointF fThirdCord = new PointF((cord2.X + 2 * cord1.X) / 3, (cord2.Y + 2 * cord1.Y) / 3);
                PointF sThirdCord = new PointF((2 * cord2.X + cord1.X) / 3, (2 * cord2.Y + cord1.Y) / 3);

                PointF highPoint = new PointF((cord1.X + cord2.X) / 2, ((cord1.Y + cord2.Y) / 2));
                PointF mainPoint = new PointF((4 * highPoint.X - cord3.X) / 3 , (4 * highPoint.Y - cord3.Y) / 3);

                
               

                graph.DrawLine(myPen, fThirdCord, mainPoint);
                graph.DrawLine(myPen, sThirdCord, mainPoint);
                graph.DrawLine(myPen, fThirdCord, sThirdCord);

                graph.FillPolygon(br, new PointF[] { fThirdCord, sThirdCord, mainPoint });

                Fract(fThirdCord, mainPoint, sThirdCord, numberOfIteration - 1);
                Fract(mainPoint, sThirdCord, fThirdCord, numberOfIteration - 1);

                Fract(cord1, fThirdCord, new PointF((2 * cord1.X + cord3.X) / 3, (2 * cord1.Y + cord3.Y) / 3), numberOfIteration - 1);
                Fract(sThirdCord, cord2, new PointF((2 * cord2.X + cord3.X) / 3, (2 * cord2.Y + cord3.Y) / 3), numberOfIteration - 1);
            }  
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myPen = new Pen(Color.Blue, 1);

            graph = pictureBox1.CreateGraphics();

            br = new SolidBrush(Color.Blue);
            

            PointF first = new PointF(250, 200);

            PointF second = new Point(850, 200);

            PointF third = new PointF(525, 600);



            graph.DrawLine(myPen, first, second);
            graph.DrawLine(myPen, second, third);
            graph.DrawLine(myPen, third, first);

            graph.FillPolygon(br, new PointF[] { first, second, third });

            Fract(first, second, third, iter);

            Fract(second, third, first, iter);

            Fract(third, first, second, iter);

            
        }
    }
}
