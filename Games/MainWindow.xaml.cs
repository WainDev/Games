﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Games;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SetUpGame();
    }

    private void SetUpGame()
    {
        List<string> animalEmoji = new List<string>()
            {
                "🐱‍🐉", "🐱‍🐉",
                "👽", "👽",
                "🧜‍♀️", "🧜‍♀️",
                "🧛‍♀️", "🧛‍♀️",
                "🐗", "🐗",
                "🙈", "🙈",
                "🦊", "🦊",
                "🐶", "🐶",
                "🐹", "🐹",
                "👻", "👻",
            };

        Random rnd = new Random();

        foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
        {
            int index = rnd.Next(animalEmoji.Count);

            string nextEmoji = animalEmoji[index];

            textBlock.Text = nextEmoji;

            animalEmoji.RemoveAt(index);
        }
    }

    TextBlock lastTextBlockClicked;

    bool findingMatch = false;

    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextBlock textBlock = (TextBlock)sender;

        if (findingMatch == false)
        {
            textBlock.Visibility = Visibility.Hidden;
            lastTextBlockClicked = textBlock;
            findingMatch = true;
        } 
        else if (textBlock.Text == lastTextBlockClicked.Text)
        {
            textBlock.Visibility= Visibility.Hidden;
            findingMatch= false;
        }
        else
        {
            lastTextBlockClicked.Visibility= Visibility.Visible; 
            findingMatch = false;
        }
    }
}