using System.Collections.Generic;

namespace ProcessFileDataConsole
{
    public class Bandas
    {
        public static List<Banda> getBandas()
        {
            List<Banda> lista = new List<Banda>();
            lista.Add(new Banda("Led Zeppelin", 0));
            lista.Add(new Banda("Beatles", 0));
            lista.Add(new Banda("Pink Floyd", 0));
            lista.Add(new Banda("Jimi Hendrix", 0));
            lista.Add(new Banda("Van Halen", 0));
            lista.Add(new Banda("Queen", 0));
            lista.Add(new Banda("Eagles", 0));
            lista.Add(new Banda("Metallica", 0));
            lista.Add(new Banda("U2", 0));
            lista.Add(new Banda("The Police", 0));
            lista.Add(new Banda("The Doors", 0));
            lista.Add(new Banda("Stone Temple Pilots", 0));
            lista.Add(new Banda("Rush", 0));
            lista.Add(new Banda("Genesis", 0));
            lista.Add(new Banda("Prince", 0));
            lista.Add(new Banda("Yes", 0));
            lista.Add(new Banda("Earth Wind and Fire", 0));
            lista.Add(new Banda("Bee Gees", 0));
            lista.Add(new Banda("Rolling Stones", 0));
            lista.Add(new Banda("Beach Boys", 0));
            lista.Add(new Banda("Soundgarden", 0));
            lista.Add(new Banda("The Who", 0));
            lista.Add(new Banda("Steely Dan", 0));
            lista.Add(new Banda("AC/DC", 0));
            lista.Add(new Banda("Fleetwood Mac", 0));
            lista.Add(new Banda("Crosby", 0));
            lista.Add(new Banda("Allman Brothers", 0));
            lista.Add(new Banda("ZZ Top", 0));
            lista.Add(new Banda("Aerosmith", 0));
            lista.Add(new Banda("Cream", 0));
            lista.Add(new Banda("Bruce Springsteen", 0));
            lista.Add(new Banda("Grateful Dead", 0));
            lista.Add(new Banda("Guns'N Roses", 0));
            lista.Add(new Banda("Pearl Jam", 0));
            lista.Add(new Banda("Boston", 0));
            lista.Add(new Banda("Dire Straits", 0));
            lista.Add(new Banda("King Crimson", 0));
            lista.Add(new Banda("Parliament", 0));
            lista.Add(new Banda("Red Hot Chili Peppers", 0));
            lista.Add(new Banda("Bon Jovi", 0));
            lista.Add(new Banda("Dixie Chicks", 0));
            lista.Add(new Banda("Foreigner", 0));
            lista.Add(new Banda("David Bowie", 0));
            lista.Add(new Banda("Talking Heads", 0));
            lista.Add(new Banda("Jethro Tull", 0));
            lista.Add(new Banda("The Band", 0));
            lista.Add(new Banda("Beastie Boys", 0));
            lista.Add(new Banda("Nirvana", 0));
            lista.Add(new Banda("Rage Against The Machine", 0));
            lista.Add(new Banda("Sly", 0));
            lista.Add(new Banda("Clash", 0));
            lista.Add(new Banda("Tool", 0));
            lista.Add(new Banda("Journey", 0));
            lista.Add(new Banda("No Doubt", 0));
            lista.Add(new Banda("Creedence", 0));
            lista.Add(new Banda("Deep Purple", 0));
            lista.Add(new Banda("Alice In Chains", 0));
            lista.Add(new Banda("Orbital", 0));
            lista.Add(new Banda("Little Feat", 0));
            lista.Add(new Banda("Duran Duran", 0));
            lista.Add(new Banda("Living Colour", 0));
            lista.Add(new Banda("Frank Zappa", 0));
            lista.Add(new Banda("Carpenters", 0));
            lista.Add(new Banda("Audioslave", 0));
            lista.Add(new Banda("Pretenders", 0));
            lista.Add(new Banda("Primus", 0));
            lista.Add(new Banda("Blondie", 0));
            lista.Add(new Banda("Black Sabbath", 0));
            lista.Add(new Banda("Lynyrd Skynyrd", 0));
            lista.Add(new Banda("Sex Pistols", 0));
            lista.Add(new Banda("Isaac Hayes", 0));
            lista.Add(new Banda("R.E.M.", 0));
            lista.Add(new Banda("Traffic", 0));
            lista.Add(new Banda("Buffalo Springfield", 0));
            lista.Add(new Banda("Derek", 0));
            lista.Add(new Banda("O'Jays", 0));
            lista.Add(new Banda("Harold Melvin", 0));
            lista.Add(new Banda("Underworld", 0));
            lista.Add(new Banda("Thievery Corporation", 0));
            lista.Add(new Banda("Motley Crue", 0));
            lista.Add(new Banda("Janis Joplin", 0));
            lista.Add(new Banda("Blind Faith", 0));
            lista.Add(new Banda("Animals", 0));
            lista.Add(new Banda("Roots", 0));
            lista.Add(new Banda("Velvet Underground", 0));
            lista.Add(new Banda("Kinks", 0));
            lista.Add(new Banda("Radiohead", 0));
            lista.Add(new Banda("Scorpions", 0));
            lista.Add(new Banda("Kansas", 0));
            lista.Add(new Banda("Iron Maiden", 0));
            lista.Add(new Banda("Motorhead", 0));
            lista.Add(new Banda("Judas Priest", 0));
            lista.Add(new Banda("Orb", 0));
            lista.Add(new Banda("The Cure", 0));
            lista.Add(new Banda("Coldplay", 0));
            lista.Add(new Banda("Slayer", 0));
            return lista;
        }
    }

    public class Banda
    {
        public Banda(string nome, int quantidade)
        {
            Nome = nome;
            Quantidade = quantidade;
        }

        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
