using JustPoChess.Client.View.Menu;
using JustPoChess.Client.MVC;

namespace JustPoChess
{
    public class StartUp
    {
        public static void Main()
        {
            Model model = new Model();
            View viewPlayer1 = new View(model);
            View viewPlayer2 = new View(model);
            Controller controller = new Controller(model, viewPlayer1);
            PlayerMVC player1 = new PlayerMVC(viewPlayer1);
            PlayerMVC player2 = new PlayerMVC(viewPlayer2);

            Server server = new Server();
            Menu.PrintLogo();
        }       
    }
}
