using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GAME
{
    /// <summary>
    /// Interaction logic for display2.xaml
    /// </summary>
    public partial class display2 : Page
    {
        public display2()
        {
            InitializeComponent();
        }

        int status = 1;
        int statusbot = 1;
        int gameTime = 60;
        bool keyD = false;
        bool keyA = false;
        bool keyQ = false;
        bool keySpace = false;
        bool playerskillstatus = false;

        public static string name = "";

        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerBot = new DispatcherTimer();
        DispatcherTimer timergame = new DispatcherTimer();
        DispatcherTimer timerplayerskill = new DispatcherTimer();


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
            playerName.Content = name;
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();

           
            timerBot.Tick += new EventHandler(dispatTickBot);
            timerBot.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timerBot.Start();

            
            timergame.Tick += new EventHandler(dispatTickgame);
            timergame.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timergame.Start();
            
            timerplayerskill.Tick += new EventHandler(dispatTickplayerskill);
            timerplayerskill.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timerplayerskill.Start();
        }

        int Roundplayerskill = 1;
        private void dispatTickplayerskill(object sender, EventArgs e)
        {
            if (PlayerMP2.Value >= 70 && playerskillstatus == true)
            {
                Canvas.SetLeft(playerskill2, Canvas.GetLeft(Player2));
                if (Roundplayerskill <= 11)
                {
                    playerskill2.Source = new BitmapImage(new Uri(@"\res\Playerskill\playerskillQ" + Roundplayerskill + ".png", UriKind.Relative));
                    Roundplayerskill++;
                    double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot2) - Canvas.GetTop(Player2), 2) + Math.Pow(Canvas.GetLeft(bot2) - Canvas.GetLeft(Player2), 2));
                    if (d < 90)
                    {
                        botHP2.Value -= 5;
                        effectAttack.Play();
                        effectAttack.Stop();
                    }
                }
                else
                {
                    playerskillstatus = false;
                    PlayerMP2.Value -= 70; // playerMP-70;
                    Canvas.SetLeft(playerskill2, 1000);
                }
            }
        }

        private void dispatTickgame(object sender, EventArgs e)
        {
            
            if (gameTime > 0)
            {
                txtTime.Content = gameTime;
                gameTime--;
            }
            else {
                MessageBox.Show("หมดเวลา");
            }
            PlayerMP2.Value += 5;
        }

        private void dispatTickBot(object sender, EventArgs e)
        {
            Canvas.SetLeft(fireEffect, Canvas.GetLeft(bot2) +1000);
            Canvas.SetLeft(fireEffect, Canvas.GetLeft(Player2) +1000);
            if (statusbot == 1)
            {
                bot2.Source = new BitmapImage(new Uri(@"\res\M22.png", UriKind.Relative));
                statusbot = 2;
            }
            else if (statusbot == 2)
            {
                bot2.Source = new BitmapImage(new Uri(@"\res\MM23.png", UriKind.Relative));
                statusbot = 3;
            }
            else if (statusbot == 3)
            {
                bot2.Source = new BitmapImage(new Uri(@"\res\M21.png", UriKind.Relative));
                statusbot = 1;
                effectAttack.Stop();
            }
           
            //การตีมอนเตอร์
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot2) - Canvas.GetTop(Player2), 2) + Math.Pow(Canvas.GetLeft(bot2) - Canvas.GetLeft(Player2), 2));
            debugTxt.Content = d;
            if (d < 70)
            {
                if (keySpace == true)
                {
                    botHP2.Value = botHP2.Value - 10;
                    if(Canvas.GetLeft(bot2)+55 <= 650)
                    {
                        Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) + 55);
                        Canvas.SetLeft(fireEffect, Canvas.GetLeft(bot2) + 50);
                    }
                    else
                    {
                        Canvas.SetLeft(fireEffect, Canvas.GetLeft(bot2));
                    }
                }
                else 
                {
                    PlayerHP2.Value = PlayerHP2.Value - 15;
                    if (Canvas.GetLeft(Player2) - 55 >= 0)
                    {
                        Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) - 55);
                        Canvas.SetLeft(fireEffect, Canvas.GetLeft(Player2) -53);
                    }
                    else
                    {
                        Canvas.SetLeft(fireEffect, Canvas.GetLeft(Player2));
                    }
                    
                }
                effectAttack.Play();
                if (PlayerHP2.Value <= 0)
                {
                    result.textResult = "คุณแพ้แล้ว!";
                    timer.Stop();
                    timerBot.Stop();
                    timergame.Stop();
                    timerplayerskill.Stop();
                    this.NavigationService.Navigate(new Uri("result.xaml", UriKind.RelativeOrAbsolute));
                }
                else if (botHP2.Value <= 0)
                {
                    result.textResult = "คุณชนะแล้ว!";
                    timer.Stop();
                    timerBot.Stop();
                    timergame.Stop();
                    timerplayerskill.Stop();
                    this.NavigationService.Navigate(new Uri("result.xaml", UriKind.RelativeOrAbsolute));
                }
            }
            //bot function
            Random rnd = new Random();
            if(rnd.Next(10)>= 8 && Canvas.GetLeft(bot2) <= 650 && Canvas.GetLeft(bot2) >= Canvas.GetLeft(Player2)) //ไปด้านขวา
            {
                Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) + 20);
            }
            else if(Canvas.GetLeft(bot2) >= Canvas.GetLeft(Player2)) //ไปด้านซ้าย
            {
                Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 20);
            }
        }
    

  

        private void dispatTick(object sender, EventArgs e)
        {
            effectPlayer.Stop();
            string temp = "";
            if (keyD == true)
            {
                temp = "next";
            }
            else if (keyA == true)
            {
                temp = "moveback";
            }
            else if (keySpace == true)
            {
                temp = "attack";
                effectPlayer.Play();
            }
            
            //ยืนอยู่เฉยๆ แต่ขยับ
            if(status==1)
            {
                Player2.Source = new BitmapImage(new Uri(@"\res\"+temp+"2.png", UriKind.Relative));
                status = 2;
            }
            else if(status == 2)
            {
                Player2.Source = new BitmapImage(new Uri(@"\res\" + temp + "3.png", UriKind.Relative));
                status = 3;
            }
            else if (status == 3)
            {
                Player2.Source = new BitmapImage(new Uri(@"\res\" + temp + "4.png", UriKind.Relative));
                status = 4;
            }
            else if (status == 4)
            {
                Player2.Source = new BitmapImage(new Uri(@"\res\" + temp + "1.png", UriKind.Relative));
                status = 1;
            }
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D && Canvas.GetLeft(Player2) <= 680)
            {
                Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) + 20);
                keyD = true;
            }
            else if (e.Key == Key.A && Canvas.GetLeft(Player2) >= 0)
            {
                Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) - 20);
                keyA = true;
            }
            else if (e.Key == Key.Space)
            {
                keySpace = true;
            }
            else if (e.Key == Key.Q)
            {
                keySpace = true;
                keyQ = true;
                playerskillstatus = true;
            }
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
           
                keyD = false;
            }
            else if (e.Key == Key.A)
            {
               
                keyA = false;
            }
            else if (e.Key == Key.Space)
            {
                keySpace = false;
            }
            else if (e.Key == Key.Q)
            {
                keySpace = false;
                keyQ = false;
            }
        }
    }
}
