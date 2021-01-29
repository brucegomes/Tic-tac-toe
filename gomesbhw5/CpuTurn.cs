using System;
using System.Windows.Shapes;

namespace gomesbTictactoe
{
    internal class CpuTurn
    {
        private MainWindow m;
        private Random randomGen;
        private readonly Rectangle[] myRects;

        public CpuTurn(MainWindow window)
        {
            this.m = window;
            randomGen = new Random();
            myRects = new Rectangle[9];
            fillRectArray();
        }

        private void fillRectArray()
        {
            
            myRects[0] = m.a1;
            myRects[1] = m.a2;
            myRects[2] = m.a3;
            myRects[3] = m.b1;
            myRects[4] = m.b2;
            myRects[5] = m.b3;
            myRects[6] = m.c1;
            myRects[7] = m.c2;
            myRects[8] = m.c3;
        }

        internal void play()
        {
            Boolean played = false;
            int choice;
            while (played == false)
            {
                choice = randomGen.Next(9);
                if(myRects[choice].IsEnabled == true)
                {
                    myRects[choice].Fill = m.circle;
                    m.statusLabel.Content = "Your Turn";
                    played = true;
                }
            }
        }
    }
}