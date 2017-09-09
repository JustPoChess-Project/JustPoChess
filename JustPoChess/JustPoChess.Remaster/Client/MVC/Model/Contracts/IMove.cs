namespace JustPoChess.Remaster.Client.MVC.Model.Contracts
{
    public interface IMove
    {
        IPosition CurrentPosition { get; set; }
        IPosition NextPosition { get; set; }
    }
}