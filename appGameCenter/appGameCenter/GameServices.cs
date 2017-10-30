using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class GameServices
    {
    private static List<Player> players;

    public static List<Player> Players
    {
        get { return players; }
        
    }

    //Constructor
    private static List<Game> games= new List<Game>();

    
        public static List<Game> Games
    {
        get { return GameServices.games; }
        
    }

    //FUNCION
    private static List<string> ReadFile(string path)
    {
        List<string> lines = new List<string>();
        try
        {
            StreamReader file = File.OpenText(path);
            string line = "";
            while (line != null)
            {
                line = file.ReadLine();
                if (line != null)
                {
                    lines.Add(line);
                }
            }
            file.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al leer fichero\n" + e);
        }
        return lines;
    }
    private static void WriteFile(string path, List<string> lines)
    {
        try
        {
            StreamWriter file = File.CreateText(path);
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
            file.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al escribir archivo\n" + e);
        }
    }

    private static string PATH = "../../data.txt";

      public static void Export()
    {
        string playerData = ConvertPlayerToString();
        string gameData = ConvertGameToString();
        string rankingData = ConvertRankingToString();

        try
        {
            StreamWriter file = File.CreateText(PATH);
            string allData = playerData + "\n*+*+*+*\n" + gameData + "\n*+*+*+*\n" + rankingData;
            file.Write(allData);
            file.Close();
            Console.WriteLine("Datos creados en Data.txt");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al crear Data.txt" + e);
        }

    }

    private static string ConvertPlayerToString()
    {
        string s = "";
        foreach (Player player in Players)
        {
            s += string.Format("{0}\n", player.ToString());
        }
        return s;
    }

    private static string ConvertGameToString()
    {
        string s = "";
        foreach (Game game in Games)
        {
            s += string.Format("{0}-{1}-{2}", game.Name, game.Genre, game.ReleaseDate);
            foreach (Platforms platform in game.Platforms)
            {
                s += string.Format("{0},", platform);
            }
        }
        s += "\n";
        return s;
    }

    private static string ConvertRankingToString()
    {
        string s = "";
        foreach (Game game in Games)
        {
            foreach (Platforms ranking in game.Rankings.Keys)
            {
                s += string.Format("{0}-{1}", game.Name, game.Rankings[ranking].Name);
                foreach (Score score in game.Rankings[ranking].Score)
                {
                    s += string.Format("{0}-{1}", score.Nickname, score.Points);
                }
                s += "\n";
            }
        }
        return s;
    }

    public static void Import()
    {
        List<string> lines = ReadFile(PATH);
        List<string> playerLines = new List<string>();
        List<string> gameLines = new List<string>();
        List<string> rankingLines = new List<string>();

        bool isGame = false;
        bool isPlayer = false;
        bool isRanking = false;

        foreach (string line in lines)
        {
            if (line == "*+*+*+*")
            {
                isGame = true;
            }
            else
            {
                if (!isPlayer)
                {
                    playerLines.Add(line);
                }
                else
                {
                    gameLines.Add(line);
                }
            }
        }
        games = new List<Game>();
        players = new List<Player>();
        foreach (string line in playerLines)
        {
            Player s = new Player(line);
            players.Add(s);
        }
        foreach (string line in gameLines)
        {
            Game l = new Game(line);   //no se hacer el string data.
            games.Add(l);
        }


    }

    //Funcionalidades

    //Juego más antiguo de la empresa
    public static Game OldestGame()
    {
        Game OldestGame = null;
        int year = int.MaxValue;
        foreach (Game game in GameServices.Games)
        {
            int y = game.ReleaseDate;
            if (year > y)
            {
                OldestGame = game;
                year = y;
            }
        }
        return OldestGame;
    }
    //Puntuacion determinado juego en un ranking

    public static int ScoreCount(string nameGame,string nameRanking)
    {
        int res = 0;
        foreach (Game dataGame in Games)
        {
            if (dataGame.Name.ToLower()==nameGame.ToLower())
            {
                foreach (Platforms dataRanking in dataGame.Rankings.Keys)
                {
                    if (dataGame.Rankings[dataRanking].Name.ToLower()==nameRanking)
                    {
                        foreach (Score dataScore in dataGame.Rankings[dataRanking].Score)
                        {
                            res += dataScore.Points;
                        }
                    }
                }
            }

        }
        return res;
    }

    //Cantidad de juegos de un genero
    public static int NamesCountByGenre(Genre genrename)
    {
        int count = 0;
        foreach (Game game in Games)
        {
            if (game.Genre == genrename)
            {
                count++;
            }
        }
        return count;
    }

    public static int GenreName(string genrename)
    {
        int res = 0;
        foreach (Genre dataGenre in Enum.GetValues(typeof(Genre)))
        {
            if (genrename.ToLower()==dataGenre.ToString().ToLower())
            {
                res += NamesCountByGenre(dataGenre);
            }

        }
        return res;
    }



}

