﻿using System;
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
    /// Interaction logic for display.xaml
    /// </summary>
    public partial class display3 : Page
    {
        public display3()
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
            if (PlayerMP3.Value >= 70 && playerskillstatus == true)
            {
                Canvas.SetLeft(playerskill3, Canvas.GetLeft(Player3));
                if (Roundplayerskill <= 11)
                {
                    playerskill3.Source = new BitmapImage(new Uri(@"\res\Playerskill\playerskillQ" + Roundplayerskill + ".png", UriKind.Relative));
                    Roundplayerskill++;
                    double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot3) - Canvas.GetTop(Player3), 2) + Math.Pow(Canvas.GetLeft(bot3) - Canvas.GetLeft(Player3), 2));
                    if (d < 90)
                    {
                        botHP3.Value -= 5;
                        effectAttack.Play();
                        effectAttack.Stop();
                    }
                }
                else
                {
                    playerskillstatus = false;
                    PlayerMP3.Value -= 70; // playerMP-70;
                    Canvas.SetLeft(playerskill3, 1000);
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
            PlayerMP3.Value += 5;
        }

        private void dispatTickBot(object sender, EventArgs e)
        {
            Canvas.SetLeft(fireEffect, Canvas.GetLeft(bot3) +1000);
            Canvas.SetLeft(fireEffect, Canvas.GetLeft(Player3) +1000);
            if (statusbot == 1)
            {
                bot3.Source = new BitmapImage(new Uri(@"\res\bot2.png", UriKind.Relative));
                statusbot = 2;
            }
            else if (statusbot == 2)
            {
                bot3.Source = new BitmapImage(new Uri(@"\res\bot3.png", UriKind.Relative));
                statusbot = 3;
            }
            else if (statusbot == 3)
            {
                bot3.Source = new BitmapImage(new Uri(@"\res\bot4.png", UriKind.Relative));
                statusbot = 4;
                effectAttack.Stop();
            }
            else if (statusbot == 4)
            {
                bot3.Source = new BitmapImage(new Uri(@"\res\bot1.png", UriKind.Relative));
                statusbot = 1;
            }
            //การตีมอนเตอร์
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot3) - Canvas.GetTop(Player3), 2) + Math.Pow(Canvas.GetLeft(bot3) - Canvas.GetLeft(Player3), 2));
            debugTxt.Content = d;
            if (d < 70)
            {
                if (keySpace == true)
                {
                    botHP3.Value = botHP3.Value - 10;
                    if(Canvas.GetLeft(bot3)+55 <= 650)
                    {
                        Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) + 55);
                        Canvas.SetLeft(fireEffect, Canvas.GetLeft(bot3) + 50);
                    }
                    else
                    {
                        Canvas.SetLeft(fireEffect, Canvas.GetLeft(bot3));
                    }
                }
                else 
                {
                    PlayerHP3.Value = PlayerHP3.Value - 15;
                    if (Canvas.GetLeft(Player3) - 55 >= 0)
                    {
                        Canvas.SetLeft(Player3, Canvas.GetLeft(Player3) - 55);
                        Canvas.SetLeft(fireEffect, Canvas.GetLeft(Player3) -53);
                    }
                    else
                    {
                        Canvas.SetLeft(fireEffect, Canvas.GetLeft(Player3));
                    }
                    
                }
                effectAttack.Play();
                if (PlayerHP3.Value <= 0)
                {
                    result.textResult = "คุณแพ้แล้ว!";
                    timer.Stop();
                    timerBot.Stop();
                    timergame.Stop();
                    timerplayerskill.Stop();
                    this.NavigationService.Navigate(new Uri("result.xaml", UriKind.RelativeOrAbsolute));
                }
                else if (botHP3.Value <= 0)
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
            if(rnd.Next(10)>= 8 && Canvas.GetLeft(bot3) <= 650 && Canvas.GetLeft(bot3) >= Canvas.GetLeft(Player3)) //ไปด้านขวา
            {
                Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) + 20);
            }
            else if(Canvas.GetLeft(bot3) >= Canvas.GetLeft(Player3)) //ไปด้านซ้าย
            {
                Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 20);
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
                Player3.Source = new BitmapImage(new Uri(@"\res\"+temp+"2.png", UriKind.Relative));
                status = 2;
            }
            else if(status == 2)
            {
                Player3.Source = new BitmapImage(new Uri(@"\res\" + temp + "3.png", UriKind.Relative));
                status = 3;
            }
            else if (status == 3)
            {
                Player3.Source = new BitmapImage(new Uri(@"\res\" + temp + "4.png", UriKind.Relative));
                status = 4;
            }
            else if (status == 4)
            {
                Player3.Source = new BitmapImage(new Uri(@"\res\" + temp + "1.png", UriKind.Relative));
                status = 1;
            }
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D && Canvas.GetLeft(Player3) <= 680)
            {
                Canvas.SetLeft(Player3, Canvas.GetLeft(Player3) + 20);
                keyD = true;
            }
            else if (e.Key == Key.A && Canvas.GetLeft(Player3) >= 0)
            {
                Canvas.SetLeft(Player3, Canvas.GetLeft(Player3) - 20);
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
