using System;
using System.Configuration;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.View.Art;
using JustPoChess.Client.MVC.View.Sounds;

namespace JustPoChess.Client.MVC.View.Contracts
{
    public interface IView
    {
        IModel Model { get; }
        
        void InitialScreen();
        void InitializeMenu();
        void StopMusic();
        void PrintBoard();
        void MirrorPrintBoard();
    }
}