using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml.Media.Animation;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LoginPageWinUI3.PageUI
{
    public sealed partial class MainLoginPage : Page
    {
        public static MainLoginPage mainLoginPage { get; set; } = null!;
        private DoubleAnimation BallAnimation1 { get; set; } = new DoubleAnimation();
        private DoubleAnimation BallAnimation2 { get; set; } = new DoubleAnimation();
        public MainLoginPage()
        {
            InitializeComponent();
            mainLoginPage = this;
            FrameLoginRegister.Navigate(typeof(LoginPage), null, new DrillInNavigationTransitionInfo());

            BallAnimation1 = (DoubleAnimation)StoryboardMoveBall.Children[0];
            BallAnimation2 = (DoubleAnimation)StoryboardMoveBall.Children[1];

            Task.Delay(100).ContinueWith(_ =>
            {
                StartAnimationBall();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void StartAnimationBall()
        {
            BallAnimation1.SetValue(DoubleAnimation.FromProperty, TranslateEllipse1.X > -20? GridMainLoginPage.ActualWidth : -20);
            BallAnimation1.SetValue(DoubleAnimation.ToProperty, TranslateEllipse1.X > -20 ? -20 : GridMainLoginPage.ActualWidth);

            BallAnimation2.SetValue(DoubleAnimation.FromProperty, TranslateEllipse2.X > 20 ? -GridMainLoginPage.ActualWidth : 20);
            BallAnimation2.SetValue(DoubleAnimation.ToProperty, TranslateEllipse2.X > 20 ? 20 : -GridMainLoginPage.ActualWidth);

            StoryboardMoveBall.Begin();
        }

        public void LoginPage()
        {
            FrameLoginRegister.Navigate(typeof(LoginPage), null, new DrillInNavigationTransitionInfo());
        }

        public void RegisterPage()
        {
            FrameLoginRegister.Navigate(typeof(RegisterPage), null, new DrillInNavigationTransitionInfo());
        }

        private void GridMainLoginPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            StoryboardMoveBall.Stop();
            StartAnimationBall();
        }
    }
}
