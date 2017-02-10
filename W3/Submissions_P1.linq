<Query Kind="Program">
  <NuGetReference>FsCheck</NuGetReference>
</Query>

class PigLatin
{
// Igpae Atinlae - Dirty cheap and simple! Yey! Regex! Buenos Suerte!
string Encrypt(string s){var t=Regex.Replace(s,@"(\w)(\w*)","$2$1ae");/*wonderful new obfustaction!*/return 'i'+t;}
string Decrypt(string s){var t=s.Remove(0,1); /*mas obfustaction!*/ return Regex.Replace(t,@"(\w*)(\w)ae","$2$1");}
}

class RailCipher
{
//Bound back and forth. Good Luck! 'Once more into the fray.'
string Encrypt(string s){if(s.Length<4)return '_'+s;var o=new string[]{"","",""};for(var i=0;i<s.Length;i++)o[i%3]+=s[i];return string.Join("",o);}
string Decrypt(string s){if(s.Length<=4 && s[0]=='_')return s.Remove(0,1);var t=Encrypt(s);var p=t;while(t!=s){p=t;t=Encrypt(t);}return p;}
}

class VigenereLike
{
// Many Ceaser Shifts. Viel Gluck! 'And to the last good fight I'll ever know'
string Encrypt(string s){var l=s.Length;/*new/var/[i++]*/return new string(s.Select(c=>(char)(((c-(l--))%128+128)%128)).ToArray());/*rav string wen*/}
string Decrypt(string s){var l=s.Length;/*stuff'n'things!*/return new string(s.Select(c=>(char)((c+((l--)))%128)).ToArray());/*rav wen new string*/}
}