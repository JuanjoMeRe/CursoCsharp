using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Ranking
{

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private List<Score> score;

    public List<Score> Score
    {
        get { return score; }
    }
    //CONSTRUCTOR
    public Ranking(string name, List<Score> score)
    {
        this.name = name;
        this.score = score;
    }
    public Ranking()
    {
        this.name = "";
        this.score = null;
    }

    //CADENA

    public Ranking(string data)
    {
        string[] splittedData = data.Split(' ');
        this.name = splittedData[0];
        this.score = (List<Score>)int.Parse(splittedData[1]);
    }



    public override string ToString()
    {
        string res = "";
        res = string.Format("Ranking:{0}\n", this.Name);
        for (int i = 0; i < Score.Count; i++)
        {
            res += string.Format("{0}.{1}\n", Score[i].ToString());
        }
        return res;
    }


}

