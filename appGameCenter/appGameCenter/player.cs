//Enumerado
public enum Countries
{
    Spain = 0,
    France = 1,
    USA = 2,
    United_Kingdom = 3,
    Japan = 4,
    Italy = 5,
    Brazil = 6,
    Germany = 7,
    Australia = 8,
    Canada = 9
}
public class Player
    {
    //TIPOS


    private string nickname;

    public string Nickname
    {
        get { return nickname; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private Countries country;

   
    public Countries Country
    {
        get { return country; }
        set { country = value; }
    }
    //Constructor
    public Player(string nickname, string email, Countries country)
    {
        this.nickname = nickname;
        this.email = email;
        this.country = country;
    }

    



      
    //Criterio de igualdad
    public override bool Equals(object obj)
    {
        if (obj is Player)
        {
            Player aux = (Player)obj;
            return this.Nickname == aux.Nickname;
        }
        else
        {
            return false;
        }
    }

    //CADENA
    public Player(string data)
    {
        string[] splittedData = data.Split('-');
        this.nickname = splittedData[0];
        this.email = splittedData[1];
        this.country = (Countries)int.Parse(splittedData[2]);

    }
    public override string ToString()
    {
        return string.Format("{0}-{1}-{2})", Nickname, Email,Country);
    }


}


