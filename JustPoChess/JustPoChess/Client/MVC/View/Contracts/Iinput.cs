using JustPoChess.Client.MVC.Model.Contracts;

namespace JustPoChess.Client.MVC.View.Contracts
{
    public interface Iinput
    {
        string GetUserInput();
        
        bool ValidateUserInputSyntax(string inputString);

        IMove ParseMove(string inputString);

        bool ValidateUserInput(string inputString);
    }
}