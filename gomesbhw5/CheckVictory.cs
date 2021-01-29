using System;
using System.Windows.Shapes;

namespace gomesbhw5
{
    internal class CheckVictory
    {
        private MainWindow m;
        
        public CheckVictory(MainWindow mainWindow)
        {
            this.m = mainWindow;
        }

        public void winLogic(Rectangle x)
        {
            if (x.Fill == m.cross)
            {
                if (m.cpuMode)
                {
                    m.winner = "YOU WIN!!!";
                    m.statusLabel.Content = m.winner;
                    m.toggleRects(false);

                }
                else
                {
                    m.winner = "Player 1 WON!!!";
                    m.statusLabel.Content = m.winner;
                    m.toggleRects(false);
                }
            }
            else
            {
                if (m.cpuMode)
                {
                    m.winner = "CPU WIN!!!";
                    m.statusLabel.Content = m.winner;
                    m.toggleRects(false);

                }
                else
                {
                    m.winner = "Player 2 WON!!!";
                    m.statusLabel.Content = m.winner;
                    m.toggleRects(false);
                }
            }
        }

        internal void check()
        {
            //Winning Condition For First Row   
            if ( m.a1.Fill == m.a2.Fill && m.a2.Fill == m.a3.Fill)
            {
                winLogic(m.a1);
            }

            //Winning Condition For Second Row   
            else if (m.b1.Fill == m.b2.Fill && m.b2.Fill == m.b3.Fill)
            {
                winLogic(m.b1);
            }

            //Winning Condition For Third Row   
            else if (m.c1.Fill == m.c2.Fill && m.c2.Fill == m.c3.Fill)
            {
                   winLogic(m.c1);
            }

            //Winning Condition For First Column       
            else if (m.a1.Fill == m.b1.Fill && m.b1.Fill == m.c1.Fill)
            {
                winLogic(m.a1);
            }

            //Winning Condition For Second Column  
            else if (m.a2.Fill == m.b2.Fill && m.b2.Fill == m.c2.Fill)
            {
                winLogic(m.a2);
            }

            //Winning Condition For Third Column  
            else if (m.a3.Fill == m.b3.Fill && m.b3.Fill == m.c3.Fill)
            {
                winLogic(m.a3);
            }

            else if (m.a1.Fill == m.b2.Fill && m.b2.Fill == m.c3.Fill)
            {
                winLogic(m.a1);
            }

            else if (m.a3.Fill == m.b2.Fill && m.b2.Fill == m.c1.Fill)
            {
                winLogic(m.a3);
            }

            // Draw Condition
            else
            {
                // all disabled = draw
                if(m.a1.IsEnabled == false && m.a2.IsEnabled == false && m.a3.IsEnabled == false &&
                   m.b1.IsEnabled == false && m.b2.IsEnabled == false && m.b3.IsEnabled == false &&
                   m.c1.IsEnabled == false && m.c2.IsEnabled == false && m.c3.IsEnabled == false)
                {
                    m.winner = "Bummer...DRAW!!!";
                    m.statusLabel.Content = m.winner;
                    m.tossBtn.IsEnabled = false;
                    m.humanRadioBtn.IsEnabled = true;
                }
                
            }
        }
    }
}