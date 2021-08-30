// See https://aka.ms/new-console-template for more information

using System;
using System.Net;


using WebClient client = new WebClient();
string s = client.DownloadString("https://the-rondure-chronicles.com");
Console.WriteLine(s);

Console.ReadLine();
