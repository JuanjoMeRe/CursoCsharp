using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Score
    {
    private string nickname;

    public string Nickname
    {
        get { return nickname; }
       
    }
    public int Points
    {
        get { return points; }
        set { points = value; }
    }
        //Constructor
    private int points;

    public Score(string nickname, int points)
    {
        this.nickname = nickname;
        this.points = (points >= 0) ? points : 0;
    }

    //CADENA
    public Score (string data)
    {
        string[] splittedData = data.Split(' ');
        this.nickname = splittedData[0];
        this.points = int.Parse(splittedData[1]);
    }
    public override string ToString()
    {
        string res = "";
        res = string.Format("{0}-{1}", this.Nickname, this.Points);
        return res;
    }



}

