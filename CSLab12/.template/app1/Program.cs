using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary d = new Dictionary();
        d.Add("dictionary", "словарь", "справочник");
        d.Add("cat", "кот", "кошка", "животное семейства кошачьих");
        d.Add("forum", "форум", "собрание", "суд");
        d.Add("fdefew", "акау", "пкупку", "пкуйкпу", "пекпер");
        d.Remove("cat");
        for (int i = 0; i < d.Length; i++)
        {
            Console.WriteLine(d[i]);
        }
    }
}

class Dictionary
{
    List<Node> list = new List<Node>();

    public void Add(string word, params string[] translations)
    {
        Node n = new Node(word, translations);
        list.Add(n);
    }

    public void Remove(string word)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Word == word)
            {
                list.RemoveAt(i);
                return;
            }
        }
    }

    public int Length
    {
        get { return list.Count; }
    }
    public string this[int index]
    {
        get { return list[index].ToString(); }
    }

    private class Node
    {
        public string Word;
        string[] Translations;

        public Node(string word, params string[] translations)
        {
            Word = word;
            Translations = translations;
        }

        public override string ToString()
        {
            string s = string.Format("{0} = [", Word);
            for (int i = 0; i < Translations.Length - 1; i++)
            {
                s += Translations[i] + ", ";
            }
            s += string.Format("{0}]", Translations[Translations.Length - 1]);
            return s;
        }
    }
}
