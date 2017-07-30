using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPoChess.Client.MVC.View.Art
{
    public static class GameArt
    {
        public static string WhitePawn = @" _ 
                                           ( )
                                           / \
                                           ===";
        public static string BlackPawn = @" _ 
                                           (#)
                                           /#\
                                           ===";

        public static string WhiteKnight = @" ,^. 
                                             (  '\
                                             |  \ 
                                             ====";

        public static string BlackKnight = @" ,^. 
                                             (##'\
                                             |##\ 
                                             ====";

        public static string WhiteQueen = @"_+_
                                            \ /
                                            ( )
                                            / \
                                            ===";

        public static string BlackQueen = @"_+_
                                            \#/
                                            (#)
                                            /#\
                                            ===";

        public static string WhiteRook = @"uuuu
                                           |  |
                                           /  \
                                           ====";

        public static string BlackRook = @"uuuu
                                           |##|
                                           /##\
                                           ====";

        public static string WhiteKing = @"www
                                           \ /
                                           ( )
                                           / \
                                           ===";

        public static string BlackKing = @"www
                                           \#/
                                           (#)
                                           /#\
                                           ===";

        public static string WhiteBishop = @" o  
                                             ( /)
                                             /  \
                                             ====";

        public static string BlackBishop = @" o  
                                             (#/)
                                             /##\
                                             ====";
    }
}
