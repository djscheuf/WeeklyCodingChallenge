using System;
using System.Linq;
class Cipher 
{
	public Cipher(string title, string name, string encrypt, string decrypt)	
	{
		Title = title; Name = name; Encrypt = encrypt; Decrypt = decrypt;
	}
	
	public string Title;
	public string Name;
	public string Encrypt;
	public string Decrypt;
	
}

class Decipher {
	
	static void Attack_Shift(string s,string match="")
  {
  	/*
		Console.WriteLine("Ceaser Shift Attack");
		Console.WriteLine("\tTarget: {0}",s);
		*/
		for(var i = 1; i<128;i++)
		{
			var t = new string(s.Select(c=>(char)((c+i)%128)).ToArray());
			if(ReasonableOutput(t))
				Console.WriteLine("\tShift Atk: {0}\n\tDecrypted: {1}",i,t);
			if(t==match)
				Console.WriteLine("\tShift Atk: {0}\n\t\tMatched Decrypted: {1}",i,t);
		}
  }
  
  static void Attack_Rot(string s,string match="")
  {
  	/*
  	Console.WriteLine("Rotation Attack");
		Console.WriteLine("\tTarget: {0}",s);
		*/
		for(var i = 0; i<26; i++)
		{
			var t = new string(s.Select(c=> Rot13(c,i)).ToArray());
			if(ReasonableOutput(t))
				Console.WriteLine("\tRot Atk: {0}\n\tDecrypted: {1}",i,t);
			if(t==match)
				Console.WriteLine("\tRot Atk: {0}\n\t\tMatched Decrypted: {1}",i,t);
		}
  }
  
  static char Rot13(char c,int mod)
    {
        if ('a' <= c && c <= (char)('a'+mod) || 'A' <= c && c <= (char)('A'+mod))
        {
            return (char)(c + mod);
        }
        if ((char)('a'+mod+1) <= c && c <= 'z' || (char)('A'+mod+1) <= c && c <= 'Z')
        {
            return (char)(c - mod);
        }
        return c;
    }
  
  static void Attack_Rails(string s,string match="")
  {
  	/*
  	Console.WriteLine("Rail Attack");
		Console.WriteLine("\tTarget: {0}",s);
		*/
		for(var i = 1; i<74; i++)
		{
			var t = Rail(s,i);
			if(ReasonableOutput(t))
				Console.WriteLine("\tRails Atk: {0}\n\tDecrypted: {1}",i,t);
			if(t==match)
				Console.WriteLine("\tRails Atk: {0}\n\t\tMatched Decrypted: {1}",i,t);
		}
  }
  
  static string Rail(string s, int rails)
  {
  	var o=new string('.',rails).Split('.');
 		for(var i=0;i<s.Length;i++)
 			o[i%rails]+=s[i];
 		return string.Join("",o);
  }
  
  static bool ReasonableOutput(string t)
  {
  	if ((t.Contains('(') && t.Contains(')'))||(t.Contains('{') && t.Contains('}')))
  		return true;
  	if (t.Contains(';'))
  		return true;
  	if(t.Contains("var") || t.Contains("new") || t.Contains("string"))
  		return true;
  	
  	return false;
  	
  }
	
	static void AttackPattern(Cipher c)
	{
		Console.WriteLine ("Target: {0}",c.Title);
    /*
    Attack_Shift(c.Name,c.Title);
    Console.WriteLine ("\nAttacking Encryption");
    Attack_Shift(c.Encrypt);
    */
    Console.WriteLine ("\nAttacking Decryption");
    Attack_Shift(c.Decrypt);
    Attack_Rot(c.Decrypt);
    Attack_Rails(c.Decrypt);
	}
	
  public static void Main (string[] args) {
    Console.WriteLine ("Attempting to Decrypt");
    
    //Pos. ROT-15 cipher
    var ides = new Cipher("The Ides of March"
    	,"r<M\x0005.IJX\x00054K\x00052FWHK"
    	,"]!o((3&(\"5&i/&8<s50k\x0009\"+$1%\x001bnri00_D\x001fNJ\x0003N\x0005K_`\x0010\x0007\x0019rs5Y&k&D]f_l`\x001d)fqo{\x001fv\x001dj4h/y\x001dj/\x001eS\x000b\x0010\x0009\x001aQPP\x0009V S\x000bQNVciZ.Z_$l"
    	, "\x0018h3\x001c!4ZZeXZTgX\x001baS\\ro4j%C\\e^k_U(fa\x001fiNN)XT\x000dX\x000fUij,S\\`]\"F\x0013X\x00131JSLY\\\x000dVZaXdMVW]R\x0006S\x001d#\x000e\x000c\x0008\x0014\x0015\x001b\x001dD\x0011[\x000fV D\x000f!\x001e\x001bV[Te\x001c\x001b\x001b$%+ \x000e\x000f&Y\x0011WS_`fW+Z\x000fk{\x001f\x000fT\x000a\x001c" );
    
    var sloppy_shifter = new Cipher( "Sloppy Shifter"
    	,"=M~\x000e\x000f\x0014\x000a=\x000d\x001cnL^*"
    	, ">N-\x001dlui-}\x001de\x0004$%N5j<]L\\>E\x0005\x000c5M\x0015\x0017We\x000c=\x000c\x001e%\x0015\x0005\x0005\x000c5&\x0016e\x00155\x000e;5\x000d\x00156\x0015\x0014^5iL]l~M\x000bUw\x0005\x0015\x0014V\x0016'\x0005\x0015\x0015\x00175u~=\x000d\x001cnL^*"
    	,",\\|_\x0005j,^\x000dL\x001c<U\x0004.=M~\x000e\x000f\x0014%h\x001c|~,\\|\x001eLU\x000e5E\x000c\x0015Ku\x0017Wh]l>/\x001e\x000eE\x000c\x0015\x0015\x0015D%\x0005e%\x0015\x0005o4%6D^5iL]l~M\x00054/U\x0014%D$F$F\x0014%\x0017:");
    
    AttackPattern(ides);
    AttackPattern(sloppy_shifter);

  }
}
      
      