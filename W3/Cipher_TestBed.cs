using System;
using System.Linq;

class P {
  static string Encrypt(string s)
 	{
 		var o="..".Split('.');
 		for(var i=0;i<s.Length;i++)
 			o[i%3]+=s[i];
 		return s.Last()+string.Join("",o);
 	}
 	
  static string Decrypt(string s)
	{
		var t=Encrypt(s.Remove(0,1));
		var p=t;
		while(t!=s)
		{
			p=t;
			t=Encrypt(t.Remove(0,1));
			
		}
		return p.Remove(0,1);
	}
  
  static int Attack(string s)
  {
  	//Console.WriteLine("Attack Phase ");
  	//Console.WriteLine("\tInput: {0}",s);
  	//Console.WriteLine("\tInput Length: {0}",s.Length);
  	var e = Encrypt(s);
  	//Console.WriteLine("\tEncrypted: {0}",e);
  	
  	var temp = e;
  	var i=0;
  	while(temp!=s && i<int.MaxValue)
  	{
			temp = Encrypt(temp);
			i++;
  	}
  	//Console.WriteLine("\tCompleted at {0}.\n\tDecryption: {1}",i,temp);
  	return i;
  }
  
  static void TestCase(string s)
  {
  	var e = Encrypt(s);
    var d = Decrypt(e);
    var pass = d==s;
    if(pass)
    	Console.WriteLine("Passed");
    else
    	Console.WriteLine("Failed!!!");
    Console.WriteLine ("Simple Test:\n\tInput:{0}",s);
    Console.WriteLine("\tEncrypt: {0}\n\tDecrypt: {1}\n",e,d);
    
  }
  
  public static void Main (string[] args) {
    TestCase("Hello, World!");
    TestCase("The once and future king.");
    TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    TestCase("r?!ETm2");
    TestCase(")");
    TestCase("y>4");
    
    //Attack("Hello, World!");
    //Attack("The once and future king.");
    //Attack("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    //Attack("r?!ETm2");
    /*
    var m = Enumerable.Range(3,125).Select(i=> Attack(new string(Enumerable.Range(0,i).Select(c=> (char)c).ToArray()))).Max();
    Console.WriteLine("Max Atk Count: {0}",m);
    */
    /*
    Attack("ABCD");
    Attack("ABCDE");
    Attack("ABCDEF");
    Attack("ABCDEFG");
    Attack("ABCDEFGH");
    Attack("ABCDEFGHI");
    Attack("ABCDEFGHIJ");
    Attack("ABCDEFGHIJK");
    Attack("ABCDEFGHIJKL");
    Attack("ABCDEFGHIJKLM");
    Attack("ABCDEFGHIJKLMN");
    Attack("ABCDEFGHIJKLMNO");
    Attack("ABCDEFGHIJKLMNOP");
    Attack("ABCDEFGHIJKLMNOPQ");
    Attack("ABCDEFGHIJKLMNOPQR");
    Attack("ABCDEFGHIJKLMNOPQRS");
    Attack("ABCDEFGHIJKLMNOPQRST");
    Attack("ABCDEFGHIJKLMNOPQRSTU");
    Attack("ABCDEFGHIJKLMNOPQRSTUV");
    Attack("ABCDEFGHIJKLMNOPQRSTUVW");
    Attack("ABCDEFGHIJKLMNOPQRSTUVWX");
    Attack("ABCDEFGHIJKLMNOPQRSTUVWXY");
    Attack("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    */
  }
}