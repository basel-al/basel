/*
//1
String input = Console.ReadLine();
char[] carray = input.ToCharArray();
Array.Reverse(carray);
string x = new string(carray);
Console.WriteLine(x);

for (int i = input.Length-1; i>=0; i--)
{
    Console.Write(input[i]);
}*/

/*
 * 
//2 
using System.Text;

char[] seperators = new char[] { '.', ',', ';', ':', '=', '[', ']', '\\', '(', ')', '&', '\'', '"', '/', '!', '?' , ' '};
string input = Console.ReadLine();
string[] s = input.Split();
String[] begs;
String[] ends;
//Array.Reverse(s);
List<StringBuilder> au = new List<StringBuilder>();
for(int i = 0; i < s.Length; i++)
{
    for(int j = 0; j<s[j].Length; j++)
    {
        if (seperators.Contains(s[i][j]))
        {
            begs[i] = begs[i].Append(s[i][j]);
        }
    }
    au.Add(new StringBuilder(s[i]));
}



for(int i = 0;i<au.Count; i++)
{
    Console.WriteLine(au.ElementAt(i).ToString());
}
*/
//3
/*
char[] seperators = new char[] { '.', ',', ';', ':', '=', '[', ']', '\\', '(', ')', '&', '\'', '"', '/', '!', '?', ' ' };
string input = Console.ReadLine();
string[] s = input.Split(seperators);
//List<string> palins = new List<string>();
bool isPalindrome = true;
foreach (string s2 in s)
{
    for (int i = 0; i < s2.Length - 1; i++)
    {
        try
        {
            int c = s2[i];
            int v = s2[s2.Length - 1];
            if (c != v)
            {
                isPalindrome = false;
                break;
            }
        }
        catch(Exception e)
        {
            continue;
        }


    }
    if(isPalindrome)
    {
        //palins.Add(s2);
        Console.WriteLine(s2);
    }
    //Console.WriteLine(s2);
   // Console.WriteLine(s2.Length);
}
*/




//4
/*
String protocol ="";
String server ="";
String resource ="";
String URL = Console.ReadLine();
int beg = 0; ;
int fin = 0 ;
for(int i = 0; i < URL.Length; i++)
{

    beg = URL.IndexOf("://");
    fin = URL.LastIndexOf("/");

    protocol = URL.Substring(0, beg);
    String tr = URL.Substring(beg+2, fin);
    server = tr.Substring(1, tr.Length - 1);
    resource = URL.Substring(fin + 1);
}


Console.WriteLine("[protocol] = " + "\"" + protocol + "\"");
Console.WriteLine("[server] = " + "\"" + server + "\"");
Console.WriteLine("[resource] = " + "\"" + resource  + "\"");
*/
