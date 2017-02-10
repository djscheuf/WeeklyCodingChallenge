<Query Kind="Program">
  <NuGetReference>FsCheck</NuGetReference>
</Query>

// Caesar Cipher (+1)
string Encrypt(string s) => new string(s.Select(c=>(char)((c+1)%128)).ToArray());
string Decrypt(string s) => new string(s.Select(c=>(char)(c<1?127:c-1)).ToArray());

void Main()
{
	Func<char, string> esc = c => "\\" + (Char.IsControl(c) ? "x" + ((int)c).ToString("x4") : ""+c);
    Func<string, string> @out = s => Regex.Replace(s, "[\0-\x1f\x7f\\\\\"]", m => esc(m.Value[0]));
    Func<string, string> name = s => Regex.Replace(s, @"^\s*//\s*|\s*$", "");
    Func<string, string> body = s => Regex.Replace(s, @"^\s*string\s+(En|De)crypt\(string\s+\w+\)(\s*=>)?\s*|\s*$", "");
    var lines = Util.CurrentQuery.Text.Split(new[] { "\r\n" }, 4, StringSplitOptions.None);
    var output = lines
        .Zip(new[] { name, body, body }, (s, f) => f(s))
        .Select(s => new { Original = s, Encrypted = Encrypt(s) })
        .Zip(new[] { "Name", "Encrypt", "Decrypt" }, (item, Sample) =>
        new
        {
            Sample,
            Encrypted = @out(item.Encrypted),
            O = item.Original.Length,
            E = item.Encrypted.Length,
        });
    output.Dump();

    // Test Data Generator
    var gen = 
		FsCheck.GenExtensions.Where(
			FsCheck.Arb.Generate<string>(),
        	x => x != null &&
                 x.Length > 1 && 
                 x.Length < 128 && 
                 x.All(c => c < 128));
    // Properties
	FsCheck.Check.Verbose(
	    FsCheck.Prop.ForAll<string>(
	        FsCheck.Arb.From(gen),
	        s => {
				Func<bool, FsCheck.Property> toProp = FsCheck.PropertyExtensions.ToProperty;
				Func<bool, string, FsCheck.Property> label = FsCheck.PropertyExtensions.Label;
				Func<FsCheck.Property, FsCheck.Property, FsCheck.Property> and = FsCheck.PropertyExtensions.And;
	            var e = Encrypt(s);
				var props = new[] {
					new { p = e != null && e.Length > 0, l = "Output from the Encrypt function must be non-null, non-empty strings" },
					new { p = e.All(c => c < 128), l = "Output from the Encrypt function must contain only ASCII characters" },
                    new { p = s.Length < 3 || e != s, l = "Output from the Encrypt function must be nontrivial for strings greater than length 2" },
                    new { p = e == Encrypt(s), l = "Output from the Encrypt function must be the same if it is called multiple times" },
                    new { p = Decrypt(e) == s, l = "Output from the Encrypt composed with the Decrypt function is the identity" }
                };
                return props.Aggregate(toProp(true), (a, x) => and(a, label(x.p, x.l)));
            }));
}