﻿using System.IO;
using GJson;
using Xunit;

namespace GJsonTests
{
	public partial class Tests
	{
		[Fact]
		public void SimpleData()
		{
			var v = new JsonValue();

			v["a"] = 32;
			Assert.Equal<int>(v["a"], 32);

			v["b"] = true;
			Assert.Equal<bool>(v["b"], true);

			v["c"] = false;
			Assert.Equal<bool>(v["c"], false);

			v["a"] = 254;
			Assert.Equal<byte>((byte)v["a"], (byte)254);

			v["a"] = 32;
			Assert.Equal<long>(v["a"], 32);

			v["a"] = 32;
			Assert.Equal<char>((char)v["a"], (char)32);

			v["a"] = 123.99942001;
			Assert.Equal<double>(v["a"], 123.99942001);

			v["a"] = double.NaN;
			Assert.Equal<double>(v["a"], double.NaN);

            v["a"] = -double.NaN;
            Assert.Equal<double>(v["a"], -double.NaN);

            v["a"] = float.Epsilon;
            Assert.Equal<double>(v["a"], float.Epsilon);

            v["a"] = 123.12333f;
			Assert.Equal<float>(v["a"], 123.12333f);

		    v["a"] = long.MaxValue;
            Assert.Equal<float>(v["a"], long.MaxValue);

            v["a"] = "";
            Assert.Equal<string>(v["a"], "");

            v["a"] = "ABCefg";
            Assert.Equal<string>(v["a"], "ABCefg");

            v["a"] = "АБВгде";
            Assert.Equal<string>(v["a"], "АБВгде");

            v["a"] = "AcciÃ³n";
            Assert.Equal<string>(v["a"], "AcciÃ³n");

            v["a"] = "\x11\x45";
            Assert.Equal<string>(v["a"], "\x11\x45");
        }

		[Fact]
		public void StringData()
		{
			var v = new JsonValue();

			string t;

			t = "abc";
			v["a"] = t;
			Assert.Equal(v["a"], t);
			t = "aBc";
			v["a"] = t;
			Assert.Equal(v["a"], t);
			t = "abc\\2";
			v["a"] = t;
			Assert.Equal(v["a"], t);
			t = "abc\n";
			v["a"] = t;
			Assert.Equal(v["a"], t);
			t = "\n";
			v["a"] = t;
			Assert.Equal(v["a"], t);
			t = "\r";
			v["a"] = t;
			Assert.Equal(v["a"], t);
			t = "\t\t44\r";
			v["a"] = t;
			Assert.Equal(v["a"], t);
			t = "\"fdsfds\"";
			v["a"] = t;
			Assert.Equal(v["a"], t);
			t = "\'fdsfds\'";
			v["a"] = t;
			Assert.Equal(v["a"], t);
		}

		[Fact]
		public void ReadWrite()
		{
			var v = new JsonValue();
            
			v["a"] = 32;
			v["d"]["a"] = "gfd";
			v["e"]["a"] = "gfd";
			v["e"]["b"] = 543.423;
			v["e"]["c"] = false;
			v["f"][0] = "gfd";
			v["f"][1]["a"] = 543.423;
			v["f"][1]["b"] = 43242342;
            v["f"][1]["c"] = 1111111.2;
            v["f"][1]["d"] = long.MaxValue;
            v["f"][2] = false;

			var s1 = v.ToStringIdent();
			var v2 = JsonValue.Parse(s1);
			var s2 = v2.ToStringIdent();

			Assert.Equal(s1, s2);

			var v3 = JsonValue.Parse(File.ReadAllText(".\\..\\GJsonTests\\TestFiles\\test.json"));
			var s3 = v3.ToStringIdent();
			File.WriteAllText("test_out.json", s3);

			var v4 = JsonValue.Parse(File.ReadAllText("test_out.json"));
			var s4 = v4.ToStringIdent();

			Assert.Equal(s3, s4);
		}
	}
}