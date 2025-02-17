﻿// Copyright (c) Richasy. All rights reserved.

using System;
using System.Threading.Tasks;
using CleanReader.Models.Constants;
using CleanReader.ViewModels.Desktop;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CleanReader.App.Controls
{
    /// <summary>
    /// 底部提醒.
    /// </summary>
    public sealed partial class TipPopup : UserControl
    {
        /// <summary>
        /// <see cref="Text"/>的依赖属性.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(TipPopup), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Initializes a new instance of the <see cref="TipPopup"/> class.
        /// </summary>
        public TipPopup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TipPopup"/> class.
        /// </summary>
        /// <param name="text">要显示的文本.</param>
        public TipPopup(string text)
            : this()
        {
            Text = text;
        }

        /// <summary>
        /// 显示文本.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// 显示内容.
        /// </summary>
        /// <param name="type">信息级别.</param>
        /// <param name="displaySeconds">显示的时间.</param>
        public async void ShowAsync(InfoType type = InfoType.Information, double displaySeconds = 2)
        {
            ((MainWindow)AppViewModel.Instance.MainWindow).ShowOnHolder(this);
            VisualStateManager.GoToState(this, type.ToString(), false);

            PopupContainer.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(displaySeconds));
            PopupContainer.Visibility = Visibility.Collapsed;
            ((MainWindow)AppViewModel.Instance.MainWindow).RemoveFromHolder(this);
        }
    }
}
