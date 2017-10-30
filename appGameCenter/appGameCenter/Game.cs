using System.Collections.Generic;
//Enumerados

public enum Platforms
{
    PC = 0,
    MAC = 1,
    Linux = 2,
    PS4 = 3,
    XBOXONE = 4,
  }



public enum Genre
{
    Action = 0,
    Strategy = 1,
    RPG = 2,
    Puzzles = 3,
    Adventure = 4,
    Simulation = 5,
    Survival_Horror = 6,
    Sandbox = 7,
}

public class Game
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private Genre genre;

    public Genre Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    //para la funcion importar exportar.
    public Game(string data)
    {
        //
    }

    //Constructor

    private Dictionary<Platforms,Ranking> rankings ;

    public Game(string name, Genre genre, Dictionary<Platforms, Ranking> rankings, List<Platforms> platforms, int releaseDate)
    {
        this.name = name;
        this.genre = genre;
        this.rankings = rankings;
        this.platforms = platforms;
        ReleaseDate = releaseDate;
        if (releaseDate >= 1980 && releaseDate <= 2018)
        {

            this.ReleaseDate = releaseDate;
        }
    }

    public Dictionary<Platforms, Ranking> Rankings
    {
        get { return this.rankings; }
      
    }


    private List<Platforms> platforms;
    public List<Platforms> Platforms
    {
        get { return platforms; }
        set { platforms = value; }
    }

    public int ReleaseDate

    {
        get { return ReleaseDate; }
        set
        {
            if (value >= 1980 && value <= 2018)
            {

                this.ReleaseDate = value;
            }
        }

    }
        //Igualdad

    public override bool Equals(object obj)
    {
        if (obj is Game)
        {
            Game aux = (Game)obj;
            return this.name == aux.name;
        }
        else
        {
            return false;
        }
                   
    }
    //CADENA
//   public Player(string data)
  //  {
    //   string[] splittedData = data.Split('-');
    // this.name = splittedData[0];
      //  this.genre = (Genre)int.Parse(splittedData[1]);
       // this.platforms = (List<Platforms>)int.Parse(splittedData[2]);
         // this.rankings = = (Dictionary)int.Parse(splittedData[3]);
  //  }

    public override string ToString()
    {
        string s = "";
        s = string.Format("---{0}({1}-)", this.Name, this.ReleaseDate);
        foreach (Platforms plataform in this.platforms)
        {
            s += string.Format("{0},", plataform);
        }
        s += string.Format("-{0}---", this.Genre);
        foreach (Platforms ranking in this.Rankings.Keys)
        {
            s += string.Format("-{0}({1})", this.Rankings[ranking].Name, this.Rankings[ranking].Score.Count);
        }
        return s;
    }


}








